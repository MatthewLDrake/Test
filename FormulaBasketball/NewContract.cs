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
        private List<Promises> promises;
        public NewContract()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contract = new Contract((int)yearsNumber.Value, (double)amountNumber.Value, 0, (double)bonusAmount.Value, promises, (double)maxDiff.Value);
            Close();
        }
        public Contract GetContract()
        {
            return contract;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PromisesForm promises = new PromisesForm();
            promises.ShowDialog();
            this.promises = promises.GetPromises();
        }
    }
}
