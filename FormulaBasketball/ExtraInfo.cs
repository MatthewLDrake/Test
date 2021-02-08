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
    public partial class ExtraInfo : Form
    {
        public ExtraInfo()
        {
            InitializeComponent();
        }

        public void SetPlayer(player p)
        {
            textBox1.Text = p.GetPositionAsString() + " " + p.getName() + " " + p.getTeam().ToString() + Environment.NewLine +"Age: " + p.age + " Peak Start: " + p.GetPeakStart() + " Peak End: " +  p.GetPeakEnd() + Environment.NewLine + "Development: " + p.development;
        }
        public void SetPlayer(NewPlayer p)
        {
            textBox1.Text = p.GetPositionAsString() + " " + p.ToString() + Environment.NewLine + "Age: " + p.GetAge() + " Peak Start: " + p.GetPeakStart() + " Peak End: " + p.GetPeakEnd() + Environment.NewLine + "Development: " + p.GetDevelopment();
        }
    }
}
