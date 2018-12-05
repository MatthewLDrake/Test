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
        public ResignPlayers()
        {
            InitializeComponent();
            r = new FormulaBasketball.Random();
            LoadInfo();
            
        }
        public ResignPlayers(createTeams create, team team, FormulaBasketball.Random r)
        {
            InitializeComponent();
            this.r = r;
            this.team = team;
            this.create = create;

            foreach (player player in team)
            {
                player.endSeason();
                if (player.ContractExpired())
                {
                    dataGridView1.Rows.Add(player.getName(), player.getPosition(), player.getOverall(), player.getDevelopment(), player.GetMoneyPerYear(), player.GetPlayerID());
                }
                else
                {
                    dataGridView2.Rows.Add(player.getName(), player.getPosition(), player.getOverall(), player.getDevelopment(), player.GetMoneyPerYear(), player.GetPlayerID(), player.GetYearsLeft());
                }
            }
        }
        private void LoadInfo()
        {
            create = DeSerializeObject("real.fbdata");

            new SetupNewSeason(create, r);

            team = create.getTeam(12);
            foreach (player player in team)
            {
                player.endSeason();
                if(player.ContractExpired())
                {
                    dataGridView1.Rows.Add(player.getName(), player.getPosition(), player.getOverall(), player.getDevelopment(), player.GetMoneyPerYear(), player.GetPlayerID());
                }
                else
                {
                    dataGridView2.Rows.Add(player.getName(), player.getPosition(), player.getOverall(), player.getDevelopment(), player.GetMoneyPerYear(), player.GetPlayerID(), player.GetYearsLeft());
                }
            }

        }
        /// <summary>
        /// Deserializes a binary file into an object list
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <returns></returns>
        public createTeams DeSerializeObject(string fileName)
        {
            createTeams temp = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream(fileName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                temp = (createTeams)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            return temp;
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
                    Contract currentContract = new Contract(Convert.ToInt32(yearsNumber.Value), Convert.ToDouble(amountNumber.Value));
                    ContractResult result = p.ContractNegotiate(currentContract, r);
                    if (result.Equals(ContractResult.Accept))
                    {
                        MessageBox.Show("Player accepted your offer");
                        p.SetNewContract(currentContract);
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                        dataGridView2.Rows.Add(p.getName(), p.getPosition(), p.getOverall(), p.getDevelopment(), p.GetMoneyPerYear(), p.GetPlayerID(), p.GetYearsLeft());
                        dataGridView2.Rows[dataGridView2.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Gray;

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
                            dataGridView2.Rows[dataGridView2.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Gray;
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
                    Contract currentContract = new Contract(Convert.ToInt32(yearsNumber.Value), Convert.ToDouble(amountNumber.Value));
                    ContractResult result = p.ContractNegotiate(currentContract, r);
                    if (result.Equals(ContractResult.Accept))
                    {
                        MessageBox.Show("Player accepted your offer");
                        p.SetNewContract(currentContract);
                        dataGridView2.CurrentRow.Cells[4].Value = p.GetMoneyPerYear();
                        dataGridView2.CurrentRow.Cells[6].Value = p.GetYearsLeft();
                        dataGridView2.Rows[dataGridView2.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gray;

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
                            p.SetNewContract(negotiation.GetContract());
                            dataGridView2.CurrentRow.Cells[4].Value = p.GetMoneyPerYear();
                            dataGridView2.CurrentRow.Cells[6].Value = p.GetYearsLeft();
                        }
                        dataGridView2.Rows[dataGridView2.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gray;
                    }
                }
                dataGridView2.ClearSelection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to finish negotiations with this player?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            else if (d == DialogResult.No)
            {
                return;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
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

            return;
        }
    }
}
    
