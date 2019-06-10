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
        public OffseasonFreeAgentForm(FreeAgents free, createTeams create)
        {
            InitializeComponent();
            freeAgents = free;
            currentGrid = centersGrid;
            grids = new DataGridView[5];
            grids[0] = centersGrid;
            grids[1] = powerForwardGrid;
            grids[2] = smallForwardGrid;
            grids[3] = shootingGuardGrid;
            grids[4] = pointGuardGrid;

            this.create = create;

            UpdateFreeAgents();
        }
        public void UpdateFreeAgents()
        {
            for (int i = 0; i < 5; i++)
            {
                List<player> players = freeAgents.GetPlayersByPos(i + 1);
                for (int j = 0; j < players.Count; j++)
                {
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayerSigned sign = new PlayerSigned(((player)currentGrid.SelectedRows[0].Cells[6].Value), create);
        }
    }
}
