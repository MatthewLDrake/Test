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
    public partial class FixScreen : Form
    {
        private createTeams create;
        private Random r;
        public FixScreen(createTeams create, Random r)
        {
            InitializeComponent();
            this.create = create;
            this.r = r;
            create.getFreeAgents().GeneratePlayers(r);
            UpdateGrid();


        }
        private void UpdateGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (team team in create.getTeams())
            {
                foreach (player p in team)
                {
                    if (team.ToString().Equals("Solea Geysers"))
                    {
                        p.FixPlayer();
                    }
                    dataGridView1.Rows.Add(new object[] { p.getName(), p.age, String.Format("{0:0.00}", p.getOverall()), "Delete", team.ToString(), p });
                }
                foreach (player p in team.GetAffiliate())
                {
                    dataGridView1.Rows.Add(new object[] { p.getName(), p.age, String.Format("{0:0.00}", p.getOverall()), "Delete", team.GetAffiliate().ToString(), p });
                    if(create.getFreeAgents().HasPlayer(p.getName(), p.getOverall()))
                    {
                        create.getFreeAgents().Remove(p.getName(), p.getOverall());
                    }
                }
            }
            foreach (player p in create.getFreeAgents().GetAllPlayers())
            {
                dataGridView1.Rows.Add(new object[] { p.getName(), p.age, String.Format("{0:0.00}", p.getOverall()), "Delete", "Free Agents", p });
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                create.getFreeAgents().Remove(dataGridView1.Rows[e.RowIndex].Cells[5].Value as player);
                UpdateGrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            formulaBasketball.SerializeObject(create, "testFile.fbsave");
            new Menu(create, r).ShowDialog();
            this.Close();
        }

    }
}
