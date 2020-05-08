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
        private bool perGameStats, dLeague;
        public StatsForm(createTeams create, int teamNum)
        {
            InitializeComponent();
            this.create = create;
            viewingNumber = teamNum;

            UpdateList();

            teamList.SelectedIndex = viewingNumber;
        }
        private void UpdateList()
        {
            teamList.Items.Clear();
            foreach(team team in create.getTeams())
            {
                team t = team;
                if (dLeague)
                    t = team.GetAffiliate();
                teamList.Items.Add(t.ToString());
            }
            teamList.Items.Add("Division A");
            teamList.Items.Add("Division B");
            teamList.Items.Add("Division C");
            teamList.Items.Add("Division D");
            teamList.Items.Add("Southern Conference");
            teamList.Items.Add("Northern Conference");
            teamList.Items.Add("All Teams");
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

            string teamName = "Free Agent";
            if (p.getTeam() != null)
                teamName = p.getTeam().ToString();

            dataGridView1.Rows.Add(teamName, p.getName(), p.getPosition(),p.getMinutes() / gameDivider, p.getAssists() / gameDivider, p.getPoints() / gameDivider, p.getShotsTaken() / gameDivider, p.getShotsMade() / gameDivider, shootingPercentage, p.getThreesTaken() / gameDivider, p.getThreePointersMade() / gameDivider,
            p.getTurnovers() / gameDivider, p.getSteals() / gameDivider, p.getRebounds() / gameDivider, p.getOffensiveRebounds() / gameDivider, p.getDefensiveRebounds() / gameDivider, p.getFouls() / gameDivider, p.getShotsAttemptedAgainst() / gameDivider, p.getShotsMadeAgainst() / gameDivider, opponentPercentage, plus_minus);
        }
        private void UpdateStats()
        {
            dataGridView1.Rows.Clear();
            if(viewingNumber < 32)
            {
                team t;
                if (dLeague)
                    t = create.getTeam(viewingNumber).GetAffiliate();
                else
                    t = create.getTeam(viewingNumber);
               
                foreach(player p in t)
                {
                    
                    AddPlayerToGrid(p);
                }
                
            }
            // Display Division Stats
            else if(viewingNumber < 36)
            {
                int num = viewingNumber - 32;
                for(int i = 0; i < 8; i++)
                {
                    team t;
                    if (dLeague)
                        t = create.getTeam(i + (num * 8)).GetAffiliate();
                    else
                        t = create.getTeam(i + (num * 8));
                    foreach(player p in t)
                    {
                        AddPlayerToGrid(p);
                    }
                }
            }
            // Display conference stats
            else if(viewingNumber < 38)
            {
                int num = viewingNumber - 36;                
                for(int i = 0; i < 16; i++)
                {
                    team t;
                    if (dLeague)
                        t = create.getTeam(i + (num * 16)).GetAffiliate();
                    else
                        t = create.getTeam(i + (num * 16));
                    foreach (player p in t)
                    {
                        AddPlayerToGrid(p);
                    }
                }
            }
            else
            {
                foreach(team team in create.getTeams())
                {
                    team t = team;
                    if (dLeague)
                        t = t.GetAffiliate();
                    foreach(player p in t)
                    {
                        AddPlayerToGrid(p);
                    }
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dLeague = checkBox2.Checked;
            UpdateList();
            teamList.SelectedIndex = viewingNumber;
        }

        private void teamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewingNumber = teamList.SelectedIndex;
            UpdateStats();
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (viewingNumber > 0)
            {
                teamList.SelectedIndex--;
            }   
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (viewingNumber < teamList.Items.Count - 1)
            {
                teamList.SelectedIndex++;
            }
        }

    }
   
}
