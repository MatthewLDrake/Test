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
    public partial class ManageTeam : Form
    {
        private League league;
        private static string releaseList, promotionList, demotionList, signList;
        public ManageTeam(League league)
        {
            InitializeComponent();
            this.league = league;
            foreach (NewTeam team in league)
            {
                teamList.Items.Add(team.ToString());
            }
            List<NewPlayer> players = league.GetFreeAgents().GetAllPlayers();
            players.Sort();
            foreach (NewPlayer p in players)
            {
                dataGridView3.Rows.Add(new object[] { p.ToString(), p.GetAge(), p.GetPositionAsString(), p.GetBestOverall(), p.GetDevelopmentAsString(), dataGridView3.Columns[5].HeaderText, dataGridView3.Columns[6].HeaderText, p });
            }
        }

        private void teamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddTeamToGrid(league.GetTeam(teamList.SelectedIndex), dataGridView1);
            AddTeamToGrid(league.GetDLeagueTeam(teamList.SelectedIndex), dataGridView2);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:\\Users\\dmatt\\Documents\\GitHub\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\singings.csv", signList);
            File.WriteAllText("C:\\Users\\dmatt\\Documents\\GitHub\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\demotions.csv", demotionList);
            File.WriteAllText("C:\\Users\\dmatt\\Documents\\GitHub\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\promotions.csv", promotionList);
            File.WriteAllText("C:\\Users\\dmatt\\Documents\\GitHub\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\releasings.csv", releaseList);

            League.SerializeObject(league, "league.fbleague");

            Close();
        }

        private void AddTeamToGrid(NewTeam team, DataGridView grid)
        {
            grid.Rows.Clear();
            foreach (NewPlayer p in team)
            {
                grid.Rows.Add(new object[] { p.ToString(), p.GetAge(), p.GetPositionAsString(), p.GetBestOverall(), p.GetDevelopmentAsString(), grid.Columns[5].HeaderText, grid.Columns[6].HeaderText, p });
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                NewPlayer player = dataGridView1.Rows[e.RowIndex].Cells[7].Value as NewPlayer;
                releaseList += player.GetPlayerID() + "\n";

                league.GetTeam(teamList.SelectedIndex).RemovePlayer(player);
                AddTeamToGrid(league.GetTeam(teamList.SelectedIndex), dataGridView1);

                league.AddPlayerToWaivers(player);
            }
            else if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                NewPlayer player = dataGridView1.Rows[e.RowIndex].Cells[7].Value as NewPlayer;
                demotionList += player.GetPlayerID() + "\n";

                league.GetTeam(teamList.SelectedIndex).RemovePlayer(player);
                AddTeamToGrid(league.GetTeam(teamList.SelectedIndex), dataGridView1);

                league.AddPlayerToWaivers(player);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                NewPlayer player = dataGridView2.Rows[e.RowIndex].Cells[7].Value as NewPlayer;
                releaseList += player.GetPlayerID() + "\n";

                league.GetDLeagueTeam(teamList.SelectedIndex).RemovePlayer(player);

                AddTeamToGrid(league.GetDLeagueTeam(teamList.SelectedIndex), dataGridView2);

                league.AddPlayerToWaivers(player);
            }
            else if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                NewPlayer player = dataGridView2.Rows[e.RowIndex].Cells[7].Value as NewPlayer;
                promotionList += player.GetPlayerID() + "\n";

                league.GetDLeagueTeam(teamList.SelectedIndex).RemovePlayer(player);
                league.GetTeam(teamList.SelectedIndex).AddPlayer(player);

                AddTeamToGrid(league.GetTeam(teamList.SelectedIndex), dataGridView1);
                AddTeamToGrid(league.GetDLeagueTeam(teamList.SelectedIndex), dataGridView2);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                NewContract contract = new NewContract();
                contract.ShowDialog();

                NewPlayer player = dataGridView3.Rows[e.RowIndex].Cells[7].Value as NewPlayer;
                signList += player.GetPlayerID() + "," + teamList.SelectedIndex + "," + contract.GetContract().GetYearsLeft() + "," + contract.GetContract().GetMoney() + "\n";

                league.GetTeam(teamList.SelectedIndex).AddPlayer(player);
                player.SetContract(contract.GetContract());
                league.GetTeam(teamList.SelectedIndex).ChangeMoney((long) Math.Round(contract.GetContract().GetBonus() * -1000000));

                league.GetFreeAgents().RemovePlayer(player);

                AddTeamToGrid(league.GetTeam(teamList.SelectedIndex), dataGridView1);

                dataGridView3.Rows.Clear();
                List<NewPlayer> players = league.GetFreeAgents().GetAllPlayers();
                players.Sort();
                foreach (NewPlayer p in players)
                {
                    dataGridView3.Rows.Add(new object[] { p.ToString(), p.GetAge(), p.GetPositionAsString(), p.GetBestOverall(), p.GetDevelopmentAsString(), dataGridView3.Columns[5].HeaderText, dataGridView3.Columns[6].HeaderText, p });
                }
            }
            else if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                NewPlayer player = dataGridView3.Rows[e.RowIndex].Cells[7].Value as NewPlayer;
                signList += player.GetPlayerID() + "," + teamList.SelectedIndex + ",d\n";

                league.GetDLeagueTeam(teamList.SelectedIndex).AddPlayer(player);
                player.SetContract(new Contract(1,1));

                league.GetFreeAgents().RemovePlayer(player);

                AddTeamToGrid(league.GetDLeagueTeam(teamList.SelectedIndex), dataGridView2);

                dataGridView3.Rows.Clear();
                List<NewPlayer> players = league.GetFreeAgents().GetAllPlayers();
                players.Sort();
                foreach (NewPlayer p in players)
                {
                    dataGridView3.Rows.Add(new object[] { p.ToString(), p.GetAge(), p.GetPositionAsString(), p.GetBestOverall(), p.GetDevelopmentAsString(), dataGridView3.Columns[5].HeaderText, dataGridView3.Columns[6].HeaderText, p });
                }
            }
        }
    }
}
