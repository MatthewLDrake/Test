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
    public partial class CutPlayers : Form
    {
        private List<player> players;
        private List<List<player>> playersAtPosition;
        private team team;
        private createTeams create;
        public CutPlayers(team team, createTeams create)
        {
            InitializeComponent();
            players = team.GetOffSeasonPlayers();
            playersAtPosition = new List<List<player>>();
            for (int i = 0; i < 5; i++)
            {
                playersAtPosition.Add(new List<player>());
            }
            foreach (player p in players)
            {
                if (p != null)
                    playersAtPosition[p.getPosition() - 1].Add(p);
            }
            comboBox1.SelectedIndex = 0;
            this.team = team;
            this.create = create;
        }
        private void UpdateGrid(int pos)
        {
            depthChartGrid.Rows.Clear();
            if (playersAtPosition[pos].Count != 0)
            {
                foreach (player p in playersAtPosition[pos])
                    depthChartGrid.Rows.Add(p.getName(), String.Format("{0:0.00}", p.getOverall()), p.getDevelopment(), p.age, "Ratings", "Stats", p);
            }
            else
            {
                depthChartGrid.Rows.Add("None");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid(comboBox1.SelectedIndex);
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            player p =  depthChartGrid.SelectedRows[0].Cells[6].Value as player;
            team.removePlayer(p);
            team.AddCutPlayer(p);
            create.getFreeAgents().Add(p);
        }
    }
}
