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
    public partial class OfferedTrade : Form
    {
        private Trade trade;
        public OfferedTrade(Trade trade)
        {
            InitializeComponent();
            this.trade = trade;
        }
    }
}
