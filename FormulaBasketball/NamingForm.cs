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
    public partial class NamingForm : Form
    {
        private bool dLeague;
        private createTeams create;
        private int viewingNumber;
        public NamingForm(createTeams create)
        {
            InitializeComponent();
            this.create = create;
            UpdateList();
            teamList.SelectedIndex = 0;

            
        }
        private void UpdateList()
        {
            teamList.Items.Clear();
            foreach (team team in create.getTeams())
            {
                team t = team;
                if (dLeague)
                    t = team.GetAffiliate();
                teamList.Items.Add(t.ToString());
            }
            teamList.Items.Add("Free Agents");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dLeague = checkBox1.Checked;
            UpdateGrid();
        }
        private void AddPlayerToGrid(player p)
        {
            playerGrid.Rows.Add(p.getName(), p.getPosition(), p.getOverall(), p);
        }
        private void UpdateGrid()
        {
            playerGrid.Rows.Clear();
            bool firstPlayer = true;
            if (viewingNumber < 32)
            {
                team t;
                if (dLeague)
                    t = create.getTeam(viewingNumber).GetAffiliate();
                else
                    t = create.getTeam(viewingNumber);

                foreach (player p in t)
                {
                    AddPlayerToGrid(p);
                    if(firstPlayer)
                    {
                        textBox1.Text = p.getName();
                        firstPlayer = false;
                    }
                }

            }
            else
            {
                foreach (player p in create.getFreeAgents().GetAllPlayers())
                {
                    AddPlayerToGrid(p);
                    if (firstPlayer)
                    {
                        textBox1.Text = p.getName();
                        firstPlayer = false;
                    }
                }
            }

        }
        private void teamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewingNumber = teamList.SelectedIndex;
            UpdateGrid();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (viewingNumber < teamList.Items.Count - 1)
            {
                teamList.SelectedIndex++;
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (viewingNumber > 0)
            {
                teamList.SelectedIndex--;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (playerGrid.SelectedRows[0].Cells[3].Value as player).setName(textBox1.Text);
            UpdateGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NameGenerator gen = NameGenerator.Instance();
            textBox1.Text = gen.GenerateName((playerGrid.SelectedRows[0].Cells[3].Value as player).GetCountry());
        }

        private void playerGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if((sender as DataGridView).SelectedRows.Count > 0)
                textBox1.Text = playerGrid.SelectedRows[0].Cells[0].Value as string;
        }
    }
}
