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
    public partial class EditTeam : Form
    {
        private player[] mainPlayers, dLeaguePlayers;
        private createTeams create;
        private team team;
        public EditTeam(team team, createTeams create)
        {
            InitializeComponent();

            this.create = create;
            this.team = team;

            mainPlayers = new player[15];
            dLeaguePlayers = new player[15];
            for (int i = 0; i < team.getActivePlayers().Length; i++)
            {
                mainPlayers[i] = team.getActivePlayers()[i];
            }
            for (int i = 0; i < team.GetAffiliate().getActivePlayers().Length; i++)
            {
                dLeaguePlayers[i] = team.GetAffiliate().getActivePlayers()[i];
            }
            UpdateGrids();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if(col == 4 )
            {
                player p = dataGridView1.Rows[e.RowIndex].Cells[6].Value as player;

                if (p != null)
                {
                    new EditRatings(p).ShowDialog();
                    UpdateGrids();
                }
            }
            else if(col == 5)
            {
                player p = dataGridView1.Rows[e.RowIndex].Cells[6].Value as player;
                if(p != null)
                {
                    p.setTeam(null);
                    mainPlayers[e.RowIndex] = null;
                    create.getFreeAgents().Add(p);
                    team.removePlayer(p);
                    UpdateGrids();
                }
                else
                {
                    AddPlayer addPlayer = new AddPlayer(e.RowIndex % 5 + 1, create);
                    addPlayer.ShowDialog();
                    p = addPlayer.GetPlayer();
                    dLeaguePlayers[e.RowIndex] = p;
                    team.AddPlayerAtSpot(p, e.RowIndex);
                    p.setTeam(team);
                    create.getFreeAgents().Remove(p);
                    UpdateGrids();
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (col == 4)
            {
                player p = dataGridView2.Rows[e.RowIndex].Cells[6].Value as player;

                if (p != null)
                {
                    new EditRatings(p).ShowDialog();
                    UpdateGrids();
                }
            }
            else if (col == 5)
            {
                player p = dataGridView2.Rows[e.RowIndex].Cells[6].Value as player;
                if (p != null)
                {
                    p.setTeam(null);
                    dLeaguePlayers[e.RowIndex] = null;
                    create.getFreeAgents().Add(p);
                    team.GetAffiliate().removePlayer(p);
                    UpdateGrids();
                }
                else                
                {
                    AddPlayer addPlayer = new AddPlayer(e.RowIndex % 5 + 1, create); 
                    addPlayer.ShowDialog();
                    p = addPlayer.GetPlayer();
                    dLeaguePlayers[e.RowIndex] = p;
                    team.GetAffiliate().AddPlayerAtSpot(p, e.RowIndex);
                    p.setTeam(team.GetAffiliate());
                    create.getFreeAgents().Remove(p);
                    UpdateGrids();
                }
            }
        }

        private void UpdateGrids()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            foreach (player p in mainPlayers)
            {
                if (p != null)
                {
                    dataGridView1.Rows.Add(new object[] { p.getName(), p.age, p.getDevelopment(), p.getOverall(), "Edit Ratings", "Cut Player", p });
                }
                else
                {
                    dataGridView1.Rows.Add(new object[] { "Empty", 0, "F", 0, "", "Add Player", null });
                }
            }

            foreach(player p in dLeaguePlayers)
            {
                if (p != null)
                {
                    dataGridView2.Rows.Add(new object[] { p.getName(), p.age, p.getDevelopment(), p.getOverall(), "Edit Ratings", "Cut Player", p });
                }
                else
                {
                    dataGridView2.Rows.Add(new object[] { "Empty", 0, "F", 0, "", "Add Player", null });
                }
            }
        }
    }
}
