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
    public partial class GameResult : Form
    {
        private int quarterNum, minutesLeft;
        private List<int> awayScore, homeScore;
        private int currAwayScore, currHomeScore;
        private NewTeam awayTeam, homeTeam;
        public GameResult(NewTeam awayTeam, NewTeam homeTeam)
        {
            InitializeComponent();

            quarterNum = 1;
            minutesLeft = 12;
            awayScore = new List<int>();
            homeScore = new List<int>();

            this.awayTeam = awayTeam;
            this.homeTeam = homeTeam;

            currAwayScore = 0;
            currHomeScore = 0;

            label1.Text = "Away Team: " + awayTeam.ToString();
            label2.Text = "Home Team: " + homeTeam.ToString();

            //awayTeam.GetCoach().GetPlayerPhilosophy().StartGame(awayTeam);
            //homeTeam.GetCoach().GetPlayerPhilosophy().StartGame(homeTeam);

            foreach (NewPlayer player in awayTeam)
            {                
                player.StartGame(false, homeTeam.GetTeamNum());
            }
            foreach (NewPlayer player in homeTeam)
            {
                player.StartGame(false, awayTeam.GetTeamNum());
            }

            //awayStarters = Substitutions(awayTeam, awayStarters);//awayTeam.GetCoach().GetStartingFive(awayTeam);
            //homeStarters = Substitutions(homeTeam, homeStarters); //homeTeam.GetCoach().GetStartingFive(homeTeam);

            foreach (NewPlayer player in awayTeam)
            {
                player.StartGame(true, homeTeam.GetTeamNum());
                teamOneGrid.Rows.Add(new object[] { player.GetName(), 0, "0/0", "0/0", "0/0", 0, "0/0", 0,0,0, 0,"Add Stats", "Add Injury", player});
            }
            foreach (NewPlayer player in homeTeam)
            {
                player.StartGame(true, awayTeam.GetTeamNum());
                teamTwoGrid.Rows.Add(new object[] { player.GetName(), 0, "0/0", "0/0", "0/0", 0, "0/0", 0, 0, 0, 0, "Add Stats", "Add Injury", player });
            }
            label3.Text = awayTeam.ToString() + " has 60 minutes left. " + homeTeam + " has 60 minutes left";
        }
        private NewPlayer[] Substitutions(NewTeam team, NewPlayer[] current)
        {
            SubstitutionForm form = new SubstitutionForm(team, current);
            form.ShowDialog();
            return form.GetPlayers();
        }

        private void teamTwoGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NewPlayer p = teamTwoGrid.Rows[e.RowIndex].Cells[12].Value as NewPlayer;
            if (e.ColumnIndex == 9)
            {
                AddStatsForm form = new AddStatsForm(p);
                form.ShowDialog();
                teamTwoGrid.Rows[e.RowIndex].SetValues(form.GetValues());
            }
            else if (e.ColumnIndex == 10)
            {
                AddInjuryForm form = new AddInjuryForm(homeTeam);
                form.ShowDialog();
            }
        }

        private int AddPlayer(NewPlayer player, NewPlayer otherPlayer, DataGridView teamOneGrid, int i)
        {
            int score = 0;

            string temp = teamOneGrid.Rows[i].Cells[2].Value as string;

            string[] twos = temp.Split('/');

            int first = int.Parse(twos[0]);
            int second = int.Parse(twos[1]);

            for (int j = 0; j < second; j++)
            {
                player.AddTwoPointer(j < first);
                otherPlayer.AddTwoPointerAgainst(j < first);

                if (j < first)
                    score += 2;
            }
            temp = teamOneGrid.Rows[i].Cells[3].Value as string;

            twos = temp.Split('/');

            first = int.Parse(twos[0]);
            second = int.Parse(twos[1]);

            for (int j = 0; j < second; j++)
            {
                player.AddThreePointer(j < first);
                otherPlayer.AddThreePointerAgainst(j < first);

                if (j < first)
                    score += 3;
            }
            temp = teamOneGrid.Rows[i].Cells[4].Value as string;

            twos = temp.Split('/');

            first = int.Parse(twos[0]);
            second = int.Parse(twos[1]);

            player.AddFreeThrows(second, first);
            score += first;

            int amount;

            if (teamOneGrid.Rows[i].Cells[5].Value is string)
                amount = int.Parse((teamOneGrid.Rows[i].Cells[5].Value) as string);
            else
                amount = (int)teamOneGrid.Rows[i].Cells[5].Value;


            for (int j = 0; j < amount; j++)
                player.AddAssist();

            temp = teamOneGrid.Rows[i].Cells[6].Value as string;

            twos = temp.Split('/');

            first = int.Parse(twos[0]);
            second = int.Parse(twos[1]);

            for (int j = 0; j < first; j++)
                player.AddRebounds(true);
            for (int j = 0; j < second; j++)
                player.AddRebounds(false);

            if (teamOneGrid.Rows[i].Cells[7].Value is string)
                amount = int.Parse((teamOneGrid.Rows[i].Cells[7].Value) as string);
            else
                amount = (int)teamOneGrid.Rows[i].Cells[77].Value;

            for (int j = 0; j < amount; j++)
                player.AddAssist();

            if (teamOneGrid.Rows[i].Cells[7].Value is string)
                amount = int.Parse((teamOneGrid.Rows[i].Cells[8].Value) as string);
            else
                amount = (int)teamOneGrid.Rows[i].Cells[8].Value;

            for (int j = 0; j < amount; j++)
                player.AddSteal();

            if (teamOneGrid.Rows[i].Cells[9].Value is string)
                amount = int.Parse((teamOneGrid.Rows[i].Cells[9].Value) as string);
            else
                amount = (int)teamOneGrid.Rows[i].Cells[9].Value;

            for (int j = 0; j < amount; j++)
                player.AddBlock();

            if (teamOneGrid.Rows[i].Cells[10].Value is string)
                amount = int.Parse((teamOneGrid.Rows[i].Cells[10].Value) as string);
            else
                amount = (int)teamOneGrid.Rows[i].Cells[10].Value;

            for (int j = 0; j < amount; j++)
                player.AddFouls(1, quarterNum);

            if (teamOneGrid.Rows[i].Cells[1].Value is string)
                amount = int.Parse((teamOneGrid.Rows[i].Cells[1].Value) as string);
            else
                amount = (int)teamOneGrid.Rows[i].Cells[1].Value;

            player.GetGameStats().AddMinutes(amount);

            return score;
        }

        private void advanceTime_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 5; i++)
            {
                NewPlayer player = teamOneGrid.Rows[i].Cells[13].Value as NewPlayer;
                NewPlayer otherPlayer = teamTwoGrid.Rows[i].Cells[13].Value as NewPlayer;

                currAwayScore += AddPlayer(player, otherPlayer, teamOneGrid, i);
                currHomeScore += AddPlayer(otherPlayer, player, teamTwoGrid, i);                
            }

            int totalHomeScore = 0, totalAwayScore = 0;
            
                quarterNum++;
                homeScore.Add(currHomeScore);
                awayScore.Add(currAwayScore);
                for (int i = 0; i < homeScore.Count; i++)
                {
                    totalHomeScore += homeScore[i];
                    totalAwayScore += awayScore[i];
                }
                if (quarterNum > 4)
                {
                    if (totalAwayScore != totalHomeScore)
                    {
                        Close();
                    }
                    else
                        minutesLeft = 5;
                }
                else
                    minutesLeft = 12;                
            

            teamOneGrid.Rows.Clear();
            teamTwoGrid.Rows.Clear();

            foreach (NewPlayer player in awayTeam)
            {
                teamOneGrid.Rows.Add(new object[] { player.GetName(), 0, "0/0", "0/0", "0/0", 0, "0/0", 0, 0, 0, 0, "Add Stats", "Add Injury", player });
            }
            foreach (NewPlayer player in homeTeam)
            {
                teamTwoGrid.Rows.Add(new object[] { player.GetName(), 0, "0/0", "0/0", "0/0", 0, "0/0", 0, 0, 0, 0, "Add Stats", "Add Injury", player });
            }
            totalHomeScore = 0;
            totalAwayScore = 0;
            for (int i = 0; i < homeScore.Count; i++)
            {
                totalHomeScore += homeScore[i];
                totalAwayScore += awayScore[i];
            }
        }

        private void teamOneGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NewPlayer p = teamOneGrid.Rows[e.RowIndex].Cells[13].Value as NewPlayer;
            if (e.ColumnIndex == 11)
            {
                AddStatsForm form = new AddStatsForm(p);
                form.ShowDialog();
                teamOneGrid.Rows[e.RowIndex].SetValues(form.GetValues());
            }
            else if (e.ColumnIndex == 12)
            {
                AddInjuryForm form = new AddInjuryForm(awayTeam);
                form.ShowDialog();
            }
        }
        public List<int> GetAwayScores()
        {
            return awayScore;
        }
        public List<int> GetHomeScores()
        {
            return homeScore;
        }
    }

}
