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
        private player[] players;
        private team team;
        public DepthChart(team team)
        {
            InitializeComponent();
            players = team.getActivePlayers();
            comboBox1.SelectedIndex = 0;
            this.team = team;
        }
        private void UpdateGrid(int pos)
        {
            depthChartGrid.Rows.Clear();
            if(players[pos] != null)
            {
                depthChartGrid.Rows.Add(players[pos].getName(), String.Format("{0:0.00}", players[pos].getOverall()), players[pos].getDevelopment(), players[pos].age, "Ratings", "Stats");
                pos += 5;
                if (players[pos] != null)
                {
                    depthChartGrid.Rows.Add(players[pos].getName(), String.Format("{0:0.00}", players[pos].getOverall()), players[pos].getDevelopment(), players[pos].age, "Ratings", "Stats");
                    pos += 5;
                    if (players[pos] != null)
                    {
                        depthChartGrid.Rows.Add(players[pos].getName(), String.Format("{0:0.00}", players[pos].getOverall()), players[pos].getDevelopment(), players[pos].age, "Ratings", "Stats");

                    }
                }
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
            int row = depthChartGrid.SelectedRows[0].Index;
            if (row == 0) return;
            int pos = comboBox1.SelectedIndex;
            player temp = players[pos + (row * 5)];
            players[pos + (row * 5)] = players[pos + ((row - 1) * 5)];
            players[pos + ((row - 1) * 5)] = temp;
            UpdateGrid(comboBox1.SelectedIndex);
            depthChartGrid.Rows[0].Selected = false;
            depthChartGrid.Rows[(row - 1)].Selected = true;
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            int row = depthChartGrid.SelectedRows[0].Index;
            if (row == 2) return;
            int pos = comboBox1.SelectedIndex;
            player temp = players[pos + ((row + 1) * 5)];
            if (temp == null) return;            
            players[pos + ((row + 1) * 5)] =  players[pos + (row * 5)];
            players[pos + (row * 5)] = temp;
            UpdateGrid(comboBox1.SelectedIndex);
            depthChartGrid.Rows[0].Selected = false;
            depthChartGrid.Rows[(row + 1)].Selected = true;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            team.SetDepthChart(players);
            Close();
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            int firstRow = depthChartGrid.SelectedRows[0].Index;
            int secondRow = depthChartGrid.SelectedRows[1].Index;
            int pos = comboBox1.SelectedIndex;
            player temp = players[pos + (firstRow * 5)];
            players[pos + (firstRow * 5)] = players[pos + (secondRow * 5)];
            players[pos + (secondRow * 5)] = temp;
            UpdateGrid(comboBox1.SelectedIndex);
            depthChartGrid.Rows[0].Selected = false;
            depthChartGrid.Rows[(firstRow)].Selected = true;
            depthChartGrid.Rows[(secondRow)].Selected = true;
        }
    }
}
