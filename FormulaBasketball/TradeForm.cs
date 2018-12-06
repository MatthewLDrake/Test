﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            foreach(player p in team)
            {
                grid.Rows.Add(false, p.getName(), String.Format("{0:0.00}", p.getOverall()), p.getDevelopment(), p.GetMoneyPerYear());
            }
            List<DraftPick> picks = team.GetPicks();
            foreach(DraftPick p in picks)
            {
                grid.Rows.Add(false, "Season 6 Round " + p.GetRound() + " pick from " + p.GetTeamOfOrigin(), "???", "B", 0);
            }
            picks = team.GetNextSeasonPicks();
            foreach (DraftPick p in picks)
            {
                grid.Rows.Add(false, "Season 7 Round " + p.GetRound() + " pick from " + p.GetTeamOfOrigin(), "???", "B", 0);
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
                    mainTeamTradeInfo.Rows.Add(mainTeamGrid[1, cell.RowIndex].Value);
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
                    otherTeamTradeInfo.Rows.Add(otherTeamGrid[1, cell.RowIndex].Value);
                }
                cell.Value = !((bool)cell.Value);
            }
        }
    }
}
