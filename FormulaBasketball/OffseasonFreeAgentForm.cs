using System;
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
    public partial class OffseasonFreeAgentForm : Form
    {
        private FreeAgents freeAgents;
        private DataGridView currentGrid;
        private DataGridView[] grids;
        private createTeams create;
        private List<int> humans;
        private LeagueRoster leaugeRoster;
        private List<List<player>> playersSigned;
        public OffseasonFreeAgentForm(FreeAgents free, createTeams create, List<int> humans, bool firstTime)
        {
            InitializeComponent();

            playersSigned = new List<List<player>>();
            playersSigned.Add(new List<player>());
            playersSigned.Add(new List<player>());
            playersSigned.Add(new List<player>());
            playersSigned.Add(new List<player>());
            playersSigned.Add(new List<player>());

            this.humans = humans;
            this.create = create;

            System.Threading.Thread thread = new System.Threading.Thread(LaunchWindow);
            thread.Start();
            freeAgents = free;
            currentGrid = centersGrid;
            grids = new DataGridView[5];
            grids[0] = centersGrid;
            grids[1] = powerForwardsGrid;
            grids[2] = smallForwardsGrid;
            grids[3] = shootingGuardsGrid;
            grids[4] = pointGuardGrid;

            UpdateFreeAgents(firstTime);
        }

        public void LaunchWindow()
        {
            leaugeRoster = new LeagueRoster(humans, create, true);
            leaugeRoster.ShowDialog();
        }
        public void UpdateFreeAgents(bool firstTime)
        {
            for (int i = 0; i < 5; i++)
            {
                int count = 32;
                Random random = new Random();
                List<player> players = freeAgents.GetPlayersByPos(i + 1);
                for (int j = 0; j < players.Count; j++)
                {
                    if(firstTime)
                    {
                        players[j].SetAdditionalOffers(0);
                    }
                    if(firstTime && j == 0)
                    {
                        players[j].OverallRating(true);
                        double overallRebuild = players[j].getOverall();
                        players[j].OverallRating(false);
                        double overall = players[j].getOverall();
                        foreach (team t in create.getTeams())
                        {
                            if(t.DraftStrategy == DraftStrategy.REBUILD)
                            {
                                foreach(player p in t)
                                {
                                    if (p.getPosition() == j + 1)
                                    {
                                        p.OverallRating(true);
                                        double pOverall = p.getOverall();
                                        p.OverallRating(false);
                                        if (pOverall > overallRebuild)
                                        {
                                            count--;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (player p in t)
                                {
                                    if (p.getPosition() == j + 1)
                                    {                                        
                                        double pOverall = p.getOverall();
                                        if (pOverall > overallRebuild)
                                        {
                                            count--;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        players[j].SetAdditionalOffers(count);
                    }
                    else if(firstTime)
                    {
                        if(count != 0)
                        {
                            int num = random.Next(count + 1);
                            players[j].SetAdditionalOffers(num);

                            count -= random.Next(num + 1);
                        }
                    }

                    String strTeam = "";
                    players[j].SetFreeAgent();
                    if (players[j].getTeam() != null) strTeam = players[j].getTeam().ToString();
                    grids[i].Rows.Add(strTeam, players[j].getName(), players[j].age, String.Format("{0:0.00}", players[j].getOverall()), players[j].getDevelopment(), players[j].GetOffers(), players[j]);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentGrid = grids[tabControl1.SelectedIndex];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((player)currentGrid.SelectedRows[0].Cells[6].Value).SetAdditionalOffers((int)numericUpDown1.Value);
            currentGrid.SelectedRows[0].Cells[5].Value = ((player)currentGrid.SelectedRows[0].Cells[6].Value).GetOffers();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayerSigned sign = new PlayerSigned(((player)currentGrid.SelectedRows[0].Cells[6].Value), create);
            sign.ShowDialog();

            playersSigned[((player)currentGrid.SelectedRows[0].Cells[6].Value).getPosition() - 1].Add((player)currentGrid.SelectedRows[0].Cells[6].Value);
            

            currentGrid.SelectedRows[0].Cells[0].Value = ((player)currentGrid.SelectedRows[0].Cells[6].Value).getTeam().ToString();
        }

        private void OffseasonFreeAgentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (playersSigned[0].Count > 0)
            {
                String eventString = "";
                for(int i = 0; i < playersSigned[0].Count; i++)
                {
                    eventString += playersSigned[0][i].getName() + " was signed by the " + playersSigned[0][i].getTeam() + " on a " + playersSigned[0][i].GetYearsLeft() + " years at " + playersSigned[0][i].GetMoneyPerYear() + " million per year." + Environment.NewLine;
                }
                create.AddEvent(new Event("Centers Signed This Week!", eventString, -1));
            }
            if (playersSigned[1].Count > 0)
            {
                String eventString = "";
                for (int i = 0; i < playersSigned[1].Count; i++)
                {
                    eventString += playersSigned[1][i].getName() + " was signed by the " + playersSigned[1][i].getTeam() + " on a " + playersSigned[1][i].GetYearsLeft() + " years at " + playersSigned[1][i].GetMoneyPerYear() + " million per year." + Environment.NewLine;
                }
                create.AddEvent(new Event("Power Forwards Signed This Week!", eventString, -1));
            }
            if (playersSigned[2].Count > 0)
            {
                String eventString = "";
                for (int i = 0; i < playersSigned[2].Count; i++)
                {
                    eventString += playersSigned[2][i].getName() + " was signed by the " + playersSigned[2][i].getTeam() + " on a " + playersSigned[2][i].GetYearsLeft() + " years at " + playersSigned[2][i].GetMoneyPerYear() + " million per year." + Environment.NewLine;
                }
                create.AddEvent(new Event("Small Forwards Signed This Week!", eventString, -1));
            }
            if (playersSigned[3].Count > 0)
            {
                String eventString = "";
                for (int i = 0; i < playersSigned[3].Count; i++)
                {
                    eventString += playersSigned[3][i].getName() + " was signed by the " + playersSigned[3][i].getTeam() + " on a " + playersSigned[3][i].GetYearsLeft() + " years at " + playersSigned[3][i].GetMoneyPerYear() + " million per year." + Environment.NewLine;
                }
                create.AddEvent(new Event("Shooting Guards Signed This Week!", eventString, -1));

            }
            if (playersSigned[4].Count > 0)
            {
                String eventString = "";
                for (int i = 0; i < playersSigned[4].Count; i++)
                {
                    eventString += playersSigned[4][i].getName() + " was signed by the " + playersSigned[4][i].getTeam() + " on a " + playersSigned[4][i].GetYearsLeft() + " years at " + playersSigned[4][i].GetMoneyPerYear() + " million per year." + Environment.NewLine;
                }
                create.AddEvent(new Event("Point Guards Signed This Week!", eventString, -1));
            }
        }
    }
}
