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
    public partial class bracket : UserControl
    {
        public bracket()
        {
            InitializeComponent();
            /*using (Graphics g = this.CreateGraphics())
            {
                g.DrawLine(new Pen(Brushes.Orange, 1), 40, 40, 40, 10);
            }*/
           
        }

        internal void setTeamNames(string v1, string v2)
        {
            firstName.Text = v1;
            firstName.Visible = true;
            secondName.Text = v2;
            secondName.Visible = true;
            Refresh();
        }

        internal void updateScores(int v1, int v2)
        {
            topScore.Text = "" + v1;
            
            bottomScore.Text = "" + v2;
           
            Refresh();
        }
        public String getWinner()
        {
            if (Convert.ToInt32(topScore.Text) == 4) return firstName.Text;
            else if (Convert.ToInt32(bottomScore.Text) == 4) return secondName.Text;
            else return "";
        }
    }
}
