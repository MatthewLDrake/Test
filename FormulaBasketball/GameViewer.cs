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
    public partial class GameViewer : Form
    {
        private game game;
        public GameViewer(team teamOne, team teamTwo, Random r, bool useDefault = true, int series = 1, int times = 1)
        {
            InitializeComponent();

            foreach(player p in teamOne)
            {
                p.SetSeasonStats(new List<StatsHolders>());
            }
            foreach(player p in teamTwo)
            {
                p.SetSeasonStats(new List<StatsHolders>());
            }

            
            if(useDefault)
            {
                if (series == 1 && times == 1)
                {
                    teamOne.setModifier(new HomeTeam());
                    teamTwo.setModifier(new None());
                    game = new game(null, teamOne, teamTwo, r);
                    teamOneLabel.Text = teamOne.ToString();
                    teamTwoLabel.Text = teamTwo.ToString();

                    int[] scores = game.getQuarterOneScore();
                    teamOneQ1Label.Text = "" + scores[0];
                    teamTwoQ1Label.Text = "" + scores[1];

                    scores = game.getQuarterTwoScore();
                    teamOneQ2Label.Text = "" + scores[0];
                    teamTwoQ2Label.Text = "" + scores[1];

                    scores = game.getQuarterThreeScore();
                    teamOneQ3Label.Text = "" + scores[0];
                    teamTwoQ3Label.Text = "" + scores[1];

                    scores = game.getQuarterFourScore();
                    teamOneQ4Label.Text = "" + scores[0];
                    teamTwoQ4Label.Text = "" + scores[1];

                    scores = game.getQuarterOTScore();
                    teamOneOTLabel.Text = "" + scores[0];
                    teamTwoOTLabel.Text = "" + scores[1];

                    teamOneTotalLabel.Text = "" + game.getAwayTeamScore();
                    teamTwoTotalLabel.Text = "" + game.getHomeTeamScore();

                    foreach (player p in teamOne)
                    {
                        p.resetGameStats(teamOne, teamTwo);
                        AddPlayerToGrid(p);
                    }
                    foreach (player p in teamTwo)
                    {
                        p.resetGameStats(teamTwo, teamOne);
                        AddPlayerToGrid(p);
                    }
                }
                else
                {
                    int homeTeamWins = 0, awayTeamWins = 0;
                    for (int i = 0; i < times; i++)
                    {
                        teamOne.Stamina();
                        teamTwo.Stamina();
                        if (series == 1)
                        {
                            
                            teamOne.setModifier(new HomeTeam());
                            teamTwo.setModifier(new None());
                            game = new game(null, teamOne, teamTwo, r);
                            if (game.getWinner())
                                homeTeamWins++;                            
                            else
                                awayTeamWins++;
                        }
                        else if (series == 3)
                        {
                            int lowerWins = 0, higherWins = 0;
                            teamTwo.setModifier(new HomeTeam());
                            teamOne.setModifier(new None());
                            game = new game(null, teamOne, teamTwo, r);
                            if (game.getWinner())
                                higherWins++;
                            else
                                lowerWins++;

                            teamTwo.setModifier(new None());
                            teamOne.setModifier(new HomeTeam());
                            game = new game(null, teamOne, teamTwo, r);

                            if (game.getWinner())
                                higherWins++;
                            else
                                lowerWins++;

                            if (higherWins == 2)
                                homeTeamWins++;
                            else if(lowerWins == 2)
                                awayTeamWins++;
                            else
                            {
                                teamOne.setModifier(new HomeTeam());
                                teamTwo.setModifier(new None());
                                game = new game(null, teamOne, teamTwo, r);
                                if (game.getWinner())
                                    homeTeamWins++;
                                else
                                    awayTeamWins++;
                            }

                        }
                        else if (series == 5)
                        {
                            int lowerWins = 0, higherWins = 0;
                            while (lowerWins != 3 && higherWins != 3)
                            {
                                if (lowerWins + higherWins < 3 || lowerWins + higherWins == 4)
                                {
                                    teamTwo.setModifier(new None());
                                    teamOne.setModifier(new HomeTeam());
                                    game = new game(null, teamOne, teamTwo, r);

                                    if (game.getWinner())
                                        higherWins++;
                                    else
                                        lowerWins++;
                                }
                                else
                                {
                                    teamTwo.setModifier(new HomeTeam());
                                    teamOne.setModifier(new None());
                                    game = new game(null, teamOne, teamTwo, r);
                                    if (game.getWinner())
                                        higherWins++;
                                    else
                                        lowerWins++;
                                }
                            }
                            if (higherWins == 3)
                                homeTeamWins++;
                            else if (lowerWins == 3)
                                awayTeamWins++;
                        }
                        else if (series == 7)
                        {
                            int lowerWins = 0, higherWins = 0;
                            while (lowerWins != 4 && higherWins != 4)
                            {
                                if (lowerWins + higherWins < 3 || lowerWins + higherWins > 5)
                                {
                                    teamTwo.setModifier(new None());
                                    teamOne.setModifier(new HomeTeam());
                                    
                                }
                                else
                                {
                                    teamTwo.setModifier(new HomeTeam());
                                    teamOne.setModifier(new None());
                                    
                                }
                                game = new game(null, teamOne, teamTwo, r);
                                if (game.getWinner())
                                    higherWins++;
                                else
                                    lowerWins++;
                                foreach(player p in teamOne)
                                {
                                    p.resetGame();
                                    p.resetGameStats(teamOne, teamTwo);
                                }
                                foreach (player p in teamTwo)
                                {
                                    p.resetGame();
                                    p.resetGameStats(teamTwo, teamOne);
                                }
                            }
                            if (higherWins == 4)
                                homeTeamWins++;
                            else if (lowerWins == 4)
                                awayTeamWins++;
                        }

                    }
                    MessageBox.Show(teamOne.ToString() + " wins " + homeTeamWins + "/" + times);
                }

                
            }
            else
            {
                NewGame game = new NewGame(new NewTeam(teamOne), new NewTeam(teamTwo), false);

                teamOneLabel.Text = teamOne.ToString();
                teamTwoLabel.Text = teamTwo.ToString();

                /*int[] scores = game.getQuarterOneScore();
                teamOneQ1Label.Text = "" + scores[0];
                teamTwoQ1Label.Text = "" + scores[1];

                scores = game.getQuarterTwoScore();
                teamOneQ2Label.Text = "" + scores[0];
                teamTwoQ2Label.Text = "" + scores[1];

                scores = game.getQuarterThreeScore();
                teamOneQ3Label.Text = "" + scores[0];
                teamTwoQ3Label.Text = "" + scores[1];

                scores = game.getQuarterFourScore();
                teamOneQ4Label.Text = "" + scores[0];
                teamTwoQ4Label.Text = "" + scores[1];

                scores = game.getQuarterOTScore();
                teamOneOTLabel.Text = "" + scores[0];
                teamTwoOTLabel.Text = "" + scores[1];

                teamOneTotalLabel.Text = "" + game.getAwayTeamScore();
                teamTwoTotalLabel.Text = "" + game.getHomeTeamScore();*/

                foreach (player p in teamOne)
                {
                    p.resetGameStats(teamOne, teamTwo);
                    AddPlayerToGrid(p);
                }
                foreach (player p in teamTwo)
                {
                    p.resetGameStats(teamTwo, teamOne);
                    AddPlayerToGrid(p);
                }


            }


        }

        public GameViewer(NewTeam homeTeam, NewTeam awayTeam, NewSimGame newSimGame)
        {
            InitializeComponent();

            teamOneLabel.Text = homeTeam.ToString();
            teamTwoLabel.Text = awayTeam.ToString();

            List<int> homeQuarters = newSimGame.GetHomeQuarterScores(), awayQuarters = newSimGame.GetAwayQuarterScores();

            int homeScore = 0, awayScore = 0;

            for (int i = 0; i < homeQuarters.Count; i++)
            {
                homeScore += homeQuarters[i];
                awayScore += awayQuarters[i];
            }

            teamOneQ1Label.Text = "" + homeQuarters[0];
            teamTwoQ1Label.Text = "" + awayQuarters[0];

            teamOneQ2Label.Text = "" + homeQuarters[1];
            teamTwoQ2Label.Text = "" + awayQuarters[1];

            teamOneQ3Label.Text = "" + homeQuarters[2];
            teamTwoQ3Label.Text = "" + awayQuarters[2];

            teamOneQ4Label.Text = "" + homeQuarters[3];
            teamTwoQ4Label.Text = "" + awayQuarters[3];

            teamOneOTLabel.Text = homeQuarters.Count > 4 ? "" + homeQuarters[4] : "";
            teamTwoOTLabel.Text = awayQuarters.Count > 4 ? "" + awayQuarters[4] : "";

            teamOneTotalLabel.Text = "" + homeScore;
            teamTwoTotalLabel.Text = "" + awayScore;

            foreach (NewPlayer p in awayTeam)
            {
                AddPlayerToGrid(p);
            }
            foreach (NewPlayer p in homeTeam)
            {
                AddPlayerToGrid(p);
            }



        }

        public GameViewer(game g)
        {
            InitializeComponent();
            this.game = g;
                teamOneLabel.Text = game.GetAwayTeam().ToString();
                teamTwoLabel.Text = game.GetHomeTeam().ToString();

                int[] scores = game.getQuarterOneScore();
                teamOneQ1Label.Text = "" + scores[0];
                teamTwoQ1Label.Text = "" + scores[1];

                scores = game.getQuarterTwoScore();
                teamOneQ2Label.Text = "" + scores[0];
                teamTwoQ2Label.Text = "" + scores[1];

                scores = game.getQuarterThreeScore();
                teamOneQ3Label.Text = "" + scores[0];
                teamTwoQ3Label.Text = "" + scores[1];

                scores = game.getQuarterFourScore();
                teamOneQ4Label.Text = "" + scores[0];
                teamTwoQ4Label.Text = "" + scores[1];

                scores = game.getQuarterOTScore();
                teamOneOTLabel.Text = "" + scores[0];
                teamTwoOTLabel.Text = "" + scores[1];

                teamOneTotalLabel.Text = "" + game.getAwayTeamScore();
                teamTwoTotalLabel.Text = "" + game.getHomeTeamScore();

                foreach (player p in game.GetAwayTeam())
                {
                    AddPlayerToGrid(p);
                }
                foreach (player p in game.GetHomeTeam())
                {
                    AddPlayerToGrid(p);
                }
            Show();
            }
        public void SaveForm(string location)
        {
            using (var bmp = new Bitmap(this.Width, this.Height))
            {
                this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(location);
            }
            Hide();
            
        }
        private void AddPlayerToGrid(NewPlayer p)
        {
            GameStats stats = p.GetStats();
            if (stats == null)
                return;
            double shootingPercentage = 0.0, opponentPercentage = 0.0;
            if (stats.GetFieldGoalsAttempted() != 0)
            {
                shootingPercentage = ((double)stats.GetFieldGoalsMade() / (double)stats.GetFieldGoalsAttempted()) * 100;
            }
            // TODO:
            double plus_minus = 0;

            if (stats.GetShotsAgainst() != 0)
                opponentPercentage = ((double)stats.GetShotsMadeAgainst() / (double)stats.GetShotsAgainst()) * 100;
            dataGridView1.Rows.Add(League.league.GetTeam(p.GetTeam()).ToString(), p.ToString(), p.GetPositionAsString(), stats.GetMinutes(), stats.GetAssists(), stats.GetPoints(), stats.GetFieldGoalsAttempted(), stats.GetFieldGoalsMade(), shootingPercentage, stats.GetThreePointsAttempted(), stats.GetThreePointsMade(), stats.GetFreeThrowsAttempted(), stats.GetFreeThrowsMade(),
            stats.GetTurnovers(), stats.GetSteals(), stats.GetRebounds(), stats.GetOffensiveRebounds(), stats.GetDefensiveRebounds(), stats.GetFouls(), stats.GetShotsAgainst(), stats.GetShotsMadeAgainst(), opponentPercentage, plus_minus);
        }
        private void AddPlayerToGrid(player p)
        {
            double shootingPercentage = 0.0, opponentPercentage = 0.0;
            if (p.getGameShotsTaken() != 0)
            {
                shootingPercentage = ((double)p.getGameShotsMade() / (double)p.getGameShotsTaken()) * 100;
            }
            double plus_minus = p.teamGamePoints;
            
            if (p.getGameShotsAttemptedAgainst() != 0)
                opponentPercentage = ((double)p.getGameShotsMadeAgainst() / (double)p.getGameShotsAttemptedAgainst()) * 100;
            dataGridView1.Rows.Add(p.getTeam().ToString(), p.getName(), p.getPosition(), p.getGameMinutes() , p.getGameAssists() , p.getGamePoints() , p.getGameShotsTaken() , p.getGameShotsMade() , shootingPercentage, p.getGameThreesTaken() , p.getGameThreePointersMade() , p.getGameFreeThrowsTaken(), p.getGameFreeThrowsMade(),
            p.getGameTurnovers() , p.getGameSteals() , p.getGameRebounds() , p.getGameOffensiveRebounds() , p.getGameDefensiveRebounds() , p.getGameFouls() , p.getGameShotsAttemptedAgainst() , p.getGameShotsMadeAgainst() , opponentPercentage, plus_minus);
        }
    }
}
