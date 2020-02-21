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
    public partial class TeamRoster : Form
    {
        private createTeams create;
        private int viewingNumber;
        private bool dLeague;
        public TeamRoster(createTeams create, int teamNum)
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
            foreach (team team in create.getTeams())
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
        private void AddPlayerToGrid(player p)
        {
            playerGrid.Rows.Add(p.GetCountry(), p.getName(), p.age, p.getLayupRating(false), p.getDunkRating(false), p.getJumpShotRating(false), p.getThreeShotRating(false), p.getPassing(false), p.getShotContestRating(false), p.getDefenseIQRating(false), p.getJumpingRating(false), p.getSeperation(false), p.getDurabilityRating(false), p.getStaminaRating(false), p.getDevelopment(), p.getOverall());          
        }
        private void UpdateRatings()
        {
            playerGrid.Rows.Clear();
            if (viewingNumber < 32)
            {
                team t;
                if (dLeague)
                    t = create.getTeam(viewingNumber).GetAffiliate();
                else
                    t = create.getTeam(viewingNumber);

                foreach (player p in t)
                {

                    AddPlayerToGrid(p);
                }

            }
            // Display Division Stats
            else if (viewingNumber < 36)
            {
                int num = viewingNumber - 32;
                for (int i = 0; i < 8; i++)
                {
                    team t;
                    if (dLeague)
                        t = create.getTeam(i + (num * 8)).GetAffiliate();
                    else
                        t = create.getTeam(i + (num * 8));
                    foreach (player p in t)
                    {
                        AddPlayerToGrid(p);
                    }
                }
            }
            // Display conference stats
            else if (viewingNumber < 38)
            {
                int num = viewingNumber - 36;
                for (int i = 0; i < 16; i++)
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
                foreach (team team in create.getTeams())
                {
                    team t = team;
                    if (dLeague)
                        t = t.GetAffiliate();
                    foreach (player p in t)
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
            UpdateRatings();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (viewingNumber < teamList.Items.Count - 1)
            {
                teamList.SelectedIndex++;
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (viewingNumber > 0)
            {
                teamList.SelectedIndex--;
            }   
        }
    }
}
