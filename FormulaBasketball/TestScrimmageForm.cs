using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class TestScrimmageForm : Form
    {
        private createTeams create;
        private Random r;
        public TestScrimmageForm(createTeams create, int teamNum)
        {
            InitializeComponent();
            this.create = create;

            r = new Random();

            foreach (OffensivePhilosophy philosophy in OffensivePhilosophy.GetPhilosophies())
            {
                awayTeamOffense.Items.Add(philosophy);
                homeTeamOffense.Items.Add(philosophy);
            }
            foreach (DefensivePhilosophy philosophy in DefensivePhilosophy.GetPhilosophies())
            {
                awayTeamDefense.Items.Add(philosophy);
                homeTeamDefense.Items.Add(philosophy);
            }
            foreach (team team in create.getTeams())
            {
                teamOneList.Items.Add(team.ToString());
                teamTwoList.Items.Add(team.ToString());
            }
            foreach (team team in create.getTeams())
            {
                teamOneList.Items.Add(team.GetAffiliate().ToString());
                teamTwoList.Items.Add(team.GetAffiliate().ToString());
            }
            teamOneList.SelectedIndex = teamNum;
            teamTwoList.SelectedIndex = teamNum == 0 ? 1 : 0;
            awayTeamOffense.SelectedIndex = 0;
            homeTeamOffense.SelectedIndex = 0;
            awayTeamDefense.SelectedIndex = 0;
            homeTeamDefense.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            team copyTeam;
            if (teamOneList.SelectedIndex < 32)
                copyTeam = create.getTeam(teamOneList.SelectedIndex);
            else
                copyTeam = create.getTeam(teamOneList.SelectedIndex - 32).GetAffiliate();
            MemoryStream stream = ScrimmageForm.SerializeTeam(copyTeam);

            team teamOne = ScrimmageForm.DeSerializeTeam(stream);

            teamOne.SetCoach(new Coach("Coach", (OffensivePhilosophy)awayTeamOffense.Items[awayTeamOffense.SelectedIndex] , (DefensivePhilosophy)awayTeamDefense.Items[awayTeamDefense.SelectedIndex], r));

            if (teamTwoList.SelectedIndex < 32)
                copyTeam = create.getTeam(teamTwoList.SelectedIndex);
            else
                copyTeam = create.getTeam(teamTwoList.SelectedIndex - 32).GetAffiliate();
            stream = ScrimmageForm.SerializeTeam(copyTeam);
            team teamTwo = ScrimmageForm.DeSerializeTeam(stream);

            teamTwo.SetCoach(new Coach("Coach", (OffensivePhilosophy)homeTeamOffense.Items[homeTeamOffense.SelectedIndex], (DefensivePhilosophy)homeTeamDefense.Items[homeTeamDefense.SelectedIndex], r));

            new GameViewer(teamOne, teamTwo, r, false).ShowDialog();
        }
    }
}
