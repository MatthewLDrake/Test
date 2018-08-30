using System;
using System.Collections;
using System.Collections.Generic;
using FormulaBasketball;
using System.Globalization;
using System.Drawing;

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
    private List<DraftPick> picks, nextSeasonPicks;
    private DisabledLists sevenGame, fifteenGame, season;
    private player[] activePlayers;
    public team(String teamName, FormulaBasketball.Random r)
    {
        picks = new List<DraftPick>();
        nextSeasonPicks = new List<DraftPick>();
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
        allTime = new Record();
        allTimePlayoffs = new Record();
        conferenceRecord = new Record();
        currentSeasonVsTeam = new Record[32];
        allTimeVsTeam = new Record[32];
        activePlayers = new player[15];
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
    public void AddDraftPick(DraftPick pick)
    {
        if (picks == null) picks = new List<DraftPick>();
        picks.Add(pick);
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
    public void FinishDraft()
    {
        foreach(DraftPick pick in picks)
        {
            addPlayer(pick.GetPlayerSelected());
        }
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
    private team affiliate;
    private bool moreImportantTeam;
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
    public List<player> resignPlayers(FormulaBasketball.Random r)
    {
        List<player> players = new List<player>();
        foreach (player p in activePlayers)
        {
            if (p == null) continue;
            bool onRoster = true;
            if(p.ContractExpired())
            {
                if (p.getGamesPlayed() < 10) onRoster = false;
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
                        onRoster = NegogiateWithPlayer(p, GetRankOnTeam(p));
                    }
                }
            }
            if (!onRoster) players.Add(p);
        }
        return players;
    }

    private bool NegogiateWithPlayer(player p, int rank)
    {
        double average = formulaBasketball.create.GetAverageSalary(rank, p.getPosition());
        double min = formulaBasketball.create.GetMinSalary(rank, p.getPosition());
        double max = formulaBasketball.create.GetMaxSalary(rank, p.getPosition());

        int playerRank = formulaBasketball.create.GetPositionalRank(rank, p.getPosition(), p.getOverall());

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
    public void addRetiredPlayer(player player)
    {
        if(retiredList == null)
        {
            retiredList = new List<player>();
        }
        retiredList.Add(player);
    }
    private bool firstFree= true;
    public void SetFree()
    {
        firstFree = true;
    }
    private List<player>[] playersOffered;
    public void offerToFreeAgents(FreeAgents freeAgency, FormulaBasketball.Random r)
    {
        if(firstFree)
        {
            playersOffered = new List<player>[5];
            for (int i = 0; i < playersOffered.Length; i++)
                playersOffered[i] = new List<player>();
        }
        else
        {
            for (int i = 0; i < playersOffered.Length; i++)
                foreach (player p in playersOffered[i])
                    if (p.FreeAgentSigned())
                        playersOffered[i].Remove(p);
        }
        List<player>[] organizationPlayers = new List<player>[5];
        for (int i = 0; i < organizationPlayers.Length; i++)
            organizationPlayers[i] = new List<player>();
        foreach (player p in activePlayers)if(p != null) organizationPlayers[p.getPosition() - 1].Add(p);
        foreach (player p in affiliate.getAllPlayer()) organizationPlayers[p.getPosition() - 1].Add(p);

        for (int i = 0; i < organizationPlayers.Length; i++)
            organizationPlayers[i] = Sort(organizationPlayers[i]);

        int[] counts = new int[5];
        for(int i = 0; i < counts.Length; i++)
        {
            counts[i] = 7 - organizationPlayers[i].Count;
        }

        for(int i = 0; i < counts.Length; i++)
        {
            List<player> freeAgentPlayers = freeAgency.GetPlayersByPos(i + 1);
            int index = 0;
            while(true)
            {
                if (freeAgentPlayers[index].getOverall() < organizationPlayers[i][organizationPlayers[i].Count - 1].getOverall()) break;

                player current = freeAgentPlayers[index];

                int playersLeft = counts[i] - playersOffered[i].Count;

                double percent = 41.5625 + 17.604166666667 * playersLeft + 0.9375 * playersLeft * playersLeft - 0.10416666666667 * playersLeft * playersLeft * playersLeft;

                if (percent < 0) break;
                if (r.Next(100) < percent)
                {
                    OfferFreeAgent(current);
                    playersOffered[i].Add(current);
                }

                index++;
            }
        }


    }
    private void OfferFreeAgent(player p)
    {
        Contract contract = null;

        if (p.getOverall() < 60)
        {
            contract = new Contract(1, 1);
        }
        else
        {
            double money = -9270 + 402.41666666667 * p.getOverall() - 5.825 * p.getOverall() * p.getOverall() + 0.028333333333333 * p.getOverall() * p.getOverall() * p.getOverall();

            money = Math.Round(money);
            money = r.Next(-10, 10);
            money = money / 10;            

            money = Math.Min(Math.Max(money, 1), 25);

            contract = new Contract(r.Next(1, 4), money);
        }       

        p.OfferFreeAgentContract(contract, this);

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
        int pos = newPlayer.getPosition()-1;
        if(activePlayers == null)activePlayers = new player[15];
        player currentPlayer = newPlayer;
        for (int i = 0; i < 4; i++ )
        {
            if(i == 3)players.Add(currentPlayer);
            else if(activePlayers[pos + (i *5)] == null)
            {
                activePlayers[pos + (i *5)] = currentPlayer;
                break;
            }
            else if(activePlayers[pos + (i *5)].getOverall() < currentPlayer.getOverall())
            {
                player temp = activePlayers[pos + (i * 5)];
                activePlayers[pos + (i * 5)] = currentPlayer;
                currentPlayer = temp;
            }
        }

        newPlayer.setTeam(this);
        addPos(pos);
    }
    private int draftPlace;
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
        return new PlayerEnum(activePlayers); 
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator) GetEnumerator();
    }

    public double GetPayroll()
    {
        double payroll = 0.0;
        foreach(player player in activePlayers)
        {
            if (player == null) continue;
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
    private int round;
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
    public bool DifferentOwner()
    {
        return !from.Equals(owner);
    }
    public team GetTeamOfOrigin()
    {
        return from;
    }
    public player GetPlayerSelected()
    {
        return selectedPlayer;
    }
    public void SelectPlayer(player selectedPlayer)
    {
        this.selectedPlayer = selectedPlayer;
        owner.addPlayer(selectedPlayer);
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
