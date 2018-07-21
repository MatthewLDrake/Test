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
    public partial class newTeam : Form
    {
        private team team;
        private FormulaBasketball.Random r;
        public newTeam(FormulaBasketball.Random r)
        {
            this.r = r;
            InitializeComponent();
        }

        public newTeam(team team)
        {
            this.team = team;
            InitializeComponent();
            name.Text = team.ToString();
            threeLetters.Text = team.getThreeLetters();
            char letter = team.getDivisionLetter();
            if(letter == 'A')
            {
                divisionA.Checked = true;
                divisionB.Checked = false;
                divisionC.Checked = false;
                divisionD.Checked = false;
            }
            else if (letter == 'B')
            {
                divisionA.Checked = false;
                divisionB.Checked = true;
                divisionC.Checked = false;
                divisionD.Checked = false;
            }
            else if (letter == 'C')
            {
                divisionA.Checked = false;
                divisionB.Checked = false;
                divisionC.Checked = true;
                divisionD.Checked = false;
            }
            else if (letter == 'D')
            {
                divisionA.Checked = false;
                divisionB.Checked = false;
                divisionC.Checked = false;
                divisionD.Checked = true;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if(name.Text.Equals(""))
            {
                MessageBox.Show("Please enter a team name!");
                return;
            }
            if(threeLetters.Text.Length != 3)
            {
                MessageBox.Show("Please make the three letter abbreviation three letters");
                return;
            }
            if (team == null)
                team = new team(name.Text, threeLetters.Text, r);
            else
            {
                team.setTeamName(name.Text);
                team.setLastThreeLetters(threeLetters.Text);
            }
            if (divisionA.Checked) team.setDivison(1);
            else if (divisionB.Checked) team.setDivison(2);
            else if (divisionC.Checked) team.setDivison(3);
            else if (divisionD.Checked) team.setDivison(4);
            this.Close();
        }
        public team getNewTeam()
        {
            return team;
        }
    }
}
