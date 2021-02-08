using System;
using System.Collections.Generic;

namespace FormulaBasketball
{
    [Serializable]
    public class NewPlayoffs
    {
        private bool doEntirePlayoffs, dleague, done;
        private List<Tuple<int, NewTeam>> nextSouthRoundWinners, nextSouthRoundLosers, nextNorthRoundWinners, nextNorthRoundLosers;
        private SecondRound winnersSecondRound, losersSecondRound;
        private int startingPosition, round;
        private League league;
        public NewPlayoffs(List<Tuple<int, NewTeam>> SouthernPlayoffTeams, List<Tuple<int, NewTeam>> NorthernPlayoffTeams, int startingPosition, bool DoEntirePlayoffs = true, bool dleague = false, League league = null)
        {
            league = league;
            doEntirePlayoffs = DoEntirePlayoffs;
            this.startingPosition = startingPosition;
            this.dleague = dleague;
            nextSouthRoundWinners = SouthernPlayoffTeams;
            nextNorthRoundWinners = NorthernPlayoffTeams;
            done = false;
            if (doEntirePlayoffs)
            {
                DoFirstRound(SouthernPlayoffTeams, NorthernPlayoffTeams);
                DoSecondRound();
            }
        }
        public void DoNextRound()
        {
            if(done)
            {
                if(winnersSecondRound == null)
                {
                    DoSecondRound();
                    winnersSecondRound.DoRound();
                    losersSecondRound.DoRound();
                }
                else
                {
                    if(winnersSecondRound.GetWinnersThird() == null)
                    {
                        winnersSecondRound.DoThirdRound();
                        winnersSecondRound.GetWinnersThird().DoRound();
                        winnersSecondRound.GetLosersThird().DoRound();
                        losersSecondRound.GetWinnersThird().DoRound();
                        losersSecondRound.GetLosersThird().DoRound();
                    }
                    else
                    {
                        winnersSecondRound.GetWinnersThird().DoFinals();
                        winnersSecondRound.GetLosersThird().DoFinals();
                        losersSecondRound.GetWinnersThird().DoFinals();
                        losersSecondRound.GetLosersThird().DoFinals();
                    }
                }
            }
            else
            {
                DoFirstRound(nextSouthRoundWinners, nextNorthRoundWinners);
            }
        }
        public void DoFirstRound(List<Tuple<int, NewTeam>> SouthernPlayoffTeams, List<Tuple<int, NewTeam>> NorthernPlayoffTeams)
        {
            nextSouthRoundWinners = new List<Tuple<int, NewTeam>>();
            nextSouthRoundLosers = new List<Tuple<int, NewTeam>>();
            nextNorthRoundWinners = new List<Tuple<int, NewTeam>>();
            nextNorthRoundLosers = new List<Tuple<int, NewTeam>>(); 

            Tuple <Tuple < int, NewTeam >, Tuple < int, NewTeam>> result = DoBracket(SouthernPlayoffTeams[0], SouthernPlayoffTeams[7], dleague, 1);

            nextSouthRoundWinners.Add(result.Item1);
            nextSouthRoundLosers.Add(result.Item2);

            result = DoBracket(SouthernPlayoffTeams[3], SouthernPlayoffTeams[4], dleague, 1);

            nextSouthRoundWinners.Add(result.Item1);
            nextSouthRoundLosers.Add(result.Item2);

            result = DoBracket(SouthernPlayoffTeams[2], SouthernPlayoffTeams[5], dleague, 1);

            nextSouthRoundWinners.Add(result.Item1);
            nextSouthRoundLosers.Add(result.Item2);

            result = DoBracket(SouthernPlayoffTeams[1], SouthernPlayoffTeams[6], dleague, 1);

            nextSouthRoundWinners.Add(result.Item1);
            nextSouthRoundLosers.Add(result.Item2);

            result = DoBracket(NorthernPlayoffTeams[0], NorthernPlayoffTeams[7], dleague, 1);

            nextNorthRoundWinners.Add(result.Item1);
            nextNorthRoundLosers.Add(result.Item2);

            result = DoBracket(NorthernPlayoffTeams[3], NorthernPlayoffTeams[4], dleague, 1);

            nextNorthRoundWinners.Add(result.Item1);
            nextNorthRoundLosers.Add(result.Item2);

            result = DoBracket(NorthernPlayoffTeams[2], NorthernPlayoffTeams[5], dleague, 1);

            nextNorthRoundWinners.Add(result.Item1);
            nextNorthRoundLosers.Add(result.Item2);

            result = DoBracket(NorthernPlayoffTeams[1], NorthernPlayoffTeams[6], dleague, 1);

            nextNorthRoundWinners.Add(result.Item1);
            nextNorthRoundLosers.Add(result.Item2);

            done = true;
        }
        public void DoSecondRound()
        {
            winnersSecondRound = new SecondRound(nextSouthRoundWinners, nextNorthRoundWinners, startingPosition, doEntirePlayoffs, dleague);
            losersSecondRound = new SecondRound(nextSouthRoundLosers, nextNorthRoundLosers, startingPosition + 8, doEntirePlayoffs, dleague);
        }
        public static Tuple<Tuple<int, NewTeam>, Tuple<int, NewTeam>> DoBracket(Tuple<int, NewTeam> teamOne, Tuple<int, NewTeam> teamTwo, bool dleague, int round)
        {
            bool teamOneHigherSeed = teamOne.Item1 < teamTwo.Item1;

            NewTeam higherSeed = teamOneHigherSeed ? teamOne.Item2 : teamTwo.Item2;
            NewTeam lowerSeed = !teamOneHigherSeed ? teamOne.Item2 : teamTwo.Item2;

            int higherSeedWins = 0, lowerSeedWins = 0;

            
            if (PlayGame(lowerSeed, higherSeed, round, 1))
                lowerSeedWins++;
            else
                higherSeedWins++;

            if (PlayGame(lowerSeed, higherSeed, round, 2))
                lowerSeedWins++;
            else
                higherSeedWins++;

            if (PlayGame(higherSeed, lowerSeed, round, 3))
                higherSeedWins++;
            else
                lowerSeedWins++;

            if (PlayGame(higherSeed, lowerSeed, round, 4))
                higherSeedWins++;
            else
                lowerSeedWins++;

            while(higherSeedWins != 4 && lowerSeedWins != 4)
            {
                if(higherSeedWins + lowerSeedWins == 4)
                    if (PlayGame(higherSeed, lowerSeed, round, higherSeedWins + lowerSeedWins + 1))
                        higherSeedWins++;
                    else
                        lowerSeedWins++;
                else
                    if (PlayGame(lowerSeed, higherSeed, round, higherSeedWins + lowerSeedWins + 1))
                    lowerSeedWins++;
                else
                    higherSeedWins++;
            }

            return (higherSeedWins == 4  && teamOneHigherSeed) || (lowerSeedWins == 4 && !teamOneHigherSeed) ? new Tuple<Tuple<int, NewTeam>, Tuple<int, NewTeam>>(teamOne, teamTwo) : new Tuple<Tuple<int, NewTeam>, Tuple<int, NewTeam>>(teamTwo, teamOne);
        }

        private static bool PlayGame(NewTeam AwayTeam, NewTeam HomeTeam, int round, int gameNum)
        {
            ScoreCheater cheater = new ScoreCheater(AwayTeam, HomeTeam);
            cheater.ShowDialog();
            League.AddPlayoffScore(cheater, AwayTeam.GetTeamNum(), HomeTeam.GetTeamNum(),new Tuple<int, int> (round, gameNum));
            int awayScore = 0, homeScore = 0;
            foreach(int i in cheater.GetAwayScores())
            {
                awayScore += i;
            }
            foreach (int i in cheater.GetHomeScores())
            {
                homeScore += i;
            }

            return awayScore > homeScore;
        }
    }
    [Serializable]
    class SecondRound
    {
        private List<Tuple<int, NewTeam>> nextSouthRoundWinners, nextSouthRoundLosers, nextNorthRoundWinners, nextNorthRoundLosers;
        private ThirdRound winnersThirdRound, losersThirdRound;
        private bool continuePlayoffs, dleague, done;
        private int startingPosition;
        public SecondRound(List<Tuple<int, NewTeam>> SouthernPlayoffTeams, List<Tuple<int, NewTeam>> NorthernPlayoffTeams, int startingPosition, bool continuePlayoffs, bool dleague)
        {
            this.dleague = dleague;
            this.continuePlayoffs = continuePlayoffs;
            this.startingPosition = startingPosition;
            nextSouthRoundWinners = SouthernPlayoffTeams;
            nextNorthRoundWinners = NorthernPlayoffTeams;
            done = false;
            if(continuePlayoffs)
            {
                DoSecondRound(SouthernPlayoffTeams, NorthernPlayoffTeams);
                DoThirdRound();
            }
        }
        public ThirdRound GetWinnersThird()
        {
            return winnersThirdRound;
        }
        public ThirdRound GetLosersThird()
        {
            return losersThirdRound;
        }
        public void DoRound()
        {
            DoSecondRound(nextSouthRoundWinners, nextNorthRoundWinners);
        }
        public bool GetDone()
        {
            return done;
        }
        public void DoSecondRound(List<Tuple<int, NewTeam>> SouthernPlayoffTeams, List<Tuple<int, NewTeam>> NorthernPlayoffTeams)
        {
            nextSouthRoundWinners = new List<Tuple<int, NewTeam>>();
            nextSouthRoundLosers = new List<Tuple<int, NewTeam>>();
            nextNorthRoundWinners = new List<Tuple<int, NewTeam>>();
            nextNorthRoundLosers = new List<Tuple<int, NewTeam>>();

            Tuple<Tuple<int, NewTeam>, Tuple<int, NewTeam>> result = NewPlayoffs.DoBracket(SouthernPlayoffTeams[0], SouthernPlayoffTeams[1], dleague, 2);

            nextSouthRoundWinners.Add(result.Item1);
            nextSouthRoundLosers.Add(result.Item2);

            result = NewPlayoffs.DoBracket(SouthernPlayoffTeams[2], SouthernPlayoffTeams[3], dleague, 2);

            nextSouthRoundWinners.Add(result.Item1);
            nextSouthRoundLosers.Add(result.Item2);

            result = NewPlayoffs.DoBracket(NorthernPlayoffTeams[0], NorthernPlayoffTeams[1], dleague, 2);

            nextNorthRoundWinners.Add(result.Item1);
            nextNorthRoundLosers.Add(result.Item2);

            result = NewPlayoffs.DoBracket(NorthernPlayoffTeams[2], NorthernPlayoffTeams[3], dleague, 2);

            nextNorthRoundWinners.Add(result.Item1);
            nextNorthRoundLosers.Add(result.Item2);

            done = true;
        }
        public void DoThirdRound()
        {
            winnersThirdRound = new ThirdRound(nextSouthRoundWinners, nextNorthRoundWinners, startingPosition, continuePlayoffs, dleague);
            losersThirdRound = new ThirdRound(nextSouthRoundLosers, nextNorthRoundLosers, startingPosition + 4, continuePlayoffs, dleague);
        }
    }
    [Serializable]
    class ThirdRound
    {
        private Tuple<int, NewTeam> southWinner, southLoser, northWinner, northLoser;
        private List<Tuple<int, NewTeam>> SouthernPlayoffTeams, NorthernPlayoffTeams;
        private List<NewTeam> ranks;
        private int startingPosition;
        private bool dleague, done;
        public ThirdRound(List<Tuple<int, NewTeam>> SouthernPlayoffTeams, List<Tuple<int, NewTeam>> NorthernPlayoffTeams, int startingPosition, bool continuePlayoffs, bool dleague)
        {
            this.dleague = dleague;
            this.startingPosition = startingPosition;
            done = false;
            this.SouthernPlayoffTeams = SouthernPlayoffTeams;
            this.NorthernPlayoffTeams = NorthernPlayoffTeams;
            if(continuePlayoffs)
            {
                DoThirdRound(SouthernPlayoffTeams, NorthernPlayoffTeams);
                DoFinals();
            }
        }
        public void DoRound()
        {
            DoThirdRound(SouthernPlayoffTeams, NorthernPlayoffTeams);
        }
        public bool GetDone()
        {
            return done;
        }
        public void DoThirdRound(List<Tuple<int, NewTeam>> SouthernPlayoffTeams, List<Tuple<int, NewTeam>> NorthernPlayoffTeams)
        {
            Tuple<Tuple<int, NewTeam>, Tuple<int, NewTeam>> result = NewPlayoffs.DoBracket(SouthernPlayoffTeams[0], SouthernPlayoffTeams[1], dleague, 3);

            southWinner = result.Item1;
            southLoser = result.Item2;

            result = NewPlayoffs.DoBracket(NorthernPlayoffTeams[0], NorthernPlayoffTeams[1], dleague, 3);

            northWinner = result.Item1;
            northLoser = result.Item2;

            done = true;
        }
        public void DoFinals()
        {
            ranks = new List<NewTeam>();

            Tuple<Tuple<int, NewTeam>, Tuple<int, NewTeam>> result = NewPlayoffs.DoBracket(new Tuple<int, NewTeam>(southWinner.Item2.GetSeed(), southWinner.Item2), new Tuple<int, NewTeam>(northWinner.Item2.GetSeed(), northWinner.Item2), dleague, 4);
            ranks.Add(result.Item1.Item2);
            ranks.Add(result.Item2.Item2);

            result = NewPlayoffs.DoBracket(new Tuple<int, NewTeam>(southLoser.Item2.GetSeed(), southLoser.Item2), new Tuple<int, NewTeam>(northLoser.Item2.GetSeed(), northLoser.Item2), dleague, 4);
            ranks.Add(result.Item1.Item2);
            ranks.Add(result.Item2.Item2);

            for (int i = 0; i < 4; i++)
            {
                ranks[i].EndPlayoffs(startingPosition + i);
            }
        }
        public List<NewTeam> GetTopFour()
        {            
            return ranks;
        }
    }
}