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
    public partial class RosterControl : UserControl
    {
        public RosterControl()
        {
            InitializeComponent();
        }
        public void SetControl(List<player> players, int pos, string team)
        {
            mainTeamGrid.Rows.Clear();
            foreach(player p in players)
            {
                if(p.getPosition() == pos)
                {
                    mainTeamGrid.Rows.Add(new object[] { p.getName(), p.getOverall(), p.getDevelopment(), p.GetMoneyPerYear() });
                }
            }
            label1.Text = team;
        }
    }
}
