using System;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class Form3 : Form
    {
        private int startingGame, endGame;
        public Form3(int startingGame)
        {
            this.startingGame = startingGame;
            endGame = 84 - startingGame;
            InitializeComponent();
            gamesPlayed.Maximum = endGame;

            endGame = gamesPlayed.Value;
            label1.Text = "Current Value: " + gamesPlayed.Value + Environment.NewLine + "Currently Playing Games: " + startingGame + " - " + (startingGame + endGame);
        }

        public int getFinishPoint()
        {
            return startingGame + endGame;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gamesPlayed_Scroll(object sender, EventArgs e)
        {
            endGame = gamesPlayed.Value;
            label1.Text = "Current Value: " + gamesPlayed.Value + Environment.NewLine + "Currently Playing Games: " + startingGame + " - " + (startingGame+endGame);
        }
    }
}
