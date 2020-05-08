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
    public partial class AddPlayer : Form
    {
        private player player;
        public AddPlayer(int positionNumber, createTeams create)
        {
            InitializeComponent();
            foreach(player p in create.getFreeAgents().GetPlayersByPos(positionNumber))
            {
                dataGridView1.Rows.Add(new object[] { p.getName(), p.age, p.getDevelopment(), p.getOverall(), "Add player",  p });
            }
        }
        public player GetPlayer()
        {
            return player;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                player = dataGridView1.Rows[e.RowIndex].Cells[5].Value as player;
                Close();
            }
        }
    }
}
