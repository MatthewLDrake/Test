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
    public partial class DepthChart : Form
    {
        private List<player> players;
        private List<List<player>> playersAtPosition;
        private team team;
        public DepthChart(team team)
        {
            InitializeComponent();
            players = team.GetOffSeasonPlayers();
            playersAtPosition = new List<List<player>>();
            for(int i = 0; i < 5; i++)
            {
                playersAtPosition.Add(new List<player>());
            }
            foreach(player p in players)
            {
                if(p != null)
                    playersAtPosition[p.getPosition()- 1].Add(p);
            }
            comboBox1.SelectedIndex = 0;
            this.team = team;
        }
        private void UpdateGrid(int pos)
        {
            depthChartGrid.Rows.Clear();
            if(playersAtPosition[pos].Count != 0)
            { 
                foreach(player p in playersAtPosition[pos])
                    depthChartGrid.Rows.Add(p.getName(), String.Format("{0:0.00}", p.getOverall()), p.getDevelopment(), p.age, "Ratings", "Stats");
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

        private void upButton_Click(object sender, EventArgs e)
        {
            if (depthChartGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show("You must have only one row selected to swap!");
                return;
            }
            int row = depthChartGrid.SelectedRows[0].Index;
            if (row == 0) return;
            int pos = comboBox1.SelectedIndex;
            player temp = playersAtPosition[comboBox1.SelectedIndex][row];
            playersAtPosition[comboBox1.SelectedIndex][row] = playersAtPosition[comboBox1.SelectedIndex][row - 1];
            playersAtPosition[comboBox1.SelectedIndex][row - 1] = temp;
            UpdateGrid(comboBox1.SelectedIndex);
            depthChartGrid.Rows[0].Selected = false;
            depthChartGrid.Rows[(row - 1)].Selected = true;
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (depthChartGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show("You must have only one row selected to swap!");
                return;
            }
            int row = depthChartGrid.SelectedRows[0].Index;
            if (row == depthChartGrid.Rows.Count - 1) return;
            int pos = comboBox1.SelectedIndex;
            player temp = playersAtPosition[comboBox1.SelectedIndex][row + 1];
            playersAtPosition[comboBox1.SelectedIndex][row + 1] = playersAtPosition[comboBox1.SelectedIndex][row];
            playersAtPosition[comboBox1.SelectedIndex][row] = temp;
            players[pos + ((row + 1) * 5)] =  players[pos + (row * 5)];
            players[pos + (row * 5)] = temp;
            UpdateGrid(comboBox1.SelectedIndex);
            depthChartGrid.Rows[0].Selected = false;
            depthChartGrid.Rows[(row + 1)].Selected = true;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            team.SetDepthChart(playersAtPosition);
            Close();
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            if (depthChartGrid.SelectedRows.Count != 2)
            {
                MessageBox.Show("You must have two rows selected to swap!");
                return;
            }
            int firstRow = depthChartGrid.SelectedRows[0].Index;
            int secondRow = depthChartGrid.SelectedRows[1].Index;
            int pos = comboBox1.SelectedIndex;
            player temp = playersAtPosition[comboBox1.SelectedIndex][firstRow];
            playersAtPosition[comboBox1.SelectedIndex][firstRow] = playersAtPosition[comboBox1.SelectedIndex][secondRow];
            playersAtPosition[comboBox1.SelectedIndex][secondRow] = temp;
            UpdateGrid(comboBox1.SelectedIndex);
            depthChartGrid.Rows[0].Selected = false;
            depthChartGrid.Rows[(firstRow)].Selected = true;
            depthChartGrid.Rows[(secondRow)].Selected = true;
        }
    }
}
