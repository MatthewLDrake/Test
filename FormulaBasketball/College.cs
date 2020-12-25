using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
[Serializable]
public class College
{
    private List<player> players;
    private List<CollegeTeam> teams;
    private string standingsContents;
    private FormulaBasketball.Random r;
    private List<Pair[]> games;
    private int season;
    private List<player> rookies;
    public College(FormulaBasketball.Random r)
    {
        season = 1;
        standingsContents = "";
        this.r = r;
        players = new List<player>();
        teams = new List<CollegeTeam>();
        rookies = new List<player>();
        LoadTeams();                
    }
    public void CollegeSetup()
    {
        foreach(team team in teams)
        {
            List<player> players = team.ClearPlayers();
            foreach(player p in players)
            {
                team.addPlayer(p);
            }
        }
    }
    public void PlaySeason()
    {
        
        games = GetConferenceGames();

        games.AddRange(GetGames());

        games.Shuffle(r);
        Console.WriteLine(season);
        
        for (int i = 0; i < games.Count; i++)
        {
            if (i % 5 == 4) DevelopPlayers();
            for (int j = 0; j < games[i].Length; j++)
            {
                executeGame(false, games[i][j].x, games[i][j].y);
            }
        }
        Console.WriteLine(season + " finished");
        season++;
        Stats();

        Standings();

        Rosters();

        DetermineRookies(season);

    }
    public List<CollegePlayer> GetRookies()
    {
        List<CollegePlayer> retval = new List<CollegePlayer>();
        foreach(player p in rookies)
        {
            retval.Add(p as CollegePlayer);
        }
        return retval;
    }
    private void DetermineRookies(int season)
    {
        rookies = new List<player>();
        foreach (CollegeTeam team in teams)
        {
            team.EndCollegeSeason();
            foreach (player p in team)
            {
                CollegePlayer player = p as CollegePlayer;
                if (player.GoPro(r)) rookies.Add(player);
            }
            team.RemoveLeavingPlayers(season);
        }
        string content = "";
        content += "New Rookies\tPlayer\tPosition\tLayup\tDunk\tJumpshot\t3PT\tPass\tShotContest\tDefenseIQ\tJumping\tSeperation\tDurability\tStamina\tDevelopment\tAge\tOverall\tPlayer ID\tYears Remaining\tMoney\tPosition Rank\tLeague Rank\n";
        foreach (CollegePlayer player in rookies)
        {
            player.FixRatings(r);
            content += player.getRatingsAsString();
        }
        
        File.WriteAllText("newrookies.csv", content);
    }
    private void DevelopPlayers()
    {
        foreach(team team in teams)
        {
            foreach(player p in team)
            {
                p.Develop(r);
            }
        }
    }
    private void Rosters()
    {
        string content = "";
        foreach (team team in teams)
        {
            content += team.ToString() + "\tPlayer\tPosition\tLayup\tDunk\tJumpshot\t3PT\tPass\tShotContest\tDefenseIQ\tJumping\tSeperation\tDurability\tStamina\tDevelopment\tAge\tOverall\tPlayer ID\tYears Remaining\tMoney\tPosition Rank\tLeague Rank\n";
            foreach (player player in team)
            {
                content += player.getRatingsAsString();
            }
        }
        File.WriteAllText("collegeRosters.csv", content);
    }
    private void Standings()
    {
        List<CollegeTeam>[] division = new List<CollegeTeam>[10];
        List<CollegeTeam> league = new List<CollegeTeam>();
        for (int i = 0; i < 10; i++)
        {
            division[i] = new List<CollegeTeam>();
            for (int j = 0; j < 10; j++)
            {
                division[i].Add(teams[i * 10 + j]);

            }
            division[i].Sort();
            league.AddRange(division[i]);
        }
        league.Sort();
        for (int i = 0; i < league.Count; i++)
        {
            league[i].setLeagueRank(i + 1);
        }
        for (int i = 0; i < 10; i++)
        {
            standingsContents += "Division " + i + ",Wins,Losses,Points Scored,Points Against,Division Rank,Conference Rank,League Rank\n";
            for (int j = 0; j < 10; j++)
            {
                division[i][j].setDivisionRank(j + 1);
                division[i][j].setConferenceRank(j + 1);
                Standings(division[i][j]);
            }
        }
        File.WriteAllText("collegestandings.csv", standingsContents);
    }
    private void Standings(team team)
    {
        standingsContents += "" + team.ToString() + "," + team.getWins() + "," + team.getLosses() + "," + team.getPoints() + "," + team.getPointsAgainst() + "," + team.getDivisionRank() + "," + team.getConferenceRank() + "," + team.getLeagueRank() + "\n";

    }
    private void Stats()
    {
        string statsContents = "";
        for (int i = 0; i < teams.Count; i++)
        {
            statsContents += (teams[i].ToString() + " players,Games Played,Minutes,Assists,Points,Shots Taken,Shots Made,Field Goal Percentage,Threes Taken,Threes Made,Free Throws Taken,Free Throws Made,Turnovers,Steals,Rebounds,Offensive Rebounds,Defensive Rebounds,Fouls,Opponent Shots Against,Opponent Shots Made,Opponent Shot Percent,Point Differential\n");
            for (int k = 0; k < teams[i].getSize(); k++)
            {
                double shootingPercentage = 0.0, opponentPercentage = 0.0;
                if (teams[i].getPlayer(k).getShotsTaken() != 0)
                {

                    shootingPercentage = ((double)teams[i].getPlayer(k).getShotsMade() / (double)teams[i].getPlayer(k).getShotsTaken()) * 100;
                }
                double plus_minus = 0.0;
                if (teams[i].getPlayer(k).getGamesPlayed() != 0)
                {
                    plus_minus = ((double)teams[i].getPlayer(k).teamPoints / (double)teams[i].getPlayer(k).getGamesPlayed());
                }
                if (teams[i].getPlayer(k).getShotsAttemptedAgainst() != 0)
                    opponentPercentage = ((double)teams[i].getPlayer(k).getShotsMadeAgainst() / (double)teams[i].getPlayer(k).getShotsAttemptedAgainst()) * 100;
                statsContents += (teams[i].getPlayer(k).getName() + "," + teams[i].getPlayer(k).getGamesPlayed() + "," + teams[i].getPlayer(k).getMinutes() + "," + teams[i].getPlayer(k).getAssists() + "," + teams[i].getPlayer(k).getPoints() + "," + teams[i].getPlayer(k).getShotsTaken() + ","
                        + teams[i].getPlayer(k).getShotsMade() + "," + shootingPercentage + "," + teams[i].getPlayer(k).getThreesTaken() + "," + teams[i].getPlayer(k).getThreePointersMade() + "," + teams[i].getPlayer(k).getFreeThrowsTaken() + "," + teams[i].getPlayer(k).getFreeThrowsMade()
                        + "," + teams[i].getPlayer(k).getTurnovers() + "," + teams[i].getPlayer(k).getSteals() + "," + teams[i].getPlayer(k).getRebounds() + "," + teams[i].getPlayer(k).getOffensiveRebounds() + "," + teams[i].getPlayer(k).getDefensiveRebounds()
                        + "," + teams[i].getPlayer(k).getFouls() + "," + teams[i].getPlayer(k).getShotsAttemptedAgainst() + "," + teams[i].getPlayer(k).getShotsMadeAgainst() + ","
                        + opponentPercentage + ", " + plus_minus + "\n");
            }
            //standings(teams[i]);
        }
        File.WriteAllText("collegestats.csv", statsContents);
    }
    private int[] GetPercents(int pos, Country country)
    {
        int[] retVal = new int[teams.Count];
        for (int i = 0; i < teams.Count; i++)
        {
            int num = 0;

            if (teams[i].GetCountry().Equals(country)) num += 8;

            int numPlayers = teams[i].getNumPlayersByPos(pos);
            if (numPlayers == 3) num = 0;
            else if(numPlayers == 2)num += 1;
            else if (numPlayers == 1) num += 3;
            else if (numPlayers == 0) num += 6;


            retVal[i] = num;
        }
        return retVal;
    }

    
    private void LoadTeams()
    {
        CollegeTeam newTeam = null;
        int i = 0;
        newTeam = new CollegeTeam("University of Pxalit'k'a", "UPX", r, Country.Dtersauuw_Sagua, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Sande Sitei", "USA", r, Country.Darvincia, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Kap'atŋpiri", "UKA", r, Country.Oesa, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Futi'akep", "UFU", r, Country.Futiakep, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Atapwa", "UAT", r, Country.Atapwa, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Hinaika Oceanography Institute", "UHI", r, Country.Hinaika, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Auspikitan", "UAU", r, Country.Auspikitan, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Alteus", "UAL", r, Country.Wyverncliff, new EliteCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Saelunavvk", "USA", r, Country.Solea, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Nausicaa", "UNA", r, Country.Nausicaa, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);

        newTeam = new CollegeTeam("University of Noxium", "UNO", r, Country.Blaist_Blaland , new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Prokax", "UPR", r, Country.Blaist_Blaland, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Klanaxon", "UKL", r, Country.Blaist_Blaland, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Naxda", "UNA", r, Country.Blaist_Blaland, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Sozaxon", "USO", r, Country.Blaist_Blaland, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Blanaxon", "UBL", r, Country.Blaist_Blaland, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Autolik", "UAU", r, Country.Blaist_Blaland, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Uxnua", "UUX", r, Country.Blaist_Blaland, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Sovkagrad", "USO", r, Country.Red_Rainbow, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Radugrad", "URA", r, Country.Red_Rainbow, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);

        newTeam = new CollegeTeam("University of Sagua", "USA", r, Country.Sagua, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Shigua", "USH", r, Country.Height_Sagua, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Dongua", "UDO", r, Country.Key_to_Don, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Barsein", "UBA", r, Country.Barsein, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Issamore", "UIS", r, Country.Antarion, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Antarion 2", "UAN", r, Country.Antarion, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Antarion 3", "UAN", r, Country.Antarion, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Nja", "UNJ", r, Country.Nja, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Pentadominion 1", "UPE", r, Country.Pentadominion, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Pentadominion 2", "UPE", r, Country.Pentadominion, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);

        newTeam = new CollegeTeam("University of Shmupland 1", "USH", r, Country.Shmupland, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Shmupland 2", "USH", r, Country.Shmupland, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Shmupland 3", "USH", r, Country.Shmupland, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Shmupland 4", "USH", r, Country.Shmupland, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Shmupland 5", "USH", r, Country.Shmupland, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Oasis City", "UOA", r, Country.Kaeshar, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Sapphire Bay", "USA", r, Country.Kaeshar, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Chromasheep Farm", "UCH", r, Country.Kaeshar, new EliteCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Kaeshar 4", "UKA", r, Country.Kaeshar, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Kaeshar 5", "UKA", r, Country.Kaeshar, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);

        newTeam = new CollegeTeam("University of Lizabechai", "ULI", r, Country.Bielosia, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Levikeana Solvae", "ULE", r, Country.Bielosia, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Alieosia", "UAL", r, Country.Bielosia, new EliteCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Byisotia", "UBY", r, Country.Bielosia, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Hkamnsi", "UHK", r, Country.Lyintaria, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Vrelinku", "UVR", r, Country.Lyintaria, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Lveinta", "ULV", r, Country.Lyintaria, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Nomvas", "UNO", r, Country.Pyxanovia, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Pyzus", "UPY", r, Country.Pyxanovia, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Eastern Alveske", "UEA", r, Country.Pyxanovia, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);

        newTeam = new CollegeTeam("University of Quiita-Kyudosia", "UQU", r, Country.Holy_Yektonisa, new AverageCollegeTeam(), season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Svitharia", "USV", r, Country.Other, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Soniara", "USO", r, Country.Other, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Kholka", "UKH", r, Country.Other, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Aavana", "UAA", r, Country.Other, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Floria", "UFL", r, Country.Other, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Eirnvse", "UEI", r, Country.Nova_Chrysalia, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Venasul", "UVE", r, Country.Other, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Ncov Ntiajeb", "UNC", r, Country.Other, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Zhiwasen", "UZH", r, Country.Other, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);

        newTeam = new CollegeTeam("University of Vincent", "UVI", r, Country.Ethanthova, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Boltway", "UBO", r, Country.Ethanthova, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Vigim", "UVI", r, Country.Ethanthova, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Arinis", "UAR", r, Country.Ethanthova, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("Naskitrusk University", "NAU", r, Country.Dotruga, new EliteCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("Stedro Institute of Technology", "STU", r, Country.Dotruga, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("Esmal District University", "EDU", r, Country.Dotruga, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("Atresmi University", "ATU", r, Country.Dotruga, new EliteCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Herelle", "UHE", r, Country.Tri_National_Dominion, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Tri_National_Dominion 2", "UTN", r, Country.Tri_National_Dominion, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);

        newTeam = new CollegeTeam("University of Imperial Institute at Faehrenfall", "UIM", r, Country.Aeridani, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Avura Aviation & Economics (A&E)", "UAV", r, Country.Aeridani, new EliteCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of University of Central Paradaniton", "UUN", r, Country.Aeridani, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Chizait University", "UCH", r, Country.Aeridani, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Imperial Institute at Levzent", "UIM", r, Country.Aeridani, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Western University", "UWE", r, Country.Aeridani, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Vikasa", "UVI", r, Country.Aiyota, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Akarine", "UAK", r, Country.Aiyota, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Ciulo", "UCI", r, Country.Aiyota, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Yoka Tse", "UYO", r, Country.Aiyota, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);

        newTeam = new CollegeTeam("University of Protopolis", "UPR", r, Country.Czalliso, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Biodry", "UBI", r, Country.Czalliso, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Forssa", "UFO", r, Country.Czalliso, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Starrie", "UST", r, Country.Czalliso, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Vatallus", "UVA", r, Country.Czalliso, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Pokoj", "UPO", r, Country.Czalliso, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Lumein", "ULU", r, Country.Czalliso, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Seraphia", "USE", r, Country.Czalliso, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Holykol", "UHO", r, Country.Holykol, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Norkute", "UNO", r, Country.Norkute, new BadCollegeTeam(), season); teams.Add(newTeam); newTeam.setTeamNum(i++);

        newTeam = new CollegeTeam("University of Ikkuvvuki", "UIK", r, Country.Transhimalia, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Fiik Lanki Akol", "UFI", r, Country.Transhimalia, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Yuofuan", "UYU", r, Country.Transhimalia, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Maxwmkakki", "UMA", r, Country.Transhimalia, new PoorCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Lnwm", "ULN", r, Country.Transhimalia, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Vikkada", "UVI", r, Country.Transhimalia, new BadCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Aahrus 1", "UAA", r, Country.Aahrus, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Aahrus 2", "UAA", r, Country.Aahrus, new GoodCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Bongatar 1", "UBO", r, Country.Bongatar, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
        newTeam = new CollegeTeam("University of Bongatar 2", "UBO", r, Country.Bongatar, new AverageCollegeTeam(),season); teams.Add(newTeam); newTeam.setTeamNum(i++);
    }
    private List<Pair[]> GetConferenceGames()
    {
        List<Pair[]> retVal = new List<Pair[]>();

        for(int i = 0; i < 18; i++)
        {
            retVal.Add(new Pair[50]);
        }

        retVal[0][0] = new Pair(9, 0, true);
        retVal[1][0] = new Pair(0, 9, true);
        retVal[0][1] = new Pair(8, 1, true);
        retVal[1][1] = new Pair(1, 8, true);
        retVal[0][2] = new Pair(7, 2, true);
        retVal[1][2] = new Pair(2, 7, true);
        retVal[0][3] = new Pair(6, 3, true);
        retVal[1][3] = new Pair(3, 6, true);
        retVal[0][4] = new Pair(5, 4, true);
        retVal[1][4] = new Pair(4, 5, true);
        retVal[0][5] = new Pair(19, 10, true);
        retVal[1][5] = new Pair(10, 19, true);
        retVal[0][6] = new Pair(18, 11, true);
        retVal[1][6] = new Pair(11, 18, true);
        retVal[0][7] = new Pair(17, 12, true);
        retVal[1][7] = new Pair(12, 17, true);
        retVal[0][8] = new Pair(16, 13, true);
        retVal[1][8] = new Pair(13, 16, true);
        retVal[0][9] = new Pair(15, 14, true);
        retVal[1][9] = new Pair(14, 15, true);
        retVal[0][10] = new Pair(29, 20, true);
        retVal[1][10] = new Pair(20, 29, true);
        retVal[0][11] = new Pair(28, 21, true);
        retVal[1][11] = new Pair(21, 28, true);
        retVal[0][12] = new Pair(27, 22, true);
        retVal[1][12] = new Pair(22, 27, true);
        retVal[0][13] = new Pair(26, 23, true);
        retVal[1][13] = new Pair(23, 26, true);
        retVal[0][14] = new Pair(25, 24, true);
        retVal[1][14] = new Pair(24, 25, true);
        retVal[0][15] = new Pair(39, 30, true);
        retVal[1][15] = new Pair(30, 39, true);
        retVal[0][16] = new Pair(38, 31, true);
        retVal[1][16] = new Pair(31, 38, true);
        retVal[0][17] = new Pair(37, 32, true);
        retVal[1][17] = new Pair(32, 37, true);
        retVal[0][18] = new Pair(36, 33, true);
        retVal[1][18] = new Pair(33, 36, true);
        retVal[0][19] = new Pair(35, 34, true);
        retVal[1][19] = new Pair(34, 35, true);
        retVal[0][20] = new Pair(49, 40, true);
        retVal[1][20] = new Pair(40, 49, true);
        retVal[0][21] = new Pair(48, 41, true);
        retVal[1][21] = new Pair(41, 48, true);
        retVal[0][22] = new Pair(47, 42, true);
        retVal[1][22] = new Pair(42, 47, true);
        retVal[0][23] = new Pair(46, 43, true);
        retVal[1][23] = new Pair(43, 46, true);
        retVal[0][24] = new Pair(45, 44, true);
        retVal[1][24] = new Pair(44, 45, true);
        retVal[0][25] = new Pair(59, 50, true);
        retVal[1][25] = new Pair(50, 59, true);
        retVal[0][26] = new Pair(58, 51, true);
        retVal[1][26] = new Pair(51, 58, true);
        retVal[0][27] = new Pair(57, 52, true);
        retVal[1][27] = new Pair(52, 57, true);
        retVal[0][28] = new Pair(56, 53, true);
        retVal[1][28] = new Pair(53, 56, true);
        retVal[0][29] = new Pair(55, 54, true);
        retVal[1][29] = new Pair(54, 55, true);
        retVal[0][30] = new Pair(69, 60, true);
        retVal[1][30] = new Pair(60, 69, true);
        retVal[0][31] = new Pair(68, 61, true);
        retVal[1][31] = new Pair(61, 68, true);
        retVal[0][32] = new Pair(67, 62, true);
        retVal[1][32] = new Pair(62, 67, true);
        retVal[0][33] = new Pair(66, 63, true);
        retVal[1][33] = new Pair(63, 66, true);
        retVal[0][34] = new Pair(65, 64, true);
        retVal[1][34] = new Pair(64, 65, true);
        retVal[0][35] = new Pair(79, 70, true);
        retVal[1][35] = new Pair(70, 79, true);
        retVal[0][36] = new Pair(78, 71, true);
        retVal[1][36] = new Pair(71, 78, true);
        retVal[0][37] = new Pair(77, 72, true);
        retVal[1][37] = new Pair(72, 77, true);
        retVal[0][38] = new Pair(76, 73, true);
        retVal[1][38] = new Pair(73, 76, true);
        retVal[0][39] = new Pair(75, 74, true);
        retVal[1][39] = new Pair(74, 75, true);
        retVal[0][40] = new Pair(89, 80, true);
        retVal[1][40] = new Pair(80, 89, true);
        retVal[0][41] = new Pair(88, 81, true);
        retVal[1][41] = new Pair(81, 88, true);
        retVal[0][42] = new Pair(87, 82, true);
        retVal[1][42] = new Pair(82, 87, true);
        retVal[0][43] = new Pair(86, 83, true);
        retVal[1][43] = new Pair(83, 86, true);
        retVal[0][44] = new Pair(85, 84, true);
        retVal[1][44] = new Pair(84, 85, true);
        retVal[0][45] = new Pair(99, 90, true);
        retVal[1][45] = new Pair(90, 99, true);
        retVal[0][46] = new Pair(98, 91, true);
        retVal[1][46] = new Pair(91, 98, true);
        retVal[0][47] = new Pair(97, 92, true);
        retVal[1][47] = new Pair(92, 97, true);
        retVal[0][48] = new Pair(96, 93, true);
        retVal[1][48] = new Pair(93, 96, true);
        retVal[0][49] = new Pair(95, 94, true);
        retVal[1][49] = new Pair(94, 95, true);
        retVal[2][0] = new Pair(1, 0, true);
        retVal[3][0] = new Pair(0, 1, true);
        retVal[2][1] = new Pair(9, 2, true);
        retVal[3][1] = new Pair(2, 9, true);
        retVal[2][2] = new Pair(8, 3, true);
        retVal[3][2] = new Pair(3, 8, true);
        retVal[2][3] = new Pair(7, 4, true);
        retVal[3][3] = new Pair(4, 7, true);
        retVal[2][4] = new Pair(6, 5, true);
        retVal[3][4] = new Pair(5, 6, true);
        retVal[2][5] = new Pair(11, 10, true);
        retVal[3][5] = new Pair(10, 11, true);
        retVal[2][6] = new Pair(19, 12, true);
        retVal[3][6] = new Pair(12, 19, true);
        retVal[2][7] = new Pair(18, 13, true);
        retVal[3][7] = new Pair(13, 18, true);
        retVal[2][8] = new Pair(17, 14, true);
        retVal[3][8] = new Pair(14, 17, true);
        retVal[2][9] = new Pair(16, 15, true);
        retVal[3][9] = new Pair(15, 16, true);
        retVal[2][10] = new Pair(21, 20, true);
        retVal[3][10] = new Pair(20, 21, true);
        retVal[2][11] = new Pair(29, 22, true);
        retVal[3][11] = new Pair(22, 29, true);
        retVal[2][12] = new Pair(28, 23, true);
        retVal[3][12] = new Pair(23, 28, true);
        retVal[2][13] = new Pair(27, 24, true);
        retVal[3][13] = new Pair(24, 27, true);
        retVal[2][14] = new Pair(26, 25, true);
        retVal[3][14] = new Pair(25, 26, true);
        retVal[2][15] = new Pair(31, 30, true);
        retVal[3][15] = new Pair(30, 31, true);
        retVal[2][16] = new Pair(39, 32, true);
        retVal[3][16] = new Pair(32, 39, true);
        retVal[2][17] = new Pair(38, 33, true);
        retVal[3][17] = new Pair(33, 38, true);
        retVal[2][18] = new Pair(37, 34, true);
        retVal[3][18] = new Pair(34, 37, true);
        retVal[2][19] = new Pair(36, 35, true);
        retVal[3][19] = new Pair(35, 36, true);
        retVal[2][20] = new Pair(41, 40, true);
        retVal[3][20] = new Pair(40, 41, true);
        retVal[2][21] = new Pair(49, 42, true);
        retVal[3][21] = new Pair(42, 49, true);
        retVal[2][22] = new Pair(48, 43, true);
        retVal[3][22] = new Pair(43, 48, true);
        retVal[2][23] = new Pair(47, 44, true);
        retVal[3][23] = new Pair(44, 47, true);
        retVal[2][24] = new Pair(46, 45, true);
        retVal[3][24] = new Pair(45, 46, true);
        retVal[2][25] = new Pair(51, 50, true);
        retVal[3][25] = new Pair(50, 51, true);
        retVal[2][26] = new Pair(59, 52, true);
        retVal[3][26] = new Pair(52, 59, true);
        retVal[2][27] = new Pair(58, 53, true);
        retVal[3][27] = new Pair(53, 58, true);
        retVal[2][28] = new Pair(57, 54, true);
        retVal[3][28] = new Pair(54, 57, true);
        retVal[2][29] = new Pair(56, 55, true);
        retVal[3][29] = new Pair(55, 56, true);
        retVal[2][30] = new Pair(61, 60, true);
        retVal[3][30] = new Pair(60, 61, true);
        retVal[2][31] = new Pair(69, 62, true);
        retVal[3][31] = new Pair(62, 69, true);
        retVal[2][32] = new Pair(68, 63, true);
        retVal[3][32] = new Pair(63, 68, true);
        retVal[2][33] = new Pair(67, 64, true);
        retVal[3][33] = new Pair(64, 67, true);
        retVal[2][34] = new Pair(66, 65, true);
        retVal[3][34] = new Pair(65, 66, true);
        retVal[2][35] = new Pair(71, 70, true);
        retVal[3][35] = new Pair(70, 71, true);
        retVal[2][36] = new Pair(79, 72, true);
        retVal[3][36] = new Pair(72, 79, true);
        retVal[2][37] = new Pair(78, 73, true);
        retVal[3][37] = new Pair(73, 78, true);
        retVal[2][38] = new Pair(77, 74, true);
        retVal[3][38] = new Pair(74, 77, true);
        retVal[2][39] = new Pair(76, 75, true);
        retVal[3][39] = new Pair(75, 76, true);
        retVal[2][40] = new Pair(81, 80, true);
        retVal[3][40] = new Pair(80, 81, true);
        retVal[2][41] = new Pair(89, 82, true);
        retVal[3][41] = new Pair(82, 89, true);
        retVal[2][42] = new Pair(88, 83, true);
        retVal[3][42] = new Pair(83, 88, true);
        retVal[2][43] = new Pair(87, 84, true);
        retVal[3][43] = new Pair(84, 87, true);
        retVal[2][44] = new Pair(86, 85, true);
        retVal[3][44] = new Pair(85, 86, true);
        retVal[2][45] = new Pair(91, 90, true);
        retVal[3][45] = new Pair(90, 91, true);
        retVal[2][46] = new Pair(99, 92, true);
        retVal[3][46] = new Pair(92, 99, true);
        retVal[2][47] = new Pair(98, 93, true);
        retVal[3][47] = new Pair(93, 98, true);
        retVal[2][48] = new Pair(97, 94, true);
        retVal[3][48] = new Pair(94, 97, true);
        retVal[2][49] = new Pair(96, 95, true);
        retVal[3][49] = new Pair(95, 96, true);
        retVal[4][0] = new Pair(2, 0, true);
        retVal[5][0] = new Pair(0, 2, true);
        retVal[4][1] = new Pair(1, 3, true);
        retVal[5][1] = new Pair(3, 1, true);
        retVal[4][2] = new Pair(9, 4, true);
        retVal[5][2] = new Pair(4, 9, true);
        retVal[4][3] = new Pair(8, 5, true);
        retVal[5][3] = new Pair(5, 8, true);
        retVal[4][4] = new Pair(7, 6, true);
        retVal[5][4] = new Pair(6, 7, true);
        retVal[4][5] = new Pair(12, 10, true);
        retVal[5][5] = new Pair(10, 12, true);
        retVal[4][6] = new Pair(11, 13, true);
        retVal[5][6] = new Pair(13, 11, true);
        retVal[4][7] = new Pair(19, 14, true);
        retVal[5][7] = new Pair(14, 19, true);
        retVal[4][8] = new Pair(18, 15, true);
        retVal[5][8] = new Pair(15, 18, true);
        retVal[4][9] = new Pair(17, 16, true);
        retVal[5][9] = new Pair(16, 17, true);
        retVal[4][10] = new Pair(22, 20, true);
        retVal[5][10] = new Pair(20, 22, true);
        retVal[4][11] = new Pair(21, 23, true);
        retVal[5][11] = new Pair(23, 21, true);
        retVal[4][12] = new Pair(29, 24, true);
        retVal[5][12] = new Pair(24, 29, true);
        retVal[4][13] = new Pair(28, 25, true);
        retVal[5][13] = new Pair(25, 28, true);
        retVal[4][14] = new Pair(27, 26, true);
        retVal[5][14] = new Pair(26, 27, true);
        retVal[4][15] = new Pair(32, 30, true);
        retVal[5][15] = new Pair(30, 32, true);
        retVal[4][16] = new Pair(31, 33, true);
        retVal[5][16] = new Pair(33, 31, true);
        retVal[4][17] = new Pair(39, 34, true);
        retVal[5][17] = new Pair(34, 39, true);
        retVal[4][18] = new Pair(38, 35, true);
        retVal[5][18] = new Pair(35, 38, true);
        retVal[4][19] = new Pair(37, 36, true);
        retVal[5][19] = new Pair(36, 37, true);
        retVal[4][20] = new Pair(42, 40, true);
        retVal[5][20] = new Pair(40, 42, true);
        retVal[4][21] = new Pair(41, 43, true);
        retVal[5][21] = new Pair(43, 41, true);
        retVal[4][22] = new Pair(49, 44, true);
        retVal[5][22] = new Pair(44, 49, true);
        retVal[4][23] = new Pair(48, 45, true);
        retVal[5][23] = new Pair(45, 48, true);
        retVal[4][24] = new Pair(47, 46, true);
        retVal[5][24] = new Pair(46, 47, true);
        retVal[4][25] = new Pair(52, 50, true);
        retVal[5][25] = new Pair(50, 52, true);
        retVal[4][26] = new Pair(51, 53, true);
        retVal[5][26] = new Pair(53, 51, true);
        retVal[4][27] = new Pair(59, 54, true);
        retVal[5][27] = new Pair(54, 59, true);
        retVal[4][28] = new Pair(58, 55, true);
        retVal[5][28] = new Pair(55, 58, true);
        retVal[4][29] = new Pair(57, 56, true);
        retVal[5][29] = new Pair(56, 57, true);
        retVal[4][30] = new Pair(62, 60, true);
        retVal[5][30] = new Pair(60, 62, true);
        retVal[4][31] = new Pair(61, 63, true);
        retVal[5][31] = new Pair(63, 61, true);
        retVal[4][32] = new Pair(69, 64, true);
        retVal[5][32] = new Pair(64, 69, true);
        retVal[4][33] = new Pair(68, 65, true);
        retVal[5][33] = new Pair(65, 68, true);
        retVal[4][34] = new Pair(67, 66, true);
        retVal[5][34] = new Pair(66, 67, true);
        retVal[4][35] = new Pair(72, 70, true);
        retVal[5][35] = new Pair(70, 72, true);
        retVal[4][36] = new Pair(71, 73, true);
        retVal[5][36] = new Pair(73, 71, true);
        retVal[4][37] = new Pair(79, 74, true);
        retVal[5][37] = new Pair(74, 79, true);
        retVal[4][38] = new Pair(78, 75, true);
        retVal[5][38] = new Pair(75, 78, true);
        retVal[4][39] = new Pair(77, 76, true);
        retVal[5][39] = new Pair(76, 77, true);
        retVal[4][40] = new Pair(82, 80, true);
        retVal[5][40] = new Pair(80, 82, true);
        retVal[4][41] = new Pair(81, 83, true);
        retVal[5][41] = new Pair(83, 81, true);
        retVal[4][42] = new Pair(89, 84, true);
        retVal[5][42] = new Pair(84, 89, true);
        retVal[4][43] = new Pair(88, 85, true);
        retVal[5][43] = new Pair(85, 88, true);
        retVal[4][44] = new Pair(87, 86, true);
        retVal[5][44] = new Pair(86, 87, true);
        retVal[4][45] = new Pair(92, 90, true);
        retVal[5][45] = new Pair(90, 92, true);
        retVal[4][46] = new Pair(91, 93, true);
        retVal[5][46] = new Pair(93, 91, true);
        retVal[4][47] = new Pair(99, 94, true);
        retVal[5][47] = new Pair(94, 99, true);
        retVal[4][48] = new Pair(98, 95, true);
        retVal[5][48] = new Pair(95, 98, true);
        retVal[4][49] = new Pair(97, 96, true);
        retVal[5][49] = new Pair(96, 97, true);
        retVal[6][0] = new Pair(3, 0, true);
        retVal[7][0] = new Pair(0, 3, true);
        retVal[6][1] = new Pair(2, 4, true);
        retVal[7][1] = new Pair(4, 2, true);
        retVal[6][2] = new Pair(1, 5, true);
        retVal[7][2] = new Pair(5, 1, true);
        retVal[6][3] = new Pair(9, 6, true);
        retVal[7][3] = new Pair(6, 9, true);
        retVal[6][4] = new Pair(8, 7, true);
        retVal[7][4] = new Pair(7, 8, true);
        retVal[6][5] = new Pair(13, 10, true);
        retVal[7][5] = new Pair(10, 13, true);
        retVal[6][6] = new Pair(12, 14, true);
        retVal[7][6] = new Pair(14, 12, true);
        retVal[6][7] = new Pair(11, 15, true);
        retVal[7][7] = new Pair(15, 11, true);
        retVal[6][8] = new Pair(19, 16, true);
        retVal[7][8] = new Pair(16, 19, true);
        retVal[6][9] = new Pair(18, 17, true);
        retVal[7][9] = new Pair(17, 18, true);
        retVal[6][10] = new Pair(23, 20, true);
        retVal[7][10] = new Pair(20, 23, true);
        retVal[6][11] = new Pair(22, 24, true);
        retVal[7][11] = new Pair(24, 22, true);
        retVal[6][12] = new Pair(21, 25, true);
        retVal[7][12] = new Pair(25, 21, true);
        retVal[6][13] = new Pair(29, 26, true);
        retVal[7][13] = new Pair(26, 29, true);
        retVal[6][14] = new Pair(28, 27, true);
        retVal[7][14] = new Pair(27, 28, true);
        retVal[6][15] = new Pair(33, 30, true);
        retVal[7][15] = new Pair(30, 33, true);
        retVal[6][16] = new Pair(32, 34, true);
        retVal[7][16] = new Pair(34, 32, true);
        retVal[6][17] = new Pair(31, 35, true);
        retVal[7][17] = new Pair(35, 31, true);
        retVal[6][18] = new Pair(39, 36, true);
        retVal[7][18] = new Pair(36, 39, true);
        retVal[6][19] = new Pair(38, 37, true);
        retVal[7][19] = new Pair(37, 38, true);
        retVal[6][20] = new Pair(43, 40, true);
        retVal[7][20] = new Pair(40, 43, true);
        retVal[6][21] = new Pair(42, 44, true);
        retVal[7][21] = new Pair(44, 42, true);
        retVal[6][22] = new Pair(41, 45, true);
        retVal[7][22] = new Pair(45, 41, true);
        retVal[6][23] = new Pair(49, 46, true);
        retVal[7][23] = new Pair(46, 49, true);
        retVal[6][24] = new Pair(48, 47, true);
        retVal[7][24] = new Pair(47, 48, true);
        retVal[6][25] = new Pair(53, 50, true);
        retVal[7][25] = new Pair(50, 53, true);
        retVal[6][26] = new Pair(52, 54, true);
        retVal[7][26] = new Pair(54, 52, true);
        retVal[6][27] = new Pair(51, 55, true);
        retVal[7][27] = new Pair(55, 51, true);
        retVal[6][28] = new Pair(59, 56, true);
        retVal[7][28] = new Pair(56, 59, true);
        retVal[6][29] = new Pair(58, 57, true);
        retVal[7][29] = new Pair(57, 58, true);
        retVal[6][30] = new Pair(63, 60, true);
        retVal[7][30] = new Pair(60, 63, true);
        retVal[6][31] = new Pair(62, 64, true);
        retVal[7][31] = new Pair(64, 62, true);
        retVal[6][32] = new Pair(61, 65, true);
        retVal[7][32] = new Pair(65, 61, true);
        retVal[6][33] = new Pair(69, 66, true);
        retVal[7][33] = new Pair(66, 69, true);
        retVal[6][34] = new Pair(68, 67, true);
        retVal[7][34] = new Pair(67, 68, true);
        retVal[6][35] = new Pair(73, 70, true);
        retVal[7][35] = new Pair(70, 73, true);
        retVal[6][36] = new Pair(72, 74, true);
        retVal[7][36] = new Pair(74, 72, true);
        retVal[6][37] = new Pair(71, 75, true);
        retVal[7][37] = new Pair(75, 71, true);
        retVal[6][38] = new Pair(79, 76, true);
        retVal[7][38] = new Pair(76, 79, true);
        retVal[6][39] = new Pair(78, 77, true);
        retVal[7][39] = new Pair(77, 78, true);
        retVal[6][40] = new Pair(83, 80, true);
        retVal[7][40] = new Pair(80, 83, true);
        retVal[6][41] = new Pair(82, 84, true);
        retVal[7][41] = new Pair(84, 82, true);
        retVal[6][42] = new Pair(81, 85, true);
        retVal[7][42] = new Pair(85, 81, true);
        retVal[6][43] = new Pair(89, 86, true);
        retVal[7][43] = new Pair(86, 89, true);
        retVal[6][44] = new Pair(88, 87, true);
        retVal[7][44] = new Pair(87, 88, true);
        retVal[6][45] = new Pair(93, 90, true);
        retVal[7][45] = new Pair(90, 93, true);
        retVal[6][46] = new Pair(92, 94, true);
        retVal[7][46] = new Pair(94, 92, true);
        retVal[6][47] = new Pair(91, 95, true);
        retVal[7][47] = new Pair(95, 91, true);
        retVal[6][48] = new Pair(99, 96, true);
        retVal[7][48] = new Pair(96, 99, true);
        retVal[6][49] = new Pair(98, 97, true);
        retVal[7][49] = new Pair(97, 98, true);
        retVal[8][0] = new Pair(4, 0, true);
        retVal[9][0] = new Pair(0, 4, true);
        retVal[8][1] = new Pair(3, 5, true);
        retVal[9][1] = new Pair(5, 3, true);
        retVal[8][2] = new Pair(2, 6, true);
        retVal[9][2] = new Pair(6, 2, true);
        retVal[8][3] = new Pair(1, 7, true);
        retVal[9][3] = new Pair(7, 1, true);
        retVal[8][4] = new Pair(9, 8, true);
        retVal[9][4] = new Pair(8, 9, true);
        retVal[8][5] = new Pair(14, 10, true);
        retVal[9][5] = new Pair(10, 14, true);
        retVal[8][6] = new Pair(13, 15, true);
        retVal[9][6] = new Pair(15, 13, true);
        retVal[8][7] = new Pair(12, 16, true);
        retVal[9][7] = new Pair(16, 12, true);
        retVal[8][8] = new Pair(11, 17, true);
        retVal[9][8] = new Pair(17, 11, true);
        retVal[8][9] = new Pair(19, 18, true);
        retVal[9][9] = new Pair(18, 19, true);
        retVal[8][10] = new Pair(24, 20, true);
        retVal[9][10] = new Pair(20, 24, true);
        retVal[8][11] = new Pair(23, 25, true);
        retVal[9][11] = new Pair(25, 23, true);
        retVal[8][12] = new Pair(22, 26, true);
        retVal[9][12] = new Pair(26, 22, true);
        retVal[8][13] = new Pair(21, 27, true);
        retVal[9][13] = new Pair(27, 21, true);
        retVal[8][14] = new Pair(29, 28, true);
        retVal[9][14] = new Pair(28, 29, true);
        retVal[8][15] = new Pair(34, 30, true);
        retVal[9][15] = new Pair(30, 34, true);
        retVal[8][16] = new Pair(33, 35, true);
        retVal[9][16] = new Pair(35, 33, true);
        retVal[8][17] = new Pair(32, 36, true);
        retVal[9][17] = new Pair(36, 32, true);
        retVal[8][18] = new Pair(31, 37, true);
        retVal[9][18] = new Pair(37, 31, true);
        retVal[8][19] = new Pair(39, 38, true);
        retVal[9][19] = new Pair(38, 39, true);
        retVal[8][20] = new Pair(44, 40, true);
        retVal[9][20] = new Pair(40, 44, true);
        retVal[8][21] = new Pair(43, 45, true);
        retVal[9][21] = new Pair(45, 43, true);
        retVal[8][22] = new Pair(42, 46, true);
        retVal[9][22] = new Pair(46, 42, true);
        retVal[8][23] = new Pair(41, 47, true);
        retVal[9][23] = new Pair(47, 41, true);
        retVal[8][24] = new Pair(49, 48, true);
        retVal[9][24] = new Pair(48, 49, true);
        retVal[8][25] = new Pair(54, 50, true);
        retVal[9][25] = new Pair(50, 54, true);
        retVal[8][26] = new Pair(53, 55, true);
        retVal[9][26] = new Pair(55, 53, true);
        retVal[8][27] = new Pair(52, 56, true);
        retVal[9][27] = new Pair(56, 52, true);
        retVal[8][28] = new Pair(51, 57, true);
        retVal[9][28] = new Pair(57, 51, true);
        retVal[8][29] = new Pair(59, 58, true);
        retVal[9][29] = new Pair(58, 59, true);
        retVal[8][30] = new Pair(64, 60, true);
        retVal[9][30] = new Pair(60, 64, true);
        retVal[8][31] = new Pair(63, 65, true);
        retVal[9][31] = new Pair(65, 63, true);
        retVal[8][32] = new Pair(62, 66, true);
        retVal[9][32] = new Pair(66, 62, true);
        retVal[8][33] = new Pair(61, 67, true);
        retVal[9][33] = new Pair(67, 61, true);
        retVal[8][34] = new Pair(69, 68, true);
        retVal[9][34] = new Pair(68, 69, true);
        retVal[8][35] = new Pair(74, 70, true);
        retVal[9][35] = new Pair(70, 74, true);
        retVal[8][36] = new Pair(73, 75, true);
        retVal[9][36] = new Pair(75, 73, true);
        retVal[8][37] = new Pair(72, 76, true);
        retVal[9][37] = new Pair(76, 72, true);
        retVal[8][38] = new Pair(71, 77, true);
        retVal[9][38] = new Pair(77, 71, true);
        retVal[8][39] = new Pair(79, 78, true);
        retVal[9][39] = new Pair(78, 79, true);
        retVal[8][40] = new Pair(84, 80, true);
        retVal[9][40] = new Pair(80, 84, true);
        retVal[8][41] = new Pair(83, 85, true);
        retVal[9][41] = new Pair(85, 83, true);
        retVal[8][42] = new Pair(82, 86, true);
        retVal[9][42] = new Pair(86, 82, true);
        retVal[8][43] = new Pair(81, 87, true);
        retVal[9][43] = new Pair(87, 81, true);
        retVal[8][44] = new Pair(89, 88, true);
        retVal[9][44] = new Pair(88, 89, true);
        retVal[8][45] = new Pair(94, 90, true);
        retVal[9][45] = new Pair(90, 94, true);
        retVal[8][46] = new Pair(93, 95, true);
        retVal[9][46] = new Pair(95, 93, true);
        retVal[8][47] = new Pair(92, 96, true);
        retVal[9][47] = new Pair(96, 92, true);
        retVal[8][48] = new Pair(91, 97, true);
        retVal[9][48] = new Pair(97, 91, true);
        retVal[8][49] = new Pair(99, 98, true);
        retVal[9][49] = new Pair(98, 99, true);
        retVal[10][0] = new Pair(5, 0, true);
        retVal[11][0] = new Pair(0, 5, true);
        retVal[10][1] = new Pair(4, 6, true);
        retVal[11][1] = new Pair(6, 4, true);
        retVal[10][2] = new Pair(3, 7, true);
        retVal[11][2] = new Pair(7, 3, true);
        retVal[10][3] = new Pair(2, 8, true);
        retVal[11][3] = new Pair(8, 2, true);
        retVal[10][4] = new Pair(1, 9, true);
        retVal[11][4] = new Pair(9, 1, true);
        retVal[10][5] = new Pair(15, 10, true);
        retVal[11][5] = new Pair(10, 15, true);
        retVal[10][6] = new Pair(14, 16, true);
        retVal[11][6] = new Pair(16, 14, true);
        retVal[10][7] = new Pair(13, 17, true);
        retVal[11][7] = new Pair(17, 13, true);
        retVal[10][8] = new Pair(12, 18, true);
        retVal[11][8] = new Pair(18, 12, true);
        retVal[10][9] = new Pair(11, 19, true);
        retVal[11][9] = new Pair(19, 11, true);
        retVal[10][10] = new Pair(25, 20, true);
        retVal[11][10] = new Pair(20, 25, true);
        retVal[10][11] = new Pair(24, 26, true);
        retVal[11][11] = new Pair(26, 24, true);
        retVal[10][12] = new Pair(23, 27, true);
        retVal[11][12] = new Pair(27, 23, true);
        retVal[10][13] = new Pair(22, 28, true);
        retVal[11][13] = new Pair(28, 22, true);
        retVal[10][14] = new Pair(21, 29, true);
        retVal[11][14] = new Pair(29, 21, true);
        retVal[10][15] = new Pair(35, 30, true);
        retVal[11][15] = new Pair(30, 35, true);
        retVal[10][16] = new Pair(34, 36, true);
        retVal[11][16] = new Pair(36, 34, true);
        retVal[10][17] = new Pair(33, 37, true);
        retVal[11][17] = new Pair(37, 33, true);
        retVal[10][18] = new Pair(32, 38, true);
        retVal[11][18] = new Pair(38, 32, true);
        retVal[10][19] = new Pair(31, 39, true);
        retVal[11][19] = new Pair(39, 31, true);
        retVal[10][20] = new Pair(45, 40, true);
        retVal[11][20] = new Pair(40, 45, true);
        retVal[10][21] = new Pair(44, 46, true);
        retVal[11][21] = new Pair(46, 44, true);
        retVal[10][22] = new Pair(43, 47, true);
        retVal[11][22] = new Pair(47, 43, true);
        retVal[10][23] = new Pair(42, 48, true);
        retVal[11][23] = new Pair(48, 42, true);
        retVal[10][24] = new Pair(41, 49, true);
        retVal[11][24] = new Pair(49, 41, true);
        retVal[10][25] = new Pair(55, 50, true);
        retVal[11][25] = new Pair(50, 55, true);
        retVal[10][26] = new Pair(54, 56, true);
        retVal[11][26] = new Pair(56, 54, true);
        retVal[10][27] = new Pair(53, 57, true);
        retVal[11][27] = new Pair(57, 53, true);
        retVal[10][28] = new Pair(52, 58, true);
        retVal[11][28] = new Pair(58, 52, true);
        retVal[10][29] = new Pair(51, 59, true);
        retVal[11][29] = new Pair(59, 51, true);
        retVal[10][30] = new Pair(65, 60, true);
        retVal[11][30] = new Pair(60, 65, true);
        retVal[10][31] = new Pair(64, 66, true);
        retVal[11][31] = new Pair(66, 64, true);
        retVal[10][32] = new Pair(63, 67, true);
        retVal[11][32] = new Pair(67, 63, true);
        retVal[10][33] = new Pair(62, 68, true);
        retVal[11][33] = new Pair(68, 62, true);
        retVal[10][34] = new Pair(61, 69, true);
        retVal[11][34] = new Pair(69, 61, true);
        retVal[10][35] = new Pair(75, 70, true);
        retVal[11][35] = new Pair(70, 75, true);
        retVal[10][36] = new Pair(74, 76, true);
        retVal[11][36] = new Pair(76, 74, true);
        retVal[10][37] = new Pair(73, 77, true);
        retVal[11][37] = new Pair(77, 73, true);
        retVal[10][38] = new Pair(72, 78, true);
        retVal[11][38] = new Pair(78, 72, true);
        retVal[10][39] = new Pair(71, 79, true);
        retVal[11][39] = new Pair(79, 71, true);
        retVal[10][40] = new Pair(85, 80, true);
        retVal[11][40] = new Pair(80, 85, true);
        retVal[10][41] = new Pair(84, 86, true);
        retVal[11][41] = new Pair(86, 84, true);
        retVal[10][42] = new Pair(83, 87, true);
        retVal[11][42] = new Pair(87, 83, true);
        retVal[10][43] = new Pair(82, 88, true);
        retVal[11][43] = new Pair(88, 82, true);
        retVal[10][44] = new Pair(81, 89, true);
        retVal[11][44] = new Pair(89, 81, true);
        retVal[10][45] = new Pair(95, 90, true);
        retVal[11][45] = new Pair(90, 95, true);
        retVal[10][46] = new Pair(94, 96, true);
        retVal[11][46] = new Pair(96, 94, true);
        retVal[10][47] = new Pair(93, 97, true);
        retVal[11][47] = new Pair(97, 93, true);
        retVal[10][48] = new Pair(92, 98, true);
        retVal[11][48] = new Pair(98, 92, true);
        retVal[10][49] = new Pair(91, 99, true);
        retVal[11][49] = new Pair(99, 91, true);
        retVal[12][0] = new Pair(6, 0, true);
        retVal[13][0] = new Pair(0, 6, true);
        retVal[12][1] = new Pair(5, 7, true);
        retVal[13][1] = new Pair(7, 5, true);
        retVal[12][2] = new Pair(4, 8, true);
        retVal[13][2] = new Pair(8, 4, true);
        retVal[12][3] = new Pair(3, 9, true);
        retVal[13][3] = new Pair(9, 3, true);
        retVal[12][4] = new Pair(2, 1, true);
        retVal[13][4] = new Pair(1, 2, true);
        retVal[12][5] = new Pair(16, 10, true);
        retVal[13][5] = new Pair(10, 16, true);
        retVal[12][6] = new Pair(15, 17, true);
        retVal[13][6] = new Pair(17, 15, true);
        retVal[12][7] = new Pair(14, 18, true);
        retVal[13][7] = new Pair(18, 14, true);
        retVal[12][8] = new Pair(13, 19, true);
        retVal[13][8] = new Pair(19, 13, true);
        retVal[12][9] = new Pair(12, 11, true);
        retVal[13][9] = new Pair(11, 12, true);
        retVal[12][10] = new Pair(26, 20, true);
        retVal[13][10] = new Pair(20, 26, true);
        retVal[12][11] = new Pair(25, 27, true);
        retVal[13][11] = new Pair(27, 25, true);
        retVal[12][12] = new Pair(24, 28, true);
        retVal[13][12] = new Pair(28, 24, true);
        retVal[12][13] = new Pair(23, 29, true);
        retVal[13][13] = new Pair(29, 23, true);
        retVal[12][14] = new Pair(22, 21, true);
        retVal[13][14] = new Pair(21, 22, true);
        retVal[12][15] = new Pair(36, 30, true);
        retVal[13][15] = new Pair(30, 36, true);
        retVal[12][16] = new Pair(35, 37, true);
        retVal[13][16] = new Pair(37, 35, true);
        retVal[12][17] = new Pair(34, 38, true);
        retVal[13][17] = new Pair(38, 34, true);
        retVal[12][18] = new Pair(33, 39, true);
        retVal[13][18] = new Pair(39, 33, true);
        retVal[12][19] = new Pair(32, 31, true);
        retVal[13][19] = new Pair(31, 32, true);
        retVal[12][20] = new Pair(46, 40, true);
        retVal[13][20] = new Pair(40, 46, true);
        retVal[12][21] = new Pair(45, 47, true);
        retVal[13][21] = new Pair(47, 45, true);
        retVal[12][22] = new Pair(44, 48, true);
        retVal[13][22] = new Pair(48, 44, true);
        retVal[12][23] = new Pair(43, 49, true);
        retVal[13][23] = new Pair(49, 43, true);
        retVal[12][24] = new Pair(42, 41, true);
        retVal[13][24] = new Pair(41, 42, true);
        retVal[12][25] = new Pair(56, 50, true);
        retVal[13][25] = new Pair(50, 56, true);
        retVal[12][26] = new Pair(55, 57, true);
        retVal[13][26] = new Pair(57, 55, true);
        retVal[12][27] = new Pair(54, 58, true);
        retVal[13][27] = new Pair(58, 54, true);
        retVal[12][28] = new Pair(53, 59, true);
        retVal[13][28] = new Pair(59, 53, true);
        retVal[12][29] = new Pair(52, 51, true);
        retVal[13][29] = new Pair(51, 52, true);
        retVal[12][30] = new Pair(66, 60, true);
        retVal[13][30] = new Pair(60, 66, true);
        retVal[12][31] = new Pair(65, 67, true);
        retVal[13][31] = new Pair(67, 65, true);
        retVal[12][32] = new Pair(64, 68, true);
        retVal[13][32] = new Pair(68, 64, true);
        retVal[12][33] = new Pair(63, 69, true);
        retVal[13][33] = new Pair(69, 63, true);
        retVal[12][34] = new Pair(62, 61, true);
        retVal[13][34] = new Pair(61, 62, true);
        retVal[12][35] = new Pair(76, 70, true);
        retVal[13][35] = new Pair(70, 76, true);
        retVal[12][36] = new Pair(75, 77, true);
        retVal[13][36] = new Pair(77, 75, true);
        retVal[12][37] = new Pair(74, 78, true);
        retVal[13][37] = new Pair(78, 74, true);
        retVal[12][38] = new Pair(73, 79, true);
        retVal[13][38] = new Pair(79, 73, true);
        retVal[12][39] = new Pair(72, 71, true);
        retVal[13][39] = new Pair(71, 72, true);
        retVal[12][40] = new Pair(86, 80, true);
        retVal[13][40] = new Pair(80, 86, true);
        retVal[12][41] = new Pair(85, 87, true);
        retVal[13][41] = new Pair(87, 85, true);
        retVal[12][42] = new Pair(84, 88, true);
        retVal[13][42] = new Pair(88, 84, true);
        retVal[12][43] = new Pair(83, 89, true);
        retVal[13][43] = new Pair(89, 83, true);
        retVal[12][44] = new Pair(82, 81, true);
        retVal[13][44] = new Pair(81, 82, true);
        retVal[12][45] = new Pair(96, 90, true);
        retVal[13][45] = new Pair(90, 96, true);
        retVal[12][46] = new Pair(95, 97, true);
        retVal[13][46] = new Pair(97, 95, true);
        retVal[12][47] = new Pair(94, 98, true);
        retVal[13][47] = new Pair(98, 94, true);
        retVal[12][48] = new Pair(93, 99, true);
        retVal[13][48] = new Pair(99, 93, true);
        retVal[12][49] = new Pair(92, 91, true);
        retVal[13][49] = new Pair(91, 92, true);
        retVal[14][0] = new Pair(7, 0, true);
        retVal[15][0] = new Pair(0, 7, true);
        retVal[14][1] = new Pair(6, 8, true);
        retVal[15][1] = new Pair(8, 6, true);
        retVal[14][2] = new Pair(5, 9, true);
        retVal[15][2] = new Pair(9, 5, true);
        retVal[14][3] = new Pair(4, 1, true);
        retVal[15][3] = new Pair(1, 4, true);
        retVal[14][4] = new Pair(3, 2, true);
        retVal[15][4] = new Pair(2, 3, true);
        retVal[14][5] = new Pair(17, 10, true);
        retVal[15][5] = new Pair(10, 17, true);
        retVal[14][6] = new Pair(16, 18, true);
        retVal[15][6] = new Pair(18, 16, true);
        retVal[14][7] = new Pair(15, 19, true);
        retVal[15][7] = new Pair(19, 15, true);
        retVal[14][8] = new Pair(14, 11, true);
        retVal[15][8] = new Pair(11, 14, true);
        retVal[14][9] = new Pair(13, 12, true);
        retVal[15][9] = new Pair(12, 13, true);
        retVal[14][10] = new Pair(27, 20, true);
        retVal[15][10] = new Pair(20, 27, true);
        retVal[14][11] = new Pair(26, 28, true);
        retVal[15][11] = new Pair(28, 26, true);
        retVal[14][12] = new Pair(25, 29, true);
        retVal[15][12] = new Pair(29, 25, true);
        retVal[14][13] = new Pair(24, 21, true);
        retVal[15][13] = new Pair(21, 24, true);
        retVal[14][14] = new Pair(23, 22, true);
        retVal[15][14] = new Pair(22, 23, true);
        retVal[14][15] = new Pair(37, 30, true);
        retVal[15][15] = new Pair(30, 37, true);
        retVal[14][16] = new Pair(36, 38, true);
        retVal[15][16] = new Pair(38, 36, true);
        retVal[14][17] = new Pair(35, 39, true);
        retVal[15][17] = new Pair(39, 35, true);
        retVal[14][18] = new Pair(34, 31, true);
        retVal[15][18] = new Pair(31, 34, true);
        retVal[14][19] = new Pair(33, 32, true);
        retVal[15][19] = new Pair(32, 33, true);
        retVal[14][20] = new Pair(47, 40, true);
        retVal[15][20] = new Pair(40, 47, true);
        retVal[14][21] = new Pair(46, 48, true);
        retVal[15][21] = new Pair(48, 46, true);
        retVal[14][22] = new Pair(45, 49, true);
        retVal[15][22] = new Pair(49, 45, true);
        retVal[14][23] = new Pair(44, 41, true);
        retVal[15][23] = new Pair(41, 44, true);
        retVal[14][24] = new Pair(43, 42, true);
        retVal[15][24] = new Pair(42, 43, true);
        retVal[14][25] = new Pair(57, 50, true);
        retVal[15][25] = new Pair(50, 57, true);
        retVal[14][26] = new Pair(56, 58, true);
        retVal[15][26] = new Pair(58, 56, true);
        retVal[14][27] = new Pair(55, 59, true);
        retVal[15][27] = new Pair(59, 55, true);
        retVal[14][28] = new Pair(54, 51, true);
        retVal[15][28] = new Pair(51, 54, true);
        retVal[14][29] = new Pair(53, 52, true);
        retVal[15][29] = new Pair(52, 53, true);
        retVal[14][30] = new Pair(67, 60, true);
        retVal[15][30] = new Pair(60, 67, true);
        retVal[14][31] = new Pair(66, 68, true);
        retVal[15][31] = new Pair(68, 66, true);
        retVal[14][32] = new Pair(65, 69, true);
        retVal[15][32] = new Pair(69, 65, true);
        retVal[14][33] = new Pair(64, 61, true);
        retVal[15][33] = new Pair(61, 64, true);
        retVal[14][34] = new Pair(63, 62, true);
        retVal[15][34] = new Pair(62, 63, true);
        retVal[14][35] = new Pair(77, 70, true);
        retVal[15][35] = new Pair(70, 77, true);
        retVal[14][36] = new Pair(76, 78, true);
        retVal[15][36] = new Pair(78, 76, true);
        retVal[14][37] = new Pair(75, 79, true);
        retVal[15][37] = new Pair(79, 75, true);
        retVal[14][38] = new Pair(74, 71, true);
        retVal[15][38] = new Pair(71, 74, true);
        retVal[14][39] = new Pair(73, 72, true);
        retVal[15][39] = new Pair(72, 73, true);
        retVal[14][40] = new Pair(87, 80, true);
        retVal[15][40] = new Pair(80, 87, true);
        retVal[14][41] = new Pair(86, 88, true);
        retVal[15][41] = new Pair(88, 86, true);
        retVal[14][42] = new Pair(85, 89, true);
        retVal[15][42] = new Pair(89, 85, true);
        retVal[14][43] = new Pair(84, 81, true);
        retVal[15][43] = new Pair(81, 84, true);
        retVal[14][44] = new Pair(83, 82, true);
        retVal[15][44] = new Pair(82, 83, true);
        retVal[14][45] = new Pair(97, 90, true);
        retVal[15][45] = new Pair(90, 97, true);
        retVal[14][46] = new Pair(96, 98, true);
        retVal[15][46] = new Pair(98, 96, true);
        retVal[14][47] = new Pair(95, 99, true);
        retVal[15][47] = new Pair(99, 95, true);
        retVal[14][48] = new Pair(94, 91, true);
        retVal[15][48] = new Pair(91, 94, true);
        retVal[14][49] = new Pair(93, 92, true);
        retVal[15][49] = new Pair(92, 93, true);
        retVal[16][0] = new Pair(8, 0, true);
        retVal[17][0] = new Pair(0, 8, true);
        retVal[16][1] = new Pair(7, 9, true);
        retVal[17][1] = new Pair(9, 7, true);
        retVal[16][2] = new Pair(6, 1, true);
        retVal[17][2] = new Pair(1, 6, true);
        retVal[16][3] = new Pair(5, 2, true);
        retVal[17][3] = new Pair(2, 5, true);
        retVal[16][4] = new Pair(4, 3, true);
        retVal[17][4] = new Pair(3, 4, true);
        retVal[16][5] = new Pair(18, 10, true);
        retVal[17][5] = new Pair(10, 18, true);
        retVal[16][6] = new Pair(17, 19, true);
        retVal[17][6] = new Pair(19, 17, true);
        retVal[16][7] = new Pair(16, 11, true);
        retVal[17][7] = new Pair(11, 16, true);
        retVal[16][8] = new Pair(15, 12, true);
        retVal[17][8] = new Pair(12, 15, true);
        retVal[16][9] = new Pair(14, 13, true);
        retVal[17][9] = new Pair(13, 14, true);
        retVal[16][10] = new Pair(28, 20, true);
        retVal[17][10] = new Pair(20, 28, true);
        retVal[16][11] = new Pair(27, 29, true);
        retVal[17][11] = new Pair(29, 27, true);
        retVal[16][12] = new Pair(26, 21, true);
        retVal[17][12] = new Pair(21, 26, true);
        retVal[16][13] = new Pair(25, 22, true);
        retVal[17][13] = new Pair(22, 25, true);
        retVal[16][14] = new Pair(24, 23, true);
        retVal[17][14] = new Pair(23, 24, true);
        retVal[16][15] = new Pair(38, 30, true);
        retVal[17][15] = new Pair(30, 38, true);
        retVal[16][16] = new Pair(37, 39, true);
        retVal[17][16] = new Pair(39, 37, true);
        retVal[16][17] = new Pair(36, 31, true);
        retVal[17][17] = new Pair(31, 36, true);
        retVal[16][18] = new Pair(35, 32, true);
        retVal[17][18] = new Pair(32, 35, true);
        retVal[16][19] = new Pair(34, 33, true);
        retVal[17][19] = new Pair(33, 34, true);
        retVal[16][20] = new Pair(48, 40, true);
        retVal[17][20] = new Pair(40, 48, true);
        retVal[16][21] = new Pair(47, 49, true);
        retVal[17][21] = new Pair(49, 47, true);
        retVal[16][22] = new Pair(46, 41, true);
        retVal[17][22] = new Pair(41, 46, true);
        retVal[16][23] = new Pair(45, 42, true);
        retVal[17][23] = new Pair(42, 45, true);
        retVal[16][24] = new Pair(44, 43, true);
        retVal[17][24] = new Pair(43, 44, true);
        retVal[16][25] = new Pair(58, 50, true);
        retVal[17][25] = new Pair(50, 58, true);
        retVal[16][26] = new Pair(57, 59, true);
        retVal[17][26] = new Pair(59, 57, true);
        retVal[16][27] = new Pair(56, 51, true);
        retVal[17][27] = new Pair(51, 56, true);
        retVal[16][28] = new Pair(55, 52, true);
        retVal[17][28] = new Pair(52, 55, true);
        retVal[16][29] = new Pair(54, 53, true);
        retVal[17][29] = new Pair(53, 54, true);
        retVal[16][30] = new Pair(68, 60, true);
        retVal[17][30] = new Pair(60, 68, true);
        retVal[16][31] = new Pair(67, 69, true);
        retVal[17][31] = new Pair(69, 67, true);
        retVal[16][32] = new Pair(66, 61, true);
        retVal[17][32] = new Pair(61, 66, true);
        retVal[16][33] = new Pair(65, 62, true);
        retVal[17][33] = new Pair(62, 65, true);
        retVal[16][34] = new Pair(64, 63, true);
        retVal[17][34] = new Pair(63, 64, true);
        retVal[16][35] = new Pair(78, 70, true);
        retVal[17][35] = new Pair(70, 78, true);
        retVal[16][36] = new Pair(77, 79, true);
        retVal[17][36] = new Pair(79, 77, true);
        retVal[16][37] = new Pair(76, 71, true);
        retVal[17][37] = new Pair(71, 76, true);
        retVal[16][38] = new Pair(75, 72, true);
        retVal[17][38] = new Pair(72, 75, true);
        retVal[16][39] = new Pair(74, 73, true);
        retVal[17][39] = new Pair(73, 74, true);
        retVal[16][40] = new Pair(88, 80, true);
        retVal[17][40] = new Pair(80, 88, true);
        retVal[16][41] = new Pair(87, 89, true);
        retVal[17][41] = new Pair(89, 87, true);
        retVal[16][42] = new Pair(86, 81, true);
        retVal[17][42] = new Pair(81, 86, true);
        retVal[16][43] = new Pair(85, 82, true);
        retVal[17][43] = new Pair(82, 85, true);
        retVal[16][44] = new Pair(84, 83, true);
        retVal[17][44] = new Pair(83, 84, true);
        retVal[16][45] = new Pair(98, 90, true);
        retVal[17][45] = new Pair(90, 98, true);
        retVal[16][46] = new Pair(97, 99, true);
        retVal[17][46] = new Pair(99, 97, true);
        retVal[16][47] = new Pair(96, 91, true);
        retVal[17][47] = new Pair(91, 96, true);
        retVal[16][48] = new Pair(95, 92, true);
        retVal[17][48] = new Pair(92, 95, true);
        retVal[16][49] = new Pair(94, 93, true);
        retVal[17][49] = new Pair(93, 94, true);

        return retVal;
    }
    private List<Pair[]> GetGames()
    {
        bool problem = true;
        List<Pair[]> retVal = null;
        while (problem)
        {
            problem = false;
            retVal = new List<Pair[]>();

            //NUM GAMES = 14

            for (int i = 0; i < 14; i++)
            {
                retVal.Add(new Pair[50]);
            }



            bool[,] previouslyPlayed = new bool[100,100];
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (i / 10 == j / 10)
                    {
                        previouslyPlayed[i,j] = true;
                    }
                }
            }
            for (int i = 0; i < retVal.Count; i++)
            {
                List<int> teamsYetToPlay = Count(100);
                teamsYetToPlay.Shuffle(r);
                for (int j = 0; j < retVal[i].Length; j++)
                {
                    int firstTeam = teamsYetToPlay[0];
                    teamsYetToPlay.RemoveAt(0);
                    int secondTeam;
                    int counter = 0;
                    while (true)
                    {
                        secondTeam = teamsYetToPlay[r.Next(teamsYetToPlay.Count)];
                        if (!previouslyPlayed[firstTeam,secondTeam]) break;
                        counter++;
                        if (counter == 10000) break;
                    }
                    if (counter == 10000)
                    {
                        problem = true;
                        break;
                    }
                    teamsYetToPlay.Remove(secondTeam);
                    previouslyPlayed[firstTeam,secondTeam] = true;
                    previouslyPlayed[secondTeam,firstTeam] = true;
                    retVal[i][j] = new Pair(firstTeam, secondTeam);
                }
                if (problem) break;
            }
        }



        return retVal;
    }

    private List<int> Count(int limit)
    {
        List<int> retVal = new List<int>();
        for (int i = 0; i < limit; i++)
        {
            retVal.Add(i);
        }
        return retVal;
    }
    public bool executeGame(bool b, int i, int j)
    {
        bool retVal = false;
        int away = teams[i].lastThreeGames(-1);
        int home = teams[j].lastThreeGames(-1);

        teams[i].CollegeInjuries();
        teams[j].CollegeInjuries();

        int randomValue = r.Next(0, 100);
        if (away == 0 && home == 0)
        {
            if (randomValue < 10)
            {
                teams[i].setModifier(new BounceBackGame());
                teams[j].setModifier(new None());
            }
            else if (randomValue < 30)
            {
                teams[i].setModifier(new DefensiveNightmare());
                teams[j].setModifier(new DefensiveNightmare());
            }
            else if (randomValue < 40)
            {
                teams[i].setModifier(new None());
                teams[j].setModifier(new BounceBackGame());
            }
            else
            {
                teams[i].setModifier(new None());
                teams[j].setModifier(new None());
            }
        }
        else if ((away == 0 || away == 1) && home == 3)
        {
            if (randomValue < 15)
            {
                teams[i].setModifier(new BounceBackGame());
                teams[j].setModifier(new LetDownGame());
            }
            else if (randomValue < 25)
            {
                teams[i].setModifier(new StrugglesContinue());
                teams[j].setModifier(new ContinueRolling());
            }
            else
            {
                teams[i].setModifier(new None());
                teams[j].setModifier(new None());
            }

        }
        else if ((home == 0 || home == 1) && away == 3)
        {
            if (randomValue < 15)
            {
                teams[j].setModifier(new BounceBackGame());
                teams[i].setModifier(new LetDownGame());
            }
            else if (randomValue < 25)
            {
                teams[j].setModifier(new StrugglesContinue());
                teams[i].setModifier(new ContinueRolling());
            }
            else
            {
                teams[j].setModifier(new None());
                teams[i].setModifier(new None());
            }
        }
        else if (away == 3 && home == 3)
        {
            if (randomValue < 5)
            {
                teams[i].setModifier(new ContinueRolling());
                teams[j].setModifier(new LetDownGame());
            }
            else if (randomValue < 10)
            {
                teams[i].setModifier(new LetDownGame());
                teams[j].setModifier(new ContinueRolling());
            }
            else
            {
                teams[i].setModifier(new None());
                teams[j].setModifier(new None());
            }

        }
        else
        {
            if (randomValue < 12)
            {
                teams[i].setModifier(new DefensiveNightmare());
                teams[j].setModifier(new None());
            }
            else if (randomValue < 25)
            {
                teams[i].setModifier(new OffenisveNightmare());
                teams[j].setModifier(new OffenisveNightmare());
            }
            else
            {
                teams[i].setModifier(new None());
                teams[j].setModifier(new None());
            }
        }
        teams[i].addModifier(new HomeTeam());
        teams[i].addModifier(teams[i].getCoachModifier());
        teams[j].addModifier(teams[j].getCoachModifier());
        gameWriter gameWriter = new gameWriter(-1);

        game newGame = new game(gameWriter, teams[i], teams[j], r);

        teams[i].AddResult(j, newGame.getAwayTeamScore(), newGame.getHomeTeamScore());
        teams[j].AddResult(i, newGame.getHomeTeamScore(), newGame.getAwayTeamScore());
        
        for (int k = 0; k < teams[i].getSize(); k++)
        {
            teams[i].getPlayer(k).resetGameStats(teams[i], teams[j]);
        }
        for (int k = 0; k < teams[j].getSize(); k++)
        {
            teams[j].getPlayer(k).resetGameStats(teams[j], teams[i]);
        }
        return retVal;
    }
}
[Serializable]
internal class Pair
{
    public int x, y;
    public double dx, dy;
    public bool conferenceGame;
    public Pair(int x, int y)
    {
        this.x = x;
        this.y = y;
        dx = x;
        dy = y;
        conferenceGame = false;
    }
    public Pair(double x, double y)
    {
        dx = x;
        dy = y;
        conferenceGame = false;

    }
    public Pair(int x, int y, bool conference)
    {
        this.x = x;
        this.y = y;
        dx = x;
        dy = y;
        conferenceGame = conference;
    }

}
[Serializable]
public static class IEnumerableExtensions
{

    public static void Shuffle<T>(this IList<T> list, FormulaBasketball.Random r)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = r.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}