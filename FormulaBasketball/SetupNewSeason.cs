using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SetupNewSeason
{
    private createTeams create;
    private FreeAgents freeAgents;
    private FormulaBasketball.Random r;
    private List<player>[] playersByPos;
    public SetupNewSeason(createTeams create, FormulaBasketball.Random r)
    {
        this.create = create;
        this.r = r;
        freeAgents = new FreeAgents();
        playersByPos = new List<player>[5];
        freeAgents.Add(create.getFreeAgents().GetAllPlayers());
        freeAgents.Add(create.GetRookies());
        SetAffiliated();
        ClearTeams();
        AdvanceYear();
        MovePlayersToTeams();
        /*ResizeRoster();

        //CalculatePositionRank();

        PrintInformation();

        FindBestPlayers();

        CalculateHighestPayroll("topDLeaguePayrolls.txt", create.getDLeagueTeams());
        CalculateHighestPayroll("topPayrolls.txt", create.getTeams());

        CalculateBestOveralls("topOveralls.txt", create.getTeams());
        CalculateBestOveralls("topDLeaugeOveralls.txt", create.getDLeagueTeams());

        FindStarterAverages("averageStarters.txt", create.getTeams());
        FindStarterAverages("dLeagueAverageStarters.txt", create.getDLeagueTeams());

        PrintWikiInfo();

        //GenerateFIBUTeams();*/
    }
    public SetupNewSeason(createTeams create, FormulaBasketball.Random r, FreeAgents free)
    {
        this.create = create;
        this.r = r;
        this.freeAgents = free;
        playersByPos = new List<player>[5];
        ResizeRoster();

        CalculatePositionRank();

        PrintInformation();

        FindBestPlayers();

        CalculateHighestPayroll("topDLeaguePayrolls.txt", create.getDLeagueTeams());
        CalculateHighestPayroll("topPayrolls.txt", create.getTeams());

        CalculateBestOveralls("topOveralls.txt", create.getTeams());
        CalculateBestOveralls("topDLeaugeOveralls.txt", create.getDLeagueTeams());

        FindStarterAverages("averageStarters.txt", create.getTeams());
        FindStarterAverages("dLeagueAverageStarters.txt", create.getDLeagueTeams());

        PrintWikiInfo();
    }

    public SetupNewSeason()
    {
        create = formulaBasketball.create;
        freeAgents = create.getFreeAgents();
        PrintInformation();
    }

    private void CalculateBestOveralls(string fileName, List<team> teams)
    {
        List<StartersOveralls> starters = new List<StartersOveralls>();
        foreach (team team in teams)
        {
            starters.Add(new StartersOveralls(team.GetStarterOveralls(), team.ToString()));
        }
        starters.Sort();
        string toWrite = "";

        foreach (StartersOveralls overalls in starters)
        {
            toWrite += overalls.ToString();
        }
        File.WriteAllText(fileName, toWrite);
    }
    private void GenerateFIBUTeams()
    {
        List<team> FIBUteams = DeSerializeObject("FIBUteams.fibudata");/*new List<team>();

        foreach (Country country in Enum.GetValues(typeof(Country)))
        {
            FIBUTeam nextTeam = new FIBUTeam("" + country, r);
            List<player> players = FindBestPlayersByCountry(country);
            foreach (player p in players)
            {
                nextTeam.ConditionalAddPlayer(p);
            }
            nextTeam.Reorder(country);
            nextTeam.Reorder(country);
            FIBUteams.Add(nextTeam);
        }
        FIBUteams.Sort();
        FIBUteams.RemoveAt(39);
        SerializeObject(FIBUteams, "FIBUteams.fibudata");*/
        List<team> loviniosa = new List<team>();
        loviniosa.Add(FIBUteams[9]);
        loviniosa.Add(FIBUteams[24]);
        loviniosa.Add(FIBUteams[33]);
        loviniosa.Add(FIBUteams[34]);
        loviniosa.Add(FIBUteams[41]);

        List<team> amaltheans = new List<team>();
        amaltheans.Add(FIBUteams[13]);
        amaltheans.Add(FIBUteams[16]);
        amaltheans.Add(FIBUteams[28]);
        amaltheans.Add(FIBUteams[31]);
        amaltheans.Add(FIBUteams[35]);
        amaltheans.Add(FIBUteams[45]);
        amaltheans.Add(FIBUteams[51]);

        List<team> lysteriok = new List<team>();
        lysteriok.Add(FIBUteams[19]);
        lysteriok.Add(FIBUteams[22]);
        lysteriok.Add(FIBUteams[27]);
        lysteriok.Add(FIBUteams[44]);
        lysteriok.Add(FIBUteams[50]);

        List<team> Amaio = new List<team>();
        Amaio.Add(FIBUteams[14]);
        Amaio.Add(FIBUteams[17]);
        Amaio.Add(FIBUteams[26]);
        Amaio.Add(FIBUteams[29]);
        Amaio.Add(FIBUteams[32]);
        Amaio.Add(FIBUteams[46]);
        Amaio.Add(FIBUteams[47]);
        Amaio.Add(FIBUteams[48]);

        List<team> ariokoczallimalia = new List<team>();
        ariokoczallimalia.Add(FIBUteams[0]);
        ariokoczallimalia.Add(FIBUteams[1]);
        ariokoczallimalia.Add(FIBUteams[3]);
        ariokoczallimalia.Add(FIBUteams[11]);
        ariokoczallimalia.Add(FIBUteams[12]);
        ariokoczallimalia.Add(FIBUteams[25]);
        ariokoczallimalia.Add(FIBUteams[37]);
        ariokoczallimalia.Add(FIBUteams[49]);

        List<team> blagua = new List<team>();
        blagua.Add(FIBUteams[4]);
        blagua.Add(FIBUteams[8]);
        blagua.Add(FIBUteams[10]);
        blagua.Add(FIBUteams[21]);
        blagua.Add(FIBUteams[30]);
        blagua.Add(FIBUteams[36]);
        blagua.Add(FIBUteams[39]);
        blagua.Add(FIBUteams[42]);
        blagua.Add(FIBUteams[43]);

        List<team> serkrs = new List<team>();
        serkrs.Add(FIBUteams[2]);
        serkrs.Add(FIBUteams[5]);
        serkrs.Add(FIBUteams[6]);
        serkrs.Add(FIBUteams[7]);
        serkrs.Add(FIBUteams[15]);
        serkrs.Add(FIBUteams[18]);
        serkrs.Add(FIBUteams[20]);
        serkrs.Add(FIBUteams[23]);
        serkrs.Add(FIBUteams[38]);
        serkrs.Add(FIBUteams[40]);

        PlayMatches(loviniosa);
        loviniosa.Reverse();
        PlayMatches(loviniosa);

        PlayMatches(amaltheans);
        amaltheans.Reverse();
        PlayMatches(amaltheans);

        PlayMatches(lysteriok);
        lysteriok.Reverse();
        PlayMatches(lysteriok);

        PlayMatches(Amaio);
        Amaio.Reverse();
        PlayMatches(Amaio);

        PlayMatches(ariokoczallimalia);
        ariokoczallimalia.Reverse();
        PlayMatches(ariokoczallimalia);

        PlayMatches(blagua);
        blagua.Reverse();
        PlayMatches(blagua);

        PlayMatches(serkrs);
        serkrs.Reverse();
        PlayMatches(serkrs);
        Console.WriteLine("Loviniosa: ");
        loviniosa.Sort();
        int seed = 1;
        foreach(team team in loviniosa)
        {
            Console.WriteLine(team.ToString() + ": " + team.getWins() + " - " + team.getLosses());
            team.setConferenceRank(seed);
            seed++;
        }
        Console.WriteLine("Amaltheans: ");
        amaltheans.Sort();
        seed = 1;
        foreach (team team in amaltheans)
        {
            Console.WriteLine(team.ToString() + ": " + team.getWins() + " - " + team.getLosses());
            team.setConferenceRank(seed);
            seed++;
        }

        lysteriok.Sort();
        seed = 1;
        Console.WriteLine("Lysteriok: ");
        foreach (team team in lysteriok)
        {
            Console.WriteLine(team.ToString() + ": " + team.getWins() + " - " + team.getLosses());
            team.setConferenceRank(seed);
            seed++;
        }
        Console.WriteLine("Amaio: ");
        Amaio.Sort();
        seed = 1;
        foreach (team team in Amaio)
        {
            Console.WriteLine(team.ToString() + ": " + team.getWins() + " - " + team.getLosses());
            team.setConferenceRank(seed);
            seed++;
        }
        Console.WriteLine("Ariokoczallimalia: ");
        ariokoczallimalia.Sort();
        seed = 1;
        foreach (team team in ariokoczallimalia)
        {
            Console.WriteLine(team.ToString() + ": " + team.getWins() + " - " + team.getLosses());
            team.setConferenceRank(seed);
            seed++;
        }
        Console.WriteLine("Blagua: ");
        blagua.Sort();
        seed = 1;
        foreach (team team in blagua)
        {
            Console.WriteLine(team.ToString() + ": " + team.getWins() + " - " + team.getLosses());
            team.setConferenceRank(seed);
            seed++;
        }
        Console.WriteLine("Serkrs: ");
        serkrs.Sort();
        seed = 1;
        foreach (team team in serkrs)
        {
            Console.WriteLine(team.ToString() + ": " + team.getWins() + " - " + team.getLosses());
            team.setConferenceRank(seed);
            seed++;
        }


        PrintRosters(FIBUteams, "FibuTeams.csv");

        List<team> finalFIBUTeams = new List<team>();
        Console.WriteLine("Loviniosa Playoffs: ");
        finalFIBUTeams.AddRange(PlayFIBUTournament(loviniosa, 3));
        Console.WriteLine("Amaltheans Playoffs: ");
        finalFIBUTeams.AddRange(PlayFIBUTournament(amaltheans, 4));
        Console.WriteLine("Lysteriok Playoffs: ");
        finalFIBUTeams.AddRange(PlayFIBUTournament(lysteriok, 3));
        Console.WriteLine("Amaio Playoffs: ");
        finalFIBUTeams.AddRange(PlayFIBUTournament(Amaio, 5));
        Console.WriteLine("Ariokoczallimalia Playoffs: ");
        finalFIBUTeams.AddRange(PlayFIBUTournament(ariokoczallimalia, 5));
        Console.WriteLine("Blagua Playoffs: ");
        finalFIBUTeams.AddRange(PlayFIBUTournament(blagua, 6));
        Console.WriteLine("Serkrs Playoffs: ");
        finalFIBUTeams.AddRange(PlayFIBUTournament(serkrs, 6));

        foreach(team team in finalFIBUTeams)
        {
            Console.WriteLine(team);
        }
        
    }
    private void PlayMatches(List<team> ListTeam)
    {
        if (ListTeam.Count % 2 != 0)
        {
            ListTeam.Add(null); // If odd number of teams add a dummy
        }
        int amountOfGames = ListTeam.Count - 1;
        List<int> nums = new List<int>();
        nums.AddRange(Count(ListTeam.Count));

        while(amountOfGames != 0)
        {
            for (int i = 0; i < nums.Count / 2; i++)
            {
                if(ListTeam[nums[i]] != null &&  ListTeam[nums[nums.Count - (i + 1)]] != null)
                    executeGame(ListTeam[nums[i]], ListTeam[nums[nums.Count - (i + 1)]]);
            }

            int number = nums[nums.Count - 1];

            nums.Remove(number);
            nums.Insert(1, number);

            amountOfGames--;
        }
        

        ListTeam.Remove(null);
    }
    private List<team> PlayFIBUTournament(List<team> division, int teamsPassing)
    {
        List<team> advancing = new List<team>();

        while(division.Count != 10)
        {
            division.Add(null);
        }

        team[] results;
        List<team> roundLosers = new List<team>();
        results = PlaySeries(division[7], division[8]);        
        team gameOneWinner = results[0];
        roundLosers.Add(results[1]);
        results = PlaySeries(division[6], division[9]);
        team gameTwoWinner = results[0];
        roundLosers.Add(results[1]);

        if(roundLosers[0] != null && roundLosers[1] != null)
        {
            if(roundLosers[0].getConferenceRank() > roundLosers[1].getConferenceRank())
            {
                advancing.Add(roundLosers[0]);
                advancing.Add(roundLosers[1]);
            }
            else
            {
                advancing.Add(roundLosers[1]);
                advancing.Add(roundLosers[0]);
            }
        }
        else if (roundLosers[0] != null) advancing.Add(roundLosers[0]);
        else if (roundLosers[1] != null) advancing.Add(roundLosers[1]);
        


        roundLosers = new List<team>();
        results = PlaySeries(gameOneWinner, division[0]);
        gameOneWinner = results[0];
        roundLosers.Add(results[1]);
        results = PlaySeries(gameTwoWinner, division[1]);
        gameTwoWinner = results[0];
        roundLosers.Add(results[1]);
        results = PlaySeries(division[2], division[5]);
        team gameThreeWinner = results[0];
        roundLosers.Add(results[1]);
        results = PlaySeries(division[3], division[4]);
        team gameFourWinner = results[0];
        roundLosers.Add(results[1]);

        while (roundLosers.Remove(null)) ;

        while(roundLosers.Count != 0)
        {
            team team = null;
            int rank = 0;
            foreach(team t in roundLosers)
            {
                if(rank < t.getConferenceRank())
                {
                    rank = t.getConferenceRank();
                    team = t;
                }
            }
            roundLosers.Remove(team);
            advancing.Add(team);
        }

        results = PlaySeries(gameOneWinner, gameFourWinner);
        gameOneWinner = results[0];
        gameFourWinner = results[1];
        results = PlaySeries(gameTwoWinner, gameThreeWinner);
        gameTwoWinner = results[0];
        gameThreeWinner = results[1];

        results = PlaySeries(gameFourWinner, gameThreeWinner);
        advancing.Add(results[1]);
        advancing.Add(results[0]);

        results = PlaySeries(gameOneWinner, gameTwoWinner);
        advancing.Add(results[1]);
        advancing.Add(results[0]);

        advancing.Reverse();

        advancing.RemoveRange(teamsPassing, advancing.Count - teamsPassing);

        

        return advancing;
    }
    private team[] PlaySeries(team teamOne, team teamTwo, int gamesToWin = 2)
    {
        if (teamOne == null && teamTwo == null)
        {
            return new team[]{null, null};;
        }
        else if (teamOne == null) return new team[]{teamTwo, null};
        else if (teamTwo == null) return new team[]{teamOne, null};

        team higherSeed, lowerSeed;
        int higherSeedWins = 0, lowerSeedWins = 0;
        if(teamOne.getConferenceRank() > teamTwo.getConferenceRank())
        {
            higherSeed = teamTwo;
            lowerSeed = teamOne;
        }
        else
        {
            higherSeed = teamOne;
            lowerSeed = teamTwo;
        }

        if (executeGame(higherSeed, lowerSeed)) lowerSeedWins++;
        else higherSeedWins++;

        if (executeGame(lowerSeed, higherSeed)) higherSeedWins++;
        else lowerSeedWins++;

        if(higherSeedWins == 1)
        {
            if (executeGame(lowerSeed, higherSeed)) higherSeedWins++;
            else lowerSeedWins++;
        }


        if (higherSeedWins == gamesToWin)
        {
            string result = String.Format("{0} seed {1} beats {2} seed {3} {4}-{5}",
                                   higherSeed.getConferenceRank(), higherSeed.ToString(), lowerSeed.getConferenceRank(), lowerSeed.ToString(), higherSeedWins, lowerSeedWins);
            Console.WriteLine(result);
            return new team[]{higherSeed, lowerSeed};
        }
        else
        {
            string result = String.Format("{0} seed {1} beats {2} seed {3} {4}-{5}",
                                   lowerSeed.getConferenceRank(), lowerSeed.ToString(), higherSeed.getConferenceRank(), higherSeed.ToString(), lowerSeedWins, higherSeedWins);
            Console.WriteLine(result);
            return new team[]{lowerSeed,higherSeed};
        }
    }
    private List<int> Count(int num)
    {
        List<int> retVal = new List<int>();
        for(int i = 0; i < num; i++)
        {
            retVal.Add(i);
        }
        return retVal;
    }
    // second team is home
    private bool executeGame(team team1, team team2)
    {
        int away = team1.lastThreeGames(-1);
        int home = team2.lastThreeGames(-1);



        int randomValue = r.Next(0, 100);
        if (away == 0 && home == 0)
        {
            if (randomValue < 10)
            {
                team1.setModifier(new BounceBackGame());
                team2.setModifier(new None());
            }
            else if (randomValue < 30)
            {
                team1.setModifier(new DefensiveNightmare());
                team2.setModifier(new DefensiveNightmare());
            }
            else if (randomValue < 40)
            {
                team1.setModifier(new None());
                team2.setModifier(new BounceBackGame());
            }
            else
            {
                team1.setModifier(new None());
                team2.setModifier(new None());
            }
        }
        else if ((away == 0 || away == 1) && home == 3)
        {
            if (randomValue < 15)
            {
                team1.setModifier(new BounceBackGame());
                team2.setModifier(new LetDownGame());
            }
            else if (randomValue < 25)
            {
                team1.setModifier(new StrugglesContinue());
                team2.setModifier(new ContinueRolling());
            }
            else
            {
                team1.setModifier(new None());
                team2.setModifier(new None());
            }

        }
        else if ((home == 0 || home == 1) && away == 3)
        {
            if (randomValue < 15)
            {
                team2.setModifier(new BounceBackGame());
                team1.setModifier(new LetDownGame());
            }
            else if (randomValue < 25)
            {
                team2.setModifier(new StrugglesContinue());
                team1.setModifier(new ContinueRolling());
            }
            else
            {
                team2.setModifier(new None());
                team1.setModifier(new None());
            }
        }
        else if (away == 3 && home == 3)
        {
            if (randomValue < 5)
            {
                team1.setModifier(new ContinueRolling());
                team2.setModifier(new LetDownGame());
            }
            else if (randomValue < 10)
            {
                team1.setModifier(new LetDownGame());
                team2.setModifier(new ContinueRolling());
            }
            else
            {
                team1.setModifier(new None());
                team2.setModifier(new None());
            }

        }
        else
        {
            if (randomValue < 12)
            {
                team1.setModifier(new DefensiveNightmare());
                team2.setModifier(new None());
            }
            else if (randomValue < 25)
            {
                team1.setModifier(new OffenisveNightmare());
                team2.setModifier(new OffenisveNightmare());
            }
            else
            {
                team1.setModifier(new None());
                team2.setModifier(new None());
            }
        }
        team2.addModifier(new HomeTeam());
        team1.addModifier(team1.getCoachModifier());
        team2.addModifier(team2.getCoachModifier());
        game newGame = new game(null, team1, team2, r);



        team1.AddResult(0, newGame.getAwayTeamScore(), newGame.getHomeTeamScore());
        team2.AddResult(0, newGame.getHomeTeamScore(), newGame.getAwayTeamScore());


        for (int k = 0; k < team1.getSize(); k++)
        {
            team1.getPlayer(k).resetGameStats();
        }
        for (int k = 0; k < team2.getSize(); k++)
        {
            team2.getPlayer(k).resetGameStats();
        }
        return newGame.getHomeTeamScore() > newGame.getAwayTeamScore();
    }

    /// <summary>
    /// Serializes an object.
    /// </summary>
    /// <param name="serializableObject"></param>
    /// <param name="fileName"></param>
    private void SerializeObject(List<team> serializableObject, string fileName)
    {
        FileStream fs = new FileStream(fileName, FileMode.Create);

        // Construct a BinaryFormatter and use it to serialize the data to the stream.
        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            formatter.Serialize(fs, serializableObject);
        }
        catch (SerializationException e)
        {
            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            fs.Close();
        }
    }
    /// <summary>
    /// Deserializes a binary file into an object list
    /// </summary>
    /// <param name="fileName">The filename</param>
    /// <returns></returns>
    public List<team> DeSerializeObject(string fileName)
    {
        List<team> temp = null;

        // Open the file containing the data that you want to deserialize.
        FileStream fs = new FileStream(fileName, FileMode.Open);
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();

            // Deserialize the hashtable from the file and 
            // assign the reference to the local variable.
            temp = (List<team>)formatter.Deserialize(fs);
        }
        catch (SerializationException e)
        {
            Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            fs.Close();
        }
        return temp;
    }
    private List<player> FindBestPlayersByCountry(Country country)
    {
        List<player> retVal = new List<player>();

        foreach (team team in create.getTeams())
        {
            foreach (player p in team)
            {
                if (p.GetCountry().Equals(country)) retVal.Add(p);
            }
        }
        foreach (team team in create.getDLeagueTeams())
        {
            foreach (player p in team)
            {
                if (p.GetCountry().Equals(country)) retVal.Add(p);
            }
        }
        foreach (player p in freeAgents.GetAllPlayers())
        {
            if (p.GetCountry().Equals(country)) retVal.Add(p);
        }
        return retVal;
    }
    private void AdvanceYear()
    {
        foreach (player player in freeAgents.GetAllPlayers())
        {
            if (player.GetPlayerID() < 1191)
                player.endSeason();
        }
    }
    class StartersOveralls : IComparable<StartersOveralls>
    {
        private double overall;
        private string team;
        public StartersOveralls(double overall, string team)
        {
            this.overall = overall;
            this.team = team;
        }

        public int CompareTo(StartersOveralls other)
        {
            if (overall - other.overall > 0) return -1;
            else if (other.overall - overall > 0) return 1;
            else return 0;
        }

        public override string ToString()
        {
            return team + ": " + overall + "\n";
        }
    }
    private void PrintWikiInfo()
    {
        create.getTeam(0).SetTeamInfo(219, 185, 4, 9, 16, 0, 0, 0, "#ac6814", "#d9d9d9", "#ffffff", "Aahrus, Aahrus", "Aahrus Stadium", "Brown", "Gray", "White");
        create.getTeam(16).SetTeamInfo(187, 217, 2, 12, 11, 0, 0, 0, "#1155cc", "#cc0000", "#ffffff", "Vikasa, Aiyota", "Aiyota Stadium", "Blue", "Red", "White");
        create.getTeam(1).SetTeamInfo(231, 173, 3, 37, 31, 1, 2, 0, "#df0000", "#ff9900", "#a46200", "Auspikitan, Auspikitan", "Auspikitan Stadium", "Red", "Orange", "Brown");
        create.getTeam(8).SetTeamInfo(174, 230, 1, 1, 4, 0, 0, 0, "#ff00ff", "#0000ff", "#00ffff", "Autolik, Blaist Blaland", "Autolik Arena", "Pink", "Blue", "Light Blue");
        create.getTeam(17).SetTeamInfo(239, 165, 3, 16, 14, 2, 0, 0, "#6aa84f", "#cccccc", "#ffffff", "Ávura, Aeridani", "Ávura Stadium", "Green", "Gray", "White");
        create.getTeam(9).SetTeamInfo(185, 219, 3, 11, 14, 0, 0, 0, "#666666", "#00ffff", "#ffffff", "Barsein City, Barsein", "Barsein Stadium", "Gray", "Light Blue", "White");
        create.getTeam(10).SetTeamInfo(185, 219, 2, 4, 8, 0, 0, 0, "#ff0000", "#ffff00", "#000000", "Blanaxon, Blaist Blaland", "Blanaxon Stadium", "Red", "Yellow", "Black");
        create.getTeam(18).SetTeamInfo(142, 262, 0, 0, 0, 0, 0, 0, "#bf9000", "#0b5394", "#ffffff", "Boltway, Ethanthova", "Boltway Stadium", "Gold", "Blue", "White");
        create.getTeam(18).SetCoach(create.getTeam(24).getCoach());
        create.getTeam(24).SetTeamInfo(166, 238, 2, 4, 9, 0, 0, 0, "#f1c232", "#ff9900", "#990000", "Bongatar City, Bongatar", "Bongatar Banging Stadium", "Tan", "Orange", "Maroon");
        create.getTeam(2).SetTeamInfo(284, 120, 5, 40, 32, 3, 1, 0, "#000000", "#ffffff", "#d9d9d9", "Calto, Wyverncliff", "Cow Center", "Black", "White", "Gray");
        create.getTeam(25).SetTeamInfo(159, 245, 1, 0, 4, 0, 0, 0, "#ffff00", "#000000", "#efefef", "Protopolis, Czalliso", "Czalliso Stadium", "Yellow", "Black", "Light Gray");
        create.getTeam(19).SetTeamInfo(280, 124, 5, 36, 30, 2, 1, 1, "#002bff", "#cccccc", "#ffffff", "Naskitrusk, Dotruga", "Naskitrusk Bowl", "Blue", "Gray", "White");
        create.getTeam(26).SetTeamInfo(317, 87, 5, 69, 24, 5, 3, 3, "#17f613", "#b7b7b7", "#000000", "Dvimne, Bielosia", "Dvimne Stadium", "Light Green", "Gray", "Black");
        create.getTeam(20).SetTeamInfo(259, 145, 3, 8, 12, 1, 0, 0, "#6d9eeb", "#e06666", "#ffffff", "Vincent, Ethanthova", "Ethanthova Stadium", "Light Blue", "Light Red", "White");
        create.getTeam(21).SetTeamInfo(220, 184, 2, 6, 9, 0, 0, 0, "#6aa84f", "#ea4000", "#ffffff", "Faehrenfall, Aeridani", "Faehrenfall Stadium", "Green", "Red", "White");
        create.getTeam(3).SetTeamInfo(154, 250, 1, 3, 4, 0, 0, 0, "#00ffac", "#0200b7", "#ffffff", "Shigua, Height Sagua", "Height Sagua Stadium", "Teal", "Blue", "White");
        create.getTeam(27).SetTeamInfo(123, 281, 2, 2, 8, 0, 0, 0, "#674ea7", "#cccccc", "#ff9900", "City, Holy Yektonesia", "Holy Yektonesia Stadium", "Purple", "Gray", "Orange");
        create.getTeam(28).SetTeamInfo(205, 199, 3, 12, 16, 0, 0, 0, "#cc4125", "#f1c232", "#000000", "Shiberia, Holykol", "Holykol Stadium", "Red", "Gold", "Black");
        create.getTeam(11).SetTeamInfo(194, 210, 3, 24, 24, 0, 1, 0, "#cc0000", "#38761d", "#ffe599", "Oasis City, Kaeshar", "Kaeshar Stadium", "Red", "Green", "Tan");
        create.getTeam(4).SetTeamInfo(165, 239, 1, 3, 4, 0, 0, 0, "#00ff00", "#000000", "#00ffff", "Dongua, Key To Don", "Key to Don Stadium", "Light Green", "Black", "Light Blue");
        create.getTeam(29).SetTeamInfo(191, 213, 2, 3, 8, 0, 0, 0, "#a64d79", "#ffff00", "#666666", "City, Lyintaria", "Lyintaria Stadium", "Purple", "Yellow", "Dark Gray");
        create.getTeam(5).SetTeamInfo(194, 210, 2, 4, 9, 1, 0, 0, "#00cf00", "#ffffff", "#0011dd", "Manwx, Darvincia", "Manwx Stadium", "Green", "White", "Blue");
        create.getTeam(12).SetTeamInfo(191, 213, 3, 6, 12, 0, 0, 0, "#7f6000", "#ffff00", "#999999", "Naxda, Blaist Blaland", "Naxda Stadium", "Brown", "Yellow", "Gray");
        create.getTeam(30).SetTeamInfo(236, 168, 4, 30, 28, 0, 1, 1, "#f230ff", "#ffff00", "#ffffff", "City, Pyxanovia", "Pyxanovia Stadium", "Pink", "Yellow", "White");
        create.getTeam(13).SetTeamInfo(161, 243, 1, 3, 4, 0, 0, 0, "#ff0000", "#000000", "#cccccc", "Sovkagrad, Red Rainbow", "Red Rainbow Stadium", "Red", "Black", "Light Gray");
        create.getTeam(6).SetTeamInfo(216, 188, 3, 16, 12, 0, 0, 0, "#e53232", "#cccccc", "#ffffff", "Sagua, Sagua", "Sagua Stadium", "Red", "Gray", "White");
        create.getTeam(14).SetTeamInfo(183, 221, 2, 12, 14, 2, 0, 0, "#00ffdb", "#10d1b6", "#0c343d", "Kap'atŋpiri, Oesa", "Kap'atŋpiri Stadium", "Teal", "Turquoise", "Elephant");
        create.getTeam(15).SetTeamInfo(241, 173, 3, 8, 13, 1, 0, 0, "#1c4587", "#e69138", "#ffffff", "Pyongyang, Shmupland", "Shmupland Stadium", "Navy Blue", "Orange", "White");
        create.getTeam(7).SetTeamInfo(259, 145, 5, 37, 31, 2, 1, 0, "#ff9900", "#ff0000", "#38761d", "Saelunavvk, Solea", "Autarky Otximodrome", "Orange", "Red", "Dark Green");
        create.getTeam(22).SetTeamInfo(189, 215, 2, 5, 8, 0, 0, 0, "#12a4b3", "#666666", "#ffffff", "Stedro, Dotruga", "Stedro Stadium", "Teal", "Gray", "White");
        create.getTeam(23).SetTeamInfo(158, 246, 1, 0, 4, 0, 0, 0, "#ffffff", "#434343", "#8bd751", "City, Tri-National Dominion", "TND Stadium", "White", "Orange", "Lime Green");
        create.getTeam(31).SetTeamInfo(157, 247, 1, 0, 4, 0, 0, 0, "#073763", "#ff0000", "#ffffff", "Degëq'so, Transhimalia", "Transhimalia Stadium", "Blue", "Red", "White");

        string toWrite = "";
        foreach (team team in create.getTeams())
        {
            toWrite += team.CreateWikiPage();
            team.endSeason();
        }
        File.WriteAllText("wiki.txt", toWrite);
    }
    private void FindStarterAverages(string fileName, List<team> teams)
    {
        double[] totals = new double[5];

        foreach (team team in teams)
        {
            for (int i = 0; i < 5; i++)
            {
                totals[i] += team.getPlayer(i).getOverall();
            }
        }

        double[] averages = new double[5];
        for (int i = 0; i < totals.Length; i++)
        {
            averages[i] = totals[i] / teams.Count;
        }
        string toWrite = "";
        for (int i = 0; i < averages.Length; i++)
        {
            toWrite += "Position " + (i + 1) + ": " + averages[i] + "\n";
        }
        File.WriteAllText(fileName, toWrite);
    }
    private void CalculatePositionRank()
    {
        for (int i = 0; i < playersByPos.Length; i++)
        {
            playersByPos[i] = new List<player>();
        }
        AddPlayersFromTeam(create.getTeams());
        AddPlayersFromTeam(create.getDLeagueTeams());
        foreach (player player in freeAgents.GetAllPlayers())
        {
            playersByPos[player.getPosition() - 1].Add(player);
        }
        int totalCount = 0;
        for (int i = 0; i < playersByPos.Length; i++)
        {
            playersByPos[i].Sort();
            playersByPos[i].Reverse();
            totalCount += playersByPos[i].Count;
            int positionRank = 1;
            double previous = 0;
            int incrementer = 1;
            for (int j = 0; j < playersByPos[i].Count; j++)
            {
                if (playersByPos[i][j].getOverall() == previous)
                {
                    incrementer++;
                }
                else
                {
                    positionRank += incrementer;
                    incrementer = 1;
                    previous = playersByPos[i][j].getOverall();
                }
                playersByPos[i][j].SetPositionRank(positionRank);

            }
        }
        int[] index = new int[5];
        int rank = 0;
        int rankIncrementer = 1;
        double previousOverall = 0;
        while (rank < totalCount)
        {
            int nextIndex = -1;
            double roundHigh = 0;
            for (int i = 0; i < playersByPos.Length; i++)
            {
                if (index[i] >= playersByPos[i].Count) continue;
                if (playersByPos[i][index[i]].getOverall() > roundHigh)
                {
                    roundHigh = playersByPos[i][index[i]].getOverall();
                    nextIndex = i;

                }

            }
            if (roundHigh != previousOverall)
            {
                rank += rankIncrementer;
                rankIncrementer = 1;
                previousOverall = roundHigh;
            }
            else
            {
                rankIncrementer++;
            }
            playersByPos[nextIndex][index[nextIndex]].SetOverallRank(rank);
            index[nextIndex]++;
        }
    }
    private void AddPlayersFromTeam(List<team> teams)
    {
        foreach (team team in teams)
        {
            foreach (player player in team)
            {
                playersByPos[player.getPosition() - 1].Add(player);


            }
        }
    }
    private void CalculateHighestPayroll(string fileName, List<team> teams)
    {
        List<Payroll> payrolls = new List<Payroll>();
        foreach (team team in teams)
        {
            payrolls.Add(new Payroll(team.GetPayroll(), team.ToString()));
        }
        payrolls.Sort();
        string toWrite = "";

        foreach (Payroll payroll in payrolls)
        {
            toWrite += payroll.ToString();
        }

        File.WriteAllText(fileName, toWrite);
    }
    private void FindBestPlayers()
    {
        string[] bestPlayers = new string[6];
        int[] index = new int[5];
        int rank = 0;
        while (rank < 10)
        {
            int nextIndex = -1;
            double roundHigh = 0;
            for (int i = 0; i < playersByPos.Length; i++)
            {
                if (index[i] >= playersByPos[i].Count) continue;
                if (playersByPos[i][index[i]].getOverall() > roundHigh)
                {
                    roundHigh = playersByPos[i][index[i]].getOverall();
                    nextIndex = i;

                }

            }

            bestPlayers[0] += "" + (rank + 1) + ". " + playersByPos[nextIndex][index[nextIndex]].getName() + ": " + playersByPos[nextIndex][index[nextIndex]].getOverall() + "\n";
            rank++;
            index[nextIndex]++;
        }
        for (int i = 1; i < bestPlayers.Length; i++)
        {
            for (int j = 0; j < 10; j++)
                bestPlayers[i] += "" + (j + 1) + ". " + playersByPos[i - 1][j].getName() + ": " + playersByPos[i - 1][j].getOverall() + "\n";
        }
        string toWrite = "";
        for (int i = 0; i < bestPlayers.Length; i++)
        {
            if (i == 0) toWrite += "Best Overall Players:\n";
            else toWrite += "Best " + i + "'s\n";
            toWrite += bestPlayers[i] + "\n\n\n";
        }
        File.WriteAllText("topPlayers.txt", toWrite);
    }

    private void SetAffiliated()
    {
        create.getTeam(0).SetAffiliate(create.getDLeagueTeam(12));
        create.getTeam(1).SetAffiliate(create.getDLeagueTeam(27));
        create.getTeam(2).SetAffiliate(create.getDLeagueTeam(5));
        create.getTeam(3).SetAffiliate(create.getDLeagueTeam(30));
        create.getTeam(4).SetAffiliate(create.getDLeagueTeam(9));
        create.getTeam(5).SetAffiliate(create.getDLeagueTeam(23));
        create.getTeam(6).SetAffiliate(create.getDLeagueTeam(7));
        create.getTeam(7).SetAffiliate(create.getDLeagueTeam(20));
        create.getTeam(8).SetAffiliate(create.getDLeagueTeam(15));
        create.getTeam(9).SetAffiliate(create.getDLeagueTeam(8));
        create.getTeam(10).SetAffiliate(create.getDLeagueTeam(1));
        create.getTeam(11).SetAffiliate(create.getDLeagueTeam(22));
        create.getTeam(12).SetAffiliate(create.getDLeagueTeam(19));
        create.getTeam(13).SetAffiliate(create.getDLeagueTeam(29));
        create.getTeam(14).SetAffiliate(create.getDLeagueTeam(18));
        create.getTeam(15).SetAffiliate(create.getDLeagueTeam(25));
        create.getTeam(16).SetAffiliate(create.getDLeagueTeam(28));
        create.getTeam(17).SetAffiliate(create.getDLeagueTeam(13));
        create.getTeam(18).SetAffiliate(create.getDLeagueTeam(14));
        create.getTeam(19).SetAffiliate(create.getDLeagueTeam(6));
        create.getTeam(20).SetAffiliate(create.getDLeagueTeam(2));
        create.getTeam(21).SetAffiliate(create.getDLeagueTeam(0));
        create.getTeam(22).SetAffiliate(create.getDLeagueTeam(26));
        create.getTeam(23).SetAffiliate(create.getDLeagueTeam(16));
        create.getTeam(24).SetAffiliate(create.getDLeagueTeam(3));
        create.getTeam(25).SetAffiliate(create.getDLeagueTeam(10));
        create.getTeam(26).SetAffiliate(create.getDLeagueTeam(17));
        create.getTeam(27).SetAffiliate(create.getDLeagueTeam(31));
        create.getTeam(28).SetAffiliate(create.getDLeagueTeam(11));
        create.getTeam(29).SetAffiliate(create.getDLeagueTeam(21));
        create.getTeam(30).SetAffiliate(create.getDLeagueTeam(4));
        create.getTeam(31).SetAffiliate(create.getDLeagueTeam(24));
    }
    private void ClearTeams()
    {
        for (int i = 0; i < create.size(); i++)
        {
            freeAgents.Add(create.getTeam(i).ClearPlayers());
            freeAgents.Add(create.getTeam(i).GetAffiliate().getAllPlayer());
            
        }
    }
    private void MovePlayersToTeams()
    {
        freeAgents.GetPlayerByID(0).ResetPlayerSkills(2, 82, 90, 42, 38, 52, 86, 82, 87, 73, 53, 101, 2, 6.4); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(0));
        freeAgents.GetPlayerByID(421).ResetPlayerSkills(1, 103, 77, 13, 7, 38, 92, 38, 93, 100, 53, 81, 1, 2); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(421));
        freeAgents.GetPlayerByID(2).ResetPlayerSkills(4, 51, 36, 100, 98, 74, 81, 62, 18, 100, 46, 76, 3, 17.6); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(2));
        freeAgents.GetPlayerByID(3).ResetPlayerSkills(5, 20, 30, 103, 100, 91, 39, 71, 30, 103, 51, 69, 4, 16.3); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(3));
        freeAgents.GetPlayerByID(4).ResetPlayerSkills(5, 25, 61, 101, 99, 98, 62, 30, 9, 56, 45, 49, 1, 9.3); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(4));
        freeAgents.GetPlayerByID(5).ResetPlayerSkills(4, 51, 48, 77, 81, 39, 61, 71, 33, 25, 49, 96, 1, 3); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(5));
        freeAgents.GetPlayerByID(6).ResetPlayerSkills(3, 76, 86, 66, 80, 41, 60, 90, 65, 66, 71, 97, 2, 3.4); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(6));
        freeAgents.GetPlayerByID(663).ResetPlayerSkills(3, 68, 7, 88, 76, 92, 19, 6, 46, 79, 71, 84, 1, 1); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(663));
        freeAgents.GetPlayerByID(8).ResetPlayerSkills(3, 41, 39, 67, 79, 85, 101, 75, 73, 43, 28, 66, 2, 6.6); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(8));
        freeAgents.GetPlayerByID(841).ResetPlayerSkills(2, 80, 37, 61, 55, 20, 66, 72, 75, 74, 48, 46, 3, 2); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(841));
        freeAgents.GetPlayerByID(11).ResetPlayerSkills(1, 78, 103, 36, 40, 31, 46, 78, 76, 46, 9, 58, 3, 4.4); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(11));
        freeAgents.GetPlayerByID(12).ResetPlayerSkills(2, 104, 46, 5, 11, 82, 85, 55, 101, 73, 54, 91, 1, 6.5); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(12));
        freeAgents.GetPlayerByID(13).ResetPlayerSkills(5, 39, 27, 98, 97, 81, 72, 62, 13, 69, 72, 67, 3, 8); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(13));
        freeAgents.GetPlayerByID(14).ResetPlayerSkills(1, 90, 40, 12, 12, 25, 61, 82, 98, 48, 50, 46, 2, 4); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(14));
        freeAgents.GetPlayerByID(1191).ResetPlayerSkills(1, 59, 69, 37, 41, 34, 32, 23, 83, 34, 75, 81, 2, 5); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(1191));
        freeAgents.GetPlayerByID(1192).ResetPlayerSkills(3, 45, 24, 82, 14, 81, 67, 70, 77, 80, 100, 48, 2, 1); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(1192));
        freeAgents.GetPlayerByID(1193).ResetPlayerSkills(4, 47, 30, 61, 41, 67, 67, 87, 5, 36, 78, 90, 2, 1); create.getTeam(0).addPlayer(freeAgents.GetPlayerByID(1193));

        freeAgents.GetPlayerByID(242).ResetPlayerSkills(1, 103, 76, 34, 30, 25, 60, 78, 77, 57, 53, 54, 3, 6.4); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(242));
        freeAgents.GetPlayerByID(243).ResetPlayerSkills(2, 93, 73, 64, 71, 57, 72, 68, 83, 88, 11, 96, 4, 12); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(243));
        freeAgents.GetPlayerByID(244).ResetPlayerSkills(3, 38, 45, 90, 93, 79, 91, 81, 66, 64, 51, 97, 1, 12); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(244));
        freeAgents.GetPlayerByID(245).ResetPlayerSkills(4, 42, 15, 117, 121, 103, 91, 85, 9, 117, 46, 102, 3, 20); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(245));
        freeAgents.GetPlayerByID(246).ResetPlayerSkills(5, 45, 27, 84, 78, 109, 67, 65, 37, 64, 45, 101, 2, 3.6); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(246));
        freeAgents.GetPlayerByID(247).ResetPlayerSkills(1, 78, 88, 8, 13, 11, 99, 55, 71, 57, 47, 67, 3, 2); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(247));
        freeAgents.GetPlayerByID(248).ResetPlayerSkills(5, 39, 52, 56, 70, 97, 79, 50, 44, 74, 98, 81, 4, 5.8); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(248));
        freeAgents.GetPlayerByID(249).ResetPlayerSkills(2, 36, 98, 37, 43, 43, 55, 56, 86, 64, 48, 95, 1, 5); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(249));
        freeAgents.GetPlayerByID(250).ResetPlayerSkills(2, 94, 61, 47, 40, 47, 56, 55, 85, 36, 33, 91, 1, 6); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(250));
        freeAgents.GetPlayerByID(477).ResetPlayerSkills(1, 80, 101, 27, 29, 18, 92, 97, 106, 55, 5, 51, 2, 7.8); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(477));
        freeAgents.GetPlayerByID(252).ResetPlayerSkills(5, 46, 53, 67, 58, 71, 35, 80, 99, 55, 58, 91, 1, 1); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(252));
        freeAgents.GetPlayerByID(253).ResetPlayerSkills(4, 71, 53, 101, 98, 15, 62, 44, 37, 61, 78, 77, 2, 2); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(253));
        freeAgents.GetPlayerByID(254).ResetPlayerSkills(4, 33, 20, 92, 92, 71, 78, 36, 12, 72, 46, 90, 1, 5); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(254));
        freeAgents.GetPlayerByID(255).ResetPlayerSkills(1, 78, 87, 24, 7, 46, 46, 96, 66, 59, 67, 64, 3, 3); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(255));
        freeAgents.GetPlayerByID(256).ResetPlayerSkills(3, 81, 42, 91, 94, 49, 51, 28, 27, 76, 48, 104, 1, 2.2); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(256));
        freeAgents.GetPlayerByID(1195).ResetPlayerSkills(3, 35, 7, 101, 78, 84, 86, 42, 38, 84, 77, 68, 2, 1); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(1195));
        freeAgents.GetPlayerByID(1194).ResetPlayerSkills(1, 47, 69, 9, 43, 41, 61, 45, 94, 34, 92, 83, 2, 5); create.getTeam(16).addPlayer(freeAgents.GetPlayerByID(1194));

        freeAgents.GetPlayerByID(15).ResetPlayerSkills(1, 97, 67, 9, 6, 43, 89, 103, 119, 59, 49, 57, 2, 10); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(15));
        freeAgents.GetPlayerByID(16).ResetPlayerSkills(3, 96, 72, 94, 78, 65, 101, 96, 85, 75, 47, 91, 1, 15); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(16));
        freeAgents.GetPlayerByID(17).ResetPlayerSkills(4, 104, 75, 97, 103, 76, 88, 65, 17, 75, 59, 69, 3, 11); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(17));
        freeAgents.GetPlayerByID(18).ResetPlayerSkills(5, 36, 42, 62, 60, 147, 85, 83, 54, 61, 53, 46, 4, 13.3); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(18));
        freeAgents.GetPlayerByID(19).ResetPlayerSkills(3, 93, 103, 20, 49, 50, 55, 88, 54, 98, 32, 88, 2, 4.3); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(19));
        freeAgents.GetPlayerByID(20).ResetPlayerSkills(2, 72, 84, 70, 76, 53, 69, 35, 62, 85, 12, 61, 3, 4.3); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(20));
        freeAgents.GetPlayerByID(418).ResetPlayerSkills(2, 67, 85, 26, 13, 30, 68, 67, 89, 74, 8, 50, 2, 2.1); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(418));
        freeAgents.GetPlayerByID(1196).ResetPlayerSkills(5, 44, 17, 51, 56, 93, 76, 61, 41, 63, 19, 68, 2, 5); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(1196));
        freeAgents.GetPlayerByID(948).ResetPlayerSkills(3, 9, 41, 96, 71, 74, 58, 73, 45, 63, 11, 104, 1, 2); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(948));
        freeAgents.GetPlayerByID(24).ResetPlayerSkills(1, 86, 103, 21, 32, 45, 100, 45, 92, 67, 65, 82, 2, 4.2); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(24));
        freeAgents.GetPlayerByID(25).ResetPlayerSkills(1, 83, 85, 21, 14, 32, 98, 54, 84, 71, 42, 79, 3, 3.7); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(25));
        freeAgents.GetPlayerByID(26).ResetPlayerSkills(4, 64, 24, 102, 95, 44, 81, 60, 31, 56, 52, 71, 1, 2.3); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(26));
        freeAgents.GetPlayerByID(27).ResetPlayerSkills(4, 44, 41, 75, 79, 56, 87, 63, 20, 92, 48, 68, 1, 4.2); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(27));
        freeAgents.GetPlayerByID(28).ResetPlayerSkills(5, 48, 41, 79, 48, 111, 77, 55, 53, 76, 52, 79, 1, 3); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(28));
        freeAgents.GetPlayerByID(29).ResetPlayerSkills(2, 65, 100, 43, 15, 47, 96, 87, 123, 100, 93, 48, 3, 13); create.getTeam(1).addPlayer(freeAgents.GetPlayerByID(29));

        

        freeAgents.GetPlayerByID(122).ResetPlayerSkills(1, 103, 65, 7, 6, 31, 90, 78, 104, 70, 71, 67, 2, 9.5); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(122));
        freeAgents.GetPlayerByID(123).ResetPlayerSkills(2, 74, 71, 37, 44, 37, 97, 74, 81, 49, 50, 102, 3, 10); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(123));
        freeAgents.GetPlayerByID(124).ResetPlayerSkills(3, 95, 36, 77, 60, 58, 49, 104, 94, 104, 39, 103, 1, 8); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(124));
        freeAgents.GetPlayerByID(125).ResetPlayerSkills(4, 35, 31, 76, 81, 82, 65, 67, 30, 65, 71, 72, 3, 6.5); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(125));
        freeAgents.GetPlayerByID(126).ResetPlayerSkills(5, 21, 26, 99, 100, 96, 76, 59, 35, 82, 74, 80, 4, 18); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(126));
        freeAgents.GetPlayerByID(127).ResetPlayerSkills(3, 92, 33, 96, 95, 40, 37, 60, 102, 79, 98, 83, 3, 3); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(127));
        freeAgents.GetPlayerByID(128).ResetPlayerSkills(3, 104, 32, 38, 27, 61, 94, 72, 28, 48, 19, 84, 1, 1.2); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(128));
        freeAgents.GetPlayerByID(129).ResetPlayerSkills(4, 48, 52, 66, 71, 57, 52, 62, 33, 96, 40, 76, 2, 1.8); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(129));
        freeAgents.GetPlayerByID(130).ResetPlayerSkills(1, 86, 103, 30, 16, 16, 54, 103, 96, 48, 102, 81, 1, 2.3); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(130));
        freeAgents.GetPlayerByID(810).ResetPlayerSkills(1, 38, 93, 19, 17, 19, 95, 82, 101, 56, 45, 48, 1, 2); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(810));
        freeAgents.GetPlayerByID(132).ResetPlayerSkills(2, 83, 99, 13, 14, 34, 55, 58, 91, 57, 47, 50, 1, 1.4); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(132));
        freeAgents.GetPlayerByID(133).ResetPlayerSkills(5, 52, 44, 64, 70, 93, 29, 79, 13, 49, 6, 69, 3, 3); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(133));
        freeAgents.GetPlayerByID(134).ResetPlayerSkills(1, 103, 104, 40, 32, 31, 69, 78, 98, 67, 23, 59, 4, 6.4); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(134));
        freeAgents.GetPlayerByID(135).ResetPlayerSkills(4, 20, 42, 100, 100, 42, 49, 74, 39, 30, 52, 46, 3, 5); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(135));
        freeAgents.GetPlayerByID(1197).ResetPlayerSkills(2, 71, 71, 28, 35, 32, 82, 83, 86, 50, 21, 92, 2, 7.5); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(1197));
        freeAgents.GetPlayerByID(1198).ResetPlayerSkills(5, 79, 10, 48, 27, 78, 41, 46, 17, 72, 64, 80, 2, 1); create.getTeam(8).addPlayer(freeAgents.GetPlayerByID(1198));

        freeAgents.GetPlayerByID(257).ResetPlayerSkills(1, 74, 94, 52, 16, 38, 100, 78, 78, 83, 21, 83, 1, 8.3); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(257));
        freeAgents.GetPlayerByID(258).ResetPlayerSkills(2, 99, 30, 63, 64, 38, 76, 95, 80, 77, 46, 83, 1, 10.4); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(258));
        freeAgents.GetPlayerByID(259).ResetPlayerSkills(3, 88, 88, 52, 62, 88, 84, 79, 84, 73, 93, 67, 4, 10.7); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(259));
        freeAgents.GetPlayerByID(260).ResetPlayerSkills(4, 79, 24, 86, 87, 103, 68, 61, 39, 81, 46, 67, 3, 12.4); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(260));
        freeAgents.GetPlayerByID(131).ResetPlayerSkills(5, 26, 51, 83, 79, 96, 96, 56, 57, 73, 46, 58, 3, 16); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(131));
        freeAgents.GetPlayerByID(1199).ResetPlayerSkills(3, 5, 99, 67, 70, 92, 75, 64, 28, 8, 100, 45, 2, 5); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(1199));
        freeAgents.GetPlayerByID(263).ResetPlayerSkills(5, 58, 20, 79, 90, 82, 61, 74, 21, 68, 38, 80, 3, 8.7); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(263));
        freeAgents.GetPlayerByID(264).ResetPlayerSkills(3, 81, 60, 74, 74, 64, 64, 50, 44, 63, 52, 81, 1, 1.6); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(264));
        freeAgents.GetPlayerByID(265).ResetPlayerSkills(1, 96, 102, 19, 19, 17, 94, 52, 68, 83, 14, 97, 2, 2.6); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(265));
        freeAgents.GetPlayerByID(266).ResetPlayerSkills(2, 84, 38, 44, 43, 36, 83, 67, 72, 62, 66, 83, 4, 3); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(266));
        freeAgents.GetPlayerByID(267).ResetPlayerSkills(4, 97, 70, 66, 73, 16, 49, 62, 18, 82, 27, 104, 3, 2); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(267));
        freeAgents.GetPlayerByID(1200).ResetPlayerSkills(5, 40, 11, 64, 51, 59, 82, 64, 20, 22, 86, 100, 2, 1); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(1200));
        freeAgents.GetPlayerByID(269).ResetPlayerSkills(4, 23, 30, 91, 89, 54, 71, 26, 35, 63, 45, 53, 2, 1); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(269));
        freeAgents.GetPlayerByID(270).ResetPlayerSkills(1, 46, 27, 59, 63, 19, 86, 35, 92, 61, 51, 49, 1, 1); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(270));
        freeAgents.GetPlayerByID(271).ResetPlayerSkills(2, 83, 14, 49, 54, 96, 71, 97, 88, 65, 49, 96, 1, 7.6); create.getTeam(17).addPlayer(freeAgents.GetPlayerByID(271));

        freeAgents.GetPlayerByID(137).ResetPlayerSkills(1, 85, 85, 24, 17, 11, 101, 87, 102, 84, 53, 61, 3, 10); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(137));
        freeAgents.GetPlayerByID(138).ResetPlayerSkills(2, 87, 72, 26, 53, 56, 76, 73, 84, 94, 46, 73, 2, 12.6); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(138));
        freeAgents.GetPlayerByID(139).ResetPlayerSkills(3, 33, 82, 93, 86, 70, 81, 75, 69, 82, 53, 90, 3, 12.5); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(139));
        freeAgents.GetPlayerByID(140).ResetPlayerSkills(4, 76, 54, 102, 106, 83, 80, 84, 35, 99, 48, 97, 1, 15); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(140));
        freeAgents.GetPlayerByID(141).ResetPlayerSkills(5, 75, 39, 47, 52, 102, 98, 100, 51, 65, 54, 59, 1, 15); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(141));
        freeAgents.GetPlayerByID(142).ResetPlayerSkills(2, 57, 57, 46, 55, 57, 80, 87, 60, 78, 32, 54, 2, 2); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(142));
        freeAgents.GetPlayerByID(930).ResetPlayerSkills(2, 61, 44, 46, 62, 79, 87, 51, 78, 69, 38, 54, 2, 8); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(930));
        freeAgents.GetPlayerByID(144).ResetPlayerSkills(4, 95, 85, 98, 96, 41, 72, 42, 39, 45, 15, 90, 4, 3.8); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(144));
        freeAgents.GetPlayerByID(145).ResetPlayerSkills(1, 64, 62, 28, 15, 24, 65, 100, 77, 72, 92, 58, 1, 1); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(145));
        freeAgents.GetPlayerByID(146).ResetPlayerSkills(3, 84, 37, 94, 85, 23, 43, 39, 80, 11, 46, 95, 1, 1); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(146));
        freeAgents.GetPlayerByID(97).ResetPlayerSkills(1, 58, 64, 32, 31, 41, 49, 90, 89, 45, 50, 53, 1, 1.1); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(97));
        freeAgents.GetPlayerByID(148).ResetPlayerSkills(5, 27, 33, 79, 102, 64, 52, 47, 52, 92, 47, 72, 4, 6.5); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(148));
        freeAgents.GetPlayerByID(149).ResetPlayerSkills(5, 27, 8, 100, 99, 53, 78, 38, 43, 37, 50, 66, 1, 5.4); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(149));
        freeAgents.GetPlayerByID(150).ResetPlayerSkills(3, 52, 40, 94, 89, 43, 32, 64, 50, 74, 46, 77, 1, 2.3); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(150));
        freeAgents.GetPlayerByID(151).ResetPlayerSkills(4, 58, 18, 59, 57, 58, 78, 71, 16, 93, 45, 62, 1, 1.8); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(151));
        freeAgents.GetPlayerByID(1201).ResetPlayerSkills(1, 37, 32, 5, 10, 15, 82, 94, 100, 40, 56, 65, 2, 5); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(1201));
        freeAgents.GetPlayerByID(1202).ResetPlayerSkills(3, 82, 101, 63, 85, 59, 50, 43, 6, 96, 66, 104, 2, 1); create.getTeam(9).addPlayer(freeAgents.GetPlayerByID(1202));

        freeAgents.GetPlayerByID(387).ResetPlayerSkills(1, 69, 51, 46, 25, 35, 38, 85, 92, 42, 80, 90, 1, 1.4); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(387));
        freeAgents.GetPlayerByID(166).ResetPlayerSkills(2, 83, 65, 69, 77, 65, 75, 99, 81, 80, 30, 92, 3, 6.4); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(166));
        freeAgents.GetPlayerByID(154).ResetPlayerSkills(3, 85, 53, 64, 60, 117, 29, 96, 96, 83, 45, 83, 4, 20); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(154));
        freeAgents.GetPlayerByID(155).ResetPlayerSkills(4, 27, 26, 100, 79, 82, 71, 75, 44, 98, 84, 52, 3, 15.3); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(155));
        freeAgents.GetPlayerByID(156).ResetPlayerSkills(5, 11, 30, 83, 77, 88, 47, 59, 35, 100, 47, 78, 4, 12.3); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(156));
        freeAgents.GetPlayerByID(157).ResetPlayerSkills(4, 16, 28, 88, 86, 35, 49, 47, 36, 103, 54, 103, 3, 3.6); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(157));
        freeAgents.GetPlayerByID(158).ResetPlayerSkills(3, 86, 79, 6, 7, 34, 101, 59, 87, 68, 67, 59, 4, 6.1); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(158));
        freeAgents.GetPlayerByID(159).ResetPlayerSkills(4, 46, 9, 68, 74, 42, 77, 68, 44, 58, 51, 53, 2, 2.4); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(159));
        freeAgents.GetPlayerByID(160).ResetPlayerSkills(5, 52, 44, 72, 58, 98, 81, 52, 56, 66, 43, 63, 1, 5); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(160));
        freeAgents.GetPlayerByID(161).ResetPlayerSkills(5, 44, 50, 56, 45, 87, 59, 41, 28, 77, 53, 80, 1, 4.3); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(161));
        freeAgents.GetPlayerByID(210).ResetPlayerSkills(3, 75, 66, 76, 100, 6, 70, 99, 31, 40, 95, 104, 1, 1.5); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(210));
        freeAgents.GetPlayerByID(163).ResetPlayerSkills(1, 72, 57, 65, 76, 43, 59, 43, 83, 82, 54, 69, 1, 1); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(163));
        freeAgents.GetPlayerByID(164).ResetPlayerSkills(2, 41, 54, 42, 36, 62, 81, 48, 85, 44, 47, 89, 2, 1); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(164));
        freeAgents.GetPlayerByID(165).ResetPlayerSkills(1, 70, 56, 37, 32, 14, 74, 87, 75, 75, 75, 71, 3, 4.3); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(165));
        freeAgents.GetPlayerByID(1203).ResetPlayerSkills(2, 54, 84, 22, 32, 21, 51, 58, 87, 57, 8, 56, 2, 1); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(1203));
        freeAgents.GetPlayerByID(1204).ResetPlayerSkills(5, 53, 37, 59, 40, 56, 84, 66, 9, 32, 64, 104, 2, 5); create.getTeam(10).addPlayer(freeAgents.GetPlayerByID(1204));

        freeAgents.GetPlayerByID(111).ResetPlayerSkills(1, 90, 93, 60, 47, 77, 69, 96, 67, 86, 64, 62, 3, 16); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(111));
        freeAgents.GetPlayerByID(273).ResetPlayerSkills(2, 103, 29, 64, 60, 71, 90, 66, 93, 80, 99, 54, 4, 9.7); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(273));
        freeAgents.GetPlayerByID(274).ResetPlayerSkills(3, 66, 53, 99, 57, 73, 63, 91, 51, 50, 52, 101, 1, 5); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(274));
        freeAgents.GetPlayerByID(275).ResetPlayerSkills(4, 74, 24, 98, 102, 71, 54, 82, 22, 97, 54, 51, 2, 7.3); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(275));
        freeAgents.GetPlayerByID(276).ResetPlayerSkills(5, 99, 30, 76, 84, 102, 60, 71, 44, 103, 46, 76, 3, 13); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(276));
        freeAgents.GetPlayerByID(277).ResetPlayerSkills(5, 69, 20, 44, 54, 94, 74, 87, 96, 41, 43, 56, 3, 3.4); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(277));
        freeAgents.GetPlayerByID(278).ResetPlayerSkills(3, 71, 75, 63, 56, 62, 68, 75, 37, 77, 51, 79, 2, 4.1); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(278));
        freeAgents.GetPlayerByID(279).ResetPlayerSkills(4, 91, 42, 95, 89, 39, 67, 53, 47, 74, 53, 65, 3, 2); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(279));
        freeAgents.GetPlayerByID(22).ResetPlayerSkills(2, 52, 92, 17, 22, 30, 99, 80, 80, 19, 48, 49, 1, 1); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(22));
        freeAgents.GetPlayerByID(281).ResetPlayerSkills(4, 58, 50, 86, 61, 74, 73, 53, 30, 97, 94, 100, 4, 3.1); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(281));
        freeAgents.GetPlayerByID(282).ResetPlayerSkills(1, 95, 54, 26, 25, 40, 44, 73, 70, 67, 50, 55, 3, 2.4); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(282));
        freeAgents.GetPlayerByID(283).ResetPlayerSkills(3, 79, 51, 66, 52, 24, 53, 48, 73, 59, 50, 67, 3, 1.7); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(283));
        freeAgents.GetPlayerByID(284).ResetPlayerSkills(1, 73, 79, 15, 22, 31, 64, 80, 83, 40, 45, 53, 2, 2); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(284));
        freeAgents.GetPlayerByID(285).ResetPlayerSkills(5, 42, 33, 89, 92, 80, 64, 69, 33, 103, 50, 46, 1, 5); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(285));
        freeAgents.GetPlayerByID(286).ResetPlayerSkills(2, 87, 63, 45, 44, 53, 40, 81, 91, 57, 99, 74, 3, 1); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(286));
        freeAgents.GetPlayerByID(1205).ResetPlayerSkills(4, 29, 33, 68, 62, 48, 54, 69, 41, 60, 96, 65, 2, 1); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(1205));
        freeAgents.GetPlayerByID(1206).ResetPlayerSkills(5, 36, 92, 75, 99, 102, 85, 67, 6, 88, 79, 98, 2, 5); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(1206));
        freeAgents.GetPlayerByID(63).ResetPlayerSkills(3, 132, 60, 128, 99, 107, 93, 98, 83, 124, 51, 100, 6, 25); create.getTeam(18).addPlayer(freeAgents.GetPlayerByID(63));

        freeAgents.GetPlayerByID(361).ResetPlayerSkills(1, 96, 92, 40, 19, 43, 81, 98, 132, 83, 53, 59, 3, 10.7); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(361));
        freeAgents.GetPlayerByID(362).ResetPlayerSkills(2, 97, 48, 58, 63, 37, 99, 75, 81, 68, 49, 46, 2, 12.5); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(362));
        freeAgents.GetPlayerByID(735).ResetPlayerSkills(3, 60, 65, 68, 81, 78, 80, 56, 3, 71, 58, 55, 3, 3.3); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(735));
        freeAgents.GetPlayerByID(364).ResetPlayerSkills(4, 47, 28, 98, 99, 79, 71, 92, 28, 80, 48, 58, 4, 12.5); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(364));
        freeAgents.GetPlayerByID(365).ResetPlayerSkills(5, 68, 28, 55, 40, 102, 93, 102, 73, 80, 50, 99, 3, 10.8); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(365));
        freeAgents.GetPlayerByID(366).ResetPlayerSkills(4, 45, 8, 92, 89, 48, 79, 63, 24, 60, 51, 48, 1, 6.3); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(366));
        freeAgents.GetPlayerByID(367).ResetPlayerSkills(5, 38, 7, 84, 82, 84, 78, 45, 40, 26, 47, 95, 2, 5.8); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(367));
        freeAgents.GetPlayerByID(368).ResetPlayerSkills(5, 72, 19, 91, 78, 97, 68, 73, 33, 94, 81, 96, 1, 12.4); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(368));
        freeAgents.GetPlayerByID(369).ResetPlayerSkills(3, 76, 99, 8, 12, 32, 103, 97, 73, 77, 48, 67, 2, 1.7); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(369));
        freeAgents.GetPlayerByID(344).ResetPlayerSkills(1, 99, 60, 16, 17, 40, 102, 13, 84, 67, 49, 84, 1, 3.5); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(344));
        freeAgents.GetPlayerByID(600).ResetPlayerSkills(2, 70, 78, 66, 76, 54, 68, 40, 64, 94, 12, 56, 1, 3.4); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(600));
        freeAgents.GetPlayerByID(372).ResetPlayerSkills(3, 51, 32, 101, 102, 24, 90, 90, 81, 81, 63, 46, 1, 5); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(372));
        freeAgents.GetPlayerByID(241).ResetPlayerSkills(2, 77, 65, 38, 41, 46, 37, 76, 99, 48, 50, 57, 1, 1); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(241));
        freeAgents.GetPlayerByID(375).ResetPlayerSkills(4, 39, 27, 65, 58, 62, 65, 65, 31, 95, 98, 70, 1, 1); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(375));
        freeAgents.GetPlayerByID(1207).ResetPlayerSkills(1, 79, 63, 40, 15, 71, 55, 43, 55, 52, 91, 62, 2, 5); create.getTeam(24).addPlayer(freeAgents.GetPlayerByID(1207));

        freeAgents.GetPlayerByID(30).ResetPlayerSkills(1, 100, 43, 57, 64, 83, 78, 97, 83, 71, 47, 76, 3, 25); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(30));
        freeAgents.GetPlayerByID(31).ResetPlayerSkills(2, 117, 79, 99, 32, 54, 111, 113, 126, 115, 48, 85, 4, 10.1); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(31));
        freeAgents.GetPlayerByID(32).ResetPlayerSkills(3, 83, 34, 73, 74, 72, 96, 102, 86, 79, 52, 60, 2, 16); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(32));
        freeAgents.GetPlayerByID(33).ResetPlayerSkills(4, 62, 31, 102, 103, 58, 99, 70, 15, 100, 49, 52, 3, 14); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(33));
        freeAgents.GetPlayerByID(34).ResetPlayerSkills(5, 59, 24, 99, 104, 115, 88, 77, 9, 99, 50, 72, 1, 12.5); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(34));
        freeAgents.GetPlayerByID(35).ResetPlayerSkills(1, 71, 78, 38, 42, 57, 80, 68, 90, 58, 49, 65, 4, 4.9); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(35));
        freeAgents.GetPlayerByID(36).ResetPlayerSkills(5, 70, 49, 80, 78, 95, 72, 67, 36, 79, 54, 75, 2, 6.5); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(36));
        freeAgents.GetPlayerByID(37).ResetPlayerSkills(2, 89, 93, 64, 46, 46, 85, 82, 77, 56, 62, 77, 3, 2.3); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(37));
        freeAgents.GetPlayerByID(416).ResetPlayerSkills(4, 83, 91, 73, 72, 89, 69, 93, 93, 73, 74, 93, 3, 13); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(416));
        freeAgents.GetPlayerByID(39).ResetPlayerSkills(3, 30, 82, 86, 93, 74, 75, 81, 65, 58, 51, 50, 2, 8.6); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(39));
        freeAgents.GetPlayerByID(40).ResetPlayerSkills(3, 9, 89, 53, 51, 36, 41, 84, 93, 91, 49, 78, 3, 4.1); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(40));
        freeAgents.GetPlayerByID(41).ResetPlayerSkills(4, 42, 19, 73, 66, 54, 99, 78, 37, 69, 47, 62, 1, 3); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(41));
        freeAgents.GetPlayerByID(43).ResetPlayerSkills(1, 103, 69, 30, 9, 37, 68, 62, 79, 73, 45, 46, 1, 5); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(43));
        freeAgents.GetPlayerByID(44).ResetPlayerSkills(5, 45, 30, 85, 89, 68, 57, 77, 28, 61, 10, 84, 1, 1); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(44));
        freeAgents.GetPlayerByID(1208).ResetPlayerSkills(2, 64, 60, 103, 91, 25, 28, 28, 73, 30, 40, 92, 2, 1); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(1208));
        freeAgents.GetPlayerByID(1209).ResetPlayerSkills(3, 31, 66, 22, 16, 103, 13, 25, 96, 41, 40, 46, 2, 5); create.getTeam(2).addPlayer(freeAgents.GetPlayerByID(1209));

        freeAgents.GetPlayerByID(376).ResetPlayerSkills(1, 96, 58, 24, 21, 26, 95, 103, 90, 50, 47, 50, 1, 6.3); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(376));
        freeAgents.GetPlayerByID(377).ResetPlayerSkills(2, 44, 102, 50, 53, 45, 64, 103, 79, 56, 50, 45, 1, 4.8); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(377));
        freeAgents.GetPlayerByID(378).ResetPlayerSkills(3, 35, 104, 72, 74, 102, 69, 67, 39, 102, 47, 85, 2, 10.2); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(378));
        freeAgents.GetPlayerByID(379).ResetPlayerSkills(4, 96, 16, 79, 77, 62, 80, 84, 13, 79, 52, 80, 4, 14.3); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(379));
        freeAgents.GetPlayerByID(380).ResetPlayerSkills(5, 95, 9, 100, 100, 86, 75, 86, 26, 89, 50, 83, 3, 25); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(380));
        freeAgents.GetPlayerByID(381).ResetPlayerSkills(1, 75, 89, 34, 32, 27, 70, 104, 69, 49, 70, 76, 1, 5); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(381));
        freeAgents.GetPlayerByID(383).ResetPlayerSkills(4, 54, 36, 56, 56, 58, 49, 74, 14, 78, 77, 104, 4, 3.1); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(383));
        freeAgents.GetPlayerByID(384).ResetPlayerSkills(4, 69, 33, 91, 88, 56, 30, 54, 38, 65, 49, 54, 1, 3.1); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(384));
        freeAgents.GetPlayerByID(385).ResetPlayerSkills(2, 81, 38, 25, 25, 81, 96, 86, 88, 53, 53, 79, 2, 3.6); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(385));
        freeAgents.GetPlayerByID(386).ResetPlayerSkills(2, 90, 70, 63, 72, 63, 86, 58, 80, 61, 7, 100, 4, 1.9); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(386));
        freeAgents.GetPlayerByID(1260).ResetPlayerSkills(1, 6, 7, 1, 2, 1, 10, 8, 8, 1, 2, 6, 1, 1); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(1260));
        freeAgents.GetPlayerByID(388).ResetPlayerSkills(3, 55, 77, 73, 78, 66, 46, 100, 85, 59, 80, 83, 1, 5.3); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(388));
        freeAgents.GetPlayerByID(390).ResetPlayerSkills(3, 43, 34, 92, 93, 7, 74, 48, 100, 16, 45, 80, 1, 1); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(390));
        freeAgents.GetPlayerByID(104).ResetPlayerSkills(1, 87, 104, 24, 28, 20, 37, 56, 91, 63, 60, 56, 1, 1); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(104));
        freeAgents.GetPlayerByID(1210).ResetPlayerSkills(2, 54, 59, 39, 14, 31, 78, 88, 73, 80, 35, 69, 2, 5); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(1210));
        freeAgents.GetPlayerByID(1211).ResetPlayerSkills(5, 89, 83, 39, 101, 87, 27, 34, 32, 79, 83, 68, 2, 1); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(1211));
        freeAgents.GetPlayerByID(1212).ResetPlayerSkills(3, 23, 86, 39, 23, 75, 68, 84, 54, 50, 100, 103, 2, 1); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(1212));
        freeAgents.GetPlayerByID(1213).ResetPlayerSkills(4, 99, 31, 38, 57, 50, 24, 45, 30, 62, 91, 86, 2, 5); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(1213));
        freeAgents.GetPlayerByID(1214).ResetPlayerSkills(5, 60, 41, 33, 52, 89, 19, 53, 17, 63, 93, 104, 2, 5); create.getTeam(25).addPlayer(freeAgents.GetPlayerByID(1214));

        freeAgents.GetPlayerByID(288).ResetPlayerSkills(1, 101, 30, 84, 81, 62, 104, 95, 96, 92, 47, 100, 2, 18); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(288));
        freeAgents.GetPlayerByID(290).ResetPlayerSkills(2, 90, 90, 79, 81, 96, 101, 90, 91, 103, 47, 81, 3, 25); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(290));
        freeAgents.GetPlayerByID(289).ResetPlayerSkills(3, 95, 88, 104, 99, 98, 104, 96, 78, 101, 45, 92, 5, 25); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(289));
        freeAgents.GetPlayerByID(289).age = 28;
        freeAgents.GetPlayerByID(1215).ResetPlayerSkills(4, 86, 41, 87, 75, 45, 83, 84, 63, 91, 47, 88, 2, 8.5); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(1215));
        freeAgents.GetPlayerByID(291).ResetPlayerSkills(5, 74, 36, 104, 95, 102, 59, 85, 36, 104, 51, 77, 1, 12.4); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(291));
        freeAgents.GetPlayerByID(292).ResetPlayerSkills(1, 102, 83, 54, 39, 15, 48, 35, 104, 51, 96, 55, 1, 1); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(292));
        freeAgents.GetPlayerByID(153).ResetPlayerSkills(2, 54, 51, 63, 61, 20, 101, 63, 88, 50, 52, 72, 2, 2); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(153));
        freeAgents.GetPlayerByID(294).ResetPlayerSkills(2, 102, 75, 46, 43, 26, 49, 60, 83, 33, 16, 71, 2, 3); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(294));
        freeAgents.GetPlayerByID(563).ResetPlayerSkills(4, 30, 27, 65, 67, 63, 21, 65, 21, 80, 46, 49, 2, 2); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(563));
        freeAgents.GetPlayerByID(296).ResetPlayerSkills(5, 84, 10, 55, 37, 88, 58, 80, 73, 35, 51, 73, 3, 1.5); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(296));
        freeAgents.GetPlayerByID(297).ResetPlayerSkills(3, 61, 37, 52, 62, 56, 57, 80, 59, 78, 98, 90, 1, 1); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(297));
        freeAgents.GetPlayerByID(298).ResetPlayerSkills(1, 76, 45, 53, 51, 25, 60, 43, 89, 80, 48, 62, 1, 6.5); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(298));
        freeAgents.GetPlayerByID(299).ResetPlayerSkills(3, 35, 40, 95, 103, 47, 49, 58, 48, 84, 53, 45, 2, 2); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(299));
        freeAgents.GetPlayerByID(42).ResetPlayerSkills(4, 68, 26, 100, 95, 46, 74, 49, 7, 79, 47, 95, 1, 1); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(42));
        freeAgents.GetPlayerByID(223).ResetPlayerSkills(5, 33, 53, 82, 100, 95, 65, 50, 30, 72, 95, 95, 2, 9); create.getTeam(19).addPlayer(freeAgents.GetPlayerByID(223));

        freeAgents.GetPlayerByID(391).ResetPlayerSkills(1, 55, 73, 31, 28, 26, 79, 90, 118, 71, 50, 46, 2, 7.6); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(391));
        freeAgents.GetPlayerByID(392).ResetPlayerSkills(2, 103, 74, 59, 57, 43, 101, 45, 97, 100, 46, 98, 3, 18.8); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(392));
        freeAgents.GetPlayerByID(393).ResetPlayerSkills(3, 104, 25, 115, 112, 111, 106, 107, 90, 119, 59, 82, 3, 25); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(393));
        freeAgents.GetPlayerByID(394).ResetPlayerSkills(4, 59, 27, 83, 76, 61, 72, 102, 34, 97, 52, 45, 5, 10.8); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(394));
        freeAgents.GetPlayerByID(395).ResetPlayerSkills(5, 14, 67, 99, 102, 61, 80, 102, 34, 86, 51, 93, 4, 22.3); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(395));
        freeAgents.GetPlayerByID(396).ResetPlayerSkills(1, 56, 76, 17, 21, 38, 66, 94, 60, 60, 48, 103, 2, 1.8); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(396));
        freeAgents.GetPlayerByID(397).ResetPlayerSkills(5, 50, 34, 80, 83, 89, 53, 71, 36, 95, 51, 55, 3, 1.6); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(397));
        freeAgents.GetPlayerByID(706).ResetPlayerSkills(2, 60, 73, 40, 49, 50, 77, 78, 68, 56, 62, 45, 1, 6); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(706));
        freeAgents.GetPlayerByID(399).ResetPlayerSkills(4, 55, 30, 99, 95, 57, 71, 71, 6, 65, 46, 45, 4, 4.1); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(399));
        freeAgents.GetPlayerByID(400).ResetPlayerSkills(3, 93, 70, 59, 51, 58, 102, 45, 97, 58, 23, 49, 2, 5.2); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(400));
        freeAgents.GetPlayerByID(401).ResetPlayerSkills(4, 98, 55, 79, 65, 38, 40, 68, 25, 54, 5, 88, 1, 1); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(401));
        freeAgents.GetPlayerByID(261).ResetPlayerSkills(1, 71, 104, 36, 25, 25, 36, 55, 79, 45, 84, 95, 2, 3); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(261));
        freeAgents.GetPlayerByID(462).ResetPlayerSkills(3, 101, 38, 13, 18, 64, 66, 57, 76, 83, 70, 94, 1, 1); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(462));
        freeAgents.GetPlayerByID(404).ResetPlayerSkills(5, 67, 22, 63, 59, 97, 42, 91, 67, 61, 55, 93, 2, 2.5); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(404));
        freeAgents.GetPlayerByID(405).ResetPlayerSkills(1, 55, 99, 44, 18, 33, 40, 88, 83, 78, 94, 92, 3, 2.6); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(405));
        freeAgents.GetPlayerByID(1216).ResetPlayerSkills(5, 44, 48, 73, 60, 79, 23, 64, 42, 24, 11, 83, 2, 1); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(1216));
        freeAgents.GetPlayerByID(1217).ResetPlayerSkills(5, 36, 21, 42, 64, 66, 70, 50, 5, 18, 62, 89, 1, 1); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(1217));
        freeAgents.GetPlayerByID(676).ResetPlayerSkills(2, 61, 74, 71, 55, 62, 70, 87, 89, 67, 44, 91, 2, 3.4); create.getTeam(26).addPlayer(freeAgents.GetPlayerByID(676));

        freeAgents.GetPlayerByID(302).ResetPlayerSkills(1, 47, 91, 21, 17, 47, 95, 54, 99, 55, 49, 63, 1, 5); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(302));
        freeAgents.GetPlayerByID(303).ResetPlayerSkills(2, 77, 41, 14, 12, 25, 96, 67, 98, 73, 52, 61, 1, 8.6); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(303));
        freeAgents.GetPlayerByID(304).ResetPlayerSkills(3, 64, 38, 84, 81, 83, 104, 70, 75, 104, 48, 81, 3, 18.6); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(304));
        freeAgents.GetPlayerByID(305).ResetPlayerSkills(4, 72, 40, 102, 104, 65, 80, 60, 44, 100, 55, 59, 1, 12.7); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(305));
        freeAgents.GetPlayerByID(306).ResetPlayerSkills(5, 66, 33, 66, 73, 96, 89, 72, 47, 102, 54, 81, 1, 10); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(306));
        freeAgents.GetPlayerByID(307).ResetPlayerSkills(5, 68, 19, 91, 92, 78, 35, 63, 35, 55, 54, 90, 1, 5); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(307));
        freeAgents.GetPlayerByID(308).ResetPlayerSkills(4, 63, 18, 77, 84, 52, 39, 79, 10, 104, 54, 74, 1, 7); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(308));
        freeAgents.GetPlayerByID(309).ResetPlayerSkills(4, 50, 32, 86, 87, 52, 88, 51, 14, 84, 46, 79, 2, 5.3); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(309));
        freeAgents.GetPlayerByID(310).ResetPlayerSkills(5, 54, 5, 86, 89, 60, 36, 65, 26, 86, 50, 98, 3, 2.9); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(310));
        freeAgents.GetPlayerByID(311).ResetPlayerSkills(1, 87, 94, 32, 32, 31, 60, 51, 97, 35, 49, 63, 1, 2.4); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(311));
        freeAgents.GetPlayerByID(312).ResetPlayerSkills(2, 93, 56, 60, 57, 17, 59, 16, 70, 42, 54, 51, 1, 1); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(312));
        freeAgents.GetPlayerByID(313).ResetPlayerSkills(3, 48, 32, 85, 88, 11, 73, 51, 98, 24, 49, 86, 1, 2.3); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(313));
        freeAgents.GetPlayerByID(314).ResetPlayerSkills(2, 85, 96, 71, 65, 38, 78, 84, 75, 62, 40, 93, 3, 6.4); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(314));
        freeAgents.GetPlayerByID(315).ResetPlayerSkills(3, 56, 47, 93, 86, 30, 59, 95, 85, 54, 42, 78, 2, 5); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(315));
        freeAgents.GetPlayerByID(316).ResetPlayerSkills(1, 64, 92, 50, 8, 43, 38, 93, 66, 50, 9, 81, 2, 2); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(316));
        freeAgents.GetPlayerByID(1218).ResetPlayerSkills(4, 101, 20, 82, 53, 34, 81, 46, 30, 34, 11, 76, 2, 5); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(1218));
        freeAgents.GetPlayerByID(1219).ResetPlayerSkills(5, 38, 11, 69, 64, 80, 50, 34, 7, 26, 27, 100, 2, 1); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(1219));
        freeAgents.GetPlayerByID(540).ResetPlayerSkills(2, 64, 42, 46, 35, 71, 55, 78, 81, 86, 27, 49, 1, 2.3); create.getTeam(20).addPlayer(freeAgents.GetPlayerByID(540));

        freeAgents.GetPlayerByID(317).ResetPlayerSkills(1, 97, 74, 16, 23, 49, 77, 75, 71, 77, 50, 53, 2, 10.5); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(317));
        freeAgents.GetPlayerByID(318).ResetPlayerSkills(2, 92, 19, 61, 60, 64, 84, 69, 65, 73, 54, 52, 3, 4); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(318));
        freeAgents.GetPlayerByID(319).ResetPlayerSkills(3, 41, 73, 95, 103, 60, 78, 68, 51, 78, 53, 72, 5, 15.8); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(319));
        freeAgents.GetPlayerByID(571).ResetPlayerSkills(2, 33, 47, 40, 43, 80, 69, 71, 82, 56, 88, 66, 1, 1); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(571));
        freeAgents.GetPlayerByID(321).ResetPlayerSkills(5, 72, 18, 96, 151, 110, 73, 71, 29, 105, 49, 53, 1, 3); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(321));
        freeAgents.GetPlayerByID(322).ResetPlayerSkills(5, 62, 7, 57, 56, 93, 51, 64, 16, 17, 46, 80, 1, 3); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(322));
        freeAgents.GetPlayerByID(323).ResetPlayerSkills(4, 43, 25, 85, 74, 83, 35, 75, 33, 63, 45, 96, 2, 3.6); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(323));
        freeAgents.GetPlayerByID(324).ResetPlayerSkills(1, 81, 103, 23, 27, 38, 64, 39, 92, 77, 28, 53, 3, 4); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(324));
        freeAgents.GetPlayerByID(325).ResetPlayerSkills(3, 95, 37, 102, 98, 77, 79, 85, 14, 96, 45, 70, 1, 16.5); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(325));
        freeAgents.GetPlayerByID(326).ResetPlayerSkills(1, 68, 66, 30, 15, 22, 62, 96, 103, 73, 5, 79, 2, 3.7); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(326));
        freeAgents.GetPlayerByID(419).ResetPlayerSkills(5, 66, 27, 51, 42, 86, 45, 95, 87, 54, 51, 101, 1, 2.1); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(419));
        freeAgents.GetPlayerByID(328).ResetPlayerSkills(2, 100, 88, 30, 27, 53, 56, 77, 72, 47, 53, 102, 1, 8); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(328));
        freeAgents.GetPlayerByID(329).ResetPlayerSkills(3, 70, 91, 63, 63, 55, 71, 89, 5, 57, 53, 47, 3, 5.1); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(329));
        freeAgents.GetPlayerByID(330).ResetPlayerSkills(4, 87, 69, 88, 85, 53, 71, 35, 29, 82, 94, 85, 1, 3); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(330));
        freeAgents.GetPlayerByID(1220).ResetPlayerSkills(1, 59, 39, 31, 40, 32, 65, 79, 57, 70, 47, 56, 2, 5); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(1220));
        freeAgents.GetPlayerByID(530).ResetPlayerSkills(4, 21, 38, 91, 91, 91, 42, 30, 38, 46, 53, 49, 4, 4.5); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(530));
        freeAgents.GetPlayerByID(114).ResetPlayerSkills(4, 63, 81, 77, 88, 101, 81, 87, 22, 69, 16, 101, 1, 1); create.getTeam(21).addPlayer(freeAgents.GetPlayerByID(114));

        freeAgents.GetPlayerByID(46).ResetPlayerSkills(1, 99, 67, 56, 58, 31, 68, 73, 60, 68, 50, 83, 1, 7.8); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(46));
        freeAgents.GetPlayerByID(47).ResetPlayerSkills(2, 68, 104, 57, 60, 55, 56, 80, 104, 60, 47, 62, 4, 9.3); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(47));
        freeAgents.GetPlayerByID(48).ResetPlayerSkills(3, 76, 101, 70, 73, 60, 54, 62, 76, 92, 47, 78, 2, 6.7); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(48));
        freeAgents.GetPlayerByID(49).ResetPlayerSkills(4, 96, 25, 92, 86, 72, 61, 80, 36, 77, 54, 97, 1, 12.7); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(49));
        freeAgents.GetPlayerByID(50).ResetPlayerSkills(5, 46, 99, 67, 69, 104, 90, 88, 63, 84, 50, 76, 1, 10.1); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(50));
        freeAgents.GetPlayerByID(51).ResetPlayerSkills(5, 50, 81, 58, 69, 94, 101, 90, 26, 80, 17, 70, 1, 7.6); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(51));
        freeAgents.GetPlayerByID(855).ResetPlayerSkills(1, 76, 24, 47, 54, 12, 98, 29, 89, 56, 51, 53, 1, 2.4); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(855));
        freeAgents.GetPlayerByID(53).ResetPlayerSkills(1, 63, 95, 35, 34, 44, 58, 97, 70, 41, 51, 93, 1, 3.4); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(53));
        freeAgents.GetPlayerByID(54).ResetPlayerSkills(4, 66, 32, 90, 89, 56, 65, 81, 29, 78, 53, 82, 2, 5.2); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(54));
        freeAgents.GetPlayerByID(55).ResetPlayerSkills(4, 9, 31, 80, 77, 68, 50, 84, 11, 63, 49, 100, 3, 2.1); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(55));
        freeAgents.GetPlayerByID(56).ResetPlayerSkills(3, 41, 52, 96, 94, 48, 100, 87, 99, 36, 86, 75, 2, 10.5); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(56));
        freeAgents.GetPlayerByID(58).ResetPlayerSkills(5, 58, 10, 60, 72, 79, 89, 58, 91, 56, 41, 60, 1, 8); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(58));
        freeAgents.GetPlayerByID(59).ResetPlayerSkills(2, 83, 55, 64, 59, 34, 94, 30, 87, 58, 52, 51, 1, 1.7); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(59));
        freeAgents.GetPlayerByID(60).ResetPlayerSkills(3, 68, 73, 84, 80, 66, 18, 54, 36, 41, 54, 77, 1, 1.5); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(60));
        freeAgents.GetPlayerByID(1222).ResetPlayerSkills(1, 50, 77, 6, 29, 15, 45, 64, 86, 46, 42, 94, 2, 1); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(1222));
        freeAgents.GetPlayerByID(1223).ResetPlayerSkills(2, 58, 65, 8, 11, 79, 35, 45, 56, 81, 95, 88, 2, 5); create.getTeam(3).addPlayer(freeAgents.GetPlayerByID(1223));

        freeAgents.GetPlayerByID(406).ResetPlayerSkills(1, 60, 99, 11, 12, 33, 91, 104, 90, 79, 45, 53, 2, 4); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(406));
        freeAgents.GetPlayerByID(407).ResetPlayerSkills(2, 90, 61, 38, 36, 28, 75, 68, 73, 69, 46, 78, 1, 8.7); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(407));
        freeAgents.GetPlayerByID(408).ResetPlayerSkills(3, 25, 90, 74, 54, 66, 101, 82, 77, 98, 54, 93, 1, 6); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(408));
        freeAgents.GetPlayerByID(409).ResetPlayerSkills(4, 72, 38, 69, 67, 80, 92, 79, 26, 84, 53, 67, 3, 7.8); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(409));
        freeAgents.GetPlayerByID(410).ResetPlayerSkills(5, 51, 36, 103, 103, 122, 78, 76, 17, 98, 52, 66, 1, 25); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(410));
        freeAgents.GetPlayerByID(411).ResetPlayerSkills(3, 94, 79, 47, 46, 104, 56, 69, 28, 23, 54, 101, 3, 4); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(411));
        freeAgents.GetPlayerByID(412).ResetPlayerSkills(2, 83, 66, 56, 63, 15, 62, 56, 89, 69, 54, 98, 1, 5); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(412));
        freeAgents.GetPlayerByID(413).ResetPlayerSkills(5, 49, 9, 86, 89, 38, 85, 63, 36, 91, 54, 103, 4, 2); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(413));
        freeAgents.GetPlayerByID(414).ResetPlayerSkills(1, 85, 65, 34, 27, 54, 92, 60, 82, 26, 49, 77, 2, 3); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(414));
        freeAgents.GetPlayerByID(415).ResetPlayerSkills(3, 54, 5, 44, 38, 94, 85, 82, 96, 27, 46, 54, 1, 1); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(415));
        freeAgents.GetPlayerByID(295).ResetPlayerSkills(2, 89, 99, 58, 39, 28, 83, 72, 78, 28, 8, 63, 1, 1); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(295));
        freeAgents.GetPlayerByID(417).ResetPlayerSkills(4, 40, 34, 98, 101, 52, 72, 60, 11, 72, 49, 53, 5, 4); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(417));
        freeAgents.GetPlayerByID(320).ResetPlayerSkills(4, 78, 25, 83, 81, 102, 92, 80, 36, 89, 50, 90, 2, 21); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(320));
        freeAgents.GetPlayerByID(176).ResetPlayerSkills(5, 47, 7, 90, 86, 84, 76, 60, 15, 55, 53, 45, 1, 3.3); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(176));
        freeAgents.GetPlayerByID(420).ResetPlayerSkills(1, 90, 55, 51, 30, 25, 57, 57, 84, 78, 99, 74, 3, 2); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(420));
        freeAgents.GetPlayerByID(1224).ResetPlayerSkills(2, 65, 29, 32, 15, 37, 57, 64, 83, 101, 63, 74, 2, 5); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(1224));
        freeAgents.GetPlayerByID(1225).ResetPlayerSkills(2, 71, 73, 48, 21, 10, 64, 58, 97, 59, 83, 66, 2, 1); create.getTeam(27).addPlayer(freeAgents.GetPlayerByID(1225));

        freeAgents.GetPlayerByID(121).ResetPlayerSkills(1, 96, 28, 15, 20, 51, 82, 75, 67, 56, 51, 52, 1, 3.3); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(121));
        freeAgents.GetPlayerByID(422).ResetPlayerSkills(2, 84, 94, 37, 40, 44, 55, 68, 91, 97, 50, 103, 1, 6.2); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(422));
        freeAgents.GetPlayerByID(423).ResetPlayerSkills(3, 41, 99, 49, 50, 87, 70, 64, 76, 76, 51, 94, 2, 7.5); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(423));
        freeAgents.GetPlayerByID(230).ResetPlayerSkills(4, 48, 85, 91, 90, 51, 92, 86, 44, 104, 42, 66, 2, 15); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(230));
        freeAgents.GetPlayerByID(425).ResetPlayerSkills(5, 96, 26, 100, 100, 116, 95, 104, 37, 103, 45, 99, 3, 25); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(425));
        freeAgents.GetPlayerByID(426).ResetPlayerSkills(4, 42, 16, 88, 85, 69, 67, 60, 42, 82, 49, 58, 3, 3); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(426));
        freeAgents.GetPlayerByID(427).ResetPlayerSkills(2, 89, 103, 56, 47, 47, 81, 87, 57, 83, 12, 92, 1, 2); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(427));
        freeAgents.GetPlayerByID(428).ResetPlayerSkills(3, 23, 69, 95, 99, 31, 91, 51, 7, 75, 52, 68, 1, 4); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(428));
        freeAgents.GetPlayerByID(429).ResetPlayerSkills(1, 101, 88, 32, 39, 40, 97, 87, 101, 68, 15, 75, 3, 2); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(429));
        freeAgents.GetPlayerByID(430).ResetPlayerSkills(1, 91, 69, 26, 13, 41, 66, 81, 103, 60, 95, 103, 2, 3.4); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(430));
        freeAgents.GetPlayerByID(431).ResetPlayerSkills(4, 29, 44, 73, 90, 69, 59, 81, 14, 98, 16, 66, 1, 2.7); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(431));
        freeAgents.GetPlayerByID(432).ResetPlayerSkills(5, 61, 21, 103, 100, 74, 70, 9, 38, 41, 54, 45, 3, 2.4); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(432));
        freeAgents.GetPlayerByID(268).ResetPlayerSkills(5, 72, 31, 62, 50, 99, 64, 70, 92, 68, 42, 67, 2, 9); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(268));
        freeAgents.GetPlayerByID(434).ResetPlayerSkills(3, 56, 77, 74, 72, 20, 88, 37, 59, 58, 53, 101, 1, 1.6); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(434));
        freeAgents.GetPlayerByID(147).ResetPlayerSkills(2, 77, 85, 19, 14, 15, 65, 95, 103, 35, 39, 74, 1, 1.8); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(147));
        freeAgents.GetPlayerByID(1226).ResetPlayerSkills(4, 69, 19, 57, 65, 43, 72, 38, 9, 76, 6, 50, 2, 5); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(1226));
        freeAgents.GetPlayerByID(1227).ResetPlayerSkills(5, 30, 7, 41, 49, 69, 28, 32, 36, 97, 72, 82, 2, 1); create.getTeam(28).addPlayer(freeAgents.GetPlayerByID(1227));

        freeAgents.GetPlayerByID(167).ResetPlayerSkills(1, 90, 98, 28, 19, 54, 57, 92, 98, 52, 55, 86, 3, 7); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(167));
        freeAgents.GetPlayerByID(168).ResetPlayerSkills(2, 99, 61, 59, 61, 27, 104, 47, 69, 66, 48, 73, 2, 7.6); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(168));
        freeAgents.GetPlayerByID(169).ResetPlayerSkills(3, 13, 51, 84, 38, 103, 77, 56, 86, 92, 50, 96, 1, 3.4); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(169));
        freeAgents.GetPlayerByID(170).ResetPlayerSkills(4, 50, 36, 98, 98, 55, 66, 89, 18, 115, 52, 83, 2, 2.6); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(170));
        freeAgents.GetPlayerByID(171).ResetPlayerSkills(5, 59, 37, 72, 64, 93, 84, 70, 54, 78, 90, 66, 2, 10); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(171));
        freeAgents.GetPlayerByID(293).ResetPlayerSkills(5, 60, 17, 72, 66, 77, 90, 69, 43, 80, 52, 72, 1, 4); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(293));
        freeAgents.GetPlayerByID(173).ResetPlayerSkills(1, 101, 94, 16, 17, 27, 63, 52, 84, 73, 48, 95, 2, 4.2); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(173));
        freeAgents.GetPlayerByID(174).ResetPlayerSkills(4, 77, 25, 104, 96, 53, 55, 48, 30, 95, 51, 52, 4, 12.7); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(174));
        freeAgents.GetPlayerByID(175).ResetPlayerSkills(3, 5, 7, 92, 58, 80, 43, 80, 85, 95, 102, 62, 1, 5); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(175));
        freeAgents.GetPlayerByID(526).ResetPlayerSkills(5, 69, 14, 64, 38, 74, 60, 89, 75, 52, 81, 58, 1, 2.3); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(526));
        freeAgents.GetPlayerByID(7).ResetPlayerSkills(1, 82, 78, 18, 21, 27, 104, 48, 89, 41, 50, 69, 3, 4); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(7));
        freeAgents.GetPlayerByID(178).ResetPlayerSkills(2, 65, 75, 10, 12, 18, 91, 89, 77, 72, 51, 47, 2, 6.2); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(178));
        freeAgents.GetPlayerByID(179).ResetPlayerSkills(4, 91, 28, 71, 69, 11, 45, 66, 54, 75, 56, 103, 1, 3.7); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(179));
        freeAgents.GetPlayerByID(180).ResetPlayerSkills(3, 93, 97, 48, 46, 48, 75, 51, 55, 48, 20, 104, 2, 1.6); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(180));
        freeAgents.GetPlayerByID(181).ResetPlayerSkills(2, 78, 47, 37, 37, 48, 53, 70, 84, 95, 53, 97, 1, 1); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(181));
        freeAgents.GetPlayerByID(1228).ResetPlayerSkills(2, 29, 18, 9, 30, 65, 61, 35, 82, 98, 98, 103, 2, 1); create.getTeam(11).addPlayer(freeAgents.GetPlayerByID(1228));

        freeAgents.GetPlayerByID(61).ResetPlayerSkills(1, 95, 88, 64, 63, 51, 57, 45, 98, 64, 46, 82, 3, 7.5); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(61));
        freeAgents.GetPlayerByID(62).ResetPlayerSkills(2, 85, 83, 47, 45, 38, 48, 55, 73, 74, 49, 85, 2, 4); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(62));
        freeAgents.GetPlayerByID(340).ResetPlayerSkills(3, 13, 79, 104, 99, 15, 24, 103, 86, 92, 45, 68, 1, 11); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(340));
        freeAgents.GetPlayerByID(64).ResetPlayerSkills(4, 55, 11, 86, 89, 71, 97, 39, 21, 101, 46, 58, 3, 14.6); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(64));
        freeAgents.GetPlayerByID(65).ResetPlayerSkills(5, 58, 22, 47, 49, 104, 70, 71, 39, 61, 11, 68, 2, 6.8); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(65));
        freeAgents.GetPlayerByID(355).ResetPlayerSkills(3, 73, 96, 92, 66, 50, 84, 38, 90, 72, 55, 68, 1, 11); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(355));
        freeAgents.GetPlayerByID(780).ResetPlayerSkills(3, 74, 22, 43, 36, 72, 82, 49, 44, 92, 49, 46, 1, 2.3); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(780));
        freeAgents.GetPlayerByID(1271).ResetPlayerSkills(2, 6, 6, 7, 2, 3, 6, 5, 7, 5, 6, 8, 1, 5); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(1271));
        freeAgents.GetPlayerByID(69).ResetPlayerSkills(4, 51, 30, 91, 77, 71, 65, 58, 9, 55, 68, 61, 3, 7.3); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(69));
        freeAgents.GetPlayerByID(70).ResetPlayerSkills(2, 43, 95, 62, 57, 38, 27, 51, 93, 54, 46, 98, 1, 4.5); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(70));
        freeAgents.GetPlayerByID(71).ResetPlayerSkills(4, 85, 24, 100, 103, 46, 56, 73, 29, 66, 45, 73, 1, 7.8); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(71));
        freeAgents.GetPlayerByID(72).ResetPlayerSkills(5, 58, 59, 84, 90, 63, 102, 55, 24, 55, 24, 100, 2, 4.4); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(72));
        freeAgents.GetPlayerByID(682).ResetPlayerSkills(1, 52, 62, 63, 58, 50, 88, 61, 50, 44, 46, 68, 1, 1); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(682));
        freeAgents.GetPlayerByID(74).ResetPlayerSkills(5, 63, 51, 55, 63, 85, 55, 44, 40, 37, 23, 76, 2, 3); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(74));
        freeAgents.GetPlayerByID(75).ResetPlayerSkills(2, 82, 84, 40, 44, 31, 58, 28, 84, 73, 45, 73, 1, 1); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(75));
        freeAgents.GetPlayerByID(1229).ResetPlayerSkills(1, 16, 74, 8, 90, 35, 55, 46, 100, 36, 33, 56, 2, 1); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(1229));
        freeAgents.GetPlayerByID(1230).ResetPlayerSkills(4, 60, 18, 66, 64, 58, 48, 45, 30, 57, 29, 91, 2, 5); create.getTeam(4).addPlayer(freeAgents.GetPlayerByID(1230));

        freeAgents.GetPlayerByID(436).ResetPlayerSkills(1, 99, 65, 11, 8, 20, 104, 101, 104, 56, 51, 54, 2, 4.7); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(436));
        freeAgents.GetPlayerByID(437).ResetPlayerSkills(2, 98, 60, 93, 70, 33, 46, 83, 104, 58, 95, 66, 1, 5); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(437));
        freeAgents.GetPlayerByID(796).ResetPlayerSkills(3, 51, 21, 78, 79, 57, 59, 61, 52, 83, 50, 76, 3, 3.3); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(796));
        freeAgents.GetPlayerByID(781).ResetPlayerSkills(4, 19, 7, 102, 98, 47, 52, 79, 21, 80, 51, 67, 3, 3.6); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(781));
        freeAgents.GetPlayerByID(440).ResetPlayerSkills(5, 28, 34, 104, 97, 100, 81, 46, 14, 97, 47, 51, 2, 17.5); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(440));
        freeAgents.GetPlayerByID(441).ResetPlayerSkills(3, 97, 81, 89, 92, 99, 84, 68, 22, 101, 46, 47, 1, 22.5); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(441));
        freeAgents.GetPlayerByID(442).ResetPlayerSkills(1, 101, 97, 44, 28, 44, 77, 85, 96, 59, 5, 50, 1, 5); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(442));
        freeAgents.GetPlayerByID(443).ResetPlayerSkills(5, 68, 28, 67, 65, 97, 42, 77, 14, 16, 45, 50, 3, 1.8); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(443));
        freeAgents.GetPlayerByID(435).ResetPlayerSkills(2, 66, 80, 34, 42, 49, 39, 79, 86, 50, 60, 46, 1, 1); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(435));
        freeAgents.GetPlayerByID(446).ResetPlayerSkills(5, 66, 9, 77, 77, 99, 67, 80, 14, 30, 49, 49, 2, 4.1); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(446));
        freeAgents.GetPlayerByID(447).ResetPlayerSkills(1, 103, 102, 28, 29, 9, 68, 102, 85, 65, 26, 66, 3, 3.5); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(447));
        freeAgents.GetPlayerByID(448).ResetPlayerSkills(4, 71, 5, 95, 96, 57, 31, 30, 32, 93, 51, 86, 3, 6.4); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(448));
        freeAgents.GetPlayerByID(449).ResetPlayerSkills(3, 42, 15, 48, 49, 71, 89, 76, 70, 40, 99, 94, 1, 1.2); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(449));
        freeAgents.GetPlayerByID(450).ResetPlayerSkills(2, 61, 84, 48, 35, 43, 44, 48, 94, 76, 104, 50, 1, 1.7); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(450));
        freeAgents.GetPlayerByID(1231).ResetPlayerSkills(3, 102, 34, 53, 17, 89, 67, 51, 48, 28, 101, 70, 2, 5); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(1231));
        freeAgents.GetPlayerByID(1232).ResetPlayerSkills(4, 76, 35, 62, 38, 27, 35, 21, 44, 91, 87, 91, 2, 1); create.getTeam(29).addPlayer(freeAgents.GetPlayerByID(1232));

        freeAgents.GetPlayerByID(76).ResetPlayerSkills(1, 99, 79, 7, 5, 40, 74, 104, 100, 73, 54, 96, 2, 8.8); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(76));
        freeAgents.GetPlayerByID(77).ResetPlayerSkills(2, 82, 90, 57, 56, 51, 77, 73, 98, 70, 50, 102, 1, 3); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(77));
        freeAgents.GetPlayerByID(78).ResetPlayerSkills(3, 82, 95, 69, 73, 45, 88, 79, 76, 97, 50, 84, 1, 6.8); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(78));
        freeAgents.GetPlayerByID(79).ResetPlayerSkills(4, 85, 50, 98, 103, 65, 82, 77, 60, 70, 53, 75, 4, 18); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(79));
        freeAgents.GetPlayerByID(80).ResetPlayerSkills(5, 73, 54, 64, 96, 102, 78, 69, 42, 67, 46, 58, 3, 15); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(80));
        freeAgents.GetPlayerByID(811).ResetPlayerSkills(1, 103, 10, 53, 46, 32, 66, 57, 80, 20, 48, 73, 1, 2); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(811));
        freeAgents.GetPlayerByID(82).ResetPlayerSkills(5, 40, 20, 96, 86, 89, 48, 83, 40, 72, 66, 93, 7, 12); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(82));
        freeAgents.GetPlayerByID(85).ResetPlayerSkills(2, 75, 97, 74, 78, 79, 68, 62, 75, 94, 57, 78, 2, 3.1); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(85));
        freeAgents.GetPlayerByID(86).ResetPlayerSkills(5, 45, 34, 72, 66, 68, 69, 51, 40, 98, 53, 51, 1, 7.6); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(86));
        freeAgents.GetPlayerByID(87).ResetPlayerSkills(4, 42, 61, 61, 101, 50, 70, 66, 35, 92, 96, 101, 3, 1.4); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(87));
        freeAgents.GetPlayerByID(88).ResetPlayerSkills(1, 102, 10, 10, 5, 33, 68, 84, 88, 98, 50, 70, 4, 2.7); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(88));
        freeAgents.GetPlayerByID(89).ResetPlayerSkills(4, 73, 32, 96, 98, 66, 74, 51, 31, 49, 46, 52, 2, 7.3); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(89));
        freeAgents.GetPlayerByID(90).ResetPlayerSkills(3, 35, 51, 82, 84, 66, 57, 50, 39, 57, 50, 61, 1, 3); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(90));
        freeAgents.GetPlayerByID(1233).ResetPlayerSkills(2, 41, 53, 36, 13, 42, 59, 82, 82, 73, 69, 89, 2, 1); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(1233));
        freeAgents.GetPlayerByID(1234).ResetPlayerSkills(3, 12, 57, 39, 94, 102, 87, 64, 73, 72, 70, 61, 2, 5); create.getTeam(5).addPlayer(freeAgents.GetPlayerByID(1234));

        freeAgents.GetPlayerByID(182).ResetPlayerSkills(1, 51, 101, 21, 23, 42, 92, 84, 104, 74, 46, 63, 1, 7.8); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(182));
        freeAgents.GetPlayerByID(183).ResetPlayerSkills(2, 57, 41, 63, 66, 80, 67, 98, 71, 55, 101, 73, 1, 6.4); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(183));
        freeAgents.GetPlayerByID(184).ResetPlayerSkills(3, 66, 36, 32, 39, 55, 100, 85, 59, 89, 81, 83, 2, 4.5); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(184));
        freeAgents.GetPlayerByID(185).ResetPlayerSkills(4, 84, 34, 89, 90, 77, 82, 68, 13, 82, 54, 62, 3, 13.4); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(185));
        freeAgents.GetPlayerByID(186).ResetPlayerSkills(5, 65, 33, 88, 120, 97, 56, 46, 32, 100, 51, 52, 1, 17.8); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(186));
        freeAgents.GetPlayerByID(187).ResetPlayerSkills(1, 57, 87, 20, 22, 46, 74, 63, 78, 40, 51, 67, 1, 1.6); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(187));
        freeAgents.GetPlayerByID(188).ResetPlayerSkills(3, 48, 29, 70, 67, 70, 67, 73, 47, 92, 45, 81, 2, 2.1); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(188));
        freeAgents.GetPlayerByID(189).ResetPlayerSkills(4, 61, 16, 84, 83, 74, 46, 81, 11, 7, 50, 54, 3, 1.4); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(189));
        freeAgents.GetPlayerByID(190).ResetPlayerSkills(5, 51, 55, 79, 81, 98, 67, 67, 57, 102, 45, 55, 4, 8.5); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(190));
        freeAgents.GetPlayerByID(191).ResetPlayerSkills(1, 100, 67, 23, 19, 73, 53, 64, 64, 48, 51, 45, 1, 1.1); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(191));
        freeAgents.GetPlayerByID(192).ResetPlayerSkills(5, 31, 28, 94, 93, 61, 82, 59, 17, 70, 49, 53, 2, 2.8); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(192));
        freeAgents.GetPlayerByID(193).ResetPlayerSkills(2, 86, 87, 42, 54, 73, 70, 37, 64, 59, 83, 66, 3, 1.3); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(193));
        freeAgents.GetPlayerByID(195).ResetPlayerSkills(3, 59, 75, 58, 71, 32, 73, 58, 51, 84, 27, 67, 1, 1.5); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(195));
        freeAgents.GetPlayerByID(196).ResetPlayerSkills(4, 53, 17, 90, 93, 47, 77, 74, 21, 93, 49, 51, 2, 4); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(196));
        freeAgents.GetPlayerByID(1235).ResetPlayerSkills(2, 63, 67, 6, 8, 51, 60, 35, 94, 37, 66, 69, 2, 1); create.getTeam(12).addPlayer(freeAgents.GetPlayerByID(1235));

        freeAgents.GetPlayerByID(451).ResetPlayerSkills(1, 99, 65, 36, 43, 9, 56, 78, 81, 52, 45, 55, 1, 6); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(451));
        freeAgents.GetPlayerByID(452).ResetPlayerSkills(2, 92, 59, 36, 35, 53, 46, 98, 92, 56, 45, 49, 2, 3.1); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(452));
        freeAgents.GetPlayerByID(453).ResetPlayerSkills(3, 16, 79, 101, 103, 68, 101, 97, 103, 104, 49, 82, 4, 18.5); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(453));
        freeAgents.GetPlayerByID(454).ResetPlayerSkills(4, 69, 18, 101, 100, 91, 79, 85, 29, 97, 46, 78, 4, 5.3); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(454));
        freeAgents.GetPlayerByID(455).ResetPlayerSkills(5, 54, 17, 99, 98, 97, 76, 67, 43, 57, 47, 62, 3, 2.1); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(455));
        freeAgents.GetPlayerByID(456).ResetPlayerSkills(4, 70, 8, 96, 95, 51, 77, 83, 31, 18, 47, 99, 3, 5.7); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(456));
        freeAgents.GetPlayerByID(457).ResetPlayerSkills(2, 68, 84, 43, 24, 45, 82, 80, 92, 57, 81, 92, 1, 1); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(457));
        freeAgents.GetPlayerByID(213).ResetPlayerSkills(2, 86, 32, 91, 93, 77, 75, 80, 74, 101, 45, 56, 2, 11); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(213));
        freeAgents.GetPlayerByID(459).ResetPlayerSkills(5, 38, 48, 75, 77, 103, 50, 49, 46, 72, 48, 50, 2, 3.1); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(459));
        freeAgents.GetPlayerByID(460).ResetPlayerSkills(3, 50, 52, 63, 64, 75, 70, 37, 37, 81, 53, 55, 1, 1); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(460));
        freeAgents.GetPlayerByID(463).ResetPlayerSkills(1, 77, 61, 32, 37, 43, 45, 83, 81, 77, 101, 76, 2, 1.8); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(463));
        freeAgents.GetPlayerByID(464).ResetPlayerSkills(1, 102, 100, 21, 11, 53, 72, 103, 89, 82, 74, 98, 3, 7.7); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(464));
        freeAgents.GetPlayerByID(465).ResetPlayerSkills(5, 65, 31, 48, 51, 71, 65, 50, 88, 48, 45, 99, 1, 1); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(465));
        freeAgents.GetPlayerByID(1236).ResetPlayerSkills(3, 69, 67, 55, 42, 51, 56, 56, 60, 61, 83, 102, 2, 5); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(1236));
        freeAgents.GetPlayerByID(1237).ResetPlayerSkills(4, 72, 18, 59, 51, 49, 51, 78, 35, 52, 37, 84, 2, 1); create.getTeam(30).addPlayer(freeAgents.GetPlayerByID(1237));

        freeAgents.GetPlayerByID(197).ResetPlayerSkills(1, 94, 77, 36, 44, 55, 102, 74, 124, 67, 99, 48, 1, 10.8); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(197));
        freeAgents.GetPlayerByID(198).ResetPlayerSkills(2, 86, 102, 74, 49, 50, 75, 64, 66, 57, 74, 103, 3, 6.4); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(198));
        freeAgents.GetPlayerByID(199).ResetPlayerSkills(3, 57, 100, 94, 92, 68, 73, 47, 103, 73, 103, 95, 2, 10.2); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(199));
        freeAgents.GetPlayerByID(200).ResetPlayerSkills(4, 76, 24, 85, 91, 81, 98, 91, 9, 85, 46, 101, 1, 10.1); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(200));
        freeAgents.GetPlayerByID(201).ResetPlayerSkills(5, 52, 54, 99, 77, 79, 46, 84, 13, 97, 48, 63, 1, 10); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(201));
        freeAgents.GetPlayerByID(202).ResetPlayerSkills(5, 32, 31, 101, 104, 65, 36, 26, 8, 52, 53, 90, 3, 2.1); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(202));
        freeAgents.GetPlayerByID(203).ResetPlayerSkills(4, 17, 41, 102, 96, 35, 49, 68, 41, 56, 47, 100, 2, 2); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(203));
        freeAgents.GetPlayerByID(204).ResetPlayerSkills(5, 78, 34, 48, 72, 87, 57, 71, 82, 58, 16, 52, 3, 4.5); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(204));
        freeAgents.GetPlayerByID(205).ResetPlayerSkills(2, 83, 77, 46, 39, 39, 87, 37, 70, 49, 58, 100, 1, 1); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(205));
        freeAgents.GetPlayerByID(206).ResetPlayerSkills(3, 55, 47, 88, 104, 18, 62, 71, 99, 65, 26, 52, 1, 3.5); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(206));
        freeAgents.GetPlayerByID(207).ResetPlayerSkills(2, 65, 38, 59, 55, 9, 78, 59, 57, 49, 45, 85, 3, 1); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(207));
        freeAgents.GetPlayerByID(208).ResetPlayerSkills(4, 62, 22, 77, 79, 69, 15, 16, 38, 68, 48, 81, 2, 1.4); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(208));
        freeAgents.GetPlayerByID(84).ResetPlayerSkills(1, 80, 100, 30, 35, 25, 102, 35, 69, 81, 104, 60, 1, 6); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(84));
        freeAgents.GetPlayerByID(222).ResetPlayerSkills(1, 66, 62, 37, 27, 19, 36, 79, 103, 62, 82, 94, 1, 1); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(222));
        freeAgents.GetPlayerByID(1238).ResetPlayerSkills(3, 95, 64, 73, 78, 60, 78, 66, 81, 93, 56, 83, 2, 5); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(1238));
        freeAgents.GetPlayerByID(1239).ResetPlayerSkills(4, 80, 42, 36, 27, 35, 37, 93, 22, 87, 73, 94, 2, 1); create.getTeam(13).addPlayer(freeAgents.GetPlayerByID(1239));

        freeAgents.GetPlayerByID(112).ResetPlayerSkills(2, 36, 89, 36, 39, 50, 95, 104, 103, 77, 53, 94, 1, 9.5); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(112));
        freeAgents.GetPlayerByID(92).ResetPlayerSkills(2, 99, 93, 33, 32, 39, 56, 36, 99, 43, 45, 95, 1, 4); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(92));
        freeAgents.GetPlayerByID(93).ResetPlayerSkills(3, 76, 84, 91, 28, 58, 64, 93, 92, 98, 54, 47, 1, 8.7); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(93));
        freeAgents.GetPlayerByID(94).ResetPlayerSkills(4, 72, 60, 91, 81, 60, 60, 69, 21, 56, 19, 62, 2, 6.5); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(94));
        freeAgents.GetPlayerByID(95).ResetPlayerSkills(5, 76, 30, 56, 25, 101, 62, 42, 75, 65, 22, 90, 3, 5.8); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(95));
        freeAgents.GetPlayerByID(96).ResetPlayerSkills(2, 79, 97, 71, 63, 45, 72, 50, 71, 53, 46, 75, 2, 1.8); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(96));
        freeAgents.GetPlayerByID(280).ResetPlayerSkills(1, 83, 94, 73, 66, 75, 74, 49, 85, 47, 61, 98, 1, 1.5); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(280));
        freeAgents.GetPlayerByID(1268).ResetPlayerSkills(1, 55, 56, 60, 59, 9, 69, 64, 88, 62, 23, 52, 1, 1); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(1268));
        freeAgents.GetPlayerByID(99).ResetPlayerSkills(3, 91, 26, 102, 102, 100, 13, 53, 37, 60, 46, 66, 1, 3.7); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(99));
        freeAgents.GetPlayerByID(100).ResetPlayerSkills(5, 43, 44, 52, 46, 104, 71, 76, 49, 42, 53, 56, 1, 6.4); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(100));
        freeAgents.GetPlayerByID(101).ResetPlayerSkills(4, 37, 8, 95, 100, 66, 82, 74, 25, 84, 51, 49, 3, 8.4); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(101));
        freeAgents.GetPlayerByID(102).ResetPlayerSkills(3, 46, 16, 96, 72, 45, 65, 82, 17, 80, 54, 85, 1, 3.7); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(102));
        freeAgents.GetPlayerByID(461).ResetPlayerSkills(4, 104, 26, 64, 59, 51, 84, 88, 50, 60, 51, 76, 1, 1); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(461));
        freeAgents.GetPlayerByID(105).ResetPlayerSkills(5, 15, 30, 83, 82, 74, 73, 74, 39, 81, 45, 79, 2, 7.4); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(105));
        freeAgents.GetPlayerByID(1240).ResetPlayerSkills(1, 55, 100, 43, 18, 53, 66, 69, 150, 66, 29, 84, 2, 5); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(1240));
        freeAgents.GetPlayerByID(1241).ResetPlayerSkills(5, 27, 56, 65, 34, 102, 57, 53, 38, 74, 29, 46, 2, 1); create.getTeam(6).addPlayer(freeAgents.GetPlayerByID(1241));

        freeAgents.GetPlayerByID(212).ResetPlayerSkills(1, 84, 43, 40, 37, 47, 101, 86, 102, 64, 54, 97, 1, 7.9); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(212));
        freeAgents.GetPlayerByID(214).ResetPlayerSkills(3, 88, 102, 98, 48, 92, 100, 88, 97, 102, 52, 80, 3, 20.6); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(214));
        freeAgents.GetPlayerByID(215).ResetPlayerSkills(4, 58, 20, 95, 96, 73, 94, 80, 15, 87, 54, 51, 4, 17.6); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(215));
        freeAgents.GetPlayerByID(216).ResetPlayerSkills(5, 98, 19, 147, 96, 102, 103, 99, 37, 99, 46, 94, 3, 25); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(216));
        freeAgents.GetPlayerByID(217).ResetPlayerSkills(5, 32, 48, 94, 99, 89, 58, 44, 14, 75, 15, 99, 1, 5.6); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(217));
        freeAgents.GetPlayerByID(57).ResetPlayerSkills(1, 47, 67, 54, 46, 23, 36, 71, 97, 44, 47, 94, 2, 6.7); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(57));
        freeAgents.GetPlayerByID(219).ResetPlayerSkills(4, 69, 8, 92, 88, 52, 75, 72, 15, 82, 52, 73, 4, 9.9); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(219));
        freeAgents.GetPlayerByID(220).ResetPlayerSkills(3, 104, 77, 87, 94, 54, 84, 38, 65, 72, 50, 74, 5, 12.2); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(220));
        freeAgents.GetPlayerByID(221).ResetPlayerSkills(4, 37, 37, 77, 84, 55, 53, 66, 43, 69, 54, 84, 3, 1.9); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(221));
        freeAgents.GetPlayerByID(218).ResetPlayerSkills(2, 95, 93, 29, 30, 35, 62, 76, 85, 81, 80, 81, 1, 2.4); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(218));
        freeAgents.GetPlayerByID(585).ResetPlayerSkills(2, 31, 81, 23, 18, 42, 98, 62, 78, 72, 46, 84, 2, 1.5); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(585));
        freeAgents.GetPlayerByID(224).ResetPlayerSkills(3, 66, 85, 53, 48, 26, 49, 96, 71, 74, 55, 77, 3, 5.6); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(224));
        freeAgents.GetPlayerByID(23).ResetPlayerSkills(5, 52, 35, 92, 89, 103, 41, 70, 41, 58, 53, 52, 1, 7.4); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(23));
        freeAgents.GetPlayerByID(226).ResetPlayerSkills(1, 45, 91, 48, 27, 39, 36, 87, 89, 68, 55, 65, 1, 1.7); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(226));
        freeAgents.GetPlayerByID(1242).ResetPlayerSkills(1, 91, 12, 22, 42, 37, 59, 56, 67, 35, 45, 53, 2, 1); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(1242));
        freeAgents.GetPlayerByID(1243).ResetPlayerSkills(2, 97, 64, 28, 29, 49, 75, 68, 98, 58, 52, 84, 2, 5); create.getTeam(14).addPlayer(freeAgents.GetPlayerByID(1243));

        freeAgents.GetPlayerByID(227).ResetPlayerSkills(1, 78, 30, 50, 49, 27, 88, 87, 88, 56, 50, 62, 3, 7.4); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(227));
        freeAgents.GetPlayerByID(228).ResetPlayerSkills(2, 81, 89, 38, 21, 28, 88, 91, 84, 84, 92, 94, 3, 6.5); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(228));
        freeAgents.GetPlayerByID(229).ResetPlayerSkills(3, 84, 45, 96, 104, 99, 85, 85, 51, 57, 48, 65, 3, 8.3); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(229));
        freeAgents.GetPlayerByID(439).ResetPlayerSkills(4, 87, 42, 101, 95, 78, 93, 82, 30, 59, 52, 73, 1, 10); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(439));
        freeAgents.GetPlayerByID(231).ResetPlayerSkills(5, 42, 33, 67, 66, 104, 88, 89, 18, 102, 49, 62, 1, 8.9); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(231));
        freeAgents.GetPlayerByID(232).ResetPlayerSkills(2, 104, 17, 36, 41, 47, 59, 69, 61, 52, 45, 81, 3, 1); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(232));
        freeAgents.GetPlayerByID(233).ResetPlayerSkills(1, 100, 98, 14, 10, 49, 97, 86, 103, 66, 47, 50, 2, 5.9); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(233));
        freeAgents.GetPlayerByID(234).ResetPlayerSkills(1, 84, 73, 50, 54, 51, 70, 57, 65, 45, 72, 84, 1, 3.1); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(234));
        freeAgents.GetPlayerByID(235).ResetPlayerSkills(5, 6, 37, 97, 104, 89, 84, 35, 36, 25, 49, 50, 1, 6.4); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(235));
        freeAgents.GetPlayerByID(236).ResetPlayerSkills(5, 82, 29, 49, 50, 99, 81, 93, 75, 50, 14, 45, 3, 8); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(236));
        freeAgents.GetPlayerByID(237).ResetPlayerSkills(4, 60, 5, 57, 58, 72, 90, 59, 32, 68, 54, 61, 2, 5); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(237));
        freeAgents.GetPlayerByID(859).ResetPlayerSkills(2, 78, 47, 60, 55, 16, 57, 30, 59, 74, 54, 48, 1, 1); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(859));
        freeAgents.GetPlayerByID(21).ResetPlayerSkills(3, 53, 80, 26, 30, 75, 89, 66, 72, 67, 49, 75, 1, 3.2); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(21));
        freeAgents.GetPlayerByID(363).ResetPlayerSkills(3, 51, 97, 50, 54, 16, 70, 65, 62, 79, 51, 78, 1, 2.7); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(363));
        freeAgents.GetPlayerByID(1244).ResetPlayerSkills(1, 76, 50, 14, 16, 36, 86, 40, 83, 63, 73, 76, 2, 5); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(1244));
        freeAgents.GetPlayerByID(1245).ResetPlayerSkills(4, 90, 14, 75, 19, 53, 38, 44, 29, 74, 92, 81, 2, 1); create.getTeam(15).addPlayer(freeAgents.GetPlayerByID(1245));

        freeAgents.GetPlayerByID(106).ResetPlayerSkills(1, 102, 40, 64, 52, 81, 78, 98, 92, 101, 54, 84, 1, 10.5); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(106));
        freeAgents.GetPlayerByID(107).ResetPlayerSkills(2, 70, 105, 66, 51, 80, 79, 84, 90, 101, 48, 72, 1, 10.5); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(107));
        freeAgents.GetPlayerByID(108).ResetPlayerSkills(3, 95, 37, 143, 139, 89, 100, 103, 13, 118, 54, 68, 4, 25); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(108));
        freeAgents.GetPlayerByID(109).ResetPlayerSkills(4, 55, 17, 103, 104, 99, 86, 84, 16, 98, 57, 73, 2, 15); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(109));
        freeAgents.GetPlayerByID(110).ResetPlayerSkills(5, 87, 54, 104, 102, 84, 69, 84, 37, 100, 52, 82, 2, 8.5); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(110));
        freeAgents.GetPlayerByID(91).ResetPlayerSkills(1, 91, 39, 27, 32, 10, 99, 102, 126, 67, 48, 84, 1, 2.1); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(91));
        freeAgents.GetPlayerByID(117).ResetPlayerSkills(2, 59, 48, 48, 55, 45, 83, 47, 63, 87, 55, 60, 1, 3); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(117));
        freeAgents.GetPlayerByID(113).ResetPlayerSkills(3, 71, 53, 102, 97, 77, 101, 57, 32, 99, 52, 45, 1, 4.5); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(113));
        freeAgents.GetPlayerByID(98).ResetPlayerSkills(4, 93, 68, 104, 95, 57, 59, 63, 42, 64, 64, 100, 2, 6); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(98));
        freeAgents.GetPlayerByID(115).ResetPlayerSkills(5, 23, 84, 72, 67, 97, 68, 75, 41, 67, 46, 95, 2, 9.5); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(115));
        freeAgents.GetPlayerByID(116).ResetPlayerSkills(1, 77, 103, 11, 13, 26, 71, 76, 79, 58, 47, 46, 2, 4); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(116));
        freeAgents.GetPlayerByID(1246).ResetPlayerSkills(2, 46, 64, 25, 44, 29, 74, 57, 67, 51, 44, 72, 2, 5); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(1246));
        freeAgents.GetPlayerByID(118).ResetPlayerSkills(3, 9, 88, 34, 37, 94, 65, 88, 35, 51, 7, 96, 2, 3.5); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(118));
        freeAgents.GetPlayerByID(1221).ResetPlayerSkills(4, 77, 32, 47, 49, 30, 75, 48, 40, 48, 82, 104, 2, 5); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(1221));
        freeAgents.GetPlayerByID(120).ResetPlayerSkills(5, 69, 7, 59, 28, 68, 46, 97, 87, 73, 23, 52, 2, 3); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(120));
        freeAgents.GetPlayerByID(152).ResetPlayerSkills(1, 88, 79, 31, 30, 43, 92, 41, 78, 47, 53, 98, 4, 5); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(152));
        freeAgents.GetPlayerByID(990).ResetPlayerSkills(1, 41, 49, 58, 60, 22, 87, 62, 27, 41, 48, 57, 4, 3.5); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(990));
        freeAgents.GetPlayerByID(1247).ResetPlayerSkills(4, 73, 11, 46, 50, 18, 29, 64, 42, 26, 93, 62, 2, 1); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(1247));
        freeAgents.GetPlayerByID(103).ResetPlayerSkills(2, 77, 65, 44, 42, 27, 52, 82, 95, 74, 45, 48, 4, 5.5); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(103));
        freeAgents.GetPlayerByID(1000).ResetPlayerSkills(2, 64, 46, 25, 33, 37, 79, 52, 70, 22, 54, 51, 4, 5); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(1000));
        freeAgents.GetPlayerByID(238).ResetPlayerSkills(3, 53, 36, 84, 75, 87, 63, 39, 50, 30, 54, 58, 4, 3); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(238));
        freeAgents.GetPlayerByID(403).ResetPlayerSkills(3, 57, 98, 33, 30, 83, 51, 63, 48, 58, 54, 76, 4, 4); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(403));
        freeAgents.GetPlayerByID(1102).ResetPlayerSkills(4, 11, 43, 91, 87, 47, 46, 78, 28, 11, 45, 49, 4, 3.5); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(1102));
        freeAgents.GetPlayerByID(433).ResetPlayerSkills(5, 49, 42, 59, 60, 75, 45, 60, 17, 81, 59, 83, 4, 4); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(433));
        freeAgents.GetPlayerByID(382).ResetPlayerSkills(5, 68, 52, 50, 45, 76, 60, 57, 19, 49, 46, 69, 4, 4); create.getTeam(7).addPlayer(freeAgents.GetPlayerByID(382));
        
        freeAgents.GetPlayerByID(331).ResetPlayerSkills(1, 79, 86, 30, 29, 25, 104, 68, 115, 64, 45, 53, 1, 8.5); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(331));
        freeAgents.GetPlayerByID(332).ResetPlayerSkills(2, 60, 45, 48, 51, 33, 98, 55, 96, 44, 52, 89, 2, 1.4); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(332));
        freeAgents.GetPlayerByID(333).ResetPlayerSkills(3, 45, 60, 85, 87, 47, 53, 48, 79, 35, 18, 100, 1, 1.6); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(333));
        freeAgents.GetPlayerByID(334).ResetPlayerSkills(4, 27, 83, 98, 84, 68, 75, 68, 13, 56, 74, 87, 1, 5.4); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(334));
        freeAgents.GetPlayerByID(335).ResetPlayerSkills(5, 69, 35, 80, 70, 96, 70, 69, 44, 101, 94, 85, 2, 14.6); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(335));
        freeAgents.GetPlayerByID(336).ResetPlayerSkills(1, 47, 94, 40, 21, 41, 70, 67, 101, 54, 95, 68, 3, 3.8); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(336));
        freeAgents.GetPlayerByID(337).ResetPlayerSkills(4, 48, 28, 98, 96, 43, 46, 63, 11, 79, 47, 50, 3, 4); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(337));
        freeAgents.GetPlayerByID(338).ResetPlayerSkills(5, 62, 24, 70, 67, 74, 103, 50, 64, 26, 46, 83, 2, 3); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(338));
        freeAgents.GetPlayerByID(339).ResetPlayerSkills(2, 61, 79, 41, 30, 47, 71, 57, 86, 66, 103, 69, 1, 1); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(339));
        freeAgents.GetPlayerByID(512).ResetPlayerSkills(1, 92, 89, 44, 45, 53, 78, 69, 49, 41, 80, 50, 1, 1.8); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(512));
        freeAgents.GetPlayerByID(438).ResetPlayerSkills(3, 104, 86, 103, 99, 116, 88, 97, 74, 117, 71, 103, 3, 15); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(438));
        freeAgents.GetPlayerByID(342).ResetPlayerSkills(5, 58, 5, 73, 69, 84, 35, 69, 28, 68, 52, 101, 1, 8.7); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(342));
        freeAgents.GetPlayerByID(177).ResetPlayerSkills(2, 69, 77, 40, 44, 76, 89, 85, 78, 59, 33, 99, 3, 14.5); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(177));
        freeAgents.GetPlayerByID(675).ResetPlayerSkills(2, 89, 44, 18, 23, 44, 98, 63, 86, 48, 53, 54, 1, 3.2); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(675));
        freeAgents.GetPlayerByID(143).ResetPlayerSkills(2, 85, 62, 58, 15, 45, 39, 46, 96, 84, 41, 49, 3, 6.7); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(143));
        freeAgents.GetPlayerByID(1248).ResetPlayerSkills(4, 18, 18, 9, 83, 49, 45, 72, 27, 84, 67, 86, 2, 5); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(1248));
        freeAgents.GetPlayerByID(1249).ResetPlayerSkills(3, 28, 58, 35, 88, 9, 65, 51, 31, 90, 83, 81, 2, 1); create.getTeam(22).addPlayer(freeAgents.GetPlayerByID(1249));

        freeAgents.GetPlayerByID(346).ResetPlayerSkills(1, 101, 60, 21, 19, 54, 97, 84, 124, 60, 51, 54, 3, 10.2); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(346));
        freeAgents.GetPlayerByID(347).ResetPlayerSkills(2, 101, 62, 63, 52, 34, 54, 58, 97, 60, 29, 84, 3, 6.7); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(347));
        freeAgents.GetPlayerByID(348).ResetPlayerSkills(3, 79, 88, 100, 95, 81, 68, 70, 65, 80, 53, 89, 1, 20); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(348));
        freeAgents.GetPlayerByID(349).ResetPlayerSkills(4, 100, 53, 101, 102, 11, 50, 61, 48, 54, 61, 55, 4, 8.7); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(349));
        freeAgents.GetPlayerByID(350).ResetPlayerSkills(5, 101, 73, 60, 60, 106, 73, 63, 16, 58, 84, 49, 1, 8.9); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(350));
        freeAgents.GetPlayerByID(351).ResetPlayerSkills(4, 59, 86, 93, 100, 47, 62, 64, 36, 81, 92, 48, 2, 8.8); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(351));
        freeAgents.GetPlayerByID(352).ResetPlayerSkills(4, 74, 19, 87, 87, 35, 79, 63, 7, 101, 51, 94, 2, 5.8); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(352));
        freeAgents.GetPlayerByID(353).ResetPlayerSkills(5, 64, 62, 63, 96, 84, 72, 80, 16, 82, 98, 93, 3, 8.8); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(353));
        freeAgents.GetPlayerByID(398).ResetPlayerSkills(2, 98, 74, 35, 40, 49, 88, 75, 79, 77, 49, 81, 1, 1); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(398));
        freeAgents.GetPlayerByID(510).ResetPlayerSkills(3, 21, 60, 46, 87, 90, 83, 51, 27, 99, 10, 89, 2, 8.8); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(510));
        freeAgents.GetPlayerByID(825).ResetPlayerSkills(3, 17, 52, 96, 99, 36, 92, 33, 38, 84, 46, 48, 2, 8.6); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(825));
        freeAgents.GetPlayerByID(357).ResetPlayerSkills(2, 57, 70, 56, 58, 72, 90, 85, 59, 58, 61, 89, 2, 3.8); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(357));
        freeAgents.GetPlayerByID(358).ResetPlayerSkills(1, 96, 101, 8, 17, 42, 71, 62, 82, 55, 48, 45, 1, 6.3); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(358));
        freeAgents.GetPlayerByID(359).ResetPlayerSkills(5, 49, 17, 81, 83, 80, 70, 67, 39, 74, 47, 45, 1, 7.4); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(359));
        freeAgents.GetPlayerByID(301).ResetPlayerSkills(4, 69, 27, 64, 59, 69, 93, 83, 44, 57, 52, 58, 3, 4.8); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(301));
        freeAgents.GetPlayerByID(287).ResetPlayerSkills(1, 98, 91, 23, 20, 34, 88, 91, 77, 68, 54, 98, 2, 7.9); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(287));
        freeAgents.GetPlayerByID(1250).ResetPlayerSkills(2, 40, 45, 59, 42, 51, 37, 100, 69, 57, 6, 97, 2, 1); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(1250));
        freeAgents.GetPlayerByID(1251).ResetPlayerSkills(2, 57, 81, 42, 63, 20, 39, 83, 80, 49, 56, 57, 2, 5); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(1251));
        freeAgents.GetPlayerByID(1252).ResetPlayerSkills(4, 61, 27, 52, 53, 72, 19, 63, 35, 60, 40, 47, 2, 5); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(1252));
        freeAgents.GetPlayerByID(1253).ResetPlayerSkills(5, 69, 42, 49, 20, 67, 34, 49, 12, 29, 69, 79, 2, 5); create.getTeam(23).addPlayer(freeAgents.GetPlayerByID(1253));

        freeAgents.GetPlayerByID(466).ResetPlayerSkills(1, 86, 71, 7, 11, 45, 46, 85, 97, 55, 47, 67, 1, 3.6); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(466));
        freeAgents.GetPlayerByID(467).ResetPlayerSkills(2, 64, 84, 44, 43, 44, 69, 48, 77, 67, 52, 68, 2, 4.2); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(467));
        freeAgents.GetPlayerByID(468).ResetPlayerSkills(3, 85, 25, 104, 95, 39, 83, 83, 72, 53, 53, 83, 1, 8.8); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(468));
        freeAgents.GetPlayerByID(469).ResetPlayerSkills(4, 57, 14, 103, 98, 83, 75, 84, 37, 97, 47, 69, 1, 12.5); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(469));
        freeAgents.GetPlayerByID(470).ResetPlayerSkills(5, 55, 35, 100, 101, 97, 80, 79, 13, 85, 75, 94, 5, 17.6); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(470));
        freeAgents.GetPlayerByID(471).ResetPlayerSkills(2, 86, 54, 26, 26, 60, 71, 31, 85, 37, 49, 96, 2, 2.8); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(471));
        freeAgents.GetPlayerByID(472).ResetPlayerSkills(1, 86, 101, 40, 39, 31, 94, 25, 61, 18, 45, 63, 1, 2); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(472));
        freeAgents.GetPlayerByID(473).ResetPlayerSkills(5, 63, 18, 69, 70, 83, 39, 68, 34, 51, 53, 82, 1, 5.6); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(473));
        freeAgents.GetPlayerByID(474).ResetPlayerSkills(2, 104, 56, 33, 32, 52, 59, 58, 75, 57, 51, 70, 1, 1); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(474));
        freeAgents.GetPlayerByID(475).ResetPlayerSkills(3, 88, 70, 68, 78, 50, 76, 103, 62, 63, 52, 90, 3, 8.5); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(475));
        freeAgents.GetPlayerByID(476).ResetPlayerSkills(5, 57, 40, 69, 71, 73, 73, 57, 25, 35, 53, 95, 2, 5.6); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(476));
        freeAgents.GetPlayerByID(424).ResetPlayerSkills(4, 70, 9, 95, 77, 73, 95, 83, 42, 63, 52, 61, 2, 4.3); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(424));
        freeAgents.GetPlayerByID(327).ResetPlayerSkills(5, 74, 9, 60, 33, 96, 75, 53, 69, 47, 100, 73, 2, 10); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(327));
        freeAgents.GetPlayerByID(480).ResetPlayerSkills(3, 43, 62, 84, 100, 75, 67, 57, 57, 91, 84, 79, 4, 5.8); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(480));
        freeAgents.GetPlayerByID(300).ResetPlayerSkills(4, 68, 8, 102, 107, 49, 86, 87, 21, 103, 51, 45, 1, 4.5); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(300));
        freeAgents.GetPlayerByID(1254).ResetPlayerSkills(1, 97, 15, 39, 46, 55, 68, 66, 72, 75, 45, 65, 2, 1); create.getTeam(31).addPlayer(freeAgents.GetPlayerByID(1254));

        for (int i = 0; i < create.size(); i++)
        {
            if (create.getTeam(i).getAllPlayer().Count < 15) create.getTeam(i).ResizeRoster(freeAgents);
            freeAgents.Remove(create.getTeam(i).getAllPlayer());
            freeAgents.Remove(create.getTeam(i).GetAffiliate().getAllPlayer());
        }
    }
    private void ResizeRoster()
    {
        for (int i = 0; i < create.size(); i++)
        {
            create.getTeam(i).ResizeRoster(freeAgents);
            create.getTeam(i).GetAffiliate().CreateRoster(freeAgents);
        }
    }
    private void PrintInformation()
    {
        PrintRosters(create.getTeams(), "rosters.csv");
        PrintRosters(create.getDLeagueTeams(), "dLeagueRosters.csv");
        PrintFreeAgents();
    }

    private void PrintFreeAgents()
    {
        string content = "";
        for (int i = 1; i < 6; i++)
        {
            content += "Country\tPlayer\tPosition\tLayup\tDunk\tJumpshot\t3PT\tPass\tShotContest\tDefenseIQ\tJumping\tSeperation\tDurability\tStamina\tDevelopment\tAge\tOverall\tPlayer ID\tYears Remaining\tMoney\tPosition Rank\tLeague Rank\n";
            List<player> players = freeAgents.GetPlayersByPos(i);
            foreach (player player in players)
            {
                content += player.getRatingsAsString();
            }
        }
        File.WriteAllText("freeAgents.csv", content);
    }

    private void PrintRosters(List<team> teams, string fileName)
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
        File.WriteAllText(fileName, content);
    }
}

public class Payroll : IComparable<Payroll>
{
    private double money;
    private string team;
    public Payroll(double money, string team)
    {
        this.money = money;
        this.team = team;
    }

    public int CompareTo(Payroll other)
    {
        if (money - other.money > 0) return -1;
        else if (other.money - money > 0) return 1;
        else return 0;
    }

    public override string ToString()
    {
        return team + ": " + money + "\n";
    }
}
