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
    public partial class AddStatsForm : Form
    {
        private NewPlayer p;
        public AddStatsForm(NewPlayer p)
        {
            InitializeComponent();
            this.p = p;
            foulTrackBar.Maximum = (6 - p.GetGameStats().GetFouls());
        }
        public object[] GetValues()
        {
            return new object[]{p.GetName(), "" + twoMadeTrackBar.Value + "/" + twoAttTrackBar.Value, "" + threeMadeTrackBar.Value + "/" + threeAttTrackBar.Value, "" + FTMadeTrackBar.Value  + "/" + FTAttTrackBar.Value, assistTrackBar.Value, "" + offRebTrackBar.Value +  "/" + defRebTrackBar.Value , stealsTrackBar.Value, blockTrackBar.Value, turnoverTrackBar.Value, "Add Stats", "Add Injury", p };
        }
        private void twoAttTrackBar_ValueChanged(object sender, EventArgs e)
        {
            twoMadeTrackBar.Maximum = twoAttTrackBar.Value;
            twosAttempt.Text = "" + twoAttTrackBar.Value;
        }

        private void twoMadeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            twosMade.Text = "" + twoMadeTrackBar.Value;
        }

        private void threeAttTrackBar_ValueChanged(object sender, EventArgs e)
        {
            threeAttTrackBar.Text = "" + threeAttTrackBar.Value;
            threeMadeTrackBar.Maximum = threeAttTrackBar.Value;
        }

        private void threeMadeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            threeMadeTrackBar.Text = "" + threeMadeTrackBar.Value;
        }

        private void FTAttTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ftAtt.Text = "" + FTAttTrackBar.Value;
            FTMadeTrackBar.Maximum = FTAttTrackBar.Value;
        }

        private void FTMadeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ftMade.Text = "" + FTMadeTrackBar.Value;
        }

        private void assistTrackBar_ValueChanged(object sender, EventArgs e)
        {
            assistsAmount.Text = "" + assistTrackBar.Value;
        }

        private void offRebTrackBar_ValueChanged(object sender, EventArgs e)
        {
            offRebounds.Text = "" + offRebTrackBar.Value;
        }

        private void defRebTrackBar_ValueChanged(object sender, EventArgs e)
        {
            defRebounds.Text = "" + defRebTrackBar.Value;
        }

        private void stealsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            stealsAmount.Text = "" + stealsTrackBar.Value;
        }

        private void turnoverTrackBar_ValueChanged(object sender, EventArgs e)
        {
            turnoversAmount.Text = "" + turnoverTrackBar.Value;
        }

        private void blockTrackBar_ValueChanged(object sender, EventArgs e)
        {
            blocksAmount.Text = "" + blockTrackBar.Value;

        }

        private void foulTrackBar_ValueChanged(object sender, EventArgs e)
        {
            foulsAmount.Text = "" + foulTrackBar.Value;
        }
    }
}
