﻿using System;
using System.Collections;
using System.Collections.Generic;
using FormulaBasketball;
using System.Globalization;
using System.Drawing;

[Serializable]
public class team : IComparable<team>,  IEnumerable<player>
{
    private Coach coach;
    private List<player> players;
    private String teamName, threeLetterAbbreviation;
    private int[] playersPerPos;
    private int pointsScored, pointsAgainst;
    private int divisionRank, conferenceRank, leagueRank, teamNum;
    private Queue<Int32> lastGames;
    private Stadium stadium;
    private teamResults teamResults;
    private int fianance;
    private Expenses expenses;
    private Trainer trainer;
    private double sponserMoney;
    private double currentSponsers;
    private double[] totalIncome;
    private int travelCosts, weeklyTravel;
    private Merchandise merchandise;
    private int seasonMerchandiseRevenue;
    private FormulaBasketball.Random r;
    private int streak;
    private List<int> lastTen;
    private List<player> retiredList;
    private Record currentSeason, currentPlayoffs, allTime, allTimePlayoffs, divisionRecord, conferenceRecord;
    private Record[] currentSeasonVsTeam, allTimeVsTeam;
    public team(String teamName, FormulaBasketball.Random r)
    {
        this.r = r;
        merchandise = new Merchandise(r);
        // ticket sales, concession sales, shared revenue, sponsor money
        totalIncome = new double[] { 0, 0, 0, 0 };
        coach = null;
        this.teamName = teamName;
        players = new List<player>();
        playersPerPos = new int[5];
        currentSeason = new Record();
        currentPlayoffs = new Record();
        divisionRecord = new Record();
        conferenceRecord = new Record();
        currentSeasonVsTeam = new Record[32];
        allTimeVsTeam = new Record[32];
        for (int i = 0; i < currentSeasonVsTeam.Length; i++ )
        {
            currentSeasonVsTeam[i] = new Record();
            allTimeVsTeam[i] = new Record();
        }
        pointsScored = 0;
        pointsAgainst = 0;
        lastGames = new Queue<Int32>();
        threeLetterAbbreviation = teamName.Substring(0, 3);
        fianance = 50000000;
        lastTen = new List<int>();
        streak = 0;
    }

    

    public team(String teamName, String threeLetter, FormulaBasketball.Random r)
    {
        this.r = r;
        merchandise = new Merchandise(r);
        // ticket sales, concession sales, shared revenue, sponsor money
        totalIncome = new double[] { 0, 0, 0, 0 };
        coach = null;
        this.teamName = teamName;
        players = new List<player>();
        playersPerPos = new int[5];
        currentSeason = new Record();
        currentPlayoffs = new Record();
        divisionRecord = new Record();
        conferenceRecord = new Record();
        currentSeasonVsTeam = new Record[32];
        allTimeVsTeam = new Record[32];
        for (int i = 0; i < currentSeasonVsTeam.Length; i++)
        {
            currentSeasonVsTeam[i] = new Record();
            allTimeVsTeam[i] = new Record();
        }
        pointsScored = 0;
        pointsAgainst = 0;
        lastGames = new Queue<Int32>();
        threeLetterAbbreviation = threeLetter;
        fianance = 50000000;
        lastTen = new List<int>();
        streak = 0;
    }
    public void endSeason()
    {
        streak = 0;
        lastTen = new List<int>();

        allTime.AddLosses(currentSeason.GetLosses());
        allTime.AddWins(currentSeason.GetWins());
        allTimePlayoffs.AddWins(currentPlayoffs.GetWins());
        allTimePlayoffs.AddLosses(currentPlayoffs.GetLosses());

        
        for (int i = 0; i < currentSeasonVsTeam.Length; i++)
        {
            allTimeVsTeam[i].AddWins(currentSeasonVsTeam[i].GetWins());
            allTimeVsTeam[i].AddLosses(currentSeasonVsTeam[i].GetLosses());
            currentSeasonVsTeam[i] = new Record();
            
        }

        divisionRecord = new Record();
        conferenceRecord = new Record();
        currentSeason = new Record();
        currentPlayoffs = new Record();
        pointsScored = 0;
        pointsAgainst = 0;
        lastGames = new Queue<Int32>();
    }
    public void Reset()
    {
        streak = 0;
        lastTen = new List<int>();

        for (int i = 0; i < currentSeasonVsTeam.Length; i++)
        {
            currentSeasonVsTeam[i] = new Record();

        }

        foreach(player player in players)
        {
            player.Reset();
        }

        divisionRecord = new Record();
        conferenceRecord = new Record();
        currentSeason = new Record();
        currentPlayoffs = new Record();
        pointsScored = 0;
        pointsAgainst = 0;
        lastGames = new Queue<Int32>();
    }
    public int getNumPlayersByPos(int pos)
    {
        int retVal = 0;
        for(int i = 0; i < players.Count; i++)
        {
            if (pos == players[i].getPosition()) retVal++;
        }
        return retVal;
    }
    public List<player> ClearPlayers()
    {
        List<player> retVal = new List<player>();
        foreach(player p in players)
        {
            retVal.Add(p);
        }
        players = new List<player>();
        for (int i = 0; i < 5; i++ )
        {
            playersPerPos[i] = 0;
        }
            return retVal;
    }
    
    private void ResetPlayersPerPosition()
    {
        playersPerPos = new int[5];
        foreach(player p in players)
        {
            playersPerPos[p.getPosition() - 1]++;
        }
    }
    // TODO: fix when I actually make the AI algorithms to include actual resizing, not just downsizing
    public void ResizeRoster(FreeAgents freeAgents)
    {
        ResetPlayersPerPosition();
        List<player> cutPlayers = ReorderRoster(freeAgents);
        foreach(player p in cutPlayers)
            affiliate.addPlayer(p);
    }

    public void CreateRoster(FreeAgents freeAgents)
    {
        ResetPlayersPerPosition();
        List<player> cutPlayers = ReorderRoster(freeAgents, true);
        freeAgents.Add(cutPlayers);
    }
    private List<player> ReorderRoster(FreeAgents freeAgents, bool potential = false)
    {
        List<player> retVal = new List<player>();
        player[] orderedRoster = new player[15];
        for(int i = 0; i < players.Count; i++)
        {
            player currPlayer = players[i];
            int position = currPlayer.getPosition() - 1;
            while(true)
            {
                if(position > 14)
                {
                    retVal.Add(currPlayer);
                    break;
                }
                else if(orderedRoster[position] == null)
                {
                    orderedRoster[position] = currPlayer;
                    break;
                }
                else if (currPlayer.getOverall(null, potential) > orderedRoster[position].getOverall(null, potential))
                {
                    player temp = orderedRoster[position];
                    orderedRoster[position] = currPlayer;
                    currPlayer = temp;
                }
                position += 5;
            }
        }
        for (int i = 0; i < orderedRoster.Length; i++)
        {
           if(orderedRoster[i] == null)
           {
               int pos = ((i % 5) + 1);
               addPlayer(freeAgents.GetTopPlayerByPos((i % 5) + 1));
               return ReorderRoster(freeAgents);
           }
        }
        players = new List<player>();
        for(int i = 0; i < orderedRoster.Length; i++)
        {
            players.Add(orderedRoster[i]);
        }
        return retVal;

    }
    private team affiliate;
    public void SetAffiliate(team team, bool setOther = true)
    {
        affiliate = team;
        if(setOther)team.SetAffiliate(this, false);
    }
    public team GetAffiliate()
    {
        return affiliate;
    }
    public List<player> resignPlayers(FormulaBasketball.Random r)
    {
        throw new NotImplementedException();
    }

    public void addRetiredPlayer(player player)
    {
        if(retiredList == null)
        {
            retiredList = new List<player>();
        }
        retiredList.Add(player);
    }

    public void offerToFreeAgents(List<player> freeAgency, FormulaBasketball.Random r)
    {
        throw new NotImplementedException();
    }

    public void removeRetiredPlayers()
    {
        if (retiredList == null) return;
        foreach(player player in retiredList)
        {
            players.Remove(player);
        }
        retiredList = null;
    }
    public int getNumberPlayers()
    {
        return players.Count;
    }

    public String getStreak()
    {
        String retVal = "";
        if (streak > 0) retVal = "W";
        else retVal = "L";

        retVal += "" + Math.Abs(streak);


        return retVal;
    }

    public void swapStarters(int previousStarter, int newStarter)
    {
        players[previousStarter].setStarter(false);
        players[newStarter].setStarter(true);
    }
    public player findPlayerByName(String name)
    {
        foreach(player p in players)
        {
            if (p.getName().Equals(name)) return p;
        }
        Console.WriteLine(name + " not found");
        return null;
    }
    public String getTopTen()
    {
        int wins = 0, losses = 0;
        for(int i = 0; i < lastTen.Count; i++)
        {
            if (lastTen[i] == 1) wins++;
            else losses++;
        }
        return wins + " - " + losses;
    }
    public char getDivisionLetter(int division = -1)
    {
        if(division == -1)division = getDivision();
        switch (division)
        {
            case 1:
                return 'A';
            case 2:
                return 'B';
            case 3:
                return 'C';
            case 4:
                return 'D';
        }
        return '0';
    }

    

    internal void setLastThreeLetters(string text)
    {
        threeLetterAbbreviation = text;
    }

    internal void setTeamName(string text)
    {
        teamName = text;
    }

    public void setBestStarters()
    {
        for (int i = 0; i < 5; i++)
        {
            List<player> tempList = new List<player>();
            for (int j = 0; j < players.Count; j++)
            {
                if (players[j].getPosition() == i + 1)
                {
                    tempList.Add(players[j]);
                }
            }
            tempList.Sort();
            tempList[tempList.Count - 1].setStarter(true);
            for (int j = 0; j < tempList.Count-1; j++)
            {
                tempList[j].setStarter(false);
            }
        }
    }
    public String getThreeLetters()
    {
        return threeLetterAbbreviation;
    }
    public void setRandom(FormulaBasketball.Random r)
    {
        this.r = r;
        merchandise = new Merchandise(r);
    }
    public Merchandise getMerchandise()
    {
        return merchandise;
    }
    public int getTravelCosts()
    {
        return travelCosts;
    }
    public void setSponserMoney(double money)
    {
        sponserMoney = money;
    }
    public void addSponsers(double[] arr)
    {
        expenses.setSponsers(arr);
    }
    public void setExpenses(double[] arr)
    {
        expenses = new Expenses(arr);
    }
    public int getFianances()
    {
        return fianance;
    }
    public void setFianances(int money, bool b)
    {
        fianance += money;
        if (b) totalIncome[1] += money;
        else totalIncome[0] += money;
    }
    public teamResults getTeamResults()
    {
        return teamResults;
    }
    public void setTeamResults(teamResults results)
    {
        teamResults = results;
    }
    public void createStadium(float[] arr)
    {
        stadium = new Stadium(arr);
    }
    public Stadium getStadium()
    {
        return stadium;
    }
    public void addCoach(Coach coach)
    {
        this.coach = coach;
    }
    public Coach getCoach()
    {
        if (coach == null) 
        {
            coach = new Coach(ToString() + " Coach", 65, 90, 0, 0, 0, 0, new Tempo(1), coachShotType.BALANCED, ssInvolvment.MEDIUM, r);
        }
        return coach;
    }
    public void addPlayer(player newPlayer)
    {
        players.Add(newPlayer);
        newPlayer.setTeam(this);
        addPos(newPlayer.getPosition() - 1);
    }
    public player getPlayer(int playerNum)
    {
        return players[playerNum];
    }
    public void removePlayer(int playerNum)
    {

        players.Remove(players[playerNum]);
    }
    public List<player> getAllPlayer()
    {
        return players;
    }
    public override String ToString()
    {
        return teamName;
    }
    public int getSize()
    {
        return players.Count;
    }
    private void addPos(int pos)
    {
        playersPerPos[pos]++;
    }
    public int getCenters()
    {
        return playersPerPos[0];
    }
    public int getPowerForwards()
    {
        return playersPerPos[1];
    }
    public int getSmallForwards()
    {
        return playersPerPos[2];
    }
    public int getShootingGuards()
    {
        return playersPerPos[3];
    }
    public int getPointGuards()
    {
        return playersPerPos[4];
    }
    protected void AddPoints(int i)
    {
        pointsScored = pointsScored + i;

    }
    public int getPoints()
    {
        return pointsScored;
    }
    protected void AddPointsAgainst(int i)
    {
        pointsAgainst = pointsAgainst + i;

    }
    public int getPointsAgainst()
    {
        return pointsAgainst;
    }
    public virtual void AddResult(int opponent, int teamScore, int opposingScore, bool isPlayoffs = false)
    {
        bool conferenceOpponent = false, divisionalOpponent = false;
        if (getDivisionLetter().Equals(getDivisionLetter(opponent)))
        {
            conferenceOpponent = true;
            divisionalOpponent = true;
        }
        else if ((opponent < 16 && teamNum < 16) || (opponent > 15 && teamNum > 15)) conferenceOpponent = true;

        if (teamScore > opposingScore && !isPlayoffs) AddWin(conferenceOpponent, divisionalOpponent, opponent);
        else if (!isPlayoffs) AddLoss(conferenceOpponent, divisionalOpponent, opponent);
        else if (teamScore > opposingScore && isPlayoffs) AddPlayoffWin();
        else AddPlayoffLoss();

        AddPoints(teamScore);
        AddPointsAgainst(opposingScore);

        
    }


    private void AddWin(bool conferenceOpponent, bool divisionalOpponent, int opponent)
    {
        if (conferenceOpponent) conferenceRecord.AddWins();
        if (divisionalOpponent) divisionRecord.AddWins();
        currentSeason.AddWins(); 
        currentSponsers += sponserMoney;
        lastThreeGames(1);
        currentSeasonVsTeam[opponent].AddWins();
    }
    private void AddPlayoffWin()
    {
        currentPlayoffs.AddWins();
        currentSponsers += sponserMoney * 2;
        lastThreeGames(1);
    }
    private void AddLoss(bool conferenceOpponent, bool divisionalOpponent, int opponent)
    {
        if (conferenceOpponent) conferenceRecord.AddLosses();
        if (divisionalOpponent) divisionRecord.AddLosses();
        currentSeason.AddLosses();
        lastThreeGames(0);
        currentSeasonVsTeam[opponent].AddLosses();
    }
    private void AddPlayoffLoss()
    {
        currentPlayoffs.AddLosses();
        lastThreeGames(0);
    }

    public virtual int getWins()
    {
        if (currentSeason == null) currentSeason = new Record();
        return currentSeason.GetWins();
    }
   
    public int getDivisionWins()
    {
        if (divisionRecord == null) divisionRecord = new Record();
        return divisionRecord.GetWins();
    }
    
    public int getConferenceWins()
    {
        if (conferenceRecord == null) conferenceRecord = new Record();
        return conferenceRecord.GetWins();
    }

    public virtual int getLosses()
    {
        if (currentSeason == null) currentSeason = new Record();
        return currentSeason.GetLosses();
    }
   
    public int getDivisionLosses()
    {
        if (divisionRecord == null) divisionRecord = new Record();
        return divisionRecord.GetLosses();
    }
    
    public int getConferenceLosses()
    {
        if (conferenceRecord == null) conferenceRecord = new Record();
        return conferenceRecord.GetLosses();
    }
    /*
     * return codes:
     * 0: Three Losses
     * 1: Two Losses
     * 2: One Loss
     * 3: Zero Losses
     */
    public int lastThreeGames(int num)
    {
        
        if (num != -1)
        {
            if (lastGames.Count == 3) lastGames.Dequeue();
            lastGames.Enqueue(num);
            lastTen.Add(num);
            if (lastTen.Count == 11)
            {
                lastTen.RemoveAt(0);
            }
            if (streak > 0 && num == 1) streak++;
            else if (streak < 0 && num == 0) streak--;
            else if (streak > 0) streak = -1;
            else streak = 1;
        }


        int retVal = 0;


        int temp = 0;

        for (int i = 0; i < lastGames.Count; i++)
        {
            temp = lastGames.Dequeue();
            retVal += temp;
            lastGames.Enqueue(temp);
        }


        return retVal;
    }
    public player GetPlayerByID(int id)
    {
        foreach(player player in players)
        {
            if (player.GetPlayerID() == id) return player;
        }
        return null;
    }
    
    public void setModifier(Modifier modifier)
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].setShootingModifier(modifier.getShootingModifier());
            players[i].setDefensiveModifier(modifier.getDefenseModifier());
            players[i].setOtherModifier(modifier.getOtherModifier());
        }

    }

    public void removePlayer(player player)
    {
        players.Remove(player);
    }

    public int getSeasonMerchandise()
    {
        return seasonMerchandiseRevenue;
    }
    public int getDivisionRank()
    {
        return divisionRank;
    }
    public void setDivisionRank(int divisionRank)
    {
        this.divisionRank = divisionRank;
    }
    public int getConferenceRank()
    {
        return conferenceRank;
    }
    public void setConferenceRank(int conferenceRank)
    {
        this.conferenceRank = conferenceRank;
    }
    public int getLeagueRank()
    {
        return leagueRank;
    }
    public void setLeagueRank(int leagueRank)
    {
        this.leagueRank = leagueRank;
    }
    public int CompareTo(team otherTeam)
    {
        if (getWins() == otherTeam.getWins())
        {
            if (this.getPoints() - this.getPointsAgainst() == otherTeam.getPoints() - otherTeam.getPointsAgainst())
            {
                if (this.getPoints() == otherTeam.getPoints()) return this.ToString().CompareTo(otherTeam.ToString());
                return otherTeam.getPoints() - this.getPoints();
            }
            return (otherTeam.getPoints() - otherTeam.getPointsAgainst()) - (this.getPoints() - this.getPointsAgainst());
        }
        return otherTeam.getWins() - getWins();
    }
    public void setTeamNum(int i)
    {
        teamNum = i;

        if (teamNum < 8) Division = 1;
        else if (teamNum < 16) Division = 2;
        else if (teamNum < 24) Division = 3;
        else Division = 4;
    }
    public int getTeamNum()
    {
        return teamNum;
    }
    public void addModifier(Modifier modifier)
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].addShootingModifier(modifier.getShootingModifier());
            players[i].addDefensiveModifier(modifier.getDefenseModifier());
            players[i].addOtherModifier(modifier.getOtherModifier());
        }

    }
    private int Division;
    public void setDivison(int div)
    {
        Division = div;
    }
    public int getDivision()
    {
        return Division;

    }
    private player[] presets = null;
    public void setPresets(player[] presets)
    {
        this.presets = presets;
    }
    public player[] getPresets()
    {
        return presets;
    }
    public Modifier getCoachModifier()
    {
        double offense = 0, defense = 0;

        int offenseNum = r.Next(0, 100);
        //Console.WriteLine(offenseNum + " " + getCoach().getOffenseModifierProbability() + " " + getCoach().getOffenseModifier());
        if (offenseNum < getCoach().getOffenseModifierProbability())
        {
            offense = getCoach().getOffenseModifier();
        }
        int defenseNum = r.Next(0, 100);
        //Console.WriteLine(defenseNum + " " + getCoach().getDefenseModifierProbability() + " " + getCoach().getDefenseModifier());
        if (defenseNum < getCoach().getDefenseModifierProbability())
        {
            defense = getCoach().getDefenseModifier();
        }

        return new changeAbleModifier(offense, defense);
    }
    public void doExpenses()
    {
        totalIncome[3] += currentSponsers + expenses.getWeeklySponser();
        fianance = expenses.chargeExpenses(fianance, currentSponsers);
        fianance += merchandise.getWeeklyRevenue() - weeklyTravel;
        currentSponsers = 0;
        seasonMerchandiseRevenue += merchandise.getWeeklyRevenue();
        weeklyTravel = 0;
    }
    public void addTrainer(Trainer trainer)
    {
        this.trainer = trainer;

    }
    public Trainer getTrainer()
    {
        if(trainer == null)
        {
            trainer = new Trainer(ToString() + " trainer", 5, 5, 0, r);
        }
        return trainer;
    }
    public void homeGameOccurred()
    {
        totalIncome[3] += expenses.getHomeMoneyEarned();
        fianance = expenses.homeGameOccurred(fianance);

    }
    public void setWeeklySponser(int i)
    {
        expenses.setWeeklySponser(i);

    }
    public double[] getTotalIncomes()
    {
        totalIncome[2] = expenses.getSharedRevenue();
        return totalIncome;
    }
    public double[] getTotalExpenses()
    {
        return expenses.getTotalExpenses();
    }
    public void awayGameOccurred(int i, int j)
    {
        int awayDiv = getDivision(i);
        int homeDiv = getDivision(j);

        if (awayDiv == homeDiv)
        {
            travelCosts += 2500;
            weeklyTravel += 2500;
        }
        else
        {
            int awayConf = getConference(i);
            int homeConf = getConference(j);
            if (awayConf == homeConf)
            {
                travelCosts += 3500;
                weeklyTravel += 3500;
            }
            else
            {
                travelCosts += 5000;
                weeklyTravel += 5000;
            }
        }
    }
    private int getDivision(int div)
    {
        if (div < 8) return 1;
        else if (div < 16) return 2;
        else if (div < 24) return 3;
        else return 4;
    }
    private int getConference(int num)
    {
        if (num < 16) return 1;
        else return 2;
    }

    public IEnumerator<player> GetEnumerator()
    {
        return new PlayerEnum(players); 
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator) GetEnumerator();
    }

    public double GetPayroll()
    {
        double payroll = 0.0;
        foreach(player player in players)
        {
            payroll += player.GetMoney();
        }
        return payroll;
    }
    private string colorOne, colorTwo, colorThree, location, city, stadiumName, colorOneName, colorTwoName, colorThreeName;
    private int playoffAppearances;
    private int leagueChampionships, conferenceChampionships, divisionChampionships;

    public void SetTeamInfo(int franchiseWins, int franchiseLosses, int playoffAppearances, int playoffWins, int playoffLosses,
        int divChampionships, int conferenceChampionships, int championships, string colorOne, string colorTwo, string colorThree,
        string location, string stadiumName, string colorOneName, string colorTwoName, string colorThreeName)
    {
        this.colorOne = colorOne;
        this.colorTwo = colorTwo;
        this.colorThree = colorThree;
        this.colorOneName = colorOneName;
        this.colorTwoName = colorTwoName;
        this.colorThreeName = colorThreeName;
        this.location = location;
        this.stadiumName = stadiumName;
        allTime = new Record(franchiseWins, franchiseLosses);
        this.playoffAppearances = playoffAppearances;
        allTimePlayoffs = new Record(playoffWins, playoffLosses);
        this.divisionChampionships = divChampionships;
        this.conferenceChampionships = conferenceChampionships;
        this.leagueChampionships = championships;
        city = location.Split(',')[0];
        currentSeason = new Record();
        currentPlayoffs = new Record();
        divisionRecord = new Record();
        conferenceRecord = new Record();
        currentSeasonVsTeam = new Record[32];
        allTimeVsTeam = new Record[32];
        for (int i = 0; i < currentSeasonVsTeam.Length; i++)
        {
            currentSeasonVsTeam[i] = new Record();
            allTimeVsTeam[i] = new Record();
        }
    }
    public string CreateWikiPage()
    {
        string retVal = "";

        

        string conference = "Southern Conference|Southern";
        if (Division > 2) conference = "Nortern Conference|Northern";
        retVal += "{{Infobox basketball club\n";
        retVal += "| color1 = " + colorOne + "\n";
        retVal += "| color2 = " + colorTwo + "\n";
        retVal += "| color3 = " + colorThree + "\n";
        retVal += "| name = " + teamName + "\n";
        retVal += "| current = UBA Season 6\n";
        retVal += "| logo = "+ teamName +" .png\n";
        retVal += "| imagesize = 200px\n";
        retVal += "| conference = [[" + conference + "]]\n";
        retVal += "| division = [[Division " + getDivisionLetter() + "|" + getDivisionLetter() + "]]\n";
        retVal += "| founded = 2016\n";
        retVal += "| arena = [[" + stadiumName +"]]\n";
        retVal += "| location = [[" + city + "|" + location + "]]\n";
        retVal += "| colors = " + colorOneName + ", "+ colorTwoName + ", " + colorThreeName +" {{color box|" + colorOne + "}} {{color box|" + colorTwo + "}} {{color box|" + colorThree + "}}\n";
        retVal += "| owner =\n";
        retVal += "| manager = \n";
        retVal += "| president = \n";
        retVal += "| coach = " + coach.getName() + "\n";
        retVal += "| affiliation = [[" + affiliate.ToString() + "]]\n";
        retVal += "| franchise_wins = '''" + allTime.GetWins() + "'''\n";
        retVal += "| franchise_losses = '''" + allTime.GetLosses() + "'''\n";
        retVal += "| playoff_appearances = '''" + playoffAppearances + "'''\n";
        retVal += "| playoff_wins = '''" + allTimePlayoffs.GetWins() + "'''\n";
        retVal += "| playoff_losses = '''" + allTimePlayoffs.GetLosses() + "'''\n";
        retVal += "| league_champs = '''" + leagueChampionships + "'''\n";
        retVal += "| conf_champs = '''" + conferenceChampionships + "'''\n";
        retVal += "| div_champs = '''" + divisionChampionships + "''' \n";
        retVal += "| ret_nums = '''0'''\n";
        retVal += "| website = " + teamName.ToLower().Replace(" ", "") +".com\n";
        retVal += "| h_body =\n";
        retVal += "| h_pattern_b =\n";
        retVal += "| h_shorts =\n";
        retVal += "| h_pattern_s =\n";
        retVal += "| a_body =\n";
        retVal += "| a_pattern_b =\n";
        retVal += "| a_shorts = \n";
        retVal += "| a_pattern_s = \n";
        retVal += "| 3_body = \n";
        retVal += "| 3_pattern_b = \n";
        retVal += "| 3_shorts = \n";
        retVal += "| 3_pattern_s = \n";
        retVal += "}}\n\n";
        retVal += "The '''" + teamName + "''' are a basketball team based in " + location + ". They compete in the [[Universalis Basketball Association|Universalis Basketball Association]] (UBA) and is in [[Division "+ getDivisionLetter() + "]] of the " + conference.Split('|')[0] + ".\n";

        retVal += "\n===Roster===\n{|class=\"wikitable\"\n";
        retVal += "|+ "+ teamName +" \n|-\n";
        retVal += "!Pos\n!Name\n!Age\n!Overall\n";

        foreach (player p in players)
        {
            retVal += "|-\n";
            retVal += "|" + p.GetPositionAsString() + "\n|" + p.getName() + "\n|" + p.age + "\n|" + String.Format("{0:0.00}", p.getOverall()) + "\n";
        }
        retVal += "|}\n";
        

        return retVal;
    }
    public string PrintChampionships()
    {
        return ToString() + "\t" + divisionChampionships + "\t" + conferenceChampionships + "\t" + leagueChampionships +"\n";
    }
    public void AddDivisionChampionship()
    {
        divisionChampionships++;
    }
    public void SetCoach(Coach coach)
    {
        this.coach = coach;
    }
    public void AddConferenceChampionship()
    {
        conferenceChampionships++;
    }

    public void AddChampionship()
    {
        leagueChampionships++;
        AddConferenceChampionship();
    }
}
class PlayerEnum : IEnumerator<player>
{
    private List<player> players;
    private int location = -1;
    public PlayerEnum(List<player> players)
    {
        this.players = players;
    }

    public player Current
    {
        get
        {
            try
            {
                return players[location];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    object IEnumerator.Current { get { return Current; } }

    public void Dispose()
    {
        
    }

    public bool MoveNext()
    {
        location++;
        return location < players.Count;
    }

    public void Reset()
    {
        location = -1;
    }
    private Subs[] subs; 
    public void SetSubstitutionTimes(Subs[] subs)
    {
        this.subs = subs;
    }
    public player GetSub(int position, int timeLeft)
    {
        // old fashioned coach
        if (subs == null) return null;
        return subs[position].GetSubstitution(timeLeft);
    }
}
class Subs
{
    private int[] subTimesPerPosition;
    private player[] playersPerPosition;
    public Subs(int[] subTimesPerPosition, player[] playersPerPosition )
    {
        this.subTimesPerPosition = subTimesPerPosition;
        this.playersPerPosition = playersPerPosition;
    }
    public player GetSubstitution(int timeLeft)
    {
        int timePassed = 0;
        int i;
        for(i = 0; i < subTimesPerPosition.Length; i++)
        {
            timePassed += subTimesPerPosition[i];
            if(timePassed >= timeLeft)
            {
                i--;
            }
        }
        return playersPerPosition[i];
    }
}
