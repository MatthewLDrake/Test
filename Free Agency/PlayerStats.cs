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
    public partial class PlayerStats : Form
    {
        public PlayerStats(player p)
        {
            InitializeComponent();

            double shootingPercentage = 0.0, opponentPercentage = 0.0;
            if (p.getShotsTaken() != 0)
            {

                shootingPercentage = ((double)p.getShotsMade() / (double)p.getShotsTaken()) * 100;
            }
            double plus_minus = 0.0;
            if (p.getGamesPlayed() != 0)
            {
                plus_minus = ((double)p.teamPoints / (double)p.getGamesPlayed());
            }
            if (p.getShotsAttemptedAgainst() != 0)
                opponentPercentage = ((double)p.getShotsMadeAgainst() / (double)p.getShotsAttemptedAgainst()) * 100;



            dataGridView1.Rows.Add("Games Played", p.getGamesPlayed());
            dataGridView1.Rows.Add("Minutes", p.getMinutes());
            dataGridView1.Rows.Add("Assists", p.getAssists());
            dataGridView1.Rows.Add("Points", p.getPoints());
            dataGridView1.Rows.Add("Shots Taken", p.getShotsTaken());
            dataGridView1.Rows.Add("Shots Made", p.getShotsMade());
            dataGridView1.Rows.Add("Field Goal Percentage", shootingPercentage);
            dataGridView1.Rows.Add("Threes Taken", p.getThreesTaken());
            dataGridView1.Rows.Add("Threes Made", p.getThreePointersMade());
            dataGridView1.Rows.Add("Free Throws Taken", p.getFreeThrowsTaken());
            dataGridView1.Rows.Add("Free Throws Made", p.getFreeThrowsMade());
            dataGridView1.Rows.Add("Turnovers", p.getTurnovers());
            dataGridView1.Rows.Add("Steals", p.getSteals());
            dataGridView1.Rows.Add("Rebounds", p.getRebounds());
            dataGridView1.Rows.Add("Offensive Rebounds", p.getOffensiveRebounds());
            dataGridView1.Rows.Add("Defensive Rebounds", p.getDefensiveRebounds());
            dataGridView1.Rows.Add("Fouls", p.getFouls());
            dataGridView1.Rows.Add("Opponent Shots Against", p.getShotsAttemptedAgainst());
            dataGridView1.Rows.Add("Opponent Shots Made", p.getShotsMadeAgainst());
            dataGridView1.Rows.Add("Opponent Shot Percent", opponentPercentage);
            dataGridView1.Rows.Add("Point Differential", plus_minus);
        }
    }
}
