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
    public partial class PlayerSigned : Form
    {
        private int pos;
        private player p;
        private List<FreeAgentContracts> contracts; 
        public PlayerSigned(player p)
        {
            InitializeComponent();
            this.p = p;
            pos = p.getPosition();
            contracts = p.GetFreeAgentOffers();
            foreach(FreeAgentContracts contract in contracts)
            {
                dataGridView1.Rows.Add(new object[] { "Y: " + contract.GetContract().GetYearsLeft() + "M: " + contract.GetContract().GetMoney(), contract.GetTeam().ToString(), contract.GetTeam() });
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                foreach (player p in (team)dataGridView1.SelectedRows[0].Cells[2].Value)
                {
                    if (p.getPosition() == pos)
                    {
                        p.setDefensiveModifier(0);
                        p.setOtherModifier(0);
                        p.setShootingModifier(0);
                        p.setStamina(100);
                        rosterGrid.Rows.Add(p.getName(), p.age, String.Format("{0:0.00}", p.getOverall()), p.getDevelopment(),  p.GetMoneyPerYear());
                    }
                }
                foreach (player p in ((team)dataGridView1.SelectedRows[0].Cells[2].Value).GetAffiliate())
                {
                    if (p.getPosition() == pos)
                    {
                        p.setDefensiveModifier(0);
                        p.setOtherModifier(0);
                        p.setShootingModifier(0);
                        p.setStamina(100);
                        rosterGrid.Rows.Add(p.getName(), p.age, String.Format("{0:0.00}", p.getOverall()), p.getDevelopment(), p.GetMoneyPerYear());
                    }
                }
            }
        }

        private void teamSelect_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)            
                return;

            ((team)dataGridView1.SelectedRows[0].Cells[2].Value).OffSeasonAddPlayer(p);


            Close();
        }
    }
}
