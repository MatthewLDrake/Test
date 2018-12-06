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
    public partial class Negotiation : Form
    {
        private bool success;
        private Contract teamOfferedContract, playerOfferedContract;
        private player player;
        private FormulaBasketball.Random r;
        private List<Promises> promises;
        public Negotiation(player p, Contract contract, FormulaBasketball.Random r)
        {
            InitializeComponent();
            success = false;
            this.r = r;
            player = p;
            teamOfferedContract = contract;
            promises = contract.GetPromises();
            grid.Rows.Add("Team", contract.GetYearsLeft(), contract.GetMoney(), contract.GetTotalMoney(), contract.GetBonus(), "Promises", contract);
            PlayerCounter(false);
        }
        private void PlayerCounter(bool b = true)
        {
            playerOfferedContract = player.GetCounterOffer(teamOfferedContract, r, playerOfferedContract);
            if(b && playerOfferedContract.GetMoney() <= teamOfferedContract.GetMoney())
            {
                MessageBox.Show("Player accepted your offer");

                success = true;
                Close();
                return;
            }

            grid.Rows.Add(player.getName(), playerOfferedContract.GetYearsLeft(), playerOfferedContract.GetMoney(), playerOfferedContract.GetTotalMoney(), playerOfferedContract.GetBonus(), "Promises", playerOfferedContract);
        }
        public bool Success()
        {
            return success;
        }
        public Contract GetContract()
        {
            return teamOfferedContract;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            success = false;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            teamOfferedContract = playerOfferedContract;
            success = true;
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            success = false;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Contract currentContract = new Contract(Convert.ToInt32(yearsNumber.Value), Convert.ToDouble(amountNumber.Value));
            if (currentContract.GetYearsLeft() == playerOfferedContract.GetYearsLeft() && currentContract.GetMoney() >= playerOfferedContract.GetMoney())
            {                
                MessageBox.Show("Player accepted your offer");
                DialogResult d = MessageBox.Show("Are you sure you want to offer more money than the player requested?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (d == DialogResult.No)
                {
                    teamOfferedContract = playerOfferedContract;
                }
                
                success = true;
                Close();
            }
            
            ContractResult result = player.ContractNegotiate(currentContract, r);
            if (result.Equals(ContractResult.Accept))
            {
                MessageBox.Show("Player accepted your offer");
                teamOfferedContract = currentContract;
                success = true;
                Close();

            }
            else if (result.Equals(ContractResult.Reject))
            {
                MessageBox.Show("Player rejected your offer");
                success = false;
                Close();
            }
            else
            {
                grid.Rows.Add("Team", currentContract.GetYearsLeft(), currentContract.GetMoney(), currentContract.GetTotalMoney());
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                PlayerCounter();
            }
            
        }

        private void promisesButton_Click(object sender, EventArgs e)
        {
            OfferPromises offer = new OfferPromises(promises);
            offer.ShowDialog();
            promises = offer.GetPromises();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Contract contract = senderGrid[6, e.RowIndex].Value as Contract;
                if (e.ColumnIndex == 5)
                {
                    new OfferPromises(contract.GetPromises(), true).ShowDialog();
                }
               
            }
        }
    }
}
