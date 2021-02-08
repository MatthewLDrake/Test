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
    public partial class NewContract : Form
    {
        private Contract contract;
        public NewContract()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contract = new Contract((int)yearsNumber.Value, (double)amountNumber.Value, 0, (double)bonusAmount.Value);
            Close();
        }
        public Contract GetContract()
        {
            return contract;
        }
    }
}
