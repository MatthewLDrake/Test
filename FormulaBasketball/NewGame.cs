using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class NewGame
    {
        private NewCurrentTeam awayTeam, homeTeam;
        private List<byte[]> scores;
        private byte[] currentQuarterScore;
        private int timeLeft;
        private bool awayTipOff, playoffs;
        public NewGame(NewTeam awayTeam, NewTeam homeTeam, bool playoffs)
        {
            this.playoffs = playoffs;

            this.awayTeam = new NewCurrentTeam(awayTeam, true, homeTeam.GetTeamNum());
            this.homeTeam = new NewCurrentTeam(homeTeam, false, awayTeam.GetTeamNum());
            scores = new List<byte[]>();

            TestGame();

            //StartGame();
        }
        public byte[] GetQuarterScore(int quarterNum)
        {
            if(quarterNum < 4)            
                return scores[quarterNum];
            else
            {
                byte[] otScores = new byte[2];
                for(int i = 4; i < scores.Count; i++)
                {
                    otScores[0] += scores[i][0];
                    otScores[1] += scores[i][1];
                }
                return otScores;
            }
        }
        public NewTeam GetAwayTeam()
        {
            return awayTeam.GetTeam();
        }
        public NewTeam GetHomeTeam()
        {
            return homeTeam.GetTeam();
        }
        public void TestGame()
        {
            awayTeam.GetStartingFive();
            homeTeam.GetStartingFive();

            PlayTestQuarter(playoffs, 1, 720);
            PlayTestQuarter(playoffs, 2, 720);
            PlayTestQuarter(playoffs, 3, 720);
            PlayTestQuarter(true, 4, 720);

            while (GetAwayTeamScore() == GetHomeTeamScore())
            {
                PlayTestQuarter(true, 5, 300);
            }

            int awayTeamScore = GetAwayTeamScore(), homeTeamScore = GetHomeTeamScore();

            awayTeam.GetTeam().FinishGame(awayTeamScore, homeTeamScore, homeTeam.GetTeam().GetTeamNum(), playoffs);
            homeTeam.GetTeam().FinishGame(homeTeamScore, awayTeamScore, awayTeam.GetTeam().GetTeamNum(), playoffs);
        }
        private void PlayTestQuarter(bool clutch, int quarter, int seconds)
        {
            int numberOfPlays = (awayTeam.GetCoach().GetOffensivePhilosophy().GetNumberOfPlays(seconds) + homeTeam.GetCoach().GetOffensivePhilosophy().GetNumberOfPlays(seconds)) / 2;

            PlayStats awayStats = awayTeam.GetCoach().GetOffensivePhilosophy().GetStats(numberOfPlays, awayTeam, homeTeam, quarter, clutch);
            PlayStats homeStats = homeTeam.GetCoach().GetOffensivePhilosophy().GetStats(numberOfPlays, homeTeam, awayTeam, quarter, clutch);

            byte awayScore = DistributeStats(awayStats, awayTeam, homeTeam, quarter, clutch);
            byte homeScore = DistributeStats(homeStats, homeTeam, awayTeam, quarter, clutch);

            scores.Add(new byte[] { awayScore, homeScore });

            awayTeam.DoSubstitutions(quarter);
            homeTeam.DoSubstitutions(quarter);
        }
        private byte DistributeStats(PlayStats stats, NewCurrentTeam offense, NewCurrentTeam defense, int quarter, bool clutch)
        {
            double[] usage = new double[] { stats.defensiveUsage.Item1[0], stats.defensiveUsage.Item1[1], stats.defensiveUsage.Item1[2], stats.defensiveUsage.Item1[3], stats.defensiveUsage.Item1[4] };
            double[] ratings = new double[] { defense.GetCurrentPlayers()[0].GetDefenseIQRating(true, clutch), defense.GetCurrentPlayers()[1].GetDefenseIQRating(true, clutch), defense.GetCurrentPlayers()[2].GetDefenseIQRating(true, clutch), defense.GetCurrentPlayers()[3].GetDefenseIQRating(true, clutch), defense.GetCurrentPlayers()[4].GetDefenseIQRating(true, clutch) };

            double[] updatedUsage = new double[5];

            double ratingSum = 0;
            for (int i = 0; i < ratings.Length; i++)
            {
                //ratings[i] = 120 - ratings[i];
                ratingSum += ratings[i];
            }
            for (int i = 0; i < updatedUsage.Length; i++)
            {
                updatedUsage[i] = (usage[i] * 1.5 + (ratings[i] * 8.5) / ratingSum) / 10.0;
            }

            for (int i = 0; i < stats.steals; i++)
            {
                double num = League.r.NextDouble();
                double curr = 0.0;
                for (int j = 0; j < defense.GetCurrentPlayers().Length; j++)
                {
                    if(curr + updatedUsage[i] > num)
                    {
                        defense.GetCurrentPlayers()[j].AddSteal();
                        break;
                    }
                    curr += updatedUsage[i];
                }
            }
            int fouls = stats.fouls;

            ratingSum = 0;
            for (int i = 0; i < ratings.Length; i++)
            {
                ratings[i] = Math.Max(0, 120 - ratings[i]);
                ratingSum += ratings[i];
            }
            for (int i = 0; i < updatedUsage.Length; i++)
            {
                updatedUsage[i] = (usage[i] * 1.5 + (ratings[i] * 8.5) / ratingSum) / 10.0;
            }


            while (fouls > 0)
            {
                double num = League.r.NextDouble();
                double curr = 0.0;
                for (int j = 0; j < defense.GetCurrentPlayers().Length; j++)
                {
                    int currFouls = League.r.Next(1, 10);

                    if (currFouls < 5)
                        currFouls = 1;
                    else if (currFouls < 8)
                        currFouls = 2;
                    else
                        currFouls = 3;

                    if (currFouls > fouls)
                        currFouls = fouls;

                    if (curr + updatedUsage[j] > num)
                    {
                        currFouls = defense.GetCurrentPlayers()[j].AddFouls(currFouls, quarter);
                        fouls -= currFouls;
                        break;
                    }
                    curr += updatedUsage[j];


                }
            }

            ratings = new double[] { offense.GetCurrentPlayers()[0].GetOffenseIQRating(true, clutch), offense.GetCurrentPlayers()[1].GetOffenseIQRating(true, clutch), offense.GetCurrentPlayers()[2].GetOffenseIQRating(true, clutch), offense.GetCurrentPlayers()[3].GetOffenseIQRating(true, clutch), offense.GetCurrentPlayers()[4].GetOffenseIQRating(true, clutch) };
            ratingSum = 0;
            for (int i = 0; i < ratings.Length; i++)
            {
                ratings[i] = Math.Max(0, 120 - ratings[i]);
                ratingSum += ratings[i];
            }
            for (int i = 0; i < updatedUsage.Length; i++)
            {
                updatedUsage[i] = (usage[i] * 1.5 + (ratings[i] * 8.5) / ratingSum) / 10.0;
            }
            for (int i = 0; i < stats.steals + stats.nonStealTurnovers; i++)
            {
                double num = League.r.NextDouble();
                double curr = 0.0;
                for (int j = 0; j < offense.GetCurrentPlayers().Length; j++)
                {
                    if (curr + updatedUsage[j] > num)
                    {
                        offense.GetCurrentPlayers()[j].AddTurnover();
                        break;
                    }
                    curr += updatedUsage[j];
                }
            }


            return DistributeShots(stats, offense, defense, clutch);
        }
        private byte DistributeShots(PlayStats stats, NewCurrentTeam offense, NewCurrentTeam defense, bool clutch)
        {
            byte scores = 0;
            int freeThrows = stats.freeThrowsAttempted;

            while (freeThrows > 0)
            {
                double num = League.r.NextDouble();
                double curr = 0.0;
                for (int j = 0; j < offense.GetCurrentPlayers().Length; j++)
                {
                    int currFrees = League.r.Next(1, 10);

                    if (currFrees < 3)
                        currFrees = 1;
                    else if (currFrees < 8)
                        currFrees = 2;
                    else
                        currFrees = 3;

                    if (currFrees > freeThrows)
                        currFrees = freeThrows;

                    if (curr + stats.offensiveUsage[j] > num)
                    {
                        ShotResult result = NewShots.TakeFreeThrow(currFrees, clutch, offense.GetCurrentPlayers()[j]);
                        byte made;
                        switch(result.Type)
                        {
                            case ResultType.MAKE_ONE_FREETHROW:
                                made = 1;
                                break;
                            case ResultType.MAKE_TWO_FREETHROW:
                                made = 2;
                                break;
                            case ResultType.MAKE_THREE_FREETHROW:
                                made = 3;
                                break;
                            default:
                                made = 0;
                                break;
                        }
                        offense.GetCurrentPlayers()[j].AddFreeThrows(currFrees, made);
                        scores += made;
                        freeThrows -= currFrees;
                        break;
                    }
                    curr += stats.offensiveUsage[j];


                }
            }

            scores += offense.GetCoach().PreviousPhilosophy().DistributeShots(stats, offense, defense, clutch);

            return scores;
        }
        public int GetAwayTeamScore()
        {
            int totalScore = 0;
            foreach (byte[] arr in scores)
            {
                totalScore += arr[0];
            }
            return totalScore;
        }
        public int GetHomeTeamScore()
        {
            int totalScore = 0;
            foreach (byte[] arr in scores)
            {
                totalScore += arr[1];
            }
            return totalScore;
        }
        private void StartGame()
        {
            awayTeam.GetStartingFive();
            homeTeam.GetStartingFive();

            awayTipOff = TipOff();
            // 60 * 12
            timeLeft = 720;
            scores.Add(PlayQuarter(awayTipOff, 1));
            timeLeft = 720;
            scores.Add(PlayQuarter(!awayTipOff, 2));
            timeLeft = 720;
            scores.Add(PlayQuarter(!awayTipOff, 3));
            timeLeft = 720;
            scores.Add(PlayQuarter(awayTipOff, 4));

            while (GetAwayTeamScore() == GetHomeTeamScore())
            {
                timeLeft = 300;
                scores.Add(PlayQuarter(TipOff(), 5));
            }

            int awayTeamScore = GetAwayTeamScore(), homeTeamScore = GetHomeTeamScore();

            awayTeam.GetTeam().FinishGame(awayTeamScore, homeTeamScore, homeTeam.GetTeam().GetTeamNum(), playoffs);
            homeTeam.GetTeam().FinishGame(homeTeamScore, awayTeamScore, awayTeam.GetTeam().GetTeamNum(), playoffs);

            /*string teamOne = awayTeam.GetTeam().ToString() + " | " + GetAwayTeamScore();
            string teamTwo = homeTeam.GetTeam().ToString() + " | " + GetHomeTeamScore();
            

            foreach(byte[] score in scores)
            {
                teamOne += " | " + score[0];
                teamTwo += " | " + score[1];
            }
            Console.WriteLine(teamOne + "\n" + teamTwo);
            */
        }
        
        private byte[] PlayQuarter(bool awayStarts, int quarterNum)
        {
            currentQuarterScore = new byte[2];

            bool awayTeamHasBall = awayStarts;
            NewPlayer starter = null;
            while(timeLeft > 0)
            {
                int awayScoreDiff = GetAwayTeamScore() - GetHomeTeamScore() + currentQuarterScore[0] - currentQuarterScore[1];

                PlayResult result;
                if (awayTeamHasBall)
                    result = awayTeam.RunPlay(homeTeam, awayScoreDiff, quarterNum, timeLeft, starter);
                else
                    result = homeTeam.RunPlay(awayTeam, -awayScoreDiff, quarterNum, timeLeft, starter);

                timeLeft -= result.timeElapsed;
                currentQuarterScore[0] += result.awayPoints;
                currentQuarterScore[1] += result.homePoints;
                starter = result.nextStarter;

                awayTeamHasBall = !awayTeamHasBall;
            }

            return currentQuarterScore;
        }
        private bool TipOff()
        {
            double temp = 0;// awayTeam.GetCurrentPlayers()[0].getJumpingRating() - homeTeam.GetCurrentPlayers()[0].getJumpingRating();

            double temp2 = League.r.Next(0, 10) + temp;

            return temp2 > 5;
        }
    }
    public class NewCurrentTeam
    {
        private NewPlayer[] currentPlayers;
        private NewCoach coach;
        private NewTeam team;
        private bool awayTeam;
        private int opponent;
        public NewCurrentTeam(NewTeam team, bool awayTeam, int opponent)
        {
            this.team = team;
            //coach = team.GetCoach();

            coach.GetPlayerPhilosophy().StartGame(team);

            this.awayTeam = awayTeam;
            this.opponent = opponent;
        }
        public NewTeam GetTeam()
        {
            return team;
        }
        public NewPlayer[] GetCurrentPlayers()
        {
            return currentPlayers;
        }
        public NewCoach GetCoach()
        {
            return coach;
        }
        public bool IsAwayTeam()
        {
            return awayTeam;
        }
        public void DoSubstitutions(int quarter)
        {
            currentPlayers = coach.GetPlayerPhilosophy().DoSubstitutions(team, quarter);
        }
        public void GetStartingFive()
        {
            currentPlayers = coach.GetStartingFive(team);
            foreach (NewPlayer p in currentPlayers)
                p.StartGame(true, opponent);

            foreach(NewPlayer p in team)            
                p.StartGame(false, opponent);
            

            /*Console.WriteLine(team.ToString());

            for(int i = 0; i < currentPlayers.Length; i++)
            {
                currentPlayers[i].AddStart();
                Console.WriteLine('\t' + currentPlayers[i].ToString());
            }*/
        }
        public void EndGame()
        {
            foreach(NewPlayer p in team)
            {
                p.EndGame();
            }
        }
        public PlayResult RunPlay(NewCurrentTeam opponent, int scoreDiff, int quarterNum, int timeLeft, NewPlayer starter)
        {
            /*int timeElapsed = 0;
            byte awayPoints = 0, homePoints = 0;
            NewPlayer nextStarter = null;
            // Late game situations
            if (quarterNum >= 4 && timeLeft < 120)
            {
                // Down by a few
                if(scoreDiff > -6 && scoreDiff < 0)
                {
                    PlayResult result = coach.DoMoreRiskyPlay(this, opponent);

                    awayPoints += result.awayPoints;
                    homePoints += result.homePoints;
                    nextStarter = result.nextStarter;

                    timeElapsed += Math.Min(timeLeft, League.r.Next(5, 12));
                }
                // Down by a lot
                else if(scoreDiff <= -6)
                {
                    byte points = coach.TakeShot(this, opponent, 2, ref nextStarter);
                    
                    awayPoints += (byte)(awayTeam ? points : 0);
                    homePoints += (byte)(awayTeam ? 0 : points);
                    
                    timeElapsed += Math.Min(timeLeft, League.r.Next(5, 12));
                }
                // Up by a little
                else if(scoreDiff >= 0 && scoreDiff <= 5)
                {
                    if(timeLeft < 30)
                    {
                        // inbound play to one of the better free throw shooters, other team
                        // tries to intentional foul
                        return coach.InboundPlay(this, opponent);
                    }
                    PlayResult result = coach.DoNormalPlay(this, opponent);

                    awayPoints += result.awayPoints;
                    homePoints += result.homePoints;

                    timeElapsed += Math.Min(timeLeft, League.r.Next(20, 24));
                }
                // Up by a lot
                else
                {
                    if (timeLeft < 24)
                        return new PlayResult(0, 0, timeLeft, nextStarter);

                    PlayResult result = coach.DoLessRiskyPlay(this, opponent);

                    awayPoints += result.awayPoints;
                    homePoints += result.homePoints;

                    timeElapsed += League.r.Next(20, 24);
                }
            }
            // Trying to catch up, take more risks, be a little faster
            else if(quarterNum >= 3 && scoreDiff < 0)
            {
                return coach.DoMoreRiskyPlay(this, opponent);
            }
            // Slow down the game, take less risks, be a little slower
            else if(quarterNum >= 3 && scoreDiff > 0)
            {
                return coach.DoLessRiskyPlay(this, opponent);
            }
            // Just play the game normally
            else*/
            {
                return null;
                //return coach.DoNormalPlay(this, opponent);
            }
            //return new PlayResult(awayPoints, homePoints, timeElapsed, nextStarter);
        }
        // TODO: Real simulation
        /*public PlayResult RunPlay(NewCurrentTeam opponent, int scoreDiff, int quarterNum, int timeLeft)
        {
            OffensivePlay offensivePlay = coach.GetOffensivePlay(scoreDiff, quarterNum, timeLeft);
            DefensivePlay defensivePlay = opponent.coach.GetDefensivePlay(-scoreDiff, quarterNum, timeLeft);
            PlayExecutor play = null;
            switch(defensivePlay)
            {
                case DefensivePlay.MAN_SWITCH:
                    play = new ManPlayExecutor(1);
                    break;
                case DefensivePlay.MAN_NO_SWITCH:
                    play = new ManPlayExecutor(0);
                    break;
                case DefensivePlay.MAN_DOUBLE_BALL:
                    play = new ManPlayExecutor(2);
                    break;
            }

            if (play != null)
                return play.RunPlay(offensivePlay, this, opponent);

            return null;
        }*/
    }
    public class PlayResult
    {
        public byte awayPoints, homePoints;
        public int timeElapsed;
        public NewPlayer nextStarter;
        public PlayResult(byte awayPoints, byte homePoints, int timeElapsed, NewPlayer nextStarter)
        {
            this.awayPoints = awayPoints;
            this.homePoints = homePoints;
            this.timeElapsed = timeElapsed;
            this.nextStarter = nextStarter;
        }
    }
    public class PlayExecutor
    {
        public virtual PlayResult RunPlay(OffensivePlay offensivePlay, NewCurrentTeam offense, NewCurrentTeam defense)
        {
            return null;
        }
    }
}