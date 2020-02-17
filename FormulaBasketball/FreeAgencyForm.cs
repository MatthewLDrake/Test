using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormulaBasketball
{
    public partial class FreeAgencyForm : Form
    {
        private FreeAgents freeAgents;
        private List<player>[] players;
        private team userTeam;
        private bool postOffseason;
        private createTeams create;
        public FreeAgencyForm(FreeAgents free, team team, createTeams create)
        {
            InitializeComponent();

            postOffseason = false;
            freeAgents = free;
            this.create = create;
            userTeam = team;

            for (int i = 0; i < create.size(); i++)
            {
                freeAgents.Add(create.getDLeagueTeam(i).getAllPlayer());
            }
            for (int i = 1; i < 6; i++ )
                foreach (player p in freeAgents.GetPlayersByPos(i))
                {
                    if (p.GetStatus() == 2)
                        continue;
                    if (p.getTeam() != null) p.SetStatus(1);
                    else p.SetStatus(0);

                    p.SetFreeAgent();
                }            

        }
        public FreeAgencyForm(createTeams create, team team)
        {
            InitializeComponent();

            freeAgents = create.getFreeAgents();
            userTeam = team;
            postOffseason = true;
            this.create = create;

            for (int i = 0; i < create.size(); i++)
            {
                freeAgents.Add(create.getDLeagueTeam(i).getAllPlayer());
            }
            for (int i = 1; i < 6; i++)
                foreach (player p in freeAgents.GetPlayersByPos(i))
                {
                    if (p.GetStatus() == 2)
                        continue;
                    if (p.getTeam() != null) p.SetStatus(1);
                    else p.SetStatus(0);

                    p.SetFreeAgent();
                }
            UpdateFreeAgents(create);
        }
        private void centerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;


            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                player p = senderGrid[9, e.RowIndex].Value as player;
                if(e.ColumnIndex == 5)
                {
                    //Console.WriteLine("Ratings hit");
                    new PlayerRatings(p).ShowDialog();
                }
                else if(e.ColumnIndex == 6)
                {
                    //Console.WriteLine("Stats hit");
                    new PlayerStats(p).ShowDialog();
                }
                else if(e.ColumnIndex == 8)
                {
                    if (postOffseason)
                    {
                        TeamSelector team = new TeamSelector();
                        team.ShowDialog();
                        create.getTeam(team.teamNum).OffSeasonAddPlayer(p);
                        p.SetNewContract(new Contract(1, 1));
                    }
                    else
                    {
                        if (p.HasOfferFromTeam(userTeam))
                            new PlayerNegotiate(p, userTeam, p.GetOfferFromTeam(userTeam)).ShowDialog();
                        else
                            new PlayerNegotiate(p, userTeam).ShowDialog();


                        if (p.HasOfferFromTeam(userTeam))
                        {
                            userTeam.AddOffer(p, p.GetOfferFromTeam(userTeam));
                        }
                        else
                        {
                            userTeam.RemoveOffer(p);
                        }
                        senderGrid.Rows[e.RowIndex].Cells[7].Value = p.GetOffers();
                    }
                }
            }
            
        }
        public void UpdateFreeAgents(createTeams create)
        {
            rosterSize.Text = "Players on team " + userTeam.GetOffSeasonPlayers(false).Count.ToString() + "/15\nPlayers on affiliate " + userTeam.GetAffiliate().Count().ToString() + "/15";
            MoneyLabel.Text = "Penalty Free Cap Space " + String.Format("{0:0.00}", (100 - userTeam.GetPayroll(true))) + "M\nAvailable Bonus Money " + String.Format("{0:0.00}", (userTeam.getFianances() / 1000000.0)) + "M";
            DataGridView[] grids = new DataGridView[5];
            grids[0] = centersGrid;
            grids[1] = powerForwardGrid;
            grids[2] = smallForwardGrid;
            grids[3] = shootingGuardGrid;
            grids[4] = pointGuardGrid;

            players = new List<player>[5];

            for (int i = 0; i < players.Length; i++)
            {
                grids[i].Rows.Clear();
                players[i] = freeAgents.GetPlayersByPos(i + 1);
                for (int j = 0; j < players[i].Count; j++)
                {
                    switch(players[i][j].GetStatus())
                    {
                        case 1:
                            if (!checkBox1.Checked)
                                continue;
                            break;
                        case 2:
                            if (!checkBox2.Checked)
                                continue;
                            break;
                        default:
                            break;
                    }


                    String strTeam = "";
                    if (players[i][j].getTeam() != null) strTeam = players[i][j].getTeam().ToString();
                    grids[i].Rows.Add(strTeam, players[i][j].getName(), players[i][j].age, String.Format("{0:0.00}", players[i][j].getOverall()), players[i][j].getDevelopment(), "Show Ratings", "Show Stats", players[i][j].GetOffers(), postOffseason ? "Sign" : "Negotiate", players[i][j]);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFreeAgents(postOffseason ? FormulaBasketball.PostOffSeason.current.create : FormulaBasketball.Menu.menu.create);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ViewRoster(userTeam.GetOffSeasonPlayers()).Show();
        }

    }    
}
