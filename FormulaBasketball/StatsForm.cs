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
    public partial class StatsForm : Form
    {
        private createTeams create;
        private int viewingNumber;
        private bool perGameStats;
        public StatsForm(createTeams create, int teamNum)
        {
            InitializeComponent();
            this.create = create;
            viewingNumber = teamNum;
            UpdateStats();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            perGameStats = checkBox1.Checked;
            UpdateStats();
        }
        private void AddPlayerToGrid(player p)
        {
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
            double gameDivider = ((perGameStats && p.getGamesPlayed() > 0) ? p.getGamesPlayed() : 1.0);
            dataGridView1.Rows.Add(p.getTeam().ToString(), p.getName(), p.getMinutes() / gameDivider, p.getAssists() / gameDivider, p.getPoints() / gameDivider, p.getShotsTaken() / gameDivider, p.getShotsMade() / gameDivider, shootingPercentage, p.getThreesTaken() / gameDivider, p.getThreePointersMade() / gameDivider,
            p.getTurnovers() / gameDivider, p.getSteals() / gameDivider, p.getRebounds() / gameDivider, p.getOffensiveRebounds() / gameDivider, p.getDefensiveRebounds() / gameDivider, p.getFouls() / gameDivider, p.getShotsAttemptedAgainst() / gameDivider, p.getShotsMadeAgainst() / gameDivider, opponentPercentage, plus_minus);
        }
        private void UpdateStats()
        {
            dataGridView1.Rows.Clear();
            if(viewingNumber < 32)
            {
                foreach(player p in create.getTeam(viewingNumber))
                {
                    AddPlayerToGrid(p);
                }
            }
        }

    }
}
