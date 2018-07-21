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
    public partial class soloScreen : Form
    {
        public soloScreen(List<team> teams, String labelText)
        {
            InitializeComponent();

            division.setLabel(labelText);
            division.setTeams(teams);
        }
    }
}
