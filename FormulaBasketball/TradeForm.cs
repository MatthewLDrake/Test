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
using System.Windows.Controls;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class TradeForm : Form
    {
        private createTeams create;
        private team team;
        private int teamNum;
        public static bool master;
        private bool offseason;
        public TradeForm(createTeams create, team mainTeam, int teamNum, bool master, bool offseason = false)
        {
            InitializeComponent();
            team = mainTeam;
            this.create = create;
            this.offseason = offseason;
            this.teamNum = teamNum;
            TradeForm.master = master;
            for(int i = 0; i < create.size(); i++)
            {
                if(i == teamNum)continue;
                teamList.Items.Add(create.getTeam(i).ToString());
            }

            teamList.SelectedIndex = 0;
            FillGridWithTeam(mainTeamGrid, mainTeam);
        }
        public TradeForm(createTeams create, Trade prevTrade, bool master, bool offseason = false)
        {
            InitializeComponent();
            this.create = create;
            this.offseason = offseason;
            this.team = create.getTeam(prevTrade.teamTwoID);
            TradeForm.master = master;
            teamNum = prevTrade.teamTwoID;

            for (int i = 0; i < create.size(); i++)
            {
                if (i == teamNum) continue;
                teamList.Items.Add(create.getTeam(i).ToString());
            }

            int index = prevTrade.teamOneID;
            if (index > teamNum) index--;
            teamList.SelectedIndex = index;
            FillGridWithTeam(mainTeamGrid, team);

            foreach(object item in prevTrade.GetTeamOneTradeItems())
            {
                if(item is player)
                {
                    for(int i = 0; i < otherTeamGrid.Rows.Count; i++)
                    {
                        object value = otherTeamGrid[6, i].Value;
                        if(value is player && (value as player).Equals(item as player))
                        {
                            otherTeamGrid.Rows[i].Cells[0].Value = true;
                            otherTeamTradeInfo.Rows.Add(otherTeamGrid[1, i].Value, otherTeamGrid[6, i].Value);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < otherTeamGrid.Rows.Count; i++)
                    {
                        object value = otherTeamGrid[6, i].Value;
                        if (value is DraftPick && (value as DraftPick).Equals(item as DraftPick))
                        {
                            otherTeamGrid.Rows[i].Cells[0].Value = true;
                            otherTeamTradeInfo.Rows.Add(otherTeamGrid[1, i].Value, otherTeamGrid[6, i].Value);
                        }
                    }
                }
            }
            foreach (object item in prevTrade.GetTeamTwoTradeItems())
            {
                if (item is player)
                {
                    for (int i = 0; i < mainTeamGrid.Rows.Count; i++)
                    {
                        object value = mainTeamGrid[6, i].Value;
                        if (value is player && (value as player).Equals(item as player))
                        {
                            mainTeamGrid.Rows[i].Cells[0].Value = true;
                            mainTeamTradeInfo.Rows.Add(mainTeamGrid[1, i].Value, mainTeamGrid[6, i].Value);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < mainTeamGrid.Rows.Count; i++)
                    {
                        object value = mainTeamGrid[6, i].Value;
                        if (value is DraftPick && (value as DraftPick).Equals(item as DraftPick))
                        {
                            mainTeamGrid.Rows[i].Cells[0].Value = true;
                            mainTeamTradeInfo.Rows.Add(mainTeamGrid[1, i].Value, mainTeamGrid[6, i].Value);
                        }
                    }
                }
            }

        }

        private void teamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            otherTeamTradeInfo.Rows.Clear();
            int index = teamList.SelectedIndex;
            if (index >= teamNum) index++;
            FillGridWithTeam(otherTeamGrid, create.getTeam(index));
        }


        private void FillGridWithTeam(DataGridView grid, team team)
        {
            grid.Rows.Clear();
            if(offseason)
            {

                foreach (player p in team.GetOffSeasonPlayers())
                {                    
                    grid.Rows.Add(false, p.getName(), p.getPosition(), p.getOverall(), p.getDevelopment(), p.GetMoneyPerYear(), p);
                }
            }
            else
            {
                foreach (player p in team.getActivePlayers())
                {
                    grid.Rows.Add(false, p.getName(), p.getPosition(), p.getOverall(), p.getDevelopment(), p.GetMoneyPerYear(), p);
                }
            }
            
            List<DraftPick> picks = team.GetPicks();
            foreach(DraftPick p in picks)
            {
                grid.Rows.Add(false, "Season " + createTeams.currentSeason  + " Round " + p.GetRound() + " pick from " + p.GetTeamOfOrigin(create),"?", "???", "B", 0, p);
            }
            picks = team.GetNextSeasonPicks();
            foreach (DraftPick p in picks)
            {
                grid.Rows.Add(false, "Season " + (createTeams.currentSeason + 1) + " Round " + p.GetRound() + " pick from " + p.GetTeamOfOrigin(create), "?", "???", "B", 0, p);
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (teamList.SelectedIndex > 0) teamList.SelectedIndex--; 
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (teamList.SelectedIndex < 30) teamList.SelectedIndex++;
        }

        private void mainTeamGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mainTeamGrid.SelectedCells == null || mainTeamGrid.SelectedCells.Count < 1) return;
            DataGridViewCell cell = mainTeamGrid.SelectedCells[0];
            if (cell.ColumnIndex == 0)
            {
                if ((bool)cell.Value)
                {
                    for (int i = 0; i < mainTeamTradeInfo.Rows.Count; i++)
                    {
                        if (mainTeamTradeInfo.Rows[i].Cells[0].Value.Equals(mainTeamGrid[1, cell.RowIndex].Value))
                        {
                            mainTeamTradeInfo.Rows.Remove(mainTeamTradeInfo.Rows[i]);
                            break;
                        }
                    }
                    
                }
                else
                {
                    mainTeamTradeInfo.Rows.Add(mainTeamGrid[1, cell.RowIndex].Value, mainTeamGrid[6, cell.RowIndex].Value);
                }
                cell.Value = !((bool)cell.Value);
            }

            
        }

        private void otherTeamGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (otherTeamGrid.SelectedCells == null || otherTeamGrid.SelectedCells.Count < 1) return;
            DataGridViewCell cell = otherTeamGrid.SelectedCells[0];
            if (cell.ColumnIndex == 0)
            {
                if ((bool)cell.Value)
                {
                    for (int i = 0; i < otherTeamTradeInfo.Rows.Count; i++)
                    {
                        if (otherTeamTradeInfo.Rows[i].Cells[0].Value.Equals(otherTeamGrid[1, cell.RowIndex].Value))
                        {
                            otherTeamTradeInfo.Rows.Remove(otherTeamTradeInfo.Rows[i]);
                            break;
                        }
                    }

                }
                else
                {
                    otherTeamTradeInfo.Rows.Add(otherTeamGrid[1, cell.RowIndex].Value, otherTeamGrid[6, cell.RowIndex].Value);
                }
                cell.Value = !((bool)cell.Value);
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if(mainTeamTradeInfo.Rows.Count == 0 || otherTeamTradeInfo.Rows.Count == 0)
            {
                MessageBox.Show("You cannot have a trade with 0 items in it");
                return;
            }
            List<object> teamOneTradeItems = new List<object>();
            List<object> teamTwoTradeItems = new List<object>();

            for(int i = 0; i < mainTeamTradeInfo.Rows.Count; i++)
            {
                teamOneTradeItems.Add(mainTeamTradeInfo.Rows[i].Cells[1].Value);
            }
            for (int i = 0; i < otherTeamTradeInfo.Rows.Count; i++)
            {
                teamTwoTradeItems.Add(otherTeamTradeInfo.Rows[i].Cells[1].Value);
            }

            int index = teamList.SelectedIndex;
            if (index >= teamNum) index++;
            String firstTeam = team.ToString();
            String otherTeam = create.getTeam(index).ToString();

            string fileName = firstTeam + "_" + otherTeam + ".fbtrade";

            Trade trade = new Trade(teamOneTradeItems, teamTwoTradeItems, firstTeam, otherTeam, teamNum, index);

            SerializeObject(trade, fileName);

            MessageBox.Show("Trade saved successfully. It is called " + fileName + " and is in the same directory as the exe");

        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Trade File";
            theDialog.Filter = "FBTrade files|*.fbtrade";
            theDialog.Multiselect = false;
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string file = theDialog.FileName;
                Trade trade = DeSerializeObject(file);
                if(trade != null)
                {
                    if (trade.CanView(team.ToString()))
                    {
                        OfferedTrade offered = new OfferedTrade(trade, create);
                        offered.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("This trade is not for your team.");
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public static void SerializeObject(Trade serializableObject, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, serializableObject);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        /// <summary>
        /// Deserializes a binary file into an object list
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <returns></returns>
        public static Trade DeSerializeObject(string fileName)
        {
            Trade temp = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream(fileName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                temp = (Trade)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            return temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Trade Response File";
            theDialog.Filter = "FB Trade Response files|*.fbtr";
            theDialog.Multiselect = false;
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Trade t = TradeForm.DeSerializeObject(theDialog.FileName);

                    team teamOne = create.getTeam(t.teamOneID);
                    team teamTwo = create.getTeam(t.teamTwoID);

                    teamOne.TradeOccurred(t.GetTeamOneTradeItems(), t.GetTeamTwoTradeItems(), create.getFreeAgents(), teamNum == t.teamOneID);
                    teamTwo.TradeOccurred(t.GetTeamTwoTradeItems(), t.GetTeamOneTradeItems(), create.getFreeAgents(), teamNum == t.teamTwoID);
                }
                catch (Exception)
                {
                    MessageBox.Show("Trade was rejected");
                }
            }
        }
    }
    [Serializable]
    public class Trade
    {

        private List<object> teamOneTradeItems, teamTwoTradeItems;
        private String teamOneName, teamTwoName;
        public int teamOneID, teamTwoID;
        public Trade(List<object> teamOne, List<object> teamTwo, String teamOneName, String teamTwoName, int teamOneID, int teamTwoID)
        {
            teamOneTradeItems = teamOne;
            teamTwoTradeItems = teamTwo;
            this.teamOneName = teamOneName;
            this.teamTwoName = teamTwoName;
            this.teamOneID = teamOneID;
            this.teamTwoID = teamTwoID;
        }
        public bool CanView(String team)
        {
            return TradeForm.master || team.Equals(teamTwoName);
        }
        public List<object> GetTeamOneTradeItems()
        {
            return teamOneTradeItems;
        }
        public List<object> GetTeamTwoTradeItems()
        {
            return teamTwoTradeItems;
        }
        public String GetTeamOneName()
        {
            return teamOneName;
        }
        public String GetTeamTwoName()
        {
            return teamTwoName;
        }
    }
}
