using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Free_Agency
{
    public partial class PlayerNegotiate : Form
    {
        private player p;
        private team team;
        public PlayerNegotiate(player p, team userTeam)
        {
            InitializeComponent();
            team = userTeam;
            this.p = p;
        }
        public PlayerNegotiate(player p, team userTeam, Contract previousContract) : this(p, userTeam)
        {   
            yearsNumber.Value = previousContract.GetYearsLeft();
            amountNumber.Value = (decimal)previousContract.GetMoney();
            bonusAmount.Value = (decimal)previousContract.GetBonus();
            retractButton.Visible = true;
        }
        private void confirmButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            int years = (int)yearsNumber.Value;
            double amount = (double)amountNumber.Value;
            double bonus = (double)bonusAmount.Value;
            p.OfferFreeAgentContract(new Contract(years, amount, 0, bonus), team);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void retractButton_Click(object sender, EventArgs e)
        {
            p.RemoveFreeAgentOffer(team);
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
