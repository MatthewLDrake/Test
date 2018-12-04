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


namespace Free_Agency
{
    public partial class FreeAgencyForm : Form
    {
        private FreeAgents freeAgents;
        private List<player>[] players;
        private team userTeam;
        public FreeAgencyForm(FreeAgents free, team team, createTeams create)
        {
            InitializeComponent();
            
            freeAgents = free;
            userTeam = team;

            for (int i = 0; i < create.size(); i++)
                freeAgents.Add(create.getDLeagueTeam(i).getAllPlayer());

            rosterSize.Text = "Players on team " + userTeam.Count().ToString() + "/15\nPlayers on affiliate " + userTeam.GetAffiliate().Count().ToString() +  "/15";
            MoneyLabel.Text = "Penalty Free Cap Space " + String.Format("{0:0.00}", (100 - userTeam.GetPayroll())) + "M\nAvailable Bonus Money " + String.Format("{0:0.00}", (userTeam.getFianances()/1000000.0)) + "M";
            DataGridView[] grids = new DataGridView[5];
            grids[0] = centersGrid;
            grids[1] = powerForwardGrid;
            grids[2] = smallForwardGrid;
            grids[3] = shootingGuardGrid;
            grids[4] = pointGuardGrid;

            players = new List<player>[5];

            for(int i = 0; i < players.Length; i++)
            {
                players[i] = freeAgents.GetPlayersByPos(i + 1);
                for (int j = 0; j < players[i].Count; j++)
                {
                    String strTeam = "";
                    if (players[i][j].getTeam() != null) strTeam = players[i][j].getTeam().ToString();
                    grids[i].Rows.Add(strTeam, players[i][j].getName(), players[i][j].age, String.Format("{0:0.00}", players[i][j].getOverall()), players[i][j].getDevelopment(), "Show Ratings", "Show Stats", players[i][j].GetOffers(), "Negotiate", players[i][j]);
                }
            }

            

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
                    //Console.WriteLine("Negotiate hit");
                    DialogResult result;
                    if (p.HasOfferFromTeam(userTeam))
                        result = new PlayerNegotiate(p, userTeam, p.GetOfferFromTeam(userTeam)).ShowDialog();
                    else
                        result = new PlayerNegotiate(p, userTeam).ShowDialog();
                    
                    senderGrid[6, e.RowIndex].Value = p.GetOffers();
                    
                }
            }
        }
        

    }
}
