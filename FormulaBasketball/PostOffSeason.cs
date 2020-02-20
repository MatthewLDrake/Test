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
    public partial class PostOffSeason : Form
    {
        public createTeams create;
        private int teamNum;
        private bool master;
        public static PostOffSeason current;
        private team team;
        private List<player> rookies;
        private DraftPick[] picks;
        private List<int> humans;
        private Scouting scoutingForm;
        private Random r;
        public PostOffSeason(createTeams create, Random r)
        {
            InitializeComponent();

            this.create = create;
            humans = new List<int>
            {
                2, 7, 19
            };
            //create.Progress(humans);

            current = this;

            this.r = r;

            picks = new DraftPick[64];

            rookies = create.GetRookies();

            

        }
        private void LaunchFreeAgency()
        {
            FreeAgencyForm free = new FreeAgencyForm(create, create.getTeam(2));
            free.ShowDialog();
        }
        private void LaunchRoster()
        {
            new LeagueRoster(new List<int>(), create).ShowDialog();
        }
        private void teamSelected(object sender, EventArgs e)
        {
            teamNum = int.Parse((String)((RadioButton)sender).Tag);
            groupBox1.Visible = false;
            tableLayoutPanel1.Visible = true;
            master = teamNum == 2;
            if(!master)
            {
                button1.Text = "Cut Players";
            }
            button2.Visible = master;
            team = create.getTeam(teamNum);

            scoutingForm = new Scouting(rookies, team.GetScout(), r);
            create.SetupSalaryInfo();

            foreach (team t in create.getTeams())
            {
                foreach (DraftPick pick in t.GetPicks())
                {
                    pick.SetSeason(6);
                }
                foreach (DraftPick pick in t.GetNextSeasonPicks())
                {
                    pick.SetSeason(7);
                }
                if (t.GetDraftPlace() < 10) t.DraftStrategy = DraftStrategy.REBUILD;
                else if (t.GetDraftPlace() < 20) t.DraftStrategy = DraftStrategy.WIN_SOON;
                else t.DraftStrategy = DraftStrategy.WIN_NOW;

//                t.StartOffSeason();

            }

            foreach (team t in create.getTeams())
            {
                foreach (DraftPick pick in t.GetPicks())
                {
                    picks[pick.GetPickNumber() - 1] = pick;
                }
            }

        }

        private void awardsButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            TradeForm tradeForm = new TradeForm(create, team, teamNum, master);
            tradeForm.ShowDialog();
            this.Visible = true;
        }

        private void scoutButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            draft draft = new draft(rookies, picks, humans, new FormulaBasketball.Random(69420));
            draft.ShowDialog();
            this.Visible = true;
            create.getFreeAgents().Add(draft.GetUndraftedPlayers());
            scoutButton.Enabled = false;
            resignPlayersButton.Enabled = true;

            create.FinishOffseason(humans);     
        }

        private void resignPlayersButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DepthChart depthChart = new DepthChart(team);
            depthChart.ShowDialog();
            this.Visible = true;
        }

        private void viewRoster_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ViewRoster rosterForm = new ViewRoster(team.GetOffSeasonPlayers(false));
            rosterForm.ShowDialog();
            this.Visible = true;
        }

        private void viewDLeagueRoster_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ViewRoster rosterForm = new ViewRoster(team.GetAffiliate().getAllPlayer());
            rosterForm.ShowDialog();
            this.Visible = true;
        }

        private void advanceButtons_Click(object sender, EventArgs e)
        {
            if (master)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;

                dialog.ShowDialog();


                String[] fileNames = dialog.FileNames;
                foreach(string file in fileNames)
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

                    if(team != null)
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

                if (extension.Equals(".fbtrade"))
                {
                    Trade trade = TradeForm.DeSerializeObject(fileName);
                    if (trade.CanView(team.ToString()))
                    {
                        OfferedTrade offer = new OfferedTrade(trade, create);
                        offer.ShowDialog();
                    }

                    // TODO: something with trades
                }
                else if (extension.Equals(".fbdata"))
                {
                    create = formulaBasketball.DeSerializeObject(fileName);
                    resignPlayersButton.Enabled = true;
                    awardsButton.Enabled = true;
                    team = create.getTeam(teamNum);
                }
                else if (extension.Equals(".fbtr"))
                {
                    try
                    {
                        Trade t = TradeForm.DeSerializeObject(fileName);
                        team teamOne = create.getTeam(t.teamOneID);
                        team teamTwo = create.getTeam(t.teamTwoID);

                        foreach (Object item in t.GetTeamOneTradeItems())
                        {
                            if (item is player)
                            {
                                player p = item as player;
                                teamOne.OffSeasonRemovePlayer(p);
                                teamTwo.OffSeasonAddPlayer(p);
                            }
                            else if (item is DraftPick)
                            {
                                DraftPick p = item as DraftPick;
                                teamOne.RemoveDraftPick(p, p.GetSeason() == 6);
                                teamTwo.AddDraftPick(p, p.GetSeason() == 6);
                            }
                        }
                        foreach (Object item in t.GetTeamTwoTradeItems())
                        {
                            if (item is player)
                            {
                                player p = item as player;
                                teamTwo.OffSeasonRemovePlayer(p);
                                teamOne.OffSeasonAddPlayer(p);
                            }
                            else if (item is DraftPick)
                            {
                                DraftPick p = item as DraftPick;
                                teamTwo.RemoveDraftPick(p, p.GetSeason() == 6);
                                teamOne.AddDraftPick(p, p.GetSeason() == 6);
                            }
                        }
                        UpdatePicks();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Trade was rejected");
                    }
                }
            }

        }
        public void UpdatePicks()
        {
            picks = new DraftPick[64];

            foreach (team t in create.getTeams())
            {
                foreach (DraftPick pick in t.GetPicks())
                {
                    picks[pick.GetPickNumber() - 1] = pick;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (master)
            {
                System.Threading.Thread thread = new System.Threading.Thread(LaunchRoster);
                thread.Start();
            }
            else
            {
                new CutPlayers(team, create).ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string content = "";
            for(int i = 0; i < 5; i++)
            {
                content += "Countries,Player,Position,Layup,Dunk,Jumpshot,3PT,Pass,ShotContest,DefenseIQ,Jumping,Seperation,Durability,Stamina,Development,Age,Overall\n";
                foreach(player p in create.getFreeAgents().GetPlayersByPos(i + 1))
                {
                    if(p.getTeam() == null)
                        content += p.GetCountry() + "," + p.getName() + "," + p.getPosition() + "," + p.getLayupRating(false) + "," + p.getDunkRating(false) + "," + p.getJumpShotRating(false) + "," + p.getThreeShotRating(false) + "," + p.getPassing(false) + "," + p.getShotContestRating(false) + "," + p.getDefenseIQRating(false) + "," + p.getJumpingRating(false) + "," + p.getSeperation(false) + "," + p.getDurabilityRating(false) + "," + p.getStaminaRating(false) + "," + p.getDevelopment() + "," + p.age + "," + p.getOverall() + "\n";
                }
            }
            File.WriteAllText("freeAgents.csv", content);
            System.Threading.Thread thread = new System.Threading.Thread(LaunchFreeAgency);
            thread.Start();
        }
    }
}
