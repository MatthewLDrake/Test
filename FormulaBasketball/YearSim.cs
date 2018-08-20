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
    public partial class YearSim : Form
    {
        private int endSeasons;
        private string result;
        public YearSim()
        {
            InitializeComponent();
            endSeasons = 1;
            label1.Text = "Current Value: " + seasonsPlayed.Value + Environment.NewLine + "Currently Playing Seasons: " + 1 + " - " + (1 + endSeasons);
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            result = "playseasons";
            this.Close();
        }
        private void gamesPlayed_Scroll(object sender, EventArgs e)
        {
            endSeasons = seasonsPlayed.Value;
            label1.Text = "Current Value: " + seasonsPlayed.Value + Environment.NewLine + "Currently Playing Seasons: " + 1 + " - " + (1 + endSeasons);
        }
        public int GetSeasons()
        {
            return endSeasons;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            result = "Save";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = "exitButton";
            this.Close();
        }
        public String GetResult()
        {
            return result;
        }
    }
}
