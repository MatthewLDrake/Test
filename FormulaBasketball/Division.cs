using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class Division : UserControl
    {
        List<team> teams;
        public Division()
        {
            InitializeComponent();
            teams = null;
        }
        public void setTeams(List<team> teams)
        {
            this.teams = teams;
            dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
            teams.Sort();
            for(int i = 0; i < teams.Count; i++)
            {
                dataGridView1.Rows.Add((i + 1), teams[i].getThreeLetters().ToUpper(), teams[i].getWins(), teams[i].getLosses(), teams[i].getPoints(), teams[i].getPointsAgainst(), teams[i].getStreak());
               
            }
            dataGridView1.Refresh();
            label1.Refresh();
        }
        public void setLabel(string str)
        {
            label1.Text = str;
        }
        public List<team> getTeams()
        {
            return teams;
        }
        public string getLabel()
        {
            return label1.Text;
        }
    }
}
