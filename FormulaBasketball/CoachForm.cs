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
    public partial class CoachForm : Form
    {
        private League league;
        public CoachForm(League league)
        {
            InitializeComponent();

            this.league = league;
            foreach (NewTeam team in league)
            {
                if (team.GetCoach() != null && team.GetCoach().GetContract().GetYearsLeft() <= 0)
                    team.RemoveCoach(team.GetCoach());
                teamList.Items.Add(team.ToString());
            }
            for (int i = 0; i < 32; i++)
            {
                if (league.GetDLeagueTeam(i).GetCoach() != null && league.GetDLeagueTeam(i).GetCoach().GetContract().GetYearsLeft() <= 0)
                    league.GetDLeagueTeam(i).RemoveCoach(league.GetDLeagueTeam(i).GetCoach());
            }
            teamList.SelectedIndex = 0;

            UpdateMainGrid();           
        }
        private void UpdateMainGrid()
        {
            dataGridView3.Rows.Clear();

            HashSet<int> coachIDs = new HashSet<int>();

            for(int i = 0; i < 32; i++)
            {
                List<Object> coaches = league.GetTeam(i).GetAllCoaches(true);
                if (coaches[0] != null)
                {
                    dataGridView3.Rows.Add(coaches[0].ToString(), league.GetTeam(i) + " Head Coach", "Hire", coaches[0]);
                    coachIDs.Add((coaches[0] as NewRealCoach).GetCoachID());
                }
                if (coaches[1] != null)
                {
                    dataGridView3.Rows.Add(coaches[1].ToString(), league.GetTeam(i) + " Offensive Assistant", "Hire", coaches[1]);
                    coachIDs.Add((coaches[1] as NewRealCoach).GetCoachID());
                }
                if (coaches[2] != null)
                {
                    dataGridView3.Rows.Add(coaches[2].ToString(), league.GetTeam(i) + " Defensive Assistant", "Hire", coaches[2]);
                    coachIDs.Add((coaches[2] as NewRealCoach).GetCoachID());
                }

                coaches = league.GetDLeagueTeam(i).GetAllCoaches(true);
                if (coaches[0] != null)
                {
                    dataGridView3.Rows.Add(coaches[0].ToString(), league.GetDLeagueTeam(i) + " Head Coach", "Hire", coaches[0]);
                    coachIDs.Add((coaches[0] as NewRealCoach).GetCoachID());
                }
                if (coaches[1] != null)
                {
                    dataGridView3.Rows.Add(coaches[1].ToString(), league.GetDLeagueTeam(i) + " Offensive Assistant", "Hire", coaches[1]);
                    coachIDs.Add((coaches[1] as NewRealCoach).GetCoachID());
                }
                if (coaches[2] != null)
                {
                    dataGridView3.Rows.Add(coaches[2].ToString(), league.GetDLeagueTeam(i) + " Defensive Assistant", "Hire", coaches[2]);
                    coachIDs.Add((coaches[2] as NewRealCoach).GetCoachID());
                }
            }
            

            foreach(NewRealCoach coach in league.GetCoaches())
            {
                if(!coachIDs.Contains(coach.GetCoachID()))
                {
                    dataGridView3.Rows.Add(coach.ToString(), "None", "Hire", coach);
                    coachIDs.Add(coach.GetCoachID());
                }
            }
        }
        private void teamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTeamGrids();
        }
        private void UpdateTeamGrids()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            List<Object> coaches = league.GetTeam(teamList.SelectedIndex).GetAllCoaches(true);
            dataGridView1.Rows.Add(coaches[0] != null ? coaches[0].ToString() : "None", "Head Coach", coaches[0] != null ? "Fire" : "Hire", coaches[0]);
            dataGridView1.Rows.Add(coaches[1] != null ? coaches[1].ToString() : "None", "Offensive Assistant", coaches[1] != null ? "Fire" : "Hire", coaches[1]);
            dataGridView1.Rows.Add(coaches[2] != null ? coaches[2].ToString() : "None", "Defensive Assistant", coaches[2] != null ? "Fire" : "Hire", coaches[2]);
            dataGridView1.Rows.Add(coaches[3] != null ? coaches[3].ToString() : "None", "General Manager", coaches[3] != null ? "Fire" : "Hire", coaches[3]);
            dataGridView1.Rows.Add(coaches[4] != null ? coaches[4].ToString() : "None", "Scout", coaches[4] != null ? "Fire" : "Hire", coaches[4]);

            coaches = league.GetDLeagueTeam(teamList.SelectedIndex).GetAllCoaches(true);
            dataGridView2.Rows.Add(coaches[0] != null ? coaches[0].ToString() : "None", "Head Coach", coaches[0] != null ? "Fire" : "Hire", coaches[0]);
            dataGridView2.Rows.Add(coaches[1] != null ? coaches[1].ToString() : "None", "Offensive Assistant", coaches[1] != null ? "Fire" : "Hire", coaches[1]);
            dataGridView2.Rows.Add(coaches[2] != null ? coaches[2].ToString() : "None", "Defensive Assistant", coaches[2] != null ? "Fire" : "Hire", coaches[2]);
            dataGridView2.Rows.Add(coaches[3] != null ? coaches[3].ToString() : "None", "General Manager", coaches[3] != null ? "Fire" : "Hire", coaches[3]);
            dataGridView2.Rows.Add(coaches[4] != null ? coaches[4].ToString() : "None", "Scout", coaches[4] != null ? "Fire" : "Hire", coaches[4]);
        }
        int hireIntoSpot = -1;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hire/Fire
            if(e.ColumnIndex == 2)
            {
                if(dataGridView1.Rows[e.RowIndex].Cells[3].Value == null)
                {
                    hireIntoSpot = e.RowIndex;
                }
                else
                {
                    NewRealCoach coach = dataGridView1.Rows[e.RowIndex].Cells[3].Value as NewRealCoach;
                    league.GetTeam(teamList.SelectedIndex).RemoveCoach(coach);
                    UpdateTeamGrids();
                    UpdateMainGrid();
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hire/Fire
            if (e.ColumnIndex == 2)
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[3].Value == null)
                {
                    hireIntoSpot = e.RowIndex + 5;
                }
                else
                {
                    NewRealCoach coach = dataGridView1.Rows[e.RowIndex].Cells[3].Value as NewRealCoach;
                    league.GetDLeagueTeam(teamList.SelectedIndex).RemoveCoach(coach);

                    UpdateTeamGrids();
                    UpdateMainGrid();
                }
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hire/Fire
            if (e.ColumnIndex == 2)
            {
                if(hireIntoSpot != -1)
                {
                    Contract contractGiven;
                    if(hireIntoSpot == 0 || hireIntoSpot == 5)
                    {
                        NewContract contract = new NewContract();
                        contract.ShowDialog();
                        contractGiven = contract.GetContract();
                    }
                    else
                    {
                        contractGiven = new Contract(1, .5);
                    }
                    if((dataGridView3.Rows[e.RowIndex].Cells[3].Value as NewRealCoach).GetTeam() != -1)
                    {
                        if((dataGridView3.Rows[e.RowIndex].Cells[3].Value as NewRealCoach).GetTeam() > 32)
                        {
                            league.GetDLeagueTeam((dataGridView3.Rows[e.RowIndex].Cells[3].Value as NewRealCoach).GetTeam() - 32).RemoveCoach((dataGridView3.Rows[e.RowIndex].Cells[3].Value as NewRealCoach));
                        }
                        else
                        {
                            league.GetTeam((dataGridView3.Rows[e.RowIndex].Cells[3].Value as NewRealCoach).GetTeam()).RemoveCoach((dataGridView3.Rows[e.RowIndex].Cells[3].Value as NewRealCoach));
                        }
                    }
                    if(hireIntoSpot >= 5)
                        league.GetDLeagueTeam(teamList.SelectedIndex).HireCoach(dataGridView3.Rows[e.RowIndex].Cells[3].Value as NewRealCoach, hireIntoSpot - 5);
                    else
                        league.GetTeam(teamList.SelectedIndex).HireCoach(dataGridView3.Rows[e.RowIndex].Cells[3].Value as NewRealCoach, hireIntoSpot);

                    hireIntoSpot = -1;

                    (dataGridView3.Rows[e.RowIndex].Cells[3].Value as NewRealCoach).SetTeam(contractGiven, teamList.SelectedIndex + (hireIntoSpot >= 5 ? 32 : 0));
                }
                UpdateTeamGrids();
                UpdateMainGrid();
            }
        }
    }
}
