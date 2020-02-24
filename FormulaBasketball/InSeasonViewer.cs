using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class InSeasonViewer : Form
    {
        private int teamNum;
        private bool master;
        private createTeams create;
        private team team;
        
        public InSeasonViewer(createTeams create)
        {
            InitializeComponent();
            this.create = create;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            teamNum = int.Parse((String)((RadioButton)sender).Tag);
            groupBox1.Visible = false;
            tableLayoutPanel1.Visible = true;
            master = teamNum == 2;
            team = create.getTeam(teamNum);
            if(teamNum == 7)
            {
                tableLayoutPanel1.BackColor = Color.FromArgb(255, 153, 0);
                label2.BackColor = Color.FromArgb(56, 118, 29);
                label2.ForeColor = Color.FromArgb(235, 235, 235);
            }
            else
            {
                tableLayoutPanel1.BackColor = Color.FromArgb(0,43,255);
                label2.BackColor = Color.FromArgb(255, 255, 255);
                label2.ForeColor = Color.FromArgb(25, 25, 25);
            }
            label2.Text = team.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (master)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;

                dialog.ShowDialog();

                String[] fileNames = dialog.FileNames;
                foreach (string file in fileNames)
                {
                    team team = null;
                    FileStream fs = new FileStream(file, FileMode.Open);
                    try
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        // Deserialize the hashtable from the file and 
                        // assign the reference to the local variable.
                        team = (team)formatter.Deserialize(fs);
                    }
                    catch (SerializationException exc)
                    {
                        Console.WriteLine("Failed to deserialize. Reason: " + exc.Message);
                        throw;
                    }
                    finally
                    {
                        fs.Close();
                    }

                    if (team != null)
                    {
                        create.ReplaceTeam(team);//.getTeamNum();
                    }
                }
                FileStream createFS = new FileStream("NextSeason.fbdata", FileMode.Create);

                // Construct a BinaryFormatter and use it to serialize the data to the stream.
                BinaryFormatter outFormatter = new BinaryFormatter();
                try
                {
                    outFormatter.Serialize(createFS, create);
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                    throw;
                }
                finally
                {
                    createFS.Close();
                }
            }
            else
            {
                string fileName = team.ToString() + "Roster.fbteam";
                FileStream fs = new FileStream(fileName, FileMode.Create);

                // Construct a BinaryFormatter and use it to serialize the data to the stream.
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, team);
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
            MessageBox.Show("File Saved");
        }

        private void LaunchStandings()
        {
            Standings standings = new Standings(false);
            standings.updateStandings(create, true);
            standings.ShowDialog();
        }
        private void LaunchRoster()
        {
            LeagueRoster roster = new LeagueRoster(new List<int>(), create);
            roster.ShowDialog();
        }
        private void LaunchStats()
        {
            StatsForm statsForm = new StatsForm(create, teamNum);
            statsForm.ShowDialog();
        }
        private void LaunchNamingForm()
        {
            NamingForm namingForm = new NamingForm(create);
            namingForm.ShowDialog();
        }
        private void LaunchTeamRoster()
        {
            TeamRoster rosterForm = new TeamRoster(create, teamNum);
            rosterForm.ShowDialog();
        }
        private void LaunchScrimamgeForm()
        {
            ScrimmageForm form = new ScrimmageForm(create, teamNum);
            form.ShowDialog();
        }
        private void standingsButton_Click(object sender, EventArgs e)
        {
            System.Threading.Thread thread = new System.Threading.Thread(LaunchStandings);
            thread.Start();
        }

        private void viewRosterButton_Click(object sender, EventArgs e)
        {
            System.Threading.Thread thread = new System.Threading.Thread(LaunchRoster);
            thread.Start();
        }
        
        private void statsButton_Click(object sender, EventArgs e)
        {
            System.Threading.Thread thread = new System.Threading.Thread(LaunchStats);
            thread.Start();
        }

        private void tradeButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (master && e.Button.Equals(MouseButtons.Right))
            {
                TradeFormAI tradeForm = new TradeFormAI(create, teamNum, master);
                tradeForm.ShowDialog();
            }
            else
            {
                TradeForm tradeForm = new TradeForm(create, team, teamNum, master);
                tradeForm.ShowDialog();
            }
        }

        private void teamRosterButton_Click(object sender, EventArgs e)
        {
            System.Threading.Thread thread = new System.Threading.Thread(LaunchTeamRoster);
            thread.Start();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Open Formula Basketball File";
            fileDialog.Filter = "FBData files (*.fbdata)|*.fbdata|FBTrade files (*.fbtrade)|*.fbtrade|FB Trade Response File (*.fbtr)|*.fbtr";
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = fileDialog.FileName;
                string extension = Path.GetExtension(fileName);

                if(extension.Equals(".fbtrade"))
                {
                    Trade trade = TradeForm.DeSerializeObject(fileName);
                    if (trade.CanView(team.ToString()))
                    {
                        OfferedTrade offer = new OfferedTrade(trade, create);
                        offer.ShowDialog();
                    }
                    
                    // TODO: something with trades
                }
                else if(extension.Equals(".fbdata"))
                {
                    create = formulaBasketball.DeSerializeObject(fileName);
                    team = create.getTeam(teamNum);
                }
                else if(extension.Equals(".fbtr"))
                {
                    try
                    {
                        Trade t = TradeForm.DeSerializeObject(fileName);
                        team teamOne = create.getTeam(t.teamOneID);
                        team teamTwo = create.getTeam(t.teamTwoID);

                        teamOne.TradeOccurred(t.GetTeamOneTradeItems(), t.GetTeamTwoTradeItems(), create.getFreeAgents(), teamNum == t.teamOneID);
                        teamTwo.TradeOccurred(t.GetTeamTwoTradeItems(), t.GetTeamOneTradeItems(), create.getFreeAgents(), teamNum == t.teamTwoID);
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Trade was rejected");
                    }
                }
            }
            
        }

        private void scrimmageButton_Click(object sender, EventArgs e)
        {
            System.Threading.Thread thread = new System.Threading.Thread(LaunchScrimamgeForm);
            thread.Start();
        }

        private void newCoachesButton_Click(object sender, EventArgs e)
        {
            System.Threading.Thread thread = new System.Threading.Thread(LaunchNamingForm);
            thread.Start();
        }
    }
}
