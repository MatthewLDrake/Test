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
    public partial class ViewRoster : Form
    {
        private List<player> team;
        public ViewRoster(List<player> team)
        {
            InitializeComponent();
            this.team = team;
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            foreach(player p in team)
            {
                p.setDefensiveModifier(0);
                p.setOtherModifier(0);
                p.setShootingModifier(0);
                p.setStamina(100);
                rosterGrid.Rows.Add(p.getName(), p.getPosition(),p.age, String.Format("{0:0.00}", p.getOverall()),p.getDevelopment(), "Show Ratings", "Show Stats",  p.GetMoneyPerYear(), p);
            }
        }
        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                player p = senderGrid[8, e.RowIndex].Value as player;
                if (e.ColumnIndex == 4)
                {
                    //Console.WriteLine("Ratings hit");
                    new PlayerRatings(p).ShowDialog();
                }
                else if (e.ColumnIndex == 5)
                {
                    //Console.WriteLine("Stats hit");
                    new PlayerStats(p).ShowDialog();
                }
                
            }
        }
    }
}
