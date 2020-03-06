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
                NewGame game = new NewGame(teamOne, teamTwo, r);

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
            dataGridView1.Rows.Add(p.getTeam().ToString(), p.getName(), p.getPosition(), p.getMinutes() , p.getAssists() , p.getPoints() , p.getShotsTaken() , p.getShotsMade() , shootingPercentage, p.getThreesTaken() , p.getThreePointersMade() ,
            p.getTurnovers() , p.getSteals() , p.getRebounds() , p.getOffensiveRebounds() , p.getDefensiveRebounds() , p.getFouls() , p.getShotsAttemptedAgainst() , p.getShotsMadeAgainst() , opponentPercentage, plus_minus);
        }
    }
}
