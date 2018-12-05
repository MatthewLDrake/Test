using System;
using System.Collections.Generic;
[Serializable]
public class createTeams
{
    private FormulaBasketball.Random r;
    private List<team> teams, dLeagueTeams;
    private List<player> freeAgency;
    private Schedule schedule;
    private FreeAgents freeAgents;
    private College college;
    private double[,] averagePositionSalaries, minPositionSalaries, maxPositionsSalaries;
    private double[,] averageOverall, minOverall, maxOverall, allOveralls;
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

        schedule = new Schedule(r);

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
        schedule = new Schedule(r);
    }
    public Schedule GetSchedule()
    {
        if (schedule == null) CreateNewSchedule();
        return schedule;
    }
    public createTeams(FormulaBasketball.Random r)
    {
        this.r = r;
        teams = new List<team>();
        dLeagueTeams = new List<team>();
        freeAgents = new FreeAgents();
        college = new College(r);
        createTheTeams();
        //createTeamTwo();
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
    private void createTheTeams()
    {
        teams.Add(new team("Aahrus Moosi",r));

        
        teams.Add(new team("Auspikitan Golden Falcons", r));
        
        teams.Add(new team("Calto Cows", r));
        
        teams.Add(new team("Height Sagua Cats", r));
       
        teams.Add(new team("Key to Don Yees", r));
       
        teams.Add(new team("Manwx Saguans", r));
        
        teams.Add(new team("Sagua Ocelots", r));
        
        teams.Add(new team("Solea Geysers", r));
        

        teams.Add(new team("Autolik Autonomy", r));
        
        teams.Add(new team("Barsein Bats", r));
       
        teams.Add(new team("Blanaxon Hammers", r));
       
        teams.Add(new team("Kaeshar Kaisers", r));
       
        teams.Add(new team("Naxda Nomads", r));
        
        teams.Add(new team("Red Rainbow Sickles", r));
       
        teams.Add(new team("Serkr Atolls", r));
        
        teams.Add(new team("Shmupland Dictators", r));
     

        teams.Add(new team("Aiyota Pumps", r));
       
        teams.Add(new team("Avura Aviators", r));
       
        teams.Add(new team("Boltway Bad Dragons", r));
       
        teams.Add(new team("Dotruga Falno", r));
       
        
        teams.Add(new team("Ethanthova Ponies", r));
        
        teams.Add(new team("Faehrenfall Feathercats", r));
        
        teams.Add(new team("Stedro Boulders", r));
        
        teams.Add(new team("TND Tanks", r));
       

        teams.Add(new team("Bongatar Banging Bongos", r));
       
        teams.Add(new team("Czalliso Pythons", r));
       
        teams.Add(new team("Dvimne Spirits", r));
      
        teams.Add(new team("Holy Yektonisa Bishops", r));
        
        teams.Add(new team("Holykol Bears", r));
       
        teams.Add(new team("Lyintaria Lynx", r));

        teams.Add(new team("Pyxanovia Pixies", r));

        teams.Add(new team("Transhimalia Disasters", r));

        teams[0].addPlayer(new player(1, 7, 10, 4, 2, 5, 10, 9, 12, 8, 9, 5, 21, "Ajanis Vealerko", Country.Dotruga, false));
        teams[0].addPlayer(new player(2, 8, 9, 4, 4, 5, 6, 5, 9, 7, 5, 10, 26, "Yombeen", Country.Aiyota, false));
        teams[0].addPlayer(new player(3, 9, 2, 6, 1, 5, 5, 8, 6, 10, 5, 10, 24, "Nadaklo Praxo", Country.Blaist_Blaland, false));
        teams[0].addPlayer(new player(4, 5, 4, 10, 10, 7, 8, 6, 2, 10, 5, 8, 23, "Kardo Gasbërr", Country.Darvincia, false));
        teams[0].addPlayer(new player(5, 2, 3, 10, 10, 9, 4, 7, 3, 10, 5, 7, 27, "Venniti Flautika", Country.Bielosia, false));
        teams[0].addPlayer(new player(5, 3, 6, 10, 10, 10, 6, 3, 1, 6, 5, 5, 27, "Aahrus Player #10", Country.Aahrus, false));
        teams[0].addPlayer(new player(4, 5, 5, 8, 8, 4, 6, 7, 3, 3, 5, 10, 27, "Aahrus Player #4", Country.Aahrus, false));
        teams[0].addPlayer(new player(3, 8, 9, 7, 8, 4, 6, 9, 7, 7, 7, 10, 21, "Kawata Hirokazu", Country.Aeridani, false));
        teams[0].addPlayer(new player(1, 8, 8, 2, 2, 3, 10, 5, 9, 4, 5, 7, 27, "Aahrus Player #2", Country.Aahrus, false));
        teams[0].addPlayer(new player(5, 5, 4, 7, 7, 10, 7, 5, 1, 1, 5, 5, 23, "Omumesomobesa Lemrombatdesi", Country.Dotruga, false));
        teams[0].addPlayer(new player(3, 4, 4, 7, 8, 9, 10, 8, 7, 4, 3, 7, 24, "Lae Thammavong", Country.Pyxanovia, false));
        teams[0].addPlayer(new player(2, 7, 8, 1, 1, 5, 7, 4, 9, 3, 5, 10, 22, "Oisín Barnett", Country.Ethanthova, false));
        teams[0].addPlayer(new player(2, 7, 9, 6, 6, 3, 6, 4, 10, 3, 5, 10, 25, "P'uyo Unup'a", Country.Dtersauuw_Sagua, false));
        teams[0].addPlayer(new player(4, 5, 1, 7, 7, 4, 8, 7, 4, 6, 5, 10, 25, "Takishima Kazuko", Country.Aeridani, false));
        teams[0].addPlayer(new player(1, 8, 10, 4, 4, 3, 5, 8, 8, 5, 1, 6, 23, "Steve Lolant", Country.Wyverncliff, false));

        teams[16].addPlayer(new player(1, 10, 8, 3, 3, 3, 3, 8, 8, 6, 5, 5, 24, "Pixtij Lekaxo", Country.Blaist_Blaland, false));
        teams[16].addPlayer(new player(2, 9, 7, 6, 7, 6, 7, 7, 8, 9, 1, 10, 25, "Paparto Bexosek", Country.Dotruga, false));
        teams[16].addPlayer(new player(3, 4, 5, 9, 9, 8, 9, 8, 7, 6, 5, 10, 27, "Aiyota Player #5", Country.Aiyota, false));
        teams[16].addPlayer(new player(4, 4, 2, 12, 12, 10, 9, 9, 1, 12, 5, 10, 23, "San Holo", Country.Height_Sagua, false));
        teams[16].addPlayer(new player(5, 5, 3, 8, 8, 11, 4, 7, 4, 6, 5, 10, 27, "Aiyota Player #2", Country.Aiyota, false));
        teams[16].addPlayer(new player(1, 8, 9, 1, 1, 1, 10, 6, 7, 6, 5, 7, 27, "Aiyota Player #1", Country.Aiyota, false));
        teams[16].addPlayer(new player(5, 4, 5, 6, 7, 10, 8, 5, 4, 7, 10, 8, 20, "Olandi Olamos", Country.Dotruga, false));
        teams[16].addPlayer(new player(2, 4, 10, 4, 4, 4, 6, 6, 9, 6, 5, 10, 24, "Pitro Tenopro", Country.Blaist_Blaland, false));
        teams[16].addPlayer(new player(2, 9, 6, 5, 4, 5, 6, 6, 9, 4, 3, 9, 21, "Günther Umlauf", Country.Tri_National_Dominion, false));
        teams[16].addPlayer(new player(3, 5, 5, 6, 6, 8, 7, 1, 2, 8, 5, 10, 27, "Aiyota Player #6", Country.Aiyota, false));
        teams[16].addPlayer(new player(5, 5, 5, 7, 6, 7, 4, 8, 10, 6, 6, 9, 22, "Niclas Unterberger", Country.Tri_National_Dominion, false));
        teams[16].addPlayer(new player(4, 7, 5, 10, 10, 2, 6, 4, 4, 6, 8, 8, 23, "Hiroshima Yakumo", Country.Aeridani, false));
        teams[16].addPlayer(new player(4, 3, 2, 9, 9, 7, 8, 4, 1, 7, 5, 9, 27, "Key To Don Player #3", Country.Key_to_Don, false));
        teams[16].addPlayer(new player(1, 8, 9, 2, 1, 5, 5, 10, 7, 6, 7, 6, 24, "Akamine Yakumo", Country.Aeridani, false));
        teams[16].addPlayer(new player(3, 8, 4, 9, 9, 5, 5, 3, 3, 8, 5, 10, 27, "xek", Country.Holykol, false));

        teams[1].addPlayer(new player(1, 10, 7, 1, 1, 4, 9, 10, 12, 6, 5, 6, 23, "Yadingallie", Country.Aiyota, false));
        teams[1].addPlayer(new player(2, 10, 7, 8, 8, 7, 10, 10, 9, 6, 5, 9, 26, "Jesse McSteve", Country.Wyverncliff, false));
        teams[1].addPlayer(new player(3, 10, 5, 1, 1, 8, 9, 6, 10, 7, 5, 9, 27, "Aahrus Player #1", Country.Aahrus, false));
        teams[1].addPlayer(new player(4, 10, 8, 10, 10, 8, 9, 7, 2, 8, 6, 7, 22, "Lato Ikro", Country.Blaist_Blaland, false));
        teams[1].addPlayer(new player(5, 4, 4, 6, 6, 15, 9, 8, 5, 6, 5, 5, 24, "Billingulbut", Country.Aiyota, false));
        teams[1].addPlayer(new player(3, 9, 10, 2, 5, 5, 6, 9, 5, 10, 3, 9, 23, "Nupa Ixau", Country.Blaist_Blaland, false));
        teams[1].addPlayer(new player(2, 7, 8, 7, 8, 5, 7, 4, 6, 9, 1, 6, 22, "Phetdum Somphonpadee", Country.Bielosia, false));
        teams[1].addPlayer(new player(3, 5, 8, 3, 3, 8, 9, 7, 7, 7, 5, 8, 27, "Small Forward #114", Country.Auspikitan, false));
        teams[1].addPlayer(new player(2, 5, 9, 2, 2, 3, 10, 8, 8, 2, 5, 5, 27, "Chip Hancock", Country.Wyverncliff, false));
        teams[1].addPlayer(new player(5, 5, 4, 9, 9, 5, 4, 7, 4, 6, 5, 5, 27, "Nasi Pindaiabu", Country.Auspikitan, false));
        teams[1].addPlayer(new player(5, 4, 3, 10, 10, 8, 7, 6, 1, 7, 7, 7, 23, "Gerard Mortlock", Country.Ethanthova, false));
        teams[1].addPlayer(new player(1, 9, 10, 2, 3, 5, 10, 5, 9, 7, 7, 8, 24, "Alfred Habicht", Country.Tri_National_Dominion, false));
        teams[1].addPlayer(new player(1, 8, 9, 2, 1, 3, 10, 5, 8, 7, 4, 8, 25, "Naqánkló Qjodlonhámh", Country.Key_to_Don, false));
        teams[1].addPlayer(new player(4, 6, 2, 10, 10, 4, 8, 6, 3, 6, 5, 7, 27, "Taneba Nole", Country.Auspikitan, false));
        teams[1].addPlayer(new player(4, 4, 4, 8, 8, 6, 9, 6, 2, 9, 5, 7, 24, "Palani Phomsouvanh", Country.Bielosia, false));

        teams[8].addPlayer(new player(1, 10, 7, 1, 1, 3, 9, 8, 10, 7, 7, 7, 26, "Boolway", Country.Aiyota, false));
        teams[8].addPlayer(new player(2, 7, 7, 4, 4, 4, 10, 7, 8, 5, 5, 10, 27, "Nopá Kánpovragá", Country.Height_Sagua, false));
        teams[8].addPlayer(new player(3, 10, 4, 8, 6, 6, 5, 10, 9, 10, 4, 10, 22, "Pakomha Pjagwazwi", Country.Sagua, false));
        teams[8].addPlayer(new player(4, 4, 3, 8, 8, 8, 7, 7, 3, 7, 7, 7, 23, "Keoki Vongsay", Country.Loviniosa, false));
        teams[8].addPlayer(new player(5, 2, 3, 10, 10, 10, 8, 6, 4, 8, 7, 8, 27, "enoikh apéka zeilun", Country.Solea, false));
        teams[8].addPlayer(new player(3, 9, 3, 10, 10, 4, 4, 6, 10, 8, 10, 8, 22, "Nopá Nonhkwaqan", Country.Sagua, false));
        teams[8].addPlayer(new player(3, 10, 3, 4, 3, 6, 9, 7, 3, 5, 2, 8, 21, "Paxathipatai Phoutthasinh", Country.Bielosia, false));
        teams[8].addPlayer(new player(4, 5, 5, 7, 7, 6, 5, 6, 3, 10, 4, 8, 20, "Ikaika Kethavongsa", Country.Pyxanovia, false));
        teams[8].addPlayer(new player(1, 9, 10, 3, 2, 2, 5, 10, 10, 5, 10, 8, 24, "Iwayanagi Harumi", Country.Transhimalia, false));
        teams[8].addPlayer(new player(5, 3, 5, 8, 8, 10, 10, 6, 6, 7, 5, 6, 24, "Yasutake Yasuoka", Country.Aeridani, false));
        teams[8].addPlayer(new player(2, 8, 10, 1, 1, 3, 6, 6, 9, 6, 5, 5, 23, "Atotra Bexek", Country.Dotruga, false));
        teams[8].addPlayer(new player(5, 5, 4, 6, 7, 9, 3, 8, 1, 5, 1, 7, 23, "Ḿavwápŕi Makŕavamhan", Country.Height_Sagua, false));
        teams[8].addPlayer(new player(1, 10, 10, 4, 3, 3, 7, 8, 10, 7, 2, 6, 24, "Keahi Genevong", Country.Lyintaria, false));
        teams[8].addPlayer(new player(4, 2, 4, 10, 10, 4, 5, 7, 4, 3, 5, 5, 26, "Mornay", Country.Aiyota, false));
        teams[8].addPlayer(new player(2, 10, 10, 5, 5, 2, 5, 6, 8, 3, 5, 5, 25, "William Fudge", Country.Ethanthova, false));

        teams[17].addPlayer(new player(1, 7, 9, 5, 2, 4, 10, 8, 8, 8, 2, 8, 23, "Omumiba Keget", Country.Dotruga, false));
        teams[17].addPlayer(new player(2, 10, 3, 6, 6, 4, 8, 10, 8, 8, 5, 8, 27, "Tibiziŋag Ifet", Country.Auspikitan, false));
        teams[17].addPlayer(new player(3, 9, 9, 5, 6, 9, 8, 8, 8, 7, 9, 7, 23, "Kilik Farhje", Country.Blaist_Blaland, false));
        teams[17].addPlayer(new player(4, 8, 2, 9, 9, 10, 7, 6, 4, 8, 5, 7, 27, "Floenne Zan", Country.Aeridani, false));
        teams[17].addPlayer(new player(1, 7, 10, 4, 3, 3, 4, 6, 8, 5, 8, 10, 21, "Yamataka Sadaharu", Country.Aeridani, false));
        teams[17].addPlayer(new player(5, 6, 1, 6, 4, 7, 6, 8, 7, 4, 2, 8, 25, "Alosembi Elotrisei", Country.Dotruga, false));
        teams[17].addPlayer(new player(5, 6, 2, 8, 9, 8, 6, 7, 2, 7, 4, 8, 21, "Hannes Ehrenstein", Country.Tri_National_Dominion, false));
        teams[17].addPlayer(new player(3, 8, 6, 7, 7, 6, 6, 5, 4, 6, 5, 8, 24, "Ijba Bexotrugo", Country.Dotruga, false));
        teams[17].addPlayer(new player(1, 10, 10, 2, 2, 2, 9, 5, 7, 8, 1, 10, 23, "Yamazaki Senichi", Country.Aeridani, false));
        teams[17].addPlayer(new player(2, 8, 4, 4, 4, 4, 8, 7, 7, 6, 7, 8, 27, "Autolik Player #1", Country.Blaist_Blaland, false));
        teams[17].addPlayer(new player(4, 10, 7, 7, 7, 2, 5, 6, 2, 8, 3, 10, 24, "Alotru Keget", Country.Dotruga, false));
        teams[17].addPlayer(new player(5, 7, 3, 6, 5, 10, 6, 7, 9, 7, 4, 7, 26, "Akamu Cheruene", Country.Pyxanovia, false));
        teams[17].addPlayer(new player(4, 2, 3, 9, 9, 5, 7, 3, 4, 6, 5, 5, 27, "Siolle Lago", Country.Aeridani, false));
        teams[17].addPlayer(new player(2, 5, 3, 6, 6, 2, 9, 4, 9, 6, 5, 5, 23, "Sundaa Wen", Country.Aeridani, false));
        teams[17].addPlayer(new player(3, 8, 1, 5, 5, 10, 7, 10, 7, 7, 5, 10, 25, "Sichaizei Sha", Country.Aeridani, false));

        teams[9].addPlayer(new player(1, 9, 9, 2, 2, 1, 10, 9, 10, 8, 5, 6, 24, "Keon Saengsavang", Country.Loviniosa, false));
        teams[9].addPlayer(new player(2, 9, 7, 3, 5, 6, 8, 7, 8, 9, 5, 7, 23, "Keahi Saengsavang", Country.Loviniosa, false));
        teams[9].addPlayer(new player(3, 3, 8, 9, 9, 7, 8, 8, 7, 8, 5, 9, 25, "Matthew Grabochov", Country.Wyverncliff, false));
        teams[9].addPlayer(new player(4, 8, 5, 9, 7, 8, 8, 8, 4, 10, 5, 10, 23, "pot", Country.Czalliso, false));
        teams[9].addPlayer(new player(5, 8, 4, 5, 5, 10, 10, 10, 5, 7, 5, 6, 27, "Danomobei Subeina", Country.Dotruga, false));
        teams[9].addPlayer(new player(2, 6, 6, 5, 6, 6, 8, 9, 6, 8, 3, 5, 23, "Sagomundisei Hisei", Country.Dotruga, false));
        teams[9].addPlayer(new player(2, 9, 6, 6, 2, 5, 4, 5, 10, 8, 4, 5, 21, "Quinten Grabochov", Country.Wyverncliff, false));
        teams[9].addPlayer(new player(4, 10, 9, 10, 10, 4, 7, 4, 4, 5, 2, 9, 22, "Aulii Thonemany", Country.Bielosia, false));
        teams[9].addPlayer(new player(1, 6, 6, 3, 2, 2, 7, 10, 8, 7, 9, 6, 22, "Yembeane", Country.Aiyota, false));
        teams[9].addPlayer(new player(3, 8, 4, 9, 9, 2, 4, 4, 8, 1, 5, 10, 27, "Barsein Player #7", Country.Barsein, false));
        teams[9].addPlayer(new player(1, 8, 9, 2, 1, 2, 7, 10, 10, 4, 4, 7, 23, "Bruce Mack", Country.Ethanthova, false));
        teams[9].addPlayer(new player(5, 3, 3, 8, 10, 6, 5, 5, 5, 9, 5, 7, 24, "Keahi Siyavong", Country.Loviniosa, false));
        teams[9].addPlayer(new player(5, 3, 1, 10, 10, 5, 8, 4, 4, 4, 5, 7, 26, "Dimitri Lolant", Country.Wyverncliff, false));
        teams[9].addPlayer(new player(3, 5, 4, 9, 9, 4, 3, 6, 5, 7, 5, 8, 24, "Om Kwang-Seok", Country.Shmupland, false));
        teams[9].addPlayer(new player(4, 6, 2, 6, 6, 6, 8, 7, 2, 9, 5, 6, 23, "Yuguchi Tomiji", Country.Aeridani, false));

        teams[10].addPlayer(new player(1, 9, 8, 3, 3, 4, 9, 4, 8, 5, 5, 10, 27, "Blanaxon Player #1", Country.Blaist_Blaland, false));
        teams[10].addPlayer(new player(2, 5, 5, 6, 6, 2, 10, 6, 9, 5, 5, 7, 27, "Blanaxon Player #3", Country.Blaist_Blaland, false));
        teams[10].addPlayer(new player(3, 9, 5, 6, 6, 12, 3, 10, 10, 8, 5, 8, 24, "Nobira Nariaki", Country.Aeridani, false));
        teams[10].addPlayer(new player(4, 3, 3, 10, 8, 8, 7, 8, 4, 10, 8, 5, 23, "Brian Lolant", Country.Wyverncliff, false));
        teams[10].addPlayer(new player(5, 1, 3, 8, 8, 9, 5, 6, 4, 10, 5, 8, 27, "Baker", Country.Darvincia, false));
        teams[10].addPlayer(new player(4, 2, 3, 9, 9, 4, 5, 5, 4, 10, 5, 10, 25, "Edgar Fichtner", Country.Tri_National_Dominion, false));
        teams[10].addPlayer(new player(3, 9, 8, 1, 1, 3, 10, 6, 9, 7, 7, 6, 27, "Autolik Player #4", Country.Blaist_Blaland, false));
        teams[10].addPlayer(new player(4, 5, 1, 7, 7, 4, 8, 7, 4, 6, 5, 5, 27, "Blanaxon Player #6", Country.Blaist_Blaland, false));
        teams[10].addPlayer(new player(5, 5, 4, 7, 6, 10, 8, 5, 6, 7, 4, 6, 20, "Versi Alovek", Country.Dotruga, false));
        teams[10].addPlayer(new player(5, 4, 5, 6, 5, 9, 6, 4, 3, 8, 5, 8, 23, "Ikaika Phomsouvanh", Country.Lyintaria, false));
        teams[10].addPlayer(new player(3, 2, 9, 3, 2, 5, 5, 6, 6, 10, 8, 9, 22, "Chu Chin-Ho", Country.Shmupland, false));
        teams[10].addPlayer(new player(1, 7, 6, 7, 8, 4, 6, 4, 8, 8, 5, 7, 22, "Bob Gagodo", Country.Dotruga, false));
        teams[10].addPlayer(new player(2, 4, 5, 4, 4, 6, 8, 5, 9, 4, 5, 9, 23, "Iggy Bolter", Country.Ethanthova, false));
        teams[10].addPlayer(new player(1, 7, 6, 4, 3, 1, 7, 9, 8, 8, 8, 7, 24, "P'uyo Unup'a", Country.Dtersauuw_Sagua, false));
        teams[10].addPlayer(new player(2, 8, 7, 7, 8, 7, 6, 10, 7, 8, 1, 9, 25, "Eiqe Vokigei", Country.Auspikitan, false));

        teams[18].addPlayer(new player(1, 9, 8, 3, 3, 2, 8, 10, 6, 5, 5, 6, 27, "Bongatar Player #2", Country.Bongatar, false));
        teams[18].addPlayer(new player(2, 10, 3, 6, 6, 7, 9, 7, 9, 8, 10, 5, 25, "Kosiro Omundi", Country.Dotruga, false));
        teams[18].addPlayer(new player(3, 7, 5, 10, 6, 7, 6, 9, 5, 5, 5, 10, 27, "Boltway Player #2", Country.Ethanthova, false));
        teams[18].addPlayer(new player(4, 7, 2, 10, 10, 7, 5, 8, 2, 10, 5, 5, 27, "Boltway Player #3", Country.Ethanthova, false));
        teams[18].addPlayer(new player(5, 10, 3, 8, 8, 10, 6, 7, 4, 10, 5, 8, 27, "Paparto Subeina", Country.Dotruga, false));
        teams[18].addPlayer(new player(5, 7, 2, 4, 5, 9, 7, 9, 10, 4, 4, 6, 27, "Biplatza Gekxakŋi", Country.Auspikitan, false));
        teams[18].addPlayer(new player(3, 7, 8, 6, 6, 6, 7, 8, 4, 8, 5, 8, 25, "Alubembi Hadosa", Country.Dotruga, false));
        teams[18].addPlayer(new player(4, 9, 4, 10, 9, 4, 7, 5, 5, 7, 5, 7, 24, "Wongduan Saengsavang", Country.Lyintaria, false));
        teams[18].addPlayer(new player(2, 8, 9, 7, 7, 8, 7, 5, 7, 5, 6, 10, 25, "Ogino Tokaji", Country.Transhimalia, false));
        teams[18].addPlayer(new player(4, 6, 5, 9, 6, 7, 7, 5, 3, 10, 9, 10, 21, "Robert Kershaw", Country.Ethanthova, false));
        teams[18].addPlayer(new player(1, 10, 5, 3, 3, 4, 4, 7, 7, 7, 5, 6, 27, "Pxalit'k'a Player #3", Country.Dtersauuw_Sagua, false));
        teams[18].addPlayer(new player(3, 8, 5, 7, 5, 2, 5, 5, 7, 6, 5, 7, 23, "Konrad Waldstein", Country.Tri_National_Dominion, false));
        teams[18].addPlayer(new player(1, 7, 8, 2, 2, 3, 6, 8, 8, 4, 5, 5, 24, "Andries Martinez", Country.Wyverncliff, false));
        teams[18].addPlayer(new player(5, 4, 3, 9, 9, 8, 6, 7, 3, 10, 5, 5, 27, "vun", Country.Czalliso, false));
        teams[18].addPlayer(new player(2, 9, 6, 5, 4, 5, 4, 8, 9, 6, 10, 7, 21, "Jonathan Wagenseil", Country.Tri_National_Dominion, false));

        teams[24].addPlayer(new player(1, 10, 9, 4, 2, 4, 8, 9, 13, 8, 5, 6, 22, "Kalani Saysamongdy", Country.Lyintaria, false));
        teams[24].addPlayer(new player(2, 10, 5, 6, 6, 4, 10, 7, 8, 7, 5, 5, 27, "Dvinme Player #11", Country.Bielosia, false));
        teams[24].addPlayer(new player(3, 5, 10, 5, 5, 2, 7, 7, 6, 8, 5, 8, 27, "Small Forward #115", Country.Bongatar, false));
        teams[24].addPlayer(new player(4, 5, 3, 10, 10, 8, 7, 8, 3, 8, 5, 6, 22, "Miyoshi Masami", Country.Aeridani, false));
        teams[24].addPlayer(new player(5, 7, 3, 6, 4, 10, 9, 9, 7, 8, 5, 10, 24, "Fujikawa Masuhiro", Country.Transhimalia, false));
        teams[24].addPlayer(new player(4, 5, 1, 9, 9, 5, 8, 6, 2, 6, 5, 5, 25, "Blanox Farhje", Country.Blaist_Blaland, false));
        teams[24].addPlayer(new player(5, 4, 1, 8, 8, 8, 8, 5, 4, 3, 5, 10, 27, "Bongatar Player #1", Country.Bongatar, false));
        teams[24].addPlayer(new player(5, 7, 2, 9, 8, 10, 7, 7, 3, 9, 8, 10, 20, "Wongduan Sengtavisouk", Country.Lyintaria, false));
        teams[24].addPlayer(new player(3, 8, 10, 1, 1, 3, 10, 10, 7, 8, 5, 7, 24, "No Seung-Won", Country.Shmupland, false));
        teams[24].addPlayer(new player(1, 7, 7, 4, 2, 4, 5, 3, 10, 4, 4, 9, 21, "Leilani Somphonpadee", Country.Pyxanovia, false));
        teams[24].addPlayer(new player(2, 1, 8, 8, 8, 1, 8, 4, 4, 9, 5, 9, 27, "Fast Break", Country.Aeridani, false));
        teams[24].addPlayer(new player(3, 5, 3, 10, 10, 2, 9, 9, 8, 8, 6, 5, 23, "Kasai Isei", Country.Transhimalia, false));
        teams[24].addPlayer(new player(1, 8, 9, 1, 1, 2, 6, 10, 6, 5, 5, 9, 27, "Sagua Player #1", Country.Sagua, false));
        teams[24].addPlayer(new player(2, 8, 7, 3, 3, 2, 6, 4, 10, 7, 5, 9, 27, "kotheket tŋpel eqovkogh", Country.Solea, false));
        teams[24].addPlayer(new player(4, 4, 3, 7, 6, 6, 7, 7, 3, 10, 10, 7, 22, "Dugaro Gagodosa", Country.Dotruga, false));

        teams[2].addPlayer(new player(1, 10, 4, 6, 6, 8, 8, 10, 8, 7, 5, 8, 27, "vo", Country.Holykol, false));
        teams[2].addPlayer(new player(2, 12, 8, 10, 3, 5, 11, 11, 12, 12, 5, 9, 27, "Trevor Oosterhout", Country.Wyverncliff, false));
        teams[2].addPlayer(new player(3, 8, 3, 7, 7, 7, 10, 10, 9, 8, 5, 6, 26, "Asher Turner", Country.Wyverncliff, false));
        teams[2].addPlayer(new player(4, 6, 3, 10, 10, 6, 10, 7, 2, 9, 5, 5, 27, "Selby Schneiders", Country.Wyverncliff, false));
        teams[2].addPlayer(new player(5, 6, 2, 10, 10, 12, 9, 8, 1, 9, 5, 7, 27, "Its'a Lełqutyi", Country.Dtersauuw_Sagua, false));
        teams[2].addPlayer(new player(1, 7, 8, 4, 4, 6, 8, 7, 9, 6, 5, 7, 24, "Alukeili Asoertotrisei", Country.Dotruga, false));
        teams[2].addPlayer(new player(5, 7, 5, 8, 8, 10, 7, 7, 4, 8, 5, 8, 25, "Michael Barnett", Country.Ethanthova, false));
        teams[2].addPlayer(new player(2, 9, 9, 6, 5, 5, 6, 8, 8, 6, 6, 8, 24, "Analu Vatthana", Country.Bielosia, false));
        teams[2].addPlayer(new player(2, 10, 10, 4, 4, 5, 4, 3, 9, 6, 5, 6, 22, "Uozumi Izo", Country.Aeridani, false));
        teams[2].addPlayer(new player(3, 3, 8, 9, 9, 7, 8, 8, 7, 6, 5, 5, 25, "Dalton Ariesen", Country.Wyverncliff, false));
        teams[2].addPlayer(new player(3, 1, 9, 5, 5, 4, 4, 8, 9, 9, 5, 8, 27, "guz", Country.Czalliso, false));
        teams[2].addPlayer(new player(4, 4, 2, 7, 7, 5, 10, 8, 4, 7, 5, 6, 26, "Seong-Hyeon Moon", Country.Shmupland, false));
        teams[2].addPlayer(new player(4, 7, 3, 10, 10, 5, 7, 5, 1, 8, 5, 10, 25, "Yuguchi Sofu", Country.Aeridani, false));
        teams[2].addPlayer(new player(1, 10, 7, 3, 1, 4, 7, 6, 8, 7, 5, 5, 21, "Yoade Perch", Country.Wyverncliff, false));
        teams[2].addPlayer(new player(5, 5, 3, 9, 9, 7, 6, 8, 3, 6, 1, 8, 21, "Xaisomboun Saengsavang", Country.Lyintaria, false));
        teams[2].addPlayer(new player(5, 5, 3, 9, 9, 7, 6, 8, 3, 6, 1, 8, 33, "Old Player", Country.Lyintaria, false));

        teams[25].addPlayer(new player(1, 10, 6, 2, 2, 3, 10, 10, 9, 5, 5, 5, 25, "Sagolnasei Korsobo", Country.Dotruga, false));
        teams[25].addPlayer(new player(2, 4, 10, 5, 5, 5, 6, 10, 8, 6, 5, 5, 25, "Dylan Fowler", Country.Ethanthova, false));
        teams[25].addPlayer(new player(3, 4, 10, 7, 7, 10, 7, 7, 4, 10, 5, 9, 27, "war", Country.Czalliso, false));
        teams[25].addPlayer(new player(4, 10, 2, 8, 8, 6, 8, 8, 1, 8, 5, 8, 27, "mu", Country.Czalliso, false));
        teams[25].addPlayer(new player(5, 10, 1, 10, 10, 9, 8, 9, 3, 9, 5, 8, 23, "Naxto Lizaxium", Country.Blaist_Blaland, false));
        teams[25].addPlayer(new player(1, 8, 9, 3, 3, 3, 7, 10, 7, 5, 7, 8, 21, "kekh okepekít", Country.Solea, false));
        teams[25].addPlayer(new player(5, 7, 5, 5, 5, 8, 6, 6, 2, 5, 5, 7, 25, "Matsuyama Tadashi", Country.Aeridani, false));
        teams[25].addPlayer(new player(4, 5, 4, 6, 6, 6, 5, 7, 1, 8, 8, 10, 22, "Pau Finapeke", Country.Auspikitan, false));
        teams[25].addPlayer(new player(4, 7, 3, 9, 9, 6, 3, 5, 4, 7, 5, 5, 27, "hig", Country.Czalliso, false));
        teams[25].addPlayer(new player(2, 8, 4, 3, 3, 8, 10, 9, 9, 5, 5, 8, 27, "Hevek Gagomos", Country.Dotruga, false));
        teams[25].addPlayer(new player(2, 9, 7, 6, 7, 6, 9, 6, 8, 6, 1, 10, 24, "Iggy Greenfield", Country.Ethanthova, false));
        teams[25].addPlayer(new player(1, 7, 5, 5, 3, 4, 4, 9, 9, 4, 8, 9, 23, "Ha Chihu", Country.Shmupland, false));
        teams[25].addPlayer(new player(3, 6, 8, 7, 8, 7, 5, 10, 9, 6, 8, 8, 23, "Juri Perch", Country.Wyverncliff, false));
        teams[25].addPlayer(new player(5, 5, 2, 8, 8, 7, 6, 4, 3, 7, 1, 9, 20, "Nagasawa Okitsugu", Country.Aeridani, false));
        teams[25].addPlayer(new player(3, 4, 3, 9, 9, 1, 7, 5, 10, 2, 5, 8, 24, "Mónhin Nasa", Country.Sagua, false));

        teams[19].addPlayer(new player(1, 10, 9, 2, 2, 3, 9, 9, 8, 7, 5, 10, 24, "Maere Eirikursson", Country.Ethanthova, false));
        teams[19].addPlayer(new player(2, 10, 3, 8, 8, 6, 10, 10, 10, 9, 5, 10, 25, "Atumobei Tute", Country.Dotruga, false));
        teams[19].addPlayer(new player(3, 7, 9, 10, 10, 10, 10, 10, 8, 10, 5, 9, 20, "Atakri Kalauni", Country.Auspikitan, false));
        teams[19].addPlayer(new player(4, 9, 9, 8, 8, 10, 10, 8, 9, 10, 5, 8, 23, "Okaget Mabipet", Country.Dotruga, false));
        teams[19].addPlayer(new player(5, 7, 4, 10, 10, 10, 6, 9, 4, 10, 5, 8, 20, "Persa Mersa", Country.Key_to_Don, false));
        teams[19].addPlayer(new player(1, 10, 8, 5, 4, 2, 5, 4, 10, 5, 10, 6, 20, "Danotra Alodosumosodo", Country.Dotruga, false));
        teams[19].addPlayer(new player(5, 6, 2, 7, 7, 8, 9, 7, 4, 8, 5, 7, 24, "Lato Naixi", Country.Blaist_Blaland, false));
        teams[19].addPlayer(new player(2, 10, 8, 5, 4, 3, 5, 6, 8, 3, 2, 7, 21, "Keahi Bokeo", Country.Bielosia, false));
        teams[19].addPlayer(new player(2, 9, 10, 6, 4, 3, 8, 7, 8, 3, 1, 6, 20, "Melebin Kixidodotsei", Country.Dotruga, false));
        teams[19].addPlayer(new player(5, 8, 1, 6, 4, 9, 6, 8, 7, 4, 5, 7, 27, "Bá Qŕámanh", Country.Sagua, false));
        teams[19].addPlayer(new player(3, 6, 4, 5, 6, 6, 6, 8, 6, 8, 10, 9, 22, "Minamoto Takeji", Country.Aeridani, false));
        teams[19].addPlayer(new player(1, 8, 5, 5, 5, 3, 6, 4, 9, 8, 5, 6, 27, "Kudapa Kaxpa", Country.Blaist_Blaland, false));
        teams[19].addPlayer(new player(3, 4, 4, 10, 10, 5, 5, 6, 5, 8, 5, 5, 24, "Volker Kluck", Country.Tri_National_Dominion, false));
        teams[19].addPlayer(new player(4, 4, 1, 10, 10, 5, 8, 8, 2, 10, 5, 5, 27, "The Dimension Slaughterer", Country.Transhimalia, false));
        teams[19].addPlayer(new player(4, 7, 3, 6, 6, 7, 9, 8, 4, 6, 5, 6, 27, "Diji Makmero", Country.Barsein, false));

        teams[26].addPlayer(new player(1, 6, 7, 3, 3, 3, 8, 9, 12, 7, 5, 5, 25, "Seong-Su Gang", Country.Shmupland, false));
        teams[26].addPlayer(new player(2, 10, 7, 6, 6, 4, 10, 5, 10, 10, 5, 10, 27, "Mazló Plókli", Country.Height_Sagua, false));
        teams[26].addPlayer(new player(3, 9, 3, 10, 10, 10, 10, 10, 8, 12, 5, 7, 27, "Sago Alodetsei", Country.Dotruga, false));
        teams[26].addPlayer(new player(4, 6, 3, 8, 8, 6, 7, 10, 3, 10, 5, 5, 27, "kuŋevok eɰnak gevunáh", Country.Solea, false));
        teams[26].addPlayer(new player(5, 1, 7, 10, 10, 6, 8, 10, 3, 9, 5, 9, 26, "Wiley Ambrose", Country.Aahrus, false));
        teams[26].addPlayer(new player(1, 6, 8, 2, 2, 4, 7, 9, 6, 6, 5, 10, 27, "Argos Pebek", Country.Bielosia, false));
        teams[26].addPlayer(new player(5, 5, 3, 8, 8, 9, 5, 7, 4, 10, 5, 6, 25, "Benben", Country.Aiyota, false));
        teams[26].addPlayer(new player(2, 8, 7, 4, 4, 5, 8, 7, 8, 7, 5, 8, 27, "Detrio Marzovius", Country.Bielosia, false));
        teams[26].addPlayer(new player(4, 6, 3, 10, 10, 6, 7, 7, 1, 7, 5, 5, 27, "Markoli Strawlo", Country.Bielosia, false));
        teams[26].addPlayer(new player(3, 9, 7, 6, 5, 6, 10, 5, 10, 6, 2, 5, 23, "Till Klostermann", Country.Tri_National_Dominion, false));
        teams[26].addPlayer(new player(4, 10, 6, 8, 7, 4, 4, 7, 3, 5, 1, 9, 23, "Ienaga Tomoyuki", Country.Aeridani, false));
        teams[26].addPlayer(new player(2, 10, 7, 3, 2, 3, 6, 6, 8, 5, 5, 9, 21, "Midger", Country.Aiyota, false));
        teams[26].addPlayer(new player(3, 6, 10, 3, 3, 8, 5, 6, 5, 6, 5, 8, 27, "Litsaw Unup'a", Country.Dtersauuw_Sagua, false));
        teams[26].addPlayer(new player(5, 7, 2, 6, 6, 10, 4, 9, 7, 6, 6, 9, 24, "Ixbla Sovix", Country.Blaist_Blaland, false));
        teams[26].addPlayer(new player(1, 6, 10, 4, 2, 3, 4, 9, 8, 8, 9, 9, 21, "Shishido Goro", Country.Aeridani, false));

        teams[20].addPlayer(new player(1, 5, 9, 2, 2, 5, 10, 5, 10, 6, 5, 6, 27, "Ethanthova Player #4", Country.Ethanthova, false));
        teams[20].addPlayer(new player(2, 8, 4, 1, 1, 3, 10, 7, 10, 7, 5, 6, 27, "Ethanthova Player #3", Country.Ethanthova, false));
        teams[20].addPlayer(new player(3, 6, 4, 8, 8, 8, 10, 7, 8, 10, 5, 8, 27, "Ethanthova Player #5", Country.Ethanthova, false));
        teams[20].addPlayer(new player(4, 7, 4, 10, 10, 7, 8, 6, 4, 10, 5, 6, 27, "Fihana Jo", Country.Aeridani, false));
        teams[20].addPlayer(new player(5, 7, 3, 7, 7, 10, 9, 7, 5, 10, 5, 8, 25, "Errol James", Country.Ethanthova, false));
        teams[20].addPlayer(new player(5, 7, 2, 9, 9, 8, 4, 6, 4, 6, 5, 9, 27, "Ixbla Kibla", Country.Blaist_Blaland, false));
        teams[20].addPlayer(new player(4, 6, 2, 8, 8, 5, 4, 8, 1, 10, 5, 7, 27, "Holy Yektonesia Player #3", Country.Holy_Yektonisa, false));
        teams[20].addPlayer(new player(4, 5, 3, 9, 9, 5, 9, 5, 1, 8, 5, 8, 27, "Ethanthova Player #1", Country.Ethanthova, false));
        teams[20].addPlayer(new player(5, 5, 1, 9, 9, 6, 4, 7, 3, 6, 5, 10, 27, "Ethanthova Player #2", Country.Ethanthova, false));
        teams[20].addPlayer(new player(1, 9, 9, 3, 3, 3, 6, 5, 9, 3, 5, 6, 23, "Mungymia", Country.Aiyota, false));
        teams[20].addPlayer(new player(2, 9, 6, 6, 6, 2, 6, 2, 7, 4, 5, 5, 27, "Ethanthova Player #7", Country.Ethanthova, false));
        teams[20].addPlayer(new player(3, 5, 3, 9, 9, 1, 7, 5, 10, 2, 5, 9, 27, "Ethanthova Player #8", Country.Ethanthova, false));
        teams[20].addPlayer(new player(2, 9, 10, 7, 7, 4, 8, 8, 8, 6, 4, 9, 21, "Asser Steinbauer", Country.Tri_National_Dominion, false));
        teams[20].addPlayer(new player(3, 6, 5, 9, 9, 3, 6, 10, 9, 5, 4, 8, 27, "lu", Country.Czalliso, false));
        teams[20].addPlayer(new player(1, 6, 9, 5, 1, 4, 4, 9, 7, 5, 1, 8, 23, "Analu Rattanavongsa", Country.Bielosia, false));

        teams[21].addPlayer(new player(1, 10, 7, 2, 2, 5, 8, 8, 7, 8, 5, 5, 27, "Savage Soleani", Country.Aeridani, false));
        teams[21].addPlayer(new player(2, 9, 2, 6, 6, 6, 8, 7, 7, 7, 5, 5, 27, "Tha Tricka", Country.Aeridani, false));
        teams[21].addPlayer(new player(3, 4, 7, 10, 10, 6, 8, 7, 5, 8, 5, 7, 22, "Aseqa Poi", Country.Auspikitan, false));
        teams[21].addPlayer(new player(4, 8, 3, 8, 8, 10, 9, 8, 4, 9, 5, 9, 24, "Kamil Jones", Country.Ethanthova, false));
        teams[21].addPlayer(new player(5, 7, 2, 10, 15, 11, 7, 7, 3, 10, 5, 5, 27, "Three Point Masta", Country.Aeridani, false));
        teams[21].addPlayer(new player(5, 6, 1, 6, 6, 9, 5, 6, 2, 2, 5, 8, 25, "Adam Lettmann", Country.Tri_National_Dominion, false));
        teams[21].addPlayer(new player(4, 4, 3, 9, 7, 8, 4, 8, 3, 6, 5, 10, 23, "Naxto Zaxnax", Country.Blaist_Blaland, false));
        teams[21].addPlayer(new player(1, 8, 10, 2, 3, 4, 6, 4, 9, 8, 3, 5, 24, "Grant Miller", Country.Ethanthova, false));
        teams[21].addPlayer(new player(3, 10, 4, 10, 10, 8, 8, 9, 1, 10, 5, 7, 27, "Blanaxon Player #5", Country.Blaist_Blaland, false));
        teams[21].addPlayer(new player(1, 7, 7, 3, 2, 2, 6, 10, 10, 7, 1, 8, 20, "Mónhin Mipjódló", Country.Key_to_Don, false));
        teams[21].addPlayer(new player(5, 7, 1, 6, 3, 10, 8, 5, 7, 5, 10, 7, 23, "Błá Kánpovŕagá", Country.Key_to_Don, false));
        teams[21].addPlayer(new player(2, 10, 9, 3, 3, 5, 6, 8, 7, 5, 5, 10, 21, "Tagawa Kazuko", Country.Aeridani, false));
        teams[21].addPlayer(new player(3, 7, 9, 6, 6, 6, 7, 9, 1, 6, 5, 5, 27, "Papa Ogre", Country.Aeridani, false));
        teams[21].addPlayer(new player(4, 9, 7, 9, 9, 5, 7, 4, 3, 8, 9, 9, 23, "Alundi Elodosatrisei", Country.Dotruga, false));
        teams[21].addPlayer(new player(2, 8, 7, 3, 3, 3, 6, 4, 8, 4, 5, 9, 24, "Okasei Bexemetadotsei", Country.Dotruga, false));

        teams[3].addPlayer(new player(1, 10, 7, 6, 6, 3, 7, 7, 6, 7, 5, 8, 27, "Red Rainbow Player #3", Country.Red_Rainbow, false));
        teams[3].addPlayer(new player(2, 7, 10, 6, 6, 6, 6, 8, 10, 6, 5, 6, 27, "Hvanne Takakazu", Country.Aeridani, false));
        teams[3].addPlayer(new player(3, 8, 10, 7, 7, 6, 5, 6, 8, 9, 5, 8, 27, "Height Sagua Player #3", Country.Height_Sagua, false));
        teams[3].addPlayer(new player(4, 10, 3, 9, 9, 7, 6, 8, 4, 8, 5, 10, 25, "Sova Kłó", Country.Height_Sagua, false));
        teams[3].addPlayer(new player(5, 5, 10, 7, 7, 10, 7, 6, 6, 7, 5, 8, 26, "Laurence Chandler", Country.Ethanthova, false));
        teams[3].addPlayer(new player(5, 5, 8, 6, 7, 9, 10, 9, 3, 8, 2, 7, 22, "No Kwang-Jo", Country.Shmupland, false));
        teams[3].addPlayer(new player(2, 9, 8, 3, 4, 3, 5, 4, 9, 3, 10, 9, 22, "Autanblanaix Sovkol", Country.Blaist_Blaland, false));
        teams[3].addPlayer(new player(1, 6, 10, 4, 3, 4, 6, 10, 7, 4, 5, 9, 23, "Naxnoxsoya Liksov", Country.Blaist_Blaland, false));
        teams[3].addPlayer(new player(4, 7, 3, 9, 9, 6, 7, 8, 3, 8, 5, 8, 27, "Tri_National_Dominion Player #2", Country.Tri_National_Dominion, false));
        teams[3].addPlayer(new player(4, 1, 3, 8, 8, 7, 5, 8, 1, 6, 5, 10, 27, "Height Sagua Player #4", Country.Height_Sagua, false));
        teams[3].addPlayer(new player(3, 4, 5, 10, 9, 5, 10, 9, 10, 4, 9, 8, 25, "Atumundikeili Halapodetsei", Country.Dotruga, false));
        teams[3].addPlayer(new player(1, 5, 7, 5, 5, 2, 4, 7, 10, 4, 5, 9, 24, "Saiki Shunmyo", Country.Aeridani, false));
        teams[3].addPlayer(new player(5, 6, 1, 6, 7, 8, 9, 6, 9, 6, 4, 6, 22, "Xavier Wilcox", Country.Wyverncliff, false));
        teams[3].addPlayer(new player(2, 8, 6, 6, 6, 3, 9, 3, 9, 6, 5, 5, 25, "Jumpe", Country.Aiyota, false));
        teams[3].addPlayer(new player(3, 7, 7, 8, 8, 7, 2, 5, 4, 4, 5, 8, 27, "Small Forward #152", Country.Height_Sagua, false));

        teams[27].addPlayer(new player(1, 6, 10, 1, 1, 3, 9, 10, 9, 8, 5, 5, 25, "Shitt Hessar", Country.Bongatar, false));
        teams[27].addPlayer(new player(2, 9, 6, 4, 4, 3, 8, 7, 7, 7, 5, 8, 24, "Eban Korsobo", Country.Dotruga, false));
        teams[27].addPlayer(new player(3, 3, 7, 5, 5, 5, 10, 8, 5, 7, 5, 9, 27, "apseŋ kép tónaqig", Country.Solea, false));
        teams[27].addPlayer(new player(4, 7, 4, 7, 7, 8, 9, 8, 3, 8, 5, 7, 25, "Omumiba Ektxr", Country.Dotruga, false));
        teams[27].addPlayer(new player(5, 5, 4, 10, 10, 12, 8, 8, 2, 10, 5, 7, 24, "Hivek Ekxtr", Country.Dotruga, false));
        teams[27].addPlayer(new player(3, 9, 8, 5, 5, 10, 6, 7, 3, 2, 5, 10, 25, "Ailiqaeu Okohae", Country.Holy_Yektonisa, false));
        teams[27].addPlayer(new player(2, 8, 7, 6, 6, 2, 6, 6, 9, 7, 5, 10, 21, "Kolpa Uxyakro", Country.Blaist_Blaland, false));
        teams[27].addPlayer(new player(5, 5, 1, 9, 9, 4, 9, 6, 4, 9, 5, 10, 27, "Dano Subeina", Country.Dotruga, false));
        teams[27].addPlayer(new player(1, 9, 7, 3, 3, 5, 9, 6, 8, 3, 5, 8, 27, "Holy Yektonesia Player #1", Country.Holy_Yektonisa, false));
        teams[27].addPlayer(new player(3, 5, 1, 4, 4, 9, 9, 8, 10, 3, 5, 5, 22, "Ji Gim", Country.Shmupland, false));
        teams[27].addPlayer(new player(4, 8, 9, 7, 7, 9, 7, 9, 9, 7, 7, 9, 25, "Keahi Savang", Country.Bielosia, false));
        teams[27].addPlayer(new player(4, 4, 3, 10, 10, 5, 7, 6, 1, 7, 5, 5, 27, "Holy Yektonesia Player #6", Country.Holy_Yektonisa, false));
        teams[27].addPlayer(new player(2, 7, 9, 3, 1, 3, 7, 7, 9, 7, 1, 5, 22, "pot", Country.Czalliso, false));
        teams[27].addPlayer(new player(5, 7, 3, 5, 4, 9, 5, 10, 9, 5, 5, 10, 24, "Melebin Himei", Country.Dotruga, false));
        teams[27].addPlayer(new player(1, 9, 6, 5, 3, 3, 6, 6, 8, 8, 10, 7, 22, "Atumiba Bexomos", Country.Dotruga, false));

        teams[28].addPlayer(new player(1, 10, 8, 1, 1, 4, 9, 4, 9, 10, 5, 8, 24, "Ikaika Savang", Country.Loviniosa, false));
        teams[28].addPlayer(new player(2, 8, 9, 4, 4, 4, 6, 7, 9, 10, 5, 10, 25, "Konala Somphousiharath", Country.Loviniosa, false));
        teams[28].addPlayer(new player(3, 4, 10, 5, 5, 7, 6, 5, 8, 8, 5, 9, 23, "Jesse Svensson", Country.Wyverncliff, false));
        teams[28].addPlayer(new player(4, 7, 1, 10, 8, 7, 10, 8, 4, 6, 5, 6, 27, "Sagua Player #2", Country.Sagua, false));
        teams[28].addPlayer(new player(5, 10, 3, 10, 10, 12, 10, 10, 4, 10, 5, 10, 25, "Red Rainbow Player #2", Country.Red_Rainbow, false));
        teams[28].addPlayer(new player(4, 4, 2, 9, 9, 7, 7, 6, 4, 8, 5, 6, 24, "Alwin Gradl", Country.Tri_National_Dominion, false));
        teams[28].addPlayer(new player(2, 9, 10, 6, 5, 5, 8, 9, 6, 8, 1, 9, 26, "Akamu Phomsouvanh", Country.Bielosia, false));
        teams[28].addPlayer(new player(3, 2, 7, 10, 10, 3, 9, 5, 1, 8, 5, 7, 27, "hax", Country.Holykol, false));
        teams[28].addPlayer(new player(1, 10, 8, 3, 4, 4, 10, 9, 9, 5, 2, 8, 24, "Nobira Taki", Country.Barsein, false));
        teams[28].addPlayer(new player(1, 9, 7, 3, 1, 4, 7, 8, 10, 6, 10, 10, 20, "Koa Savang", Country.Pyxanovia, false));
        teams[28].addPlayer(new player(4, 3, 4, 7, 9, 7, 6, 8, 1, 10, 2, 7, 22, "Rusty Berry", Country.Ethanthova, false));
        teams[28].addPlayer(new player(5, 6, 2, 10, 10, 7, 7, 1, 4, 4, 5, 5, 27, "quj", Country.Holykol, false));
        teams[28].addPlayer(new player(5, 5, 4, 6, 6, 8, 5, 6, 2, 8, 6, 8, 20, "Travis Traenfeglia", Country.Wyverncliff, false));
        teams[28].addPlayer(new player(3, 6, 8, 7, 7, 2, 9, 4, 6, 6, 5, 10, 22, "Tsekon Wap't'ebw", Country.Dtersauuw_Sagua, false));
        teams[28].addPlayer(new player(2, 7, 8, 3, 4, 5, 4, 8, 9, 5, 6, 5, 21, "Lilo Thepsenavong", Country.Bielosia, false));

        teams[11].addPlayer(new player(1, 9, 10, 3, 2, 5, 6, 9, 10, 5, 6, 9, 22, "Lilo Vatthana", Country.Bielosia, false));
        teams[11].addPlayer(new player(2, 10, 6, 6, 6, 3, 10, 5, 7, 7, 5, 7, 27, "Pxalit'k'a Player #6", Country.Dtersauuw_Sagua, false));
        teams[11].addPlayer(new player(3, 1, 5, 8, 4, 10, 8, 6, 9, 9, 5, 10, 27, "Key To Don Player #4", Country.Key_to_Don, false));
        teams[11].addPlayer(new player(4, 5, 4, 8, 8, 6, 7, 9, 2, 10, 5, 8, 24, "Akamine Naizen", Country.Barsein, false));
        teams[11].addPlayer(new player(5, 6, 4, 7, 6, 9, 8, 7, 5, 8, 9, 7, 21, "Carlos Harris", Country.Ethanthova, false));
        teams[11].addPlayer(new player(5, 5, 4, 8, 8, 7, 4, 4, 3, 7, 5, 8, 27, "Pxalit'k'a Player #2", Country.Dtersauuw_Sagua, false));
        teams[11].addPlayer(new player(1, 10, 9, 2, 2, 3, 6, 5, 8, 7, 5, 10, 27, "Boltway Player #1", Country.Ethanthova, false));
        teams[11].addPlayer(new player(4, 8, 3, 10, 10, 5, 6, 5, 3, 10, 5, 5, 23, "Xavier McSteve", Country.Wyverncliff, false));
        teams[11].addPlayer(new player(3, 1, 1, 9, 6, 8, 4, 8, 9, 10, 10, 6, 23, "Sol Song-Jin", Country.Shmupland, false));
        teams[11].addPlayer(new player(5, 5, 1, 9, 9, 8, 8, 6, 2, 6, 5, 5, 27, "Pxalit'k'a Player #7", Country.Dtersauuw_Sagua, false));
        teams[11].addPlayer(new player(2, 7, 8, 4, 4, 8, 9, 9, 8, 6, 3, 10, 23, "Kaili Saenthavisouk", Country.Lyintaria, false));
        teams[11].addPlayer(new player(1, 7, 8, 1, 1, 2, 9, 9, 8, 7, 5, 5, 27, "Osiei Bituna", Country.Dotruga, false));
        teams[11].addPlayer(new player(4, 9, 3, 7, 7, 1, 5, 7, 5, 8, 6, 10, 24, "Tanifuji Shirosama", Country.Aeridani, false));
        teams[11].addPlayer(new player(3, 9, 10, 5, 5, 5, 8, 5, 6, 5, 2, 10, 24, "Atomobei Kerxer", Country.Dotruga, false));
        teams[11].addPlayer(new player(2, 8, 5, 4, 4, 5, 5, 7, 8, 10, 5, 10, 24, "Uxnax Prokexov", Country.Blaist_Blaland, false));

        teams[4].addPlayer(new player(1, 10, 9, 6, 6, 5, 6, 5, 10, 6, 5, 8, 26, "Gerard Holzer", Country.Tri_National_Dominion, false));
        teams[4].addPlayer(new player(2, 9, 8, 5, 5, 4, 5, 6, 7, 7, 5, 9, 23, "Kapel Hilo", Country.Dotruga, false));
        teams[4].addPlayer(new player(3, 13, 6, 13, 5, 10, 9, 10, 8, 12, 5, 10, 24, "Litsaw Wap't'ebw", Country.Dtersauuw_Sagua, false));
        teams[4].addPlayer(new player(4, 6, 1, 9, 9, 7, 10, 4, 2, 10, 5, 6, 27, "la", Country.Holykol, false));
        teams[4].addPlayer(new player(5, 6, 2, 5, 5, 10, 7, 7, 4, 6, 1, 7, 22, "Kaliso Hatemosei", Country.Dotruga, false));
        teams[4].addPlayer(new player(3, 7, 4, 7, 7, 1, 8, 6, 4, 4, 5, 8, 22, "Blalikki Tanpratia", Country.Blaist_Blaland, false));
        teams[4].addPlayer(new player(1, 10, 8, 3, 3, 5, 7, 1, 7, 7, 5, 8, 27, "Key To Don Player #2", Country.Key_to_Don, false));
        teams[4].addPlayer(new player(1, 6, 7, 4, 4, 3, 10, 8, 5, 1, 5, 7, 25, "Grant Pool", Country.Ethanthova, false));
        teams[4].addPlayer(new player(4, 5, 3, 9, 8, 7, 7, 6, 1, 6, 7, 6, 20, "Alomibamobei Olalomundi", Country.Dotruga, false));
        teams[4].addPlayer(new player(2, 4, 10, 6, 6, 4, 3, 5, 9, 5, 5, 10, 27, "Key To Don Player #5", Country.Key_to_Don, false));
        teams[4].addPlayer(new player(4, 9, 2, 10, 10, 5, 6, 7, 3, 7, 5, 7, 21, "Stephan Hutto", Country.Tri_National_Dominion, false));
        teams[4].addPlayer(new player(5, 6, 6, 8, 9, 6, 10, 6, 2, 6, 2, 10, 26, "Cabodu Sokàtà", Country.Darvincia, false));
        teams[4].addPlayer(new player(3, 6, 7, 6, 6, 7, 4, 7, 4, 2, 5, 8, 27, "Key To Don Player #8", Country.Key_to_Don, false));
        teams[4].addPlayer(new player(5, 6, 5, 6, 6, 9, 6, 4, 4, 4, 2, 8, 20, "Guvggillmào Nùx́iś", Country.Barsein, false));
        teams[4].addPlayer(new player(2, 8, 8, 4, 4, 3, 6, 3, 8, 7, 5, 7, 25, "Aseqa Tituqu", Country.Auspikitan, false));

        teams[29].addPlayer(new player(1, 10, 7, 1, 1, 2, 10, 10, 10, 6, 5, 5, 27, "Lyintaria Player #4", Country.Lyintaria, false));
        teams[29].addPlayer(new player(2, 10, 6, 9, 7, 3, 5, 8, 10, 6, 10, 7, 21, "Éxànnecig Hàŕselàn", Country.Barsein, false));
        teams[29].addPlayer(new player(3, 8, 9, 7, 10, 9, 4, 10, 7, 10, 7, 10, 20, "Bingarra", Country.Aiyota, false));
        teams[29].addPlayer(new player(4, 9, 4, 10, 10, 8, 9, 8, 3, 6, 5, 7, 20, "Waltoko", Country.Aiyota, false));
        teams[29].addPlayer(new player(5, 3, 3, 10, 10, 10, 8, 5, 1, 10, 5, 5, 23, "Phetdum Vongsay", Country.Loviniosa, false));
        teams[29].addPlayer(new player(3, 10, 8, 9, 9, 10, 8, 7, 2, 10, 5, 5, 27, "Uelv Lganne", Country.Barsein, false));
        teams[29].addPlayer(new player(1, 10, 10, 4, 3, 4, 8, 9, 10, 6, 1, 5, 24, "Uemura Tadashi", Country.Aeridani, false));
        teams[29].addPlayer(new player(5, 7, 3, 7, 7, 10, 4, 8, 1, 2, 5, 5, 27, "Lyintaria Player #11", Country.Lyintaria, false));
        teams[29].addPlayer(new player(5, 6, 6, 7, 9, 9, 7, 3, 1, 4, 1, 9, 20, "Meka Bokeo", Country.Pyxanovia, false));
        teams[29].addPlayer(new player(2, 8, 7, 2, 2, 4, 7, 7, 8, 3, 5, 10, 27, "Lyintaria Player #2", Country.Lyintaria, false));
        teams[29].addPlayer(new player(4, 7, 1, 8, 8, 7, 7, 8, 1, 3, 5, 5, 27, "Lyintaria Player #3", Country.Lyintaria, false));
        teams[29].addPlayer(new player(1, 10, 10, 3, 3, 1, 7, 10, 9, 7, 3, 7, 26, "Alubembi Xahelvi", Country.Dotruga, false));
        teams[29].addPlayer(new player(4, 7, 1, 10, 10, 6, 3, 3, 3, 9, 5, 9, 27, "Tekle Doko", Country.Auspikitan, false));
        teams[29].addPlayer(new player(3, 4, 2, 5, 5, 7, 9, 8, 7, 4, 10, 9, 24, "Váqáp Vjamhá", Country.Height_Sagua, false));
        teams[29].addPlayer(new player(2, 6, 8, 5, 4, 4, 4, 5, 9, 8, 10, 5, 23, "Bernard Wade", Country.Ethanthova, false));

        teams[5].addPlayer(new player(1, 10, 8, 1, 1, 4, 7, 10, 10, 7, 5, 10, 26, "Himi Azumamaro", Country.Aeridani, false));
        teams[5].addPlayer(new player(2, 8, 9, 6, 6, 5, 8, 7, 10, 7, 5, 10, 24, "Eipe Hawo", Country.Oesa, false));
        teams[5].addPlayer(new player(3, 8, 10, 7, 7, 5, 6, 7, 8, 9, 5, 8, 25, "Rusty Harries", Country.Ethanthova, false));
        teams[5].addPlayer(new player(4, 9, 5, 10, 10, 7, 8, 8, 6, 7, 5, 8, 21, "Kiyoto Mansumo", Country.Lyintaria, false));
        teams[5].addPlayer(new player(5, 7, 5, 6, 10, 10, 8, 7, 4, 7, 5, 6, 23, "Xolin Hialerko", Country.Dotruga, false));
        teams[5].addPlayer(new player(3, 9, 9, 3, 3, 10, 7, 5, 2, 2, 5, 8, 27, "Charlie", Country.Darvincia, false));
        teams[5].addPlayer(new player(5, 4, 2, 10, 9, 9, 5, 8, 4, 7, 7, 9, 23, "Blalikki Kiixrit", Country.Blaist_Blaland, false));
        teams[5].addPlayer(new player(1, 6, 8, 3, 3, 5, 5, 10, 7, 5, 5, 5, 27, "Fox", Country.Darvincia, false));
        teams[5].addPlayer(new player(1, 8, 10, 3, 4, 3, 10, 4, 7, 8, 10, 6, 24, "Masaki Kazuko", Country.Aeridani, false));
        teams[5].addPlayer(new player(2, 8, 10, 7, 8, 8, 7, 6, 8, 9, 6, 8, 25, "Sol Jae-Wook", Country.Shmupland, false));
        teams[5].addPlayer(new player(5, 5, 3, 7, 7, 7, 7, 5, 4, 10, 5, 5, 27, "Item", Country.Darvincia, false));
        teams[5].addPlayer(new player(4, 4, 6, 6, 10, 5, 7, 7, 4, 9, 10, 10, 23, "Ok Yeong-Jin", Country.Shmupland, false));
        teams[5].addPlayer(new player(2, 10, 1, 1, 1, 3, 7, 8, 9, 10, 5, 7, 23, "Kiromi Kersidomobek", Country.Dotruga, false));
        teams[5].addPlayer(new player(4, 7, 3, 10, 10, 7, 7, 5, 3, 5, 5, 5, 22, "Sitwa Luvepiri", Country.Oesa, false));
        teams[5].addPlayer(new player(3, 4, 5, 8, 8, 7, 6, 5, 4, 6, 5, 6, 25, "Pezi Vuki", Country.Auspikitan, false));

        teams[12].addPlayer(new player(1, 5, 10, 2, 2, 4, 9, 8, 10, 7, 5, 6, 27, "Height Sagua Player #5", Country.Height_Sagua, false));
        teams[12].addPlayer(new player(2, 6, 4, 6, 7, 8, 7, 10, 7, 6, 10, 7, 22, "Eto Shunmyo", Country.Barsein, false));
        teams[12].addPlayer(new player(3, 7, 4, 3, 4, 6, 10, 9, 6, 9, 8, 8, 20, "Maik Phothisarath", Country.Bielosia, false));
        teams[12].addPlayer(new player(4, 8, 3, 9, 9, 8, 8, 7, 1, 8, 5, 6, 26, "Tixen Prokol", Country.Blaist_Blaland, false));
        teams[12].addPlayer(new player(5, 7, 3, 9, 12, 10, 6, 5, 3, 10, 5, 5, 24, "Alomundi Gagolomundi", Country.Dotruga, false));
        teams[12].addPlayer(new player(1, 6, 9, 2, 2, 5, 7, 6, 8, 4, 5, 7, 24, "Kersuvi Himei", Country.Dotruga, false));
        teams[12].addPlayer(new player(3, 5, 3, 7, 7, 6, 7, 7, 5, 9, 5, 8, 27, "Small Forward #143", Country.Blaist_Blaland, false));
        teams[12].addPlayer(new player(4, 6, 2, 8, 8, 6, 5, 8, 1, 1, 5, 5, 24, "Darkon Piklo", Country.Blaist_Blaland, false));
        teams[12].addPlayer(new player(5, 5, 6, 8, 8, 10, 7, 7, 6, 10, 5, 6, 27, "b 9u", Country.Aeridani, false));
        teams[12].addPlayer(new player(1, 10, 7, 2, 2, 6, 5, 6, 6, 5, 5, 5, 24, "Malo Sengtavisouk", Country.Loviniosa, false));
        teams[12].addPlayer(new player(5, 3, 3, 9, 9, 5, 8, 6, 2, 7, 5, 5, 25, "Lizaxon Rova", Country.Blaist_Blaland, false));
        teams[12].addPlayer(new player(2, 9, 9, 4, 5, 7, 7, 4, 6, 6, 8, 7, 23, "Moke Savang", Country.Pyxanovia, false));
        teams[12].addPlayer(new player(2, 7, 7, 4, 4, 4, 6, 5, 7, 5, 5, 6, 27, "Power Forward #164", Country.Blaist_Blaland, false));
        teams[12].addPlayer(new player(3, 6, 8, 6, 7, 2, 7, 6, 5, 8, 3, 7, 20, "Mhokba Djamhámhoñha", Country.Nausicaa, false));
        teams[12].addPlayer(new player(4, 5, 2, 9, 9, 5, 8, 7, 2, 9, 5, 5, 27, "Zhali Mpetaec", Country.Pyxanovia, false));

        teams[30].addPlayer(new player(1, 10, 7, 4, 4, 1, 6, 8, 8, 5, 5, 6, 27, "Pyxanovia Player #1", Country.Pyxanovia, false));
        teams[30].addPlayer(new player(2, 9, 6, 4, 4, 5, 5, 10, 9, 6, 5, 5, 27, "tag", Country.Czalliso, false));
        teams[30].addPlayer(new player(3, 2, 8, 10, 10, 7, 10, 10, 10, 10, 5, 8, 27, "Pyxanovia Player #4", Country.Pyxanovia, false));
        teams[30].addPlayer(new player(4, 7, 2, 10, 10, 9, 8, 9, 3, 10, 5, 8, 22, "Handa Senichi", Country.Aeridani, false));
        teams[30].addPlayer(new player(5, 5, 2, 10, 10, 10, 8, 7, 4, 6, 5, 6, 27, "Pyxanovia Player #2", Country.Pyxanovia, false));
        teams[30].addPlayer(new player(4, 7, 1, 10, 10, 5, 6, 7, 3, 2, 5, 10, 27, "Autolik Player #2", Country.Blaist_Blaland, false));
        teams[30].addPlayer(new player(2, 7, 8, 4, 2, 5, 8, 8, 9, 6, 8, 9, 23, "Reinhard Waldstein", Country.Tri_National_Dominion, false));
        teams[30].addPlayer(new player(2, 5, 10, 3, 3, 4, 4, 8, 7, 5, 5, 8, 22, "Niclas Umlauf", Country.Tri_National_Dominion, false));
        teams[30].addPlayer(new player(5, 4, 5, 8, 8, 10, 5, 5, 5, 7, 5, 5, 25, "Ixux Naixi", Country.Blaist_Blaland, false));
        teams[30].addPlayer(new player(3, 5, 5, 6, 6, 8, 7, 1, 2, 8, 5, 6, 24, "Nathaniel Starks", Country.Wyverncliff, false));
        teams[30].addPlayer(new player(4, 10, 3, 6, 6, 5, 8, 9, 5, 6, 5, 8, 27, "Shooting Guard #169", Country.Aiyota, false));
        teams[30].addPlayer(new player(3, 10, 4, 1, 2, 6, 7, 6, 8, 8, 7, 9, 20, "Mom Slivókŕámhomhók", Country.Sagua, false));
        teams[30].addPlayer(new player(1, 8, 6, 3, 4, 4, 5, 8, 8, 8, 10, 8, 25, "Marcel Weidenmann", Country.Tri_National_Dominion, false));
        teams[30].addPlayer(new player(1, 10, 10, 2, 1, 5, 7, 10, 9, 8, 7, 10, 23, "Analu Cheruene", Country.Lyintaria, false));
        teams[30].addPlayer(new player(5, 7, 3, 5, 5, 7, 7, 5, 9, 5, 5, 10, 22, "William James", Country.Ethanthova, false));

        teams[13].addPlayer(new player(1, 9, 8, 4, 4, 6, 10, 7, 12, 7, 10, 5, 23, "Caleb Jervis", Country.Ethanthova, false));
        teams[13].addPlayer(new player(2, 9, 10, 7, 5, 5, 8, 6, 7, 6, 7, 10, 20, "Cabodu Kanix", Country.Darvincia, false));
        teams[13].addPlayer(new player(3, 6, 10, 9, 9, 7, 7, 5, 10, 7, 10, 10, 27, "Red Rainbow Player #1", Country.Red_Rainbow, false));
        teams[13].addPlayer(new player(4, 8, 2, 9, 9, 8, 10, 9, 1, 9, 5, 10, 24, "Vanhik Slivókŕámhomhók", Country.Height_Sagua, false));
        teams[13].addPlayer(new player(5, 5, 5, 10, 8, 8, 5, 8, 1, 10, 5, 6, 22, "Dano Mesiaertoxek", Country.Dotruga, false));
        teams[13].addPlayer(new player(5, 3, 3, 10, 10, 7, 4, 3, 1, 5, 5, 9, 25, "Atotra Danomane", Country.Dotruga, false));
        teams[13].addPlayer(new player(4, 2, 4, 10, 10, 4, 5, 7, 4, 6, 5, 10, 27, "Sagua Player #3", Country.Sagua, false));
        teams[13].addPlayer(new player(5, 8, 3, 5, 7, 9, 6, 7, 8, 6, 2, 5, 23, "William Spicer", Country.Ethanthova, false));
        teams[13].addPlayer(new player(2, 8, 8, 5, 4, 4, 9, 4, 7, 5, 6, 10, 24, "Ydar Iode", Country.Bongatar, false));
        teams[13].addPlayer(new player(3, 6, 5, 9, 10, 2, 6, 7, 10, 7, 3, 5, 21, "Murata Sofu", Country.Aeridani, false));
        teams[13].addPlayer(new player(2, 7, 4, 6, 6, 1, 8, 6, 6, 5, 5, 9, 27, "Red Rainbow Player #4", Country.Red_Rainbow, false));
        teams[13].addPlayer(new player(4, 6, 2, 8, 8, 7, 2, 2, 4, 7, 5, 8, 27, "Red Rainbow Player #6", Country.Red_Rainbow, false));
        teams[13].addPlayer(new player(1, 7, 7, 3, 3, 5, 7, 4, 8, 2, 5, 5, 27, "Red Rainbow Player #7", Country.Red_Rainbow, false));
        teams[13].addPlayer(new player(3, 8, 7, 8, 10, 1, 7, 10, 3, 4, 10, 10, 26, "Sovtanzax Uxyakro", Country.Blaist_Blaland, false));
        teams[13].addPlayer(new player(1, 8, 8, 3, 1, 4, 4, 6, 7, 5, 2, 9, 20, "Métro Sanraku", Country.Aeridani, false));

        teams[6].addPlayer(new player(1, 9, 4, 3, 3, 1, 10, 10, 13, 7, 5, 8, 26, "Colin Hutchison", Country.Ethanthova, false));
        teams[6].addPlayer(new player(2, 10, 9, 3, 3, 4, 6, 4, 10, 4, 5, 10, 24, "Mawatari Kane", Country.Transhimalia, false));
        teams[6].addPlayer(new player(3, 8, 8, 9, 3, 6, 6, 9, 9, 10, 5, 5, 27, "Mavótáfika Vilikó", Country.Sagua, false));
        teams[6].addPlayer(new player(4, 7, 6, 9, 8, 6, 6, 7, 2, 6, 2, 6, 27, "Hvanne Aeridaniok", Country.Aeridani, false));
        teams[6].addPlayer(new player(5, 8, 3, 6, 3, 10, 6, 4, 8, 7, 2, 9, 24, "Zac Lolant", Country.Wyverncliff, false));
        teams[6].addPlayer(new player(2, 8, 10, 7, 6, 5, 7, 5, 7, 5, 5, 8, 25, "Hevek Himadolsei", Country.Dotruga, false));
        teams[6].addPlayer(new player(1, 6, 6, 3, 3, 4, 5, 9, 9, 5, 5, 5, 27, "Biplatza Ifet", Country.Auspikitan, false));
        teams[6].addPlayer(new player(4, 9, 7, 10, 10, 6, 6, 6, 4, 6, 6, 10, 23, "Paxathipatai Sengtavisouk", Country.Bielosia, false));
        teams[6].addPlayer(new player(3, 9, 3, 10, 10, 10, 1, 5, 4, 6, 5, 7, 25, "Neville Spicer", Country.Ethanthova, false));
        teams[6].addPlayer(new player(5, 4, 4, 5, 5, 10, 7, 8, 5, 4, 5, 6, 27, "Danomobei Subeina", Country.Dotruga, false));
        teams[6].addPlayer(new player(4, 4, 1, 10, 10, 7, 8, 7, 3, 8, 5, 5, 24, "Pwa Lefinu", Country.Oesa, false));
        teams[6].addPlayer(new player(3, 5, 2, 10, 7, 5, 7, 8, 2, 8, 5, 9, 21, "Alomibamobei Osadolsei", Country.Dotruga, false));
        teams[6].addPlayer(new player(2, 8, 7, 4, 4, 3, 5, 8, 10, 7, 5, 5, 23, "The Moo Saχi", Country.Darvincia, false));
        teams[6].addPlayer(new player(1, 9, 10, 2, 3, 2, 4, 6, 9, 6, 6, 6, 20, "Keahi Cheruene", Country.Pyxanovia, false));
        teams[6].addPlayer(new player(5, 2, 3, 8, 8, 7, 7, 7, 4, 8, 5, 8, 27, "hex", Country.Holykol, false));

        teams[14].addPlayer(new player(1, 8, 4, 4, 4, 5, 10, 9, 5, 6, 5, 10, 27, "Vrá Nonhkwaqan", Country.Sagua, false));
        teams[14].addPlayer(new player(2, 9, 3, 9, 9, 8, 8, 8, 4, 10, 5, 6, 25, "Moke Douangvily", Country.Loviniosa, false));
        teams[14].addPlayer(new player(3, 9, 10, 10, 5, 9, 10, 9, 10, 10, 5, 8, 24, "Klaxon Nixoka", Country.Blaist_Blaland, false));
        teams[14].addPlayer(new player(4, 6, 2, 10, 10, 7, 9, 8, 2, 9, 5, 5, 25, "Danomobei Motxev", Country.Dotruga, false));
        teams[14].addPlayer(new player(5, 10, 2, 15, 10, 10, 10, 10, 4, 10, 5, 9, 27, "Transhilmalia Player #2", Country.Transhimalia, false));
        teams[14].addPlayer(new player(5, 3, 5, 9, 10, 9, 6, 4, 1, 8, 2, 10, 21, "Nathaniel Bate", Country.Ethanthova, false));
        teams[14].addPlayer(new player(2, 10, 9, 3, 3, 4, 6, 8, 9, 8, 8, 8, 20, "Iveo Vokigei", Country.Auspikitan, false));
        teams[14].addPlayer(new player(4, 7, 1, 9, 9, 5, 8, 7, 2, 8, 5, 7, 26, "Niko Stengel", Country.Tri_National_Dominion, false));
        teams[14].addPlayer(new player(3, 10, 8, 9, 9, 5, 8, 4, 7, 7, 5, 7, 21, "K'ita Senako", Country.Oesa, false));
        teams[14].addPlayer(new player(4, 4, 4, 8, 8, 6, 5, 7, 4, 7, 5, 8, 22, "Nupa Auprat", Country.Blaist_Blaland, false));
        teams[14].addPlayer(new player(1, 7, 6, 4, 3, 2, 4, 8, 10, 6, 8, 9, 23, "Dylan Cass", Country.Ethanthova, false));
        teams[14].addPlayer(new player(5, 3, 5, 8, 10, 10, 7, 5, 3, 7, 10, 10, 21, "Pakomha Dakómh", Country.Sagua, false));
        teams[14].addPlayer(new player(3, 7, 9, 5, 5, 3, 5, 10, 7, 7, 6, 8, 26, "Alomiba Xahelvi", Country.Dotruga, false));
        teams[14].addPlayer(new player(2, 9, 8, 6, 6, 5, 4, 4, 7, 7, 5, 10, 27, "Dimitri Ebron", Country.Wyverncliff, false));
        teams[14].addPlayer(new player(1, 5, 9, 5, 3, 4, 4, 9, 9, 7, 6, 7, 22, "Teva Gekxakŋi", Country.Auspikitan, false));

        teams[15].addPlayer(new player(1, 8, 3, 5, 5, 3, 9, 9, 9, 6, 5, 6, 27, "Power Forward #166", Country.Holy_Yektonisa, false));
        teams[15].addPlayer(new player(2, 8, 9, 4, 2, 3, 9, 9, 8, 8, 9, 9, 23, "Kibibei Hatemosei", Country.Dotruga, false));
        teams[15].addPlayer(new player(3, 8, 5, 10, 10, 10, 9, 9, 5, 6, 5, 7, 22, "Eun Cho", Country.Shmupland, false));
        teams[15].addPlayer(new player(4, 5, 9, 9, 9, 5, 9, 9, 4, 10, 4, 7, 23, "Steve Sho", Country.Barsein, false));
        teams[15].addPlayer(new player(5, 4, 3, 7, 7, 10, 9, 9, 2, 10, 5, 6, 25, "Billingulbut", Country.Aiyota, false));
        teams[15].addPlayer(new player(2, 10, 2, 4, 4, 5, 6, 7, 6, 5, 5, 8, 27, "Power Forward #151", Country.Lyintaria, false));
        teams[15].addPlayer(new player(1, 10, 10, 1, 1, 5, 10, 9, 10, 7, 5, 5, 23, "Eric Newton", Country.Ethanthova, false));
        teams[15].addPlayer(new player(1, 8, 7, 5, 5, 5, 7, 6, 7, 5, 7, 8, 23, "Vŕá Płońiblá", Country.Nausicaa, false));
        teams[15].addPlayer(new player(5, 1, 4, 10, 10, 8, 8, 3, 4, 3, 5, 5, 27, "Ji-Min Choi", Country.Shmupland, false));
        teams[15].addPlayer(new player(5, 8, 3, 5, 5, 10, 8, 9, 8, 5, 1, 5, 22, "Tapan Sikasbë", Country.Darvincia, false));
        teams[15].addPlayer(new player(4, 6, 1, 6, 6, 7, 9, 6, 3, 7, 5, 6, 27, "Aiyota Player #3", Country.Aiyota, false));
        teams[15].addPlayer(new player(3, 5, 4, 8, 8, 9, 6, 4, 5, 3, 5, 6, 24, "Malo Sayasone", Country.Loviniosa, false));
        teams[15].addPlayer(new player(4, 9, 5, 9, 10, 4, 6, 6, 2, 4, 4, 6, 24, "Teyvada Somphousiharath", Country.Pyxanovia, false));
        teams[15].addPlayer(new player(3, 7, 7, 7, 7, 1, 6, 5, 7, 5, 5, 9, 25, "Sung-Soo Song", Country.Shmupland, false));
        teams[15].addPlayer(new player(2, 8, 7, 4, 4, 5, 4, 7, 10, 5, 5, 6, 26, "Zax Kaxpa", Country.Blaist_Blaland, false));

        teams[7].addPlayer(new player(1, 10, 4, 6, 5, 8, 8, 10, 9, 10, 5, 8, 20, "Alomundi Bituna", Country.Dotruga, false));
        teams[7].addPlayer(new player(2, 7, 10, 7, 5, 8, 7, 8, 9, 10, 5, 7, 27, "Hënila Ūnā", Country.Darvincia, false));
        teams[7].addPlayer(new player(3, 10, 4, 14, 14, 9, 10, 10, 1, 12, 5, 6, 27, "Kersok Milan", Country.Bielosia, false));
        teams[7].addPlayer(new player(4, 6, 2, 10, 10, 10, 9, 8, 2, 10, 6, 7, 27, "voput epoikez tapnatiš", Country.Solea, false));
        teams[7].addPlayer(new player(5, 9, 5, 10, 10, 8, 7, 8, 4, 10, 5, 8, 25, "Makiaipisi Fana", Country.Auspikitan, false));
        teams[7].addPlayer(new player(1, 9, 9, 6, 5, 8, 7, 10, 7, 9, 6, 6, 21, "Boḿa Blamhákpwano", Country.Height_Sagua, false));
        teams[7].addPlayer(new player(2, 4, 9, 4, 4, 5, 10, 10, 10, 8, 5, 9, 27, "Msenne Prai", Country.Aeridani, false));
        teams[7].addPlayer(new player(3, 7, 5, 10, 10, 8, 10, 6, 3, 10, 5, 5, 27, "Rvai Florkotae", Country.Lyintaria, false));
        teams[7].addPlayer(new player(4, 6, 8, 8, 9, 7, 8, 7, 2, 7, 2, 10, 20, "Vince Fowler", Country.Ethanthova, false));
        teams[7].addPlayer(new player(5, 2, 8, 7, 7, 10, 7, 8, 4, 7, 5, 10, 27, "zeppak itehíl tikítákh", Country.Solea, false));
        teams[7].addPlayer(new player(1, 8, 10, 1, 1, 3, 7, 8, 8, 6, 5, 5, 19, "Kipana Nibrit", Country.Auspikitan, false));
        teams[7].addPlayer(new player(2, 6, 5, 5, 6, 5, 8, 5, 6, 9, 6, 6, 23, "Pau Nipta", Country.Auspikitan, false));
        teams[7].addPlayer(new player(3, 1, 9, 3, 4, 9, 7, 9, 4, 5, 1, 10, 20, "Xaisomboun Tayvihane", Country.Bielosia, false));
        teams[7].addPlayer(new player(4, 5, 4, 9, 10, 6, 6, 5, 2, 6, 7, 10, 21, "Murata Yoshifumi", Country.Aeridani, false));
        teams[7].addPlayer(new player(5, 7, 1, 6, 3, 7, 5, 10, 9, 7, 2, 5, 19, "Ḿavwápŕi Sŕóniqńoqi", Country.Nausicaa, false));

        teams[22].addPlayer(new player(1, 8, 9, 3, 3, 3, 10, 7, 12, 6, 5, 5, 27, "Mabebosei Alotro", Country.Dotruga, false));
        teams[22].addPlayer(new player(2, 6, 5, 5, 5, 3, 10, 6, 10, 4, 5, 9, 27, "eneŋ zekek zeilunaven", Country.Solea, false));
        teams[22].addPlayer(new player(3, 5, 6, 9, 9, 5, 5, 5, 8, 4, 2, 10, 22, "Sebastien Robertson", Country.Ethanthova, false));
        teams[22].addPlayer(new player(4, 3, 8, 10, 8, 7, 8, 7, 1, 6, 7, 9, 23, "Gorga Ektxr", Country.Dotruga, false));
        teams[22].addPlayer(new player(5, 7, 4, 8, 7, 10, 7, 7, 4, 10, 9, 9, 21, "Okada Sumiteru", Country.Barsein, false));
        teams[22].addPlayer(new player(1, 5, 9, 4, 2, 4, 7, 7, 10, 5, 10, 7, 23, "Nagata Taki", Country.Aeridani, false));
        teams[22].addPlayer(new player(4, 5, 3, 10, 10, 4, 5, 6, 1, 8, 5, 5, 23, "Lavrenti Ogden", Country.Wyverncliff, false));
        teams[22].addPlayer(new player(2, 6, 2, 7, 7, 7, 10, 3, 6, 3, 5, 8, 27, "Blanaxon Player #2", Country.Blaist_Blaland, false));
        teams[22].addPlayer(new player(2, 6, 8, 4, 3, 5, 7, 6, 9, 7, 10, 7, 23, "Keahi Saenthavisouk", Country.Bielosia, false));
        teams[22].addPlayer(new player(3, 1, 8, 10, 10, 2, 2, 10, 9, 9, 5, 7, 27, "Aahrus Player #5", Country.Aahrus, false));
        teams[22].addPlayer(new player(3, 5, 6, 7, 7, 10, 2, 4, 4, 7, 5, 8, 23, "Sagolegotosiei Sagotxile", Country.Dotruga, false));
        teams[22].addPlayer(new player(5, 6, 1, 7, 7, 8, 4, 7, 3, 7, 5, 10, 25, "pekleɰ tiwan", Country.Solea, false));
        teams[22].addPlayer(new player(5, 2, 3, 10, 10, 6, 1, 8, 3, 3, 5, 8, 27, "Dude McBeth", Country.Bielosia, false));
        teams[22].addPlayer(new player(1, 10, 6, 2, 2, 4, 10, 1, 8, 7, 5, 8, 27, "Om Kwang-Jo", Country.Shmupland, false));
        teams[22].addPlayer(new player(4, 5, 3, 10, 10, 4, 5, 6, 1, 8, 5, 5, 24, "Lavrenti Ogden", Country.Wyverncliff, false));

        teams[23].addPlayer(new player(1, 10, 6, 2, 2, 5, 10, 8, 12, 6, 5, 5, 27, "Tri_National_Dominion Player #1", Country.Tri_National_Dominion, false));
        teams[23].addPlayer(new player(2, 10, 6, 6, 5, 3, 5, 6, 10, 6, 1, 8, 22, "Wilbert Harries", Country.Ethanthova, false));
        teams[23].addPlayer(new player(3, 8, 9, 10, 10, 8, 7, 7, 7, 8, 5, 9, 24, "Phetdum Vatthana", Country.Loviniosa, false));
        teams[23].addPlayer(new player(4, 10, 5, 10, 10, 1, 5, 6, 5, 4, 6, 6, 25, "Noxku Noxtan", Country.Blaist_Blaland, false));
        teams[23].addPlayer(new player(5, 10, 7, 6, 6, 9, 7, 6, 2, 5, 8, 5, 27, "LeBryon James", Country.Tri_National_Dominion, false));
        teams[23].addPlayer(new player(4, 6, 9, 9, 10, 5, 6, 6, 4, 8, 9, 5, 23, "Quartermarra", Country.Aiyota, false));
        teams[23].addPlayer(new player(4, 7, 2, 9, 9, 4, 8, 6, 1, 10, 5, 9, 25, "Pakomha Nhoñsła", Country.Sagua, false));
        teams[23].addPlayer(new player(5, 6, 6, 6, 10, 8, 7, 8, 2, 8, 10, 9, 25, "Phetdum Vongsay", Country.Pyxanovia, false));
        teams[23].addPlayer(new player(3, 9, 7, 8, 8, 1, 8, 5, 6, 4, 5, 5, 27, "Tri_National_Dominion Player #10", Country.Tri_National_Dominion, false));
        teams[23].addPlayer(new player(3, 7, 10, 9, 7, 5, 8, 4, 9, 7, 6, 7, 22, "Lvieknim Yuji", Country.Transhimalia, false));
        teams[23].addPlayer(new player(2, 5, 6, 4, 4, 5, 4, 6, 8, 7, 5, 10, 22, "Pyxanovia Player #5", Country.Pyxanovia, false));
        teams[23].addPlayer(new player(2, 6, 7, 6, 6, 7, 9, 9, 6, 6, 6, 9, 24, "Kwak Chihu", Country.Shmupland, false));
        teams[23].addPlayer(new player(1, 10, 10, 1, 2, 4, 7, 6, 8, 4, 5, 5, 22, "Kiromi Hialerko", Country.Dotruga, false));
        teams[23].addPlayer(new player(5, 5, 2, 8, 8, 8, 7, 7, 4, 7, 5, 5, 27, "Tri_National_Dominion Player #3", Country.Tri_National_Dominion, false));
        teams[23].addPlayer(new player(1, 5, 5, 1, 1, 5, 6, 7, 8, 2, 5, 7, 27, "Tri_National_Dominion Player #9", Country.Tri_National_Dominion, false));

        teams[31].addPlayer(new player(1, 9, 7, 1, 1, 5, 5, 9, 10, 6, 5, 7, 24, "Timblejoornay", Country.Aiyota, false));
        teams[31].addPlayer(new player(2, 6, 8, 4, 4, 4, 7, 5, 8, 7, 5, 7, 27, "Qrux'uhz the Enraged", Country.Transhimalia, false));
        teams[31].addPlayer(new player(3, 9, 3, 10, 10, 4, 8, 8, 7, 5, 5, 8, 27, "King Kalassak", Country.Transhimalia, false));
        teams[31].addPlayer(new player(4, 6, 1, 10, 10, 8, 8, 8, 4, 10, 5, 7, 27, "Sachie Snijder", Country.Wyverncliff, false));
        teams[31].addPlayer(new player(5, 6, 4, 10, 10, 10, 8, 8, 1, 9, 8, 9, 23, "Steve Masuhiro", Country.Transhimalia, false));
        teams[31].addPlayer(new player(2, 9, 5, 3, 3, 6, 7, 3, 9, 4, 5, 10, 25, "Akamu Tayvyihane", Country.Loviniosa, false));
        teams[31].addPlayer(new player(1, 9, 10, 4, 4, 3, 9, 3, 6, 2, 5, 6, 24, "Ingo Gradl", Country.Tri_National_Dominion, false));
        teams[31].addPlayer(new player(5, 6, 2, 7, 7, 8, 4, 7, 3, 5, 5, 8, 22, "Klabo Bexoxek", Country.Dotruga, false));
        teams[31].addPlayer(new player(2, 10, 6, 3, 3, 5, 6, 6, 8, 6, 5, 7, 27, "Center #113", Country.Aeridani, false));
        teams[31].addPlayer(new player(3, 9, 7, 7, 8, 5, 8, 10, 6, 6, 5, 9, 24, "Eiqe Gekxakŋi", Country.Auspikitan, false));
        teams[31].addPlayer(new player(5, 6, 4, 7, 7, 7, 7, 6, 3, 4, 5, 10, 27, "Sreotruyphoe the Expunger", Country.Transhimalia, false));
        teams[31].addPlayer(new player(1, 8, 10, 3, 3, 2, 9, 10, 10, 6, 1, 5, 23, "Danotra Beselapo", Country.Dotruga, false));
        teams[31].addPlayer(new player(4, 9, 4, 9, 9, 5, 4, 9, 9, 1, 5, 9, 27, "Ceokmihza the Igniter", Country.Transhimalia, false));
        teams[31].addPlayer(new player(4, 5, 2, 7, 7, 6, 10, 4, 3, 8, 5, 10, 27, "Kmeav'hsoe the Wretched", Country.Transhimalia, false));
        teams[31].addPlayer(new player(3, 4, 6, 8, 10, 8, 7, 6, 6, 9, 8, 8, 20, "Kalani Phanivong", Country.Bielosia, false));

        dLeagueTeams.Add(new team("Aeridani Troopers", r));
        dLeagueTeams[0].addPlayer(new player(1, 10, 5, 3, 3, 5, 7, 9, 7, 6, 5, 5, 27, "Stuyr'et the Dominator", Country.Transhimalia, false));
        dLeagueTeams[0].addPlayer(new player(1, 9, 9, 1, 1, 1, 7, 8, 6, 6, 5, 5, 27, "Autolik Player #7", Country.Blaist_Blaland, false));
        dLeagueTeams[0].addPlayer(new player(4, 3, 3, 10, 9, 5, 7, 7, 2, 6, 4, 6, 21, "Heine Hutto", Country.Tri_National_Dominion, false));
        dLeagueTeams[0].addPlayer(new player(4, 2, 2, 6, 6, 7, 7, 8, 3, 8, 5, 5, 27, "Height Sagua Player #6", Country.Pyxanovia, false));
        dLeagueTeams[0].addPlayer(new player(4, 7, 4, 8, 9, 2, 3, 5, 5, 6, 3, 10, 26, "Stephen Starks", Country.Dtersauuw_Sagua, false));
        dLeagueTeams[0].addPlayer(new player(2, 9, 3, 6, 6, 1, 1, 2, 8, 6, 5, 7, 27, "Aiyota Player #10", Country.Aiyota, false));
        dLeagueTeams[0].addPlayer(new player(2, 8, 2, 1, 1, 4, 4, 3, 9, 6, 5, 6, 26, "Sung-Soo Chung", Country.Shmupland, false));
        dLeagueTeams[0].addPlayer(new player(5, 6, 4, 4, 4, 6, 4, 3, 1, 7, 5, 7, 27, "Ethanthova Player #10", Country.Ethanthova, false));
        dLeagueTeams[0].addPlayer(new player(2, 5, 6, 4, 4, 4, 2, 5, 8, 6, 5, 9, 27, "Pyxanovia Player #6", Country.Pyxanovia, false));
        dLeagueTeams[0].addPlayer(new player(5, 4, 4, 2, 2, 8, 3, 3, 3, 7, 5, 7, 24, "Yqt Messi", Country.Red_Rainbow, false));
        dLeagueTeams[0].addPlayer(new player(3, 7, 5, 5, 5, 4, 6, 4, 9, 2, 5, 5, 27, "Small Forward #67", Country.Holykol, false));
        dLeagueTeams[0].addPlayer(new player(5, 1, 4, 7, 7, 6, 7, 5, 2, 4, 5, 5, 27, "Point Guard #9", Country.Bielosia, false));
        dLeagueTeams[0].addPlayer(new player(3, 5, 7, 7, 7, 2, 3, 4, 3, 6, 5, 5, 24, "Wongduan Somphonpadee", Country.Bielosia, false));
        dLeagueTeams[0].addPlayer(new player(3, 4, 1, 4, 4, 9, 2, 7, 10, 5, 5, 3, 27, "Small Forward #76", Country.Transhimalia, false));
        dLeagueTeams[0].addPlayer(new player(1, 5, 8, 1, 1, 2, 9, 5, 6, 1, 5, 5, 25, "Atiga Porle", Country.Dotruga, false));

        dLeagueTeams.Add(new team("Zaxon Zephyrs", r));
        dLeagueTeams[1].addPlayer(new player(4, 6, 1, 9, 9, 7, 1, 7, 4, 10, 5, 5, 23, "Itso Bigo", Country.Aeridani, false));
        dLeagueTeams[1].addPlayer(new player(1, 10, 7, 2, 2, 5, 4, 4, 7, 5, 5, 10, 27, "Able", Country.Darvincia, false));
        dLeagueTeams[1].addPlayer(new player(1, 7, 9, 3, 3, 3, 7, 5, 7, 5, 5, 5, 21, "Watsuji Isei", Country.Aeridani, false));
        dLeagueTeams[1].addPlayer(new player(5, 4, 1, 7, 7, 7, 6, 3, 1, 7, 5, 6, 24, "Cabodu Kanix", Country.Darvincia, false));
        dLeagueTeams[1].addPlayer(new player(5, 4, 1, 7, 7, 7, 6, 3, 1, 7, 5, 6, 23, "Brodie Cropper", Country.Wyverncliff, false));
        dLeagueTeams[1].addPlayer(new player(5, 3, 2, 4, 4, 8, 3, 5, 1, 7, 5, 9, 27, "Point Guard #126", Country.Aiyota, false));
        dLeagueTeams[1].addPlayer(new player(3, 5, 7, 5, 5, 2, 7, 7, 6, 2, 5, 8, 27, "Small Forward #115", Country.Bongatar, false));
        dLeagueTeams[1].addPlayer(new player(4, 4, 3, 5, 5, 4, 9, 3, 2, 7, 5, 7, 22, "panpek hana ševéŋkev", Country.Aahrus, false));
        dLeagueTeams[1].addPlayer(new player(4, 7, 2, 8, 8, 4, 2, 3, 3, 4, 5, 10, 27, "Bongatar Player #6", Country.Auspikitan, false));
        dLeagueTeams[1].addPlayer(new player(1, 5, 9, 2, 2, 4, 5, 3, 8, 2, 5, 5, 20, "Seino Seviba", Country.Lyintaria, false));
        dLeagueTeams[1].addPlayer(new player(3, 7, 5, 5, 5, 4, 6, 4, 9, 2, 5, 5, 27, "Transhilmalia Player #9", Country.Transhimalia, false));
        dLeagueTeams[1].addPlayer(new player(2, 5, 4, 8, 8, 9, 6, 4, 5, 3, 5, 6, 26, "Malo Sayasone", Country.Lyintaria, false));
        dLeagueTeams[1].addPlayer(new player(3, 3, 1, 6, 7, 9, 4, 4, 7, 4, 3, 9, 24, "Kardo Rrasab", Country.Darvincia, false));
        dLeagueTeams[1].addPlayer(new player(2, 8, 4, 1, 1, 3, 3, 5, 8, 3, 5, 5, 27, "Ethanthova Player #13", Country.Ethanthova, false));
        dLeagueTeams[1].addPlayer(new player(2, 7, 4, 2, 2, 2, 9, 1, 7, 5, 5, 5, 22, "Channing Clark", Country.Wyverncliff, false));

        dLeagueTeams.Add(new team("Vincent Vikings", r));
        dLeagueTeams[2].addPlayer(new player(3, 2, 6, 5, 9, 9, 8, 5, 3, 10, 1, 9, 20, "Carsten Meyer", Country.Tri_National_Dominion, false));
        dLeagueTeams[2].addPlayer(new player(4, 8, 8, 4, 4, 9, 4, 2, 5, 6, 5, 8, 27, "Shooting Guard #101", Country.Dtersauuw_Sagua, false));
        dLeagueTeams[2].addPlayer(new player(1, 9, 9, 4, 5, 5, 8, 7, 5, 4, 8, 5, 23, "Làto Sokàtà", Country.Darvincia, false));
        dLeagueTeams[2].addPlayer(new player(2, 8, 3, 5, 5, 6, 6, 8, 5, 3, 5, 7, 27, "Power Forward #136", Country.Darvincia, false));
        dLeagueTeams[2].addPlayer(new player(1, 4, 6, 1, 1, 1, 8, 7, 11, 3, 5, 5, 27, "Lyintaria Player #8", Country.Lyintaria, false));
        dLeagueTeams[2].addPlayer(new player(2, 5, 7, 4, 4, 2, 6, 5, 9, 5, 5, 5, 27, "Aiyota Player #11", Country.Aiyota, false));
        dLeagueTeams[2].addPlayer(new player(1, 7, 6, 3, 3, 5, 6, 6, 6, 6, 5, 6, 27, "Center #116", Country.Red_Rainbow, false));
        dLeagueTeams[2].addPlayer(new player(2, 7, 7, 3, 3, 6, 3, 7, 6, 4, 5, 7, 27, "Power Forward #113", Country.Blaist_Blaland, false));
        dLeagueTeams[2].addPlayer(new player(5, 3, 3, 5, 5, 10, 3, 4, 2, 4, 5, 9, 27, "Point Guard #149", Country.Dotruga, false));
        dLeagueTeams[2].addPlayer(new player(3, 7, 5, 6, 6, 3, 5, 7, 4, 1, 5, 8, 27, "Small Forward #111", Country.Oesa, false));
        dLeagueTeams[2].addPlayer(new player(3, 6, 4, 7, 7, 7, 6, 4, 4, 1, 5, 7, 27, "Small Forward #120", Country.Tri_National_Dominion, false));
        dLeagueTeams[2].addPlayer(new player(5, 6, 3, 5, 5, 7, 5, 5, 2, 2, 5, 9, 27, "Point Guard #167", Country.Ethanthova, false));
        dLeagueTeams[2].addPlayer(new player(5, 1, 4, 7, 7, 6, 7, 5, 2, 4, 5, 5, 27, "Ethanthova Player #11", Country.Ethanthova, false));
        dLeagueTeams[2].addPlayer(new player(4, 6, 2, 8, 8, 6, 5, 8, 1, 1, 5, 5, 26, "Abi Rrasab", Country.Sagua, false));
        dLeagueTeams[2].addPlayer(new player(4, 4, 1, 10, 10, 4, 3, 2, 3, 5, 5, 5, 27, "Shooting Guard #43", Country.Ethanthova, false));

        dLeagueTeams.Add(new team("Bongatar Boppers", r));
        dLeagueTeams[3].addPlayer(new player(4, 3, 6, 6, 8, 7, 6, 6, 3, 7, 3, 9, 21, "Mya Saysamongdy", Country.Bielosia, false));
        dLeagueTeams[3].addPlayer(new player(5, 7, 1, 6, 4, 7, 6, 9, 8, 5, 8, 6, 26, "Làto Naksik", Country.Darvincia, false));
        dLeagueTeams[3].addPlayer(new player(3, 6, 8, 1, 1, 4, 7, 8, 6, 7, 1, 7, 20, "Alomundi Korsobo", Country.Dotruga, false));
        dLeagueTeams[3].addPlayer(new player(5, 3, 3, 7, 9, 10, 5, 4, 2, 4, 5, 9, 23, "Kaliso Alolundi", Country.Dotruga, false));
        dLeagueTeams[3].addPlayer(new player(2, 5, 7, 5, 5, 4, 2, 6, 9, 7, 5, 5, 27, "Blanaxon Player #9", Country.Blaist_Blaland, false));
        dLeagueTeams[3].addPlayer(new player(4, 2, 4, 9, 9, 9, 4, 3, 4, 5, 5, 5, 27, "Shooting Guard #105", Country.Holykol, false));
        dLeagueTeams[3].addPlayer(new player(2, 3, 5, 3, 3, 5, 5, 7, 8, 5, 5, 10, 27, "TND Player #5", Country.Tri_National_Dominion, false));
        dLeagueTeams[3].addPlayer(new player(2, 8, 6, 5, 5, 3, 9, 1, 8, 3, 5, 6, 26, "Rizaxon Klegna", Country.Blaist_Blaland, false));
        dLeagueTeams[3].addPlayer(new player(3, 5, 7, 6, 2, 3, 5, 10, 3, 1, 1, 5, 20, "Bane Thammasith", Country.Lyintaria, false));
        dLeagueTeams[3].addPlayer(new player(5, 2, 3, 1, 1, 5, 8, 8, 4, 6, 5, 9, 27, "Point Guard #133", Country.Height_Sagua, false));
        dLeagueTeams[3].addPlayer(new player(3, 7, 6, 5, 5, 5, 6, 3, 4, 4, 5, 5, 27, "Small Forward #162", Country.Sagua, false));
        dLeagueTeams[3].addPlayer(new player(1, 5, 6, 1, 1, 4, 7, 7, 7, 4, 5, 5, 27, "Center #140", Country.Dotruga, false));
        dLeagueTeams[3].addPlayer(new player(4, 1, 3, 6, 6, 4, 6, 1, 3, 5, 5, 10, 27, "Shooting Guard #86", Country.Czalliso, false));
        dLeagueTeams[3].addPlayer(new player(1, 6, 6, 1, 1, 5, 8, 5, 7, 3, 5, 5, 27, "Center #161", Country.Bielosia, false));
        dLeagueTeams[3].addPlayer(new player(1, 8, 8, 2, 2, 5, 2, 1, 6, 6, 5, 10, 27, "Aiyota Player #8", Country.Aiyota, false));
        
        dLeagueTeams.Add(new team("Pyxanovia Elites", r));
        dLeagueTeams[4].addPlayer(new player(2, 6, 4, 5, 4, 7, 6, 8, 8, 9, 3, 5, 26, "Kompasu Yasuoka", Country.Aeridani, false));
        dLeagueTeams[4].addPlayer(new player(5, 5, 7, 9, 8, 4, 8, 6, 1, 7, 3, 5, 22, "Alfred Unterberger", Country.Tri_National_Dominion, false));
        dLeagueTeams[4].addPlayer(new player(5, 6, 2, 5, 3, 7, 10, 5, 8, 5, 4, 7, 22, "Sol Kwang-Jo", Country.Shmupland, false));
        dLeagueTeams[4].addPlayer(new player(4, 5, 1, 5, 5, 5, 8, 8, 2, 8, 5, 5, 27, "Sagua Player #9", Country.Shmupland, false));
        dLeagueTeams[4].addPlayer(new player(3, 6, 4, 1, 1, 8, 8, 9, 1, 5, 5, 6, 25, "Kalani Thonemany", Country.Loviniosa, false));
        dLeagueTeams[4].addPlayer(new player(5, 1, 4, 7, 7, 8, 6, 4, 3, 4, 5, 8, 26, "Kimo Rattanvongsa", Country.Loviniosa, false));
        dLeagueTeams[4].addPlayer(new player(1, 7, 8, 2, 2, 5, 8, 3, 7, 3, 5, 8, 23, "Lekai Modoki", Country.Oesa, false));
        dLeagueTeams[4].addPlayer(new player(2, 8, 8, 1, 1, 2, 4, 6, 7, 6, 5, 5, 24, "Woo-Jin Cho", Country.Shmupland, false));
        dLeagueTeams[4].addPlayer(new player(2, 4, 6, 3, 3, 2, 7, 4, 6, 7, 5, 9, 27, "Key To Don Player #9", Country.Key_to_Don, false));
        dLeagueTeams[4].addPlayer(new player(4, 6, 1, 6, 6, 7, 9, 5, 4, 2, 5, 5, 24, "Daddy Bank Shot", Country.Aeridani, false));
        dLeagueTeams[4].addPlayer(new player(3, 7, 6, 4, 4, 2, 6, 1, 6, 7, 5, 6, 22, "Bane Sisoulith", Country.Bongatar, false));
        dLeagueTeams[4].addPlayer(new player(1, 7, 8, 2, 2, 3, 5, 3, 7, 4, 5, 7, 23, "Pranga", Country.Aiyota, false));
        dLeagueTeams[4].addPlayer(new player(1, 5, 6, 3, 1, 4, 5, 9, 7, 3, 7, 8, 20, "Gago Hatemosei", Country.Dotruga, false));
        dLeagueTeams[4].addPlayer(new player(3, 6, 2, 3, 3, 2, 7, 9, 1, 2, 5, 5, 27, "Small Forward #44", Country.Shmupland, false));
        dLeagueTeams[4].addPlayer(new player(4, 4, 5, 6, 6, 2, 4, 2, 2, 7, 5, 7, 27, "Shooting Guard #147", Country.Pyxanovia, false));

        dLeagueTeams.Add(new team("Alteus Astronauts", r));
        dLeagueTeams[5].addPlayer(new player(3, 10, 2, 2, 2, 6, 8, 6, 1, 7, 6, 10, 19, "Pat Turner", Country.Wyverncliff, false));
        dLeagueTeams[5].addPlayer(new player(1, 8, 9, 1, 1, 1, 8, 5, 7, 6, 5, 5, 27, "Bongatar Player #7", Country.Bongatar, false));
        dLeagueTeams[5].addPlayer(new player(1, 10, 9, 2, 2, 1, 8, 2, 8, 4, 5, 5, 27, "Peika Baisoŋa", Country.Auspikitan, false));
        dLeagueTeams[5].addPlayer(new player(1, 9, 10, 2, 2, 3, 3, 9, 6, 3, 5, 7, 24, "Blanoxium Toxium", Country.Blaist_Blaland, false));
        dLeagueTeams[5].addPlayer(new player(5, 3, 5, 6, 7, 7, 4, 5, 2, 5, 4, 10, 20, "Kaliso Bexomos", Country.Dotruga, false));
        dLeagueTeams[5].addPlayer(new player(2, 8, 2, 4, 4, 4, 2, 5, 7, 6, 5, 5, 27, "Bongatar Player #11", Country.Bongatar, false));
        dLeagueTeams[5].addPlayer(new player(3, 7, 5, 3, 3, 7, 6, 7, 4, 4, 5, 5, 27, "Small Forward #177", Country.Transhimalia, false));
        dLeagueTeams[5].addPlayer(new player(2, 6, 7, 3, 3, 6, 6, 6, 5, 4, 5, 7, 27, "Power Forward #152", Country.Key_to_Don, false));
        dLeagueTeams[5].addPlayer(new player(4, 3, 3, 7, 7, 6, 2, 7, 2, 8, 5, 5, 27, "Aiyota Player #9", Country.Dotruga, false));
        dLeagueTeams[5].addPlayer(new player(5, 6, 3, 3, 3, 7, 5, 5, 4, 4, 5, 8, 27, "Point Guard #107", Country.Dtersauuw_Sagua, false));
        dLeagueTeams[5].addPlayer(new player(2, 4, 7, 5, 5, 6, 1, 4, 8, 3, 5, 9, 23, "Tipeprik Vokigei", Country.Ethanthova, false));
        dLeagueTeams[5].addPlayer(new player(5, 1, 4, 3, 3, 7, 8, 6, 2, 3, 5, 9, 26, "Justin Deiters", Country.Wyverncliff, false));
        dLeagueTeams[5].addPlayer(new player(4, 1, 3, 6, 6, 4, 6, 1, 3, 5, 5, 10, 22, "Prokavexa Nexium", Country.Darvincia, false));
        dLeagueTeams[5].addPlayer(new player(3, 2, 4, 8, 4, 3, 7, 3, 6, 3, 3, 5, 21, "Paxathipatai Cheruene", Country.Lyintaria, false));
        dLeagueTeams[5].addPlayer(new player(4, 2, 3, 6, 6, 5, 6, 2, 6, 6, 5, 5, 27, "Shooting Guard #158", Country.Wyverncliff, false));

        dLeagueTeams.Add(new team("Naskitrusk Brutes", r));
        dLeagueTeams[6].addPlayer(new player(1, 10, 3, 2, 2, 5, 8, 8, 7, 6, 5, 5, 27, "Center #137", Country.Holy_Yektonisa, false));
        dLeagueTeams[6].addPlayer(new player(2, 8, 7, 6, 6, 6, 7, 4, 6, 5, 2, 9, 25, "Malcolm Mortlock", Country.Ethanthova, false));
        dLeagueTeams[6].addPlayer(new player(3, 3, 5, 4, 4, 8, 7, 7, 8, 6, 9, 7, 24, "Munglegarra", Country.Aiyota, false));
        dLeagueTeams[6].addPlayer(new player(3, 10, 6, 3, 3, 3, 7, 4, 5, 5, 5, 7, 23, "How", Country.Darvincia, false));
        dLeagueTeams[6].addPlayer(new player(3, 4, 7, 7, 7, 2, 6, 3, 7, 7, 5, 6, 27, "Small Forward #132", Country.Shmupland, false));
        dLeagueTeams[6].addPlayer(new player(5, 4, 4, 4, 4, 8, 8, 4, 3, 6, 5, 6, 27, "Blanaxon Player #7", Country.Blaist_Blaland, false));
        dLeagueTeams[6].addPlayer(new player(1, 6, 9, 1, 1, 4, 4, 7, 8, 2, 5, 6, 21, "Handa Minoru", Country.Aeridani, false));
        dLeagueTeams[6].addPlayer(new player(2, 3, 5, 3, 3, 3, 9, 3, 9, 7, 5, 6, 24, "Malo Phoutthasinh", Country.Solea, false));
        dLeagueTeams[6].addPlayer(new player(2, 8, 7, 3, 3, 2, 3, 1, 7, 7, 5, 10, 24, "Mávlika Vósnakniñqávla", Country.Sagua, false));
        dLeagueTeams[6].addPlayer(new player(5, 3, 1, 3, 3, 7, 5, 3, 4, 7, 5, 7, 27, "Point Guard #142", Country.Dotruga, false));
        dLeagueTeams[6].addPlayer(new player(4, 8, 4, 6, 6, 2, 3, 4, 3, 5, 1, 9, 24, "Omumbisei Hadosa", Country.Blaist_Blaland, false));
        dLeagueTeams[6].addPlayer(new player(1, 5, 7, 2, 2, 5, 5, 9, 7, 2, 5, 5, 23, "Ek Hersa", Country.Dotruga, false));
        dLeagueTeams[6].addPlayer(new player(4, 6, 2, 8, 7, 1, 5, 6, 2, 4, 6, 8, 24, "Niko Unterberger", Country.Tri_National_Dominion, false));
        dLeagueTeams[6].addPlayer(new player(5, 4, 3, 5, 5, 7, 4, 3, 1, 6, 5, 5, 27, "Autolik Player #13", Country.Blaist_Blaland, false));
        dLeagueTeams[6].addPlayer(new player(4, 2, 3, 3, 9, 9, 6, 2, 8, 5, 5, 5, 23, "Derto Himei", Country.Holy_Yektonisa, false));

        dLeagueTeams.Add(new team("Klákjábo Servals", r));
        dLeagueTeams[7].addPlayer(new player(2, 3, 8, 2, 2, 4, 10, 6, 8, 7, 5, 8, 27, "Bongatar Player #5", Country.Bongatar, false));
        dLeagueTeams[7].addPlayer(new player(1, 5, 10, 3, 1, 3, 1, 6, 8, 6, 8, 8, 20, "Zeabik Bitsekzeba", Country.Auspikitan, false));
        dLeagueTeams[7].addPlayer(new player(2, 8, 5, 4, 4, 2, 3, 6, 9, 7, 5, 8, 27, "Holy Yektonesia Player #2", Country.Holy_Yektonisa, false));
        dLeagueTeams[7].addPlayer(new player(2, 9, 3, 1, 1, 1, 5, 6, 7, 7, 5, 7, 27, "Boltway Player #9", Country.Ethanthova, false));
        dLeagueTeams[7].addPlayer(new player(4, 7, 4, 9, 9, 2, 4, 5, 4, 7, 2, 7, 23, "Kolnu Auprat", Country.Sagua, false));
        dLeagueTeams[7].addPlayer(new player(3, 2, 5, 8, 8, 2, 1, 9, 7, 8, 5, 5, 25, "pihten ponaŋ kareŋap", Country.Solea, false));
        dLeagueTeams[7].addPlayer(new player(5, 1, 2, 6, 6, 7, 5, 5, 4, 6, 5, 9, 27, "Boltway Player #6", Country.Ethanthova, false));
        dLeagueTeams[7].addPlayer(new player(5, 5, 3, 3, 3, 7, 5, 5, 1, 7, 5, 6, 27, "Point Guard #137", Country.Holykol, false));
        dLeagueTeams[7].addPlayer(new player(4, 7, 3, 7, 7, 4, 4, 8, 1, 2, 5, 10, 25, "Nigel Harris", Country.Transhimalia, false));
        dLeagueTeams[7].addPlayer(new player(5, 1, 2, 3, 3, 4, 5, 6, 7, 8, 5, 9, 26, "LeBroccoli James", Country.Dotruga, false));
        dLeagueTeams[7].addPlayer(new player(3, 6, 7, 1, 1, 1, 5, 7, 4, 6, 5, 8, 27, "Small Forward #127", Country.Blaist_Blaland, false));
        dLeagueTeams[7].addPlayer(new player(1, 5, 7, 3, 4, 5, 4, 5, 7, 4, 3, 9, 22, "Kaliso Alolundi", Country.Dotruga, false));
        dLeagueTeams[7].addPlayer(new player(3, 8, 4, 1, 1, 2, 2, 3, 4, 10, 5, 9, 22, "Kibi Osamo", Country.Dotruga, false));
        dLeagueTeams[7].addPlayer(new player(1, 8, 5, 1, 1, 1, 2, 10, 6, 4, 5, 5, 27, "Lyintaria Player #13", Country.Lyintaria, false));
        dLeagueTeams[7].addPlayer(new player(4, 5, 1, 5, 5, 4, 2, 4, 1, 8, 5, 5, 23, "Issac Van Breda", Country.Pyxanovia, false));

        dLeagueTeams.Add(new team("Barsein Beggars", r));
        dLeagueTeams[8].addPlayer(new player(2, 7, 8, 7, 8, 5, 7, 4, 6, 9, 1, 6, 25, "Phetdum Somphonpadee", Country.Bielosia, false));
        dLeagueTeams[8].addPlayer(new player(5, 3, 3, 9, 9, 5, 8, 6, 2, 7, 5, 8, 25, "Namia Akaleta", Country.Aiyota, false));
        dLeagueTeams[8].addPlayer(new player(1, 6, 10, 1, 1, 1, 9, 8, 5, 3, 5, 8, 27, "Center #101", Country.Darvincia, false));
        dLeagueTeams[8].addPlayer(new player(2, 8, 5, 3, 3, 1, 6, 5, 7, 7, 5, 9, 27, "Aiyota Player #4", Country.Aiyota, false));
        dLeagueTeams[8].addPlayer(new player(4, 7, 2, 6, 6, 7, 5, 2, 1, 5, 5, 9, 23, "Kudapa Zaxnax", Country.Aeridani, false));
        dLeagueTeams[8].addPlayer(new player(3, 8, 7, 5, 5, 10, 1, 2, 2, 10, 5, 7, 27, "Red Rainbow Player #8", Country.Red_Rainbow, false));
        dLeagueTeams[8].addPlayer(new player(2, 4, 6, 6, 6, 5, 2, 4, 6, 7, 5, 10, 27, "Lyintaria Player #7", Country.Lyintaria, false));
        dLeagueTeams[8].addPlayer(new player(4, 9, 2, 8, 7, 1, 5, 6, 4, 4, 3, 8, 24, "Kai Soulignavong", Country.Pyxanovia, false));
        dLeagueTeams[8].addPlayer(new player(1, 10, 7, 1, 1, 1, 2, 4, 8, 4, 5, 5, 26, "Klopar Pobro", Country.Blaist_Blaland, false));
        dLeagueTeams[8].addPlayer(new player(4, 3, 1, 8, 8, 6, 8, 7, 3, 3, 5, 5, 27, "Holy Yektonesia Player #5", Country.Holy_Yektonisa, false));
        dLeagueTeams[8].addPlayer(new player(3, 4, 5, 4, 4, 7, 6, 7, 3, 3, 5, 5, 27, "Small Forward #137", Country.Holykol, false));
        dLeagueTeams[8].addPlayer(new player(1, 7, 6, 1, 1, 4, 8, 2, 6, 5, 5, 9, 27, "Height Sagua Player #7", Country.Height_Sagua, false));
        dLeagueTeams[8].addPlayer(new player(3, 3, 6, 4, 4, 1, 7, 6, 3, 3, 5, 7, 27, "Small Forward #102", Country.Bielosia, false));
        dLeagueTeams[8].addPlayer(new player(5, 2, 4, 4, 4, 5, 7, 3, 3, 6, 5, 8, 27, "Point Guard #47", Country.Blaist_Blaland, false));
        dLeagueTeams[8].addPlayer(new player(5, 6, 2, 5, 5, 5, 5, 4, 2, 4, 5, 8, 23, "kaf", Country.Czalliso, false));

        dLeagueTeams.Add(new team("Ma-Popá Yiffs", r));
        dLeagueTeams[9].addPlayer(new player(3, 10, 4, 1, 1, 8, 8, 9, 1, 5, 5, 7, 24, "Blaxanon Bonits", Country.Blaist_Blaland, false));
        dLeagueTeams[9].addPlayer(new player(1, 8, 7, 1, 1, 3, 10, 3, 8, 6, 5, 5, 27, "Qili Kedi", Country.Auspikitan, false));
        dLeagueTeams[9].addPlayer(new player(2, 8, 2, 1, 1, 4, 2, 7, 8, 7, 5, 10, 26, "Alomale Atutralei", Country.Dotruga, false));
        dLeagueTeams[9].addPlayer(new player(1, 5, 8, 2, 2, 4, 6, 8, 6, 5, 5, 5, 27, "Center #106", Country.Dtersauuw_Sagua, false));
        dLeagueTeams[9].addPlayer(new player(4, 1, 1, 10, 10, 1, 4, 3, 3, 10, 5, 9, 24, "Harver Borelli", Country.Sagua, false));
        dLeagueTeams[9].addPlayer(new player(2, 9, 5, 6, 6, 1, 9, 2, 6, 4, 5, 5, 27, "Transhilmalia Player #13", Country.Transhimalia, false));
        dLeagueTeams[9].addPlayer(new player(3, 1, 2, 6, 6, 2, 10, 2, 9, 6, 5, 10, 27, "Autolik Player #10", Country.Blaist_Blaland, false));
        dLeagueTeams[9].addPlayer(new player(5, 1, 3, 9, 9, 6, 8, 3, 4, 5, 5, 5, 26, "Xigasiei Atusin", Country.Dotruga, false));
        dLeagueTeams[9].addPlayer(new player(5, 1, 4, 7, 7, 8, 6, 4, 3, 4, 5, 6, 27, "Lyintaria Player #5", Country.Lyintaria, false));
        dLeagueTeams[9].addPlayer(new player(2, 5, 7, 5, 5, 6, 7, 3, 5, 3, 5, 8, 27, "Power Forward #106", Country.Transhimalia, false));
        dLeagueTeams[9].addPlayer(new player(3, 7, 6, 6, 6, 2, 3, 3, 5, 7, 5, 7, 27, "Small Forward #160", Country.Solea, false));
        dLeagueTeams[9].addPlayer(new player(5, 5, 3, 4, 4, 7, 4, 6, 1, 3, 5, 10, 24, "Tsekon Lek'at", Country.Dtersauuw_Sagua, false));
        dLeagueTeams[9].addPlayer(new player(1, 9, 6, 3, 3, 1, 7, 6, 5, 2, 5, 5, 27, "Red Rainbow Player #12", Country.Red_Rainbow, false));
        dLeagueTeams[9].addPlayer(new player(4, 5, 2, 5, 5, 7, 6, 5, 1, 4, 5, 5, 23, "Porlolitro Omelopet", Country.Sagua, false));
        dLeagueTeams[9].addPlayer(new player(4, 2, 1, 10, 10, 5, 7, 3, 4, 2, 5, 6, 25, "Abi Gasbërr", Country.Blaist_Blaland, false));

        dLeagueTeams.Add(new team("Protopolis Progs", r));
        dLeagueTeams[10].addPlayer(new player(4, 6, 2, 7, 7, 6, 7, 3, 4, 10, 5, 5, 22, "Veno Kibiget", Country.Dotruga, false));
        dLeagueTeams[10].addPlayer(new player(4, 8, 9, 6, 6, 4, 7, 2, 1, 9, 5, 5, 23, "Fihano Fem", Country.Barsein, false));
        dLeagueTeams[10].addPlayer(new player(4, 5, 3, 6, 6, 8, 5, 5, 4, 7, 5, 6, 24, "Kibibei Alodosulomundi", Country.Height_Sagua, false));
        dLeagueTeams[10].addPlayer(new player(5, 7, 7, 4, 4, 7, 5, 5, 7, 5, 5, 9, 24, "Kamil Harris", Country.Ethanthova, false));
        dLeagueTeams[10].addPlayer(new player(2, 6, 6, 6, 7, 6, 7, 4, 6, 6, 6, 10, 25, "Ogino Kunimichi", Country.Aeridani, false));
        dLeagueTeams[10].addPlayer(new player(2, 8, 4, 6, 6, 1, 6, 2, 6, 7, 5, 6, 25, "son", Country.Czalliso, false));
        dLeagueTeams[10].addPlayer(new player(2, 7, 8, 3, 3, 6, 2, 5, 3, 8, 7, 5, 23, "Mónhin Słanák", Country.Sagua, false));
        dLeagueTeams[10].addPlayer(new player(3, 3, 1, 7, 7, 7, 6, 2, 10, 6, 5, 5, 27, "Small Forward #54", Country.Blaist_Blaland, false));
        dLeagueTeams[10].addPlayer(new player(5, 2, 1, 5, 6, 8, 6, 6, 5, 6, 5, 5, 24, "Keon Saysamongdy", Country.Key_to_Don, false));
        dLeagueTeams[10].addPlayer(new player(3, 1, 3, 10, 10, 1, 6, 1, 2, 9, 5, 5, 27, "Bongatar Player #13", Country.Bongatar, false));
        dLeagueTeams[10].addPlayer(new player(3, 4, 6, 6, 6, 4, 5, 7, 5, 1, 5, 8, 27, "Small Forward #110", Country.Red_Rainbow, false));
        dLeagueTeams[10].addPlayer(new player(5, 3, 1, 8, 8, 6, 8, 7, 3, 3, 5, 5, 25, "Zaxox Pasovya", Country.Blaist_Blaland, false));
        dLeagueTeams[10].addPlayer(new player(1, 7, 9, 1, 1, 5, 6, 4, 6, 2, 5, 5, 22, "Seamso Horribus", Country.Bielosia, false));
        dLeagueTeams[10].addPlayer(new player(1, 5, 3, 2, 2, 1, 7, 6, 7, 6, 5, 6, 27, "Center #107", Country.Auspikitan, false));
        dLeagueTeams[10].addPlayer(new player(1, 7, 6, 7, 7, 1, 3, 3, 7, 5, 5, 6, 27, "Center #115", Country.Ethanthova, false));

        dLeagueTeams.Add(new team("Holylmao Bison", r));
        dLeagueTeams[11].addPlayer(new player(1, 7, 9, 1, 1, 1, 6, 9, 8, 7, 10, 9, 25, "Hexar Mann", Country.Bongatar, false));
        dLeagueTeams[11].addPlayer(new player(5, 1, 4, 9, 9, 6, 8, 5, 3, 5, 5, 10, 27, "Height Sagua Player #2", Country.Height_Sagua, false));
        dLeagueTeams[11].addPlayer(new player(3, 6, 7, 3, 3, 4, 7, 5, 6, 9, 5, 6, 26, "Munglegarra", Country.Solea, false));
        dLeagueTeams[11].addPlayer(new player(3, 7, 5, 7, 7, 6, 6, 6, 3, 4, 5, 7, 27, "Small Forward #161", Country.Czalliso, false));
        dLeagueTeams[11].addPlayer(new player(1, 10, 6, 2, 2, 3, 1, 8, 8, 3, 5, 5, 23, "Sagobesei Alote", Country.Dotruga, false));
        dLeagueTeams[11].addPlayer(new player(4, 2, 4, 9, 9, 5, 5, 6, 1, 3, 5, 10, 26, "Tuk Kauqepei", Country.Auspikitan, false));
        dLeagueTeams[11].addPlayer(new player(1, 6, 6, 1, 1, 4, 5, 9, 9, 4, 5, 6, 25, "Zane Harris", Country.Ethanthova, false));
        dLeagueTeams[11].addPlayer(new player(5, 4, 2, 4, 4, 7, 5, 4, 4, 5, 5, 10, 27, "Point Guard #145", Country.Ethanthova, false));
        dLeagueTeams[11].addPlayer(new player(4, 3, 5, 6, 6, 3, 3, 6, 3, 8, 5, 7, 27, "Shooting Guard #138", Country.Red_Rainbow, false));
        dLeagueTeams[11].addPlayer(new player(3, 9, 5, 2, 2, 3, 10, 1, 8, 1, 5, 5, 27, "Small Forward #80", Country.Aahrus, false));
        dLeagueTeams[11].addPlayer(new player(4, 4, 2, 9, 9, 6, 6, 1, 1, 5, 5, 5, 27, "Aiyota Player #12", Country.Aiyota, false));
        dLeagueTeams[11].addPlayer(new player(5, 4, 3, 3, 3, 5, 8, 6, 4, 5, 5, 8, 27, "Red Rainbow Player #9", Country.Red_Rainbow, false));
        dLeagueTeams[11].addPlayer(new player(2, 7, 1, 3, 3, 6, 6, 7, 3, 3, 5, 7, 27, "Power Forward #170", Country.Dotruga, false));
        dLeagueTeams[11].addPlayer(new player(2, 7, 3, 3, 3, 4, 5, 3, 8, 3, 5, 6, 27, "Sagua Player #12", Country.Sagua, false));
        dLeagueTeams[11].addPlayer(new player(2, 6, 3, 5, 5, 6, 4, 6, 3, 4, 5, 7, 27, "Power Forward #156", Country.Aahrus, false));

        dLeagueTeams.Add(new team("Aahrus Goosi", r));
        dLeagueTeams[12].addPlayer(new player(4, 6, 3, 6, 6, 4, 6, 6, 3, 8, 5, 10, 22, "Phetdum Phanivong", Country.Loviniosa, false));
        dLeagueTeams[12].addPlayer(new player(1, 9, 4, 1, 1, 3, 6, 8, 7, 6, 5, 5, 27, "Center #134", Country.Blaist_Blaland, false));
        dLeagueTeams[12].addPlayer(new player(1, 7, 4, 1, 1, 6, 8, 8, 7, 5, 5, 5, 27, "Center #166", Country.Pyxanovia, false));
        dLeagueTeams[12].addPlayer(new player(2, 9, 3, 5, 5, 3, 5, 3, 10, 4, 5, 7, 25, "Biplatza Bitsekzeba", Country.Auspikitan, false));
        dLeagueTeams[12].addPlayer(new player(3, 7, 1, 9, 8, 9, 2, 1, 5, 8, 7, 8, 21, "Ikaika Tayvihane", Country.Pyxanovia, false));
        dLeagueTeams[12].addPlayer(new player(3, 2, 5, 8, 8, 2, 1, 9, 7, 8, 5, 6, 24, "Takishima Natsuo", Country.Ethanthova, false));
        dLeagueTeams[12].addPlayer(new player(3, 8, 6, 5, 5, 4, 4, 10, 5, 2, 5, 5, 27, "Lyintaria Player #10", Country.Lyintaria, false));
        dLeagueTeams[12].addPlayer(new player(2, 4, 4, 5, 5, 1, 10, 6, 6, 7, 5, 9, 26, "Easy", Country.Darvincia, false));
        dLeagueTeams[12].addPlayer(new player(1, 4, 9, 2, 2, 2, 3, 8, 7, 3, 5, 5, 24, "yed", Country.Holykol, false));
        dLeagueTeams[12].addPlayer(new player(2, 8, 5, 1, 1, 1, 6, 4, 9, 4, 5, 6, 23, "Alolomobei Lokanbagibet", Country.Dotruga, false));
        dLeagueTeams[12].addPlayer(new player(4, 6, 1, 7, 7, 4, 2, 7, 4, 6, 5, 5, 27, "Shooting Guard #27", Country.Sagua, false));
        dLeagueTeams[12].addPlayer(new player(4, 3, 3, 5, 5, 6, 4, 2, 1, 9, 5, 5, 27, "Shooting Guard #99", Country.Ethanthova, false));
        dLeagueTeams[12].addPlayer(new player(5, 4, 3, 5, 5, 8, 6, 3, 3, 4, 5, 6, 27, "Point Guard #136", Country.Sagua, false));
        dLeagueTeams[12].addPlayer(new player(5, 6, 2, 4, 4, 5, 4, 6, 2, 6, 5, 5, 27, "Point Guard #19", Country.Shmupland, false));
        dLeagueTeams[12].addPlayer(new player(5, 5, 4, 4, 4, 6, 6, 4, 2, 5, 5, 6, 27, "Point Guard #131", Country.Aeridani, false));

        dLeagueTeams.Add(new team("Boston Beavers", r));
        dLeagueTeams[13].addPlayer(new player(2, 9, 4, 2, 2, 4, 10, 6, 9, 5, 5, 5, 24, "dot", Country.Holykol, false));
        dLeagueTeams[13].addPlayer(new player(5, 6, 7, 7, 6, 6, 4, 6, 3, 7, 4, 9, 26, "Alukeili Asolomundi", Country.Dotruga, false));
        dLeagueTeams[13].addPlayer(new player(3, 8, 4, 3, 3, 1, 5, 10, 10, 6, 5, 6, 27, "Sagua Player #8", Country.Sagua, false));
        dLeagueTeams[13].addPlayer(new player(3, 7, 5, 7, 7, 1, 5, 6, 6, 7, 5, 6, 27, "Small Forward #138", Country.Ethanthova, false));
        dLeagueTeams[13].addPlayer(new player(2, 9, 5, 2, 2, 2, 7, 7, 6, 5, 5, 5, 27, "Aahrus Player #8", Country.Aahrus, false));
        dLeagueTeams[13].addPlayer(new player(4, 5, 3, 6, 9, 6, 6, 7, 2, 6, 3, 6, 22, "Maik Siharath", Country.Holykol, false));
        dLeagueTeams[13].addPlayer(new player(5, 5, 3, 4, 4, 8, 3, 5, 3, 7, 5, 6, 27, "Point Guard #147", Country.Key_to_Don, false));
        dLeagueTeams[13].addPlayer(new player(1, 5, 6, 6, 6, 5, 9, 6, 5, 4, 5, 7, 27, "Center #132", Country.Sagua, false));
        dLeagueTeams[13].addPlayer(new player(4, 3, 2, 5, 5, 6, 4, 1, 2, 7, 5, 10, 27, "Sagua Player #11", Country.Sagua, false));
        dLeagueTeams[13].addPlayer(new player(4, 5, 2, 7, 7, 4, 5, 6, 6, 4, 5, 7, 27, "Shooting Guard #129", Country.Dotruga, false));
        dLeagueTeams[13].addPlayer(new player(1, 7, 9, 1, 1, 3, 3, 7, 8, 2, 5, 5, 24, "Trezent Rogu", Country.Aeridani, false));
        dLeagueTeams[13].addPlayer(new player(1, 4, 4, 2, 2, 5, 8, 10, 9, 2, 5, 6, 19, "Danombi Chejijar", Country.Dotruga, false));
        dLeagueTeams[13].addPlayer(new player(2, 3, 8, 4, 4, 3, 1, 6, 8, 3, 5, 5, 25, "Love", Country.Darvincia, false));
        dLeagueTeams[13].addPlayer(new player(5, 3, 2, 6, 6, 7, 4, 4, 3, 5, 5, 6, 26, "Lilo Viravongs", Country.Loviniosa, false));
        dLeagueTeams[13].addPlayer(new player(3, 3, 6, 6, 6, 4, 5, 5, 4, 2, 5, 8, 27, "Small Forward #158", Country.Tri_National_Dominion, false));

        dLeagueTeams.Add(new team("Rockshaw Rave", r));
        dLeagueTeams[14].addPlayer(new player(5, 5, 6, 7, 8, 4, 7, 7, 1, 10, 1, 8, 23, "Kolnu Kukroda", Country.Blaist_Blaland, false));
        dLeagueTeams[14].addPlayer(new player(4, 2, 3, 7, 7, 6, 6, 5, 1, 7, 5, 9, 26, "Pŋševa Ke'una", Country.Dtersauuw_Sagua, false));
        dLeagueTeams[14].addPlayer(new player(5, 4, 3, 3, 3, 8, 8, 6, 3, 6, 5, 10, 27, "Autolik Player #3", Country.Blaist_Blaland, false));
        dLeagueTeams[14].addPlayer(new player(1, 6, 8, 3, 3, 4, 6, 6, 6, 6, 5, 5, 27, "Barsein Player #11", Country.Barsein, false));
        dLeagueTeams[14].addPlayer(new player(3, 7, 3, 2, 2, 7, 5, 7, 8, 6, 5, 6, 25, "tikit' tiwan", Country.Aeridani, false));
        dLeagueTeams[14].addPlayer(new player(4, 2, 5, 8, 8, 4, 3, 3, 6, 7, 5, 8, 27, "Shooting Guard #157", Country.Blaist_Blaland, false));
        dLeagueTeams[14].addPlayer(new player(2, 6, 3, 5, 5, 6, 4, 6, 7, 5, 5, 6, 27, "Power Forward #125", Country.Bielosia, false));
        dLeagueTeams[14].addPlayer(new player(5, 4, 4, 4, 6, 10, 4, 7, 5, 4, 8, 6, 21, "Matthew Boyle", Country.Wyverncliff, false));
        dLeagueTeams[14].addPlayer(new player(3, 1, 2, 10, 10, 10, 3, 3, 2, 8, 5, 6, 27, "Bongatar Player #9", Country.Bongatar, false));
        dLeagueTeams[14].addPlayer(new player(3, 6, 7, 8, 8, 4, 4, 2, 5, 5, 5, 5, 27, "Small Forward #147", Country.Barsein, false));
        dLeagueTeams[14].addPlayer(new player(2, 5, 8, 3, 3, 2, 2, 4, 9, 4, 5, 7, 27, "Holy Yektonesia Player #10", Country.Holy_Yektonisa, false));
        dLeagueTeams[14].addPlayer(new player(2, 6, 2, 1, 1, 4, 7, 2, 9, 6, 5, 6, 27, "Barsein Player #10", Country.Barsein, false));
        dLeagueTeams[14].addPlayer(new player(1, 8, 7, 3, 3, 4, 4, 5, 7, 3, 5, 5, 25, "Sávákán Mipjódló", Country.Sagua, false));
        dLeagueTeams[14].addPlayer(new player(4, 1, 1, 8, 8, 4, 8, 3, 3, 3, 5, 9, 27, "Pxalit'k'a Player #12", Country.Dotruga, false));
        dLeagueTeams[14].addPlayer(new player(1, 5, 3, 2, 2, 2, 6, 4, 7, 7, 5, 6, 27, "Center #164", Country.Blaist_Blaland, false));

        dLeagueTeams.Add(new team("Autolik Rebels", r));
        dLeagueTeams[15].addPlayer(new player(4, 3, 1, 7, 7, 6, 7, 6, 4, 10, 5, 5, 23, "Big G", Country.Aeridani, false));
        dLeagueTeams[15].addPlayer(new player(2, 6, 7, 4, 5, 5, 8, 8, 7, 6, 6, 5, 23, "Wakayama Higashikuni", Country.Aeridani, false));
        dLeagueTeams[15].addPlayer(new player(1, 6, 10, 2, 2, 3, 4, 10, 7, 2, 5, 7, 22, "Kajiki Yoshitoshi", Country.Aeridani, false));
        dLeagueTeams[15].addPlayer(new player(5, 4, 4, 9, 9, 5, 8, 4, 3, 7, 5, 5, 27, "Sagua Player #6", Country.Sagua, false));
        dLeagueTeams[15].addPlayer(new player(2, 9, 6, 7, 7, 5, 8, 1, 1, 8, 5, 5, 22, "Pwot'e Lanakwi", Country.Oesa, false));
        dLeagueTeams[15].addPlayer(new player(4, 7, 1, 5, 5, 6, 10, 7, 4, 4, 5, 5, 24, "Jung-Hee Kim", Country.Aeridani, false));
        dLeagueTeams[15].addPlayer(new player(3, 4, 8, 3, 3, 1, 7, 8, 3, 4, 5, 5, 22, "Danosiei Vealerko", Country.Dotruga, false));
        dLeagueTeams[15].addPlayer(new player(5, 4, 4, 5, 5, 7, 4, 2, 4, 7, 5, 7, 27, "Point Guard #109", Country.Pyxanovia, false));
        dLeagueTeams[15].addPlayer(new player(2, 5, 7, 5, 5, 5, 4, 7, 6, 3, 5, 6, 27, "Power Forward #128", Country.Barsein, false));
        dLeagueTeams[15].addPlayer(new player(4, 7, 2, 6, 6, 7, 5, 2, 1, 5, 5, 5, 27, "Autolik Player #8", Country.Blaist_Blaland, false));
        dLeagueTeams[15].addPlayer(new player(3, 6, 7, 2, 2, 3, 7, 3, 4, 5, 5, 8, 27, "Small Forward #176", Country.Aeridani, false));
        dLeagueTeams[15].addPlayer(new player(5, 6, 2, 4, 4, 5, 4, 6, 2, 6, 5, 6, 24, "Nathaniel Roberts", Country.Pyxanovia, false));
        dLeagueTeams[15].addPlayer(new player(1, 7, 6, 1, 1, 5, 7, 8, 6, 2, 5, 6, 27, "Bro McBeth", Country.Red_Rainbow, false));
        dLeagueTeams[15].addPlayer(new player(3, 5, 6, 3, 3, 1, 7, 4, 5, 5, 5, 6, 27, "Small Forward #122", Country.Dotruga, false));
        dLeagueTeams[15].addPlayer(new player(1, 6, 8, 2, 2, 5, 1, 4, 5, 6, 5, 10, 20, "Bilingulbut", Country.Aiyota, false));

        dLeagueTeams.Add(new team("TND Force", r));
        dLeagueTeams[16].addPlayer(new player(3, 4, 10, 7, 7, 4, 4, 8, 3, 7, 5, 6, 25, "Pergo Elomosei", Country.Dotruga, false));
        dLeagueTeams[16].addPlayer(new player(4, 7, 2, 8, 8, 4, 5, 5, 2, 8, 5, 6, 25, "Hato Yoshifumi", Country.Solea, false));
        dLeagueTeams[16].addPlayer(new player(3, 5, 7, 6, 6, 6, 7, 3, 6, 7, 5, 6, 24, "Hiroshima Shusui", Country.Transhimalia, false));
        dLeagueTeams[16].addPlayer(new player(3, 9, 5, 6, 6, 6, 4, 2, 8, 7, 5, 6, 27, "Holy Yektonesia Player #7", Country.Holy_Yektonisa, false));
        dLeagueTeams[16].addPlayer(new player(2, 7, 6, 2, 2, 3, 8, 5, 6, 7, 5, 8, 27, "Barsein Player #3", Country.Barsein, false));
        dLeagueTeams[16].addPlayer(new player(1, 10, 5, 3, 3, 1, 3, 7, 8, 2, 5, 5, 27, "mus", Country.Holykol, false));
        dLeagueTeams[16].addPlayer(new player(1, 7, 5, 2, 2, 5, 9, 1, 6, 6, 5, 8, 22, "Joon-Ho Jo", Country.Shmupland, false));
        dLeagueTeams[16].addPlayer(new player(5, 5, 3, 3, 3, 8, 6, 8, 1, 5, 5, 6, 19, "Berend Herschlag", Country.Tri_National_Dominion, false));
        dLeagueTeams[16].addPlayer(new player(2, 7, 2, 1, 1, 4, 4, 5, 7, 5, 5, 10, 27, "Sagua Player #7", Country.Sagua, false));
        dLeagueTeams[16].addPlayer(new player(2, 4, 5, 5, 5, 4, 3, 7, 9, 5, 5, 5, 27, "Red Rainbow Player #10", Country.Red_Rainbow, false));
        dLeagueTeams[16].addPlayer(new player(5, 3, 2, 7, 7, 4, 7, 3, 4, 5, 5, 9, 27, "Autolik Player #9", Country.Blaist_Blaland, false));
        dLeagueTeams[16].addPlayer(new player(1, 8, 7, 1, 1, 1, 2, 5, 8, 5, 5, 10, 27, "Ethanthova Player #6", Country.Ethanthova, false));
        dLeagueTeams[16].addPlayer(new player(5, 5, 2, 5, 5, 7, 3, 6, 3, 5, 5, 5, 27, "Point Guard #111", Country.Aeridani, false));
        dLeagueTeams[16].addPlayer(new player(4, 8, 4, 6, 5, 1, 6, 7, 4, 4, 1, 6, 24, "Afalna Osamos", Country.Aeridani, false));
        dLeagueTeams[16].addPlayer(new player(4, 3, 5, 5, 5, 5, 4, 1, 2, 7, 5, 5, 27, "Shooting Guard #128", Country.Ethanthova, false));

        dLeagueTeams.Add(new team("Bielosia Ghosts", r));
        dLeagueTeams[17].addPlayer(new player(3, 6, 7, 7, 8, 8, 8, 5, 0, 7, 6, 6, 23, "Eric Gilroy", Country.Ethanthova, false));
        dLeagueTeams[17].addPlayer(new player(2, 8, 9, 4, 3, 5, 6, 4, 6, 6, 7, 9, 26, "Atumiba Tetrisei", Country.Dotruga, false));
        dLeagueTeams[17].addPlayer(new player(4, 3, 3, 6, 6, 6, 7, 7, 2, 6, 7, 9, 22, "Dylan Rooney", Country.Key_to_Don, false));
        dLeagueTeams[17].addPlayer(new player(3, 1, 10, 6, 6, 7, 1, 6, 5, 7, 5, 5, 27, "Blanaxon Player #11", Country.Blaist_Blaland, false));
        dLeagueTeams[17].addPlayer(new player(2, 9, 4, 6, 6, 5, 7, 2, 6, 4, 5, 5, 26, "Keiqioi Auemei", Country.Auspikitan, false));
        dLeagueTeams[17].addPlayer(new player(4, 2, 1, 10, 10, 5, 5, 3, 2, 7, 5, 7, 27, "Bongatar Player #4", Country.Holy_Yektonisa, false));
        dLeagueTeams[17].addPlayer(new player(2, 7, 6, 4, 4, 2, 3, 7, 8, 4, 5, 9, 27, "Pxalit'k'a Player #4", Country.Dtersauuw_Sagua, false));
        dLeagueTeams[17].addPlayer(new player(3, 7, 5, 3, 3, 4, 4, 4, 1, 10, 5, 5, 27, "Sagua Player #13", Country.Sagua, false));
        dLeagueTeams[17].addPlayer(new player(4, 4, 2, 8, 8, 1, 4, 6, 5, 7, 5, 8, 27, "Shooting Guard #151", Country.Holy_Yektonisa, false));
        dLeagueTeams[17].addPlayer(new player(5, 3, 4, 4, 4, 6, 6, 4, 1, 5, 5, 10, 24, "First Last", Country.Wyverncliff, false));
        dLeagueTeams[17].addPlayer(new player(5, 2, 3, 9, 9, 4, 5, 5, 4, 6, 5, 5, 27, "Aahrus Player #9", Country.Aahrus, false));
        dLeagueTeams[17].addPlayer(new player(1, 5, 8, 2, 2, 1, 6, 5, 5, 6, 5, 5, 27, "TND Player #13", Country.Tri_National_Dominion, false));
        dLeagueTeams[17].addPlayer(new player(5, 5, 2, 4, 4, 6, 4, 2, 4, 5, 5, 9, 27, "Point Guard #157", Country.Aeridani, false));
        dLeagueTeams[17].addPlayer(new player(1, 6, 6, 3, 3, 5, 7, 5, 6, 4, 5, 7, 27, "Pyxanovia Player #9", Country.Pyxanovia, false));
        dLeagueTeams[17].addPlayer(new player(1, 7, 3, 3, 3, 2, 8, 5, 7, 1, 5, 6, 27, "Center #117", Country.Pyxanovia, false));

        dLeagueTeams.Add(new team("Hinaika Hurricanes", r));
        dLeagueTeams[18].addPlayer(new player(4, 5, 3, 9, 8, 7, 7, 6, 1, 6, 7, 6, 19, "Alomibamobei Olalomundi", Country.Dotruga, false));
        dLeagueTeams[18].addPlayer(new player(3, 4, 6, 5, 5, 6, 9, 10, 3, 4, 5, 5, 22, "Kimball Chavarría", Country.Wyverncliff, false));
        dLeagueTeams[18].addPlayer(new player(4, 4, 5, 7, 9, 5, 8, 5, 1, 8, 5, 5, 19, "Saiki Udo", Country.Wyverncliff, false));
        dLeagueTeams[18].addPlayer(new player(3, 5, 3, 8, 7, 2, 7, 5, 8, 6, 1, 7, 24, "Till Seidel", Country.Tri_National_Dominion, false));
        dLeagueTeams[18].addPlayer(new player(4, 9, 4, 6, 7, 1, 4, 5, 2, 8, 9, 8, 24, "Noxku Pasovya", Country.Wyverncliff, false));
        dLeagueTeams[18].addPlayer(new player(3, 5, 6, 5, 5, 7, 5, 6, 7, 4, 5, 8, 27, "Small Forward #159", Country.Aiyota, false));
        dLeagueTeams[18].addPlayer(new player(5, 1, 3, 7, 7, 6, 6, 6, 2, 6, 5, 7, 23, "Hoeki Ulepa", Country.Oesa, false));
        dLeagueTeams[18].addPlayer(new player(5, 1, 4, 4, 4, 7, 5, 4, 1, 7, 5, 7, 27, "Boltway Player #7", Country.Ethanthova, false));
        dLeagueTeams[18].addPlayer(new player(1, 6, 7, 1, 1, 2, 4, 6, 7, 7, 10, 6, 21, "Detlef Tischbein", Country.Tri_National_Dominion, false));
        dLeagueTeams[18].addPlayer(new player(2, 6, 3, 4, 4, 5, 4, 7, 6, 4, 5, 8, 27, "Power Forward #108", Country.Height_Sagua, false));
        dLeagueTeams[18].addPlayer(new player(2, 7, 3, 1, 1, 1, 1, 7, 8, 6, 5, 8, 27, "Height Sagua Player #10", Country.Height_Sagua, false));
        dLeagueTeams[18].addPlayer(new player(1, 5, 8, 2, 2, 1, 6, 5, 5, 6, 5, 5, 25, "Kuronuma Gihei", Country.Wyverncliff, false));
        dLeagueTeams[18].addPlayer(new player(5, 3, 4, 4, 4, 6, 6, 4, 1, 5, 5, 8, 24, "Günther Schuttler", Country.Tri_National_Dominion, false));
        dLeagueTeams[18].addPlayer(new player(2, 7, 6, 5, 5, 3, 4, 6, 4, 3, 5, 8, 27, "Power Forward #114", Country.Darvincia, false));
        dLeagueTeams[18].addPlayer(new player(1, 5, 5, 5, 5, 4, 3, 2, 10, 5, 5, 6, 27, "laluk títhep ulapaš", Country.Solea, false));

        dLeagueTeams.Add(new team("Daxanad Soldiers", r));
        dLeagueTeams[19].addPlayer(new player(2, 9, 4, 1, 1, 3, 6, 7, 8, 8, 5, 5, 24, "Young Layup", Country.Aeridani, false));
        
        dLeagueTeams[19].addPlayer(new player(1, 6, 10, 2, 2, 3, 8, 3, 7, 3, 5, 6, 23, "Nho'ja Kámh", Country.Darvincia, false));
        dLeagueTeams[19].addPlayer(new player(1, 10, 6, 2, 2, 3, 4, 6, 5, 6, 5, 5, 27, "Aahrus Player #6", Country.Aahrus, false));
        dLeagueTeams[19].addPlayer(new player(5, 10, 3, 10, 10, 4, 1, 1, 1, 7, 5, 5, 22, "Iora Dani", Country.Aeridani, false));
        dLeagueTeams[19].addPlayer(new player(5, 1, 1, 9, 9, 8, 4, 3, 2, 7, 5, 6, 25, "app", Country.Czalliso, false));
        dLeagueTeams[19].addPlayer(new player(2, 8, 4, 3, 3, 6, 5, 2, 8, 4, 5, 7, 23, "Zax Zaxnax", Country.Pyxanovia, false));
        dLeagueTeams[19].addPlayer(new player(5, 6, 3, 5, 5, 7, 5, 2, 1, 6, 5, 7, 27, "Point Guard #150", Country.Aahrus, false));
        dLeagueTeams[19].addPlayer(new player(4, 5, 5, 6, 6, 5, 4, 5, 5, 6, 5, 7, 27, "Shooting Guard #103", Country.Bielosia, false));
        dLeagueTeams[19].addPlayer(new player(2, 6, 3, 3, 3, 2, 9, 1, 8, 7, 5, 7, 23, "Dominic Murtagh", Country.Ethanthova, false));
        dLeagueTeams[19].addPlayer(new player(3, 3, 7, 5, 5, 5, 3, 6, 4, 4, 5, 7, 27, "Small Forward #141", Country.Red_Rainbow, false));
        dLeagueTeams[19].addPlayer(new player(4, 1, 2, 9, 9, 4, 6, 5, 1, 3, 5, 9, 26, "Litsaw Lek'at", Country.Ethanthova, false));
        dLeagueTeams[19].addPlayer(new player(3, 6, 6, 3, 3, 7, 7, 4, 7, 1, 5, 7, 27, "Small Forward #145", Country.Aeridani, false));
        dLeagueTeams[19].addPlayer(new player(4, 5, 3, 5, 5, 6, 8, 2, 3, 5, 5, 5, 22, "Inla Kabatau", Country.Shmupland, false));
        dLeagueTeams[19].addPlayer(new player(3, 4, 6, 3, 3, 7, 2, 3, 7, 8, 5, 5, 27, "Small Forward #23", Country.Blaist_Blaland, false));
        dLeagueTeams[19].addPlayer(new player(5, 6, 4, 8, 8, 5, 5, 5, 3, 7, 5, 10, 27, "Barsein Player #2", Country.Barsein, false));

        dLeagueTeams.Add(new team("Kutapi Redwoods", r));
        dLeagueTeams[20].addPlayer(new player(3, 7, 2, 4, 4, 7, 8, 5, 4, 9, 5, 5, 27, "Height Sagua Player #9", Country.Height_Sagua, false));
        dLeagueTeams[20].addPlayer(new player(4, 2, 1, 10, 10, 5, 5, 8, 2, 7, 5, 7, 27, "Lyintaria Player #6", Country.Aeridani, false));
        dLeagueTeams[20].addPlayer(new player(1, 8, 5, 3, 3, 2, 5, 5, 8, 6, 5, 8, 27, "Barsein Player #4", Country.Barsein, false));
        dLeagueTeams[20].addPlayer(new player(3, 8, 4, 5, 5, 3, 4, 6, 7, 8, 5, 6, 23, "Till Hutto", Country.Tri_National_Dominion, false));
        dLeagueTeams[20].addPlayer(new player(4, 4, 3, 5, 5, 4, 9, 3, 2, 7, 5, 9, 24, "Jumpe", Country.Solea, false));
        dLeagueTeams[20].addPlayer(new player(4, 4, 2, 10, 10, 5, 3, 6, 3, 7, 5, 5, 27, "Key To Don Player #7", Country.Blaist_Blaland, false));
        dLeagueTeams[20].addPlayer(new player(3, 8, 7, 2, 2, 4, 2, 7, 1, 10, 5, 7, 25, "Devison Elker", Country.Bielosia, false));
        dLeagueTeams[20].addPlayer(new player(1, 4, 6, 4, 4, 4, 4, 8, 7, 6, 5, 6, 27, "King", Country.Darvincia, false));
        dLeagueTeams[20].addPlayer(new player(2, 7, 7, 3, 3, 5, 9, 1, 6, 6, 5, 5, 27, "Holy Yektonesia Player #8", Country.Holy_Yektonisa, false));
        dLeagueTeams[20].addPlayer(new player(5, 6, 4, 4, 4, 6, 5, 5, 1, 6, 5, 6, 25, "Sovka Danarko", Country.Blaist_Blaland, false));
        dLeagueTeams[20].addPlayer(new player(5, 3, 4, 5, 5, 5, 5, 7, 1, 4, 5, 10, 27, "Aiyota Player #7", Country.Aiyota, false));
        dLeagueTeams[20].addPlayer(new player(5, 6, 1, 6, 6, 10, 5, 4, 2, 5, 5, 5, 25, "lípek kŋkvúg ipaŋuk", Country.Solea, false));
        dLeagueTeams[20].addPlayer(new player(1, 4, 6, 1, 1, 2, 5, 7, 7, 6, 5, 5, 24, "Carsten Fein", Country.Tri_National_Dominion, false));
        dLeagueTeams[20].addPlayer(new player(2, 6, 6, 3, 3, 4, 4, 3, 8, 4, 5, 10, 27, "Barsein Player #6", Country.Barsein, false));
        dLeagueTeams[20].addPlayer(new player(2, 6, 7, 4, 4, 1, 2, 2, 6, 7, 5, 8, 27, "Bongatar Player #8", Country.Bongatar, false));

        dLeagueTeams.Add(new team("Lyintaria Kool Kats", r));
        dLeagueTeams[21].addPlayer(new player(4, 8, 3, 7, 7, 5, 3, 6, 4, 8, 5, 7, 22, "Alukeili Himadosadetsei", Country.Lyintaria, false));
        dLeagueTeams[21].addPlayer(new player(3, 5, 2, 8, 8, 6, 6, 6, 5, 8, 5, 8, 23, "Swanano Nonhkwaqan", Country.Key_to_Don, false));
        dLeagueTeams[21].addPlayer(new player(2, 9, 8, 4, 4, 3, 3, 9, 7, 4, 5, 7, 22, "Tansov Liksov", Country.Blaist_Blaland, false));
        dLeagueTeams[21].addPlayer(new player(4, 10, 5, 8, 8, 3, 4, 5, 4, 4, 7, 9, 25, "Biplatza Tituqu", Country.Ethanthova, false));
        dLeagueTeams[21].addPlayer(new player(3, 6, 3, 5, 5, 2, 5, 7, 7, 7, 5, 7, 27, "Small Forward #133", Country.Auspikitan, false));
        dLeagueTeams[21].addPlayer(new player(5, 2, 4, 9, 9, 9, 4, 3, 4, 5, 5, 5, 23, "Sagotru Vealerko", Country.Dotruga, false));
        dLeagueTeams[21].addPlayer(new player(3, 7, 5, 3, 3, 4, 6, 7, 7, 4, 5, 5, 27, "Small Forward #167", Country.Solea, false));
        dLeagueTeams[21].addPlayer(new player(4, 8, 4, 8, 9, 2, 5, 7, 2, 6, 1, 5, 23, "Śonpennneŕgomà Qe", Country.Auspikitan, false));
        dLeagueTeams[21].addPlayer(new player(5, 1, 2, 5, 5, 8, 7, 3, 4, 6, 5, 6, 26, "kom", Country.Holykol, false));
        dLeagueTeams[21].addPlayer(new player(5, 7, 4, 9, 9, 5, 3, 3, 2, 5, 5, 5, 24, "Kibisei Olamos", Country.Dotruga, false));
        dLeagueTeams[21].addPlayer(new player(2, 6, 4, 1, 1, 2, 6, 7, 7, 6, 5, 5, 24, "si", Country.Holykol, false));
        dLeagueTeams[21].addPlayer(new player(1, 7, 3, 1, 1, 1, 10, 6, 6, 3, 5, 7, 27, "Center #128", Country.Shmupland, false));
        dLeagueTeams[21].addPlayer(new player(1, 3, 6, 3, 3, 4, 5, 6, 7, 5, 5, 5, 27, "Center #138", Country.Blaist_Blaland, false));
        dLeagueTeams[21].addPlayer(new player(2, 3, 5, 3, 3, 2, 7, 2, 8, 6, 5, 10, 24, "kiríl lutnej pitikeš", Country.Solea, false));
        dLeagueTeams[21].addPlayer(new player(1, 6, 9, 2, 2, 4, 5, 1, 6, 3, 5, 5, 22, "Yondoora", Country.Transhimalia, false));

        dLeagueTeams.Add(new team("Aovensiiv Atoms", r));
        dLeagueTeams[22].addPlayer(new player(1, 4, 9, 2, 2, 2, 10, 8, 6, 6, 5, 5, 27, "Dwab Itsok", Country.Aeridani, false));
        dLeagueTeams[22].addPlayer(new player(1, 10, 1, 5, 5, 3, 7, 6, 8, 2, 5, 7, 27, "Pyxanovia Player #8", Country.Pyxanovia, false));
        dLeagueTeams[22].addPlayer(new player(2, 7, 10, 3, 3, 3, 6, 4, 5, 6, 5, 8, 26, "Wilbert Fudge", Country.Ethanthova, false));
        dLeagueTeams[22].addPlayer(new player(3, 7, 7, 2, 2, 4, 6, 9, 6, 7, 5, 6, 25, "Uxku Sovix", Country.Blaist_Blaland, false));
        dLeagueTeams[22].addPlayer(new player(3, 7, 5, 1, 1, 7, 6, 7, 4, 6, 5, 8, 27, "Small Forward #104", Country.Blaist_Blaland, false));
        dLeagueTeams[22].addPlayer(new player(1, 10, 6, 1, 1, 4, 2, 5, 8, 3, 5, 9, 24, "fal", Country.Czalliso, false));
        dLeagueTeams[22].addPlayer(new player(3, 5, 7, 4, 4, 3, 5, 5, 4, 6, 5, 9, 24, "Greg Kershaw", Country.Ethanthova, false));
        dLeagueTeams[22].addPlayer(new player(4, 5, 1, 5, 5, 4, 2, 4, 1, 8, 5, 10, 23, "Kolpa Hjetohje", Country.Blaist_Blaland, false));
        dLeagueTeams[22].addPlayer(new player(2, 7, 8, 3, 2, 3, 4, 7, 7, 3, 1, 5, 21, "Kaliso Osadolsei", Country.Dotruga, false));
        dLeagueTeams[22].addPlayer(new player(5, 4, 4, 3, 3, 8, 4, 5, 2, 6, 5, 7, 27, "Point Guard #141", Country.Lyintaria, false));
        dLeagueTeams[22].addPlayer(new player(5, 3, 2, 3, 3, 8, 3, 3, 2, 6, 5, 9, 27, "Point Guard #112", Country.Barsein, false));
        dLeagueTeams[22].addPlayer(new player(5, 4, 2, 8, 8, 5, 3, 5, 3, 5, 5, 7, 23, "Danombi Kexek", Country.Dotruga, false));
        dLeagueTeams[22].addPlayer(new player(2, 5, 7, 5, 5, 6, 5, 6, 1, 4, 5, 8, 27, "Power Forward #109", Country.Aiyota, false));
        dLeagueTeams[22].addPlayer(new player(4, 5, 4, 6, 6, 5, 4, 3, 4, 5, 5, 7, 27, "Shooting Guard #107", Country.Dotruga, false));
        dLeagueTeams[22].addPlayer(new player(4, 5, 5, 6, 6, 3, 4, 6, 3, 5, 5, 6, 27, "Shooting Guard #160", Country.Dtersauuw_Sagua, false));

        dLeagueTeams.Add(new team("Suggionic Infantry", r));
        dLeagueTeams[23].addPlayer(new player(3, 2, 5, 10, 10, 4, 9, 3, 4, 8, 5, 5, 25, "pazek lutep kaghišek", Country.Solea, false));
        dLeagueTeams[23].addPlayer(new player(5, 4, 4, 7, 8, 7, 5, 8, 2, 9, 2, 6, 24, "Błá Váva", Country.Nausicaa, false));
        dLeagueTeams[23].addPlayer(new player(5, 1, 3, 8, 8, 7, 5, 8, 1, 6, 5, 8, 23, "Nio Oipa", Country.Auspikitan, false));
        dLeagueTeams[23].addPlayer(new player(5, 9, 1, 7, 7, 5, 1, 4, 5, 7, 5, 7, 27, "Height Sagua Player #11", Country.Height_Sagua, false));
        dLeagueTeams[23].addPlayer(new player(3, 2, 8, 5, 7, 6, 6, 8, 5, 1, 6, 7, 20, "Melebin Hidolundi", Country.Dotruga, false));
        dLeagueTeams[23].addPlayer(new player(1, 4, 8, 2, 2, 2, 10, 4, 7, 3, 5, 6, 20, "Lilo Inthisane", Country.Lyintaria, false));
        dLeagueTeams[23].addPlayer(new player(1, 4, 5, 1, 1, 1, 10, 7, 7, 6, 5, 7, 27, "Center #135", Country.Transhimalia, false));
        dLeagueTeams[23].addPlayer(new player(1, 5, 7, 5, 5, 3, 6, 2, 6, 7, 5, 8, 27, "Fahrenfall Player #10", Country.Aeridani, false));
        dLeagueTeams[23].addPlayer(new player(2, 7, 6, 5, 5, 6, 3, 2, 7, 5, 5, 8, 22, "Amari Yakumo", Country.Aeridani, false));
        dLeagueTeams[23].addPlayer(new player(4, 6, 1, 6, 6, 7, 4, 4, 4, 5, 5, 5, 27, "Pyxanovia Player #10", Country.Pyxanovia, false));
        dLeagueTeams[23].addPlayer(new player(3, 5, 4, 7, 7, 4, 3, 6, 4, 5, 5, 7, 27, "Small Forward #148", Country.Ethanthova, false));
        dLeagueTeams[23].addPlayer(new player(4, 7, 1, 9, 9, 7, 1, 3, 1, 4, 5, 5, 24, "Woganure", Country.Wyverncliff, false));
        dLeagueTeams[23].addPlayer(new player(4, 1, 2, 7, 7, 6, 8, 5, 1, 4, 5, 6, 27, "Barsein Player #9", Country.Bongatar, false));
        dLeagueTeams[23].addPlayer(new player(2, 7, 6, 5, 5, 6, 2, 4, 6, 3, 5, 8, 27, "Power Forward #174", Country.Holykol, false));
        dLeagueTeams[23].addPlayer(new player(2, 6, 7, 4, 4, 1, 2, 2, 6, 7, 5, 8, 27, "Bongatar Player #8", Country.Bongatar, false));

        dLeagueTeams.Add(new team("Yuofuan Jaguars", r));
        dLeagueTeams[24].addPlayer(new player(5, 7, 1, 6, 4, 10, 5, 4, 8, 6, 6, 7, 25, "Danobamobesa Alulomundi", Country.Dotruga, false));
        dLeagueTeams[24].addPlayer(new player(2, 8, 4, 6, 6, 2, 7, 7, 6, 7, 5, 5, 26, "Itausŋaŋufi Utipŋiqe", Country.Auspikitan, false));
        dLeagueTeams[24].addPlayer(new player(4, 6, 9, 6, 5, 5, 4, 6, 2, 4, 5, 10, 24, "Hato Senelile", Country.Bongatar, false));
        dLeagueTeams[24].addPlayer(new player(2, 7, 4, 7, 7, 4, 7, 6, 7, 5, 5, 6, 27, "Power Forward #131", Country.Tri_National_Dominion, false));
        dLeagueTeams[24].addPlayer(new player(3, 10, 3, 5, 5, 7, 7, 3, 1, 3, 5, 5, 27, "Holy Yektonesia Player #11", Country.Holy_Yektonisa, false));
        dLeagueTeams[24].addPlayer(new player(2, 6, 4, 3, 3, 5, 8, 4, 7, 7, 5, 5, 26, "Tesine Falei", Country.Oesa, false));
        dLeagueTeams[24].addPlayer(new player(3, 7, 4, 6, 6, 6, 7, 4, 7, 1, 5, 7, 27, "Small Forward #139", Country.Darvincia, false));
        dLeagueTeams[24].addPlayer(new player(4, 1, 1, 5, 5, 6, 9, 2, 2, 7, 5, 9, 24, "kol", Country.Auspikitan, false));
        dLeagueTeams[24].addPlayer(new player(3, 1, 9, 1, 1, 3, 9, 4, 6, 2, 5, 5, 27, "Small Forward #7", Country.Wyverncliff, false));
        dLeagueTeams[24].addPlayer(new player(4, 4, 1, 9, 9, 4, 2, 2, 4, 6, 5, 8, 23, "Guooka", Country.Dotruga, false));
        dLeagueTeams[24].addPlayer(new player(1, 8, 9, 2, 2, 5, 3, 1, 6, 6, 5, 7, 23, "Ijba Gibuni", Country.Dotruga, false));
        dLeagueTeams[24].addPlayer(new player(5, 5, 3, 7, 7, 4, 7, 6, 2, 4, 5, 7, 23, "Asser Samter", Country.Blaist_Blaland, false));
        dLeagueTeams[24].addPlayer(new player(1, 7, 7, 5, 5, 4, 5, 5, 7, 3, 5, 5, 22, "Kimo Keobounphanh", Country.Bielosia, false));
        dLeagueTeams[24].addPlayer(new player(5, 4, 1, 8, 8, 7, 5, 2, 2, 3, 5, 7, 27, "Point Guard #158", Country.Auspikitan, false));
        dLeagueTeams[24].addPlayer(new player(1, 5, 9, 3, 3, 5, 5, 3, 5, 2, 5, 6, 21, "Mornay", Country.Blaist_Blaland, false));

        dLeagueTeams.Add(new team("Shmupland Tyrants", r));
        dLeagueTeams[25].addPlayer(new player(1, 8, 2, 5, 5, 1, 10, 3, 9, 6, 5, 5, 27, "kalassak vekel álutep", Country.Solea, false));
        dLeagueTeams[25].addPlayer(new player(3, 6, 8, 8, 7, 6, 7, 7, 0, 5, 5, 6, 23, "Sagolna Hersa", Country.Dotruga, false));
        dLeagueTeams[25].addPlayer(new player(5, 4, 4, 7, 7, 7, 1, 5, 4, 7, 5, 10, 22, "Sovlik Naxki", Country.Blaist_Blaland, false));
        dLeagueTeams[25].addPlayer(new player(4, 6, 5, 8, 9, 5, 4, 5, 1, 7, 4, 7, 20, "áz pavútekaš", Country.Oesa, false));
        dLeagueTeams[25].addPlayer(new player(2, 8, 5, 6, 6, 2, 6, 3, 6, 7, 5, 5, 27, "Transhilmalia Player #8", Country.Transhimalia, false));
        dLeagueTeams[25].addPlayer(new player(2, 6, 1, 4, 4, 6, 5, 7, 7, 5, 5, 6, 27, "Power Forward #111", Country.Czalliso, false));
        dLeagueTeams[25].addPlayer(new player(1, 6, 6, 3, 3, 5, 5, 8, 7, 5, 5, 8, 27, "Jote Ávura", Country.Aeridani, false));
        dLeagueTeams[25].addPlayer(new player(4, 3, 2, 9, 9, 4, 1, 6, 1, 10, 5, 5, 25, "Halsten Jöran", Country.Ethanthova, false));
        dLeagueTeams[25].addPlayer(new player(1, 6, 8, 3, 3, 1, 9, 3, 7, 2, 5, 9, 25, "Mabebesa Imbiedopei", Country.Dotruga, false));
        dLeagueTeams[25].addPlayer(new player(3, 5, 3, 7, 7, 3, 5, 4, 3, 6, 5, 7, 27, "Small Forward #151", Country.Bongatar, false));
        dLeagueTeams[25].addPlayer(new player(3, 5, 4, 1, 1, 3, 7, 6, 5, 5, 5, 8, 27, "Small Forward #119", Country.Dotruga, false));
        dLeagueTeams[25].addPlayer(new player(4, 6, 1, 7, 7, 4, 2, 7, 4, 6, 5, 5, 27, "Boltway Player #8", Country.Solea, false));
        dLeagueTeams[25].addPlayer(new player(2, 6, 6, 4, 4, 5, 7, 6, 3, 4, 5, 8, 27, "Power Forward #110", Country.Lyintaria, false));
        dLeagueTeams[25].addPlayer(new player(5, 4, 10, 1, 1, 5, 3, 2, 3, 7, 5, 5, 27, "Point Guard #161", Country.Dotruga, false));
        dLeagueTeams[25].addPlayer(new player(5, 4, 4, 2, 2, 7, 3, 5, 1, 6, 5, 8, 27, "Point Guard #114", Country.Height_Sagua, false));

        dLeagueTeams.Add(new team("Ebetxi Detro", r));
        dLeagueTeams[26].addPlayer(new player(4, 6, 3, 6, 8, 7, 6, 8, 3, 7, 4, 6, 21, "Amoda Kixidodotsei", Country.Dotruga, false));
        dLeagueTeams[26].addPlayer(new player(4, 5, 6, 6, 9, 5, 6, 7, 1, 9, 5, 5, 19, "Kibi Fevioka", Country.Ethanthova, false));
        dLeagueTeams[26].addPlayer(new player(1, 10, 8, 2, 2, 3, 8, 5, 6, 3, 5, 5, 27, "Autolik Player #5", Country.Blaist_Blaland, false));
        dLeagueTeams[26].addPlayer(new player(1, 9, 8, 1, 1, 5, 6, 6, 7, 3, 5, 8, 27, "Pruv'uorf the Extinguisher", Country.Transhimalia, false));
        dLeagueTeams[26].addPlayer(new player(2, 8, 5, 2, 2, 4, 6, 4, 8, 5, 5, 7, 25, "Teyvada Khouphongsy", Country.Loviniosa, false));
        dLeagueTeams[26].addPlayer(new player(3, 9, 7, 6, 6, 3, 8, 4, 1, 3, 5, 5, 27, "Boltway Player #5", Country.Ethanthova, false));
        dLeagueTeams[26].addPlayer(new player(3, 2, 2, 2, 2, 4, 8, 4, 8, 10, 5, 6, 22, "Belangana", Country.Pyxanovia, false));
        dLeagueTeams[26].addPlayer(new player(1, 4, 5, 3, 3, 5, 9, 5, 10, 2, 5, 7, 27, "Center #149", Country.Darvincia, false));
        dLeagueTeams[26].addPlayer(new player(3, 6, 3, 6, 6, 3, 6, 2, 5, 6, 5, 7, 27, "Small Forward #166", Country.Holy_Yektonisa, false));
        dLeagueTeams[26].addPlayer(new player(4, 3, 3, 6, 10, 7, 6, 5, 4, 6, 1, 5, 22, "Paxathipatai Sayasone", Country.Transhimalia, false));
        dLeagueTeams[26].addPlayer(new player(2, 8, 6, 1, 1, 1, 5, 5, 8, 3, 5, 9, 27, "Autolik Player #6", Country.Blaist_Blaland, false));
        dLeagueTeams[26].addPlayer(new player(2, 6, 6, 4, 4, 5, 6, 6, 5, 4, 5, 7, 27, "Power Forward #141", Country.Blaist_Blaland, false));
        dLeagueTeams[26].addPlayer(new player(5, 6, 3, 5, 5, 8, 4, 3, 2, 4, 5, 5, 27, "TND Player #11", Country.Tri_National_Dominion, false));
        dLeagueTeams[26].addPlayer(new player(5, 2, 1, 5, 5, 4, 8, 6, 3, 7, 5, 5, 26, "Keahi Bokeo", Country.Bielosia, false));
        dLeagueTeams[26].addPlayer(new player(5, 1, 3, 6, 6, 6, 5, 4, 1, 6, 5, 5, 27, "Bongatar Player #12", Country.Bongatar, false));

        dLeagueTeams.Add(new team("Errakyva Eruption", r));
        dLeagueTeams[27].addPlayer(new player(4, 5, 2, 8, 8, 4, 2, 8, 2, 8, 5, 9, 23, "Carlos Garber", Country.Dotruga, false));
        dLeagueTeams[27].addPlayer(new player(4, 5, 3, 7, 10, 6, 7, 8, 3, 7, 1, 5, 19, "Asser Stengel", Country.Tri_National_Dominion, false));
        dLeagueTeams[27].addPlayer(new player(3, 5, 7, 6, 6, 6, 7, 3, 6, 7, 5, 6, 26, "Hiroshima Shusui", Country.Transhimalia, false));
        dLeagueTeams[27].addPlayer(new player(1, 8, 9, 3, 3, 2, 8, 6, 8, 1, 5, 7, 27, "Dvinme Player #5", Country.Bielosia, false));
        dLeagueTeams[27].addPlayer(new player(3, 3, 2, 9, 9, 1, 2, 10, 6, 9, 5, 5, 26, "Kiro Sensoi", Country.Aeridani, false));
        dLeagueTeams[27].addPlayer(new player(3, 8, 1, 1, 1, 5, 5, 3, 10, 8, 5, 7, 26, "Pastek Tauaqa", Country.Auspikitan, false));
        dLeagueTeams[27].addPlayer(new player(4, 7, 3, 7, 7, 7, 5, 8, 1, 1, 5, 9, 27, "Pyxanovia Player #3", Country.Oesa, false));
        dLeagueTeams[27].addPlayer(new player(1, 6, 7, 3, 3, 2, 9, 8, 6, 3, 5, 5, 27, "Pxalit'k'a Player #10", Country.Dtersauuw_Sagua, false));
        dLeagueTeams[27].addPlayer(new player(2, 5, 6, 5, 5, 4, 4, 7, 6, 5, 5, 6, 27, "Power Forward #150", Country.Dtersauuw_Sagua, false));
        dLeagueTeams[27].addPlayer(new player(5, 2, 3, 5, 5, 8, 4, 4, 1, 6, 5, 7, 27, "Lyintaria Player #9", Country.Lyintaria, false));
        dLeagueTeams[27].addPlayer(new player(1, 7, 6, 1, 1, 4, 6, 10, 5, 4, 5, 6, 27, "Blanaxon Player #8", Country.Blaist_Blaland, false));
        dLeagueTeams[27].addPlayer(new player(5, 1, 2, 9, 9, 6, 4, 3, 3, 6, 5, 5, 27, "Aiyota Player #13", Country.Aiyota, false));
        dLeagueTeams[27].addPlayer(new player(2, 7, 6, 3, 3, 3, 7, 2, 6, 5, 5, 7, 27, "Power Forward #116", Country.Ethanthova, false));
        dLeagueTeams[27].addPlayer(new player(2, 3, 6, 2, 2, 5, 2, 4, 9, 4, 5, 10, 22, "Noxar Blagda", Country.Blaist_Blaland, false));
        dLeagueTeams[27].addPlayer(new player(5, 1, 3, 4, 4, 5, 4, 3, 2, 6, 5, 10, 24, "Midger", Country.Blaist_Blaland, false));

        dLeagueTeams.Add(new team("Detroit Pumps", r));
        dLeagueTeams[28].addPlayer(new player(2, 7, 9, 4, 5, 4, 6, 7, 7, 5, 9, 9, 25, "Keanu Thammavong", Country.Pyxanovia, false));
        dLeagueTeams[28].addPlayer(new player(4, 3, 2, 9, 9, 7, 2, 4, 4, 7, 5, 9, 27, "Pxalit'k'a Player #8", Country.Lyintaria, false));
        dLeagueTeams[28].addPlayer(new player(2, 8, 2, 4, 4, 5, 7, 4, 8, 6, 5, 5, 22, "Irinei Tailor", Country.Wyverncliff, false));
        dLeagueTeams[28].addPlayer(new player(1, 7, 5, 4, 4, 2, 1, 8, 10, 3, 5, 8, 23, "Sael Yen", Country.Aeridani, false));
        dLeagueTeams[28].addPlayer(new player(3, 4, 8, 5, 5, 6, 7, 2, 5, 4, 5, 8, 25, "Hoeki Pakana", Country.Hinaika, false));
        dLeagueTeams[28].addPlayer(new player(2, 5, 7, 5, 5, 4, 5, 6, 8, 3, 5, 9, 26, "Kudapa Naix", Country.Blaist_Blaland, false));
        dLeagueTeams[28].addPlayer(new player(3, 2, 2, 2, 2, 4, 8, 4, 8, 10, 5, 6, 26, "Pota Taumoti", Country.Auspikitan, false));
        dLeagueTeams[28].addPlayer(new player(3, 7, 5, 3, 3, 4, 4, 4, 1, 10, 5, 5, 27, "Small Forward #26", Country.Bielosia, false));
        dLeagueTeams[28].addPlayer(new player(4, 1, 2, 8, 8, 6, 1, 3, 1, 9, 5, 6, 27, "Fahrenfall Player #12", Country.Aahrus, false));
        dLeagueTeams[28].addPlayer(new player(4, 4, 2, 8, 8, 7, 4, 8, 2, 1, 5, 9, 23, "Dalmylphoe the Devourer", Country.Transhimalia, false));
        dLeagueTeams[28].addPlayer(new player(5, 2, 4, 4, 4, 5, 7, 3, 3, 6, 5, 8, 26, "yeb", Country.Czalliso, false));
        dLeagueTeams[28].addPlayer(new player(5, 1, 2, 9, 9, 6, 4, 3, 3, 6, 5, 5, 27, "Point Guard #93", Country.Darvincia, false));
        dLeagueTeams[28].addPlayer(new player(1, 5, 3, 2, 2, 2, 6, 8, 6, 7, 5, 5, 27, "Center #131", Country.Holykol, false));
        dLeagueTeams[28].addPlayer(new player(1, 8, 6, 2, 2, 3, 4, 9, 7, 1, 5, 5, 24, "dyo", Country.Holykol, false));
        dLeagueTeams[28].addPlayer(new player(1, 4, 7, 3, 3, 3, 1, 10, 8, 2, 5, 5, 23, "Asser Klostermann", Country.Tri_National_Dominion, false));

        dLeagueTeams.Add(new team("Red-Rainbow Reds", r));
        dLeagueTeams[29].addPlayer(new player(4, 7, 5, 9, 8, 5, 3, 5, 2, 5, 6, 10, 23, "Heine Umlauf", Country.Dotruga, false));
        dLeagueTeams[29].addPlayer(new player(2, 8, 4, 3, 3, 1, 7, 7, 9, 7, 5, 5, 27, "TND Player #7", Country.Tri_National_Dominion, false));
        dLeagueTeams[29].addPlayer(new player(5, 6, 5, 5, 5, 8, 3, 5, 3, 7, 5, 7, 26, "Fletcher Templeton", Country.Ethanthova, false));
        dLeagueTeams[29].addPlayer(new player(3, 7, 7, 6, 7, 5, 8, 5, 0, 6, 6, 7, 26, "Teyvada Vongsamphanh", Country.Bielosia, false));
        dLeagueTeams[29].addPlayer(new player(4, 7, 1, 9, 9, 7, 1, 3, 1, 4, 5, 9, 27, "TND Player #6", Country.Tri_National_Dominion, false));
        dLeagueTeams[29].addPlayer(new player(3, 7, 8, 5, 6, 5, 6, 4, 5, 5, 7, 5, 26, "Noxku Kibla", Country.Blaist_Blaland, false));
        dLeagueTeams[29].addPlayer(new player(2, 9, 8, 2, 2, 3, 1, 6, 8, 3, 5, 9, 27, "Aahrus Player #3", Country.Aahrus, false));
        dLeagueTeams[29].addPlayer(new player(3, 4, 6, 6, 6, 5, 4, 5, 1, 6, 5, 10, 23, "Ni'áqŕópłá Nánpa", Country.Nausicaa, false));
        dLeagueTeams[29].addPlayer(new player(4, 3, 3, 2, 2, 7, 8, 9, 3, 3, 5, 10, 27, "Shooting Guard #106", Country.Bongatar, false));
        dLeagueTeams[29].addPlayer(new player(5, 1, 4, 4, 4, 6, 7, 4, 1, 6, 5, 8, 22, "Pari Tanou", Country.Oesa, false));
        dLeagueTeams[29].addPlayer(new player(5, 4, 3, 7, 7, 5, 6, 7, 2, 5, 5, 5, 27, "Barsein Player #8", Country.Barsein, false));
        dLeagueTeams[29].addPlayer(new player(2, 8, 4, 2, 2, 1, 3, 7, 6, 5, 5, 5, 23, "Darren Santiago", Country.Wyverncliff, false));
        dLeagueTeams[29].addPlayer(new player(1, 7, 5, 2, 2, 4, 3, 7, 10, 1, 5, 5, 27, "Center #152", Country.Aeridani, false));
        dLeagueTeams[29].addPlayer(new player(1, 10, 5, 3, 3, 1, 3, 2, 7, 2, 5, 9, 19, "Hana Ieritou", Country.Oesa, false));
        dLeagueTeams[29].addPlayer(new player(1, 8, 7, 4, 4, 3, 3, 7, 5, 3, 5, 7, 19, "Asser Gradl", Country.Tri_National_Dominion, false));

        dLeagueTeams.Add(new team("Shigua Boots", r));
        dLeagueTeams[30].addPlayer(new player(2, 6, 4, 5, 6, 8, 9, 5, 8, 7, 4, 5, 26, "Phetdum Phanivong", Country.Bielosia, false));
        dLeagueTeams[30].addPlayer(new player(5, 4, 5, 8, 8, 4, 7, 5, 1, 9, 1, 9, 24, "Lae Thepsenavong", Country.Lyintaria, false));
        dLeagueTeams[30].addPlayer(new player(5, 4, 3, 8, 7, 7, 7, 5, 3, 6, 9, 6, 20, "Ingo Nesselrode", Country.Tri_National_Dominion, false));
        dLeagueTeams[30].addPlayer(new player(4, 8, 5, 8, 7, 2, 3, 5, 4, 6, 9, 10, 26, "Malo Thammavong", Country.Transhimalia, false));
        dLeagueTeams[30].addPlayer(new player(1, 9, 5, 2, 2, 5, 10, 1, 7, 2, 5, 6, 27, "Barsein Player #5", Country.Barsein, false));
        dLeagueTeams[30].addPlayer(new player(2, 9, 6, 3, 3, 5, 5, 5, 6, 4, 5, 5, 27, "Holy Yektonesia Player #9", Country.Holy_Yektonisa, false));
        dLeagueTeams[30].addPlayer(new player(2, 5, 2, 6, 6, 5, 10, 1, 7, 6, 5, 8, 24, "George", Country.Darvincia, false));
        dLeagueTeams[30].addPlayer(new player(5, 1, 3, 4, 4, 7, 8, 7, 1, 6, 5, 7, 27, "Key To Don Player #6", Country.Key_to_Don, false));
        dLeagueTeams[30].addPlayer(new player(4, 4, 3, 6, 6, 5, 5, 4, 3, 8, 5, 5, 27, "Ethanthova Player #12", Country.Height_Sagua, false));
        dLeagueTeams[30].addPlayer(new player(1, 8, 7, 1, 1, 5, 4, 2, 7, 6, 5, 7, 27, "Boltway Player #4", Country.Ethanthova, false));
        dLeagueTeams[30].addPlayer(new player(1, 8, 7, 1, 1, 6, 3, 8, 6, 4, 5, 5, 24, "Tamatsuki Eikichi", Country.Aeridani, false));
        dLeagueTeams[30].addPlayer(new player(3, 3, 4, 2, 1, 6, 8, 5, 9, 2, 10, 8, 21, "Meka Phoutthasinh", Country.Lyintaria, false));
        dLeagueTeams[30].addPlayer(new player(3, 2, 4, 6, 6, 5, 2, 10, 8, 3, 5, 5, 27, "Small Forward #29", Country.Aiyota, false));
        dLeagueTeams[30].addPlayer(new player(4, 5, 1, 7, 7, 7, 1, 8, 3, 1, 5, 9, 24, "Auqloa Nudun", Country.Transhimalia, false));
        dLeagueTeams[30].addPlayer(new player(3, 5, 5, 5, 5, 3, 3, 5, 6, 7, 5, 5, 27, "Small Forward #172", Country.Wyverncliff, false));

        dLeagueTeams.Add(new team("Holy Yektonisa Hmongs", r));
        dLeagueTeams[31].addPlayer(new player(2, 6, 5, 4, 3, 8, 7, 5, 7, 7, 4, 10, 24, "E'àǵay Nnoncàśénreskèc", Country.Barsein, false));
        dLeagueTeams[31].addPlayer(new player(4, 3, 2, 6, 6, 6, 6, 8, 1, 10, 5, 5, 22, "Ametsuchi Kamlyn", Country.Barsein, false));
        dLeagueTeams[31].addPlayer(new player(1, 4, 6, 4, 1, 2, 7, 9, 9, 4, 5, 6, 19, "Alve Sanraku", Country.Barsein, false));
        dLeagueTeams[31].addPlayer(new player(3, 1, 2, 10, 7, 7, 6, 7, 4, 6, 1, 10, 19, "Guooka", Country.Aiyota, false));
        dLeagueTeams[31].addPlayer(new player(1, 4, 6, 3, 3, 2, 9, 7, 10, 2, 5, 5, 27, "Center #141", Country.Aiyota, false));
        dLeagueTeams[31].addPlayer(new player(2, 8, 5, 5, 5, 4, 4, 6, 6, 4, 5, 8, 27, "Power Forward #161", Country.Tri_National_Dominion, false));
        dLeagueTeams[31].addPlayer(new player(3, 2, 8, 5, 5, 3, 4, 7, 7, 2, 5, 10, 27, "Pxalit'k'a Player #11", Country.Dtersauuw_Sagua, false));
        dLeagueTeams[31].addPlayer(new player(5, 1, 3, 4, 4, 7, 8, 7, 1, 6, 5, 7, 26, "Quartermarra", Country.Aiyota, false));
        dLeagueTeams[31].addPlayer(new player(1, 9, 7, 2, 2, 3, 3, 4, 9, 2, 5, 7, 25, "Tsekon Wap't'ebw", Country.Sagua, false));
        dLeagueTeams[31].addPlayer(new player(3, 8, 8, 2, 2, 7, 2, 5, 6, 7, 5, 6, 27, "Pxalit'k'a Player #9", Country.Dtersauuw_Sagua, false));
        dLeagueTeams[31].addPlayer(new player(2, 4, 5, 3, 3, 3, 7, 6, 8, 5, 5, 6, 22, "Masaki Taki", Country.Aeridani, false));
        dLeagueTeams[31].addPlayer(new player(5, 4, 2, 4, 4, 5, 1, 3, 7, 7, 5, 10, 24, "Lilo Savang", Country.Bielosia, false));
        dLeagueTeams[31].addPlayer(new player(4, 4, 2, 8, 8, 5, 9, 4, 3, 3, 5, 5, 27, "Aahrus Player #7", Country.Aeridani, false));
        dLeagueTeams[31].addPlayer(new player(5, 3, 4, 3, 3, 6, 4, 5, 1, 6, 5, 8, 27, "Point Guard #103", Country.Bongatar, false));
        dLeagueTeams[31].addPlayer(new player(4, 6, 2, 7, 7, 6, 2, 5, 3, 2, 5, 7, 27, "Ethanthova Player #9", Country.Bielosia, false));


        freeAgency.Add(new player(1, 9, 9, 3, 3, 5, 1, 6, 7, 1, 5, 5, 24, "Brian Moore", Country.Wyverncliff, false));
        freeAgency.Add(new player(1, 7, 5, 1, 1, 3, 3, 9, 6, 3, 5, 8, 27, "Key To Don Player #10", Country.Key_to_Don, false));
        freeAgency.Add(new player(1, 9, 8, 5, 5, 2, 2, 5, 5, 3, 5, 7, 21, "Hamish Rooney", Country.Aahrus, false));
        freeAgency.Add(new player(1, 6, 5, 1, 1, 5, 3, 9, 8, 2, 5, 6, 27, "luz", Country.Czalliso, false));
        freeAgency.Add(new player(1, 8, 8, 1, 1, 1, 6, 2, 7, 1, 5, 8, 27, "Sagua Player #10", Country.Sagua, false));
        freeAgency.Add(new player(1, 7, 6, 3, 3, 4, 4, 5, 4, 6, 5, 7, 27, "Center #143", Country.Dtersauuw_Sagua, false));
        freeAgency.Add(new player(1, 5, 6, 1, 1, 5, 6, 8, 6, 1, 5, 7, 24, "Jake Kirk", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(1, 5, 2, 4, 4, 1, 10, 9, 5, 1, 5, 8, 23, "Lani Savang", Country.Bielosia, false));
        freeAgency.Add(new player(1, 5, 3, 2, 2, 5, 10, 7, 6, 1, 5, 7, 27, "Center #154", Country.Bielosia, false));
        freeAgency.Add(new player(1, 6, 6, 1, 1, 1, 6, 5, 7, 1, 5, 9, 27, "Derek Denton", Country.Wyverncliff, false));
        freeAgency.Add(new player(1, 5, 6, 1, 1, 5, 6, 8, 6, 1, 5, 7, 27, "Dando Bebetxi", Country.Dotruga, false));
        freeAgency.Add(new player(1, 5, 6, 1, 1, 5, 6, 8, 6, 1, 5, 7, 27, "Autolik Player #12", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(1, 6, 6, 3, 3, 2, 6, 8, 7, 1, 5, 5, 24, "Henri Ulster", Country.Aeridani, false));
        freeAgency.Add(new player(1, 4, 5, 3, 3, 2, 1, 9, 6, 5, 5, 10, 24, "Su-Bin Lee", Country.Shmupland, false));
        freeAgency.Add(new player(1, 8, 8, 2, 2, 1, 3, 6, 6, 2, 5, 5, 24, "Bruce Robertson", Country.Wyverncliff, false));
        freeAgency.Add(new player(1, 6, 6, 3, 3, 2, 7, 1, 10, 1, 5, 5, 24, "Jasper Spivey", Country.Ethanthova, false));
        freeAgency.Add(new player(1, 6, 5, 3, 3, 5, 2, 5, 6, 7, 5, 6, 27, "Center #112", Country.Aahrus, false));
        freeAgency.Add(new player(1, 3, 4, 3, 3, 2, 9, 8, 7, 1, 5, 7, 27, "Center #151", Country.Tri_National_Dominion, false));
        freeAgency.Add(new player(1, 6, 6, 3, 3, 1, 2, 7, 7, 3, 5, 7, 27, "Center #153", Country.Sagua, false));
        freeAgency.Add(new player(1, 6, 5, 6, 6, 1, 10, 4, 4, 2, 5, 7, 27, "Center #157", Country.Darvincia, false));
        freeAgency.Add(new player(1, 6, 7, 3, 3, 1, 9, 5, 5, 1, 5, 6, 22, "aneŋo Ketwi", Country.Oesa, false));
        freeAgency.Add(new player(1, 5, 5, 1, 1, 4, 6, 6, 6, 2, 5, 9, 27, "Transhilmalia Player #14", Country.Transhimalia, false));
        freeAgency.Add(new player(1, 7, 6, 1, 1, 3, 4, 2, 6, 4, 5, 9, 27, "Height Sagua Player #12", Country.Height_Sagua, false));
        freeAgency.Add(new player(1, 6, 6, 7, 7, 3, 6, 6, 4, 3, 5, 5, 27, "Center #119", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(1, 6, 6, 1, 1, 3, 5, 5, 6, 5, 5, 5, 23, "Sol Chin-Ho", Country.Shmupland, false));
        freeAgency.Add(new player(1, 8, 3, 2, 2, 2, 1, 6, 5, 6, 5, 8, 23, "Ivor Wade", Country.Wyverncliff, false));
        freeAgency.Add(new player(1, 5, 5, 2, 2, 3, 6, 8, 6, 3, 5, 5, 27, "Center #145", Country.Aeridani, false));
        freeAgency.Add(new player(1, 6, 4, 1, 1, 2, 5, 4, 6, 7, 5, 6, 27, "Center #150", Country.Shmupland, false));
        freeAgency.Add(new player(1, 5, 6, 1, 1, 4, 4, 9, 6, 2, 5, 5, 26, "Ijba Himadosadetsei", Country.Czalliso, false));
        freeAgency.Add(new player(1, 7, 5, 2, 2, 4, 2, 6, 7, 1, 5, 7, 27, "Center #125", Country.Solea, false));
        freeAgency.Add(new player(1, 6, 4, 2, 2, 2, 8, 5, 6, 2, 5, 5, 27, "Center #104", Country.Auspikitan, false));
        freeAgency.Add(new player(1, 4, 5, 6, 6, 2, 9, 6, 3, 4, 5, 6, 21, "Center #162", Country.Bielosia, false));
        freeAgency.Add(new player(1, 5, 8, 1, 1, 2, 1, 5, 6, 5, 5, 6, 23, "Mazló Nánpa", Country.Aeridani, false));
        freeAgency.Add(new player(1, 5, 6, 1, 1, 5, 2, 9, 5, 3, 5, 5, 22, "Mhasłanok Qjodlonhámh", Country.Sagua, false));
        freeAgency.Add(new player(1, 4, 2, 2, 2, 5, 2, 8, 10, 1, 5, 6, 23, "Atomobei Dotrugo", Country.Dotruga, false));
        freeAgency.Add(new player(1, 5, 8, 1, 1, 2, 1, 6, 6, 5, 5, 5, 21, "Klanu Tanpratia", Country.Bongatar, false));
        freeAgency.Add(new player(1, 4, 4, 1, 1, 2, 7, 6, 3, 7, 5, 7, 22, "Center #105", Country.Wyverncliff, false));
        freeAgency.Add(new player(1, 7, 3, 2, 2, 4, 5, 3, 5, 4, 5, 7, 25, "Center #118", Country.Wyverncliff, false));
        freeAgency.Add(new player(2, 4, 5, 5, 5, 5, 7, 7, 2, 4, 5, 8, 27, "Power Forward #120", Country.Wyverncliff, false));
        freeAgency.Add(new player(2, 4, 4, 5, 5, 6, 4, 4, 7, 5, 5, 8, 27, "Power Forward #146", Country.Shmupland, false));
        freeAgency.Add(new player(2, 5, 5, 6, 6, 5, 1, 2, 8, 4, 5, 10, 25, "Kelii Sisoulith", Country.Loviniosa, false));
        freeAgency.Add(new player(2, 6, 5, 3, 3, 4, 8, 5, 7, 2, 5, 5, 26, "Aiuige Inekpid", Country.Auspikitan, false));
        freeAgency.Add(new player(2, 6, 6, 3, 3, 4, 1, 6, 7, 4, 5, 8, 27, "Power Forward #119", Country.Solea, false));
        freeAgency.Add(new player(2, 3, 3, 6, 6, 4, 7, 6, 7, 3, 5, 5, 27, "Power Forward #46", Country.Dotruga, false));
        freeAgency.Add(new player(2, 5, 6, 5, 5, 3, 7, 2, 5, 5, 5, 6, 27, "Power Forward #135", Country.Oesa, false));
        freeAgency.Add(new player(2, 7, 5, 5, 5, 5, 7, 1, 1, 5, 5, 8, 27, "Power Forward #139", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(2, 6, 6, 5, 5, 4, 3, 4, 6, 3, 5, 7, 27, "Power Forward #145", Country.Auspikitan, false));
        freeAgency.Add(new player(2, 4, 4, 5, 5, 4, 6, 7, 5, 3, 5, 6, 27, "Power Forward #157", Country.Sagua, false));
        freeAgency.Add(new player(2, 6, 7, 3, 3, 2, 9, 1, 6, 4, 5, 5, 27, "Pyxanovia Player #13", Country.Pyxanovia, false));
        freeAgency.Add(new player(2, 4, 3, 3, 3, 6, 7, 4, 5, 5, 5, 8, 27, "Power Forward #160", Country.Aahrus, false));
        freeAgency.Add(new player(2, 5, 5, 3, 3, 3, 3, 7, 6, 4, 5, 8, 27, "Power Forward #124", Country.Ethanthova, false));
        freeAgency.Add(new player(2, 3, 4, 4, 4, 2, 5, 6, 8, 6, 5, 5, 26, "Omeri Tetrisei", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(2, 6, 7, 3, 3, 6, 4, 4, 2, 3, 5, 8, 27, "Power Forward #101", Country.Aeridani, false));
        freeAgency.Add(new player(2, 6, 4, 4, 4, 4, 6, 6, 1, 5, 5, 7, 27, "Power Forward #149", Country.Red_Rainbow, false));
        freeAgency.Add(new player(2, 3, 4, 3, 3, 2, 6, 7, 7, 4, 5, 7, 25, "Zaxix Naxki", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(2, 5, 5, 4, 4, 2, 5, 2, 7, 7, 5, 5, 23, "Klabo Motxev", Country.Dotruga, false));
        freeAgency.Add(new player(2, 3, 5, 6, 6, 5, 1, 4, 9, 4, 5, 6, 25, "Vipoi Vuki", Country.Holy_Yektonisa, false));
        freeAgency.Add(new player(2, 5, 5, 5, 5, 3, 4, 3, 7, 3, 5, 7, 27, "Power Forward #118", Country.Height_Sagua, false));
        freeAgency.Add(new player(2, 6, 4, 4, 4, 6, 5, 3, 1, 5, 5, 8, 27, "Power Forward #122", Country.Dotruga, false));
        freeAgency.Add(new player(2, 6, 2, 3, 3, 6, 7, 2, 4, 4, 5, 8, 27, "Power Forward #168", Country.Bielosia, false));
        freeAgency.Add(new player(2, 6, 6, 1, 1, 4, 8, 1, 8, 3, 5, 5, 27, "Fahrenfall Player #9", Country.Aeridani, false));
        freeAgency.Add(new player(2, 6, 5, 4, 4, 5, 4, 2, 5, 5, 5, 6, 27, "Power Forward #107", Country.Dotruga, false));
        freeAgency.Add(new player(2, 7, 5, 4, 4, 1, 1, 1, 9, 3, 5, 10, 27, "TND Player #12", Country.Tri_National_Dominion, false));
        freeAgency.Add(new player(2, 4, 6, 1, 1, 1, 7, 6, 7, 3, 5, 6, 24, "Danonio Asetxi", Country.Aeridani, false));
        freeAgency.Add(new player(2, 6, 1, 5, 5, 6, 3, 3, 5, 4, 5, 8, 27, "Power Forward #153", Country.Auspikitan, false));
        freeAgency.Add(new player(2, 6, 3, 3, 3, 5, 7, 6, 1, 3, 5, 7, 27, "Power Forward #155", Country.Holykol, false));
        freeAgency.Add(new player(2, 7, 5, 1, 1, 1, 2, 3, 7, 7, 5, 7, 24, "Viktor Quentin", Country.Wyverncliff, false));
        freeAgency.Add(new player(2, 3, 2, 1, 1, 2, 8, 3, 8, 5, 5, 9, 24, "Ivo Bunschoten", Country.Tri_National_Dominion, false));
        freeAgency.Add(new player(2, 7, 5, 1, 1, 1, 2, 3, 7, 7, 5, 7, 26, "Dimitri Vuchko", Country.Wyverncliff, false));
        freeAgency.Add(new player(2, 4, 6, 1, 1, 1, 7, 6, 7, 3, 5, 6, 27, "Key To Don Player #13", Country.Key_to_Don, false));
        freeAgency.Add(new player(2, 3, 5, 7, 7, 1, 6, 4, 5, 3, 5, 7, 23, "Pañha Dakómh", Country.Sagua, false));
        freeAgency.Add(new player(2, 5, 2, 5, 5, 1, 5, 3, 9, 4, 5, 6, 23, "tǔnik napuh xapotív", Country.Solea, false));
        freeAgency.Add(new player(2, 6, 3, 1, 1, 5, 2, 5, 7, 6, 5, 5, 27, "Power Forward #2", Country.Shmupland, false));
        freeAgency.Add(new player(2, 4, 4, 5, 5, 5, 2, 2, 6, 3, 5, 10, 27, "Power Forward #95", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(2, 4, 5, 3, 3, 2, 1, 4, 7, 4, 5, 10, 26, "Bransby Jones", Country.Ethanthova, false));
        freeAgency.Add(new player(2, 5, 3, 6, 6, 2, 4, 2, 9, 3, 5, 5, 27, "Power Forward #15", Country.Aeridani, false));
        freeAgency.Add(new player(2, 5, 4, 4, 4, 1, 5, 2, 6, 7, 5, 5, 27, "Power Forward #79", Country.Auspikitan, false));
        freeAgency.Add(new player(2, 4, 2, 2, 2, 5, 2, 6, 9, 5, 5, 5, 27, "Power Forward #90", Country.Barsein, false));
        freeAgency.Add(new player(2, 3, 2, 5, 5, 5, 4, 5, 7, 4, 5, 5, 27, "Power Forward #92", Country.Bongatar, false));
        freeAgency.Add(new player(2, 5, 5, 5, 5, 2, 2, 3, 7, 5, 5, 5, 25, "Paxathipatai Vongsay", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(2, 4, 5, 5, 5, 4, 2, 2, 7, 4, 5, 7, 27, "Power Forward #103", Country.Czalliso, false));
        freeAgency.Add(new player(2, 4, 2, 5, 5, 6, 2, 6, 4, 4, 5, 7, 27, "Power Forward #104", Country.Key_to_Don, false));
        freeAgency.Add(new player(2, 4, 3, 5, 5, 4, 5, 4, 3, 4, 5, 8, 27, "Power Forward #127", Country.Dotruga, false));
        freeAgency.Add(new player(2, 6, 1, 3, 3, 6, 3, 5, 5, 5, 5, 6, 27, "Power Forward #132", Country.Transhimalia, false));
        freeAgency.Add(new player(2, 5, 1, 5, 5, 5, 4, 7, 5, 3, 5, 5, 27, "Power Forward #138", Country.Dtersauuw_Sagua, false));
        freeAgency.Add(new player(2, 6, 4, 5, 5, 3, 3, 2, 4, 4, 5, 8, 27, "Power Forward #159", Country.Pyxanovia, false));
        freeAgency.Add(new player(2, 5, 3, 5, 5, 6, 3, 1, 6, 5, 5, 6, 27, "Power Forward #173", Country.Oesa, false));
        freeAgency.Add(new player(2, 3, 5, 3, 3, 4, 3, 5, 6, 5, 5, 5, 27, "Power Forward #9", Country.Shmupland, false));
        freeAgency.Add(new player(2, 7, 2, 1, 1, 1, 4, 3, 7, 7, 5, 5, 27, "Power Forward #38", Country.Wyverncliff, false));
        freeAgency.Add(new player(2, 3, 4, 6, 6, 5, 3, 1, 9, 3, 5, 5, 27, "Power Forward #73", Country.Bongatar, false));
        freeAgency.Add(new player(2, 5, 2, 3, 3, 6, 2, 5, 7, 3, 5, 6, 27, "Power Forward #102", Country.Aiyota, false));
        freeAgency.Add(new player(2, 5, 3, 4, 4, 5, 3, 7, 3, 3, 5, 6, 27, "Power Forward #105", Country.Red_Rainbow, false));
        freeAgency.Add(new player(3, 10, 9, 1, 1, 4, 5, 5, 7, 1, 5, 5, 25, "elp", Country.Czalliso, false));
        freeAgency.Add(new player(3, 4, 4, 2, 2, 6, 7, 7, 7, 1, 5, 8, 27, "Small Forward #124", Country.Lyintaria, false));
        freeAgency.Add(new player(3, 5, 8, 6, 6, 8, 1, 6, 4, 1, 5, 7, 23, "Nupa Zaxau", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(3, 9, 6, 6, 6, 4, 1, 1, 7, 6, 5, 5, 27, "Autolik Player #11", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(3, 5, 7, 5, 5, 4, 3, 6, 7, 1, 5, 7, 27, "Small Forward #107", Country.Pyxanovia, false));
        freeAgency.Add(new player(3, 6, 6, 3, 3, 7, 3, 5, 6, 1, 5, 8, 27, "Small Forward #168", Country.Key_to_Don, false));
        freeAgency.Add(new player(3, 9, 7, 10, 10, 2, 3, 2, 6, 1, 5, 5, 26, "Alomundi Feber", Country.Height_Sagua, false));
        freeAgency.Add(new player(3, 7, 5, 1, 1, 7, 2, 1, 4, 9, 5, 9, 23, "Blaxia Zadabro", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(3, 6, 6, 3, 4, 3, 4, 6, 5, 4, 9, 8, 24, "Uemura Tomiji", Country.Barsein, false));
        freeAgency.Add(new player(3, 6, 5, 3, 3, 7, 2, 4, 6, 6, 5, 5, 27, "Small Forward #32", Country.Czalliso, false));
        freeAgency.Add(new player(3, 5, 6, 6, 6, 5, 4, 5, 6, 1, 5, 6, 27, "Small Forward #112", Country.Key_to_Don, false));
        freeAgency.Add(new player(3, 6, 7, 7, 7, 1, 2, 7, 4, 2, 5, 8, 27, "Small Forward #140", Country.Pyxanovia, false));
        freeAgency.Add(new player(3, 3, 7, 4, 4, 7, 3, 4, 5, 3, 5, 8, 27, "Small Forward #157", Country.Oesa, false));
        freeAgency.Add(new player(3, 5, 6, 2, 2, 3, 5, 3, 7, 5, 5, 8, 27, "Small Forward #178", Country.Barsein, false));
        freeAgency.Add(new player(3, 8, 8, 5, 5, 4, 3, 1, 3, 5, 5, 7, 24, "Iklo Hialerko", Country.Aeridani, false));
        freeAgency.Add(new player(3, 7, 5, 1, 1, 7, 2, 1, 4, 9, 5, 8, 24, "Onishi Masami", Country.Ethanthova, false));
        freeAgency.Add(new player(3, 7, 7, 2, 2, 2, 5, 6, 8, 1, 5, 5, 27, "Small Forward #29", Country.Aahrus, false));
        freeAgency.Add(new player(3, 2, 4, 5, 5, 10, 1, 2, 7, 6, 5, 6, 27, "Small Forward #37", Country.Aeridani, false));
        freeAgency.Add(new player(3, 4, 1, 2, 2, 8, 1, 8, 8, 2, 5, 9, 27, "Small Forward #78", Country.Auspikitan, false));
        freeAgency.Add(new player(3, 3, 5, 4, 4, 5, 3, 6, 6, 3, 5, 8, 27, "Small Forward #116", Country.Lyintaria, false));
        freeAgency.Add(new player(3, 4, 5, 2, 2, 6, 6, 4, 6, 4, 5, 6, 27, "Small Forward #121", Country.Holy_Yektonisa, false));
        freeAgency.Add(new player(3, 6, 6, 1, 1, 6, 5, 6, 5, 2, 5, 6, 27, "Small Forward #125", Country.Aeridani, false));
        freeAgency.Add(new player(3, 4, 7, 6, 6, 6, 4, 3, 6, 1, 5, 6, 27, "Small Forward #128", Country.Aeridani, false));
        freeAgency.Add(new player(3, 7, 5, 2, 2, 4, 4, 6, 7, 1, 5, 7, 27, "Small Forward #136", Country.Ethanthova, false));
        freeAgency.Add(new player(3, 6, 6, 8, 8, 4, 2, 2, 3, 6, 5, 6, 27, "Small Forward #164", Country.Height_Sagua, false));
        freeAgency.Add(new player(3, 3, 9, 1, 1, 7, 1, 4, 1, 7, 5, 9, 27, "Small Forward #71", Country.Dotruga, false));
        freeAgency.Add(new player(3, 7, 6, 6, 6, 5, 6, 3, 3, 1, 5, 5, 27, "Small Forward #113", Country.Transhimalia, false));
        freeAgency.Add(new player(3, 7, 5, 5, 5, 5, 3, 2, 3, 6, 5, 6, 27, "Small Forward #118", Country.Wyverncliff, false));
        freeAgency.Add(new player(3, 6, 4, 1, 1, 6, 7, 4, 5, 1, 5, 8, 27, "Small Forward #135", Country.Ethanthova, false));
        freeAgency.Add(new player(3, 4, 6, 4, 4, 3, 5, 4, 5, 4, 5, 7, 27, "Small Forward #146", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(3, 6, 6, 4, 4, 2, 7, 5, 3, 3, 5, 6, 27, "Small Forward #150", Country.Darvincia, false));
        freeAgency.Add(new player(3, 6, 7, 4, 4, 2, 4, 2, 5, 6, 5, 6, 27, "Small Forward #153", Country.Shmupland, false));
        freeAgency.Add(new player(3, 5, 4, 3, 3, 7, 5, 2, 4, 4, 5, 8, 27, "Small Forward #169", Country.Bielosia, false));
        freeAgency.Add(new player(3, 4, 6, 1, 1, 7, 4, 2, 5, 7, 5, 6, 27, "Small Forward #173", Country.Key_to_Don, false));
        freeAgency.Add(new player(3, 3, 9, 1, 1, 7, 1, 4, 1, 7, 5, 9, 27, "Red Rainbow Player #13", Country.Red_Rainbow, false));
        freeAgency.Add(new player(3, 6, 5, 6, 6, 5, 2, 1, 8, 4, 5, 5, 23, "Kimo Cheruene", Country.Transhimalia, false));
        freeAgency.Add(new player(3, 6, 1, 5, 6, 4, 6, 3, 6, 2, 2, 9, 21, "Hexar Jeem", Country.Bongatar, false));
        freeAgency.Add(new player(3, 3, 1, 2, 1, 9, 4, 3, 8, 6, 1, 6, 22, "Ulatrusiei Hiemeta", Country.Dotruga, false));
        freeAgency.Add(new player(3, 2, 9, 2, 2, 10, 2, 2, 8, 1, 5, 5, 27, "Small Forward #3", Country.Aahrus, false));
        freeAgency.Add(new player(3, 4, 7, 1, 1, 4, 7, 3, 6, 4, 5, 5, 27, "Small Forward #165", Country.Tri_National_Dominion, false));
        freeAgency.Add(new player(3, 4, 5, 7, 7, 4, 3, 3, 3, 6, 5, 6, 27, "Small Forward #171", Country.Holykol, false));
        freeAgency.Add(new player(3, 4, 6, 2, 2, 7, 7, 4, 4, 1, 5, 6, 27, "Small Forward #175", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(4, 7, 3, 7, 7, 4, 4, 8, 1, 2, 5, 5, 27, "Shooting Guard #21", Country.Aahrus, false));
        freeAgency.Add(new player(4, 3, 2, 2, 6, 6, 6, 7, 8, 5, 5, 5, 23, "Klaxanon Blaxon", Country.Oesa, false));
        freeAgency.Add(new player(4, 2, 3, 8, 8, 1, 3, 6, 5, 6, 5, 5, 27, "Shooting Guard #111", Country.Aahrus, false));
        freeAgency.Add(new player(4, 5, 5, 5, 5, 3, 5, 2, 4, 6, 5, 6, 27, "Shooting Guard #112", Country.Key_to_Don, false));
        freeAgency.Add(new player(4, 5, 5, 6, 6, 5, 2, 2, 6, 5, 5, 6, 27, "Shooting Guard #113", Country.Solea, false));
        freeAgency.Add(new player(4, 5, 4, 6, 6, 1, 5, 2, 3, 7, 5, 6, 27, "Shooting Guard #125", Country.Auspikitan, false));
        freeAgency.Add(new player(4, 4, 2, 8, 8, 5, 6, 4, 5, 1, 5, 6, 27, "Shooting Guard #161", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(4, 2, 1, 10, 10, 5, 7, 3, 4, 2, 5, 5, 27, "Key To Don Player #11", Country.Lyintaria, false));
        freeAgency.Add(new player(4, 3, 3, 8, 8, 7, 9, 3, 1, 1, 5, 5, 25, "Dog", Country.Aeridani, false));
        freeAgency.Add(new player(4, 1, 4, 9, 9, 5, 5, 8, 3, 1, 5, 5, 25, "Mike", Country.Key_to_Don, false));
        freeAgency.Add(new player(4, 6, 2, 7, 7, 6, 2, 5, 3, 2, 5, 7, 26, "Stephen McBob", Country.Czalliso, false));
        freeAgency.Add(new player(4, 7, 3, 6, 5, 1, 4, 7, 2, 4, 9, 6, 24, "Uwe Fein", Country.Tri_National_Dominion, false));
        freeAgency.Add(new player(4, 2, 2, 7, 7, 4, 1, 7, 4, 4, 5, 8, 27, "Shooting Guard #47", Country.Auspikitan, false));
        freeAgency.Add(new player(4, 1, 1, 8, 8, 5, 6, 8, 4, 1, 5, 5, 27, "Shooting Guard #94", Country.Lyintaria, false));
        freeAgency.Add(new player(4, 3, 1, 5, 5, 4, 4, 8, 2, 5, 5, 6, 25, "Pau Vevapi", Country.Barsein, false));
        freeAgency.Add(new player(4, 4, 3, 4, 4, 4, 5, 2, 5, 7, 5, 6, 27, "Shooting Guard #165", Country.Height_Sagua, false));
        freeAgency.Add(new player(4, 4, 2, 6, 6, 2, 1, 5, 5, 7, 5, 6, 27, "Shooting Guard #167", Country.Red_Rainbow, false));
        freeAgency.Add(new player(4, 7, 2, 9, 9, 4, 3, 1, 3, 3, 5, 6, 25, "First Last", Country.Ethanthova, false));
        freeAgency.Add(new player(4, 3, 3, 10, 10, 4, 1, 5, 1, 3, 5, 7, 23, "Lasina Opehi", Country.Bongatar, false));
        freeAgency.Add(new player(4, 3, 1, 5, 5, 4, 4, 8, 2, 5, 5, 5, 27, "Shooting Guard #8", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(4, 1, 2, 9, 9, 4, 6, 5, 1, 3, 5, 5, 27, "Shooting Guard #12", Country.Aeridani, false));
        freeAgency.Add(new player(4, 6, 2, 9, 9, 5, 4, 3, 3, 1, 5, 5, 27, "Shooting Guard #14", Country.Aiyota, false));
        freeAgency.Add(new player(4, 7, 2, 9, 9, 4, 3, 1, 3, 3, 5, 5, 26, "Carsten Tischbein", Country.Aahrus, false));
        freeAgency.Add(new player(4, 3, 3, 10, 10, 4, 1, 5, 1, 3, 5, 6, 26, "Kamil Fowler", Country.Wyverncliff, false));
        freeAgency.Add(new player(4, 6, 2, 9, 9, 5, 4, 3, 3, 1, 5, 5, 27, "Dvinme Player #10", Country.Dtersauuw_Sagua, false));
        freeAgency.Add(new player(4, 4, 4, 3, 3, 1, 4, 6, 2, 7, 5, 7, 27, "Shooting Guard #119", Country.Height_Sagua, false));
        freeAgency.Add(new player(4, 5, 3, 3, 3, 5, 1, 3, 4, 7, 5, 7, 27, "Shooting Guard #137", Country.Shmupland, false));
        freeAgency.Add(new player(4, 4, 2, 10, 10, 6, 3, 1, 1, 1, 5, 8, 24, "First Last", Country.Darvincia, false));
        freeAgency.Add(new player(4, 7, 2, 5, 5, 4, 2, 4, 3, 2, 5, 10, 27, "Red Rainbow Player #11", Country.Dotruga, false));
        freeAgency.Add(new player(4, 4, 1, 10, 10, 4, 3, 2, 3, 5, 5, 2, 26, "Iklo Morti", Country.Solea, false));
        freeAgency.Add(new player(4, 1, 1, 7, 7, 4, 4, 6, 1, 5, 5, 5, 27, "Shooting Guard #57", Country.Nausicaa, false));
        freeAgency.Add(new player(4, 1, 1, 5, 5, 7, 10, 4, 1, 2, 5, 5, 27, "Shooting Guard #89", Country.Tri_National_Dominion, false));
        freeAgency.Add(new player(4, 3, 4, 4, 4, 4, 5, 3, 3, 4, 5, 8, 27, "Shooting Guard #114", Country.Pyxanovia, false));
        freeAgency.Add(new player(4, 2, 2, 3, 3, 4, 4, 6, 3, 7, 5, 5, 27, "Shooting Guard #140", Country.Auspikitan, false));
        freeAgency.Add(new player(4, 3, 2, 6, 6, 4, 4, 3, 2, 5, 5, 5, 27, "Shooting Guard #49", Country.Barsein, false));
        freeAgency.Add(new player(4, 2, 3, 7, 7, 5, 3, 4, 4, 3, 5, 5, 27, "Shooting Guard #70", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(4, 1, 2, 5, 5, 4, 1, 5, 2, 6, 5, 8, 27, "Shooting Guard #75", Country.Height_Sagua, false));
        freeAgency.Add(new player(4, 5, 2, 5, 5, 1, 1, 5, 5, 6, 5, 6, 27, "Shooting Guard #108", Country.Holy_Yektonisa, false));
        freeAgency.Add(new player(4, 4, 4, 4, 4, 4, 1, 2, 2, 8, 5, 6, 27, "Shooting Guard #109", Country.Aiyota, false));
        freeAgency.Add(new player(4, 4, 4, 1, 3, 5, 3, 1, 2, 8, 5, 8, 27, "Shooting Guard #115", Country.Shmupland, false));
        freeAgency.Add(new player(4, 2, 3, 8, 8, 3, 3, 1, 5, 3, 5, 8, 27, "Shooting Guard #121", Country.Holykol, false));
        freeAgency.Add(new player(4, 4, 4, 2, 2, 3, 4, 6, 3, 5, 5, 7, 27, "Shooting Guard #131", Country.Lyintaria, false));
        freeAgency.Add(new player(4, 2, 4, 3, 3, 5, 2, 5, 5, 6, 5, 6, 27, "Shooting Guard #136", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(4, 4, 5, 4, 4, 5, 6, 3, 2, 3, 5, 6, 27, "Shooting Guard #162", Country.Ethanthova, false));
        freeAgency.Add(new player(4, 6, 1, 5, 5, 5, 6, 1, 2, 3, 5, 5, 27, "Shooting Guard #60", Country.Ethanthova, false));
        freeAgency.Add(new player(4, 5, 4, 4, 4, 4, 5, 2, 3, 2, 5, 8, 27, "Shooting Guard #110", Country.Red_Rainbow, false));
        freeAgency.Add(new player(4, 4, 2, 6, 6, 2, 1, 1, 4, 6, 5, 8, 27, "Shooting Guard #122", Country.Bielosia, false));
        freeAgency.Add(new player(4, 3, 4, 5, 5, 1, 1, 3, 2, 8, 5, 6, 27, "Shooting Guard #124", Country.Shmupland, false));
        freeAgency.Add(new player(5, 4, 3, 3, 3, 8, 8, 6, 3, 3, 5, 6, 24, "Bá Noq", Country.Sagua, false));
        freeAgency.Add(new player(5, 5, 3, 7, 7, 4, 7, 6, 2, 4, 5, 5, 27, "Lyintaria Player #12", Country.Lyintaria, false));
        freeAgency.Add(new player(5, 4, 2, 5, 5, 6, 4, 7, 5, 4, 5, 6, 23, "Yadingallie", Country.Key_to_Don, false));
        freeAgency.Add(new player(5, 4, 2, 5, 5, 6, 4, 7, 5, 4, 5, 6, 24, "Yadingallie", Country.Key_to_Don, false));
        freeAgency.Add(new player(5, 5, 3, 4, 4, 7, 3, 5, 4, 4, 5, 7, 27, "Point Guard #129", Country.Oesa, false));
        freeAgency.Add(new player(5, 5, 3, 3, 3, 8, 6, 3, 3, 4, 5, 6, 24, "Onishi Takeji", Country.Aeridani, false));
        freeAgency.Add(new player(5, 4, 4, 7, 7, 4, 4, 4, 3, 4, 5, 9, 27, "Dvinme Player #7", Country.Bielosia, false));
        freeAgency.Add(new player(5, 5, 3, 4, 4, 7, 4, 6, 1, 3, 5, 8, 27, "Height Sagua Player #8", Country.Height_Sagua, false));
        freeAgency.Add(new player(5, 2, 1, 3, 3, 8, 6, 6, 3, 3, 5, 8, 24, "Crispy Dribble", Country.Aeridani, false));
        freeAgency.Add(new player(5, 2, 4, 7, 7, 7, 5, 6, 1, 3, 5, 5, 27, "Point Guard #92", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(5, 3, 3, 5, 5, 5, 7, 3, 3, 5, 5, 7, 27, "Point Guard #128", Country.Czalliso, false));
        freeAgency.Add(new player(5, 3, 4, 4, 4, 6, 3, 5, 4, 3, 5, 10, 27, "Point Guard #140", Country.Bongatar, false));
        freeAgency.Add(new player(5, 4, 3, 1, 1, 8, 5, 6, 2, 5, 5, 6, 27, "Point Guard #144", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(5, 5, 4, 5, 5, 5, 4, 5, 3, 3, 5, 8, 25, "Jung Kim", Country.Shmupland, false));
        freeAgency.Add(new player(5, 6, 1, 8, 8, 6, 4, 3, 3, 3, 5, 5, 26, "Jung-Hee Cho", Country.Shmupland, false));
        freeAgency.Add(new player(5, 5, 3, 3, 3, 8, 6, 3, 3, 4, 5, 5, 27, "Dvinme Player #9", Country.Bielosia, false));
        freeAgency.Add(new player(5, 6, 4, 7, 7, 5, 5, 4, 3, 3, 5, 5, 23, "Tanau Krofar", Country.Barsein, false));
        freeAgency.Add(new player(5, 1, 1, 5, 5, 5, 8, 4, 7, 4, 5, 7, 23, "Tuto Bexek", Country.Dotruga, false));
        freeAgency.Add(new player(5, 6, 1, 3, 3, 5, 4, 6, 4, 3, 5, 10, 22, "Kai Thammavong", Country.Loviniosa, false));
        freeAgency.Add(new player(5, 2, 3, 5, 5, 7, 4, 4, 3, 3, 5, 10, 26, "Paxathipatai Menorath", Country.Loviniosa, false));
        freeAgency.Add(new player(5, 2, 4, 7, 7, 7, 5, 6, 1, 3, 5, 5, 26, "Ruul Rzit", Country.Aeridani, false));
        freeAgency.Add(new player(5, 4, 5, 10, 8, 2, 5, 5, 5, 2, 10, 5, 21, "Guvggillmào Vàydep", Country.Pentadominion, false));
        freeAgency.Add(new player(5, 6, 4, 3, 3, 6, 6, 3, 2, 5, 5, 5, 27, "Point Guard #102", Country.Sagua, false));
        freeAgency.Add(new player(5, 6, 1, 5, 5, 5, 5, 4, 4, 5, 5, 5, 27, "Point Guard #118", Country.Holy_Yektonisa, false));
        freeAgency.Add(new player(5, 5, 3, 2, 2, 8, 3, 5, 4, 5, 5, 5, 27, "Point Guard #120", Country.Auspikitan, false));
        freeAgency.Add(new player(5, 4, 3, 5, 5, 7, 4, 5, 1, 2, 5, 8, 27, "Point Guard #146", Country.Red_Rainbow, false));
        freeAgency.Add(new player(5, 5, 2, 3, 3, 7, 3, 6, 2, 4, 5, 7, 27, "Point Guard #156", Country.Ethanthova, false));
        freeAgency.Add(new player(5, 5, 2, 3, 3, 5, 7, 6, 1, 3, 5, 8, 27, "Key To Don Player #12", Country.Key_to_Don, false));
        freeAgency.Add(new player(5, 3, 1, 6, 6, 4, 5, 5, 3, 6, 5, 6, 26, "app", Country.Holykol, false));
        freeAgency.Add(new player(5, 3, 1, 6, 6, 4, 5, 5, 3, 6, 5, 5, 27, "Point Guard #20", Country.Darvincia, false));
        freeAgency.Add(new player(5, 4, 4, 3, 3, 5, 5, 3, 4, 3, 5, 10, 27, "Point Guard #33", Country.Holykol, false));
        freeAgency.Add(new player(5, 4, 2, 3, 3, 7, 4, 6, 3, 3, 5, 7, 27, "Point Guard #105", Country.Dtersauuw_Sagua, false));
        freeAgency.Add(new player(5, 6, 1, 4, 4, 5, 3, 4, 10, 3, 5, 7, 27, "Point Guard #122", Country.Aeridani, false));
        freeAgency.Add(new player(5, 3, 2, 4, 4, 8, 5, 6, 3, 2, 5, 5, 27, "Point Guard #127", Country.Transhimalia, false));
        freeAgency.Add(new player(5, 4, 2, 5, 5, 7, 3, 4, 1, 5, 5, 6, 27, "Point Guard #135", Country.Barsein, false));
        freeAgency.Add(new player(5, 4, 4, 1, 1, 8, 3, 5, 1, 4, 5, 9, 27, "Point Guard #138", Country.Blaist_Blaland, false));
        freeAgency.Add(new player(5, 4, 4, 3, 3, 5, 5, 3, 4, 3, 5, 10, 26, "Ivan Buchov", Country.Wyverncliff, false));
        freeAgency.Add(new player(5, 5, 2, 3, 3, 5, 5, 7, 2, 3, 5, 7, 25, "map", Country.Aiyota, false));
        freeAgency.Add(new player(5, 1, 4, 7, 7, 7, 4, 4, 3, 4, 5, 5, 23, "Jig", Country.Czalliso, false));
        freeAgency.Add(new player(5, 6, 2, 5, 5, 5, 5, 4, 2, 4, 5, 5, 27, "Point Guard #3", Country.Oesa, false));
        freeAgency.Add(new player(5, 4, 4, 7, 7, 4, 4, 4, 3, 4, 5, 5, 23, "Kiromi Hisei", Country.Lyintaria, false));
        freeAgency.Add(new player(5, 2, 4, 3, 3, 5, 6, 3, 2, 4, 5, 10, 26, "Ok Jae-Wook", Country.Transhimalia, false));
        freeAgency.Add(new player(5, 6, 2, 4, 4, 5, 6, 6, 1, 3, 5, 5, 27, "Point Guard #101", Country.Wyverncliff, false));
        freeAgency.Add(new player(5, 4, 4, 3, 3, 5, 3, 4, 3, 7, 5, 6, 27, "Point Guard #115", Country.Sagua, false));
        freeAgency.Add(new player(5, 5, 1, 5, 5, 5, 4, 5, 2, 5, 5, 5, 27, "Point Guard #125", Country.Dtersauuw_Sagua, false));
        freeAgency.Add(new player(5, 3, 3, 4, 4, 5, 3, 5, 4, 6, 5, 6, 27, "Point Guard #143", Country.Bielosia, false));
        freeAgency.Add(new player(5, 6, 2, 3, 3, 6, 3, 5, 2, 4, 5, 7, 27, "Point Guard #153", Country.Bielosia, false));
        freeAgency.Add(new player(5, 3, 2, 6, 6, 6, 3, 4, 3, 5, 5, 5, 27, "Point Guard #154", Country.Darvincia, false));
        freeAgency.Add(new player(5, 3, 4, 5, 5, 7, 4, 5, 3, 2, 5, 6, 27, "Point Guard #159", Country.Tri_National_Dominion, false));
        freeAgency.Add(new player(5, 2, 4, 3, 3, 8, 5, 6, 2, 2, 5, 6, 27, "Point Guard #168", Country.Aiyota, false));

        for (int i = 0; i<teams.Count; i++)
        {
            teams[i].setBestStarters();
        }
        
        teams[0].addCoach(new Coach("Coach #5", 85, 99, 0.6, 11, 0.5, 7, new Tempo(1), coachShotType.BALANCED, ssInvolvment.HIGH, r));
        teams[16].addCoach(new Coach("Coach #8", 73, 86, -0.7, 16, -0.6, 5, new Tempo(2), coachShotType.BALANCED, ssInvolvment.HIGH, r));

        teams[8].addCoach(new Coach("Coach #14", 73, 86, 0.2, 10, -0.3, 30, new Tempo(0), coachShotType.BALANCED, ssInvolvment.HIGH, r));
        teams[17].addCoach(new Coach("Coach #15", 55, 92, 0.3, 18, 0.6, 26, new Tempo(2), coachShotType.BALANCED, ssInvolvment.HIGH, r));
        teams[9].addCoach(new Coach("Coach #23", 73, 85, -0.3, 11, -0.4, 29, new Tempo(1), coachShotType.BALANCED, ssInvolvment.MEDIUM, r));
        teams[10].addCoach(new Coach("Coach #35", 54, 87, -0.1, 21, -0.3, 22, new Tempo(1), coachShotType.INSIDE, ssInvolvment.MEDIUM, r));
        teams[18].addCoach(new Coach("Coach #40", 48, 93, -0.8, 15, 0.4, 5, new Tempo(1), coachShotType.INSIDE, ssInvolvment.HIGH, r));
        teams[24].addCoach(new Coach("Coach #12", 80, 91, 0.9, 23, 0, 29, new Tempo(0), coachShotType.BALANCED, ssInvolvment.MEDIUM, r));
        teams[2].addCoach(new Coach("Coach #24", 83, 100, 0.8, 16, 0, 29, new Tempo(0), coachShotType.BALANCED, ssInvolvment.MEDIUM, r));
        teams[25].addCoach(new Coach("Coach #17", 59, 92, 0.4, 7, 0.8, 24, new Tempo(2), coachShotType.OUTSIDE, ssInvolvment.LOW,r));
        teams[31].addCoach(new Coach("Coach #34", 75, 88, 0.8, 30, 0.3, 19, new Tempo(1), coachShotType.INSIDE, ssInvolvment.MEDIUM, r));
        teams[26].addCoach(new Coach("Coach #13", 65, 92, 0.7, 7, 0.8, 10, new Tempo(0), coachShotType.BALANCED, ssInvolvment.MEDIUM, r));

        teams[21].addCoach(new Coach("Coach #10", 65, 89, 0, 12, 0.9, 29, new Tempo(0), coachShotType.BALANCED, ssInvolvment.MEDIUM, r));
        teams[3].addCoach(new Coach("Coach #18", 71, 92, 0.2, 22, 0.5, 13, new Tempo(1), coachShotType.BALANCED, ssInvolvment.LOW,r));
        teams[27].addCoach(new Coach("Coach #21", 68, 99, -0.2, 5, 1, 11, new Tempo(0), coachShotType.BALANCED, ssInvolvment.MEDIUM, r));

        teams[11].addCoach(new Coach("Coach #28", 83, 96, 0.9, 30, -1, 19, new Tempo(0), coachShotType.OUTSIDE, ssInvolvment.LOW,r));
        teams[4].addCoach(new Coach("Coach #25", 54, 91, 0.1, 17, 0.3, 10, new Tempo(1), coachShotType.INSIDE, ssInvolvment.LOW,r));
        teams[29].addCoach(new Coach("Coach #22", 56, 89, 0.1, 5, 0.5, 11, new Tempo(1), coachShotType.BALANCED, ssInvolvment.LOW,r));

        teams[12].addCoach(new Coach("Coach #26", 70, 90, -0.5, 19, -0.2, 28, new Tempo(0), coachShotType.BALANCED, ssInvolvment.LOW,r));
        teams[30].addCoach(new Coach("Coach #32", 45, 91, -0.3, 17, -0.6, 22, new Tempo(1), coachShotType.OUTSIDE, ssInvolvment.MEDIUM, r));
        teams[13].addCoach(new Coach("Coach #7", 65, 99, 0.3, 29, -0.8, 13, new Tempo(1), coachShotType.OUTSIDE, ssInvolvment.HIGH, r));
        teams[6].addCoach(new Coach("Coach #30", 53, 92, 0.7, 11, 0.3, 15, new Tempo(1), coachShotType.OUTSIDE, ssInvolvment.LOW,r));
        teams[14].addCoach(new Coach("Coach #27", 80, 92, 0.9, 24, -0.4, 6, new Tempo(0), coachShotType.BALANCED, ssInvolvment.HIGH, r));


        teams[22].addCoach(new Coach("Coach #37", 56, 98, -0.3, 9, 0, 7, new Tempo(0), coachShotType.BALANCED, ssInvolvment.LOW,r));
        teams[23].addCoach(new Coach("Coach #2", 59, 94, -0.1, 28, 0.8, 7, new Tempo(1), coachShotType.BALANCED, ssInvolvment.LOW,r));
        teams[5].addCoach(new Coach("Coach #6", 59, 84, 0.8, 6, 0.9, 28, new Tempo(1), coachShotType.BALANCED, ssInvolvment.MEDIUM, r));        

        teams[15].addCoach(new Coach("Naskitrusk Coach", 65, 100, 0.6, 20, 0.5, 25, new Tempo(1), coachShotType.BALANCED, ssInvolvment.HIGH, r));
        teams[1].addCoach(new Coach("Western University Coach", 70, 85, 1, 15, 0.4, 32, new Tempo(0), coachShotType.INSIDE, ssInvolvment.MEDIUM, r));

        teams[7].addCoach(new Coach("Mawxwmkakki Coach", 65, 90, 0.9, 30, 0.1, 6, new Tempo(1), coachShotType.OUTSIDE, ssInvolvment.HIGH, r));
        teams[28].addCoach(new Coach("Pyzus Coach", 64, 96, 0.7, 16, 0.4, 0, new Tempo(2), coachShotType.BALANCED, ssInvolvment.LOW,r));

        teams[19].addCoach(new Coach("Chromasheep Farm Coach", 65, 90, 0.8, 40, 0.95, 40, new Tempo(1), coachShotType.BALANCED, ssInvolvment.HIGH, r));

        teams[20].addCoach(new Coach("Sande Sitei Coach", 75, 85, 0.3, 40, 0.4, 24, new Tempo(2), coachShotType.OUTSIDE, ssInvolvment.LOW,r));
        
        teams[0].addTrainer(new Trainer("Trainer #19", 7, 1, 0.691094914, r));
        teams[16].addTrainer(new Trainer("Trainer #35", 10, 4, 0.57251146, r));
        teams[1].addTrainer(new Trainer("Trainer #7", 5, 2, 0.117832176, r));
        teams[8].addTrainer(new Trainer("Trainer #20", 10, 10, 0.503985209, r));
        teams[17].addTrainer(new Trainer("Trainer #1", 1, 7, 0.266258933, r));
        teams[9].addTrainer(new Trainer("Trainer #31", 4, 9, 0.630190084, r));
        teams[10].addTrainer(new Trainer("Trainer #11", 3, 1, 0.446068207, r));
        teams[18].addTrainer(new Trainer("Trainer #27", 7, 8, -0.581974201, r));
        teams[24].addTrainer(new Trainer("Trainer #16", 2, 7, 0.787548972, r));
        teams[2].addTrainer(new Trainer("Trainer #2", 10, 2, 0.285976864, r));
        teams[25].addTrainer(new Trainer("Trainer #32", 5, 3, -0.075495402, r));
        teams[19].addTrainer(new Trainer("Trainer #9", 8, 7, 0.428944579, r));
        teams[26].addTrainer(new Trainer("Trainer #26", 6, 3, 0.79609261, r));
        teams[20].addTrainer(new Trainer("Trainer #24", 1, 5, 0.124362683, r));
        teams[21].addTrainer(new Trainer("Trainer #14", 3, 8, 0.0871004, r));
        teams[3].addTrainer(new Trainer("Trainer #5", 8, 1, -0.257724291, r));
        teams[27].addTrainer(new Trainer("Trainer #15", 8, 7, -0.444167258, r));
        teams[28].addTrainer(new Trainer("Trainer #33", 8, 5, 0.694395937, r));
        teams[11].addTrainer(new Trainer("Trainer #34", 5, 8, -0.073032337, r));
        teams[4].addTrainer(new Trainer("Trainer #18", 9, 1, -0.230108126, r));
        teams[29].addTrainer(new Trainer("Trainer #37", 2, 8, -0.486536665, r));
        teams[5].addTrainer(new Trainer("Trainer #40", 5, 2, 0.218518853, r));
        teams[12].addTrainer(new Trainer("Trainer #39", 6, 4, 0.371777967, r));
        teams[30].addTrainer(new Trainer("Trainer #25", 2, 8, 0.336946596, r));
        teams[13].addTrainer(new Trainer("Trainer #8", 3, 1, 0.596611974, r));
        teams[6].addTrainer(new Trainer("Trainer #3", 6, 1, 0.332918203, r));
        teams[14].addTrainer(new Trainer("Trainer #30", 6, 3, 0.477191344, r));
        teams[15].addTrainer(new Trainer("Trainer #22", 2, 5, 0.350137071, r));
        teams[7].addTrainer(new Trainer("Trainer #36", 9, 8, 0.126761463, r));
        teams[22].addTrainer(new Trainer("Trainer #29", 9, 1, 0.072649528, r));
        teams[23].addTrainer(new Trainer("Trainer #17", 8, 1, 0.989996664, r));
        teams[31].addTrainer(new Trainer("Trainer #12", 10, 4, -0.88818582, r));




        setFianancials();
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
        GetCollege();
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

   
