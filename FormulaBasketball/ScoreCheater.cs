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
    [Serializable]
    public partial class ScoreCheater : Form
    {
        private List<int> awayScores, homeScores;
        private NewTeam awayTeam, homeTeam;
        public ScoreCheater(NewTeam awayTeam, NewTeam homeTeam)
        {
            InitializeComponent();

            this.awayTeam = awayTeam;
            this.homeTeam = homeTeam;

            dataGridView1.Rows.Add(new object[] { awayTeam.ToString(), 0,0,0,0,"",0 });
            dataGridView1.Rows.Add(new object[] { homeTeam.ToString(), 0, 0, 0, 0, "", 0 });
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            int totalAwayScore = 0, totalHomeScore = 0;

            awayScores = new List<int>();

            int amount;
            if (dataGridView1.Rows[0].Cells[1].Value is int)
                amount = (int)dataGridView1.Rows[0].Cells[1].Value;
            else
                amount = int.Parse((string)dataGridView1.Rows[0].Cells[1].Value);
            awayScores.Add(amount);

            totalAwayScore += amount;

            if (dataGridView1.Rows[0].Cells[2].Value is int)
                amount = (int)dataGridView1.Rows[0].Cells[2].Value;
            else
                amount = int.Parse((string)dataGridView1.Rows[0].Cells[2].Value);
            awayScores.Add(amount);

            totalAwayScore += amount;

            if (dataGridView1.Rows[0].Cells[3].Value is int)
                amount = (int)dataGridView1.Rows[0].Cells[3].Value;
            else
                amount = int.Parse((string)dataGridView1.Rows[0].Cells[3].Value);
            awayScores.Add(amount);

            totalAwayScore += amount;

            if (dataGridView1.Rows[0].Cells[4].Value is int)
                amount = (int)dataGridView1.Rows[0].Cells[4].Value;
            else
                amount = int.Parse((string)dataGridView1.Rows[0].Cells[4].Value);
            awayScores.Add(amount);

            totalAwayScore += amount;

            homeScores = new List<int>();

            if (dataGridView1.Rows[1].Cells[1].Value is int)
                amount = (int)dataGridView1.Rows[1].Cells[1].Value;
            else
                amount = int.Parse((string)dataGridView1.Rows[1].Cells[1].Value);
            homeScores.Add(amount);

            totalHomeScore += amount;

            if (dataGridView1.Rows[1].Cells[2].Value is int)
                amount = (int)dataGridView1.Rows[1].Cells[2].Value;
            else
                amount = int.Parse((string)dataGridView1.Rows[1].Cells[2].Value);
            homeScores.Add(amount);

            totalHomeScore += amount;

            if (dataGridView1.Rows[1].Cells[3].Value is int)
                amount = (int)dataGridView1.Rows[1].Cells[3].Value;
            else
                amount = int.Parse((string)dataGridView1.Rows[1].Cells[3].Value);
            homeScores.Add(amount);

            totalHomeScore += amount;

            if (dataGridView1.Rows[1].Cells[4].Value is int)
                amount = (int)dataGridView1.Rows[1].Cells[4].Value;
            else
                amount = int.Parse((string)dataGridView1.Rows[1].Cells[4].Value);

            homeScores.Add(amount);

            totalHomeScore += amount;

            if(totalHomeScore == totalAwayScore)
            {
                if (dataGridView1.Rows[0].Cells[5].Value is int)
                    amount = (int)dataGridView1.Rows[0].Cells[5].Value;
                else
                    amount = int.Parse((string)dataGridView1.Rows[0].Cells[5].Value);

                awayScores.Add(amount);

                if (dataGridView1.Rows[1].Cells[5].Value is int)
                    amount = (int)dataGridView1.Rows[1].Cells[5].Value;
                else
                    amount = int.Parse((string)dataGridView1.Rows[1].Cells[5].Value);

                homeScores.Add(amount);
            }

            Close();
        }
        public List<int> GetAwayScores()
        {
            return awayScores;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == 0)
            {
                int amount, totalAwayScore = 0;
                if (dataGridView1.Rows[0].Cells[1].Value is int)
                    amount = (int)dataGridView1.Rows[0].Cells[1].Value;
                else
                    amount = int.Parse((string)dataGridView1.Rows[0].Cells[1].Value);

                totalAwayScore += amount;

                if (dataGridView1.Rows[0].Cells[2].Value is int)
                    amount = (int)dataGridView1.Rows[0].Cells[2].Value;
                else
                    amount = int.Parse((string)dataGridView1.Rows[0].Cells[2].Value);

                totalAwayScore += amount;

                if (dataGridView1.Rows[0].Cells[3].Value is int)
                    amount = (int)dataGridView1.Rows[0].Cells[3].Value;
                else
                    amount = int.Parse((string)dataGridView1.Rows[0].Cells[3].Value);

                totalAwayScore += amount;

                if (dataGridView1.Rows[0].Cells[4].Value is int)
                    amount = (int)dataGridView1.Rows[0].Cells[4].Value;
                else
                    amount = int.Parse((string)dataGridView1.Rows[0].Cells[4].Value);

                totalAwayScore += amount;

                try
                {
                    if (dataGridView1.Rows[0].Cells[5].Value is int)
                        amount = (int)dataGridView1.Rows[0].Cells[5].Value;
                    else
                        amount = int.Parse((string)dataGridView1.Rows[0].Cells[5].Value);

                    totalAwayScore += amount;
                }
                catch
                {

                }
                dataGridView1.Rows[0].Cells[6].Value = totalAwayScore;
            }
            else if(e.RowIndex == 1)
            {
                int amount, totalHomeScore = 0;

                if (dataGridView1.Rows[1].Cells[1].Value is int)
                    amount = (int)dataGridView1.Rows[1].Cells[1].Value;
                else
                    amount = int.Parse((string)dataGridView1.Rows[1].Cells[1].Value);

                totalHomeScore += amount;

                if (dataGridView1.Rows[1].Cells[2].Value is int)
                    amount = (int)dataGridView1.Rows[1].Cells[2].Value;
                else
                    amount = int.Parse((string)dataGridView1.Rows[1].Cells[2].Value);

                totalHomeScore += amount;

                if (dataGridView1.Rows[1].Cells[3].Value is int)
                    amount = (int)dataGridView1.Rows[1].Cells[3].Value;
                else
                    amount = int.Parse((string)dataGridView1.Rows[1].Cells[3].Value);

                totalHomeScore += amount;

                if (dataGridView1.Rows[1].Cells[4].Value is int)
                    amount = (int)dataGridView1.Rows[1].Cells[4].Value;
                else
                    amount = int.Parse((string)dataGridView1.Rows[1].Cells[4].Value);
                    
                totalHomeScore += amount;
                try
                {
                    if (dataGridView1.Rows[1].Cells[5].Value is int)
                        amount = (int)dataGridView1.Rows[1].Cells[5].Value;
                    else
                        amount = int.Parse((string)dataGridView1.Rows[1].Cells[5].Value);

                    totalHomeScore += amount;
                }
                catch
                {

                }
                dataGridView1.Rows[1].Cells[6].Value = totalHomeScore;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddInjuryForm form = new AddInjuryForm(awayTeam);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddInjuryForm form = new AddInjuryForm(homeTeam);
            form.ShowDialog();
        }

        public List<int> GetHomeScores()
        {
            return homeScores;
        }
    }
}
