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
    public partial class teamPicker : Form
    {
        public List<team> teams;
        private team teamOne;
        private team teamTwo;
        public teamPicker(List<team> teams, bool flag = true)
        {
            this.teams = teams;
            InitializeComponent();
            comboBox2.Visible = flag;
            foreach (team team in teams)
            {
                comboBox1.Items.Add(team.ToString());
                comboBox2.Items.Add(team.ToString());
            }
        }
        public team getFirstTeam()
        {
            return teamOne;
        }
        public team getSecondTeam()
        {
            return teamTwo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1) teamOne = teams[comboBox1.SelectedIndex];
            if(comboBox2.SelectedIndex != -1) teamTwo = teams[comboBox2.SelectedIndex];


            this.Close();
        }
    }
}
