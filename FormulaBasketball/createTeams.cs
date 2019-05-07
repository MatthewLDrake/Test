using System;
using System.Collections.Generic;
using FormulaBasketball;
using System.IO;
[Serializable]
public class createTeams
{
    private FormulaBasketball.Random r;
    private List<team> teams, dLeagueTeams;
    private List<player> freeAgency;
    private FreeAgents freeAgents;
    private College college;
    private double[,] averagePositionSalaries, minPositionSalaries, maxPositionsSalaries;
    private double[,] averageOverall, minOverall, maxOverall, allOveralls;
    private List<int> gameNums;
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
    }
    public void SaveCreate()
    {
        String fileName = "saveFile.csv";
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
    }
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
    public void CreateNewSchedule()
    {
        gameNums = new List<int>();
        for(int i = 0; i < 84; i++)
        {
            gameNums.Add(i);
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
    private void createTheTeams(string info)
    {
        string[] data = info.Split(new string[] { "<team>" }, StringSplitOptions.None);
        teams = new List<team>();
        for(int i = 1; i < data.Length; i += 2)
        {
            teams.Add(new team(data[i], data[i + 1], r, false));
        }

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
    private void setFianancials()
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

    private List<player> rookies;
    public List<player> GetRookies()
    {
        foreach(player p in rookies) p.IsRookie();
        return rookies;
    }
    public void AddRookies()
    {
        rookies = new List<player>();
        rookies.Add(new player(1, 6, 7, 4, 4, 3, 3, 2, 8, 3, 8, 8, 24, "Sovnox Naixi ", false, 32, 34, 7, Country.Blaist_Blaland, 1191));
        rookies.Add(new player(3, 5, 2, 8, 1, 8, 7, 7, 8, 8, 10, 5, 19, "Olandi Amodetsei ", false, 27, 33, 7, Country.Dotruga, 1192));
        rookies.Add(new player(4, 5, 3, 6, 4, 7, 7, 9, 1, 4, 8, 9, 22, "Handa Seiki ", false, 30, 36, 1, Country.Transhimalia, 1193));
        rookies.Add(new player(1, 5, 7, 1, 4, 4, 6, 5, 9, 3, 9, 8, 22, "Sagolna Hartotasek ", false, 31, 32, 6, Country.Dotruga, 1194));
        rookies.Add(new player(3, 4, 1, 10, 8, 8, 9, 4, 4, 8, 8, 7, 19, "Lee Stidham", false, 28, 33, 3, Country.Ethanthova, 1195));
        rookies.Add(new player(5, 4, 2, 5, 6, 9, 6, 4, 4, 2, 2, 7, 21, "Calvin Hayhurst", false, 30, 36, 9, Country.Ethanthova, 1196));
        rookies.Add(new player(2, 7, 7, 3, 4, 3, 8, 8, 4, 5, 2, 9, 21, "Dennis Tsoi", false, 29, 33, 8, Country.Ethanthova, 1197));
        rookies.Add(new player(5, 8, 1, 5, 3, 6, 3, 5, 2, 7, 6, 8, 22, "Stephen Chapman", false, 28, 32, 5, Country.Wyverncliff, 1198));
        rookies.Add(new player(3, 1, 10, 7, 7, 9, 8, 6, 3, 1, 10, 5, 20, "Váqáp Qlámipanońqo ", false, 27, 32, 9, Country.Sagua, 1199));
        rookies.Add(new player(5, 4, 1, 6, 5, 5, 8, 6, 2, 2, 9, 10, 22, "Kiromibakeili Tute ", false, 28, 32, 6, Country.Dotruga, 1200));
        rookies.Add(new player(1, 4, 3, 1, 1, 2, 8, 9, 10, 4, 6, 7, 22, "Abosa Aludetsei ", false, 30, 36, 7, Country.Dotruga, 1201));
        rookies.Add(new player(3, 8, 10, 6, 9, 6, 5, 4, 1, 10, 7, 10, 22, "Sol Young-Chul ", false, 29, 33, 6, Country.Shmupland, 1202));
        rookies.Add(new player(1, 5, 8, 2, 3, 2, 5, 6, 9, 6, 1, 6, 21, "Harri Umlauf ", false, 30, 34, 5, Country.Tri_National_Dominion, 1203));
        rookies.Add(new player(5, 5, 4, 6, 4, 6, 8, 7, 1, 3, 6, 10, 20, "Mack Cesar", false, 29, 35, 7, Country.Ethanthova, 1204));
        rookies.Add(new player(4, 3, 3, 7, 6, 5, 5, 7, 4, 6, 10, 7, 21, "Wahlady", false, 27, 30, 4, Country.Aiyota, 1205));
        rookies.Add(new player(5, 4, 9, 8, 10, 10, 9, 7, 1, 9, 8, 10, 22, "Làto Cows ", false, 27, 32, 5, Country.Darvincia, 1206));
        rookies.Add(new player(1, 8, 6, 4, 2, 7, 6, 4, 6, 5, 9, 6, 22, "Goormurra", false, 30, 34, 4, Country.Aiyota, 1207));
        rookies.Add(new player(2, 6, 6, 10, 9, 3, 3, 3, 7, 3, 4, 9, 19, "Bane Phothisarath ", false, 27, 31, 9, Country.Lyintaria, 1208));
        rookies.Add(new player(3, 3, 7, 2, 2, 10, 1, 3, 10, 4, 4, 5, 24, "James Ayala", false, 32, 36, 3, Country.Ethanthova, 1209));
        rookies.Add(new player(2, 5, 6, 4, 1, 3, 8, 9, 7, 8, 4, 7, 21, "Onishi Yoshiiku ", false, 29, 34, 5, Country.Barsein, 1210));
        rookies.Add(new player(3, 9, 8, 4, 10, 8, 1, 1, 3, 7, 8, 7, 20, "Nukunaix Hjetohje ", false, 29, 33, 5, Country.Blaist_Blaland, 1211));
        rookies.Add(new player(3, 2, 9, 4, 2, 8, 7, 8, 5, 5, 10, 10, 19, "Om Jae-Wook ", false, 32, 34, 4, Country.Shmupland, 1212));
        rookies.Add(new player(4, 10, 3, 4, 6, 5, 2, 5, 3, 6, 9, 9, 23, "Alundi Bituna ", false, 29, 34, 6, Country.Dotruga, 1213));
        rookies.Add(new player(5, 6, 4, 3, 5, 9, 2, 5, 2, 6, 9, 10, 23, "Nuux Naxix ", false, 32, 33, 6, Country.Blaist_Blaland, 1214));
        rookies.Add(new player(4, 9, 4, 9, 8, 5, 8, 8, 6, 9, 5, 9, 19, "Iklo Eloalerko ", false, 28, 33, 6, Country.Dotruga, 1215));
        rookies.Add(new player(5, 4, 5, 7, 6, 8, 2, 6, 4, 2, 1, 8, 22, "Alotru Fevioka ", false, 32, 35, 7, Country.Dotruga, 1216));
        rookies.Add(new player(5, 4, 2, 4, 6, 7, 7, 5, 1, 2, 6, 9, 23, "Uxku Toxium ", false, 32, 35, 4, Country.Blaist_Blaland, 1217));
        rookies.Add(new player(4, 10, 2, 8, 5, 3, 8, 5, 3, 3, 1, 8, 19, "Himiba Olalomundi ", false, 32, 33, 5, Country.Dotruga, 1218));
        rookies.Add(new player(5, 4, 1, 7, 6, 8, 5, 3, 1, 3, 3, 10, 19, "Nho'ja Vanho ", false, 28, 31, 5, Country.Key_to_Don, 1219));
        rookies.Add(new player(1, 6, 4, 3, 4, 3, 7, 8, 6, 7, 5, 6, 23, "Nàsà Sikasbë ", false, 28, 31, 6, Country.Darvincia, 1220));
        rookies.Add(new player(4, 8, 3, 5, 5, 3, 8, 5, 4, 5, 8, 10, 20, "Rael Ssekien ", false, 31, 35, 10, Country.Barsein, 1221));
        rookies.Add(new player(1, 5, 8, 1, 3, 2, 5, 6, 9, 5, 4, 9, 20, "Cagi  ", false, 27, 33, 5, Country.Aiyota, 1222));
        rookies.Add(new player(1, 6, 7, 1, 1, 8, 4, 5, 6, 8, 10, 9, 19, "Rezinal Naizen ", false, 29, 34, 10, Country.Aeridani, 1223));
        rookies.Add(new player(2, 7, 3, 3, 2, 4, 6, 6, 8, 10, 6, 7, 21, "Alotru Amodetsei ", false, 29, 34, 5, Country.Dotruga, 1224));
        rookies.Add(new player(2, 7, 7, 5, 2, 1, 6, 6, 10, 6, 8, 7, 19, "Nyning  ", false, 27, 30, 4, Country.Aiyota, 1225));
        rookies.Add(new player(4, 7, 2, 6, 7, 4, 7, 4, 1, 8, 1, 5, 20, "Ingo Wagenseil ", false, 31, 32, 7, Country.Tri_National_Dominion, 1226));
        rookies.Add(new player(5, 3, 1, 4, 5, 7, 3, 3, 4, 10, 7, 8, 21, "Blaki Dazaxka ", false, 29, 33, 6, Country.Blaist_Blaland, 1227));
        rookies.Add(new player(2, 3, 2, 1, 3, 7, 6, 4, 8, 10, 10, 10, 22, "Uxnax Sovix ", false, 31, 34, 5, Country.Blaist_Blaland, 1228));
        rookies.Add(new player(3, 2, 7, 1, 9, 4, 4, 2, 10, 4, 3, 6, 21, "Ixux Zaxau ", false, 29, 33, 4, Country.Blaist_Blaland, 1229));
        rookies.Add(new player(4, 6, 2, 7, 6, 6, 5, 5, 3, 6, 3, 9, 22, "Pakomha Nánpa ", false, 29, 34, 9, Country.Key_to_Don, 1230));
        rookies.Add(new player(3, 10, 3, 5, 2, 9, 7, 5, 5, 3, 10, 7, 22, "Randy Feltman", false, 32, 35, 6, Country.Ethanthova, 1231));
        rookies.Add(new player(4, 8, 4, 6, 4, 3, 4, 2, 4, 9, 9, 9, 22, "Xai Alodetsei ", false, 29, 35, 4, Country.Dotruga, 1232));
        rookies.Add(new player(2, 4, 5, 4, 1, 4, 6, 8, 8, 7, 7, 9, 21, "Kanoa Thammavong ", false, 27, 32, 5, Country.Bielosia, 1233));
        rookies.Add(new player(3, 1, 6, 4, 9, 10, 9, 6, 7, 7, 7, 6, 22, "Ḿavwápŕi Pimh ", false, 27, 32, 6, Country.Sagua, 1234));
        rookies.Add(new player(2, 6, 7, 1, 1, 5, 6, 4, 9, 4, 7, 7, 22, "Maik Menorath ", false, 31, 34, 6, Country.Holy_Yektonisa, 1235));
        rookies.Add(new player(1, 7, 7, 3, 4, 4, 3, 3, 6, 6, 8, 10, 21, "Alve Higashikuni ", false, 28, 34, 5, Country.Barsein, 1236));
        rookies.Add(new player(4, 7, 2, 6, 5, 5, 5, 8, 4, 5, 4, 8, 22, "Yamataka Hiroaki ", false, 27, 30, 3, Country.Transhimalia, 1237));
        rookies.Add(new player(2, 10, 6, 6, 8, 3, 7, 6, 8, 9, 6, 8, 19, "Phetdum Bouvanaat ", false, 28, 31, 6, Country.Holy_Yektonisa, 1238));
        rookies.Add(new player(4, 8, 4, 4, 3, 4, 4, 9, 2, 9, 7, 9, 23, "Uwe Bischoff ", false, 29, 34, 4, Country.Tri_National_Dominion, 1239));
        rookies.Add(new player(1, 6, 10, 4, 2, 5, 7, 7, 15, 7, 3, 8, 19, "Thomas Skinner", false, 28, 34, 6, Country.Wyverncliff, 1240));
        rookies.Add(new player(5, 3, 4, 5, 3, 10, 6, 2, 4, 7, 3, 5, 19, "Kompasu Toshiyuki ", false, 30, 35, 4, Country.Aeridani, 1241));
        rookies.Add(new player(1, 9, 1, 2, 4, 4, 6, 6, 7, 4, 5, 5, 20, "Pusu Iode ", false, 30, 34, 6, Country.Bongatar, 1242));
        rookies.Add(new player(2, 10, 6, 3, 3, 5, 4, 4, 7, 4, 5, 8, 23, "Pranga  ", false, 29, 33, 9, Country.Aiyota, 1243));
        rookies.Add(new player(1, 8, 5, 1, 2, 4, 9, 4, 8, 6, 7, 8, 19, "noe  ", false, 31, 35, 5, Country.Czalliso, 1244));
        rookies.Add(new player(4, 9, 1, 8, 2, 5, 2, 2, 3, 7, 9, 8, 22, "Danomobei Hiemeta ", false, 30, 33, 7, Country.Dotruga, 1245));
        rookies.Add(new player(2, 5, 6, 3, 4, 3, 7, 6, 7, 5, 4, 7, 22, "Autanblanaix Auproda ", false, 32, 34, 7, Country.Blaist_Blaland, 1246));
        rookies.Add(new player(4, 7, 1, 5, 5, 2, 3, 6, 4, 3, 9, 6, 23, "Milton Solorzano", false, 29, 35, 8, Country.Ethanthova, 1247));
        rookies.Add(new player(3, 2, 2, 1, 8, 5, 1, 7, 3, 8, 7, 9, 21, "Kiro Hidolundi ", false, 28, 32, 6, Country.Dotruga, 1248));
        rookies.Add(new player(3, 3, 6, 4, 9, 1, 7, 5, 3, 9, 8, 8, 23, "Ulatrusiei Hisei ", false, 27, 30, 5, Country.Dotruga, 1249));
        rookies.Add(new player(2, 4, 5, 6, 4, 5, 4, 10, 7, 6, 1, 10, 23, "Sathanalat Vatthana ", false, 27, 31, 3, Country.Bielosia, 1250));
        rookies.Add(new player(2, 6, 8, 4, 6, 2, 4, 8, 8, 5, 6, 6, 21, "Stanley Price", false, 27, 30, 5, Country.Ethanthova, 1251));
        rookies.Add(new player(4, 6, 3, 5, 5, 7, 2, 6, 4, 6, 4, 5, 19, "Jeff Bellow", false, 28, 34, 6, Country.Ethanthova, 1252));
        rookies.Add(new player(5, 7, 4, 5, 2, 7, 3, 5, 1, 3, 7, 8, 20, "Hvanne Shunmyo ", false, 28, 34, 6, Country.Barsein, 1253));
        rookies.Add(new player(2, 10, 2, 4, 5, 6, 7, 7, 7, 8, 5, 7, 23, "Asser Hutto ", false, 27, 33, 7, Country.Tri_National_Dominion, 1254));
        rookies.Add(new player(1, 5, 6, 2, 1, 5, 3, 4, 7, 5, 5, 10, 20, "Atusosa Hisei ", false, 28, 33, 2, Country.Dotruga, 1255));
        rookies.Add(new player(1, 4, 7, 2, 2, 3, 5, 2, 7, 6, 2, 8, 22, "Charrat  ", false, 30, 36, 1, Country.Aiyota, 1256));
        rookies.Add(new player(1, 4, 5, 3, 1, 4, 5, 2, 7, 8, 7, 6, 23, "Cocogo  ", false, 27, 33, 7, Country.Aiyota, 1257));
        rookies.Add(new player(1, 4, 4, 1, 4, 5, 7, 8, 7, 3, 4, 5, 19, "Dgenek Kvviiké ", false, 30, 36, 4, Country.Transhimalia, 1258));
        rookies.Add(new player(1, 8, 6, 1, 1, 4, 4, 3, 8, 2, 8, 5, 21, "Kersuvi Himamosei ", false, 30, 35, 4, Country.Dotruga, 1259));
        rookies.Add(new player(1, 6, 7, 1, 2, 1, 10, 8, 8, 1, 2, 6, 20, "Makan Savang ", false, 31, 32, 1, Country.Pyxanovia, 1260));
        rookies.Add(new player(1, 7, 7, 1, 4, 1, 4, 5, 7, 1, 8, 10, 19, "Nagata Saikaku ", false, 28, 34, 2, Country.Transhimalia, 1261));
        rookies.Add(new player(1, 5, 8, 2, 1, 4, 4, 1, 7, 2, 4, 7, 24, "Sovtanzax Kibla ", false, 29, 34, 6, Country.Blaist_Blaland, 1262));
        rookies.Add(new player(1, 5, 4, 1, 2, 2, 10, 10, 4, 1, 1, 8, 20, "Volkhardt Klostermann ", false, 28, 34, 6, Country.Tri_National_Dominion, 1263));
        rookies.Add(new player(1, 7, 5, 4, 4, 4, 3, 5, 7, 4, 8, 8, 22, "Volkhardt Schröpfer ", false, 32, 35, 1, Country.Tri_National_Dominion, 1264));
        rookies.Add(new player(2, 4, 3, 5, 3, 1, 5, 4, 6, 3, 10, 10, 21, "Alfred Alt ", false, 29, 34, 6, Country.Tri_National_Dominion, 1265));
        rookies.Add(new player(2, 8, 4, 1, 1, 2, 3, 2, 7, 5, 3, 8, 23, "Anthony Mendez", false, 32, 33, 8, Country.Wyverncliff, 1266));
        rookies.Add(new player(2, 5, 5, 5, 2, 3, 6, 4, 7, 7, 6, 5, 21, "Boḿa Pámhóǵwá ", false, 31, 32, 1, Country.Nausicaa, 1267));
        rookies.Add(new player(2, 6, 6, 6, 6, 1, 7, 4, 7, 6, 2, 5, 23, "Ingo Samter ", false, 31, 32, 1, Country.Tri_National_Dominion, 1268));
        rookies.Add(new player(2, 7, 4, 3, 1, 2, 8, 2, 9, 6, 8, 7, 22, "James Dunn", false, 28, 31, 4, Country.Wyverncliff, 1269));
        rookies.Add(new player(2, 4, 4, 5, 3, 5, 10, 6, 5, 2, 8, 6, 22, "Joshua Doney", false, 27, 30, 4, Country.Wyverncliff, 1270));
        rookies.Add(new player(2, 6, 6, 7, 2, 3, 6, 5, 7, 5, 6, 8, 22, "Liko Menorath ", false, 28, 33, 3, Country.Bielosia, 1271));
        rookies.Add(new player(2, 6, 4, 2, 2, 7, 3, 10, 7, 3, 5, 7, 24, "Louis Wagenseil ", false, 27, 33, 1, Country.Tri_National_Dominion, 1272));
        rookies.Add(new player(2, 4, 5, 3, 5, 2, 6, 4, 8, 4, 5, 7, 20, "Matthew Vermillion", false, 28, 34, 6, Country.Ethanthova, 1273));
        rookies.Add(new player(3, 6, 6, 6, 1, 3, 4, 3, 2, 9, 1, 7, 23, "Atumundikeili Bexote ", false, 30, 35, 3, Country.Dotruga, 1274));
        rookies.Add(new player(3, 6, 3, 2, 6, 4, 2, 1, 4, 9, 9, 5, 21, "Ydar Jeem ", false, 32, 34, 4, Country.Bongatar, 1275));
        rookies.Add(new player(4, 8, 4, 7, 6, 4, 1, 1, 2, 4, 5, 7, 22, "Alumobei Hialerko ", false, 30, 33, 5, Country.Dotruga, 1276));
        rookies.Add(new player(4, 7, 2, 5, 6, 3, 6, 4, 2, 5, 4, 7, 21, "Ametsuchi Hideki ", false, 27, 31, 3, Country.Aeridani, 1277));
        rookies.Add(new player(4, 8, 4, 3, 1, 7, 6, 4, 2, 1, 5, 6, 20, "Charles Alday", false, 27, 32, 4, Country.Ethanthova, 1278));
        rookies.Add(new player(4, 3, 4, 4, 4, 6, 5, 7, 2, 5, 2, 9, 24, "Havika Phothisarath ", false, 31, 32, 3, Country.Lyintaria, 1279));
        rookies.Add(new player(4, 10, 1, 4, 3, 4, 9, 1, 3, 4, 4, 9, 21, "Kimo Rattanavongsa ", false, 28, 31, 3, Country.Bielosia, 1280));
        rookies.Add(new player(4, 9, 3, 5, 3, 4, 10, 5, 2, 1, 1, 7, 22, "Leilani Thammavong ", false, 27, 31, 6, Country.Pyxanovia, 1281));
        rookies.Add(new player(4, 9, 3, 2, 1, 3, 7, 5, 1, 4, 3, 10, 24, "Ńà Nhòà ", false, 31, 34, 6, Country.Pentadominion, 1282));
        rookies.Add(new player(4, 1, 1, 2, 3, 5, 2, 5, 2, 3, 9, 6, 21, "Timblejoorany  ", false, 31, 35, 7, Country.Aiyota, 1283));
        rookies.Add(new player(4, 3, 3, 7, 7, 7, 3, 2, 1, 5, 5, 7, 22, "Weer  ", false, 27, 30, 7, Country.Aiyota, 1284));
        rookies.Add(new player(4, 8, 4, 8, 4, 6, 3, 5, 1, 3, 10, 7, 24, "Yuguchi Izo ", false, 31, 34, 1, Country.Transhimalia, 1285));
        rookies.Add(new player(5, 6, 1, 3, 3, 8, 5, 4, 1, 2, 7, 7, 20, "Hannes Kluck ", false, 29, 32, 3, Country.Tri_National_Dominion, 1286));
        rookies.Add(new player(5, 5, 1, 7, 4, 8, 2, 3, 4, 2, 10, 6, 19, "Kawata Hakuseki ", false, 30, 35, 3, Country.Transhimalia, 1287));
        rookies.Add(new player(5, 5, 2, 4, 2, 4, 5, 8, 1, 3, 4, 9, 23, "Kye Genevong ", false, 29, 35, 7, Country.Bielosia, 1288));
        rookies.Add(new player(5, 7, 3, 5, 6, 4, 5, 3, 2, 4, 5, 10, 21, "lu  ", false, 28, 31, 2, Country.Norkute, 1289));
        rookies.Add(new player(5, 2, 1, 7, 3, 8, 3, 8, 3, 1, 2, 8, 22, "Tugano Bexosek ", false, 32, 34, 4, Country.Dotruga, 1290));
        rookies.Add(new player(5, 3, 1, 6, 4, 5, 8, 4, 3, 2, 10, 10, 22, "Tusaro Elolapo ", false, 28, 34, 5, Country.Dotruga, 1291));
        rookies.Add(new player(5, 6, 8, 1, 1, 5, 5, 4, 1, 7, 9, 8, 21, "Warren Radcliffe", false, 31, 33, 5, Country.Ethanthova, 1292));
        rookies.Add(new player(5, 2, 1, 5, 4, 3, 1, 4, 3, 4, 6, 10, 23, "Watsuji Sumiteru ", false, 32, 36, 6, Country.Barsein, 1293));


    }

}

   
