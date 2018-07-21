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
    public partial class playScrimmage : Form
    {
        private team teamOne, teamTwo;
        private FormulaBasketball.Random r;
        private bool firstTime = true;
        private game newGame;
        private bool isGameOver;
        public playScrimmage(team teamOne, team teamTwo, FormulaBasketball.Random r)
        {
            InitializeComponent();
            this.r = r;
            this.teamOne = teamOne;
            this.teamTwo = teamTwo;
            isGameOver = false;
            teamOneName.Text = teamOne.ToString();
            teamTwoName.Text = teamTwo.ToString();
        }

        private void playQuarter_Click(object sender, EventArgs e)
        {
            if(firstTime)
            {
                firstTime = !firstTime;
                newGame = new game(null, teamOne, teamTwo, r, true);
            }
            if (!isGameOver)
            {
                isGameOver = newGame.playNextQuarter();
                updateScores();
            }
        }

        private void playGame_Click(object sender, EventArgs e)
        {
            newGame = new game(null, teamOne, teamTwo, r);
            updateScores();
        }

        private void updateScores()
        {
            string zeroPadding = "";
            int awayScore = newGame.getAwayTeamScore();
            if (awayScore < 10) zeroPadding = "00";
            else if(awayScore < 100) zeroPadding = "0";
            teamOneScore.Text = zeroPadding + awayScore;

            zeroPadding = "";
            int homeScore = newGame.getHomeTeamScore();
            if (homeScore < 10) zeroPadding = "00";
            else if (homeScore < 100) zeroPadding = "0";
            teamTwoScore.Text = zeroPadding + homeScore;

            quarterNum.Text = "Q" + newGame.getQuarterNum();
        }
    }
}
