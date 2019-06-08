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
    public partial class TradeForm : Form
    {
        private createTeams create;
        private team team;
        private int teamNum;
        public static bool master = true;
        public TradeForm(createTeams create, team mainTeam, int teamNum)
        {
            InitializeComponent();
            team = mainTeam;
            this.create = create;
            this.teamNum = teamNum;

            for(int i = 0; i < create.size(); i++)
            {
                if(i == teamNum)continue;
                teamList.Items.Add(create.getTeam(i).ToString());
            }

            teamList.SelectedIndex = 0;
            FillGridWithTeam(mainTeamGrid, mainTeam);
        }
        public TradeForm(createTeams create, Trade prevTrade)
        {
            InitializeComponent();
            this.create = create;
            this.team = create.getTeam(prevTrade.teamOneID);
            teamNum = prevTrade.teamOneID;

            for (int i = 0; i < create.size(); i++)
            {
                if (i == teamNum) continue;
                teamList.Items.Add(create.getTeam(i).ToString());
            }

            int index = prevTrade.teamTwoID;
            if (index > teamNum) index--;
            teamList.SelectedIndex = index;
            FillGridWithTeam(mainTeamGrid, team);

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
            foreach(player p in team.GetOffSeasonPlayers(false))
            {
                grid.Rows.Add(false, p.getName(), p.getPosition(), String.Format("{0:0.00}", p.getOverall()), p.getDevelopment(), p.GetMoneyPerYear(), p);
            }
            List<DraftPick> picks = team.GetPicks();
            foreach(DraftPick p in picks)
            {
                grid.Rows.Add(false, "Season 6 Round " + p.GetRound() + " pick from " + p.GetTeamOfOrigin(),"?", "???", "B", 0, p);
            }
            picks = team.GetNextSeasonPicks();
            foreach (DraftPick p in picks)
            {
                grid.Rows.Add(false, "Season 7 Round " + p.GetRound() + " pick from " + p.GetTeamOfOrigin(), "?", "???", "B", 0, p);
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
                        OfferedTrade offered = new OfferedTrade(trade, create, teamNum);
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
            theDialog.Title = "Open Trade File";
            theDialog.Filter = "FBTrade files|*.fbtrade";
            theDialog.Multiselect = false;
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Trade t = TradeForm.DeSerializeObject(theDialog.FileName);
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
                    FormulaBasketball.Menu.menu.UpdatePicks();
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
            if (TradeForm.master) return TradeForm.master;
            return team.Equals(teamTwoName);
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
