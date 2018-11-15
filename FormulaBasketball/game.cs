using System;
using System.Collections.Generic;

public class game
{
    private team awayTeam, homeTeam;
    private int awayTeamScore, homeTeamScore, staminaRegen, quarterNum;
    private int[] firstQuarterScore, secondQuarterScore, thirdQuarterScore, fourthQuarterScore, OTScore;
    private bool awayTipOff;
    private currentTeam playingAwayTeam, playingHomeTeam;
    private gameWriter gameWriter;
    private FormulaBasketball.Random r;
    private bool injuries;
    public game(gameWriter gameWriter, team away, team home, FormulaBasketball.Random r, bool quarterly = false)
    {
        this.injuries = formulaBasketball.injuries;
        this.gameWriter = gameWriter;
        this.r = r;
        if (gameWriter != null) this.gameWriter.listOfStrings.Add("Game," + away.ToString() + "," + home.ToString());
        firstQuarterScore = new int[] { 0, 0 };
        secondQuarterScore = new int[] { 0, 0 };
        thirdQuarterScore = new int[] { 0, 0 };
        fourthQuarterScore = new int[] { 0, 0 };
        OTScore = new int[] { 0, 0 };

        for (int i = 0; i < away.getSize(); i++)
        {
            away.getPlayer(i).decrementDay();
            away.ProgressInjuries();
        }
        for (int i = 0; i < home.getSize(); i++)
        {
            home.getPlayer(i).decrementDay();
            home.ProgressInjuries();
        }
        awayTeam = away;
        homeTeam = home;

        staminaRegen = 0;

        playingAwayTeam = new currentTeam(awayTeam);
        playingHomeTeam = new currentTeam(homeTeam);

        for (int i = 0; i < away.getSize(); i++)
        {
            away.getPlayer(i).setIsPlaying(false);
            if (away.getPlayer(i).isStarter())
            {
                away.getPlayer(i).setIsPlaying(true);
                if (away.getPlayer(i).getPosition() == 1) playingAwayTeam.center = away.getPlayer(i);
                else if (away.getPlayer(i).getPosition() == 2) playingAwayTeam.powerForward = away.getPlayer(i);
                else if (away.getPlayer(i).getPosition() == 3) playingAwayTeam.smallForward = away.getPlayer(i);
                else if (away.getPlayer(i).getPosition() == 4) playingAwayTeam.shootingGuard = away.getPlayer(i);
                else if (away.getPlayer(i).getPosition() == 5) playingAwayTeam.pointGuard = away.getPlayer(i);
            }

        }

        for (int i = 0; i < home.getSize(); i++)
        {
            home.getPlayer(i).setIsPlaying(false);
            if (home.getPlayer(i).isStarter())
            {
                home.getPlayer(i).setIsPlaying(true);
                if (home.getPlayer(i).getPosition() == 1) playingHomeTeam.center = home.getPlayer(i);
                else if (home.getPlayer(i).getPosition() == 2) playingHomeTeam.powerForward = home.getPlayer(i);
                else if (home.getPlayer(i).getPosition() == 3) playingHomeTeam.smallForward = home.getPlayer(i);
                else if (home.getPlayer(i).getPosition() == 4) playingHomeTeam.shootingGuard = home.getPlayer(i);
                else if (home.getPlayer(i).getPosition() == 5) playingHomeTeam.pointGuard = home.getPlayer(i);
            }
        }
        playingAwayTeam.substitutions(1, getWinner());
        playingHomeTeam.substitutions(1, !getWinner());

        playingAwayTeam.checkTeam();
        playingHomeTeam.checkTeam();

        for(int i = 0; i < 5; i++)
        {
            playingAwayTeam.get(i).addStart();
            playingHomeTeam.get(i).addStart();
        }

        awayTeamScore = 0;
        homeTeamScore = 0;

        quarterNum = 1;

        if (!quarterly)
            startGame();
    }
    public int getQuarterNum()
    {
        return quarterNum;
    }
    public int[] getQuarterOneScore()
    {
        return firstQuarterScore;
    }
    public int[] getQuarterTwoScore()
    {
        return secondQuarterScore;
    }
    public int[] getQuarterThreeScore()
    {
        return thirdQuarterScore;
    }
    public int[] getQuarterFourScore()
    {
        return fourthQuarterScore;
    }
    public int[] getQuarterOTScore()
    {
        return OTScore;
    }
    public bool playNextQuarter()
    {
        if(quarterNum == 1)
        {
            awayTipOff = tipOff();
        }
        if(quarterNum == 1 || quarterNum == 4)
        {
            playQuarter(quarterNum, awayTipOff);
        }
        else if(quarterNum < 4)
        {
            playQuarter(quarterNum, !awayTipOff);
        }
        else
        {
            awayTipOff = tipOff();
            playQuarter(quarterNum, awayTipOff);
        }
        inBetweenQuarters();
        return quarterNum > 4 && awayTeamScore != homeTeamScore;
    }
    private void startGame()
    {
        awayTipOff = tipOff();
        
        playQuarter(quarterNum, awayTipOff);
        firstQuarterScore[0] = awayTeamScore;
        firstQuarterScore[1] = homeTeamScore;
        inBetweenQuarters();
       
        playQuarter(quarterNum, !awayTipOff);
        secondQuarterScore[0] = awayTeamScore - firstQuarterScore[0];
        secondQuarterScore[1] = homeTeamScore - firstQuarterScore[1];
        inBetweenQuarters();
        playQuarter(quarterNum, !awayTipOff);
        thirdQuarterScore[0] = awayTeamScore - secondQuarterScore[0] - firstQuarterScore[0];
        thirdQuarterScore[1] = homeTeamScore - secondQuarterScore[1] - firstQuarterScore[1];
        inBetweenQuarters();
        playQuarter(quarterNum, awayTipOff);
        fourthQuarterScore[0] = awayTeamScore - thirdQuarterScore[0] - secondQuarterScore[0] - firstQuarterScore[0];
        fourthQuarterScore[1] = homeTeamScore - thirdQuarterScore[1] - secondQuarterScore[1] - firstQuarterScore[1];

        int OT = 5;
        while (awayTeamScore == homeTeamScore)
        {

            awayTipOff = tipOff();
            inBetweenQuarters();
            playQuarter(OT++, awayTipOff);
            //System.out.println(OT-1 + " (" + awayTeamScore + " - " + homeTeamScore + ")");
        }
        OTScore[0] = awayTeamScore - fourthQuarterScore[0] - thirdQuarterScore[0] - secondQuarterScore[0] - firstQuarterScore[0];
        OTScore[1] = homeTeamScore - fourthQuarterScore[1] - thirdQuarterScore[1] - secondQuarterScore[1] - firstQuarterScore[1];
        regenStamina();

    }
    private void regenStamina()
    {
        for (int i = 0; i < awayTeam.getSize(); i++)
        {
            awayTeam.getPlayer(i).changeStamina(20);
            awayTeam.getPlayer(i).resetGame();


        }
        for (int i = 0; i < homeTeam.getSize(); i++)
        {
            homeTeam.getPlayer(i).changeStamina(20);
            homeTeam.getPlayer(i).resetGame();
        }

    }
    private void inBetweenQuarters()
    {
        quarterNum++;
        for (int i = 0; i < awayTeam.getSize(); i++)
        {
            awayTeam.getPlayer(i).changeStamina(5);

        }
        for (int i = 0; i < homeTeam.getSize(); i++)
        {
            homeTeam.getPlayer(i).changeStamina(5);
        }
    }
    private bool tipOff()
    {
        double temp = playingAwayTeam.center.getJumpingRating() - playingHomeTeam.center.getJumpingRating();

        
        double temp2 = r.Next(0,10) + temp;
        
        return temp2 > 5;
    }
    private void playQuarter(int quarterNum, bool awayPoss)
    {
        int timeRemaining = 0;
        if (quarterNum < 5)
            timeRemaining = 720;
        else
            timeRemaining = 300;
        while (timeRemaining > 0)
        {
            currentTeam currentTeam = null;
            if (awayPoss) currentTeam = playingAwayTeam;
            else currentTeam = playingHomeTeam;

            
            while (true)
            {
                //Console.WriteLine("Play quarter test for infinite loop");
                int playersInPlay = r.Next(0,9);
                if (playersInPlay == 0)
                {
                    bool[] temp = new bool[] { r.NextDouble() > 0.5, r.NextDouble() > 0.5, r.NextDouble() > 0.5, r.NextDouble() > 0.5, r.NextDouble() > 0.5, r.NextDouble() > 0.5, r.NextDouble() > 0.5 };


                    bool playMaker = true;
                    for (int j = 0; j < temp.Length; j++)
                    {
                        playMaker = temp[j];
                        if (!playMaker) break;
                    }
                    if (!playMaker) playersInPlay = playersInPlay + r.Next(0,2) + 1;
                }
                player[] whichPlayers = new player[playersInPlay + 1];

                if (currentTeam.coach.useSuperStar()) whichPlayers[0] = currentTeam.superStar;
                else whichPlayers[0] = currentTeam.playMaker;


                currentTeam.lastPlayer = whichPlayers[0];
                int counter = 1;
                for (int i = playersInPlay; i > 0; i--)
                {
                    bool flag = false;
                    if (i == 1)
                    {
                        bool[] temp = new bool[] { r.NextDouble() > 0.5, r.NextDouble() > 0.5, r.NextDouble() > 0.5 };


                        bool superStar = true;
                        for (int j = 0; j < temp.Length; j++)
                        {
                            superStar = temp[j];
                            if (!superStar) break;
                        }
                        player tempPlayer = null;
                        tempPlayer = currentTeam.superStar;
                        if (superStar && !tempPlayer.Equals(whichPlayers[counter - 1])) flag = true;
                    }
                    if (!flag)
                    {
                        int temp2 = 0;
                        while (true)
                        {
                            temp2 = r.Next(0,5);
                            if (temp2 + 1 != currentTeam.getPos(currentTeam.lastPlayer)) break;

                        }
                        whichPlayers[counter++] = currentTeam.get(temp2);

                    }
                    else
                    {
                        if (currentTeam.coach.useSuperStar()) whichPlayers[counter++] = currentTeam.superStar;
                        else whichPlayers[counter++] = currentTeam.shooter;
                    }
                    currentTeam.lastPlayer = whichPlayers[counter - 1];


                }
                int playResult = executePlay(whichPlayers, awayPoss);
                if (playResult == 1)
                {
                    awayPoss = !awayPoss;
                    break;
                }

                else if (playResult == 0)
                {
                    break;
                }

            }
            int timePassed = r.Next(0,currentTeam.coach.getPreferredTempo().getRandomTime()) + currentTeam.coach.getPreferredTempo().getMinimumTime();
            if (timePassed > timeRemaining) timePassed = timeRemaining;

           

            staminaRegen += timePassed;
            timeRemaining = timeRemaining - timePassed;
            if (gameWriter != null)
            {
                statWriter awayStats = new statWriter(awayTeam);

                statWriter homeStats = new statWriter(homeTeam);
                gameWriter.listOfStrings.Add(awayTeamScore + "," + homeTeamScore + "," + timeRemaining + "_" + awayStats.ToString() + "_" + homeStats.ToString());
            }
            for (int i = 0; i < 5; i++)
            {
                double temp1 = -60;
                playingHomeTeam.get(i).changeStamina(timePassed / (temp1));
                playingAwayTeam.get(i).changeStamina(timePassed / (temp1));
                playingHomeTeam.get(i).addMinutes(timePassed);
                playingAwayTeam.get(i).addMinutes(timePassed);
            }
            if (staminaRegen >= 60)
            {
                staminaRegen -= 60;
                for (int i = 0; i < awayTeam.getSize(); i++)
                {
                    if (!awayTeam.getPlayer(i).isPlaying()) awayTeam.getPlayer(i).changeStamina(5);

                }
                for (int i = 0; i < homeTeam.getSize(); i++)
                {
                    if (!homeTeam.getPlayer(i).isPlaying()) homeTeam.getPlayer(i).changeStamina(5);

                }
            }
            checkForInjuries(quarterNum, timeRemaining);
            playingAwayTeam.substitutions(quarterNum, getWinner());
            playingHomeTeam.substitutions(quarterNum, !getWinner());

        }
    }
    private void checkForInjuries(int quarterNum, int timeRemaining)
    {
        if (!injuries) return;
        for (int i = 0; i < playingAwayTeam.length; i++)
        {
            double injuryRate = (awayTeam.getTrainer().getInjuryPrevention(playingAwayTeam.get(i)));
            int injury = r.Next(0, (int)Math.Floor(injuryRate));
            if (injury == 500)
            {
                playingAwayTeam.get(i).setInjured(true);
                new Injury(playingAwayTeam.get(i), awayTeam, homeTeam, quarterNum, timeRemaining, awayTeam.getTrainer(), r);
            }
        }
        for (int i = 0; i < playingHomeTeam.length; i++)
        {
            double injuryRate = (homeTeam.getTrainer().getInjuryPrevention(playingHomeTeam.get(i)));
            int injury = r.Next(0,(int)Math.Floor(injuryRate));
            if (injury == 500)
            {
                playingHomeTeam.get(i).setInjured(true);
                new Injury(playingHomeTeam.get(i), awayTeam, homeTeam, quarterNum, timeRemaining, homeTeam.getTrainer(), r);
            }
        }

    }
    
    private int executePlay(player[] Players, bool b)
    {
        bool playIsOver = false;
        int lastPass = 0;
        while (!playIsOver)
        {
            //Console.WriteLine("Execute Play Test for infinite loop");
            for (int i = 0; i < Players.Length - 1; i++)
            {
                int temp = pass(Players[i], Players[i + 1], b);
                if (temp < -6)
                {
                    if (b)
                    {
                        playingHomeTeam.get(Players[i + 1].getPosition() - 1).addSteals(1);
                        playingHomeTeam.get(Players[i + 1].getPosition() - 1).changeStamina(-.1);
                    }
                    else
                    {
                        playingAwayTeam.get(Players[i + 1].getPosition() - 1).addSteals(1);
                        playingAwayTeam.get(Players[i + 1].getPosition() - 1).changeStamina(-.1);
                    }

                    Players[i].addTurnovers(1);
                    Players[i].changeStamina(-.2);

                    playIsOver = true;
                    break;
                }
                else
                {
                    lastPass = temp;
                }
            }
            
            int randomTurnover = r.Next(0,100);
            if (randomTurnover == 4 || randomTurnover == 40 || randomTurnover == 30)
            {
                Players[Players.Length - 1].addTurnovers(1);
                Players[Players.Length - 1].changeStamina(-.2);
                playIsOver = true;
            }
            else if (randomTurnover == 12 || randomTurnover == 3)
            {
                Players[Players.Length - 1].addTurnovers(1);
                Players[Players.Length - 1].changeStamina(-.2);
                if (b) playingHomeTeam.get(Players[Players.Length - 1].getPosition() - 1).addSteals(1);
                else playingAwayTeam.get(Players[Players.Length - 1].getPosition() - 1).addSteals(1);

                playIsOver = true;
            }
            ShotType shot;
            if (!playIsOver)
            {
                //r = new Random();
                int shotType = r.Next(0,20);
                double shotSkill = 0.0;
                if (Players[Players.Length - 1].getJumpShotRating() > Math.Max(Players[Players.Length - 1].getLayupRating(), Players[Players.Length - 1].getDunkRating()))
                {
                    shotType -= 5;
                }
                else if (Players[Players.Length - 1].getJumpShotRating() < Math.Max(Players[Players.Length - 1].getLayupRating(), Players[Players.Length - 1].getDunkRating()))
                {
                    shotType += 5;
                }
                if (shotType > 10)
                {

                    if (lastPass > 5 || Players[Players.Length - 1].getDunkRating() > Players[Players.Length - 1].getLayupRating())
                    {
                        shotSkill = Players[Players.Length - 1].getDunkRating();
                        shot = ShotType.DUNK;
                    }
                    else
                    {
                        shotSkill = Players[Players.Length - 1].getLayupRating();
                        shot = ShotType.LAYUP;
                    }


                }
                else if (shotType >= 3)
                {

                    shotSkill = Players[Players.Length - 1].getJumpShotRating();
                    shot = ShotType.JUMP;
                }
                else
                {
                    shotSkill = Players[Players.Length - 1].getThreeShotRating();
                    shot = ShotType.THREE;
                }

                switch (shot)
                {
                    case ShotType.THREE:
                        if (lastPass < -4) lastPass = 3;
                        else if (lastPass < 0) lastPass = 2;
                        else lastPass = 1;
                        break;
                    case ShotType.JUMP:
                        if (lastPass < -2.5) lastPass = 3;
                        else if (lastPass < 2) lastPass = 2;
                        else lastPass = 1;
                        break;
                    case ShotType.LAYUP:
                        if (lastPass < 2) lastPass = 3;
                        else if (lastPass < 7) lastPass = 2;
                        else lastPass = 1;
                        break;
                    case ShotType.DUNK:
                        if (lastPass < 0) lastPass = 3;
                        else if (lastPass < 6) lastPass = 2;
                        else lastPass = 1;
                        break;
                    default:
                        break;
                }


                if (lastPass == 3 && shotSkill < 8)
                {
                    int tempValue = r.Next(0,20);
                    if (tempValue > 5)
                    {
                        return 2;
                    }
                }
                if (lastPass == 2 && shotSkill < 5)
                {
                    int tempValue = r.Next(0,20);
                    if (tempValue > 10)
                    {
                        return 2;
                    }
                }

                if (shotSkill < 3 && lastPass != 1)
                {
                    int tempValue = r.Next(0,20);
                    if (tempValue > 3)
                    {
                        return 2;
                    }
                }

                player tempDef;
                if (b) tempDef = playingHomeTeam.get(Players[Players.Length - 1].getPosition() - 1);
                else tempDef = playingAwayTeam.get(Players[Players.Length - 1].getPosition() - 1);
                shots takeShot = new shots(lastPass, shotSkill, tempDef.getShotContestRating(), shot, r);
                Players[Players.Length - 1].addShotTaken(1);
                Players[Players.Length - 1].changeStamina(-.5);
                if (b) playingHomeTeam.get(Players[Players.Length - 1].getPosition() - 1).addShotsAttemptedAgainst(1);
                else playingAwayTeam.get(Players[Players.Length - 1].getPosition() - 1).addShotsAttemptedAgainst(1);
                if (b && takeShot.madeShot())
                {

                    if (shotType < 3)
                    {
                        awayTeamScore += 3;
                        Players[Players.Length - 1].addPoints(3);
                        Players[Players.Length - 1].addThreePointerMade(1);
                        Players[Players.Length - 1].addThreeTaken(1);
                        for(int i = 0; i < 5; i++)
                        {
                            playingAwayTeam.get(i).teamPoints += 3;
                            playingHomeTeam.get(i).teamPoints -= 3;
                        }

                    }
                    else
                    {
                        Players[Players.Length - 1].addPoints(2);
                        awayTeamScore += 2;
                        for (int i = 0; i < 5; i++)
                        {
                            playingAwayTeam.get(i).teamPoints += 2;
                            playingHomeTeam.get(i).teamPoints -= 2;
                        }
                    }
                    Players[Players.Length - 1].addShotMade(1);

                }
                else if (takeShot.madeShot())
                {
                    if (shotType < 3)
                    {

                        Players[Players.Length - 1].addPoints(3);
                        homeTeamScore += 3;
                        for (int i = 0; i < 5; i++)
                        {
                            playingAwayTeam.get(i).teamPoints -= 3;
                            playingHomeTeam.get(i).teamPoints += 3;
                        }
                    }
                    else
                    {
                        Players[Players.Length - 1].addPoints(2);
                        homeTeamScore += 2;
                        for (int i = 0; i < 5; i++)
                        {
                            playingAwayTeam.get(i).teamPoints -= 2;
                            playingHomeTeam.get(i).teamPoints += 2;
                        }
                    }
                    Players[Players.Length - 1].addShotMade(1);

                }
                if (takeShot.wasFouled())
                {
                    if (b)
                    {
                        playingHomeTeam.get(Players[Players.Length - 1].getPosition() - 1).addFoul(1);
                    }
                    else
                    {
                        playingAwayTeam.get(Players[Players.Length - 1].getPosition() - 1).addFoul(1);
                    }
                }
                if (takeShot.madeShot())
                {
                    if (b) playingHomeTeam.get(Players[Players.Length - 1].getPosition() - 1).addShotsMadeAgainst(1);
                    else playingAwayTeam.get(Players[Players.Length - 1].getPosition() - 1).addShotsMadeAgainst(1);
                    //r = new Random();
                    int assist = 0;
                    if (Players.Length > 1) assist = (int)(r.Next(0,10) - Players[Players.Length - 2].getPassing() * 2);
                    if (assist < 2 && Players.Length > 1)
                    {
                        Players[Players.Length - 2].addAssists(1);
                    }
                    playIsOver = true;
                    if (takeShot.wasFouled() && shotType < 3)
                    {
                        shots takeFreeThrows = new shots(6, Players[Players.Length - 1].getJumpShotRating(), 0, ShotType.FREE, r);
                        Players[Players.Length - 1].addPoints(takeFreeThrows.getPointsScored());
                        Players[Players.Length - 1].addFreeThrowsTaken(1);
                        Players[Players.Length - 1].addFreeThrowsMade(takeFreeThrows.getPointsScored());
                        if (!b)
                        {
                            homeTeamScore += takeFreeThrows.getPointsScored();
                            for (int i = 0; i < 5; i++)
                            {
                                playingAwayTeam.get(i).teamPoints -= takeFreeThrows.getPointsScored();
                                playingHomeTeam.get(i).teamPoints += takeFreeThrows.getPointsScored();
                            }
                        }
                        else
                        {
                            awayTeamScore += takeFreeThrows.getPointsScored();
                            for (int i = 0; i < 5; i++)
                            {
                                playingAwayTeam.get(i).teamPoints += takeFreeThrows.getPointsScored();
                                playingHomeTeam.get(i).teamPoints -= takeFreeThrows.getPointsScored();
                            }
                        }
                    }
                }
                else
                {
                    if (takeShot.wasFouled() && shotType < 3)
                    {
                        shots takeFreeThrows = new shots(5, Players[Players.Length - 1].getJumpShotRating(), 0, ShotType.FREE, r);
                        Players[Players.Length - 1].addPoints(takeFreeThrows.getPointsScored());
                        Players[Players.Length - 1].addFreeThrowsTaken(3);
                        Players[Players.Length - 1].addFreeThrowsMade(takeFreeThrows.getPointsScored());
                        if (!b) homeTeamScore += takeFreeThrows.getPointsScored();
                        else awayTeamScore += takeFreeThrows.getPointsScored();
                    }
                    else if (takeShot.wasFouled())
                    {
                        shots takeFreeThrows = new shots(4, Players[Players.Length - 1].getJumpShotRating(), 0, ShotType.FREE, r);
                        Players[Players.Length - 1].addPoints(takeFreeThrows.getPointsScored());
                        Players[Players.Length - 1].addFreeThrowsTaken(2);
                        Players[Players.Length - 1].addFreeThrowsMade(takeFreeThrows.getPointsScored());
                        if (!b)
                        {
                            homeTeamScore += takeFreeThrows.getPointsScored();
                            for (int i = 0; i < 5; i++)
                            {
                                playingAwayTeam.get(i).teamPoints -= takeFreeThrows.getPointsScored();
                                playingHomeTeam.get(i).teamPoints += takeFreeThrows.getPointsScored();
                            }
                        }
                        else
                        {
                            awayTeamScore += takeFreeThrows.getPointsScored();
                            for (int i = 0; i < 5; i++)
                            {
                                playingAwayTeam.get(i).teamPoints += takeFreeThrows.getPointsScored();
                                playingHomeTeam.get(i).teamPoints -= takeFreeThrows.getPointsScored();
                            }
                        }
                    }
                    else if (shotType < 3)
                    {

                        Players[Players.Length - 1].addThreeTaken(1);
                    }


                    bool reboundResult = !rebound(b);
                    if (reboundResult) return 1;
                    else return 0;
                }


            }


        }
        return 1;


    }
    private bool rebound(bool b)
    {
        
        player offensivePlayer = null, defensivePlayer = null;
        bool reboundOne = r.NextDouble() > 0.5;
        bool reboundTwo = r.NextDouble() > 0.5;
        bool reboundThree = r.NextDouble() > 0.5;
;
        if (reboundOne && reboundTwo && reboundThree)
        {
            if (b)
            {
                if (playingAwayTeam.coach.useSuperStar()) defensivePlayer = playingAwayTeam.superStar;
                else defensivePlayer = playingAwayTeam.rebounder;
                if (playingHomeTeam.coach.useSuperStar()) offensivePlayer = playingHomeTeam.superStar;
                else offensivePlayer = playingHomeTeam.rebounder;

            }
            else
            {
                if (playingAwayTeam.coach.useSuperStar()) offensivePlayer = playingAwayTeam.superStar;
                else offensivePlayer = playingAwayTeam.rebounder;
                if (playingHomeTeam.coach.useSuperStar()) defensivePlayer = playingHomeTeam.superStar;
                else defensivePlayer = playingHomeTeam.rebounder;
            }
        }
        else
        {
            int temp3 = r.Next(0,101);


            if (temp3 > 70)
            {
                if (b)
                {
                    offensivePlayer = playingHomeTeam.get(0);
                    defensivePlayer = playingAwayTeam.get(0);
                }
                else
                {
                    offensivePlayer = playingAwayTeam.get(0);
                    defensivePlayer = playingHomeTeam.get(0);
                }
            }
            else if (temp3 > 45)
            {
                if (b)
                {
                    offensivePlayer = playingHomeTeam.get(1);
                    defensivePlayer = playingAwayTeam.get(1);
                }
                else
                {
                    offensivePlayer = playingAwayTeam.get(1);
                    defensivePlayer = playingHomeTeam.get(1);
                }
            }
            else if (temp3 > 30)
            {
                if (b)
                {
                    offensivePlayer = playingHomeTeam.get(2);
                    defensivePlayer = playingAwayTeam.get(2);
                }
                else
                {
                    offensivePlayer = playingAwayTeam.get(2);
                    defensivePlayer = playingHomeTeam.get(2);
                }
            }
            else if (temp3 > 15)
            {
                if (b)
                {
                    offensivePlayer = playingHomeTeam.get(3);
                    defensivePlayer = playingAwayTeam.get(3);
                }
                else
                {
                    offensivePlayer = playingAwayTeam.get(3);
                    defensivePlayer = playingHomeTeam.get(3);
                }
            }
            else
            {
                if (b)
                {
                    offensivePlayer = playingHomeTeam.get(4);
                    defensivePlayer = playingAwayTeam.get(4);
                }
                else
                {
                    offensivePlayer = playingAwayTeam.get(4);
                    defensivePlayer = playingHomeTeam.get(4);
                }
            }

        }
        int temp = r.Next(0,10);


        Object[] arr = getReboundResult(offensivePlayer.getJumpingRating(), defensivePlayer.getJumpingRating());
        bool retVal = (bool)arr[0];
        double temp2 = Math.Abs((double)arr[1] - (double)arr[2]);
        if (retVal)
        {
            defensivePlayer.addRebound(1);
            defensivePlayer.addDefensiveRebound(1);
            if (temp == 5 && temp2 < 1)
            {
                defensivePlayer.addTurnovers(1);
                retVal = !retVal;
            }
        }
        else
        {
            offensivePlayer.addRebound(1);
            offensivePlayer.addOffensiveRebound(1);
            if (temp == 5 && temp2 < 1)
            {
                offensivePlayer.addTurnovers(1);
                retVal = !retVal;
            }

        }
        return retVal;
    }
    private Object[] getReboundResult(double offenseSkill, double defenseSkill)
    {
        bool madeShot = true;
        double temp = offenseSkill - defenseSkill;

        
        double num = 25 + (r.Next(0,5) - 2);
        num = num + (temp);
        double temp2 = r.Next(0,105);

        if (temp2 < num) madeShot = false;
        //if((Math.floor(temp2) == 3 && Math.round(temp2+.25) == 3) || (Math.floor(temp2) == 6 && Math.round(temp2+.4) == 6))
        Object[] retVal = new Object[] { madeShot, temp2, num };
        return retVal;
    }
    private int pass(player player1, player player2, bool b)
    {

        double temp = player1.getPassing()
            + player2.getSeperation();
        double temp2;
        if (b) temp2 = playingHomeTeam.get(player2.getPosition() - 1).getDefenseIQRating();
        else temp2 = playingAwayTeam.get(player2.getPosition() - 1).getDefenseIQRating();

        
        int temp3 = r.Next(0,8) - 3;

        return (int)((temp + temp3) - temp2);
    }

    public bool getWinner()
    {

        return awayTeamScore > homeTeamScore;

    }
    public int getAwayTeamScore()
    {
        return awayTeamScore;
    }
    public int getHomeTeamScore()
    {
        return homeTeamScore;
    }
}
