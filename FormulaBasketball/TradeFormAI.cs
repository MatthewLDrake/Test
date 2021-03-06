﻿using System;
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
    public partial class TradeFormAI : Form
    {
        private createTeams create;
        private bool offseason;
        public static bool master;
        public TradeFormAI(createTeams create, int teamNum, bool master, bool offseason)
        {
            InitializeComponent();
            this.create = create;
            TradeFormAI.master = master;
            for(int i = 0; i < create.size(); i++)
            {
                teamList.Items.Add(create.getTeam(i).ToString());
                aiTeamList.Items.Add(create.getTeam(i).ToString());
            }
            this.offseason = offseason;
            teamList.SelectedIndex = 0;
            aiTeamList.SelectedIndex = teamNum;
            
        }
        public TradeFormAI(createTeams create, Trade prevTrade, bool master, bool offseason)
        {
            InitializeComponent();
            this.create = create;
            TradeFormAI.master = master;
            this.offseason = offseason;
            for (int i = 0; i < create.size(); i++)
            {
                teamList.Items.Add(create.getTeam(i).ToString());
                aiTeamList.Items.Add(create.getTeam(i).ToString());
            }

            aiTeamList.SelectedIndex = prevTrade.teamTwoID;
            teamList.SelectedIndex = prevTrade.teamOneID;

            foreach (object item in prevTrade.GetTeamOneTradeItems())
            {
                if (item is player)
                {
                    for (int i = 0; i < otherTeamGrid.Rows.Count; i++)
                    {
                        object value = otherTeamGrid[6, i].Value;
                        if (value is player && (value as player).Equals(item as player))
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
            FillGridWithTeam(otherTeamGrid, create.getTeam(index), offseason);
        }


        private void FillGridWithTeam(DataGridView grid, team team, bool offseason)
        {
            grid.Rows.Clear();
            if (offseason)
            {
                foreach (player p in team.GetOffSeasonPlayers())
                {
                    grid.Rows.Add(false, p.getName(), p.getPosition(), p.getOverall(), p.getDevelopment(), p.GetMoneyPerYear(), p);
                }
            }
            else
            {
                foreach (player p in team.GetOffSeasonPlayers())
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

            String firstTeam = create.getTeam(aiTeamList.SelectedIndex).ToString();
            String otherTeam = create.getTeam(teamList.SelectedIndex).ToString();

            string fileName = firstTeam + "_" + otherTeam + ".fbtrade";

            Trade trade = new Trade(teamOneTradeItems, teamTwoTradeItems, firstTeam, otherTeam, aiTeamList.SelectedIndex, teamList.SelectedIndex);

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
                    OfferedTrade offered = new OfferedTrade(trade, create);
                    offered.ShowDialog();                    
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

                    teamOne.TradeOccurred(t.GetTeamOneTradeItems(), t.GetTeamTwoTradeItems(), create.getFreeAgents(), false);
                    teamTwo.TradeOccurred(t.GetTeamTwoTradeItems(), t.GetTeamOneTradeItems(), create.getFreeAgents(), false);
                }
                catch (Exception)
                {
                    MessageBox.Show("Trade was rejected");
                }
            }
        }

        private void aiTeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainTeamTradeInfo.Rows.Clear();
            int index = aiTeamList.SelectedIndex;
            FillGridWithTeam(mainTeamGrid, create.getTeam(index), offseason);
        }
    }    
}
