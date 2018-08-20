using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class Playoffs
    {
        private formulaBasketball formulaBasketball;
        private int[] conferenceAWinCounter = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] conferenceBWinCounter = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int gamesPlayed = 0;
        private int winnerOfMatchOne = 0, loserOfMatchOne = 0;
        private int winnerOfMatchTwo = 0, loserOfMatchTwo = 0;
        private int winnerOfMatchThree = 0, loserOfMatchThree = 0;
        private int winnerOfMatchFour = 0, loserOfMatchFour = 0;
        private int winnerOfMatchFive = 0, loserOfMatchFive = 0;
        private int winnerOfMatchSix = 0, loserOfMatchSix = 0;
        private int winnerOfMatchSeven = 0, loserOfMatchSeven = 0;
        private int winnerOfMatchEight = 0, loserOfMatchEight = 0;
        private int winnerOfMatchNine = 0, loserOfMatchNine = 0;
        private int winnerOfMatchTen = 0, loserOfMatchTen = 0;
        private int winnerOfMatchEleven = 0, loserOfMatchEleven = 0;
        private int winnerOfMatchTwelve = 0, loserOfMatchTwelve = 0;
        private int winnerOfMatchThirteen = 0, loserOfMatchThirteen = 0;
        private int winnerOfMatchForteen = 0, loserOfMatchForteen = 0;
        private int winnerOfMatchFifteen = 0, loserOfMatchFifteen = 0;
        private int winnerOfMatchSixteen = 0, loserOfMatchSixteen = 0;
        private int winnerOfThirdRoundMatchOne = 0, loserOfThirdRoundMatchOne = 0;
        private int winnerOfThirdRoundMatchTwo;
        private int loserOfThirdRoundMatchTwo;
        private int winnerOfThirdRoundMatchThree;
        private int loserOfThirdRoundMatchThree;
        private int winnerOfThirdRoundMatchFour;
        private int loserOfThirdRoundMatchFour;
        private int winnerOfThirdRoundMatchFive;
        private int loserOfThirdRoundMatchFive;
        private int winnerOfThirdRoundMatchSix;
        private int loserOfThirdRoundMatchSix;
        private int winnerOfThirdRoundMatchSeven;
        private int loserOfThirdRoundMatchSeven;
        private int winnerOfThirdRoundMatchEight;
        private int loserOfThirdRoundMatchEight;
        private int winnerOfThirdRoundMatchNine;
        private int loserOfThirdRoundMatchNine;
        private int winnerOfThirdRoundMatchTen;
        private int loserOfThirdRoundMatchTen;
        private int winnerOfThirdRoundMatchEleven;
        private int loserOfThirdRoundMatchEleven;
        private int winnerOfThirdRoundMatchTwelve;
        private int loserOfThirdRoundMatchTwelve;
        private int winnerOfThirdRoundMatchThirteen;
        private int loserOfThirdRoundMatchThirteen;
        private int winnerOfThirdRoundMatchForteen;
        private int loserOfThirdRoundMatchForteen;
        private int winnerOfThirdRoundMatchFifteen;
        private int loserOfThirdRoundMatchFifteen;
        private int winnerOfThirdRoundMatchSixteen;
        private int loserOfThirdRoundMatchSixteen;
        private int topSeedConferenceA = 0, secondSeedConferenceA = 0;
        private int thirdSeedConferenceA;
        private int fourthSeedConferenceA;
        private int fifthSeedConferenceA;
        private int sixthSeedConferenceA;
        private int seventhSeedConferenceA;
        private int eighthSeedConferenceA;
        private int topSeedConferenceB;
        private int secondSeedConferenceB;
        private int thirdSeedConferenceB;
        private int fourthSeedConferenceB;
        private int fifthSeedConferenceB;
        private int sixthSeedConferenceB;
        private int seventhSeedConferenceB;
        private int eighthSeedConferenceB;
        private int ninthSeedConferenceA;
        private int tenthSeedConferenceA;
        private int eleventhSeedConferenceA;
        private int twelfthSeedConferenceA;
        private int thirteenthSeedConferenceA;
        private int forteenthSeedConferenceA;
        private int fifteenthSeedConferenceA;
        private int sixteenthSeedConferenceA;
        private int ninthSeedConferenceB;
        private int tenthSeedConferenceB;
        private int eleventhSeedConferenceB;
        private int twelfthSeedConferenceB;
        private int thirteenthSeedConferenceB;
        private int forteenthSeedConferenceB;
        private int fifteenthSeedConferenceB;
        private int sixteenthSeedConferenceB;
        private team champion, runnerUp;
        public Queue<Action> queue;
        private PlayoffBracket bracket;
        
        
        public Playoffs()
        {
            setUpPlayoffs();
        }
        public String GetChampion()
        {
            champion.AddChampionship();
            runnerUp.AddConferenceChampionship();
            return champion.ToString();
        }
        private void setUpPlayoffs()
        {
            queue = new Queue<Action>();
            queue.Enqueue(() => firstRound());
            queue.Enqueue(() => secondRound());
            queue.Enqueue(() => thirdRound());
            queue.Enqueue(() => fourthRound());

            
        }       
        public void setBracket(PlayoffBracket bracket, int num)
        {
            this.bracket = bracket;
            bracket.SetNumber(num);
        }
        private void firstRound()
        {
            formulaBasketball.calculateStandings(true);
            formulaBasketball.DivisionA[0].AddDivisionChampionship();
            formulaBasketball.DivisionB[0].AddDivisionChampionship();
            formulaBasketball.DivisionC[0].AddDivisionChampionship();
            formulaBasketball.DivisionD[0].AddDivisionChampionship();

            formulaBasketball.startingGame = 0;

            bracket.setBrackets(formulaBasketball.ConferenceA, formulaBasketball.ConferenceB);

            while (gamesPlayed < 7)
            {
                
                formulaBasketball.startingGame = gamesPlayed + 2;
                formulaBasketball.gameResultsContents += "Game " + (formulaBasketball.startingGame - 1) + ",Home,Score,Away,Score\n";

                if (conferenceAWinCounter[0] != 4 && conferenceAWinCounter[7] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceA.ElementAt(0).getLeagueRank() < formulaBasketball.ConferenceA.ElementAt(7).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(0).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(7).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(7).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(0).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceA.ElementAt(0).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceA.ElementAt(0).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceA.ElementAt(0).getTeamNum(),formulaBasketball.ConferenceA.ElementAt(7).getTeamNum());
                    if (flag) conferenceAWinCounter[0]++;
                    else conferenceAWinCounter[7]++;
                }
                if (conferenceAWinCounter[1] != 4 && conferenceAWinCounter[6] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceA.ElementAt(1).getLeagueRank() < formulaBasketball.ConferenceA.ElementAt(6).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(1).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(6).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(6).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(1).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceA.ElementAt(1).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceA.ElementAt(1).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceA.ElementAt(1).getTeamNum(),formulaBasketball.ConferenceA.ElementAt(6).getTeamNum());
                    if (flag) conferenceAWinCounter[1]++;
                    else conferenceAWinCounter[6]++;
                }
                if (conferenceAWinCounter[2] != 4 && conferenceAWinCounter[5] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceA.ElementAt(2).getLeagueRank() < formulaBasketball.ConferenceA.ElementAt(5).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(2).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(5).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(5).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(2).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceA.ElementAt(2).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceA.ElementAt(2).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceA.ElementAt(2).getTeamNum(),formulaBasketball.ConferenceA.ElementAt(5).getTeamNum());
                    if (flag) conferenceAWinCounter[2]++;
                    else conferenceAWinCounter[5]++;
                }
                if (conferenceAWinCounter[3] != 4 && conferenceAWinCounter[4] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceA.ElementAt(3).getLeagueRank() < formulaBasketball.ConferenceA.ElementAt(4).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(3).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(4).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(4).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(3).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceA.ElementAt(3).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceA.ElementAt(3).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceA.ElementAt(3).getTeamNum(),formulaBasketball.ConferenceA.ElementAt(4).getTeamNum());
                    if (flag) conferenceAWinCounter[3]++;
                    else conferenceAWinCounter[4]++;
                }
                if (conferenceBWinCounter[0] != 4 && conferenceBWinCounter[7] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceB.ElementAt(0).getLeagueRank() < formulaBasketball.ConferenceB.ElementAt(7).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(0).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(7).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(7).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(0).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceB.ElementAt(0).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceB.ElementAt(0).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceB.ElementAt(0).getTeamNum(),formulaBasketball.ConferenceB.ElementAt(7).getTeamNum());
                    if (flag) conferenceBWinCounter[0]++;
                    else conferenceBWinCounter[7]++;
                }
                if (conferenceBWinCounter[1] != 4 && conferenceBWinCounter[6] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceB.ElementAt(1).getLeagueRank() < formulaBasketball.ConferenceB.ElementAt(6).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(1).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(6).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(6).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(1).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceB.ElementAt(1).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceB.ElementAt(1).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceB.ElementAt(1).getTeamNum(),formulaBasketball.ConferenceB.ElementAt(6).getTeamNum());
                    if (flag) conferenceBWinCounter[1]++;
                    else conferenceBWinCounter[6]++;
                }
                if (conferenceBWinCounter[2] != 4 && conferenceBWinCounter[5] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceB.ElementAt(2).getLeagueRank() < formulaBasketball.ConferenceB.ElementAt(5).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(2).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(5).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(5).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(2).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceB.ElementAt(2).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceB.ElementAt(2).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceB.ElementAt(2).getTeamNum(),formulaBasketball.ConferenceB.ElementAt(5).getTeamNum());
                    if (flag) conferenceBWinCounter[2]++;
                    else conferenceBWinCounter[5]++;
                }
                if (conferenceBWinCounter[3] != 4 && conferenceBWinCounter[4] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceB.ElementAt(3).getLeagueRank() < formulaBasketball.ConferenceB.ElementAt(4).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(3).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(4).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(4).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(3).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceB.ElementAt(3).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceB.ElementAt(3).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceB.ElementAt(3).getTeamNum(),formulaBasketball.ConferenceB.ElementAt(4).getTeamNum());
                    if (flag) conferenceBWinCounter[3]++;
                    else conferenceBWinCounter[4]++;
                }
                if (conferenceAWinCounter[8] != 4 && conferenceAWinCounter[15] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceA.ElementAt(8).getLeagueRank() < formulaBasketball.ConferenceA.ElementAt(15).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(8).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(15).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(15).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(8).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceA.ElementAt(8).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceA.ElementAt(8).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceA.ElementAt(8).getTeamNum(),formulaBasketball.ConferenceA.ElementAt(15).getTeamNum());
                    if (flag) conferenceAWinCounter[8]++;
                    else conferenceAWinCounter[15]++;
                }
                if (conferenceAWinCounter[9] != 4 && conferenceAWinCounter[14] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceA.ElementAt(9).getLeagueRank() < formulaBasketball.ConferenceA.ElementAt(14).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(9).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(14).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(14).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(9).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceA.ElementAt(9).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceA.ElementAt(9).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceA.ElementAt(9).getTeamNum(),formulaBasketball.ConferenceA.ElementAt(14).getTeamNum());
                    if (flag) conferenceAWinCounter[9]++;
                    else conferenceAWinCounter[14]++;
                }
                if (conferenceAWinCounter[10] != 4 && conferenceAWinCounter[13] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceA.ElementAt(10).getLeagueRank() < formulaBasketball.ConferenceA.ElementAt(13).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(10).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(13).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(13).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(10).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceA.ElementAt(10).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceA.ElementAt(10).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceA.ElementAt(10).getTeamNum(),formulaBasketball.ConferenceA.ElementAt(13).getTeamNum());
                    if (flag) conferenceAWinCounter[10]++;
                    else conferenceAWinCounter[13]++;
                }
                if (conferenceAWinCounter[11] != 4 && conferenceAWinCounter[12] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceA.ElementAt(11).getLeagueRank() < formulaBasketball.ConferenceA.ElementAt(12).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(11).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(12).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceA.ElementAt(12).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceA.ElementAt(11).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceA.ElementAt(11).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceA.ElementAt(11).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceA.ElementAt(11).getTeamNum(),formulaBasketball.ConferenceA.ElementAt(12).getTeamNum());
                    if (flag) conferenceAWinCounter[11]++;
                    else conferenceAWinCounter[12]++;
                }
                if (conferenceBWinCounter[8] != 4 && conferenceBWinCounter[15] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceB.ElementAt(8).getLeagueRank() < formulaBasketball.ConferenceB.ElementAt(15).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(8).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(15).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(15).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(8).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceB.ElementAt(8).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceB.ElementAt(8).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceB.ElementAt(8).getTeamNum(),formulaBasketball.ConferenceB.ElementAt(15).getTeamNum());
                    if (flag) conferenceBWinCounter[8]++;
                    else conferenceBWinCounter[15]++;
                }
                if (conferenceBWinCounter[9] != 4 && conferenceBWinCounter[14] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceB.ElementAt(9).getLeagueRank() < formulaBasketball.ConferenceB.ElementAt(14).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(9).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(14).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(14).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(9).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceB.ElementAt(9).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceB.ElementAt(9).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceB.ElementAt(9).getTeamNum(),formulaBasketball.ConferenceB.ElementAt(14).getTeamNum());
                    if (flag) conferenceBWinCounter[9]++;
                    else conferenceBWinCounter[14]++;
                }
                if (conferenceBWinCounter[10] != 4 && conferenceBWinCounter[13] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceB.ElementAt(10).getLeagueRank() < formulaBasketball.ConferenceB.ElementAt(13).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(10).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(13).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(13).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(10).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceB.ElementAt(10).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceB.ElementAt(10).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceB.ElementAt(10).getTeamNum(),formulaBasketball.ConferenceB.ElementAt(13).getTeamNum());
                    if (flag) conferenceBWinCounter[10]++;
                    else conferenceBWinCounter[13]++;
                }
                if (conferenceBWinCounter[11] != 4 && conferenceBWinCounter[12] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.ConferenceB.ElementAt(11).getLeagueRank() < formulaBasketball.ConferenceB.ElementAt(12).getLeagueRank())
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(11).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(12).getTeamNum();
                    }
                    else
                    {
                        higherSeed = formulaBasketball.ConferenceB.ElementAt(12).getTeamNum();
                        lowerSeed = formulaBasketball.ConferenceB.ElementAt(11).getTeamNum();
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != formulaBasketball.ConferenceB.ElementAt(11).getTeamNum()) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == formulaBasketball.ConferenceB.ElementAt(11).getTeamNum()) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, formulaBasketball.ConferenceB.ElementAt(11).getTeamNum(),formulaBasketball.ConferenceB.ElementAt(12).getTeamNum());
                    if (flag) conferenceBWinCounter[11]++;
                    else conferenceBWinCounter[12]++;
                }
                bracket.updateFirstRoundScores(conferenceAWinCounter, conferenceBWinCounter);
                System.Threading.Thread.Sleep(5);
                formulaBasketball.writerContents += "\n";
                gamesPlayed++;
            }
            if (conferenceAWinCounter[0] == 4)
            {
                winnerOfMatchOne = formulaBasketball.ConferenceA.ElementAt(0).getTeamNum();
                loserOfMatchOne = formulaBasketball.ConferenceA.ElementAt(7).getTeamNum();

            }
            else
            {
                loserOfMatchOne = formulaBasketball.ConferenceA.ElementAt(0).getTeamNum();
                winnerOfMatchOne = formulaBasketball.ConferenceA.ElementAt(7).getTeamNum();
            }
            if (conferenceAWinCounter[1] == 4)
            {
                winnerOfMatchTwo = formulaBasketball.ConferenceA.ElementAt(1).getTeamNum();
                loserOfMatchTwo = formulaBasketball.ConferenceA.ElementAt(6).getTeamNum();
            }
            else
            {
                loserOfMatchTwo = formulaBasketball.ConferenceA.ElementAt(1).getTeamNum();
                winnerOfMatchTwo = formulaBasketball.ConferenceA.ElementAt(6).getTeamNum();
            }
            if (conferenceAWinCounter[2] == 4)
            {
                winnerOfMatchThree = formulaBasketball.ConferenceA.ElementAt(2).getTeamNum();
                loserOfMatchThree = formulaBasketball.ConferenceA.ElementAt(5).getTeamNum();
            }
            else
            {
                loserOfMatchThree = formulaBasketball.ConferenceA.ElementAt(2).getTeamNum();
                winnerOfMatchThree = formulaBasketball.ConferenceA.ElementAt(5).getTeamNum();
            }
            if (conferenceAWinCounter[3] == 4)
            {
                winnerOfMatchFour = formulaBasketball.ConferenceA.ElementAt(3).getTeamNum();
                loserOfMatchFour = formulaBasketball.ConferenceA.ElementAt(4).getTeamNum();
            }
            else
            {
                loserOfMatchFour = formulaBasketball.ConferenceA.ElementAt(3).getTeamNum();
                winnerOfMatchFour = formulaBasketball.ConferenceA.ElementAt(4).getTeamNum();
            }
            if (conferenceBWinCounter[0] == 4)
            {
                winnerOfMatchFive = formulaBasketball.ConferenceB.ElementAt(0).getTeamNum();
                loserOfMatchFive = formulaBasketball.ConferenceB.ElementAt(7).getTeamNum();
            }
            else
            {
                loserOfMatchFive = formulaBasketball.ConferenceB.ElementAt(0).getTeamNum();
                winnerOfMatchFive = formulaBasketball.ConferenceB.ElementAt(7).getTeamNum();
            }
            if (conferenceBWinCounter[1] == 4)
            {
                winnerOfMatchSix = formulaBasketball.ConferenceB.ElementAt(1).getTeamNum();
                loserOfMatchSix = formulaBasketball.ConferenceB.ElementAt(6).getTeamNum();
            }
            else
            {
                loserOfMatchSix = formulaBasketball.ConferenceB.ElementAt(1).getTeamNum();
                winnerOfMatchSix = formulaBasketball.ConferenceB.ElementAt(6).getTeamNum();
            }
            if (conferenceBWinCounter[2] == 4)
            {
                winnerOfMatchSeven = formulaBasketball.ConferenceB.ElementAt(2).getTeamNum();
                loserOfMatchSeven = formulaBasketball.ConferenceB.ElementAt(5).getTeamNum();
            }
            else
            {
                loserOfMatchSeven = formulaBasketball.ConferenceB.ElementAt(2).getTeamNum();
                winnerOfMatchSeven = formulaBasketball.ConferenceB.ElementAt(5).getTeamNum();
            }
            if (conferenceBWinCounter[3] == 4)
            {
                winnerOfMatchEight = formulaBasketball.ConferenceB.ElementAt(3).getTeamNum();
                loserOfMatchEight = formulaBasketball.ConferenceB.ElementAt(4).getTeamNum();
            }
            else
            {
                loserOfMatchEight = formulaBasketball.ConferenceB.ElementAt(3).getTeamNum();
                winnerOfMatchEight = formulaBasketball.ConferenceB.ElementAt(4).getTeamNum();
            }
            if (conferenceAWinCounter[8] == 4)
            {
                winnerOfMatchNine = formulaBasketball.ConferenceA.ElementAt(8).getTeamNum();
                loserOfMatchNine = formulaBasketball.ConferenceA.ElementAt(15).getTeamNum();
            }
            else
            {
                loserOfMatchNine = formulaBasketball.ConferenceA.ElementAt(8).getTeamNum();
                winnerOfMatchNine = formulaBasketball.ConferenceA.ElementAt(15).getTeamNum();
            }
            if (conferenceAWinCounter[9] == 4)
            {
                winnerOfMatchTen = formulaBasketball.ConferenceA.ElementAt(9).getTeamNum();
                loserOfMatchTen = formulaBasketball.ConferenceA.ElementAt(14).getTeamNum();
            }
            else
            {
                loserOfMatchTen = formulaBasketball.ConferenceA.ElementAt(9).getTeamNum();
                winnerOfMatchTen = formulaBasketball.ConferenceA.ElementAt(14).getTeamNum();
            }
            if (conferenceAWinCounter[10] == 4)
            {
                winnerOfMatchEleven = formulaBasketball.ConferenceA.ElementAt(10).getTeamNum();
                loserOfMatchEleven = formulaBasketball.ConferenceA.ElementAt(13).getTeamNum();
            }
            else
            {
                loserOfMatchEleven = formulaBasketball.ConferenceA.ElementAt(10).getTeamNum();
                winnerOfMatchEleven = formulaBasketball.ConferenceA.ElementAt(13).getTeamNum();
            }
            if (conferenceAWinCounter[11] == 4)
            {
                winnerOfMatchTwelve = formulaBasketball.ConferenceA.ElementAt(11).getTeamNum();
                loserOfMatchTwelve = formulaBasketball.ConferenceA.ElementAt(12).getTeamNum();
            }
            else
            {
                loserOfMatchTwelve = formulaBasketball.ConferenceA.ElementAt(11).getTeamNum();
                winnerOfMatchTwelve = formulaBasketball.ConferenceA.ElementAt(12).getTeamNum();
            }
            if (conferenceBWinCounter[8] == 4)
            {
                winnerOfMatchThirteen = formulaBasketball.ConferenceB.ElementAt(8).getTeamNum();
                loserOfMatchThirteen = formulaBasketball.ConferenceB.ElementAt(15).getTeamNum();
            }
            else
            {
                loserOfMatchThirteen = formulaBasketball.ConferenceB.ElementAt(8).getTeamNum();
                winnerOfMatchThirteen = formulaBasketball.ConferenceB.ElementAt(15).getTeamNum();
            }
            if (conferenceBWinCounter[9] == 4)
            {
                winnerOfMatchForteen = formulaBasketball.ConferenceB.ElementAt(9).getTeamNum();
                loserOfMatchForteen = formulaBasketball.ConferenceB.ElementAt(14).getTeamNum();
            }
            else
            {
                loserOfMatchForteen = formulaBasketball.ConferenceB.ElementAt(9).getTeamNum();
                winnerOfMatchForteen = formulaBasketball.ConferenceB.ElementAt(14).getTeamNum();
            }
            if (conferenceBWinCounter[10] == 4)
            {
                winnerOfMatchFifteen = formulaBasketball.ConferenceB.ElementAt(10).getTeamNum();
                loserOfMatchFifteen = formulaBasketball.ConferenceB.ElementAt(13).getTeamNum();
            }
            else
            {
                loserOfMatchFifteen = formulaBasketball.ConferenceB.ElementAt(10).getTeamNum();
                winnerOfMatchFifteen = formulaBasketball.ConferenceB.ElementAt(13).getTeamNum();
            }
            if (conferenceBWinCounter[11] == 4)
            {
                winnerOfMatchSixteen = formulaBasketball.ConferenceB.ElementAt(11).getTeamNum();
                loserOfMatchSixteen = formulaBasketball.ConferenceB.ElementAt(12).getTeamNum();
            }
            else
            {
                loserOfMatchSixteen = formulaBasketball.ConferenceB.ElementAt(11).getTeamNum();
                winnerOfMatchSixteen = formulaBasketball.ConferenceB.ElementAt(12).getTeamNum();
            }
            
        }       

        private void secondRound()
        {
            gamesPlayed = 0;
            conferenceAWinCounter = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            conferenceBWinCounter = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            while (gamesPlayed < 7)
            {

                formulaBasketball.startingGame = gamesPlayed + 2;
                formulaBasketball.gameResultsContents += ("Game " + (formulaBasketball.startingGame - 1) + ",Home,Score,Away,Score\n");
                if (conferenceAWinCounter[0] != 4 && conferenceAWinCounter[7] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfMatchOne).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfMatchFour).getLeagueRank())
                    {
                        higherSeed = winnerOfMatchOne;
                        lowerSeed = winnerOfMatchFour;
                    }
                    else
                    {
                        higherSeed = winnerOfMatchFour;
                        lowerSeed = winnerOfMatchOne;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfMatchOne) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfMatchOne) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfMatchOne,winnerOfMatchFour);
                    if (flag) conferenceAWinCounter[0]++;
                    else conferenceAWinCounter[7]++;
                }
                if (conferenceAWinCounter[1] != 4 && conferenceAWinCounter[6] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfMatchTwo).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfMatchThree).getLeagueRank())
                    {
                        higherSeed = winnerOfMatchTwo;
                        lowerSeed = winnerOfMatchThree;
                    }
                    else
                    {
                        higherSeed = winnerOfMatchThree;
                        lowerSeed = winnerOfMatchTwo;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfMatchTwo) flag = true;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfMatchTwo) flag = true;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfMatchTwo,winnerOfMatchThree);
                    if (flag) conferenceAWinCounter[1]++;
                    else conferenceAWinCounter[6]++;
                }
                if (conferenceAWinCounter[2] != 4 && conferenceAWinCounter[5] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfMatchOne).getLeagueRank() < formulaBasketball.create.getTeam(loserOfMatchFour).getLeagueRank())
                    {
                        higherSeed = loserOfMatchOne;
                        lowerSeed = loserOfMatchFour;
                    }
                    else
                    {
                        higherSeed = loserOfMatchFour;
                        lowerSeed = loserOfMatchOne;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfMatchOne) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfMatchOne) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfMatchOne,loserOfMatchFour);
                    if (flag) conferenceAWinCounter[2]++;
                    else conferenceAWinCounter[5]++;
                }
                if (conferenceAWinCounter[3] != 4 && conferenceAWinCounter[4] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfMatchTwo).getLeagueRank() < formulaBasketball.create.getTeam(loserOfMatchThree).getLeagueRank())
                    {
                        higherSeed = loserOfMatchTwo;
                        lowerSeed = loserOfMatchThree;
                    }
                    else
                    {
                        higherSeed = loserOfMatchThree;
                        lowerSeed = loserOfMatchTwo;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfMatchTwo) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfMatchTwo) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfMatchTwo,loserOfMatchThree);
                    if (flag) conferenceAWinCounter[3]++;
                    else conferenceAWinCounter[4]++;
                }
                if (conferenceBWinCounter[0] != 4 && conferenceBWinCounter[7] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfMatchFive).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfMatchEight).getLeagueRank())
                    {
                        higherSeed = winnerOfMatchFive;
                        lowerSeed = winnerOfMatchEight;
                    }
                    else
                    {
                        higherSeed = winnerOfMatchEight;
                        lowerSeed = winnerOfMatchFive;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfMatchFive) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfMatchFive) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfMatchFive,winnerOfMatchEight);
                    if (flag) conferenceBWinCounter[0]++;
                    else conferenceBWinCounter[7]++;
                }
                if (conferenceBWinCounter[1] != 4 && conferenceBWinCounter[6] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfMatchSix).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfMatchSeven).getLeagueRank())
                    {
                        higherSeed = winnerOfMatchSix;
                        lowerSeed = winnerOfMatchSeven;
                    }
                    else
                    {
                        higherSeed = winnerOfMatchSeven;
                        lowerSeed = winnerOfMatchSix;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfMatchSix) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfMatchSix) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfMatchSix,winnerOfMatchSeven);
                    if (flag) conferenceBWinCounter[1]++;
                    else conferenceBWinCounter[6]++;
                }
                if (conferenceBWinCounter[2] != 4 && conferenceBWinCounter[5] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfMatchFive).getLeagueRank() < formulaBasketball.create.getTeam(loserOfMatchEight).getLeagueRank())
                    {
                        higherSeed = loserOfMatchFive;
                        lowerSeed = loserOfMatchEight;
                    }
                    else
                    {
                        higherSeed = loserOfMatchEight;
                        lowerSeed = loserOfMatchFive;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfMatchFive) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfMatchFive) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfMatchFive,loserOfMatchEight);
                    if (flag) conferenceBWinCounter[2]++;
                    else conferenceBWinCounter[5]++;
                }
                if (conferenceBWinCounter[3] != 4 && conferenceBWinCounter[4] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfMatchSix).getLeagueRank() < formulaBasketball.create.getTeam(loserOfMatchSeven).getLeagueRank())
                    {
                        higherSeed = loserOfMatchSix;
                        lowerSeed = loserOfMatchSeven;
                    }
                    else
                    {
                        higherSeed = loserOfMatchSeven;
                        lowerSeed = loserOfMatchSix;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfMatchSix) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfMatchSix) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfMatchSix,loserOfMatchSeven);
                    if (flag) conferenceBWinCounter[3]++;
                    else conferenceBWinCounter[4]++;
                }
                if (conferenceAWinCounter[8] != 4 && conferenceAWinCounter[15] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfMatchNine).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfMatchTwelve).getLeagueRank())
                    {
                        higherSeed = winnerOfMatchNine;
                        lowerSeed = winnerOfMatchTwelve;
                    }
                    else
                    {
                        higherSeed = winnerOfMatchTwelve;
                        lowerSeed = winnerOfMatchNine;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfMatchNine) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfMatchNine) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfMatchNine,winnerOfMatchTwelve);
                    if (flag) conferenceAWinCounter[8]++;
                    else conferenceAWinCounter[15]++;
                }
                if (conferenceAWinCounter[9] != 4 && conferenceAWinCounter[14] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfMatchTen).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfMatchEleven).getLeagueRank())
                    {
                        higherSeed = winnerOfMatchTen;
                        lowerSeed = winnerOfMatchEleven;
                    }
                    else
                    {
                        higherSeed = winnerOfMatchEleven;
                        lowerSeed = winnerOfMatchTen;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfMatchTen) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfMatchTen) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfMatchTen,winnerOfMatchEleven);
                    if (flag) conferenceAWinCounter[9]++;
                    else conferenceAWinCounter[14]++;
                }
                if (conferenceAWinCounter[10] != 4 && conferenceAWinCounter[13] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfMatchNine).getLeagueRank() < formulaBasketball.create.getTeam(loserOfMatchTwelve).getLeagueRank())
                    {
                        higherSeed = loserOfMatchNine;
                        lowerSeed = loserOfMatchTwelve;
                    }
                    else
                    {
                        higherSeed = loserOfMatchTwelve;
                        lowerSeed = loserOfMatchNine;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfMatchNine) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfMatchNine) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfMatchNine,loserOfMatchTwelve);
                    if (flag) conferenceAWinCounter[10]++;
                    else conferenceAWinCounter[13]++;
                }
                if (conferenceAWinCounter[11] != 4 && conferenceAWinCounter[12] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfMatchTen).getLeagueRank() < formulaBasketball.create.getTeam(loserOfMatchEleven).getLeagueRank())
                    {
                        higherSeed = loserOfMatchTen;
                        lowerSeed = loserOfMatchEleven;
                    }
                    else
                    {
                        higherSeed = loserOfMatchEleven;
                        lowerSeed = loserOfMatchTen;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfMatchTen) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfMatchTen) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfMatchTen,loserOfMatchEleven);
                    if (flag) conferenceAWinCounter[11]++;
                    else conferenceAWinCounter[12]++;
                }
                if (conferenceBWinCounter[8] != 4 && conferenceBWinCounter[15] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfMatchThirteen).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfMatchSixteen).getLeagueRank())
                    {
                        higherSeed = winnerOfMatchThirteen;
                        lowerSeed = winnerOfMatchSixteen;
                    }
                    else
                    {
                        higherSeed = winnerOfMatchSixteen;
                        lowerSeed = winnerOfMatchThirteen;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfMatchThirteen) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfMatchThirteen) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfMatchThirteen,winnerOfMatchSixteen);
                    if (flag) conferenceBWinCounter[8]++;
                    else conferenceBWinCounter[15]++;
                }
                if (conferenceBWinCounter[9] != 4 && conferenceBWinCounter[14] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfMatchForteen).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfMatchFifteen).getLeagueRank())
                    {
                        higherSeed = winnerOfMatchForteen;
                        lowerSeed = winnerOfMatchFifteen;
                    }
                    else
                    {
                        higherSeed = winnerOfMatchFifteen;
                        lowerSeed = winnerOfMatchForteen;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfMatchForteen) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfMatchForteen) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfMatchForteen,winnerOfMatchFifteen);
                    if (flag) conferenceBWinCounter[9]++;
                    else conferenceBWinCounter[14]++;
                }
                if (conferenceBWinCounter[10] != 4 && conferenceBWinCounter[13] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfMatchThirteen).getLeagueRank() < formulaBasketball.create.getTeam(loserOfMatchSixteen).getLeagueRank())
                    {
                        higherSeed = loserOfMatchThirteen;
                        lowerSeed = loserOfMatchSixteen;
                    }
                    else
                    {
                        higherSeed = loserOfMatchSixteen;
                        lowerSeed = loserOfMatchThirteen;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfMatchThirteen) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfMatchThirteen) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfMatchThirteen,loserOfMatchSixteen);
                    if (flag) conferenceBWinCounter[10]++;
                    else conferenceBWinCounter[13]++;
                }
                if (conferenceBWinCounter[11] != 4 && conferenceBWinCounter[12] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfMatchForteen).getLeagueRank() < formulaBasketball.create.getTeam(loserOfMatchFifteen).getLeagueRank())
                    {
                        higherSeed = loserOfMatchForteen;
                        lowerSeed = loserOfMatchFifteen;
                    }
                    else
                    {
                        higherSeed = loserOfMatchFifteen;
                        lowerSeed = loserOfMatchForteen;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfMatchForteen) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfMatchForteen) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfMatchForteen,loserOfMatchFifteen);
                    if (flag) conferenceBWinCounter[11]++;
                    else conferenceBWinCounter[12]++;
                }
                formulaBasketball.writerContents += "\n";
                bracket.updateSecondRoundScores(conferenceAWinCounter, conferenceBWinCounter);
                gamesPlayed++;


            }

            if (conferenceAWinCounter[0] == 4)
            {
                winnerOfThirdRoundMatchOne = winnerOfMatchOne;
                loserOfThirdRoundMatchOne = winnerOfMatchFour;
            }
            else
            {
                loserOfThirdRoundMatchOne = winnerOfMatchOne;
                winnerOfThirdRoundMatchOne = winnerOfMatchFour;
            }

            if (conferenceAWinCounter[1] == 4)
            {
                winnerOfThirdRoundMatchTwo = winnerOfMatchTwo;
                loserOfThirdRoundMatchTwo = winnerOfMatchThree;
            }
            else
            {
                loserOfThirdRoundMatchTwo = winnerOfMatchTwo;
                winnerOfThirdRoundMatchTwo = winnerOfMatchThree;
            }

            if (conferenceAWinCounter[2] == 4)
            {
                winnerOfThirdRoundMatchThree = loserOfMatchOne;
                loserOfThirdRoundMatchThree = loserOfMatchFour;
            }
            else
            {
                loserOfThirdRoundMatchThree = loserOfMatchOne;
                winnerOfThirdRoundMatchThree = loserOfMatchFour;
            }

            if (conferenceAWinCounter[3] == 4)
            {
                winnerOfThirdRoundMatchFour = loserOfMatchTwo;
                loserOfThirdRoundMatchFour = loserOfMatchThree;
            }
            else
            {
                loserOfThirdRoundMatchFour = loserOfMatchTwo;
                winnerOfThirdRoundMatchFour = loserOfMatchThree;
            }

            if (conferenceBWinCounter[0] == 4)
            {
                winnerOfThirdRoundMatchFive = winnerOfMatchFive;
                loserOfThirdRoundMatchFive = winnerOfMatchEight;
            }
            else
            {
                loserOfThirdRoundMatchFive = winnerOfMatchFive;
                winnerOfThirdRoundMatchFive = winnerOfMatchEight;
            }

            if (conferenceBWinCounter[1] == 4)
            {
                winnerOfThirdRoundMatchSix = winnerOfMatchSix;
                loserOfThirdRoundMatchSix = winnerOfMatchSeven;
            }
            else
            {
                loserOfThirdRoundMatchSix = winnerOfMatchSix;
                winnerOfThirdRoundMatchSix = winnerOfMatchSeven;
            }

            if (conferenceBWinCounter[2] == 4)
            {
                winnerOfThirdRoundMatchSeven = loserOfMatchFive;
                loserOfThirdRoundMatchSeven = loserOfMatchEight;
            }
            else
            {
                loserOfThirdRoundMatchSeven = loserOfMatchFive;
                winnerOfThirdRoundMatchSeven = loserOfMatchEight;
            }

            if (conferenceBWinCounter[3] == 4)
            {
                winnerOfThirdRoundMatchEight = loserOfMatchSix;
                loserOfThirdRoundMatchEight = loserOfMatchSeven;
            }
            else
            {
                loserOfThirdRoundMatchEight = loserOfMatchSix;
                winnerOfThirdRoundMatchEight = loserOfMatchSeven;
            }

            if (conferenceAWinCounter[8] == 4)
            {
                winnerOfThirdRoundMatchNine = winnerOfMatchNine;
                loserOfThirdRoundMatchNine = winnerOfMatchTwelve;
            }
            else
            {
                loserOfThirdRoundMatchNine = winnerOfMatchNine;
                winnerOfThirdRoundMatchNine = winnerOfMatchTwelve;
            }

            if (conferenceAWinCounter[9] == 4)
            {
                winnerOfThirdRoundMatchTen = winnerOfMatchTen;
                loserOfThirdRoundMatchTen = winnerOfMatchEleven;
            }
            else
            {
                loserOfThirdRoundMatchTen = winnerOfMatchTen;
                winnerOfThirdRoundMatchTen = winnerOfMatchEleven;
            }

            if (conferenceAWinCounter[10] == 4)
            {
                winnerOfThirdRoundMatchEleven = loserOfMatchNine;
                loserOfThirdRoundMatchEleven = loserOfMatchTwelve;
            }
            else
            {
                loserOfThirdRoundMatchEleven = loserOfMatchNine;
                winnerOfThirdRoundMatchEleven = loserOfMatchTwelve;
            }

            if (conferenceAWinCounter[11] == 4)
            {
                winnerOfThirdRoundMatchTwelve = loserOfMatchTen;
                loserOfThirdRoundMatchTwelve = loserOfMatchEleven;
            }
            else
            {
                loserOfThirdRoundMatchTwelve = loserOfMatchTen;
                winnerOfThirdRoundMatchTwelve = loserOfMatchEleven;
            }

            if (conferenceBWinCounter[8] == 4)
            {
                winnerOfThirdRoundMatchThirteen = winnerOfMatchThirteen;
                loserOfThirdRoundMatchThirteen = winnerOfMatchSixteen;
            }
            else
            {
                loserOfThirdRoundMatchThirteen = winnerOfMatchThirteen;
                winnerOfThirdRoundMatchThirteen = winnerOfMatchSixteen;
            }

            if (conferenceBWinCounter[9] == 4)
            {
                winnerOfThirdRoundMatchForteen = winnerOfMatchForteen;
                loserOfThirdRoundMatchForteen = winnerOfMatchFifteen;
            }
            else
            {
                loserOfThirdRoundMatchForteen = winnerOfMatchForteen;
                winnerOfThirdRoundMatchForteen = winnerOfMatchFifteen;
            }

            if (conferenceBWinCounter[10] == 4)
            {
                winnerOfThirdRoundMatchFifteen = loserOfMatchThirteen;
                loserOfThirdRoundMatchFifteen = loserOfMatchSixteen;
            }
            else
            {
                loserOfThirdRoundMatchFifteen = loserOfMatchThirteen;
                winnerOfThirdRoundMatchFifteen = loserOfMatchSixteen;
            }

            if (conferenceBWinCounter[11] == 4)
            {
                winnerOfThirdRoundMatchSixteen = loserOfMatchForteen;
                loserOfThirdRoundMatchSixteen = loserOfMatchFifteen;
            }
            else
            {
                loserOfThirdRoundMatchSixteen = loserOfMatchForteen;
                winnerOfThirdRoundMatchSixteen = loserOfMatchFifteen;
            }
        }
        private void thirdRound()
        {
            gamesPlayed = 0;
            conferenceAWinCounter = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            conferenceBWinCounter = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            while (gamesPlayed < 7)
            {
                formulaBasketball.startingGame = gamesPlayed + 2;
                formulaBasketball.gameResultsContents += "Game " + (formulaBasketball.startingGame - 1) + ",Home,Score,Away,Score\n";
                if (conferenceAWinCounter[0] != 4 && conferenceAWinCounter[7] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfThirdRoundMatchOne).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfThirdRoundMatchTwo).getLeagueRank())
                    {
                        higherSeed = winnerOfThirdRoundMatchOne;
                        lowerSeed = winnerOfThirdRoundMatchTwo;
                    }
                    else
                    {
                        higherSeed = winnerOfThirdRoundMatchTwo;
                        lowerSeed = winnerOfThirdRoundMatchOne;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfThirdRoundMatchOne) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfThirdRoundMatchOne) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfThirdRoundMatchOne,winnerOfThirdRoundMatchTwo);
                    if (flag) conferenceAWinCounter[0]++;
                    else conferenceAWinCounter[7]++;
                }
                if (conferenceAWinCounter[1] != 4 && conferenceAWinCounter[6] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfThirdRoundMatchFour).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfThirdRoundMatchThree).getLeagueRank())
                    {
                        higherSeed = winnerOfThirdRoundMatchFour;
                        lowerSeed = winnerOfThirdRoundMatchThree;
                    }
                    else
                    {
                        higherSeed = winnerOfThirdRoundMatchThree;
                        lowerSeed = winnerOfThirdRoundMatchFour;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfThirdRoundMatchFour) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfThirdRoundMatchFour) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfThirdRoundMatchFour,winnerOfThirdRoundMatchThree);
                    if (flag) conferenceAWinCounter[1]++;
                    else conferenceAWinCounter[6]++;
                }
                if (conferenceAWinCounter[2] != 4 && conferenceAWinCounter[5] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfThirdRoundMatchOne).getLeagueRank() < formulaBasketball.create.getTeam(loserOfThirdRoundMatchTwo).getLeagueRank())
                    {
                        higherSeed = loserOfThirdRoundMatchOne;
                        lowerSeed = loserOfThirdRoundMatchTwo;
                    }
                    else
                    {
                        higherSeed = loserOfThirdRoundMatchTwo;
                        lowerSeed = loserOfThirdRoundMatchOne;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfThirdRoundMatchOne) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfThirdRoundMatchOne) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfThirdRoundMatchOne,loserOfThirdRoundMatchTwo);
                    if (flag) conferenceAWinCounter[2]++;
                    else conferenceAWinCounter[5]++;
                }
                if (conferenceAWinCounter[3] != 4 && conferenceAWinCounter[4] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfThirdRoundMatchFour).getLeagueRank() < formulaBasketball.create.getTeam(loserOfThirdRoundMatchThree).getLeagueRank())
                    {
                        higherSeed = loserOfThirdRoundMatchFour;
                        lowerSeed = loserOfThirdRoundMatchThree;
                    }
                    else
                    {
                        higherSeed = loserOfThirdRoundMatchThree;
                        lowerSeed = loserOfThirdRoundMatchFour;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfThirdRoundMatchFour) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfThirdRoundMatchFour) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfThirdRoundMatchFour,loserOfThirdRoundMatchThree);
                    if (flag) conferenceAWinCounter[3]++;
                    else conferenceAWinCounter[4]++;
                }
                if (conferenceBWinCounter[0] != 4 && conferenceBWinCounter[7] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfThirdRoundMatchFive).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfThirdRoundMatchSix).getLeagueRank())
                    {
                        higherSeed = winnerOfThirdRoundMatchFive;
                        lowerSeed = winnerOfThirdRoundMatchSix;
                    }
                    else
                    {
                        higherSeed = winnerOfThirdRoundMatchSix;
                        lowerSeed = winnerOfThirdRoundMatchFive;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfThirdRoundMatchFive) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfThirdRoundMatchFive) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfThirdRoundMatchFive,winnerOfThirdRoundMatchSix);
                    if (flag) conferenceBWinCounter[0]++;
                    else conferenceBWinCounter[7]++;
                }
                if (conferenceBWinCounter[1] != 4 && conferenceBWinCounter[6] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfThirdRoundMatchEight).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfThirdRoundMatchSeven).getLeagueRank())
                    {
                        higherSeed = winnerOfThirdRoundMatchEight;
                        lowerSeed = winnerOfThirdRoundMatchSeven;
                    }
                    else
                    {
                        higherSeed = winnerOfThirdRoundMatchSeven;
                        lowerSeed = winnerOfThirdRoundMatchEight;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfThirdRoundMatchEight) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfThirdRoundMatchEight) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfThirdRoundMatchEight,winnerOfThirdRoundMatchSeven);
                    if (flag) conferenceBWinCounter[1]++;
                    else conferenceBWinCounter[6]++;
                }
                if (conferenceBWinCounter[2] != 4 && conferenceBWinCounter[5] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfThirdRoundMatchFive).getLeagueRank() < formulaBasketball.create.getTeam(loserOfThirdRoundMatchSix).getLeagueRank())
                    {
                        higherSeed = loserOfThirdRoundMatchFive;
                        lowerSeed = loserOfThirdRoundMatchSix;
                    }
                    else
                    {
                        higherSeed = loserOfThirdRoundMatchSix;
                        lowerSeed = loserOfThirdRoundMatchFive;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfThirdRoundMatchFive) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfThirdRoundMatchFive) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfThirdRoundMatchFive,loserOfThirdRoundMatchSix);
                    if (flag) conferenceBWinCounter[2]++;
                    else conferenceBWinCounter[5]++;
                }
                if (conferenceBWinCounter[3] != 4 && conferenceBWinCounter[4] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfThirdRoundMatchEight).getLeagueRank() < formulaBasketball.create.getTeam(loserOfThirdRoundMatchSeven).getLeagueRank())
                    {
                        higherSeed = loserOfThirdRoundMatchEight;
                        lowerSeed = loserOfThirdRoundMatchSeven;
                    }
                    else
                    {
                        higherSeed = loserOfThirdRoundMatchSeven;
                        lowerSeed = loserOfThirdRoundMatchEight;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfThirdRoundMatchEight) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfThirdRoundMatchEight) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfThirdRoundMatchEight,loserOfThirdRoundMatchSeven);
                    if (flag) conferenceBWinCounter[3]++;
                    else conferenceBWinCounter[4]++;
                }
                if (conferenceAWinCounter[8] != 4 && conferenceAWinCounter[15] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfThirdRoundMatchNine).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfThirdRoundMatchTen).getLeagueRank())
                    {
                        higherSeed = winnerOfThirdRoundMatchNine;
                        lowerSeed = winnerOfThirdRoundMatchTen;
                    }
                    else
                    {
                        higherSeed = winnerOfThirdRoundMatchTen;
                        lowerSeed = winnerOfThirdRoundMatchNine;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfThirdRoundMatchNine) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfThirdRoundMatchNine) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfThirdRoundMatchNine,winnerOfThirdRoundMatchTen);
                    if (flag) conferenceAWinCounter[8]++;
                    else conferenceAWinCounter[15]++;
                }
                if (conferenceAWinCounter[9] != 4 && conferenceAWinCounter[14] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfThirdRoundMatchTwelve).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfThirdRoundMatchEleven).getLeagueRank())
                    {
                        higherSeed = winnerOfThirdRoundMatchTwelve;
                        lowerSeed = winnerOfThirdRoundMatchEleven;
                    }
                    else
                    {
                        higherSeed = winnerOfThirdRoundMatchEleven;
                        lowerSeed = winnerOfThirdRoundMatchTwelve;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfThirdRoundMatchTwelve) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfThirdRoundMatchTwelve) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfThirdRoundMatchTwelve,winnerOfThirdRoundMatchEleven);
                    if (flag) conferenceAWinCounter[9]++;
                    else conferenceAWinCounter[14]++;
                }
                if (conferenceAWinCounter[10] != 4 && conferenceAWinCounter[13] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfThirdRoundMatchNine).getLeagueRank() < formulaBasketball.create.getTeam(loserOfThirdRoundMatchTen).getLeagueRank())
                    {
                        higherSeed = loserOfThirdRoundMatchNine;
                        lowerSeed = loserOfThirdRoundMatchTen;
                    }
                    else
                    {
                        higherSeed = loserOfThirdRoundMatchTen;
                        lowerSeed = loserOfThirdRoundMatchNine;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfThirdRoundMatchNine) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfThirdRoundMatchNine) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfThirdRoundMatchNine,loserOfThirdRoundMatchTen);
                    if (flag) conferenceAWinCounter[10]++;
                    else conferenceAWinCounter[13]++;
                }
                if (conferenceAWinCounter[11] != 4 && conferenceAWinCounter[12] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfThirdRoundMatchTwelve).getLeagueRank() < formulaBasketball.create.getTeam(loserOfThirdRoundMatchEleven).getLeagueRank())
                    {
                        higherSeed = loserOfThirdRoundMatchTwelve;
                        lowerSeed = loserOfThirdRoundMatchEleven;
                    }
                    else
                    {
                        higherSeed = loserOfThirdRoundMatchEleven;
                        lowerSeed = loserOfThirdRoundMatchTwelve;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfThirdRoundMatchTwelve) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfThirdRoundMatchTwelve) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfThirdRoundMatchTwelve,loserOfThirdRoundMatchEleven);
                    if (flag) conferenceAWinCounter[11]++;
                    else conferenceAWinCounter[12]++;
                }
                if (conferenceBWinCounter[8] != 4 && conferenceBWinCounter[15] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfThirdRoundMatchThirteen).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfThirdRoundMatchForteen).getLeagueRank())
                    {
                        higherSeed = winnerOfThirdRoundMatchThirteen;
                        lowerSeed = winnerOfThirdRoundMatchForteen;
                    }
                    else
                    {
                        higherSeed = winnerOfThirdRoundMatchForteen;
                        lowerSeed = winnerOfThirdRoundMatchThirteen;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfThirdRoundMatchThirteen) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfThirdRoundMatchThirteen) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfThirdRoundMatchThirteen,winnerOfThirdRoundMatchForteen);
                    if (flag) conferenceBWinCounter[8]++;
                    else conferenceBWinCounter[15]++;
                }
                if (conferenceBWinCounter[9] != 4 && conferenceBWinCounter[14] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(winnerOfThirdRoundMatchSixteen).getLeagueRank() < formulaBasketball.create.getTeam(winnerOfThirdRoundMatchFifteen).getLeagueRank())
                    {
                        higherSeed = winnerOfThirdRoundMatchSixteen;
                        lowerSeed = winnerOfThirdRoundMatchFifteen;
                    }
                    else
                    {
                        higherSeed = winnerOfThirdRoundMatchFifteen;
                        lowerSeed = winnerOfThirdRoundMatchSixteen;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != winnerOfThirdRoundMatchSixteen) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == winnerOfThirdRoundMatchSixteen) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, winnerOfThirdRoundMatchSixteen,winnerOfThirdRoundMatchFifteen);
                    if (flag) conferenceBWinCounter[9]++;
                    else conferenceBWinCounter[14]++;
                }
                if (conferenceBWinCounter[10] != 4 && conferenceBWinCounter[13] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfThirdRoundMatchThirteen).getLeagueRank() < formulaBasketball.create.getTeam(loserOfThirdRoundMatchForteen).getLeagueRank())
                    {
                        higherSeed = loserOfThirdRoundMatchThirteen;
                        lowerSeed = loserOfThirdRoundMatchForteen;
                    }
                    else
                    {
                        higherSeed = loserOfThirdRoundMatchForteen;
                        lowerSeed = loserOfThirdRoundMatchThirteen;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfThirdRoundMatchThirteen) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfThirdRoundMatchThirteen) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfThirdRoundMatchThirteen,loserOfThirdRoundMatchForteen);
                    if (flag) conferenceBWinCounter[10]++;
                    else conferenceBWinCounter[13]++;
                }
                if (conferenceBWinCounter[11] != 4 && conferenceBWinCounter[12] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(loserOfThirdRoundMatchSixteen).getLeagueRank() < formulaBasketball.create.getTeam(loserOfThirdRoundMatchFifteen).getLeagueRank())
                    {
                        higherSeed = loserOfThirdRoundMatchSixteen;
                        lowerSeed = loserOfThirdRoundMatchFifteen;
                    }
                    else
                    {
                        higherSeed = loserOfThirdRoundMatchFifteen;
                        lowerSeed = loserOfThirdRoundMatchSixteen;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != loserOfThirdRoundMatchSixteen) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == loserOfThirdRoundMatchSixteen) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, loserOfThirdRoundMatchSixteen,loserOfThirdRoundMatchFifteen);
                    if (flag) conferenceBWinCounter[11]++;
                    else conferenceBWinCounter[12]++;
                }
                formulaBasketball.writerContents += "\n";
                bracket.updateThirdRoundScores(conferenceAWinCounter, conferenceBWinCounter);
                gamesPlayed++;


            }

            
            if (conferenceAWinCounter[0] == 4)
            {
                topSeedConferenceA = winnerOfThirdRoundMatchOne;
                secondSeedConferenceA = winnerOfThirdRoundMatchTwo;
            }
            else
            {
                secondSeedConferenceA = winnerOfThirdRoundMatchOne;
                topSeedConferenceA = winnerOfThirdRoundMatchTwo;
            }

            
            if (conferenceAWinCounter[1] == 4)
            {
                thirdSeedConferenceA = winnerOfThirdRoundMatchFour;
                fourthSeedConferenceA = winnerOfThirdRoundMatchThree;
            }
            else
            {
                fourthSeedConferenceA = winnerOfThirdRoundMatchFour;
                thirdSeedConferenceA = winnerOfThirdRoundMatchThree;
            }
            
            if (conferenceAWinCounter[2] == 4)
            {
                fifthSeedConferenceA = loserOfThirdRoundMatchOne;
                sixthSeedConferenceA = loserOfThirdRoundMatchTwo;
            }
            else
            {
                sixthSeedConferenceA = loserOfThirdRoundMatchOne;
                fifthSeedConferenceA = loserOfThirdRoundMatchTwo;
            }
            
            if (conferenceAWinCounter[3] == 4)
            {
                seventhSeedConferenceA = loserOfThirdRoundMatchFour;
                eighthSeedConferenceA = loserOfThirdRoundMatchThree;
            }
            else
            {
                eighthSeedConferenceA = loserOfThirdRoundMatchFour;
                seventhSeedConferenceA = loserOfThirdRoundMatchThree;
            }
            
            if (conferenceBWinCounter[0] == 4)
            {
                topSeedConferenceB = winnerOfThirdRoundMatchFive;
                secondSeedConferenceB = winnerOfThirdRoundMatchSix;

            }
            else
            {
                secondSeedConferenceB = winnerOfThirdRoundMatchFive;
                topSeedConferenceB = winnerOfThirdRoundMatchSix;

            }
            
            if (conferenceBWinCounter[1] == 4)
            {
                thirdSeedConferenceB = winnerOfThirdRoundMatchEight;
                fourthSeedConferenceB = winnerOfThirdRoundMatchSeven;
            }
            else
            {
                fourthSeedConferenceB = winnerOfThirdRoundMatchEight;
                thirdSeedConferenceB = winnerOfThirdRoundMatchSeven;
            }
            
            if (conferenceBWinCounter[2] == 4)
            {
                fifthSeedConferenceB = loserOfThirdRoundMatchFive;
                sixthSeedConferenceB = loserOfThirdRoundMatchSix;
            }
            else
            {
                sixthSeedConferenceB = loserOfThirdRoundMatchFive;
                fifthSeedConferenceB = loserOfThirdRoundMatchSix;
            }
            
            if (conferenceBWinCounter[3] == 4)
            {
                seventhSeedConferenceB = loserOfThirdRoundMatchEight;
                eighthSeedConferenceB = loserOfThirdRoundMatchSeven;
            }
            else
            {
                eighthSeedConferenceB = loserOfThirdRoundMatchEight;
                seventhSeedConferenceB = loserOfThirdRoundMatchSeven;
            }
            
            if (conferenceAWinCounter[8] == 4)
            {
                ninthSeedConferenceA = winnerOfThirdRoundMatchNine;
                tenthSeedConferenceA = winnerOfThirdRoundMatchTen;
            }
            else
            {
                tenthSeedConferenceA = winnerOfThirdRoundMatchNine;
                ninthSeedConferenceA = winnerOfThirdRoundMatchTen;
            }
            
            if (conferenceAWinCounter[9] == 4)
            {
                eleventhSeedConferenceA = winnerOfThirdRoundMatchTwelve;
                twelfthSeedConferenceA = winnerOfThirdRoundMatchEleven;
            }
            else
            {
                twelfthSeedConferenceA = winnerOfThirdRoundMatchTwelve;
                eleventhSeedConferenceA = winnerOfThirdRoundMatchEleven;
            }
            
            if (conferenceAWinCounter[10] == 4)
            {
                thirteenthSeedConferenceA = loserOfThirdRoundMatchNine;
                forteenthSeedConferenceA = loserOfThirdRoundMatchTen;
            }
            else
            {
                forteenthSeedConferenceA = loserOfThirdRoundMatchNine;
                thirteenthSeedConferenceA = loserOfThirdRoundMatchTen;
            }
            
            if (conferenceAWinCounter[11] == 4)
            {
                fifteenthSeedConferenceA = loserOfThirdRoundMatchTwelve;
                sixteenthSeedConferenceA = loserOfThirdRoundMatchEleven;
            }
            else
            {
                sixteenthSeedConferenceA = loserOfThirdRoundMatchTwelve;
                fifteenthSeedConferenceA = loserOfThirdRoundMatchEleven;
            }
            
            if (conferenceBWinCounter[8] == 4)
            {
                ninthSeedConferenceB = winnerOfThirdRoundMatchThirteen;
                tenthSeedConferenceB = winnerOfThirdRoundMatchForteen;
            }
            else
            {
                tenthSeedConferenceB = winnerOfThirdRoundMatchThirteen;
                ninthSeedConferenceB = winnerOfThirdRoundMatchForteen;
            }
            
            if (conferenceBWinCounter[9] == 4)
            {
                eleventhSeedConferenceB = winnerOfThirdRoundMatchSixteen;
                twelfthSeedConferenceB = winnerOfThirdRoundMatchFifteen;
            }
            else
            {
                twelfthSeedConferenceB = winnerOfThirdRoundMatchSixteen;
                eleventhSeedConferenceB = winnerOfThirdRoundMatchFifteen;
            }
            
            if (conferenceBWinCounter[10] == 4)
            {
                thirteenthSeedConferenceB = loserOfThirdRoundMatchThirteen;
                forteenthSeedConferenceB = loserOfThirdRoundMatchForteen;
            }
            else
            {
                forteenthSeedConferenceB = loserOfThirdRoundMatchThirteen;
                thirteenthSeedConferenceB = loserOfThirdRoundMatchForteen;
            }
            
            if (conferenceBWinCounter[11] == 4)
            {
                fifteenthSeedConferenceB = loserOfThirdRoundMatchSixteen;
                sixteenthSeedConferenceB = loserOfThirdRoundMatchFifteen;
            }
            else
            {
                sixteenthSeedConferenceB = loserOfThirdRoundMatchSixteen;
                fifteenthSeedConferenceB = loserOfThirdRoundMatchFifteen;
            }
        }
        private void fourthRound()
        {            
            gamesPlayed = 0;
            conferenceAWinCounter = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            conferenceBWinCounter = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            while (gamesPlayed < 7)
            {
                formulaBasketball.startingGame = gamesPlayed + 2;
                formulaBasketball.gameResultsContents += ("Game " + (formulaBasketball.startingGame - 1) + ",Home,Score,Away,Score\n");
                if (conferenceAWinCounter[0] != 4 && conferenceAWinCounter[7] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(topSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(topSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = topSeedConferenceA;
                        lowerSeed = topSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = topSeedConferenceB;
                        lowerSeed = topSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != topSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == topSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, topSeedConferenceA,topSeedConferenceB);
                    if (flag) conferenceAWinCounter[0]++;
                    else conferenceAWinCounter[7]++;
                }
                if (conferenceAWinCounter[1] != 4 && conferenceAWinCounter[6] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(secondSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(secondSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = secondSeedConferenceA;
                        lowerSeed = secondSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = secondSeedConferenceB;
                        lowerSeed = secondSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != secondSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == secondSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, secondSeedConferenceA,secondSeedConferenceB);
                    if (flag) conferenceAWinCounter[1]++;
                    else conferenceAWinCounter[6]++;
                }
                if (conferenceAWinCounter[2] != 4 && conferenceAWinCounter[5] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(thirdSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(thirdSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = thirdSeedConferenceA;
                        lowerSeed = thirdSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = thirdSeedConferenceB;
                        lowerSeed = thirdSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != thirdSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == thirdSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, thirdSeedConferenceA,thirdSeedConferenceB);
                    if (flag) conferenceAWinCounter[2]++;
                    else conferenceAWinCounter[5]++;
                }
                if (conferenceAWinCounter[3] != 4 && conferenceAWinCounter[4] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(fourthSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(fourthSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = fourthSeedConferenceA;
                        lowerSeed = fourthSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = fourthSeedConferenceB;
                        lowerSeed = fourthSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != fourthSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == fourthSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, fourthSeedConferenceA,fourthSeedConferenceB);
                    if (flag) conferenceAWinCounter[3]++;
                    else conferenceAWinCounter[4]++;
                }
                if (conferenceBWinCounter[0] != 4 && conferenceBWinCounter[7] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(fifthSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(fifthSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = fifthSeedConferenceA;
                        lowerSeed = fifthSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = fifthSeedConferenceB;
                        lowerSeed = fifthSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != fifthSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == fifthSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, fifthSeedConferenceA,fifthSeedConferenceB);
                    if (flag) conferenceBWinCounter[0]++;
                    else conferenceBWinCounter[7]++;
                }
                if (conferenceBWinCounter[1] != 4 && conferenceBWinCounter[6] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(sixthSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(sixthSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = sixthSeedConferenceA;
                        lowerSeed = sixthSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = sixthSeedConferenceB;
                        lowerSeed = sixthSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != sixthSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == sixthSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, sixthSeedConferenceA,sixthSeedConferenceB);
                    if (flag) conferenceBWinCounter[1]++;
                    else conferenceBWinCounter[6]++;
                }
                if (conferenceBWinCounter[2] != 4 && conferenceBWinCounter[5] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(seventhSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(seventhSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = seventhSeedConferenceA;
                        lowerSeed = seventhSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = seventhSeedConferenceB;
                        lowerSeed = seventhSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != seventhSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == seventhSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, seventhSeedConferenceA,seventhSeedConferenceB);
                    if (flag) conferenceBWinCounter[2]++;
                    else conferenceBWinCounter[5]++;
                }
                if (conferenceBWinCounter[3] != 4 && conferenceBWinCounter[4] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(eighthSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(eighthSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = eighthSeedConferenceA;
                        lowerSeed = eighthSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = eighthSeedConferenceB;
                        lowerSeed = eighthSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != eighthSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == eighthSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, eighthSeedConferenceA,eighthSeedConferenceB);
                    if (flag) conferenceBWinCounter[3]++;
                    else conferenceBWinCounter[4]++;
                }
                if (conferenceAWinCounter[8] != 4 && conferenceAWinCounter[15] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(ninthSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(ninthSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = ninthSeedConferenceA;
                        lowerSeed = ninthSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = ninthSeedConferenceB;
                        lowerSeed = ninthSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != ninthSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == ninthSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, ninthSeedConferenceA,ninthSeedConferenceB);
                    if (flag) conferenceAWinCounter[8]++;
                    else conferenceAWinCounter[15]++;
                }
                if (conferenceAWinCounter[9] != 4 && conferenceAWinCounter[14] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(tenthSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(tenthSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = tenthSeedConferenceA;
                        lowerSeed = tenthSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = tenthSeedConferenceB;
                        lowerSeed = tenthSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != tenthSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == tenthSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, tenthSeedConferenceA,tenthSeedConferenceB);
                    if (flag) conferenceAWinCounter[9]++;
                    else conferenceAWinCounter[14]++;
                }
                if (conferenceAWinCounter[10] != 4 && conferenceAWinCounter[13] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(eleventhSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(eleventhSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = eleventhSeedConferenceA;
                        lowerSeed = eleventhSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = eleventhSeedConferenceB;
                        lowerSeed = eleventhSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != eleventhSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == eleventhSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, eleventhSeedConferenceA,eleventhSeedConferenceB);
                    if (flag) conferenceAWinCounter[10]++;
                    else conferenceAWinCounter[13]++;
                }
                if (conferenceAWinCounter[11] != 4 && conferenceAWinCounter[12] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(twelfthSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(twelfthSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = twelfthSeedConferenceA;
                        lowerSeed = twelfthSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = twelfthSeedConferenceB;
                        lowerSeed = twelfthSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != twelfthSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == twelfthSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, twelfthSeedConferenceA,twelfthSeedConferenceB);
                    if (flag) conferenceAWinCounter[11]++;
                    else conferenceAWinCounter[12]++;
                }
                if (conferenceBWinCounter[8] != 4 && conferenceBWinCounter[15] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(thirteenthSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(thirteenthSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = thirteenthSeedConferenceA;
                        lowerSeed = thirteenthSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = thirteenthSeedConferenceB;
                        lowerSeed = thirteenthSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != thirteenthSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == thirteenthSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, thirteenthSeedConferenceA,thirteenthSeedConferenceB);
                    if (flag) conferenceBWinCounter[8]++;
                    else conferenceBWinCounter[15]++;
                }
                if (conferenceBWinCounter[9] != 4 && conferenceBWinCounter[14] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(forteenthSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(forteenthSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = forteenthSeedConferenceA;
                        lowerSeed = forteenthSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = forteenthSeedConferenceB;
                        lowerSeed = forteenthSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != forteenthSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == forteenthSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, forteenthSeedConferenceA,forteenthSeedConferenceB);
                    if (flag) conferenceBWinCounter[9]++;
                    else conferenceBWinCounter[14]++;
                }
                if (conferenceBWinCounter[10] != 4 && conferenceBWinCounter[13] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(fifteenthSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(fifteenthSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = fifteenthSeedConferenceA;
                        lowerSeed = fifteenthSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = fifteenthSeedConferenceB;
                        lowerSeed = fifteenthSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != fifteenthSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == fifteenthSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, fifteenthSeedConferenceA,fifteenthSeedConferenceB);
                    if (flag) conferenceBWinCounter[10]++;
                    else conferenceBWinCounter[13]++;
                }
                if (conferenceBWinCounter[11] != 4 && conferenceBWinCounter[12] != 4)
                {
                    bool flag = false;
                    int higherSeed = 0, lowerSeed = 0;
                    if (formulaBasketball.create.getTeam(sixteenthSeedConferenceA).getLeagueRank() < formulaBasketball.create.getTeam(sixteenthSeedConferenceB).getLeagueRank())
                    {
                        higherSeed = sixteenthSeedConferenceA;
                        lowerSeed = sixteenthSeedConferenceB;
                    }
                    else
                    {
                        higherSeed = sixteenthSeedConferenceB;
                        lowerSeed = sixteenthSeedConferenceA;
                    }
                    if (gamesPlayed != 2 && gamesPlayed != 3 && gamesPlayed != 5)
                    {
                        flag = formulaBasketball.executeGame(false, higherSeed, lowerSeed);
                        if (higherSeed != sixteenthSeedConferenceA) flag = !flag;
                    }
                    else
                    {
                        flag = formulaBasketball.executeGame(false, lowerSeed, higherSeed);
                        if (higherSeed == sixteenthSeedConferenceA) flag = !flag;
                    }
                    //bool flag = formulaBasketball.executeGame(false, sixteenthSeedConferenceA,sixteenthSeedConferenceB);
                    if (flag) conferenceBWinCounter[11]++;
                    else conferenceBWinCounter[12]++;
                }
                formulaBasketball.writerContents += "\n";
                bracket.updateFourthRoundScores(conferenceAWinCounter);
                gamesPlayed++;


            }
            List<team> playoffOrder = new List<team>();
            formulaBasketball.championshipsContents += formulaBasketball.create.getTeam(topSeedConferenceA).ToString() + "\t" + conferenceAWinCounter[0] + "\t\t" + conferenceAWinCounter[7] + "\t" + formulaBasketball.create.getTeam(topSeedConferenceB) + "\t";
            if (conferenceAWinCounter[0] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(topSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(topSeedConferenceB));

                champion = formulaBasketball.create.getTeam(topSeedConferenceA);
                runnerUp = formulaBasketball.create.getTeam(topSeedConferenceB);
            }
            else
            {

                playoffOrder.Add(formulaBasketball.create.getTeam(topSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(topSeedConferenceA));

                champion = formulaBasketball.create.getTeam(topSeedConferenceB);
                runnerUp = formulaBasketball.create.getTeam(topSeedConferenceA);
            }
            if (conferenceAWinCounter[1] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(secondSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(secondSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(secondSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(secondSeedConferenceA));
            }

            if (conferenceBWinCounter[0] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(fifthSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(fifthSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(fifthSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(fifthSeedConferenceA));
            }
            if (conferenceBWinCounter[1] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(sixthSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(sixthSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(sixthSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(sixthSeedConferenceA));
            }
            if (conferenceAWinCounter[2] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(thirdSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(thirdSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(thirdSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(thirdSeedConferenceA));
            }
            if (conferenceAWinCounter[3] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(fourthSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(fourthSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(fourthSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(fourthSeedConferenceA));
            }
            if (conferenceBWinCounter[2] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(seventhSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(seventhSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(seventhSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(seventhSeedConferenceA));
            }
            if (conferenceBWinCounter[3] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(eighthSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(eighthSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(eighthSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(eighthSeedConferenceA));
            }
            if (conferenceAWinCounter[8] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(ninthSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(ninthSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(ninthSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(ninthSeedConferenceA));
            }
            if (conferenceAWinCounter[9] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(tenthSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(tenthSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(tenthSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(tenthSeedConferenceA));
            }

            if (conferenceBWinCounter[8] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(thirteenthSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(thirteenthSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(thirteenthSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(thirteenthSeedConferenceA));
            }
            if (conferenceBWinCounter[9] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(forteenthSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(forteenthSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(forteenthSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(forteenthSeedConferenceA));
            }
            if (conferenceAWinCounter[10] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(eleventhSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(eleventhSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(eleventhSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(eleventhSeedConferenceA));
            }
            if (conferenceAWinCounter[11] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(twelfthSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(twelfthSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(twelfthSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(twelfthSeedConferenceA));
            }
            if (conferenceBWinCounter[10] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(fifteenthSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(fifteenthSeedConferenceB));
            }
            else
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(fifteenthSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(fifteenthSeedConferenceA));
            }
            if (conferenceBWinCounter[11] == 4)
            {
                playoffOrder.Add(formulaBasketball.create.getTeam(sixteenthSeedConferenceA));
                playoffOrder.Add(formulaBasketball.create.getTeam(sixteenthSeedConferenceB));
            }
            else
            {                
                playoffOrder.Add(formulaBasketball.create.getTeam(sixteenthSeedConferenceB));
                playoffOrder.Add(formulaBasketball.create.getTeam(sixteenthSeedConferenceA));
            }
            for (int i = 0; i < playoffOrder.Count; i++ )
            {
                string number = "" + (i+1) + ". ";
                if (i + 1 < 10) number = "0" + (i + 1) + ". ";
                Console.WriteLine(number + playoffOrder[i].ToString());
                playoffOrder[i].SetDraftPlace(32-i);

            }
            formulaBasketball.printFianances();
            
        }
    }
}
