
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class Menu : Form
    {
        private createTeams create;
        private team team;
        private FormulaBasketball.Random r;
        private int teamNum;
        private int stage;
        private ResignPlayers resignForm;
        private bool master = true;
        public Menu(createTeams create, int teamNum, FormulaBasketball.Random r)
        {
            InitializeComponent();
            this.create = create;
            
            team = create.getTeam(teamNum);
            foreach (player player in team)
            {
                player.endSeason();
            }
            foreach(player player in team.GetAffiliate())
            {
                player.endSeason();
            }
            create.getFreeAgents().AdvanceSeason();
            create.SetupSalaryInfo();
            this.r = r;
            this.teamNum = teamNum;
            stage = 0;
        }       

        private void resignPlayersButton_Click(object sender, EventArgs e)
        {
            if (stage == 0)
            {
                this.Visible = false;
                if(resignForm == null)
                    resignForm = new ResignPlayers(create, team, r);
                resignForm.ShowDialog();
                this.Visible = true;
            }
            else if(stage < 4)
            {
                this.Visible = false;
                create.getFreeAgents().Verify();
                FreeAgencyForm freeAgentForm = new FreeAgencyForm(create.getFreeAgents(), team, create);
                freeAgentForm.ShowDialog();
                this.Visible = true;
            }
            else
            {
                this.Visible = false;
                DepthChart depthChart = new DepthChart(team);
                depthChart.ShowDialog();
                this.Visible = true;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            formulaBasketball.SerializeObject(create, "testSave.fbdata");
            //Close();
        }

        private void viewRoster_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ViewRoster freeAgentForm = new ViewRoster(team);
            freeAgentForm.ShowDialog();
            this.Visible = true;
        }

        private void viewDLeagueRoster_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ViewRoster freeAgentForm = new ViewRoster(team.GetAffiliate());
            freeAgentForm.ShowDialog();
            this.Visible = true;
        }

        private void scoutButton_Click(object sender, EventArgs e)
        {
            if (stage < 4)
            {
                this.Visible = false;
                Scouting freeAgentForm = new Scouting(create.GetCollege().GetRookies(), r);
                freeAgentForm.ShowDialog();
                this.Visible = true;
            }
            else
            {

            }
        }
        private void awardsButton_Click(object sender, EventArgs e)
        {
            if (stage == 1)
            {
                this.Visible = false;
                AwardVoting voting = new AwardVoting(create);
                voting.ShowDialog();
                this.Visible = true;
            }
            else
            {
                this.Visible = false;
                TradeForm freeAgentForm = new TradeForm(create, team, teamNum);
                freeAgentForm.ShowDialog();
                this.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to advance? All uncompleted tasks will be autocompleted.", "Confirmation", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                stage++;
                if(stage == 1)
                {
                    if(resignForm == null)
                        resignForm = new ResignPlayers(create, team, r);
                    List<player> players = resignForm.GetRejectedPlayers();
                    create.getFreeAgents().Add(players);
                    team.removePlayer(players);

                    if(master)
                    {
                        for(int i = 0; i < create.size(); i++)
                        {
                            if (i == teamNum) continue;
                            players = create.getTeam(i).resignPlayers(create, r);
                            create.getFreeAgents().Add(players);
                            create.getTeam(i).removePlayer(players);
                        }
                    }

                    resignPlayersButton.Text = "Free Agency";
                    awardsButton.Text = "Trade";
                }
                else if(stage == 4)
                {
                    scoutButton.Text = "Draft";
                    resignPlayersButton.Text = "Change Depth Chart";
                }
            }
        }
    }
}
