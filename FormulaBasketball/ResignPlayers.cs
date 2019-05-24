using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class ResignPlayers : Form
    {
        private createTeams create;
        private team team;
        private FormulaBasketball.Random r;
        private List<Promises> promises;
        private int playersUnderContract;
        private double capSpace;
        private double bonusCash;
        private List<player> rejectedPlayers;
        private bool rejectedPlayer, cutPlayer, playerRejected;
        public ResignPlayers(createTeams create, team team, FormulaBasketball.Random r)
        {
            InitializeComponent();
            rejectedPlayers = new List<player>();
            this.r = r;
            this.team = team;
            this.create = create;
            promises = new List<Promises>();
            playersUnderContract = 0;
            capSpace = 100 - team.CapPenalty;
            bonusCash = (team.getFianances() / 1000000.0);
            foreach (player player in team)
            {
                if (player.ContractExpired())
                {
                    dataGridView1.Rows.Add(player.getName(), player.getPosition(), player.getOverall(), player.getDevelopment(), player.GetMoneyPerYear(), player.GetPlayerID());
                    rejectedPlayers.Add(player);
                }
                else
                {
                    playersUnderContract++;
                    capSpace -= player.GetMoneyPerYear();
                    dataGridView2.Rows.Add(player.getName(), player.getPosition(), player.getOverall(), player.getDevelopment(), player.GetMoneyPerYear(), player.GetPlayerID(), player.GetYearsLeft());
                }
            }
            rosterSize.Text = "Players on team " + playersUnderContract + "/15\nPlayers on affiliate " + team.GetAffiliate().Count().ToString() + "/15";
            MoneyLabel.Text = "Penalty Free Cap Space " + String.Format("{0:0.00}", capSpace) + "M\nAvailable Bonus Money " + String.Format("{0:0.00}", bonusCash) + "M";
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("No row was selected!");
                }
                else
                {
                    int playerID = (int)dataGridView1.CurrentRow.Cells[5].Value;
                    player p = team.GetPlayerByID(playerID);
                    Contract currentContract = new Contract(Convert.ToInt32(yearsNumber.Value), Convert.ToDouble(amountNumber.Value), 0, Convert.ToDouble(bonusAmount.Value), promises);
                    ContractResult result = p.ContractNegotiate(currentContract, r);
                    if (result.Equals(ContractResult.Accept))
                    {
                        MessageBox.Show("Player accepted your offer");
                        p.SetNewContract(currentContract);
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                        dataGridView2.Rows.Add(p.getName(), p.getPosition(), p.getOverall(), p.getDevelopment(), p.GetMoneyPerYear(), p.GetPlayerID(), p.GetYearsLeft());
                        dataGridView2.Rows[dataGridView2.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Gray;
                        playersUnderContract++;
                        capSpace -= p.GetMoneyPerYear();
                        bonusCash -= p.GetBonus();
                        rejectedPlayers.Remove(p);
                        rosterSize.Text = "Players on team " + playersUnderContract + "/15\nPlayers on affiliate " + team.GetAffiliate().Count().ToString() + "/15";
                        MoneyLabel.Text = "Penalty Free Cap Space " + String.Format("{0:0.00}", capSpace) + "M\nAvailable Bonus Money " + String.Format("{0:0.00}", bonusCash) + "M";
                    }
                    else if (result.Equals(ContractResult.Reject))
                    {
                        MessageBox.Show("Player rejected your offer");
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    }
                    else
                    {
                        Negotiation negotiation = new Negotiation(p, currentContract, r);
                        negotiation.ShowDialog();
                        if (negotiation.Success())
                        {
                            p.SetNewContract(negotiation.GetContract());
                            dataGridView2.Rows.Add(p.getName(), p.getPosition(), p.getOverall(), p.getDevelopment(), p.GetMoneyPerYear(), p.GetPlayerID(), p.GetYearsLeft());
                            dataGridView2.Rows[dataGridView2.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Gray;
                            playersUnderContract++;
                            capSpace -= p.GetMoneyPerYear();
                            bonusCash -= p.GetBonus();
                            rejectedPlayers.Remove(p);
                            rosterSize.Text = "Players on team " + playersUnderContract + "/15\nPlayers on affiliate " + team.GetAffiliate().Count().ToString() + "/15";
                            MoneyLabel.Text = "Penalty Free Cap Space " + String.Format("{0:0.00}", capSpace) + "M\nAvailable Bonus Money " + String.Format("{0:0.00}", bonusCash) + "M";
                        }
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    }
                }
            }
            else
            {
                if (dataGridView2.CurrentRow == null)
                {
                    MessageBox.Show("No row was selected!");
                }
                else
                {
                    int playerID = (int)dataGridView2.CurrentRow.Cells[5].Value;
                    player p = team.GetPlayerByID(playerID);
                    Contract currentContract = new Contract(Convert.ToInt32(yearsNumber.Value), Convert.ToDouble(amountNumber.Value), 0, Convert.ToDouble(bonusAmount.Value), promises);
                    ContractResult result = p.ContractNegotiate(currentContract, r);
                    if (result.Equals(ContractResult.Accept))
                    {
                        MessageBox.Show("Player accepted your offer");
                        p.SetNewContract(currentContract);
                        double oldContract = (double)dataGridView2.CurrentRow.Cells[4].Value;
                        dataGridView2.CurrentRow.Cells[4].Value = p.GetMoneyPerYear();
                        dataGridView2.CurrentRow.Cells[6].Value = p.GetYearsLeft();
                        dataGridView2.Rows[dataGridView2.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gray;
                        capSpace += oldContract;
                        capSpace -= p.GetMoneyPerYear();
                        bonusCash -= p.GetBonus();
                        rosterSize.Text = "Players on team " + playersUnderContract + "/15\nPlayers on affiliate " + team.GetAffiliate().Count().ToString() + "/15";
                        MoneyLabel.Text = "Penalty Free Cap Space " + String.Format("{0:0.00}", capSpace) + "M\nAvailable Bonus Money " + String.Format("{0:0.00}", bonusCash) + "M";

                    }
                    else if (result.Equals(ContractResult.Reject))
                    {
                        MessageBox.Show("Player rejected your offer");
                        dataGridView2.Rows[dataGridView2.CurrentRow.Index].DefaultCellStyle.BackColor=Color.Gray;//.Remove(dataGridView1.CurrentRow);
                    }
                    else
                    {
                        Negotiation negotiation = new Negotiation(p, currentContract, r);
                        negotiation.ShowDialog();
                        if(negotiation.Success())
                        {
                            double oldContract = (double)dataGridView2.CurrentRow.Cells[4].Value;
                            p.SetNewContract(negotiation.GetContract());
                            dataGridView2.CurrentRow.Cells[4].Value = p.GetMoneyPerYear();
                            dataGridView2.CurrentRow.Cells[6].Value = p.GetYearsLeft();
                            capSpace += oldContract;
                            capSpace -= p.GetMoneyPerYear();
                            bonusCash -= p.GetBonus();
                            rosterSize.Text = "Players on team " + playersUnderContract + "/15\nPlayers on affiliate " + team.GetAffiliate().Count().ToString() + "/15";
                            MoneyLabel.Text = "Penalty Free Cap Space " + String.Format("{0:0.00}", capSpace) + "M\nAvailable Bonus Money " + String.Format("{0:0.00}", bonusCash) + "M";
                        }
                        dataGridView2.Rows[dataGridView2.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gray;
                    }
                }
                dataGridView2.ClearSelection();
            }
            promises = new List<Promises>();
        }
        public List<player> GetRejectedPlayers()
        {
            return rejectedPlayers;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                DialogResult d = MessageBox.Show("Are you sure you want to cut this player?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (d == DialogResult.Yes)
                {
                    
                    int playerID = (int)dataGridView2.CurrentRow.Cells[5].Value;
                    player p = team.GetPlayerByID(playerID);
                    rejectedPlayers.Add(p);
                    team.CapPenalty += p.GetMoneyPerYear() / 2;
                    capSpace += p.GetMoneyPerYear()/2;

                    playersUnderContract--;

                    rosterSize.Text = "Players on team " + playersUnderContract + "/15\nPlayers on affiliate " + team.GetAffiliate().Count().ToString() + "/15";
                    MoneyLabel.Text = "Penalty Free Cap Space " + String.Format("{0:0.00}", capSpace) + "M\nAvailable Bonus Money " + String.Format("{0:0.00}", bonusCash) + "M";
                    dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                }
                else if (d == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                DialogResult d = MessageBox.Show("Are you sure you want to finish negotiations with this player?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (d == DialogResult.Yes)
                {
                    int playerID = (int)dataGridView1.CurrentRow.Cells[5].Value;
                    player p = team.GetPlayerByID(playerID);
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    if(!rejectedPlayer && r.NextBool())
                    {
                        rejectedPlayer = true;
                        FormulaBasketball.Menu.menu.AddEvent(new Event("Fan Favorite " + p.getName() + " not given an offer", "This week the " + team.ToString() + " announced that " + p.getName() + " would not be joining the team next season. Fans are bitterly disappointed"));
                    }
                }
                else if (d == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                button2.Text = "Cut Player";
            }
            else
            {
                button2.Text = "Not Interested";
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView2.Rows[dataGridView2.CurrentRow.Index].DefaultCellStyle.BackColor.Equals(Color.Gray))
                dataGridView2.ClearSelection();
            
        }

        private void yearsNumber_Validating(object sender, CancelEventArgs e)
        {
            if (yearsNumber.Value < 1) e.Cancel = true;
            else e.Cancel = false;
        }

        private void amountNumber_Validating(object sender, CancelEventArgs e)
        {
            if (amountNumber.Value > 25 || amountNumber.Value < 1) e.Cancel = true;
            else e.Cancel = false;
        }

        private void promisesButtons_Click(object sender, EventArgs e)
        {
            OfferPromises offer = new OfferPromises(promises);
            offer.ShowDialog();
            promises = offer.GetPromises();
        }
    }
}
    
