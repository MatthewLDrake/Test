
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
        public Menu(createTeams create, int teamNum, FormulaBasketball.Random r)
        {
            InitializeComponent();
            this.create = create;
            team = create.getTeam(teamNum);
            this.r = r;
            this.teamNum = teamNum;
        }
       
        private void freeAgencyButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            create.getFreeAgents().Verify();
            FreeAgencyForm freeAgentForm = new FreeAgencyForm(create.getFreeAgents(), team, create);
            freeAgentForm.ShowDialog();
            this.Visible = true;
        }
       

        private void tradeButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            TradeForm freeAgentForm = new TradeForm(create, team, teamNum);
            freeAgentForm.ShowDialog();
            this.Visible = true;
        }

        private void resignPlayersButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ResignPlayers freeAgentForm = new ResignPlayers(create, team, r);
            freeAgentForm.ShowDialog();
            this.Visible = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
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
            this.Visible = false;

            Scouting freeAgentForm = new Scouting(create.GetCollege().GetRookies(), r);            
            freeAgentForm.ShowDialog();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
