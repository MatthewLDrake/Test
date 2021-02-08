using System;
using System.Collections.Generic;
using FormulaBasketball;
using System.IO;
[Serializable]
public class createTeams
{
    private FormulaBasketball.Random r;
    public FormulaBasketball.Random draftRandom;
    private List<team> teams, dLeagueTeams;
    private List<player> freeAgency;
    private List<Event> events;
    private FreeAgents freeAgents;
    private College college;
    private double[,] averagePositionSalaries, minPositionSalaries, maxPositionsSalaries;
    private double[,] averageOverall, minOverall, maxOverall, allOveralls;
    private List<int> gameNums;
    public static int nextID = 0;
    public static int currentSeason = 9;
    private MyList<player> Rookies;
    public createTeams(List<team> teams, FreeAgents freeAgency, FormulaBasketball.Random r)
    {
        this.teams = teams;
        this.freeAgents = freeAgency;
        this.r = r;
        college = new College(r);
        setFianancials();

        averagePositionSalaries = new double[3, 5];
        minPositionSalaries = new double[3,5];
        maxPositionsSalaries = new double[3,5];

        averageOverall = new double[3,5];
        minOverall = new double[3,5];
        maxOverall = new double[3,5];
        allOveralls = new double[15, 32];

    }
    public createTeams(String info, FormulaBasketball.Random r)
    {
        this.r = r;
        teams = new List<team>();
        dLeagueTeams = new List<team>();
        freeAgents = new FreeAgents();
        college = new College(r);
        createTheTeams(info);
        averagePositionSalaries = new double[3, 5];
        minPositionSalaries = new double[3, 5];
        for (int x = 0; x < minPositionSalaries.GetLength(0); x += 1)
        {
            for (int y = 0; y < minPositionSalaries.GetLength(1); y += 1)
            {
                minPositionSalaries[x, y] = 26;
            }
        }
        maxPositionsSalaries = new double[3, 5];

        averageOverall = new double[3, 5];
        minOverall = new double[3, 5];
        for (int x = 0; x < minOverall.GetLength(0); x += 1)
        {
            for (int y = 0; y < minOverall.GetLength(1); y += 1)
            {
                minOverall[x, y] = 100;
            }
        }
        maxOverall = new double[3, 5];

        SetDraftPicks();
        for(int i = 0 ; i < teams.Count; i++)
        {
            teams[i].setTeamNum(i);
        }
    }
    public FormulaBasketball.Random GetRandom()
    {
        return draftRandom;
    }
    public void SetEvents()
    {
        events = new List<Event>();
    }
    public void SetRookies(MyList<player> rookies)
    {
        this.Rookies = rookies;
    }
    public MyList<player> GetRookies()
    {
        return Rookies;
    }
    /*public void SaveCreate()
    {
        String fileName = "testSaveFile.csv";
        String contents = "";

        foreach(team team in teams)
        {
            contents += team.SaveTeam();
        }
        contents += "\n";
        foreach(player p in freeAgents.GetAllPlayers())
        {
            contents += p.SavePlayer();
        }

        File.WriteAllText(fileName, contents);
    }*/
    public void Verify()
    {
        foreach(team team in dLeagueTeams)
        {
            foreach(player p in team)
            {
                if (!p.getTeam().Equals(team)) team.removePlayer(p);
            }
            team.ResizeRoster(freeAgents);
        }
        
    }
    public List<Event> GetEventsForTeam(int teamNum)
    {
        List<Event> events = new List<Event>();

        foreach(Event e in this.events)
        {
            if (e.GetTeamsAffected().Contains(-1) || e.GetTeamsAffected().Contains(teamNum))
                events.Add(e);
        }

        return events;
    }
    public void ResetEvents()
    {
        events = new List<Event>();
    }
    public void AddEvent(Event e)
    {
        events.Add(e);
    }
    public void CreateNewSchedule()
    {
        gameNums = new List<int>();
        for(int i = 0; i < 84; i++)
        {
            gameNums.Add(i);
        }
        gameNums.Shuffle(r);
    }
    public void FixTeams()
    {
        /*setFianancials();
        foreach (team t in teams)
        {
            if (t.ToString().Equals("Dotruga Falno"))
            {
                player p = freeAgents.GetTopPlayerByPos(5);
                t.OffSeasonAddPlayer(p);
                p.SetNewContract(new Contract(1,1));
                freeAgents.Remove(p);
            }
            t.FinishOffseason(t.getTeamNum() == 2 || t.getTeamNum() == 7 || t.getTeamNum() == 19);
            foreach(player p in t)
            {
                p.setInjured(false);
                p.setStamina(100);
               
            }
            
           

            t.FixStats();
        }
        
        

        freeAgents.Fix();

        foreach(team t in teams)
        {
            t.FixTeam();
            t.GetAffiliate().FixTeam();
            
        }
        List<player> allPlayers = new List<player>(freeAgents.GetAllPlayers());
        foreach(player p in allPlayers)
        {
            if (p.getTeam() != null)
                freeAgents.Remove(p);
        }
        foreach(team t in teams)
        {
            t.FixDuplicatePlayers();
            t.GetAffiliate().FixDuplicatePlayers();
        }*/
        

    }
    public void Clean()
    {
        Rookies = null;
        dLeagueTeams = null;
        foreach(team team in teams)
        {
            foreach(player p in team)
            {
                p.setPreviousTeam(null);
            }
            foreach(player p in team.GetAffiliate())
            {
                p.setPreviousTeam(null);
            }
        }
        foreach(player p in freeAgents.GetAllPlayers())
        {
            p.setPreviousTeam(null);
        }
    }
    public void playGames(int firstGame, int lastGame, FormulaBasketball.Random r)
    {
        for(int i = firstGame - 1; i < lastGame; i++)
        {
            if(i % 28 == 0)
            {
                foreach(team team in formulaBasketball.create.getTeams())
                {
                    foreach(player p in team)
                    {
                        p.Develop(r);
                    }
                    team.CheckInjuries(formulaBasketball.create.getFreeAgents());
                }
            }

            Schedule.GetInstance(r).playGames(gameNums[i]);
            formulaBasketball.updateStandings();
        }
    }
    public void playDLeagueGames(int firstGame, int lastGame, FormulaBasketball.Random r)
    {
        for (int i = firstGame - 1; i < lastGame; i++)
        {
            if (i % 28 == 0)
            {
                foreach (team team in formulaBasketball.create.getTeams())
                {
                    foreach (player p in team)
                    {
                        p.Develop(r);
                    }
                    team.CheckInjuries(formulaBasketball.create.getFreeAgents());
                }
            }

            Schedule.GetInstance(r).playDLeagueGames(gameNums[i]);
            formulaBasketball.updateStandings();
        }
    }
    public void FinishOffseason(List<int> humans)
    {
        new LeagueRoster(new List<int>(), this).ShowDialog();
        List<Tuple<int, team, int>> teamNeeds = new List<Tuple<int, team, int>>();
        foreach(team team in teams)
        {
            
            List<player> players = team.GetOffSeasonPlayers();
            List<player> pgs = new List<player>(), sgs = new List<player>(), pfs = new List<player>(), sfs = new List<player>(), cs = new List<player>();
            foreach(player p in players)
            {
                switch(p.getPosition())
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
            if(pgs.Count < 6)
            {
                teamNeeds.Add(new Tuple<int, team, int>(5, team, 6 - pgs.Count));
            }
            if (sgs.Count < 6)
            {
                teamNeeds.Add(new Tuple<int, team, int>(4, team, 6 - sgs.Count));
            }
            if (sfs.Count < 6)
            {
                teamNeeds.Add(new Tuple<int, team, int>(3, team, 6 - sfs.Count));
            }
            if (pfs.Count < 6)
            {
                teamNeeds.Add(new Tuple<int, team, int>(2, team, 6 - pfs.Count));
            }
            if (cs.Count < 6)
            {
                teamNeeds.Add(new Tuple<int, team, int>(1, team, 6 - cs.Count));
            }
            if (humans.Contains(team.getTeamNum()))
                continue;

            if(pgs.Count > 6)
            {
                player[] playersToCut = new player[pgs.Count - 6];
                foreach(player p in pgs)
                {
                    player currPlayer = p;
                    for(int i = 0; i < playersToCut.Length; i++)
                    {
                        if (playersToCut[i] == null)
                        {
                            playersToCut[i] = currPlayer;
                            break;
                        }
                        else if (playersToCut[i].getOverall(null, true) > currPlayer.getOverall(null, true))
                        {
                            player temp = currPlayer;
                            currPlayer = playersToCut[i];
                            playersToCut[i] = temp;
                        }
                    }
                }
                foreach(player p in playersToCut)
                {
                    team.OffSeasonRemovePlayer(p);
                    freeAgents.Add(p);
                }
            }
           
            if (sgs.Count > 6)
            {
                player[] playersToCut = new player[sgs.Count - 6];
                foreach (player p in sgs)
                {
                    player currPlayer = p;
                    for (int i = 0; i < playersToCut.Length; i++)
                    {
                        if (playersToCut[i] == null)
                        {
                            playersToCut[i] = currPlayer;
                            break;
                        }
                        else if (playersToCut[i].getOverall(null, true) > currPlayer.getOverall(null, true))
                        {
                            player temp = currPlayer;
                            currPlayer = playersToCut[i];
                            playersToCut[i] = temp;
                        }
                    }
                }
                foreach (player p in playersToCut)
                {
                    team.OffSeasonRemovePlayer(p);
                    freeAgents.Add(p);
                }
            }
           
            if (sfs.Count > 6)
            {
                player[] playersToCut = new player[sfs.Count - 6];
                foreach (player p in sfs)
                {
                    player currPlayer = p;
                    for (int i = 0; i < playersToCut.Length; i++)
                    {
                        if (playersToCut[i] == null)
                        {
                            playersToCut[i] = currPlayer;
                            break;
                        }
                        else if (playersToCut[i].getOverall(null, true) > currPlayer.getOverall(null, true))
                        {
                            player temp = currPlayer;
                            currPlayer = playersToCut[i];
                            playersToCut[i] = temp;
                        }
                    }
                }
                foreach (player p in playersToCut)
                {
                    team.OffSeasonRemovePlayer(p);
                    freeAgents.Add(p);
                }
            }
           
            if (pfs.Count > 6)
            {
                player[] playersToCut = new player[pfs.Count - 6];
                foreach (player p in pfs)
                {
                    player currPlayer = p;
                    for (int i = 0; i < playersToCut.Length; i++)
                    {
                        if (playersToCut[i] == null)
                        {
                            playersToCut[i] = currPlayer;
                            break;
                        }
                        else if (playersToCut[i].getOverall(null, true) > currPlayer.getOverall(null, true))
                        {
                            player temp = currPlayer;
                            currPlayer = playersToCut[i];
                            playersToCut[i] = temp;
                        }
                    }
                }
                foreach (player p in playersToCut)
                {
                    team.OffSeasonRemovePlayer(p);
                    freeAgents.Add(p);
                }
            }
            
            if (cs.Count > 6)
            {
                player[] playersToCut = new player[cs.Count - 6];
                foreach (player p in cs)
                {
                    player currPlayer = p;
                    for (int i = 0; i < playersToCut.Length; i++)
                    {
                        if (playersToCut[i] == null)
                        {
                            playersToCut[i] = currPlayer;
                            break;
                        }
                        else if (playersToCut[i].getOverall(null, true) > currPlayer.getOverall(null, true))
                        {
                            player temp = currPlayer;
                            currPlayer = playersToCut[i];
                            playersToCut[i] = temp;
                        }
                    }
                }
                foreach (player p in playersToCut)
                {
                    team.OffSeasonRemovePlayer(p);
                    freeAgents.Add(p);
                }
            }

        }
        List<player> playersToRemove = new List<player>();
        foreach(player p in freeAgents.GetAllPlayers())
        {
            if (p.GetStatus() == 2)
                playersToRemove.Add(p);
        }
        freeAgents.Remove(playersToRemove);
        while(teamNeeds.Count > 0)
        {
            Tuple<int, team, int> next = teamNeeds[r.Next(teamNeeds.Count)];
            teamNeeds.Remove(next);
            List<player> players = freeAgents.GetPlayersByPos(next.Item1);
            player[] topPlayers = new player[next.Item3];

            foreach (player p in players)
            {
                player currPlayer = p;
                for (int i = 0; i < topPlayers.Length; i++)
                {
                    if (topPlayers[i] == null)
                    {
                        topPlayers[i] = currPlayer;
                        break;
                    }
                    else if (topPlayers[i].getOverall(null, true) < currPlayer.getOverall(null, true))
                    {
                        player temp = currPlayer;
                        currPlayer = topPlayers[i];
                        topPlayers[i] = temp;
                    }
                }
            }

            foreach (player p in topPlayers)
            {
                freeAgents.Remove(p);
                next.Item2.OffSeasonAddPlayer(p);
                p.SetNewContract(new Contract(1, 1));
            }
        }
        foreach (team team in teams)
        {
            if (humans.Contains(team.getTeamNum()))
                continue;

            team.FinishOffseason(true);
        }
    }
    private void createTheTeams(string info)
    {
        /*string[] splits = info.Split(new string[] { "<freeagents>" }, StringSplitOptions.None);
        string[] players = splits[1].Split(new string[] { "<player>" }, StringSplitOptions.None);
        for (int i = 1; i < players.Length; i++)
        {
            freeAgents.Add(new player(players[i]));
        }
        string[] data = splits[0].Split(new string[] { "<team>" }, StringSplitOptions.None);
        teams = new List<team>();
        dLeagueTeams = new List<team>();
        for(int i = 1; i < data.Length; i += 2)
        {
            team newTeam = new team(data[i], data[i + 1], r, false);
            teams.Add(newTeam);
            dLeagueTeams.Add(newTeam.GetAffiliate());
        }
        
        for(int i = 0; i < teams.Count; i++)
        {
            for(int j = 0; j < teams.Count/2; j++)
            {
                game game = new game(null, teams[j], teams[31-j], r);
                CalculateELO(ref teams[j].elo, ref teams[31-j].elo, game.getWinner() ? 1 : 0);
                teams[j].AddResult(0, game.getAwayTeamScore(), game.getHomeTeamScore());
                teams[31 - j].AddResult(0, game.getHomeTeamScore(), game.getAwayTeamScore());
            }

            team t = teams[31];
            teams.Remove(t);
            teams.Insert(1, t);
            
        }
        foreach(team t in teams)
        {
            Console.WriteLine(t.ToString() + " - " + t.elo + "(" + t.getWins() + "-" + t.getLosses() + ")");
        }*/


    }
    static double ExpectationToWin(int playerOneRating, int playerTwoRating)
    {
        return 1 / (1 + Math.Pow(10, (playerTwoRating - playerOneRating) / 400.0));
    }
    static void CalculateELO(ref int playerOneRating, ref int playerTwoRating, int outcome)
    {
        int eloK = 10;

        int delta = (int)(eloK * ((int)outcome - ExpectationToWin(playerOneRating, playerTwoRating)));

        playerOneRating += delta;
        playerTwoRating -= delta;
    }

    public void SetupSalaryInfo()
    {
        averagePositionSalaries = new double[3, 5];
        minPositionSalaries = new double[3, 5];
        maxPositionsSalaries = new double[3, 5];

        averageOverall = new double[3, 5];
        minOverall = new double[3, 5];
        maxOverall = new double[3, 5];
        allOveralls = new double[15, 32];
        int teamNum = 0;
        foreach(team team in teams)
        {
            List<player> players = team.getAllPlayer();
            for(int i = 0; i < players.Count;i++)
            {
                averageOverall[i/5, i%5] += players[i].getOverall();
                averagePositionSalaries[i / 5, i % 5] += players[i].GetMoneyPerYear();
                allOveralls[i, teamNum] = players[i].getOverall();

                if (players[i].getOverall() > maxOverall[i / 5, i % 5]) maxOverall[i / 5, i % 5] = players[i].getOverall();
                if (players[i].getOverall() < minOverall[i / 5, i % 5]) minOverall[i / 5, i % 5] = players[i].getOverall();

                if (players[i].GetMoneyPerYear() > maxPositionsSalaries[i / 5, i % 5]) maxPositionsSalaries[i / 5, i % 5] = players[i].GetMoneyPerYear();
                if (players[i].GetMoneyPerYear() < minPositionSalaries[i / 5, i % 5]) minPositionSalaries[i / 5, i % 5] = players[i].GetMoneyPerYear();
            }
            teamNum++;
        }
        for(int i = 0; i < 15; i++)
        {
            averagePositionSalaries[i / 5, i % 5] = averagePositionSalaries[i / 5, i % 5] / 32;
            averageOverall[i / 5, i % 5] = averageOverall[i / 5, i % 5] / 32;
        }
    }

    public double GetAverageSalary(int rank, int pos)
    {
        return averagePositionSalaries[rank-1, pos-1];
    }
    public double GetMinSalary(int rank, int pos)
    {
        return maxPositionsSalaries[rank-1, pos-1];
    }
    public double GetMaxSalary(int rank, int pos)
    {
        return maxPositionsSalaries[rank-1, pos - 1];
    }
    public int GetPositionalRank(int rosterSpot, int pos, double overall)
    {
        int rank = 1;
        int loc = (rosterSpot - 1) * 5 + (pos - 1);

        for (int i = 0; i < allOveralls.GetLength(1); i++ )
        {
            if (allOveralls[loc, i] > overall) rank++;
        }

        return rank;
    }

    public void SetUpCollege()
    {
        college = new College(r);
    }
    public void PlayCollegeSeason()
    {
        college.PlaySeason();
    }
    public int size()
    {
        return teams.Count;
    }
    public team getTeam(int teamNum)
    {
        return teams[teamNum];
    }

    public List<team> getTeams()
    {
        return teams;
    }
    public team getDLeagueTeam(int teamNum)
    {
        return dLeagueTeams[teamNum];
    }

    public List<team> getDLeagueTeams()
    {
        return dLeagueTeams;
    }
    public FreeAgents getFreeAgents()
    {
        if(freeAgents == null)
        {
            freeAgents = new FreeAgents();
            freeAgents.Add(freeAgency);
        }
        return freeAgents;
    }
    public void SetDraftPicks()
    {
        foreach(team team in teams)
        {
            team.ClearDraftPicks();
        }
       
        getTeam(0).SetDraftPlace(25);
        getTeam(1).SetDraftPlace(22);
        getTeam(2).SetDraftPlace(32);
        getTeam(3).SetDraftPlace(15);
        getTeam(4).SetDraftPlace(1);
        getTeam(5).SetDraftPlace(5);
        getTeam(6).SetDraftPlace(28);
        getTeam(7).SetDraftPlace(29);
        getTeam(8).SetDraftPlace(13);
        getTeam(9).SetDraftPlace(10);
        getTeam(10).SetDraftPlace(8);
        getTeam(11).SetDraftPlace(24);
        getTeam(12).SetDraftPlace(12);
        getTeam(13).SetDraftPlace(3);
        getTeam(14).SetDraftPlace(18);
        getTeam(15).SetDraftPlace(19);
        getTeam(16).SetDraftPlace(20);
        getTeam(17).SetDraftPlace(9);
        getTeam(18).SetDraftPlace(31);
        getTeam(19).SetDraftPlace(23);
        getTeam(20).SetDraftPlace(2);
        getTeam(21).SetDraftPlace(4);
        getTeam(22).SetDraftPlace(6);
        getTeam(23).SetDraftPlace(16);
        getTeam(24).SetDraftPlace(21);
        getTeam(25).SetDraftPlace(17);
        getTeam(26).SetDraftPlace(30);
        getTeam(27).SetDraftPlace(14);
        getTeam(28).SetDraftPlace(27);
        getTeam(29).SetDraftPlace(7);
        getTeam(30).SetDraftPlace(26);
        getTeam(31).SetDraftPlace(11);


        getTeam(19).AddDraftPick(new DraftPick(1, getTeam(23), getTeam(19)));
        getTeam(27).AddDraftPick(new DraftPick(1, getTeam(27), getTeam(27)));
        getTeam(18).AddDraftPick(new DraftPick(1, getTeam(18), getTeam(18)));
        getTeam(14).AddDraftPick(new DraftPick(1, getTeam(14), getTeam(14)));
        getTeam(3).AddDraftPick(new DraftPick(1, getTeam(3), getTeam(3)));
        getTeam(24).AddDraftPick(new DraftPick(1, getTeam(24), getTeam(24)));
        getTeam(4).AddDraftPick(new DraftPick(1, getTeam(4), getTeam(4)));
        getTeam(31).AddDraftPick(new DraftPick(1, getTeam(31), getTeam(31)));
        getTeam(10).AddDraftPick(new DraftPick(1, getTeam(10), getTeam(10)));
        getTeam(13).AddDraftPick(new DraftPick(1, getTeam(13), getTeam(13)));
        getTeam(7).AddDraftPick(new DraftPick(1, getTeam(21), getTeam(7)));
        getTeam(29).AddDraftPick(new DraftPick(1, getTeam(29), getTeam(29)));
        getTeam(12).AddDraftPick(new DraftPick(1, getTeam(17), getTeam(12)));
        getTeam(25).AddDraftPick(new DraftPick(1, getTeam(25), getTeam(25)));
        getTeam(0).AddDraftPick(new DraftPick(1, getTeam(0), getTeam(0)));
        getTeam(22).AddDraftPick(new DraftPick(1, getTeam(22), getTeam(22)));
        getTeam(11).AddDraftPick(new DraftPick(1, getTeam(11), getTeam(11)));
        getTeam(12).AddDraftPick(new DraftPick(1, getTeam(12), getTeam(12)));
        getTeam(6).AddDraftPick(new DraftPick(1, getTeam(6), getTeam(6)));
        getTeam(8).AddDraftPick(new DraftPick(1, getTeam(8), getTeam(8)));
        getTeam(9).AddDraftPick(new DraftPick(1, getTeam(9), getTeam(9)));
        getTeam(16).AddDraftPick(new DraftPick(1, getTeam(16), getTeam(16)));
        getTeam(30).AddDraftPick(new DraftPick(1, getTeam(30), getTeam(30)));
        getTeam(7).AddDraftPick(new DraftPick(1, getTeam(7), getTeam(7)));
        getTeam(0).AddDraftPick(new DraftPick(1, getTeam(1), getTeam(0)));
        getTeam(28).AddDraftPick(new DraftPick(1, getTeam(28), getTeam(28)));
        getTeam(20).AddDraftPick(new DraftPick(1, getTeam(20), getTeam(20)));
        getTeam(15).AddDraftPick(new DraftPick(1, getTeam(15), getTeam(15)));
        getTeam(5).AddDraftPick(new DraftPick(1, getTeam(5), getTeam(5)));
        getTeam(2).AddDraftPick(new DraftPick(1, getTeam(2), getTeam(2)));
        getTeam(26).AddDraftPick(new DraftPick(1, getTeam(26), getTeam(26)));
        getTeam(23).AddDraftPick(new DraftPick(1, getTeam(19), getTeam(23)));

        getTeam(23).AddDraftPick(new DraftPick(2, getTeam(23), getTeam(23)));
        getTeam(27).AddDraftPick(new DraftPick(2, getTeam(27), getTeam(27)));
        getTeam(18).AddDraftPick(new DraftPick(2, getTeam(18), getTeam(18)));
        getTeam(14).AddDraftPick(new DraftPick(2, getTeam(14), getTeam(14)));
        getTeam(3).AddDraftPick(new DraftPick(2, getTeam(3), getTeam(3)));
        getTeam(24).AddDraftPick(new DraftPick(2, getTeam(24), getTeam(24)));
        getTeam(4).AddDraftPick(new DraftPick(2, getTeam(4), getTeam(4)));
        getTeam(31).AddDraftPick(new DraftPick(2, getTeam(31), getTeam(31)));
        getTeam(10).AddDraftPick(new DraftPick(2, getTeam(10), getTeam(10)));
        getTeam(13).AddDraftPick(new DraftPick(2, getTeam(13), getTeam(13)));
        getTeam(21).AddDraftPick(new DraftPick(2, getTeam(21), getTeam(21)));
        getTeam(29).AddDraftPick(new DraftPick(2, getTeam(29), getTeam(29)));
        getTeam(17).AddDraftPick(new DraftPick(2, getTeam(17), getTeam(17)));
        getTeam(25).AddDraftPick(new DraftPick(2, getTeam(25), getTeam(25)));
        getTeam(0).AddDraftPick(new DraftPick(2, getTeam(0), getTeam(0)));
        getTeam(22).AddDraftPick(new DraftPick(2, getTeam(22), getTeam(22)));
        getTeam(19).AddDraftPick(new DraftPick(2, getTeam(11), getTeam(19)));
        getTeam(12).AddDraftPick(new DraftPick(2, getTeam(12), getTeam(12)));
        getTeam(25).AddDraftPick(new DraftPick(2, getTeam(6), getTeam(25)));
        getTeam(8).AddDraftPick(new DraftPick(2, getTeam(8), getTeam(8)));
        getTeam(9).AddDraftPick(new DraftPick(2, getTeam(9), getTeam(9)));
        getTeam(16).AddDraftPick(new DraftPick(2, getTeam(16), getTeam(16)));
        getTeam(30).AddDraftPick(new DraftPick(2, getTeam(30), getTeam(30)));
        getTeam(7).AddDraftPick(new DraftPick(2, getTeam(7), getTeam(7)));
        getTeam(1).AddDraftPick(new DraftPick(2, getTeam(1), getTeam(1)));
        getTeam(28).AddDraftPick(new DraftPick(2, getTeam(28), getTeam(28)));
        getTeam(20).AddDraftPick(new DraftPick(2, getTeam(20), getTeam(20)));
        getTeam(15).AddDraftPick(new DraftPick(2, getTeam(15), getTeam(15)));
        getTeam(5).AddDraftPick(new DraftPick(2, getTeam(5), getTeam(5)));
        getTeam(2).AddDraftPick(new DraftPick(2, getTeam(2), getTeam(2)));
        getTeam(26).AddDraftPick(new DraftPick(2, getTeam(26), getTeam(26)));
        getTeam(23).AddDraftPick(new DraftPick(2, getTeam(19), getTeam(23)));

        getTeam(23).AddFutureDraftPick(new DraftPick(1, getTeam(23), getTeam(23)));
        getTeam(27).AddFutureDraftPick(new DraftPick(1, getTeam(27), getTeam(27)));
        getTeam(18).AddFutureDraftPick(new DraftPick(1, getTeam(18), getTeam(18)));
        getTeam(14).AddFutureDraftPick(new DraftPick(1, getTeam(14), getTeam(14)));
        getTeam(3).AddFutureDraftPick(new DraftPick(1, getTeam(3), getTeam(3)));
        getTeam(24).AddFutureDraftPick(new DraftPick(1, getTeam(24), getTeam(24)));
        getTeam(4).AddFutureDraftPick(new DraftPick(1, getTeam(4), getTeam(4)));
        getTeam(31).AddFutureDraftPick(new DraftPick(1, getTeam(31), getTeam(31)));
        getTeam(10).AddFutureDraftPick(new DraftPick(1, getTeam(10), getTeam(10)));
        getTeam(13).AddFutureDraftPick(new DraftPick(1, getTeam(13), getTeam(13)));
        getTeam(21).AddFutureDraftPick(new DraftPick(1, getTeam(21), getTeam(21)));
        getTeam(29).AddFutureDraftPick(new DraftPick(1, getTeam(29), getTeam(29)));
        getTeam(17).AddFutureDraftPick(new DraftPick(1, getTeam(17), getTeam(17)));
        getTeam(25).AddFutureDraftPick(new DraftPick(1, getTeam(25), getTeam(25)));
        getTeam(0).AddFutureDraftPick(new DraftPick(1, getTeam(0), getTeam(0)));
        getTeam(22).AddFutureDraftPick(new DraftPick(1, getTeam(22), getTeam(22)));
        getTeam(11).AddFutureDraftPick(new DraftPick(1, getTeam(11), getTeam(11)));
        getTeam(12).AddFutureDraftPick(new DraftPick(1, getTeam(12), getTeam(12)));
        getTeam(6).AddFutureDraftPick(new DraftPick(1, getTeam(6), getTeam(6)));
        getTeam(8).AddFutureDraftPick(new DraftPick(1, getTeam(8), getTeam(8)));
        getTeam(9).AddFutureDraftPick(new DraftPick(1, getTeam(9), getTeam(9)));
        getTeam(16).AddFutureDraftPick(new DraftPick(1, getTeam(16), getTeam(16)));
        getTeam(30).AddFutureDraftPick(new DraftPick(1, getTeam(30), getTeam(30)));
        getTeam(21).AddFutureDraftPick(new DraftPick(1, getTeam(7), getTeam(21)));
        getTeam(1).AddFutureDraftPick(new DraftPick(1, getTeam(1), getTeam(1)));
        getTeam(28).AddFutureDraftPick(new DraftPick(1, getTeam(28), getTeam(28)));
        getTeam(20).AddFutureDraftPick(new DraftPick(1, getTeam(20), getTeam(20)));
        getTeam(15).AddFutureDraftPick(new DraftPick(1, getTeam(15), getTeam(15)));
        getTeam(5).AddFutureDraftPick(new DraftPick(1, getTeam(5), getTeam(5)));
        getTeam(2).AddFutureDraftPick(new DraftPick(1, getTeam(2), getTeam(2)));
        getTeam(26).AddFutureDraftPick(new DraftPick(1, getTeam(26), getTeam(26)));
        getTeam(19).AddFutureDraftPick(new DraftPick(1, getTeam(19), getTeam(19)));

        getTeam(23).AddFutureDraftPick(new DraftPick(2, getTeam(23), getTeam(23)));
        getTeam(27).AddFutureDraftPick(new DraftPick(2, getTeam(27), getTeam(27)));
        getTeam(18).AddFutureDraftPick(new DraftPick(2, getTeam(18), getTeam(18)));
        getTeam(14).AddFutureDraftPick(new DraftPick(2, getTeam(14), getTeam(14)));
        getTeam(3).AddFutureDraftPick(new DraftPick(2, getTeam(3), getTeam(3)));
        getTeam(24).AddFutureDraftPick(new DraftPick(2, getTeam(24), getTeam(24)));
        getTeam(4).AddFutureDraftPick(new DraftPick(2, getTeam(4), getTeam(4)));
        getTeam(31).AddFutureDraftPick(new DraftPick(2, getTeam(31), getTeam(31)));
        getTeam(10).AddFutureDraftPick(new DraftPick(2, getTeam(10), getTeam(10)));
        getTeam(13).AddFutureDraftPick(new DraftPick(2, getTeam(13), getTeam(13)));
        getTeam(21).AddFutureDraftPick(new DraftPick(2, getTeam(21), getTeam(21)));
        getTeam(29).AddFutureDraftPick(new DraftPick(2, getTeam(29), getTeam(29)));
        getTeam(17).AddFutureDraftPick(new DraftPick(2, getTeam(17), getTeam(17)));
        getTeam(25).AddFutureDraftPick(new DraftPick(2, getTeam(25), getTeam(25)));
        getTeam(0).AddFutureDraftPick(new DraftPick(2, getTeam(0), getTeam(0)));
        getTeam(22).AddFutureDraftPick(new DraftPick(2, getTeam(22), getTeam(22)));
        getTeam(11).AddFutureDraftPick(new DraftPick(2, getTeam(11), getTeam(11)));
        getTeam(12).AddFutureDraftPick(new DraftPick(2, getTeam(12), getTeam(12)));
        getTeam(6).AddFutureDraftPick(new DraftPick(2, getTeam(6), getTeam(6)));
        getTeam(8).AddFutureDraftPick(new DraftPick(2, getTeam(8), getTeam(8)));
        getTeam(9).AddFutureDraftPick(new DraftPick(2, getTeam(9), getTeam(9)));
        getTeam(16).AddFutureDraftPick(new DraftPick(2, getTeam(16), getTeam(16)));
        getTeam(30).AddFutureDraftPick(new DraftPick(2, getTeam(30), getTeam(30)));
        getTeam(7).AddFutureDraftPick(new DraftPick(2, getTeam(7), getTeam(7)));
        getTeam(1).AddFutureDraftPick(new DraftPick(2, getTeam(1), getTeam(1)));
        getTeam(28).AddFutureDraftPick(new DraftPick(2, getTeam(28), getTeam(28)));
        getTeam(20).AddFutureDraftPick(new DraftPick(2, getTeam(20), getTeam(20)));
        getTeam(15).AddFutureDraftPick(new DraftPick(2, getTeam(15), getTeam(15)));
        getTeam(5).AddFutureDraftPick(new DraftPick(2, getTeam(5), getTeam(5)));
        getTeam(2).AddFutureDraftPick(new DraftPick(2, getTeam(2), getTeam(2)));
        getTeam(26).AddFutureDraftPick(new DraftPick(2, getTeam(26), getTeam(26)));
        getTeam(19).AddFutureDraftPick(new DraftPick(2, getTeam(19), getTeam(19)));
    }
    private List<player> drafted, undrafted;
    internal void AddFinishedDraft(List<player> list1, List<player> list2)
    {
        drafted = list1;
        undrafted = list2;
    }

    public void setFianancials()
    {
        teams[0].setExpenses(new double[] { 88.7, 17.7, 11 });
        teams[16].setExpenses(new double[] { 74.6, 15.5, 11 });
        teams[1].setExpenses(new double[] { 99.8, 16.8, 11 });
        teams[8].setExpenses(new double[] { 87.5, 16.1, 11 });
        teams[17].setExpenses(new double[] { 94, 17.2, 11 });
        teams[9].setExpenses(new double[] { 90.2, 15.8, 11 });
        teams[10].setExpenses(new double[] { 78.4, 18.3, 11 });
        teams[18].setExpenses(new double[] { 65.2, 18.3, 11 });
        teams[24].setExpenses(new double[] { 76.4, 17.8, 11 });
        teams[2].setExpenses(new double[] { 99.2, 17.2, 11 });
        teams[25].setExpenses(new double[] { 91.5, 18.3, 11 });
        teams[19].setExpenses(new double[] { 91.2, 18, 11 });
        teams[26].setExpenses(new double[] { 99.8, 16.1, 11 });
        teams[20].setExpenses(new double[] { 94.5, 18.3, 11 });
        teams[21].setExpenses(new double[] { 86.5, 15.9, 11 });
        teams[3].setExpenses(new double[] { 77, 19.5, 11 });
        teams[27].setExpenses(new double[] { 86.8, 17.2, 11 });
        teams[28].setExpenses(new double[] { 97.6, 17.5, 11 });
        teams[11].setExpenses(new double[] { 70.2, 15.9, 11 });
        teams[4].setExpenses(new double[] { 66.6, 18.7, 11 });
        teams[29].setExpenses(new double[] { 83.4, 15.8, 11 });
        teams[5].setExpenses(new double[] { 80.8, 15.1, 11 });
        teams[12].setExpenses(new double[] { 77, 17.3, 11 });
        teams[30].setExpenses(new double[] { 80.8, 19.3, 11 });
        teams[13].setExpenses(new double[] { 73.4, 17.7, 11 });
        teams[6].setExpenses(new double[] { 76.8, 18.3, 11 });
        teams[14].setExpenses(new double[] { 99.5, 18.3, 11 });
        teams[15].setExpenses(new double[] { 82.4, 17.2, 11 });
        teams[7].setExpenses(new double[] { 97.5, 19.4, 11 });
        teams[22].setExpenses(new double[] { 80.9, 16.1, 11 });
        teams[23].setExpenses(new double[] { 82.3, 15.4, 11 });
        teams[31].setExpenses(new double[] { 90.1, 16.1, 11 });


        teams[0].setSponserMoney(5000);
        teams[0].setWeeklySponser(1000000);
        teams[0].addSponsers(new double[] { 2500, 1000 });
        teams[1].setSponserMoney(5000);
        teams[1].setWeeklySponser(2500000);
        teams[1].addSponsers(new double[] { 2500, 1000 });
        teams[2].setSponserMoney(5000);
        teams[2].setWeeklySponser(2500000);
        teams[2].addSponsers(new double[] { 2500, 1000 });
        teams[3].setSponserMoney(5000);
        teams[3].setWeeklySponser(1000000);
        teams[3].addSponsers(new double[] { 2500, 1000 });
        teams[4].setSponserMoney(5000);
        teams[4].setWeeklySponser(1000000);
        teams[4].addSponsers(new double[] { 2500, 1000 });
        teams[5].setSponserMoney(5000);
        teams[5].setWeeklySponser(1000000);
        teams[5].addSponsers(new double[] { 2500, 1000 });
        teams[6].setSponserMoney(5000);
        teams[6].setWeeklySponser(1000000);
        teams[6].addSponsers(new double[] { 2500, 1000 });
        teams[7].setSponserMoney(5000);
        teams[7].setWeeklySponser(1000000);
        teams[7].addSponsers(new double[] { 2500, 1000 });
        teams[8].setSponserMoney(5000);
        teams[8].setWeeklySponser(1000000);
        teams[8].addSponsers(new double[] { 2500, 1000 });
        teams[9].setSponserMoney(5000);
        teams[9].setWeeklySponser(1000000);
        teams[9].addSponsers(new double[] { 2500, 1000 });
        teams[10].setSponserMoney(5000);
        teams[10].setWeeklySponser(1000000);
        teams[10].addSponsers(new double[] { 2500, 1000 });
        teams[11].setSponserMoney(5000);
        teams[11].setWeeklySponser(1000000);
        teams[11].addSponsers(new double[] { 2500, 1000 });
        teams[12].setSponserMoney(5000);
        teams[12].setWeeklySponser(1000000);
        teams[12].addSponsers(new double[] { 2500, 1000 });
        teams[13].setSponserMoney(5000);
        teams[13].setWeeklySponser(1000000);
        teams[13].addSponsers(new double[] { 2500, 1000 });
        teams[14].setSponserMoney(5000);
        teams[14].setWeeklySponser(500000);
        teams[14].addSponsers(new double[] { 2500, 1000 });
        teams[15].setSponserMoney(5000);
        teams[15].setWeeklySponser(1000000);
        teams[15].addSponsers(new double[] { 2500, 1000 });
        teams[16].setSponserMoney(5000);
        teams[16].setWeeklySponser(1000000);
        teams[16].addSponsers(new double[] { 2500, 1000 });
        teams[17].setSponserMoney(5000);
        teams[17].setWeeklySponser(1000000);
        teams[17].addSponsers(new double[] { 2500, 1000 });
        teams[18].setSponserMoney(5000);
        teams[18].setWeeklySponser(1000000);
        teams[18].addSponsers(new double[] { 2500, 1000 });
        teams[19].setSponserMoney(5000);
        teams[19].setWeeklySponser(1000000);
        teams[19].addSponsers(new double[] { 2500, 1000 });
        teams[20].setSponserMoney(5000);
        teams[20].setWeeklySponser(1000000);
        teams[20].addSponsers(new double[] { 2500, 1000 });
        teams[21].setSponserMoney(5000);
        teams[21].setWeeklySponser(1000000);
        teams[21].addSponsers(new double[] { 2500, 1000 });
        teams[22].setSponserMoney(5000);
        teams[22].setWeeklySponser(1000000);
        teams[22].addSponsers(new double[] { 2500, 1000 });
        teams[23].setSponserMoney(5000);
        teams[23].setWeeklySponser(1000000);
        teams[23].addSponsers(new double[] { 2500, 1000 });
        teams[24].setSponserMoney(5000);
        teams[24].setWeeklySponser(500000);
        teams[24].addSponsers(new double[] { 2500, 1000 });
        teams[25].setSponserMoney(5000);
        teams[25].setWeeklySponser(1000000);
        teams[25].addSponsers(new double[] { 2500, 1000 });
        teams[26].setSponserMoney(5000);
        teams[26].setWeeklySponser(2500000);
        teams[26].addSponsers(new double[] { 2500, 1000 });
        teams[27].setSponserMoney(5000);
        teams[27].setWeeklySponser(1000000);
        teams[27].addSponsers(new double[] { 2500, 1000 });
        teams[28].setSponserMoney(5000);
        teams[28].setWeeklySponser(2500000);
        teams[28].addSponsers(new double[] { 2500, 1000 });
        teams[29].setSponserMoney(5000);
        teams[29].setWeeklySponser(1000000);
        teams[29].addSponsers(new double[] { 2500, 1000 });
        teams[30].setSponserMoney(5000);
        teams[30].setWeeklySponser(1000000);
        teams[30].addSponsers(new double[] { 2500, 1000 });
        teams[31].setSponserMoney(5000);
        teams[31].setWeeklySponser(1000000);
        teams[31].addSponsers(new double[] { 2500, 1000 });

        teams[0].createStadium(new float[] { 30, 100, 450, 1000 });
        teams[16].createStadium(new float[] { 30, 120, 450, 1000 });
        teams[1].createStadium(new float[] { 40, 100, 550, 1250 });
        teams[8].createStadium(new float[] { 35, 90, 450, 1000 });
        teams[17].createStadium(new float[] { 30, 90, 600, 1200 });
        teams[9].createStadium(new float[] { 20, 120, 350, 1000 });
        teams[10].createStadium(new float[] { 40, 100, 350, 1000 });
        teams[18].createStadium(new float[] { 30, 100, 550, 1000 });
        teams[24].createStadium(new float[] { 30, 120, 550, 900 });
        teams[2].createStadium(new float[] { 25, 125, 400, 1000 });
        teams[25].createStadium(new float[] { 25, 110, 600, 1000 });
        teams[19].createStadium(new float[] { 15, 120, 650, 1500 });
        teams[26].createStadium(new float[] { 40, 150, 700, 1500 });
        teams[20].createStadium(new float[] { 20, 105, 400, 1250 });
        teams[21].createStadium(new float[] { (float)27.5, 120, 500, 1500 });
        teams[3].createStadium(new float[] { 20, 90, 600, 900 });
        teams[27].createStadium(new float[] { 20, 115, 450, 800 });
        teams[28].createStadium(new float[] { 40, 105, 350, 1000 });
        teams[11].createStadium(new float[] { 25, 45, 400, 1000 });
        teams[4].createStadium(new float[] { 30, 110, 500, 750 });
        teams[29].createStadium(new float[] { 35, 115, 450, 800 });
        teams[5].createStadium(new float[] { 20, 160, 400, 1500 });
        teams[12].createStadium(new float[] { 35, 90, 400, 1200 });
        teams[30].createStadium(new float[] { 25, 120, 350, 1000 });
        teams[13].createStadium(new float[] { 35, 100, 350, 1000 });
        teams[6].createStadium(new float[] { 25, 125, 350, 1000 });
        teams[14].createStadium(new float[] { 25, 105, 600, 950 });
        teams[15].createStadium(new float[] { 30, 115, 350, 900 });
        teams[7].createStadium(new float[] { 15, 80, 500, 1250 });
        teams[22].createStadium(new float[] { 30, 125, 600, 1000 });
        teams[23].createStadium(new float[] { 35, 115, 500, 1000 });
        teams[31].createStadium(new float[] { 30, 110, 450, 1000 });

        teams[0].getStadium().startConcessions("Cotton Candy", 3.5, "Beer", 7.5);
        teams[16].getStadium().startConcessions("Nachos", 4.5, "Beer", 7.5);
        teams[1].getStadium().startConcessions("Popcorn", 6.25, "Coffee", 4);
        teams[8].getStadium().startConcessions("Popcorn", 6.25, "Soda", 4);
        teams[17].getStadium().startConcessions("Ice Cream", 5.5, "Soda", 4);
        teams[9].getStadium().startConcessions("Cotton Candy", 3.5, "Beer", 7.5);
        teams[10].getStadium().startConcessions("Pizza", 6, "Water", 3);
        teams[18].getStadium().startConcessions("French Fries", 4, "Icees", 5.5);
        teams[24].getStadium().startConcessions("Churros", 3.5, "Beer", 7.5);
        teams[2].getStadium().startConcessions("Cotton Candy", 3.5, "Water", 3);
        teams[25].getStadium().startConcessions("Ice Cream", 5.5, "Soda", 4);
        teams[19].getStadium().startConcessions("Hotdogs", 3.5, "Milkshake", 5);
        teams[26].getStadium().startConcessions("Popcorn", 6.25, "Water", 3);
        teams[20].getStadium().startConcessions("Hamburgers", 7, "Water", 3);
        teams[21].getStadium().startConcessions("Ice Cream", 5.5, "Soda", 4);
        teams[3].getStadium().startConcessions("Ice Cream", 5.5, "Beer", 7.5);
        teams[27].getStadium().startConcessions("Chips", 4, "Soda", 4);
        teams[28].getStadium().startConcessions("Pretzels", 5, "Water", 3);
        teams[11].getStadium().startConcessions("Chips", 4, "Coffee", 4);
        teams[4].getStadium().startConcessions("Hamburgers", 7, "Sports Drink", 4.5);
        teams[29].getStadium().startConcessions("Cookies", 3.5, "Lemonade", 5);
        teams[5].getStadium().startConcessions("Fries", 5, "Lemonade", 5);
        teams[12].getStadium().startConcessions("Cotton Candy", 3.5, "Beer", 7.5);
        teams[30].getStadium().startConcessions("Pizza", 6, "Soda", 4);
        teams[13].getStadium().startConcessions("Chips", 4, "Soda", 4);
        teams[6].getStadium().startConcessions("Popcorn", 6.25, "Soda", 4);
        teams[14].getStadium().startConcessions("Pizza", 6, "Coffee", 4);
        teams[15].getStadium().startConcessions("Cookies", 3.5, "Water", 3);
        teams[7].getStadium().startConcessions("Nachos", 4, "Soda", 3);
        teams[22].getStadium().startConcessions("Hotdogs", 6.75, "Soda", 4);
        teams[23].getStadium().startConcessions("Cookies", 3.5, "Beer", 7.5);
        teams[31].getStadium().startConcessions("Churros", 3.5, "Sports Drink", 4.5);


        teams[0].setTeamResults(new teamResults(new int[] { 25, 12, 13 }));

        teams[1].setTeamResults(new teamResults(new int[] { 20, 2, 2 }));

        teams[2].setTeamResults(new teamResults(new int[] { 2, 4, 5 }));

        teams[3].setTeamResults(new teamResults(new int[] { 26, 11, 26 }));

        teams[4].setTeamResults(new teamResults(new int[] { 15, 20, 30 }));

        teams[5].setTeamResults(new teamResults(new int[] { 32, 6, 14 }));

        teams[6].setTeamResults(new teamResults(new int[] { 18, 23, 8 }));

        teams[7].setTeamResults(new teamResults(new int[] { 4, 10, 3 }));

        teams[8].setTeamResults(new teamResults(new int[] { 29, 16, 21 }));

        teams[9].setTeamResults(new teamResults(new int[] { 27, 8, 10 }));

        teams[10].setTeamResults(new teamResults(new int[] { 10, 18, 17 }));

        teams[11].setTeamResults(new teamResults(new int[] { 8, 29, 27 }));

        teams[12].setTeamResults(new teamResults(new int[] { 12, 25, 15 }));

        teams[13].setTeamResults(new teamResults(new int[] { 14, 27, 19 }));

        teams[14].setTeamResults(new teamResults(new int[] { 23, 31, 32 }));

        teams[15].setTeamResults(new teamResults(new int[] { 6, 13, 11 }));

        teams[16].setTeamResults(new teamResults(new int[] { 24, 24, 7 }));

        teams[17].setTeamResults(new teamResults(new int[] { 3, 7, 18 }));

        teams[18].setTeamResults(new teamResults(new int[] { 22, 32, 31 }));

        teams[19].setTeamResults(new teamResults(new int[] { 9, 5, 6 }));

        teams[20].setTeamResults(new teamResults(new int[] { 5, 9, 9 }));

        teams[21].setTeamResults(new teamResults(new int[] { 7, 17, 22 }));

        teams[22].setTeamResults(new teamResults(new int[] { 21, 22, 23 }));

        teams[23].setTeamResults(new teamResults(new int[] { 13, 19, 29 }));

        teams[24].setTeamResults(new teamResults(new int[] { 16, 26, 28 }));

        teams[25].setTeamResults(new teamResults(new int[] { 19, 28, 16 }));

        teams[26].setTeamResults(new teamResults(new int[] { 1, 1, 1 }));

        teams[27].setTeamResults(new teamResults(new int[] { 31, 30, 25 }));

        teams[28].setTeamResults(new teamResults(new int[] { 17, 15, 4 }));

        teams[29].setTeamResults(new teamResults(new int[] { 11, 21, 24 }));

        teams[30].setTeamResults(new teamResults(new int[] { 28, 3, 12 }));

        teams[31].setTeamResults(new teamResults(new int[] { 30, 14, 20 }));
    }
    /*public player removePlayerFromFreeAgents(int position)
    {
        
        player retVal = freeAgency[position];
        freeAgency.RemoveAt(position);
        return retVal;
    }*/
    private FreeAgents free;
    public void SetFreeAgents(FreeAgents free)
    {
        this.free = free;
    }

    
    public College GetCollege()
    {
        /*college = new College(r);
        college.PlaySeason();
        Console.WriteLine(1);
        college.PlaySeason();
        Console.WriteLine(2);
        college.PlaySeason();
        Console.WriteLine(3);
        college.PlaySeason();
        Console.WriteLine(4);
        college.PlaySeason();
        Console.WriteLine(5);*/
        return college;
    }
    
    public void Progress(List<int> humans)
    {
        foreach(team t in teams)
        {
            if (t.ToString().Equals("Manwx Saguans"))
            {
                player p = freeAgents.GetTopPlayerByPos(1);
                t.OffSeasonAddPlayer(p);
                freeAgents.Remove(p);
                p.SetNewContract(new Contract(1, 1));
            }
            t.FinishDraft();
            t.ProgressPlayers(humans.Contains(t.getTeamNum()));
            if (!humans.Contains(t.getTeamNum()))
                t.FinishOffseason(true);
        }
        
    }
    public void AddRookies()
    {

        /* string[] players = File.ReadAllText("college.fibusave").Split(new string[] { "<player>" }, StringSplitOptions.None);
         for (int i = 1; i <players.Length; i++)
         {
             rookies.Add(new player(players[i]));
         }
        

         rookies.Add(player.GeneratePlayer(1, Country.Wyverncliff, 47, 21, 3, 27, 28, r));
         rookies.Add(player.GeneratePlayer(1, Country.Wyverncliff, 76, 22, 8, 29, 32, r));
         rookies.Add(player.GeneratePlayer(1, Country.Wyverncliff, 65, 20, 6, 27, 31, r));
         rookies.Add(player.GeneratePlayer(1, Country.Dotruga, 53, 23, 6, 27, 32, r));
         rookies.Add(player.GeneratePlayer(1, Country.Dotruga, 68, 21, 2, 27, 32, r));
         rookies.Add(player.GeneratePlayer(1, Country.Dotruga, 73, 19, 7, 31, 35, r));
         rookies.Add(player.GeneratePlayer(1, Country.Dotruga, 55, 19, 4, 32, 36, r));
         rookies.Add(player.GeneratePlayer(1, Country.Tjedigar, 62, 19, 3, 29, 30, r));
         rookies.Add(player.GeneratePlayer(1, Country.Tjedigar, 64, 19, 4, 24, 25, r));
         rookies.Add(player.GeneratePlayer(1, Country.Auspikitan, 69, 23, 5, 28, 31, r));
         rookies.Add(player.GeneratePlayer(1, Country.Auspikitan, 71, 22, 2, 29, 31, r));
         rookies.Add(player.GeneratePlayer(1, Country.Darvincia, 60, 19, 10, 31, 33, r));
         rookies.Add(player.GeneratePlayer(1, Country.Blaist_Blaland, 57, 22, 5, 25, 29, r));
         rookies.Add(player.GeneratePlayer(1, Country.Holykol, 60, 19, 8, 26, 28, r));
         rookies.Add(player.GeneratePlayer(1, Country.Shmupland, 67, 23, 6, 29, 34, r));
         rookies.Add(player.GeneratePlayer(1, Country.Ethanthova, 68, 22, 2, 31, 34, r));
         rookies.Add(player.GeneratePlayer(1, Country.Ethanthova, 60, 23, 6, 30, 33, r));
         rookies.Add(player.GeneratePlayer(1, Country.Ethanthova, 52, 19, 3, 26, 28, r));
         rookies.Add(player.GeneratePlayer(1, Country.Nausicaa, 50, 21, 3, 28, 32, r));
         rookies.Add(player.GeneratePlayer(1, Country.Lyintaria, 42, 20, 3, 30, 33, r));
         rookies.Add(player.GeneratePlayer(1, Country.Lyintaria, 64, 23, 6, 28, 31, r));
         rookies.Add(player.GeneratePlayer(1, Country.Aovensiiv, 40, 19, 6, 29, 33, r));
         rookies.Add(player.GeneratePlayer(1, Country.Eqkirium, 60, 23, 7, 30, 35, r));
         rookies.Add(player.GeneratePlayer(1, Country.Eqkirium, 65, 21, 6, 27, 28, r));
         rookies.Add(player.GeneratePlayer(1, Country.Auspikitan, 70, 21, 4, 29, 34, r));
         rookies.Add(player.GeneratePlayer(1, Country.Sagua, 56, 19, 3, 32, 36, r));
         rookies.Add(player.GeneratePlayer(1, Country.Sagua, 50, 21, 5, 29, 30, r));
         rookies.Add(player.GeneratePlayer(1, Country.Sagua, 71, 19, 8, 28, 32, r));
         rookies.Add(player.GeneratePlayer(1, Country.Barsein, 62, 19, 7, 27, 32, r));
         rookies.Add(player.GeneratePlayer(2, Country.Ethanthova, 82, 22, 5, 27, 30, r));
         rookies.Add(player.GeneratePlayer(2, Country.Dotruga, 75, 22, 8, 30, 33, r));
         rookies.Add(player.GeneratePlayer(2, Country.Wyverncliff, 72, 20, 7, 26, 30, r));
         rookies.Add(player.GeneratePlayer(2, Country.Dotruga, 68, 22, 3, 28, 32, r));
         rookies.Add(player.GeneratePlayer(2, Country.Dotruga, 68, 21, 4, 29, 31, r));
         rookies.Add(player.GeneratePlayer(2, Country.Bielosia, 66, 21, 5, 26, 28, r));
         rookies.Add(player.GeneratePlayer(2, Country.Bielosia, 64, 19, 5, 30, 33, r));
         rookies.Add(player.GeneratePlayer(2, Country.Solea, 60, 19, 5, 27, 28, r));
         rookies.Add(player.GeneratePlayer(2, Country.Shmupland, 60, 19, 3, 28, 31, r));
         rookies.Add(player.GeneratePlayer(2, Country.Aeridani, 69, 22, 4, 26, 28, r));
         rookies.Add(player.GeneratePlayer(2, Country.Czalliso, 59, 21, 7, 28, 30, r));
         rookies.Add(player.GeneratePlayer(2, Country.Aiyota, 57, 19, 5, 30, 32, r));
         rookies.Add(player.GeneratePlayer(2, Country.Auspikitan, 57, 21, 6, 30, 33, r));
         rookies.Add(player.GeneratePlayer(2, Country.Aeridani, 53, 20, 3, 28, 32, r));
         rookies.Add(player.GeneratePlayer(2, Country.Dtersauuw_Sagua, 53, 19, 8, 30, 31, r));
         rookies.Add(player.GeneratePlayer(2, Country.Darvincia, 51, 20, 5, 26, 29, r));
         rookies.Add(player.GeneratePlayer(2, Country.Sagua, 50, 20, 6, 30, 33, r));
         rookies.Add(player.GeneratePlayer(2, Country.Aahrus, 44, 21, 4, 27, 28, r));
         rookies.Add(player.GeneratePlayer(3, Country.Dotruga, 73, 20, 10, 26, 30, r));
         rookies.Add(player.GeneratePlayer(3, Country.Lyintaria, 70, 21, 4, 29, 31, r));
         rookies.Add(player.GeneratePlayer(3, Country.Wyverncliff, 67, 23, 5, 28, 30, r));
         rookies.Add(player.GeneratePlayer(3, Country.Holykol, 66, 21, 1, 29, 33, r));
         rookies.Add(player.GeneratePlayer(3, Country.Bielosia, 65, 21, 10, 29, 32, r));
         rookies.Add(player.GeneratePlayer(3, Country.Sagua, 63, 19, 3, 26, 30, r));
         rookies.Add(player.GeneratePlayer(3, Country.Darvincia, 60, 21, 5, 28, 30, r));
         rookies.Add(player.GeneratePlayer(3, Country.Tjedigar, 59, 19, 3, 27, 29, r));
         rookies.Add(player.GeneratePlayer(3, Country.Barsein, 58, 23, 8, 26, 29, r));
         rookies.Add(player.GeneratePlayer(3, Country.Atapwa, 58, 22, 10, 27, 29, r));
         rookies.Add(player.GeneratePlayer(3, Country.Oesa, 57, 20, 8, 26, 28, r));
         rookies.Add(player.GeneratePlayer(3, Country.Nja, 55, 21, 7, 28, 31, r));
         rookies.Add(player.GeneratePlayer(3, Country.Blaist_Blaland, 54, 19, 4, 29, 32, r));
         rookies.Add(player.GeneratePlayer(3, Country.Barsein, 55, 22, 2, 28, 32, r));
         rookies.Add(player.GeneratePlayer(3, Country.Transhimalia, 63, 19, 6, 29, 32, r));
         rookies.Add(player.GeneratePlayer(3, Country.Czalliso, 61, 20, 4, 27, 29, r));
         rookies.Add(player.GeneratePlayer(3, Country.Aiyota, 62, 20, 6, 29, 31, r));
         rookies.Add(player.GeneratePlayer(3, Country.Aeridani, 64, 19, 7, 26, 29, r));
         rookies.Add(player.GeneratePlayer(3, Country.Aeridani, 53, 21, 3, 28, 32, r));
         rookies.Add(player.GeneratePlayer(3, Country.Teralm, 51, 23, 4, 26, 29, r));
         rookies.Add(player.GeneratePlayer(3, Country.Timbalta, 50, 22, 2, 28, 30, r));
         rookies.Add(player.GeneratePlayer(3, Country.Height_Sagua, 48, 22, 5, 26, 30, r));
         rookies.Add(player.GeneratePlayer(3, Country.Lyintaria, 44, 22, 8, 27, 30, r));
         rookies.Add(player.GeneratePlayer(3, Country.Wyverncliff, 46, 22, 4, 27, 30, r));
         rookies.Add(player.GeneratePlayer(3, Country.Dotruga, 47, 20, 2, 27, 29, r));
         rookies.Add(player.GeneratePlayer(4, Country.Solea, 85, 21, 8, 26, 31, r));
         rookies.Add(player.GeneratePlayer(4, Country.Auspikitan, 74, 22, 7, 28, 29, r));
         rookies.Add(player.GeneratePlayer(4, Country.Auspikitan, 75, 19, 4, 29, 30, r));
         rookies.Add(player.GeneratePlayer(4, Country.Auspikitan, 42, 20, 4, 27, 31, r));
         rookies.Add(player.GeneratePlayer(4, Country.Wyverncliff, 67, 20, 5, 29, 31, r));
         rookies.Add(player.GeneratePlayer(4, Country.Bielosia, 56, 19, 6, 30, 34, r));
         rookies.Add(player.GeneratePlayer(4, Country.Pyxanovia, 45, 22, 5, 28, 30, r));
         rookies.Add(player.GeneratePlayer(4, Country.Dotruga, 80, 19, 5, 27, 29, r));
         rookies.Add(player.GeneratePlayer(4, Country.Dotruga, 67, 22, 4, 28, 29, r));
         rookies.Add(player.GeneratePlayer(4, Country.Dotruga, 66, 19, 5, 28, 30, r));
         rookies.Add(player.GeneratePlayer(4, Country.Helvaena, 70, 22, 5, 26, 27, r));
         rookies.Add(player.GeneratePlayer(4, Country.Shmupland, 47, 21, 6, 29, 33, r));
         rookies.Add(player.GeneratePlayer(4, Country.Tri_National_Dominion, 55, 21, 6, 28, 32, r));
         rookies.Add(player.GeneratePlayer(4, Country.Ethanthova, 58, 23, 8, 28, 31, r));
         rookies.Add(player.GeneratePlayer(4, Country.Ethanthova, 63, 22, 6, 28, 32, r));
         rookies.Add(player.GeneratePlayer(4, Country.Ipal, 47, 22, 6, 29, 32, r));
         rookies.Add(player.GeneratePlayer(4, Country.Tjedigar, 71, 20, 2, 27, 28, r));
         rookies.Add(player.GeneratePlayer(4, Country.Tjedigar, 63, 19, 6, 29, 32, r));
         rookies.Add(player.GeneratePlayer(4, Country.Teralm, 57, 23, 6, 29, 32, r));
         rookies.Add(player.GeneratePlayer(4, Country.Ipal, 60, 22, 4, 28, 30, r));
         rookies.Add(player.GeneratePlayer(4, Country.Aeridani, 51, 19, 5, 29, 33, r));
         rookies.Add(player.GeneratePlayer(4, Country.Aahrus, 42, 22, 5, 25, 27, r));
         rookies.Add(player.GeneratePlayer(4, Country.Transhimalia, 37, 23, 6, 28, 29, r));
         rookies.Add(player.GeneratePlayer(4, Country.Dtersauuw_Sagua, 46, 23, 1, 28, 29, r));
         rookies.Add(player.GeneratePlayer(4, Country.Czalliso, 48, 21, 4, 29, 30, r));
         rookies.Add(player.GeneratePlayer(4, Country.Aiyota, 51, 21, 5, 28, 31, r));
         rookies.Add(player.GeneratePlayer(4, Country.Bongatar, 52, 20, 10, 28, 31, r));
         rookies.Add(player.GeneratePlayer(5, Country.Holy_Yektonisa, 82, 23, 6, 27, 31, r));
         rookies.Add(player.GeneratePlayer(5, Country.Bielosia, 59, 19, 8, 28, 29, r));
         rookies.Add(player.GeneratePlayer(5, Country.Darvincia, 67, 22, 2, 27, 30, r));
         rookies.Add(player.GeneratePlayer(5, Country.Eksola, 64, 22, 7, 29, 33, r));
         rookies.Add(player.GeneratePlayer(5, Country.Kolauk, 62, 22, 8, 28, 29, r));
         rookies.Add(player.GeneratePlayer(5, Country.Wyverncliff, 68, 20, 3, 29, 31, r));
         rookies.Add(player.GeneratePlayer(5, Country.Pyxanovia, 64, 21, 6, 28, 29, r));
         rookies.Add(player.GeneratePlayer(5, Country.Pyxanovia, 60, 21, 1, 26, 27, r));
         rookies.Add(player.GeneratePlayer(5, Country.Shmupland, 71, 22, 7, 27, 31, r));
         rookies.Add(player.GeneratePlayer(5, Country.Helvaena, 68, 23, 6, 29, 31, r));
         rookies.Add(player.GeneratePlayer(5, Country.Lyintaria, 66, 20, 2, 28, 31, r));
         rookies.Add(player.GeneratePlayer(5, Country.Dotruga, 77, 21, 7, 28, 30, r));
         rookies.Add(player.GeneratePlayer(5, Country.Dotruga, 65, 21, 3, 27, 30, r));
         rookies.Add(player.GeneratePlayer(5, Country.Elvine, 63, 22, 8, 28, 32, r));
         rookies.Add(player.GeneratePlayer(5, Country.Tjedigar, 67, 22, 3, 29, 33, r));
         rookies.Add(player.GeneratePlayer(5, Country.Key_to_Don, 58, 21, 9, 27, 31, r));
         rookies.Add(player.GeneratePlayer(5, Country.Sagua, 52, 21, 5, 26, 27, r));
         rookies.Add(player.GeneratePlayer(5, Country.Barsein, 47, 23, 3, 28, 29, r));
         rookies.Add(player.GeneratePlayer(5, Country.Blaist_Blaland, 56, 19, 6, 29, 33, r));
         rookies.Add(player.GeneratePlayer(5, Country.Height_Sagua, 77, 19, 6, 27, 31, r));
         rookies.Add(player.GeneratePlayer(5, Country.Aiyota, 68, 21, 4, 28, 29, r));
         rookies.Add(player.GeneratePlayer(5, Country.Aeridani, 76, 23, 3, 29, 33, r));

         string content = "";
         foreach (player p in rookies)
             content += p.SavePlayer();

         File.WriteAllText("college.fibusave", content);

     */
    }


    public void SetCollege(College college)
    {
        this.college = college;
    }

    public void ReplaceTeam(team temp)
    {
        teams[temp.getTeamNum()] = temp;
    }
}

   
