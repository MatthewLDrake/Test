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
    public partial class AddInjuryForm : Form
    {
        private NewTeam team;
        private League league;
        public AddInjuryForm(League league)
        {
            InitializeComponent();

            this.league = league;

            comboBox1.Visible = true;
            dataGridView2.Visible = false;
            panel1.Visible = false;

            for (int i = 0; i < 32; i++)
            {
                league.GetTeam(i).UpdateTeam();
                comboBox1.Items.Add(league.GetTeam(i));
            }


        }
        public AddInjuryForm(NewTeam team)
        {
            InitializeComponent();

            Startup(team);
        }
        private void Startup(NewTeam team)
        {
            this.team = team;

            foreach (NewPlayer activePlayers in team.GetPlayers())
            {
                dataGridView2.Rows.Add(new object[] { activePlayers.GetPositionAsString(), activePlayers.GetName(), activePlayers.GetBestOverall(), "Injure", activePlayers });
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                NewPlayer player = dataGridView2.Rows[e.RowIndex].Cells[4].Value as NewPlayer;

                int injuryLength;

                if(randomButton.Checked)
                {
                    int temp = League.r.Next(10);
                    if (temp < 2)
                        injuryLength = League.r.Next(2,4);
                    else if(temp < 5)
                        injuryLength = League.r.Next(6, 14);
                    else if(temp < 8)
                        injuryLength = League.r.Next(12, 35);
                    else
                        injuryLength = 84;
                }
                else if(minorInjury.Checked)
                {
                    injuryLength = League.r.Next(2, 4);
                }
                else if (moderateInjury.Checked)
                {
                    injuryLength = League.r.Next(6, 14);
                }
                else if (majorInjury.Checked)
                {
                    injuryLength = League.r.Next(12, 35);
                }
                else
                {
                    injuryLength = 84;
                }
                team.AddInjury(player, injuryLength);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            dataGridView2.Visible = true;
            panel1.Visible = true;


            Startup(league.GetTeam(comboBox1.SelectedIndex));

        }
    }
}
