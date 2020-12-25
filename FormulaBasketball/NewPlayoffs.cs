using System;
using System.Collections.Generic;

namespace FormulaBasketball
{
    public class NewPlayoffs
    {
        private bool doEntirePlayoffs;
        private List<Tuple<int, NewTeam>> nextSouthRoundWinners, nextSouthRoundLosers, nextNorthRoundWinners, nextNorthRoundLosers;
        private SecondRound winnersSecondRound, losersSecondRound;
        private int startingPosition;
        public NewPlayoffs(List<Tuple<int, NewTeam>> SouthernPlayoffTeams, List<Tuple<int, NewTeam>> NorthernPlayoffTeams, int startingPosition, bool DoEntirePlayoffs = true)
        {
            doEntirePlayoffs = DoEntirePlayoffs;
            this.startingPosition = startingPosition;
            if (doEntirePlayoffs)
            {
                DoFirstRound(SouthernPlayoffTeams, NorthernPlayoffTeams);
                DoSecondRound();
            }
        }
        public void DoFirstRound(List<Tuple<int, NewTeam>> SouthernPlayoffTeams, List<Tuple<int, NewTeam>> NorthernPlayoffTeams)
        {
            nextSouthRoundWinners = new List<Tuple<int, NewTeam>>();
            nextSouthRoundLosers = new List<Tuple<int, NewTeam>>();
            nextNorthRoundWinners = new List<Tuple<int, NewTeam>>();
            nextNorthRoundLosers = new List<Tuple<int, NewTeam>>(); 

            Tuple <Tuple < int, NewTeam >, Tuple < int, NewTeam>> result = DoBracket(SouthernPlayoffTeams[0], SouthernPlayoffTeams[7]);

            nextSouthRoundWinners.Add(result.Item1);
            nextSouthRoundLosers.Add(result.Item2);

            result = DoBracket(SouthernPlayoffTeams[3], SouthernPlayoffTeams[4]);

            nextSouthRoundWinners.Add(result.Item1);
            nextSouthRoundLosers.Add(result.Item2);

            result = DoBracket(SouthernPlayoffTeams[2], SouthernPlayoffTeams[5]);

            nextSouthRoundWinners.Add(result.Item1);
            nextSouthRoundLosers.Add(result.Item2);

            result = DoBracket(SouthernPlayoffTeams[1], SouthernPlayoffTeams[6]);

            nextSouthRoundWinners.Add(result.Item1);
            nextSouthRoundLosers.Add(result.Item2);

            result = DoBracket(NorthernPlayoffTeams[0], NorthernPlayoffTeams[7]);

            nextNorthRoundWinners.Add(result.Item1);
            nextNorthRoundLosers.Add(result.Item2);

            result = DoBracket(NorthernPlayoffTeams[3], NorthernPlayoffTeams[4]);

            nextNorthRoundWinners.Add(result.Item1);
            nextNorthRoundLosers.Add(result.Item2);

            result = DoBracket(NorthernPlayoffTeams[2], NorthernPlayoffTeams[5]);

            nextNorthRoundWinners.Add(result.Item1);
            nextNorthRoundLosers.Add(result.Item2);

            result = DoBracket(NorthernPlayoffTeams[1], NorthernPlayoffTeams[6]);

            nextNorthRoundWinners.Add(result.Item1);
            nextNorthRoundLosers.Add(result.Item2);
        }
        public void DoSecondRound()
        {
            winnersSecondRound = new SecondRound(nextSouthRoundWinners, nextNorthRoundWinners, startingPosition, doEntirePlayoffs);
            losersSecondRound = new SecondRound(nextSouthRoundLosers, nextNorthRoundLosers, startingPosition + 8, doEntirePlayoffs);
        }
        public static Tuple<Tuple<int, NewTeam>, Tuple<int, NewTeam>> DoBracket(Tuple<int, NewTeam> teamOne, Tuple<int, NewTeam> teamTwo)
        {
            bool teamOneHigherSeed = teamOne.Item1 < teamTwo.Item1;

            NewTeam higherSeed = teamOneHigherSeed ? teamOne.Item2 : teamTwo.Item2;
            NewTeam lowerSeed = !teamOneHigherSeed ? teamOne.Item2 : teamTwo.Item2;

            int higherSeedWins = 0, lowerSeedWins = 0;

            
            if (PlayGame(lowerSeed, higherSeed))
                lowerSeedWins++;
            else
                higherSeedWins++;

            if (PlayGame(lowerSeed, higherSeed))
                lowerSeedWins++;
            else
                higherSeedWins++;

            if (PlayGame(higherSeed, lowerSeed))
                higherSeedWins++;
            else
                lowerSeedWins++;

            if (PlayGame(higherSeed, lowerSeed))
                higherSeedWins++;
            else
                lowerSeedWins++;

            while(higherSeedWins != 4 && lowerSeedWins != 4)
            {
                if(higherSeedWins + lowerSeedWins == 4)
                    if (PlayGame(higherSeed, lowerSeed))
                        higherSeedWins++;
                    else
                        lowerSeedWins++;
                else
                    if (PlayGame(lowerSeed, higherSeed))
                    lowerSeedWins++;
                else
                    higherSeedWins++;
            }

            return (higherSeedWins == 4  && teamOneHigherSeed) || (lowerSeedWins == 4 && !teamOneHigherSeed) ? new Tuple<Tuple<int, NewTeam>, Tuple<int, NewTeam>>(teamOne, teamTwo) : new Tuple<Tuple<int, NewTeam>, Tuple<int, NewTeam>>(teamTwo, teamOne);
        }

        private static bool PlayGame(NewTeam AwayTeam, NewTeam HomeTeam)
        {
            NewGame game = new NewGame(AwayTeam, HomeTeam, true);
            return game.GetAwayTeamScore() > game.GetHomeTeamScore();
        }
    }
    class SecondRound
    {
        private List<Tuple<int, NewTeam>> nextSouthRoundWinners, nextSouthRoundLosers, nextNorthRoundWinners, nextNorthRoundLosers;
        private ThirdRound winnersThirdRound, losersThirdRound;
        private bool continuePlayoffs;
        private int startingPosition;
        public SecondRound(List<Tuple<int, NewTeam>> SouthernPlayoffTeams, List<Tuple<int, NewTeam>> NorthernPlayoffTeams, int startingPosition, bool continuePlayoffs)
        {
            this.continuePlayoffs = continuePlayoffs;
            this.startingPosition = startingPosition;
            DoSecondRound(SouthernPlayoffTeams, NorthernPlayoffTeams);
            if(continuePlayoffs)
            {
                DoThirdRound();
            }
        }
        public void DoSecondRound(List<Tuple<int, NewTeam>> SouthernPlayoffTeams, List<Tuple<int, NewTeam>> NorthernPlayoffTeams)
        {
            nextSouthRoundWinners = new List<Tuple<int, NewTeam>>();
            nextSouthRoundLosers = new List<Tuple<int, NewTeam>>();
            nextNorthRoundWinners = new List<Tuple<int, NewTeam>>();
            nextNorthRoundLosers = new List<Tuple<int, NewTeam>>();

            Tuple<Tuple<int, NewTeam>, Tuple<int, NewTeam>> result = NewPlayoffs.DoBracket(SouthernPlayoffTeams[0], SouthernPlayoffTeams[1]);

            nextSouthRoundWinners.Add(result.Item1);
            nextSouthRoundLosers.Add(result.Item2);

            result = NewPlayoffs.DoBracket(SouthernPlayoffTeams[2], SouthernPlayoffTeams[3]);

            nextSouthRoundWinners.Add(result.Item1);
            nextSouthRoundLosers.Add(result.Item2);

            result = NewPlayoffs.DoBracket(NorthernPlayoffTeams[0], NorthernPlayoffTeams[1]);

            nextNorthRoundWinners.Add(result.Item1);
            nextNorthRoundLosers.Add(result.Item2);

            result = NewPlayoffs.DoBracket(NorthernPlayoffTeams[2], NorthernPlayoffTeams[3]);

            nextNorthRoundWinners.Add(result.Item1);
            nextNorthRoundLosers.Add(result.Item2);
        }
        public void DoThirdRound()
        {
            winnersThirdRound = new ThirdRound(nextSouthRoundWinners, nextNorthRoundWinners, startingPosition, continuePlayoffs);
            losersThirdRound = new ThirdRound(nextSouthRoundLosers, nextNorthRoundLosers, startingPosition + 4, continuePlayoffs);
        }
    }
    class ThirdRound
    {
        private Tuple<int, NewTeam> southWinner, southLoser, northWinner, northLoser;
        private List<NewTeam> ranks;
        private int startingPosition;
        public ThirdRound(List<Tuple<int, NewTeam>> SouthernPlayoffTeams, List<Tuple<int, NewTeam>> NorthernPlayoffTeams, int startingPosition, bool continuePlayoffs)
        {
            DoThirdRound(SouthernPlayoffTeams, NorthernPlayoffTeams);
            this.startingPosition = startingPosition;
            if(continuePlayoffs)
            {
                DoFinals();
            }
        }
        public void DoThirdRound(List<Tuple<int, NewTeam>> SouthernPlayoffTeams, List<Tuple<int, NewTeam>> NorthernPlayoffTeams)
        {
            Tuple<Tuple<int, NewTeam>, Tuple<int, NewTeam>> result = NewPlayoffs.DoBracket(SouthernPlayoffTeams[0], SouthernPlayoffTeams[1]);

            southWinner = result.Item1;
            southLoser = result.Item2;

            result = NewPlayoffs.DoBracket(NorthernPlayoffTeams[0], NorthernPlayoffTeams[1]);

            northWinner = result.Item1;
            northLoser = result.Item2;
        }
        public void DoFinals()
        {
            ranks = new List<NewTeam>();

            Tuple<Tuple<int, NewTeam>, Tuple<int, NewTeam>> result = NewPlayoffs.DoBracket(new Tuple<int, NewTeam>(southWinner.Item2.GetSeed(), southWinner.Item2), new Tuple<int, NewTeam>(northWinner.Item2.GetSeed(), northWinner.Item2));
            ranks.Add(result.Item1.Item2);
            ranks.Add(result.Item2.Item2);

            result = NewPlayoffs.DoBracket(new Tuple<int, NewTeam>(southLoser.Item2.GetSeed(), southLoser.Item2), new Tuple<int, NewTeam>(northLoser.Item2.GetSeed(), northLoser.Item2));
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