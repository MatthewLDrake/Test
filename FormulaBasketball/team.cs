using System;
using System.Collections;
using System.Collections.Generic;
using FormulaBasketball;
using System.Globalization;
using System.Drawing;
using System.IO;

[Serializable]
public class team : IComparable<team>,  IEnumerable<player>
{
    protected Coach coach;
    protected List<player> players;
    protected String teamName, threeLetterAbbreviation;
    protected int[] playersPerPos;
    protected int pointsScored, pointsAgainst;
    protected int divisionRank, conferenceRank, leagueRank, teamNum;
    protected Queue<Int32> lastGames;
    protected Stadium stadium;
    protected teamResults teamResults;
    protected int fianance;
    protected Expenses expenses;
    protected Trainer trainer;
    protected double sponserMoney;
    protected double currentSponsers;
    protected double[] totalIncome;
    protected int travelCosts, weeklyTravel;
    protected Merchandise merchandise;
    protected int seasonMerchandiseRevenue;
    protected FormulaBasketball.Random r;
    protected int streak;
    protected List<int> lastTen;
    protected List<player> retiredList;
    private Record currentSeason, currentPlayoffs, allTime, allTimePlayoffs, divisionRecord, conferenceRecord;
    private Record[] currentSeasonVsTeam, allTimeVsTeam;
    private SeasonRecords seasonRecords;
    private List<DraftPick> picks, nextSeasonPicks;
    private DisabledLists sevenGame, fifteenGame, season;
    protected player[] activePlayers;
    private double penalty;
    private team affiliate;
    private bool moreImportantTeam;
    private bool firstFree = true;
    private int draftPlace;
    private int Division;
    private player[] presets = null;
    private string colorOne, colorTwo, colorThree, location, city, stadiumName, colorOneName, colorTwoName, colorThreeName;
    private int playoffAppearances;
    private int leagueChampionships, conferenceChampionships, divisionChampionships;
    private Scout scout;
    public int elo;
    public team(String teamName, String threeLetter, FormulaBasketball.Random r)
    {
        nextSeasonPicks = new List<DraftPick>();
        picks = new List<DraftPick>();
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
        allTime = new Record();
        allTimePlayoffs = new Record();
        currentSeasonVsTeam = new Record[32];
        allTimeVsTeam = new Record[32];
        activePlayers = new player[15];
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
    public void AddDraftPick(DraftPick pick, bool currSeason = true)
    {
        if (currSeason)
        {
            if (picks == null) picks = new List<DraftPick>();
            picks.Add(pick);
        }
        else
        {
            if (nextSeasonPicks == null) nextSeasonPicks = new List<DraftPick>();
            nextSeasonPicks.Add(pick);
        }
    }
    public void RemoveDraftPick(DraftPick pick, bool currSeason = true)
    {
        if(currSeason)
        {
            picks.Remove(pick);
        }
        else
        {
            nextSeasonPicks.Remove(pick);
        }
    }
    private void CheckSeasonRecords(int pointsFor, int pointsAgainst, int gameNum, string teamAgainst)
    {
        if(seasonRecords == null)
        {
            seasonRecords = new SeasonRecords(this);
        }
        seasonRecords.Update(activePlayers, pointsFor, pointsAgainst, teamAgainst, gameNum);
        foreach(player p in this)
        {
            p.updatePlayerRecords(gameNum, teamAgainst);
        }
    }
    private List<player> cutPlayers;
    public void AddCutPlayer(player p)
    {
        if (cutPlayers == null)
            cutPlayers = new List<player>();
        cutPlayers.Add(p);
    }
    public void PrintSeasonRecords()
    {
        seasonRecords.Print(currentSeasonVsTeam);
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
    public void ResetStats()
    {
        draftPlace = 0;
    }
    public void AddFutureDraftPick(DraftPick pick)
    {
        if (nextSeasonPicks == null) nextSeasonPicks = new List<DraftPick>();
        nextSeasonPicks.Add(pick);
    }
    public void ProgressPlayers(bool human)
    {        
        foreach(player p in offseasonPlayers)
        {
            p.Develop(r);
            p.Develop(r);
            p.Develop(r);
        }
        if (human)
        {
            int positionUpgrade = 5, playerUpgrade = 1;
            activePlayers[playerUpgrade].Develop(r);
            foreach (player p in activePlayers)
            {
                if (p.getPosition() == positionUpgrade)
                    p.Develop(r);
            }
        }
        else
        {
            int lowestPos = int.MaxValue, currValue = 0;
            int lowestStarter = int.MaxValue, currV = 0;
            for(int i = 0; i < 5; i++)
            {
                int temp = ((int)(activePlayers[i].getOverall() + activePlayers[i + 5].getOverall())) / 2;
                if (temp < lowestPos)
                {
                    lowestPos = temp;
                    currValue = i + 1;
                }
                if (activePlayers[i].getOverall() < lowestStarter)
                {
                    lowestStarter = (int)activePlayers[i].getOverall();
                    currV = i;
                }
            }
            activePlayers[currV].Develop(r);
            foreach(player p in activePlayers)
            {
                if (p.getPosition() == currValue)
                    p.Develop(r);
            }
        }
    }
    public void FinishDraft()
    {
        /*foreach(DraftPick pick in picks)
        {
            addPlayer(pick.GetPlayerSelected());
        }*/
        picks = nextSeasonPicks;
        nextSeasonPicks = new List<DraftPick>();
        nextSeasonPicks.Add(new DraftPick(1, this, this));
        nextSeasonPicks.Add(new DraftPick(2, this, this));
    }
    public void Reset()
    {
        streak = 0;
        lastTen = new List<int>();

        for (int i = 0; i < currentSeasonVsTeam.Length; i++)
        {
            currentSeasonVsTeam[i] = new Record();

        }

        foreach(player player in activePlayers)
        {
            if (player == null) continue;
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
        for (int i = 0; i < activePlayers.Length; i++)
        {
            if (activePlayers[i] == null) continue;
            if (pos == activePlayers[i].getPosition()) retVal++;
        }
        return retVal;
    }
   
    public List<player> ClearPlayers()
    {
        List<player> retVal = new List<player>();
        if(activePlayers == null)
        {
            foreach (player p in players)
            {
                if (p == null) continue;
                retVal.Add(p);
            }
            players = new List<player>();
            activePlayers = new player[15];
            for (int i = 0; i < 5; i++)
            {
                playersPerPos[i] = 0;
            }
            return retVal;
        }
        foreach (player p in activePlayers)
        {
            if (p == null) continue;
            retVal.Add(p);
        }
        players = new List<player>();
        activePlayers = new player[15];
        for (int i = 0; i < 5; i++ )
        {
            playersPerPos[i] = 0;
        }
            return retVal;
    }
    
    private void ResetPlayersPerPosition()
    {
        playersPerPos = new int[5];
        foreach (player p in activePlayers)
        {
            if(p != null)
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
    public void removePlayer(List<player> players)
    {
        foreach(player p in players)
        {
            removePlayer(p);
            p.setTeam(null);
        }
    }
    
    public double CapPenalty
    {
        get
        {
            return penalty;
        }
        set
        {
            penalty = value;
        }
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
        for (int i = 0; i < activePlayers.Length; i++)
        {
            player currPlayer = activePlayers[i];
            if (currPlayer == null) continue;
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
        activePlayers = new player[15];
        for(int i = 0; i < orderedRoster.Length; i++)
        {
            activePlayers[i] = orderedRoster[i];
        }
        return retVal;

    }
    
    public void SetAffiliate(team team, bool setOther = true)
    {
        moreImportantTeam = setOther;
        affiliate = team;
        if(setOther)team.SetAffiliate(this, false);
    }
    public team GetAffiliate()
    {
        return affiliate;
    }
    public int GetRankOnTeam(player p)
    {
        int rank = 1;
        foreach (player player in activePlayers)
        {
            if (player == null) continue;
            if(!p.Equals(player) && p.getPosition() == player.getPosition() && p.getOverall() < player.getOverall())rank++;
        }
        return rank;
    }
    public void CheckInjuries(FreeAgents freeAgents)
    {
        return;
        if(sevenGame == null)
        {
            sevenGame = new DisabledLists(7);
            fifteenGame = new DisabledLists(15);
            season = new DisabledLists(84);
        }
        List<player> playersReturning = sevenGame.GetReturningPlayers();
        playersReturning.AddRange(fifteenGame.GetReturningPlayers());
        playersReturning.AddRange(season.GetReturningPlayers());

        foreach(player p in playersReturning)
        {
            addPlayer(p);
        }
        int healthyPlayers = 15;
        foreach (player p in activePlayers)
        {
            if (p == null) continue;
            if (!p.isInjured()) continue;
            else if (p.getInjuryLength() > 84 - currentSeason.GetTotalGames())
            {
                season.AddPlayer(p);
                removePlayer(p);
            }
            else if (p.getInjuryLength() < 7) healthyPlayers--;
            else if (p.getInjuryLength() < 15)
            {
                sevenGame.AddPlayer(p);
                removePlayer(p);
            }
            else
            {
                fifteenGame.AddPlayer(p);
                removePlayer(p);
            }
            
        }

        while (healthyPlayers < 10)
        {
            player toRemove = null;
            int highestLength = 0;
            foreach (player p in activePlayers)
            {
                if (p == null) continue;
                if (p.getInjuryLength() < 7)
                {
                    if(highestLength < p.getInjuryLength())
                    {
                        highestLength = p.getInjuryLength();
                        toRemove = p;
                    }
                }
            }
            sevenGame.AddPlayer(toRemove);
            healthyPlayers++;
        }
        
        for(int i = 0; i < activePlayers.Length; i++)
        {
            if(activePlayers[i] == null)
            {
                int position = i % 5 + 1;
                player newPlayer = freeAgents.GetTopPlayerByPos(position);
                addPlayer(newPlayer);
            }
        }
        bool flag = false;
        while(players.Count > 0)
        {
            flag = true;
            if (moreImportantTeam) affiliate.addPlayer(players[0]);
            players.Remove(players[0]);
        }

        if (flag && moreImportantTeam) affiliate.ReorderRoster(freeAgents, true);

    }
    public List<player> resignPlayers(createTeams create, FormulaBasketball.Random r)
    {
        List<player> players = new List<player>();
        for(int i = 0; i < activePlayers.Length; i++)
        {
            player p = activePlayers[i];
            if (p == null) continue;
            bool onRoster = true;
            if (p.getOverall() < 55) onRoster = false;
            if (p.ContractExpired() && onRoster)
            {
                if(i >= 5 && p.getOverall() < 80)
                {
                    onRoster = false;
                }
                else
                {
                    double shootingPercentage = 0.0, opponentPercentage = 0.0;
                    if (p.getShotsTaken() > 10 && p.getShotsAttemptedAgainst() > 10)
                    {
                        opponentPercentage = ((double)p.getShotsMadeAgainst() / (double)p.getShotsAttemptedAgainst()) * 100;
                        shootingPercentage = ((double)p.getShotsMade() / (double)p.getShotsTaken()) * 100;
                    }
                    double plus_minus = 0.0;
                    if (p.getGamesPlayed() != 0)
                    {
                        plus_minus = ((double)p.teamPoints / (double)p.getGamesPlayed());
                    }

                    plus_minus += shootingPercentage - opponentPercentage;

                    if (r.Next(-5, 5) + plus_minus < 0) onRoster = false;
                    else
                    {
                        onRoster = NegogiateWithPlayer(p, GetRankOnTeam(p), create);
                    }
                }
                

            }
            else if (!p.ContractExpired() && !onRoster) 
            {
                CapPenalty += p.GetMoneyPerYear() / 2;
            }
            if (!onRoster) players.Add(p);
        }
        return players;
    }
    public String GetLocation()
    {
        return location;
    }
    private bool NegogiateWithPlayer(player p, int rank, createTeams create)
    {
        double average = create.GetAverageSalary(rank, p.getPosition());
        double min = create.GetMinSalary(rank, p.getPosition());
        double max = create.GetMaxSalary(rank, p.getPosition());

        int playerRank = create.GetPositionalRank(rank, p.getPosition(), p.getOverall());

        double salary = 0;

        if(playerRank > 16)
        {
            salary = GetY(16, average, 32, min, playerRank) + (r.Next(-25, 25));
            salary = Math.Min(25, Math.Max(1, salary));
        }
        else
        {
            salary = GetY(16, average, 1, max, playerRank) + (r.Next(-25, 25)/10);
            salary = Math.Min(25, Math.Max(1, salary));
        }
        int years = r.Next(1, 5);
        Contract teamOffer = new Contract(years, salary);

        ContractResult result = p.ContractNegotiate(teamOffer, r);
        Contract playerOffer = null;
        while(result.Equals(ContractResult.Continue))
        {
            playerOffer = p.GetCounterOffer(teamOffer, r, playerOffer);
            if (playerOffer.GetMoney() <= teamOffer.GetMoney())
            {
                result = ContractResult.Accept;
                p.SetNewContract(playerOffer);
                break;
            }
            result = ContractNegotiate(playerOffer, teamOffer, playerRank, rank, p);
            if (result.Equals(ContractResult.Continue))
            {
                years = (playerOffer.GetYearsLeft() + teamOffer.GetYearsLeft()) / 2;
                salary = r.Next(((int)Math.Round(teamOffer.GetMoney() * 10)) + 1, ((int)Math.Round(playerOffer.GetMoney() * 10)));
                teamOffer = new Contract(years, salary);
                result = p.ContractNegotiate(teamOffer, r);
            }
            else if (result.Equals(ContractResult.Accept))
            {
                p.SetNewContract(teamOffer);
            }            
        }

        return result.Equals(ContractResult.Accept);
    }

    private ContractResult ContractNegotiate(Contract playerOffer, Contract teamOffer, int positionalRank, int teamRank, player p)
    {
        if ((teamRank == 3 && playerOffer.GetMoney() > 6) || (teamRank == 2 && playerOffer.GetMoney() > 13)) return ContractResult.Reject;

        double shootingPercentage = 0.0, opponentPercentage = 0.0;
        if (p.getShotsTaken() > 10 && p.getShotsAttemptedAgainst() > 10)
        {
            opponentPercentage = ((double)p.getShotsMadeAgainst() / (double)p.getShotsAttemptedAgainst()) * 100;
            shootingPercentage = ((double)p.getShotsMade() / (double)p.getShotsTaken()) * 100;
        }
        double plus_minus = 0.0;
        if (p.getGamesPlayed() != 0)
        {
            plus_minus = ((double)p.teamPoints / (double)p.getGamesPlayed());
        }

        plus_minus += shootingPercentage - opponentPercentage;

        double difference = playerOffer.GetMoney() - teamOffer.GetMoney();

        if (difference < 0) return ContractResult.Accept;

        if (p.getOverall() > 90) return ContractResult.Accept;

        double score = plus_minus * .8 + p.getOverall() * .1 + difference * -1 + r.Next(-3,2);

        if (score > 1) return ContractResult.Accept;
        else if (score > -3) return ContractResult.Continue;
        else return ContractResult.Reject;

    }
    public double GetY(double point1X, double point1Y, double point2X, double point2Y, int x)
    {
        double m = (point2Y - point1Y) / (point2X - point1Y);
        double b = point1Y - (m * point1X);

        return m * x + b;
    }
    public player FindBestPlayerByPos(int pos)
    {
        player retVal = null;
        double bestOverall = 0;
        foreach (player p in activePlayers)
        {
            if (p == null || p.getPosition() != pos) continue;
            if(bestOverall < p.getOverall())
            {
                bestOverall = p.getOverall();
                retVal = p;
            }

        }
        return retVal;
    }
    public player FindBackupByPos(int pos)
    {
        player[] retVal = new player[2];
        double[] bestOverall = new double[]{0,0};
        foreach (player p in activePlayers)
        {
            if (p == null || p.getPosition() != pos) continue;
            if (bestOverall[0] < p.getOverall())
            {
                bestOverall[1] = bestOverall[0];
                bestOverall[0] = p.getOverall();
                retVal[1] = retVal[0];
                retVal[0] = p;
            }
            else if(bestOverall[1] < p.getOverall())
            {
                bestOverall[1] = p.getOverall();
                retVal[1] = p;
            }

        }
        return retVal[1];
    }

    public int GetPositionToDraft(player[] players)
    {
        int positionToDraft = -1;
        double greatestDifferenceInOverall = 0;
        for (int i = 0; i < players.Length; i++ )
        {
            player bestPlayer = FindBestPlayerByPos(i+1);
            if(bestPlayer == null || players[i].getOverall() - bestPlayer.getOverall() > greatestDifferenceInOverall)
            {
                if (bestPlayer == null) greatestDifferenceInOverall = 100;
                else greatestDifferenceInOverall = players[i].getOverall() - bestPlayer.getOverall();
                positionToDraft = i;
            }
        }

        if(positionToDraft == -1)
        {
            List<int> positions = new List<int>();
            for (int i = 0; i < players.Length; i++)
            {
                player bestPlayer = FindBackupByPos(i + 1);
                
                if (bestPlayer == null) 
                {
                    positions.Add(i);
                }
                else if (players[i].getOverall() - bestPlayer.getOverall() > greatestDifferenceInOverall) 
                {
                    greatestDifferenceInOverall = players[i].getOverall() - bestPlayer.getOverall();
                    positionToDraft = i;
                }
            }
            if(positions.Count > 0)
            {
                positionToDraft = r.Select<int>(positions);
            }
            if (positionToDraft == -1)
            {
                int highestAge = 0;
                for (int i = 0; i < players.Length; i++)
                {
                    player bestPlayer = FindBestPlayerByPos(i + 1);
                    if (bestPlayer == null || bestPlayer.age > highestAge)
                    {
                        highestAge = bestPlayer.age;
                        positionToDraft = i;
                    }
                }
            }
        }

        return positionToDraft;
    }
    public List<DraftPick> GetPicks()
    {
        return picks;
    }
    public List<DraftPick> GetNextSeasonPicks()
    {
        return nextSeasonPicks;
    }
    public void ClearDraftPicks()
    {
        picks = new List<DraftPick>();
        nextSeasonPicks = new List<DraftPick>();
    }
    public void addRetiredPlayer(player player)
    {
        if(retiredList == null)
        {
            retiredList = new List<player>();
        }
        retiredList.Add(player);
    }
    
    public void SetFree()
    {
        firstFree = true;
    }
    
    private List<player> Sort(List<player> list)
    {
        player temp = null;
        for (int write = 0; write < list.Count; write++)
        {
            for (int sort = 0; sort < list.Count - 1; sort++)
            {
                if (list[sort].getOverall() < list[sort + 1].getOverall())
                {
                    temp = list[sort + 1];
                    list[sort + 1] = list[sort];
                    list[sort] = temp;
                }
            }
        }
        return list;
    }
    public void removeRetiredPlayers()
    {
        if (retiredList == null) return;
        foreach(player player in retiredList)
        {
            for(int i= 0; i < activePlayers.Length; i++)
            {
                if (activePlayers[i] == null) continue;
                if(activePlayers[i].Equals(player))
                {
                    activePlayers[i] = null;
                    break;
                }
            }
        }
        retiredList = null;
    }
    public int getNumberPlayers()
    {
        return getSize();
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
        activePlayers[previousStarter].setStarter(false);
        activePlayers[newStarter].setStarter(true);
    }
    public player findPlayerByName(String name)
    {
        foreach (player p in activePlayers)
        {
            if (p == null) continue;
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
        int i = 0;
        for (; i < 5; i++)
        {
            activePlayers[i].setStarter(true);
        }
        for(;i<activePlayers.Length;i++)
        {
            activePlayers[i].setStarter(false);
        }
        
    }
    public String getThreeLetters()
    {
        if(threeLetterAbbreviation == null)
            threeLetterAbbreviation = teamName.Substring(0, 3);
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
    public Scout GetScout()
    {
        if(scout == null)
        {
            scout = new Scout(ToString() + " Scout", 20, 80);
        }
        return scout;
    }
    public void SimpleAddPlayer(player newPlayer)
    {
        int pos = newPlayer.getPosition() - 1;
        if (activePlayers == null) activePlayers = new player[15];

        if (activePlayers[pos] == null) activePlayers[pos] = newPlayer;
        else if (activePlayers[pos + 5] == null) activePlayers[pos + 5] = newPlayer;
        else activePlayers[pos + 10] = newPlayer;

        newPlayer.setTeam(this);
        addPos(pos);
    }
    public void addPlayer(player newPlayer)
    {
        if (newPlayer.getTeam() != null) newPlayer.getTeam().removePlayer(newPlayer);

        int pos = newPlayer.getPosition()-1;
        if(activePlayers == null)activePlayers = new player[15];


        List<player> playersAtPos = new List<player>();

        playersAtPos.Add(newPlayer);
        playersAtPos.Add(activePlayers[pos]);
        playersAtPos.Add(activePlayers[pos + 5]);
        playersAtPos.Add(activePlayers[pos + 10]);

        player[] newLocations = new player[4];

        for (int i = 0; i < newLocations.Length; i++)
        {
            player currentPlayer = null;
            double highestOverall = 0;
            foreach (player p in playersAtPos)
            {
                if (p == null) continue;
                if(p.getOverall() > highestOverall)
                {
                    highestOverall = p.getOverall();
                    currentPlayer = p;
                }
            }
            if (currentPlayer != null)
            {
                playersAtPos.Remove(currentPlayer);
                if (i == 3) players.Add(currentPlayer);
            }
            
            if(i != 3)
            {
                activePlayers[pos + (i * 5)] = currentPlayer;
            }
        }
        

        newPlayer.setTeam(this);
        addPos(pos);
    }
    
    public void SetDraftPlace(int place)
    {
        draftPlace = place;
    }
    public int GetDraftPlace()
    {
        return draftPlace;
    }
    public player getPlayer(int playerNum)
    {
        return activePlayers[playerNum];
    }
    public void removePlayer(int playerNum)
    {
        activePlayers[playerNum] = null;
        //players.Remove(players[playerNum]);
    }
    public List<player> getAllPlayer()
    {
        List<player> retVal = new List<player>();
        if (activePlayers == null)
        {
            activePlayers = new player[15];
            return players;
        }
        foreach(player p in activePlayers)
        {
            if (p == null) continue;
            retVal.Add(p);
        }
        return retVal;
    }
    public player[] getActivePlayers()
    {
        return activePlayers;
    }
    public override String ToString()
    {
        return teamName;
    }
    public int getSize()
    {
        int size = 0;
        for (int i = 0; i < activePlayers.Length; i++ )
        {
            if (activePlayers[i] != null) size++;
        }
        return size;
    }
    protected void addPos(int pos)
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
    public void FixTeam()
    {
        foreach (player p in activePlayers)
        {
            p.setTeam(this);
            p.setInjured(false);
            p.setStamina(100);
        }
    }
    public void FixStats()
    {
        foreach (player p in activePlayers)
        {
            p.ResetStats();
        }
    }
    public virtual void AddResult(int opponent, int teamScore, int opposingScore, bool isPlayoffs = false)
    {
        if(conferenceRecord == null)
        {
            currentPlayoffs = new Record();
            currentSeason = new Record();
            conferenceRecord = new Record();
            divisionRecord = new Record();
            currentSeasonVsTeam = new Record[32];
            for (int i = 0; i < currentSeasonVsTeam.Length; i++)
                currentSeasonVsTeam[i] = new Record();

        }
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
        
        CheckSeasonRecords(teamScore, opposingScore, getWins() + getLosses(), formulaBasketball.create.getTeam(opponent).ToString());
        
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
    public void FixDuplicatePlayers()
    {
        for(int i = 0; i < activePlayers.Length; i++)
        {
            if (!activePlayers[i].getTeam().Equals(this))
            {
                CollegePlayerGen playerGen = new CollegePlayerGen(r);
                player newPlayer;
                switch(activePlayers[i].getPosition())
                {
                    case 1:
                        newPlayer = playerGen.GenerateCenter((int)activePlayers[i].getOverall(), activePlayers[i].GetCountry(), activePlayers[i].GetDevelopmentRating(), activePlayers[i].GetPeakStart(), activePlayers[i].GetPeakEnd(), false, activePlayers[i].age, 0);
                        break;
                    case 2:
                        newPlayer = playerGen.GeneratePowerForward((int)activePlayers[i].getOverall(), activePlayers[i].GetCountry(), activePlayers[i].GetDevelopmentRating(), activePlayers[i].GetPeakStart(), activePlayers[i].GetPeakEnd(), false, activePlayers[i].age, 0);
                        break;
                    case 3:
                        newPlayer = playerGen.GenerateSmallForward((int)activePlayers[i].getOverall(), activePlayers[i].GetCountry(), activePlayers[i].GetDevelopmentRating(), activePlayers[i].GetPeakStart(), activePlayers[i].GetPeakEnd(), false, activePlayers[i].age, 0);
                        break;
                    case 4:
                        newPlayer = playerGen.GenerateShootingGuard((int)activePlayers[i].getOverall(), activePlayers[i].GetCountry(), activePlayers[i].GetDevelopmentRating(), activePlayers[i].GetPeakStart(), activePlayers[i].GetPeakEnd(), false, activePlayers[i].age, 0);
                        break;
                    default:
                        newPlayer = playerGen.GeneratePointGuard((int)activePlayers[i].getOverall(), activePlayers[i].GetCountry(), activePlayers[i].GetDevelopmentRating(), activePlayers[i].GetPeakStart(), activePlayers[i].GetPeakEnd(), false, activePlayers[i].age, 0);
                        break;
                }
                List<StatsHolders> thisTeamStats = new List<StatsHolders>(), playerStats = activePlayers[i].GetSeasonStats();
                foreach(StatsHolders stat in playerStats)
                {
                    if (stat.GetTeamFor().Equals(ToString()))
                        thisTeamStats.Add(stat);
                }
                foreach (StatsHolders stat in thisTeamStats)
                {
                    playerStats.Remove(stat);
                }
                activePlayers[i].SetSeasonStats(playerStats);
                newPlayer.SetSeasonStats(thisTeamStats);
                activePlayers[i].SetGamesPlayed(playerStats.Count);
                activePlayers[i] = newPlayer;
                newPlayer.SetNewContract(new Contract(1, 1));
                newPlayer.setTeam(this);
                newPlayer.setInjured(false);
                newPlayer.setStamina(100);

            }
            List<StatsHolders> activePlayersStats = activePlayers[i].GetSeasonStats();
            int gamesPlayed = 0;
            foreach (StatsHolders stat in activePlayersStats)
            {
                if (stat.getMinutes() > 0)
                    gamesPlayed++;
            }
            activePlayers[i].SetGamesPlayed(gamesPlayed);
        }
    }
    public void ReplacePlayer(int activePlayerLoc, player newPlayer)
    {
        activePlayers[activePlayerLoc] = newPlayer;
        newPlayer.setTeam(this);
        newPlayer.setInjured(false);
        newPlayer.setStamina(100);
        newPlayer.SetNewContract(new Contract(1, 1));
        newPlayer.SetSeasonStats(new List<StatsHolders>());
    }
    public void UpdateDraftPicks()
    {
        foreach(DraftPick pick in picks)
        {
            pick.SetSeason(createTeams.currentSeason);
        }
        foreach(DraftPick pick in nextSeasonPicks)
        {
            pick.SetSeason(createTeams.currentSeason + 1);
        }
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
        if (lastGames == null)
        {
            lastGames = new Queue<Int32>();
            lastTen = new List<int>();
        }


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
            else if (num == 0) streak = -1;
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
    private List<player> offseasonPlayers;
    public void StartOffSeason()
    {
        offseasonPlayers = new List<player>(activePlayers);
        offseasonPlayers.AddRange(affiliate.activePlayers);
    }
    public void FinishOffseason(bool human)
    {
        currentPlayoffs = new Record();
        currentSeason = new Record();
        conferenceRecord = new Record();
        divisionRecord = new Record();
         currentSeasonVsTeam = new Record[32];
        for (int i = 0; i < currentSeasonVsTeam.Length; i++)
            currentSeasonVsTeam[i] = new Record();
        
        if (!human)
        {
            offseasonPlayers.Sort();
            offseasonPlayers.Reverse();
        }
        List<player> pgs = new List<player>(), sgs = new List<player>(), pfs = new List<player>(), sfs = new List<player>(), cs = new List<player>();
        foreach (player p in offseasonPlayers)
        {
            if(p != null)
            switch (p.getPosition())
            {
                case 1:
                    cs.Add(p);
                    break;
                case 2:
                    pfs.Add(p);
                    break;
                case 3:
                    sfs.Add(p);
                    break;
                case 4:
                    sgs.Add(p);
                    break;
                case 5:
                    pgs.Add(p);
                    break;
            }
        }
        
            
        activePlayers = new player[15];
        affiliate.activePlayers = new player[15];
        for(int i = 0; i < 6; i++)
        {
            if(i > 2)
            {
                affiliate.activePlayers[(i - 3) * 5] = cs[i];
                affiliate.activePlayers[1 + (i - 3) * 5] = pfs[i];
                affiliate.activePlayers[2 + (i - 3) * 5] = sfs[i];
                affiliate.activePlayers[3 + (i - 3) * 5] = sgs[i];
                affiliate.activePlayers[4 + (i - 3) * 5] = pgs[i];

            }
            else
            {
                activePlayers[i  * 5] = cs[i];
                activePlayers[1 + i * 5] = pfs[i];
                activePlayers[2 + i * 5] = sfs[i];
                activePlayers[3 + i * 5] = sgs[i];
                activePlayers[4 + i * 5] = pgs[i];
            }
        }
    }
    public void TradeOccurred(List<object> tradedItems, List<object> receivedItems, FreeAgents freeAgents, bool human)
    {
        List<player> players = new List<player>(activePlayers);
        players.AddRange(affiliate.activePlayers);

        foreach(object obj in tradedItems)
        {
            if(obj is player)
            {
                players.Remove(obj as player);
            }
            else
            {
                DraftPick pick = obj as DraftPick;
                if(!picks.Remove(pick))
                {
                    nextSeasonPicks.Remove(pick);
                }
            }
        }
        foreach(object obj in receivedItems)
        {
            if (obj is player)
            {
                players.Add(obj as player);
            }
            else
            {
                DraftPick pick = obj as DraftPick;
                if (pick.GetSeason() == createTeams.currentSeason)
                    picks.Add(pick);
                else
                    nextSeasonPicks.Add(pick);
                
            }
        }

        if (human)
        {
            new DepthChart(this, players).ShowDialog();
        }
        else
        {
            players.Sort();
            players.Reverse();

            List<player> pgs = new List<player>(), sgs = new List<player>(), pfs = new List<player>(), sfs = new List<player>(), cs = new List<player>();
            foreach (player p in players)
            {
                if (p != null)
                    switch (p.getPosition())
                    {
                        case 1:
                            cs.Add(p);
                            break;
                        case 2:
                            pfs.Add(p);
                            break;
                        case 3:
                            sfs.Add(p);
                            break;
                        case 4:
                            sgs.Add(p);
                            break;
                        case 5:
                            pgs.Add(p);
                            break;
                    }
            }
            if(cs.Count < 6)
            {
                while(cs.Count < 6)
                {
                    player p = freeAgents.GetTopPlayerByPos(1);
                    cs.Add(p);
                    p.setTeam(this);
                    p.SetNewContract(new Contract(1, 1));
                    p.SetSeasonStats(new List<StatsHolders>());
                }
            }
            else if(cs.Count > 6)
            {
                while (cs.Count > 6)
                {
                    cs[cs.Count - 1].setTeam(null);
                    freeAgents.Add(cs[cs.Count - 1]);
                    cs.Remove(cs[cs.Count - 1]);
                }
            }
            if (pfs.Count < 6)
            {
                while (pfs.Count < 6)
                {
                    player p = freeAgents.GetTopPlayerByPos(2);
                    pfs.Add(p);
                    p.setTeam(this);
                    p.SetNewContract(new Contract(1, 1));
                    p.SetSeasonStats(new List<StatsHolders>());
                }
            }
            else if (pfs.Count > 6)
            {
                while (pfs.Count > 6)
                {
                    pfs[pfs.Count - 1].setTeam(null);
                    freeAgents.Add(pfs[pfs.Count - 1]);
                    pfs.Remove(pfs[pfs.Count - 1]);
                }
            }
            if (sfs.Count < 6)
            {
                while (sfs.Count < 6)
                {
                    player p = freeAgents.GetTopPlayerByPos(3);
                    sfs.Add(p);
                    p.setTeam(this);
                    p.SetNewContract(new Contract(1, 1));
                    p.SetSeasonStats(new List<StatsHolders>());
                }
            }
            else if (sfs.Count > 6)
            {
                while (sfs.Count > 6)
                {
                    sfs[sfs.Count - 1].setTeam(null);
                    freeAgents.Add(sfs[sfs.Count - 1]);
                    sfs.Remove(sfs[sfs.Count - 1]);
                }
            }
            if (sgs.Count < 6)
            {
                while (sgs.Count < 6)
                {
                    player p = freeAgents.GetTopPlayerByPos(4);
                    sgs.Add(p);
                    p.setTeam(this);
                    p.SetNewContract(new Contract(1, 1));
                    p.SetSeasonStats(new List<StatsHolders>());
                }
            }
            else if (sgs.Count > 6)
            {
                while (sgs.Count > 6)
                {
                    sgs[sgs.Count - 1].setTeam(null);
                    freeAgents.Add(sgs[sgs.Count - 1]);
                    sgs.Remove(sgs[sgs.Count - 1]);
                }
            }
            if (pgs.Count < 6)
            {
                while (pgs.Count < 6)
                {
                    player p = freeAgents.GetTopPlayerByPos(5);
                    pgs.Add(p);
                    p.setTeam(this);
                    p.SetNewContract(new Contract(1, 1));
                    p.SetSeasonStats(new List<StatsHolders>());
                }
            }
            else if (pgs.Count > 6)
            {
                while (pgs.Count > 6)
                {
                    pgs[pgs.Count - 1].setTeam(null);
                    freeAgents.Add(pgs[pgs.Count - 1]);
                    pgs.Remove(pgs[pgs.Count - 1]);
                }
            }

            activePlayers = new player[15];
            affiliate.activePlayers = new player[15];
            for (int i = 0; i < 6; i++)
            {
                if (i > 2)
                {
                    affiliate.activePlayers[(i - 3) * 5] = cs[i];
                    affiliate.activePlayers[1 + (i - 3) * 5] = pfs[i];
                    affiliate.activePlayers[2 + (i - 3) * 5] = sfs[i];
                    affiliate.activePlayers[3 + (i - 3) * 5] = sgs[i];
                    affiliate.activePlayers[4 + (i - 3) * 5] = pgs[i];

                }
                else
                {
                    activePlayers[i * 5] = cs[i];
                    activePlayers[1 + i * 5] = pfs[i];
                    activePlayers[2 + i * 5] = sfs[i];
                    activePlayers[3 + i * 5] = sgs[i];
                    activePlayers[4 + i * 5] = pgs[i];
                }
            }
        }
        
    }
    public void Stamina()
    {
        foreach (player p in activePlayers)
            p.setStamina(100);
    }
    public void OffSeasonAddPlayer(player p)
    {
        p.setTeam(this);
        offseasonPlayers.Add(p);
        p.SetStatus(2);
    }
    public List<player> GetOffSeasonPlayers(bool includeDLeague = true)
    {
        if(includeDLeague)
            return offseasonPlayers;
        List<player> list = new List<player>(offseasonPlayers);

        foreach(player p in affiliate)
        {
            list.Remove(p);
        }
        return list;
    }
    public void OffSeasonRemovePlayers(List<player> players)
    {
        foreach (player p in players)
            OffSeasonRemovePlayer(p);
    }
    public void OffSeasonRemovePlayer(player p)
    {
        offseasonPlayers.Remove(p);
        p.setTeam(null);
    }

    public player GetPlayerByID(int id)
    {
        foreach(player player in activePlayers)
        {
            if (player == null) continue;
            if (player.GetPlayerID() == id) return player;
        }
        return null;
    }
    public double GetStarterOveralls()
    {
        double overall = 0.0;
        for (int i = 0; i < 5; i++)
        {
            overall += activePlayers[i].getOverall();
        }
        return overall / 5;
    }
    public void setModifier(Modifier modifier)
    {
        for (int i = 0; i < activePlayers.Length; i++)
        {
            if (activePlayers[i] != null)
            {
                activePlayers[i].setShootingModifier(modifier.getShootingModifier());
                activePlayers[i].setDefensiveModifier(modifier.getDefenseModifier());
                activePlayers[i].setOtherModifier(modifier.getOtherModifier());
            }
            
        }

    }

    public void removePlayer(player player)
    {
        for (int i = 0; i < activePlayers.Length; i++ )
        {
            if (player.Equals(activePlayers[i]))
            {
                activePlayers[i] = null;
                break;
            }
                
        }
    }
    public void ProgressInjuries()
    {
        if(sevenGame == null)
        {
            return;
        }
        sevenGame.ProgressInjury();
        fifteenGame.ProgressInjury();
        season.ProgressInjury();
    }
    public void EndOfSeason(FreeAgents freeAgents)
    {
        List<player> recoveredPlayers = season.GetAllPlayers();
        foreach(player p in players)
        {
            if (p.getInjuryLength() < 15)
            {
                sevenGame.AddPlayer(p);
                removePlayer(p);
            }
            else if(p.getInjuryLength() > 15)
            {
                fifteenGame.AddPlayer(p);
                removePlayer(p);
            }
            else
            {
                addPlayer(p);
            }
        }
        bool flag = false;
        while (players.Count > 0)
        {
            flag = true;
            if (moreImportantTeam) affiliate.addPlayer(players[0]);
            players.Remove(players[0]);
        }

        if (flag && moreImportantTeam) affiliate.ReorderRoster(freeAgents, true);
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
        for (int i = 0; i < activePlayers.Length; i++)
        {
            if(activePlayers[i] != null)
            {
                activePlayers[i].addShootingModifier(modifier.getShootingModifier());
                activePlayers[i].addDefensiveModifier(modifier.getDefenseModifier());
                activePlayers[i].addOtherModifier(modifier.getOtherModifier());
            }
            
        }

    }
    
    public void setDivison(int div)
    {
        Division = div;
    }
    public int getDivision()
    {
        return Division;

    }
    
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
        if (totalIncome == null)
        {
            totalIncome = new double[] { 0, 0, 0, 0 };
            merchandise = new Merchandise(r);
        }
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
        return new PlayerEnum(activePlayers); 
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator) GetEnumerator();
    }

    public double GetPayroll(bool offseason = false)
    {        
        double payroll = CapPenalty;
        if (offseason)
        {
            List<player> players = GetOffSeasonPlayers(false);
            foreach (player player in players)
            {
                payroll += player.GetMoney();
            }
        }
        else
        {
            foreach (player player in activePlayers)
            {
                if (player == null) continue;
                payroll += player.GetMoney();
            }
        }
        return payroll;
    }
    

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

        foreach (player p in activePlayers)
        {
            if (p == null) continue;
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

    public void SetDepthChart(List<List<player>> players)
    {
        activePlayers = new player[15];
        int curr = 0;
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < players.Count; j++)
            {
                activePlayers[curr] = players[j][i];
                curr++;
            }
        }
        curr = 0;
        affiliate.activePlayers = new player[15];
        for (int i = 3; i < 6; i++)
        {
            for (int j = 0; j < players.Count; j++)
            {
                if(players[j].Count > i)
                    affiliate.activePlayers[curr] = players[j][i];
                curr++;
            }
        }
        offseasonPlayers.Clear();
        foreach (player p in activePlayers)
            offseasonPlayers.Add(p);
        foreach (player p in affiliate.activePlayers)
            offseasonPlayers.Add(p);
    }

    public List<player> GetRoster()
    {
        List<player> bigList = new List<player>(players);
        bigList.AddRange(affiliate.players);
        return bigList;
    }
    private List<player> mockPlayerList;
    public List<player> GetMockRoster()
    {
        if (mockPlayerList == null) mockPlayerList = new List<player>(activePlayers);
        List<player> bigList = new List<player>(mockPlayerList);
        bigList.AddRange(affiliate.activePlayers);
        return bigList;
    }
    public void AddMockedPlayer(player player)
    {
        mockPlayerList.Add(player);
    }
    public void AddDraftedPlayer(player player)
    {
        players.Add(player);
    }

    private DraftStrategy strat;
    public DraftStrategy DraftStrategy
    {
        get
        {
            return strat;
        }
        set
        {
            strat = value;
        }
    }
    public Dictionary<int, Contract> offers;
    public void AddOffer(player p, Contract contract)
    {
        if (offers == null) offers = new Dictionary<int, Contract>();
        if (offers.ContainsKey(p.GetPlayerID())) offers[p.GetPlayerID()] = contract;
        else offers.Add(p.GetPlayerID(), contract);
    }
    public void RemoveOffer(player p)
    {
        if (offers == null) offers = new Dictionary<int, Contract>();
        offers.Remove(p.GetPlayerID());
    }
    public Dictionary<int, Contract> GetOffers()
    {
        return offers;
    }
    public Contract GetContract(player p)
    {
        if (offers != null && offers.ContainsKey(p.GetPlayerID())) return offers[p.GetPlayerID()];
        return null;
    }

    public void OfferFreeAgents(FreeAgents freeAgents, FormulaBasketball.Random r, bool firstRound)
    {
        List<player> c, pf, sf, sg, pg;
        c = freeAgents.GetPlayersByPos(1);
        pf = freeAgents.GetPlayersByPos(2);
        sf = freeAgents.GetPlayersByPos(3);
        sg = freeAgents.GetPlayersByPos(4);
        pg = freeAgents.GetPlayersByPos(5);
    }
}

[Serializable]
public enum DraftStrategy
{
    WIN_NOW, WIN_SOON, REBUILD
}

[Serializable]
class PlayerEnum : IEnumerator<player>
{
    private player[] players;
    private int location = -1;
    public PlayerEnum(player[] players)
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
        while (location < players.Length && players[location] == null) location++;
        return location < players.Length;
    }

    public void Reset()
    {
        location = -1;
    }
   
}
[Serializable]
public class Subs
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
[Serializable]
public class DraftPick
{
    private int round, season;
    private team from, owner;
    private player selectedPlayer;
    public DraftPick(int round, team pickFrom, team owner)
    {
        this.round = round;
        this.from = pickFrom;
        this.owner = owner;
    }
    public int GetPickNumber()
    {
        return from.GetDraftPlace() + ((round-1) * 32);
    }
    public team GetOwner()
    {
        return owner;
    }
    public void SetOwner(team t)
    {
        owner = t;
    }
    public bool DifferentOwner()
    {
        return !from.Equals(owner);
    }
    public team GetTeamOfOrigin()
    {
        return from;
    }
    public int GetRound()
    {
        return round;
    }
    public player GetPlayerSelected()
    {
        return selectedPlayer;
    }
    public void SetSeason(int season)
    {
        this.season = season;
    }
    public int GetSeason()
    {
        return season;
    }
    public void SelectPlayer(player selectedPlayer)
    {
        this.selectedPlayer = selectedPlayer;
        player newPlayer = new player(selectedPlayer.getPosition(), selectedPlayer.ratings, selectedPlayer.age, selectedPlayer.getName(), selectedPlayer.peakStart, selectedPlayer.peakEnd, selectedPlayer.development, selectedPlayer.GetCountry(), formulaBasketball.nextPlayerID++);
        owner.addPlayer(newPlayer);
    }
    public override bool Equals(object obj)
    {
        if(!(obj is DraftPick))
            return false;
        DraftPick otherPick = obj as DraftPick;
        return otherPick.round == round && otherPick.from.ToString().Equals(from.ToString());
    }
}
[Serializable]
public class DisabledLists
{
    private int baseGames;
    private List<int> gamesLeft;
    private List<player> players;
    public DisabledLists(int games)
    {
        baseGames = games;
        gamesLeft = new List<int>();
        players = new List<player>();
    }
    public void AddPlayer(player p)
    {
        players.Add(p);
        gamesLeft.Add(baseGames);
    }
    public List<player> GetReturningPlayers()
    {
        List<player> retVal = new List<player>();
        
        for (int i = 0; i < gamesLeft.Count; i++ )
        {
            gamesLeft[i]--;
            if(gamesLeft[i] <= 0)
            {
                retVal.Add(this.players[i]);                
            }
        }
        gamesLeft.RemoveAll(i => i <= 0);

        return retVal;
    }
    public void ProgressInjury()
    {
        foreach(player p in players)
        {
            p.decrementDay();
        }
    }
    public List<player> GetAllPlayers()
    {
        return players;
    }
}
