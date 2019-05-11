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
    public partial class DisplayPlayer : Form
    {
        public DisplayPlayer(player p)
        {
            InitializeComponent();
            double shootingPercentage = 0.0, oppontentShootingPercentage = 0.0;
             if (p.getShotsTaken() != 0)    
                    shootingPercentage = ((double)p.getShotsMade() / (double)p.getShotsTaken()) * 100;           
                if (p.getShotsAttemptedAgainst() != 0)
                    oppontentShootingPercentage = ((double)p.getShotsMadeAgainst() / (double)p.getShotsAttemptedAgainst()) * 100;
            double[] stats = new double[]{shootingPercentage, p.getPoints(), p.getAssists(), p.getRebounds(), oppontentShootingPercentage};
            list.Rows.Add(p.getName(),p.age, stats[0], stats[1], stats[2], stats[3], stats[4], p.GetCountry(), p.getTeam());
        }
    }
}
