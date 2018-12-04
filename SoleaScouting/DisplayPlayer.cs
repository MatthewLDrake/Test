using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoleaScouting
{
    public partial class DisplayPlayer : Form
    {
        public DisplayPlayer(Player p)
        {
            InitializeComponent();
            double[] stats = p.GetStats();
            list.Rows.Add(p.ToString(),p.GetAge(), stats[0], stats[1], stats[2], stats[3], stats[4], p.GetCountry(), p.GetUniversity());
        }
    }
}
