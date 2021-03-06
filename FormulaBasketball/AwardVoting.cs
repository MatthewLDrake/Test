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
// TODO: Fix the fooking award confirm button
namespace FormulaBasketball
{
    public partial class AwardVoting : Form
    {
        private createTeams create;
        private List<player> mvpPlayers, rotyPlayers;
        private List<Coach> coaches;
        public AwardVoting(createTeams create)
        {
            InitializeComponent();
            this.create = create;
            mvpPlayers = new List<player>();
            rotyPlayers = new List<player>();
            coaches = new List<Coach>();
            UpdateGrid(top10MVPGrid, mvpPlayers);
            UpdateGrid(top10ROTYGrid, rotyPlayers);
            UpdateGrid(top10CoachingGrid, coaches);
            for(int i = 0; i < create.size(); i++)
            {
                team curr = create.getTeam(i);
                foreach(player p in curr)
                {
                    if (p.getMinutes() > 2000)
                    {
                        MVPCandidates.Rows.Add("Add Player", p.getName(), p, curr.ToString());
                    }
                    if (p.Rookie())
                    {
                        rotyCandidateGrid.Rows.Add("Add Player", p.getName(), p, curr.ToString());
                    }
                }
                curr.getCoach().Team = curr;
                coachingCandidates.Rows.Add("Add Coach", curr.getCoach().getName(), curr.getCoach(), curr.ToString());
            }
        }

        private void top10MVPGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            topTenPlayerStatsGrid.Rows.Clear();
            foreach(DataGridViewRow row in top10MVPGrid.SelectedRows)
            {
                if (row.Cells[3].Value != null)
                {
                    player p = row.Cells[3].Value as player;
                    double shootingPercentage = 0.0, opponentPercentage = 0.0;
                    if (p.getShotsTaken() != 0)
                    {

                        shootingPercentage = ((double)p.getShotsMade() / (double)p.getShotsTaken()) * 100;
                    }
                    double plus_minus = 0.0;
                    if (p.getGamesPlayed() != 0)
                    {
                        plus_minus = ((double)p.teamPoints / (double)p.getGamesPlayed());
                    }
                    if (p.getShotsAttemptedAgainst() != 0)
                        opponentPercentage = ((double)p.getShotsMadeAgainst() / (double)p.getShotsAttemptedAgainst()) * 100;
                    topTenPlayerStatsGrid.Rows.Add(p.getPoints(), p.getAssists(), p.getRebounds(), String.Format("{0:0.00}", shootingPercentage), String.Format("{0:0.00}", opponentPercentage), String.Format("{0:0.00}", plus_minus));
                }
            }
                
        }

        private void MVPCandidates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            candidateStatsGrid.Rows.Clear();
            foreach (DataGridViewRow row in MVPCandidates.SelectedRows)
            {
                if (row.Cells[2].Value != null)
                {
                    player p = row.Cells[2].Value as player;
                    double shootingPercentage = 0.0, opponentPercentage = 0.0;
                    if (p.getShotsTaken() != 0)
                    {

                        shootingPercentage = ((double)p.getShotsMade() / (double)p.getShotsTaken()) * 100;
                    }
                    double plus_minus = 0.0;
                    if (p.getGamesPlayed() != 0)
                    {
                        plus_minus = ((double)p.teamPoints / (double)p.getGamesPlayed());
                    }
                    if (p.getShotsAttemptedAgainst() != 0)
                        opponentPercentage = ((double)p.getShotsMadeAgainst() / (double)p.getShotsAttemptedAgainst()) * 100;
                    candidateStatsGrid.Rows.Add(p.getPoints(), p.getAssists(), p.getRebounds(), String.Format("{0:0.00}", shootingPercentage), String.Format("{0:0.00}", opponentPercentage), String.Format("{0:0.00}", plus_minus));
                }
            }
        }

        private void MVPCandidates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                player p = senderGrid[2, e.RowIndex].Value as player;
                if (e.ColumnIndex == 0)
                {
                    if (!mvpPlayers.Contains(p))
                    {
                        mvpPlayers.Add(p);
                        UpdateGrid(top10MVPGrid, mvpPlayers);
                    }
                }

            }
        }

        private void MVPCandidates_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            player p = MVPCandidates[2, MVPCandidates.SelectedCells[0].RowIndex].Value as player;
            new PlayerStats(p).ShowDialog();
        }
        private void UpdateGrid(DataGridView grid, List<player> players)
        {
            grid.Rows.Clear();
            int place = 1;
            for (int i = players.Count - 1; i >= 0; i-- )
            {
                grid.Rows.Add(place, players[i].getName(),players[i].getTeam().ToString(), players[i], i);
                place++;
            }


            for (; place < 11; place++)
                grid.Rows.Add(place, "Empty", null, null, -1);
        }
        private void UpdateGrid(DataGridView grid, List<Coach> coaches)
        {
            grid.Rows.Clear();
            int place = 1;
            for (int i = coaches.Count - 1; i >= 0; i--)
            {
                grid.Rows.Add(place, coaches[i].getName(), coaches[i], i, coaches[i].Team.ToString());
                place++;
            }


            for (; place < 11; place++)
                grid.Rows.Add(place, "Empty", null, -1, "");
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (top10MVPGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("You may only use the down button if there is only one row selected.");
                return;
            }
            if (top10MVPGrid.Rows[top10MVPGrid.SelectedRows[0].Index].Cells[3].Value == null)
            {
                MessageBox.Show("You may not move an empty spot.");
                return;
            }
            if (top10MVPGrid.Rows.Count == top10MVPGrid.SelectedRows[0].Index + 1)
            {
                MessageBox.Show("This is already on the bottom.");
                return;
            }
            if(top10MVPGrid.Rows[top10MVPGrid.SelectedRows[0].Index + 1].Cells[3].Value == null)
            {
                MessageBox.Show("This is already on the bottom.");
                return;
            }

            int selectedRow = top10MVPGrid.SelectedRows[0].Index;

            player topPlayer = top10MVPGrid.Rows[selectedRow].Cells[3].Value as player;
            player bottomPlayer = top10MVPGrid.Rows[selectedRow + 1].Cells[3].Value as player;

            int firstIndex = (int)top10MVPGrid.Rows[selectedRow].Cells[4].Value;
            int secondIndex = (int)top10MVPGrid.Rows[selectedRow + 1].Cells[4].Value;

            mvpPlayers[firstIndex] = bottomPlayer;
            mvpPlayers[secondIndex] = topPlayer;

            UpdateGrid(top10MVPGrid, mvpPlayers);

            top10MVPGrid.Rows[0].Selected = false;
            top10MVPGrid.Rows[selectedRow + 1].Selected = true;
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (top10MVPGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("You may only use the up button if there is only one row selected.");
                return;
            }
            if (top10MVPGrid.Rows[top10MVPGrid.SelectedRows[0].Index].Cells[3].Value == null)
            {
                MessageBox.Show("You may not move an empty spot.");
                return;
            }
            if (top10MVPGrid.SelectedRows[0].Index == 0)
            {
                MessageBox.Show("This is already on top.");
                return;
            }
            int selectedRow = top10MVPGrid.SelectedRows[0].Index;

            player topPlayer = top10MVPGrid.Rows[selectedRow].Cells[3].Value as player;
            player bottomPlayer = top10MVPGrid.Rows[selectedRow - 1].Cells[3].Value as player;

            int firstIndex = (int)top10MVPGrid.Rows[selectedRow].Cells[4].Value;
            int secondIndex = (int)top10MVPGrid.Rows[selectedRow - 1].Cells[4].Value;

            mvpPlayers[firstIndex] = bottomPlayer;
            mvpPlayers[secondIndex] = topPlayer;

            UpdateGrid(top10MVPGrid, mvpPlayers);

            top10MVPGrid.Rows[0].Selected = false;
            top10MVPGrid.Rows[selectedRow - 1].Selected = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (top10MVPGrid.SelectedRows.Count != 2)
            {
                MessageBox.Show("You may only use the swap button if there are exactly two rows selected.");
                return;
            }
            if (top10MVPGrid.Rows[top10MVPGrid.SelectedRows[0].Index].Cells[3].Value == null || top10MVPGrid.Rows[top10MVPGrid.SelectedRows[1].Index].Cells[3].Value == null)
            {
                MessageBox.Show("You may not swap an empty spot.");
                return;
            }
            int originalIndex = top10MVPGrid.SelectedRows[0].Index, secondaryIndex = top10MVPGrid.SelectedRows[1].Index;

            player topPlayer = top10MVPGrid.Rows[originalIndex].Cells[3].Value as player;
            player bottomPlayer = top10MVPGrid.Rows[secondaryIndex].Cells[3].Value as player;

            int firstIndex = (int)top10MVPGrid.Rows[originalIndex].Cells[4].Value;
            int secondIndex = (int)top10MVPGrid.Rows[secondaryIndex].Cells[4].Value;

            mvpPlayers[firstIndex] = bottomPlayer;
            mvpPlayers[secondIndex] = topPlayer;

            UpdateGrid(top10MVPGrid, mvpPlayers);

            top10MVPGrid.Rows[0].Selected = false;
            top10MVPGrid.Rows[secondaryIndex].Selected = true;
            top10MVPGrid.Rows[originalIndex].Selected = true;
        }

        private void rotySwapButton_Click(object sender, EventArgs e)
        {
            if (top10ROTYGrid.SelectedRows.Count != 2)
            {
                MessageBox.Show("You may only use the swap button if there are exactly two rows selected.");
                return;
            }
            if (top10ROTYGrid.Rows[top10ROTYGrid.SelectedRows[0].Index].Cells[3].Value == null || top10ROTYGrid.Rows[top10ROTYGrid.SelectedRows[1].Index].Cells[3].Value == null)
            {
                MessageBox.Show("You may not swap an empty spot.");
                return;
            }
            int originalIndex = top10ROTYGrid.SelectedRows[0].Index, secondaryIndex = top10ROTYGrid.SelectedRows[1].Index;

            player topPlayer = top10ROTYGrid.Rows[originalIndex].Cells[3].Value as player;
            player bottomPlayer = top10ROTYGrid.Rows[secondaryIndex].Cells[3].Value as player;

            int firstIndex = (int)top10ROTYGrid.Rows[originalIndex].Cells[4].Value;
            int secondIndex = (int)top10ROTYGrid.Rows[secondaryIndex].Cells[4].Value;

            rotyPlayers[firstIndex] = bottomPlayer;
            rotyPlayers[secondIndex] = topPlayer;

            UpdateGrid(top10ROTYGrid, rotyPlayers);

            top10ROTYGrid.Rows[0].Selected = false;
            top10ROTYGrid.Rows[secondaryIndex].Selected = true;
            top10ROTYGrid.Rows[originalIndex].Selected = true;
        }

        private void rotyUpButton_Click(object sender, EventArgs e)
        {
            if (top10ROTYGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("You may only use the up button if there is only one row selected.");
                return;
            }
            if (top10ROTYGrid.Rows[top10ROTYGrid.SelectedRows[0].Index].Cells[3].Value == null)
            {
                MessageBox.Show("You may not move an empty spot.");
                return;
            }
            if (top10ROTYGrid.SelectedRows[0].Index == 0)
            {
                MessageBox.Show("This is already on top.");
                return;
            }
            int selectedRow = top10ROTYGrid.SelectedRows[0].Index;

            player topPlayer = top10ROTYGrid.Rows[selectedRow].Cells[3].Value as player;
            player bottomPlayer = top10ROTYGrid.Rows[selectedRow - 1].Cells[3].Value as player;

            int firstIndex = (int)top10ROTYGrid.Rows[selectedRow].Cells[4].Value;
            int secondIndex = (int)top10ROTYGrid.Rows[selectedRow - 1].Cells[4].Value;

            rotyPlayers[firstIndex] = bottomPlayer;
            rotyPlayers[secondIndex] = topPlayer;

            UpdateGrid(top10ROTYGrid, rotyPlayers);

            top10ROTYGrid.Rows[0].Selected = false;
            top10ROTYGrid.Rows[selectedRow - 1].Selected = true;
        }

        private void rotyDownButton_Click(object sender, EventArgs e)
        {
            if (top10ROTYGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("You may only use the down button if there is only one row selected.");
                return;
            }
            if (top10ROTYGrid.Rows[top10ROTYGrid.SelectedRows[0].Index].Cells[3].Value == null)
            {
                MessageBox.Show("You may not move an empty spot.");
                return;
            }
            if (top10ROTYGrid.Rows.Count == top10ROTYGrid.SelectedRows[0].Index + 1)
            {
                MessageBox.Show("This is already on the bottom.");
                return;
            }
            if (top10ROTYGrid.Rows[top10ROTYGrid.SelectedRows[0].Index + 1].Cells[3].Value == null)
            {
                MessageBox.Show("This is already on the bottom.");
                return;
            }

            int selectedRow = top10ROTYGrid.SelectedRows[0].Index;

            player topPlayer = top10ROTYGrid.Rows[selectedRow].Cells[3].Value as player;
            player bottomPlayer = top10ROTYGrid.Rows[selectedRow + 1].Cells[3].Value as player;

            int firstIndex = (int)top10ROTYGrid.Rows[selectedRow].Cells[4].Value;
            int secondIndex = (int)top10ROTYGrid.Rows[selectedRow + 1].Cells[4].Value;

            rotyPlayers[firstIndex] = bottomPlayer;
            rotyPlayers[secondIndex] = topPlayer;

            UpdateGrid(top10ROTYGrid, rotyPlayers);

            top10ROTYGrid.Rows[0].Selected = false;
            top10ROTYGrid.Rows[selectedRow + 1].Selected = true;
        }

        private void rotyCandidateGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rotyCandidateStatsGrid.Rows.Clear();
            foreach (DataGridViewRow row in rotyCandidateGrid.SelectedRows)
            {
                if (row.Cells[2].Value != null)
                {
                    player p = row.Cells[2].Value as player;
                    double shootingPercentage = 0.0, opponentPercentage = 0.0;
                    if (p.getShotsTaken() != 0)
                    {

                        shootingPercentage = ((double)p.getShotsMade() / (double)p.getShotsTaken()) * 100;
                    }
                    double plus_minus = 0.0;
                    if (p.getGamesPlayed() != 0)
                    {
                        plus_minus = ((double)p.teamPoints / (double)p.getGamesPlayed());
                    }
                    
                    if (p.getShotsAttemptedAgainst() != 0)
                        opponentPercentage = ((double)p.getShotsMadeAgainst() / (double)p.getShotsAttemptedAgainst()) * 100;
                    rotyCandidateStatsGrid.Rows.Add(p.getPoints(), p.getAssists(), p.getRebounds(), String.Format("{0:0.00}", shootingPercentage), String.Format("{0:0.00}", opponentPercentage), String.Format("{0:0.00}", plus_minus));
                }
            }
        }

        private void top10ROTYGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rotyTop10StatsGrid.Rows.Clear();
            foreach (DataGridViewRow row in top10ROTYGrid.SelectedRows)
            {
                if (row.Cells[3].Value != null)
                {
                    player p = row.Cells[3].Value as player;
                    double shootingPercentage = 0.0, opponentPercentage = 0.0;
                    if (p.getShotsTaken() != 0)
                    {

                        shootingPercentage = ((double)p.getShotsMade() / (double)p.getShotsTaken()) * 100;
                    }
                    double plus_minus = 0.0;
                    if (p.getGamesPlayed() != 0)
                    {
                        plus_minus = ((double)p.teamPoints / (double)p.getGamesPlayed());
                    }
                    if (p.getShotsAttemptedAgainst() != 0)
                        opponentPercentage = ((double)p.getShotsMadeAgainst() / (double)p.getShotsAttemptedAgainst()) * 100;
                    rotyTop10StatsGrid.Rows.Add(p.getPoints(), p.getAssists(), p.getRebounds(), String.Format("{0:0.00}", shootingPercentage), String.Format("{0:0.00}", opponentPercentage), String.Format("{0:0.00}", plus_minus));
                }
            }
        }

        private void rotyCandidateGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                player p = senderGrid[2, e.RowIndex].Value as player;
                if (e.ColumnIndex == 0)
                {
                    if (!rotyPlayers.Contains(p))
                    {
                        rotyPlayers.Add(p);
                        UpdateGrid(top10ROTYGrid, rotyPlayers);
                    }
                }

            }
        }

        private void coachingCandidates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Coach p = senderGrid[2, e.RowIndex].Value as Coach;
                if (e.ColumnIndex == 0)
                {
                    if (!coaches.Contains(p))
                    {
                        coaches.Add(p);
                        UpdateGrid(top10CoachingGrid, coaches);
                    }
                }

            }
        }

        private void coachingSwapButton_Click(object sender, EventArgs e)
        {
            if (top10CoachingGrid.SelectedRows.Count != 2) return;
            DataGridViewRow rowOne = top10CoachingGrid.SelectedRows[0], rowTwo = top10CoachingGrid.SelectedRows[1];

            if (top10CoachingGrid.SelectedRows[0].Cells[2].Value == null || top10CoachingGrid.SelectedRows[1].Cells[2].Value == null) return;
            Coach first = rowOne.Cells[2].Value as Coach;
            Coach second = rowTwo.Cells[2].Value as Coach;
            int firstIndex = (int)rowOne.Cells[3].Value;
            int secondIndex = (int)rowTwo.Cells[3].Value;
            coaches[firstIndex] = second;
            coaches[secondIndex] = first;
            int rowOneIndex = rowOne.Index, rowTwoIndex = rowTwo.Index;
            UpdateGrid(top10CoachingGrid, coaches);
            top10CoachingGrid.Rows[0].Selected = false;
            top10CoachingGrid.Rows[rowOneIndex].Selected = true;
            top10CoachingGrid.Rows[rowTwoIndex].Selected = true;
        }

        private void coachingUpButton_Click(object sender, EventArgs e)
        {
            if (top10CoachingGrid.SelectedRows.Count != 1) return;
            DataGridViewRow rowOne = top10CoachingGrid.SelectedRows[0];
            if (top10CoachingGrid.SelectedRows[0].Cells[2].Value == null) return;
            Coach first = rowOne.Cells[2].Value as Coach;
            int firstIndex = (int)rowOne.Cells[3].Value;
            if (firstIndex + 1 >= coaches.Count) return;
            Coach second = coaches[firstIndex + 1];
            coaches[firstIndex + 1] = first;
            coaches[firstIndex] = second;
            int rowOneIndex = rowOne.Index;
            UpdateGrid(top10CoachingGrid, coaches);
            top10CoachingGrid.Rows[0].Selected = false;
            top10CoachingGrid.Rows[rowOneIndex - 1].Selected = true;
        }

        private void coachingDownButton_Click(object sender, EventArgs e)
        {
            if (top10CoachingGrid.SelectedRows.Count != 1) return;
            DataGridViewRow rowOne = top10CoachingGrid.SelectedRows[0];
            if (top10CoachingGrid.SelectedRows[0].Cells[2].Value == null) return;
            Coach first = rowOne.Cells[2].Value as Coach;
            int firstIndex = (int)rowOne.Cells[3].Value;
            if (firstIndex - 1 < 0) return;
            Coach second = coaches[firstIndex - 1];
            coaches[firstIndex - 1] = first;
            coaches[firstIndex] = second;
            int rowOneIndex = rowOne.Index;
            UpdateGrid(top10CoachingGrid, coaches);
            top10CoachingGrid.Rows[0].Selected = false;
            top10CoachingGrid.Rows[rowOneIndex + 1].Selected = true;
        }
        AwardVotes votes;
        private void button2_Click(object sender, EventArgs e)
        {
            List<int> topTenMVP = new List<int>();
            for(int i = 0; i < top10MVPGrid.Rows.Count; i++)
            {
                player player = top10MVPGrid.Rows[i].Cells[2].Value as player;
                topTenMVP.Add(player.GetPlayerID());
                if (i == 9) break;
            }

            List<int> topTenROTY = new List<int>();
            for (int i = 0; i < top10ROTYGrid.Rows.Count; i++)
            {
                player player = top10ROTYGrid.Rows[i].Cells[2].Value as player;
                topTenROTY.Add(player.GetPlayerID());
                if (i == 9) break;
            }

            List<int> topTenCoaches = new List<int>();
            for(int i = 0; i < top10CoachingGrid.Rows.Count; i++)
            {
                Coach coach = top10CoachingGrid.Rows[i].Cells[2].Value as Coach;
                topTenCoaches.Add(coach.currTeam.getTeamNum());
                if (i == 9) break;
            }


            votes = new AwardVotes(topTenMVP, topTenROTY, topTenCoaches);
            Close();
        }
        public AwardVotes GetVotes()
        {
            return votes;
        }
    }
    [Serializable]
    public class AwardVotes
    {
        public List<int> mvpVotes, rotyVotes;
        public List<int> coaches;
        public AwardVotes(List<int> mvpVotes, List<int> rotyVotes, List<int> coaches)
        {
            this.mvpVotes = mvpVotes;
            this.rotyVotes = rotyVotes;
            this.coaches = coaches;

        }
    }
}
