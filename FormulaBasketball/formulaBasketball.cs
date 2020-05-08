using FormulaBasketball;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

public class formulaBasketball
{
    public static string writerFile, gameResultsFile, statsFile, standingsFile;
    public static string writerContents, gameResultsContents, statsContents, standingsContents, championshipsContents;
    public static createTeams create;
    public static int startingGame;
    public static List<team> DivisionA, DivisionB, DivisionC, DivisionD, ConferenceA, ConferenceB, League;
    public static gameWriter gameWriter;
    public static StringUtils StringUtils;
    public static bool writeGames;
    public static FormulaBasketball.Random r;
    public static Standings standingsForm, dLeagueStandingsForm;
    private static PlayoffBracket bracket;
    public static int nextPlayerID;
    public static bool injuries = false;
    private static ImagePrinter printer;
    public static bool createImages = true;
    public static Dictionary<Promises, String> promisesList = new Dictionary<Promises, String>()
    {
        { Promises.Year_One_Starter, "Year One Starter" }, {Promises.Win_Division, "Win Division" }, {Promises.Win_Conference, "Win Conference" }, {Promises.Win_Championship, "Win Championship" }, {Promises.Make_Playoffs, "Make Playoffs"},{ Promises.No_Trade ,"No trade clause" }
    };
    public formulaBasketball(bool loadSave, String fileName, List<team> teams, List<player> freeAgency, Boolean flag = false)
    {

        nextPlayerID = 1294;
        r = new FormulaBasketball.Random();
        writeGames = false;
        StringUtils = new StringUtils();

        Startup(loadSave, fileName, teams, freeAgency, !flag);
        standingsForm = new Standings(true);
        dLeagueStandingsForm = new Standings(true);
        bracket = new PlayoffBracket();
        bracket.Show();
        bracket.Visible = false;
        writerFile = "Results.txt";
        gameResultsFile = "GameResults.csv";
        statsFile = "stats.csv";
        standingsFile = "standings.csv";
        championshipsContents = championshipsContents += "Southern Conference Winner\tSouthern Conference Games Won\t\tNorthern Conference Games Won\tNorthern Conference winner\tMVP Winner\tMVP Team\tROTY winner\tROTY Team\n";

        team nova = create.getTeam(12), tuto = create.getTeam(19), solea = create.getTeam(7);

        foreach (team t in create.getTeams())
        {
            double capPenalty = -100;
            foreach (player p in t)
            {
                capPenalty += p.GetMoneyPerYear();
            }
            Console.WriteLine(t + ": " + capPenalty);
        }

        Console.WriteLine(tuto + ": " + tuto.getFianances());
        Console.WriteLine(nova + ": " + nova.getFianances());
        Console.WriteLine(solea + ": " + solea.getFianances());

        /*double[] topRating = new double[11];
        double[] bottomRating = new double[] { double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue };
        int threesAttempted = 0, threesMade = 0;
        foreach (team t in create.getTeams())
            foreach (player p in t)
            {
                for (int i = 0; i < bottomRating.Length; i++)
                {
                    if (p.ratings[i] > topRating[i])
                        topRating[i] = p.ratings[i];
                    if (p.ratings[i] < bottomRating[i])
                        bottomRating[i] = p.ratings[i];
                }
                threesAttempted += p.getThreesTaken();
                threesMade += p.getThreePointersMade();
            }
        double[] slopes = new double[11];
        double[] yIntercepts = new double[11];
        for (int i = 0; i < bottomRating.Length; i++)
        {
            double[] temp = Util.GetLineGivenPoints(bottomRating[i], 25, topRating[i], 99);
            slopes[i] = temp[0];
            yIntercepts[i] = temp[1];
        }
        string content = "";
        foreach (team t in create.getTeams())
        {
            content += t.ToString() + ",Name,Position,Layup,Dunk,Jumpshot,3PT,Pass,Shot Contest,Defense IQ,Jumping,Seperation,Durability,Stamina,Potential,Age,Overall,Player ID\n"; 
            foreach(player p in t)
            {
                int[] ratings = new int[11];
                for(int i = 0; i < ratings.Length; i++)
                {
                    ratings[i] = (int)Math.Round(p.ratings[i] * slopes[i] + yIntercepts[i]);
                }
                string retVal = p.GetCountry() + "," + p.getName() + "," + p.getPosition() + ",";

                retVal += ratings[0] + "," + ratings[1] + "," + ratings[2] + "," + ratings[9] + "," + ratings[7] + "," + ratings[3] + "," + ratings[4] + "," + ratings[5] + "," + ratings[6] + "," + ratings[10] + "," + ratings[8] + ",";
                
                retVal += p.getDevelopment() + "," + p.age + "," + String.Format("{0:0.00}", p.getOverall()) + "," + p.GetPlayerID() + "\n";
                content += retVal;
            }
        }
        File.WriteAllText("nba2krosters.csv", content);
        */
        /*
        team nova = create.getTeam(12), tuto = create.getTeam(19), solea = create.getTeam(7);

        nova.setLastThreeLetters("NOV");
        create.CreateNewSchedule();
        create.getTeam(2).TradeOccurred(new List<object>(), new List<object>(), null, false);
        nova.SetActiveRoster(new int[] { 132, 362, 363, 364, 365, 426, 372, 368, 369, 370, 146, 367, 698, 64, 375, 641, 996, 228, 384, 3, 791, 96, 913, 41, 16, 231, 382, 84, 809, 385 }, new int[] { });
        tuto.SetActiveRoster(new int[] { 571, 572, 573, 574, 785, 576, 577, 453, 579, 580, 989, 582, 583, 589, 590, 916, 976, 1004, 584, 585, 596, 597, 967, 1011, 961, 591, 592, 1104, 1069, 600 }, new int[] { });
        create.getFreeAgents().Add(solea.SetActiveRoster(new int[] { 211, 212, 213, 214, 215, 216, 222, 223, 219, 225, 221, 102, 133, 239, 220, 881, 252, 523, 194, 22, 226, 217, 228, 988, 235, 236, 227, 233, 1049, 973 }, new int[] {240 }));
        Console.WriteLine(tuto + ": " + tuto.getFianances());
        Console.WriteLine(nova + ": " + nova.getFianances());
        Console.WriteLine(solea + ": " + solea.getFianances());
        int playerID = 0;
        foreach(team t in create.getTeams())
        {
            foreach(player p in t)
            {
                p.addPlayerID(playerID);
                playerID++;
                p.setTeam(t);
            }
            foreach (player p in t.GetAffiliate())
            {
                p.addPlayerID(playerID);
                playerID++;
                p.setTeam(t.GetAffiliate());
            }
        }
        create.setFianancials();
        foreach (team t in create.getTeams())
        {
            foreach (player p in t)
            {
                if(!p.getTeam().Equals(t))
                {
                    Console.WriteLine(p.getName() + " plays for multiple teams.");
                }
            }
            for(int i = 0; i < t.GetAffiliate().getActivePlayers().Length; i++)
            {
                player p = t.GetAffiliate().getActivePlayers()[i];
                if (!p.getTeam().Equals(t.GetAffiliate()))
                {
                    
                    Console.WriteLine(p.getName() + " plays for multiple teams.");
                    if(t.getTeamNum() == 7)
                    {
                        p.getTeam().ReplacePlayer(p, PlayerGenerator.GeneratePlayer(p.getPosition(), p.GetCountry(), (int)p.getOverall(), p.age, p.GetDevelopmentRating(), p.GetPeakStart(), p.GetPeakEnd(), r));
                    }
                    else
                        t.GetAffiliate().getActivePlayers()[i] = PlayerGenerator.GeneratePlayer(p.getPosition(), p.GetCountry(), (int)p.getOverall(), p.age, p.GetDevelopmentRating(), p.GetPeakStart(), p.GetPeakEnd(), r);
                }
            }
        }
        playerID = 0;
        foreach (team t in create.getTeams())
        {
            t.endSeason();
            t.GetAffiliate().endSeason();
            foreach (player p in t)
            {
                p.addPlayerID(playerID);
                playerID++;
                p.setTeam(t);
            }
            foreach (player p in t.GetAffiliate())
            {
                p.addPlayerID(playerID);
                playerID++;
                p.setTeam(t.GetAffiliate());
            }
        }
        createTeams.nextID = playerID;
        createTeams.currentSeason = 8;
        */

        //create.FixTeams();
        //create.CreateNewSchedule();

        /* create.SetUpCollege();
         create.PlayCollegeSeason();
         create.PlayCollegeSeason();
         create.PlayCollegeSeason();
         create.PlayCollegeSeason(); 
         SerializeObject(create, fileName);*/
        //create.SetDraftPicks();

        /*for (int i = 0; i < 100; i++ )
        {
            
            Schedule schedule = new Schedule();
            schedule.playGames(1, 84);
            string winner = mockPlayoffs(true, i+1);
            foreach (team team in create.getTeams())
            {
                team.Reset();
                
            }

        }
        String toWrite = "Team Name\tDivision Championships\tConference Championships\tLeague Championships\n";
        foreach(team team in create.getTeams())
        {
            toWrite += team.PrintChampionships();
        }
        File.WriteAllText("sim.txt", toWrite);
        return;*/
        writerContents = "";
        gameResultsContents = "";
        statsContents = "";
        standingsContents = "";

        for (int i = 0; i < create.size(); i++)
        {
            create.getTeam(i).setTeamNum(i);
        }
        printer = new ImagePrinter(startingGame);

        //create.FixTeams();

        dLeagueStandingsForm.updateStandings(create, false);
        dLeagueStandingsForm.Visible = true;

        standingsForm.updateStandings(create, true);
        standingsForm.Visible = true;

        while (!flag)
        {
            Form2 resultFinder = new Form2();
            // YearSim resultFinder = new YearSim();
            resultFinder.ShowDialog();
            String result = resultFinder.GetResult();
            standingsForm.Show();
            standingsForm.Visible = false;

            //String result = Console.ReadLine();
            if (result.Equals("selectGames"))
            {
                Form3 tempScreen = new Form3(startingGame);
                tempScreen.ShowDialog();
                int endGame = tempScreen.getFinishPoint();

                standingsForm.Visible = true;
                int oldStartingGame = startingGame;
                playGames(startingGame, endGame);
                startingGame = oldStartingGame;
                playDLeagueGames(startingGame, endGame);

            }
            else if (result.Equals("playSeason"))
            {
                standingsForm.Visible = true;
                playGames(startingGame, 84);

            }
            else if (result.Equals("playseasons"))
            {
                Coach c = null;
                foreach (team team in create.getTeams())
                {
                    if (c == null)
                    {
                        c = team.getCoach();
                    }
                    else
                    {
                        team.SetCoach(c);
                    }
                }
                for (int i = 0; i < resultFinder.GetSeasons(); i++)
                {

                    standingsForm.Visible = true;
                    Thread thread = new Thread(create.PlayCollegeSeason);
                    thread.Start();
                    playGames(1, 84);
                    standingsForm.Visible = false;
                    foreach (team team in create.getTeams())
                    {
                        team.EndOfSeason(create.getFreeAgents());
                    }
                    mockPlayoffs(true);

                    VoteMVP();
                    VoteROTY();
                    bracket.Visible = false;
                    create.SetupSalaryInfo();
                    Offseason off = new Offseason(create.getTeams(), create.getFreeAgents(), create.GetCollege().GetRookies(), r, create);
                    new SetupNewSeason(create, r, create.getFreeAgents());
                }
                break;

            }
            else if (result.Equals("doPlayoffs"))
            {
                mockPlayoffs(true);
                /*create.PlayCollegeSeason();
                Offseason off = new Offseason(create, create.getTeams(), create.getFreeAgents(), create.GetCollege().GetRookies() ,r);
                new SetupNewSeason(create, r, create.getFreeAgents());*/
            }
            else if (result.Equals("restartSeason"))
            {
                Startup(loadSave, fileName, teams, freeAgency, !flag);
            }
            else if (result.Equals("doRound"))
            {
                mockPlayoffs(false);
            }
            else if (result.Equals("exitButton"))
                break;
            else if (result.Equals("Save"))
            {
                SerializeObject(create, fileName);
                standingsForm.SaveForm("images/standings.png");
                dLeagueStandingsForm.SaveForm("images/dLeagueStandings.png");
            }
            for (int i = 0; i < create.size(); i++)
            {
                create.getTeam(i).PrintSeasonRecords();
            }
        }
        PrintBestPlayers();
        calculateStandings(!flag);
        stats();
        File.WriteAllText("championships.csv", championshipsContents);
        File.WriteAllText(writerFile, writerContents);
        if (!gameResultsContents.Equals("")) File.WriteAllText(gameResultsFile, gameResultsContents);
        File.WriteAllText(statsFile, statsContents);
        File.WriteAllText(standingsFile, standingsContents);

    }
    private void PrintBestPlayers()
    {

        if (playersPoints != null)
        {
            String fileName = "InterestingFacts.txt";
            String contents = "";

            contents += playersPoints.getName() + " of the " + playersPoints.getTeam().ToString() + " scored a four game high of " + mostPoints + " points.\n";
            contents += playerRebounds.getName() + " of the " + playerRebounds.getTeam().ToString() + " had a four game high of " + mostRebounds + " rebounds.\n";
            contents += playersAssists.getName() + " of the " + playersAssists.getTeam().ToString() + " had a four game high of " + mostAssists + " assists.\n";


            File.WriteAllText(fileName, contents);
        }

    }

    private void VoteMVP()
    {
        List<player> playerList = new List<player>();
        foreach (team team in create.getTeams())
        {
            foreach (player p in team)
            {
                if (p.getMinutes() > 2000)
                {
                    playerList.Add(p);
                }
            }
        }
        player winner = FindBest(playerList);
        championshipsContents += winner.getName() + "\t" + winner.getTeam().ToString() + "\t";
    }
    private void VoteROTY()
    {
        List<player> playerList = new List<player>();
        foreach (team team in create.getTeams())
        {
            foreach (player p in team)
            {
                if (p.Rookie())
                {
                    playerList.Add(p);
                }
            }
        }
        player winner = FindBest(playerList);
        if (winner != null)
            championshipsContents += winner.getName() + "\t" + winner.getTeam().ToString() + "\n";
        else
            championshipsContents += "no rookies\t\n";
    }
    private player FindBest(List<player> list)
    {
        if (list.Count == 0) return null;
        int[] totalPoints = new int[list.Count];

        foreach (team team in create.getTeams())
        {
            int[] points = GetPoints(team, list);
            for (int i = 0; i < totalPoints.Length; i++)
            {
                totalPoints[i] += points[i];
            }
        }
        int index = 0;
        int highest = 0;
        for (int p = 0; p < totalPoints.Length; p++)
        {
            if (highest < totalPoints[p])
            {
                highest = totalPoints[p];
                index = p;
            }
        }

        return list[index];

    }
    private int[] GetPoints(team team, List<player> list)
    {
        int[] retVal = new int[list.Count];
        double[] scores = new double[list.Count];
        double[] tempList = new double[list.Count];
        int value = r.Next(1, 100);
        int focus = 6;
        if (value <= 10)
            focus = 1;
        else if (value <= 20)
            focus = 2;
        else if (value <= 50)
            focus = 3;
        else if (value <= 75)
            focus = 4;
        else if (value <= 90)
            focus = 5;

        for (int i = 0; i < list.Count; i++)
        {
            scores[i] = GetScore(list[i], focus, team);
            tempList[i] = scores[i];
        }

        Sort(scores);

        int endRange = Math.Min(10, list.Count);
        for (int i = 0; i < endRange; i++)
        {
            for (int j = 0; j < tempList.Length; j++)
            {
                if (scores[i] == tempList[j])
                {
                    retVal[j] = 10 - i;
                    break;
                }
            }
        }

        return retVal;
    }
    private double GetScore(player p, int focus, team team)
    {
        int bonus = 0;

        if (p.getTeam().Equals(team))
            bonus = 20;
        // read in minutes first, then find out the per minute situations
        int Minutes = p.getMinutes();
        double APM = ((double)p.getAssists() / (double)Minutes) * 100;
        double PPM = ((double)p.getPoints() / (double)Minutes) * 100;
        double Percent = 0;
        if (p.getShotsTaken() > 0)
            Percent = p.getShotsMade() / p.getShotsTaken() * 100;
        double Turnovers = ((double)p.getTurnovers() / (double)Minutes) * 100;
        double Steals = ((double)p.getSteals() / (double)Minutes) * 100;
        // add the random value
        double retVal = bonus + r.Next(-40, 60);

        // this is probably bad style, but eh it was the best way I thought of doing it
        if (focus == 1)
            retVal += APM * 4 + PPM + Percent - Turnovers + Steals;
        else if (focus == 2)
            retVal += APM + PPM + Percent - Turnovers + Steals * 100;
        else if (focus == 3)
            retVal += APM * 2 + PPM + Percent * 3 - Turnovers + Steals * 2;
        else if (focus == 4)
            retVal += APM + PPM * 4 + Percent * 3 - Turnovers + Steals;
        else if (focus == 5)
            retVal += APM * 4 + PPM + Percent * 5 - Turnovers + Steals * 2;
        else
            retVal += APM + PPM + Percent - Turnovers + Steals;

        return retVal;
    }
    private double[] Sort(double[] list)
    {
        double temp = 0;
        for (int write = 0; write < list.Length; write++)
        {
            for (int sort = 0; sort < list.Length - 1; sort++)
            {
                if (list[sort] < list[sort + 1])
                {
                    temp = list[sort + 1];
                    list[sort + 1] = list[sort];
                    list[sort] = temp;
                }
            }
        }
        return list;
    }
    private void playCollegeSeason()
    {
        new College(r);
    }
    private void saveDLeague()
    {
        for (int i = 0; i < 32; i++)
        {
            team currentTeam = create.getDLeagueTeam(i);
            Directory.CreateDirectory("DLeague Teams");
            string filepath = "DLeague Teams/" + currentTeam.ToString() + ".fbteam";
            SerializeObject(currentTeam, filepath);
        }
    }
    /// <summary>
    /// Serializes an object.
    /// </summary>
    /// <param name="serializableObject"></param>
    /// <param name="fileName"></param>
    public static void SerializeObject(createTeams serializableObject, string fileName)
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
    /// Serializes an object.
    /// </summary>
    /// <param name="serializableObject"></param>
    /// <param name="fileName"></param>
    public static void SerializeObject(object serializableObject, string fileName)
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
    /// Serializes an object.
    /// </summary>
    /// <param name="serializableObject"></param>
    /// <param name="fileName"></param>
    public static void SerializeObject(team serializableObject, string fileName)
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
    public static createTeams DeSerializeObject(string fileName)
    {
        createTeams temp = null;
        if (fileName.EndsWith(".fbusave"))
        {
            String info = File.ReadAllText(fileName);

            temp = new createTeams(info, new FormulaBasketball.Random());
        }
        else
        {
            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream(fileName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                temp = (createTeams)formatter.Deserialize(fs);
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
        }
        return temp;
    }
    private void Startup(bool loadSave, string fileName, List<team> teams, List<player> freeAgency, Boolean flag)
    {
        if (loadSave)
        {
            create = DeSerializeObject(fileName);
            startingGame = create.getTeam(0).getWins() + create.getTeam(0).getLosses() + 1;
            //standingsForm = new Standings();
            //standingsForm.updateStandings(create);
            //standingsForm.Show();
            //standingsForm.Visible = true;
        }
        else
        {
            FreeAgents free = new FreeAgents();
            if (freeAgency != null) foreach (player p in freeAgency) free.Add(p);
            if (teams == null) create = new createTeams("", r);
            else create = new createTeams(teams, free, r);
            doSetup(flag);
            startingGame = 1;
        }

    }

    public static void updateStandings()
    {
        standingsForm.updateStandings(create, true);
        dLeagueStandingsForm.updateStandings(create, false);
        //System.Threading.Thread.Sleep(5);
    }
    public static void doSetup(Boolean flag)
    {
        if (flag)
        {
            List<DoubleDoubles> averages = new List<DoubleDoubles>();
            for (int i = 0; i < create.size(); i++)
            {
                averages.Add(new DoubleDoubles(create.getTeam(i).getTeamResults().getAverage(), i));
            }
            averages.OrderBy(a => a.average);
            for (int i = 0; i < 10; i++)
            {
                create.getTeam(averages.ElementAt(i).i).getTeamResults().setTeamTier(teamTier.ELITE);
                Console.Write((i + 1) + ". " + create.getTeam(averages.ElementAt(i).i));
            }
            for (int i = 10; i < 23; i++)
            {
                create.getTeam(averages.ElementAt(i).i).getTeamResults().setTeamTier(teamTier.MIDRANGE);
                Console.Write((i + 1) + ". " + create.getTeam(averages.ElementAt(i).i));
            }
            for (int i = 23; i < create.size(); i++)
            {
                create.getTeam(averages.ElementAt(i).i).getTeamResults().setTeamTier(teamTier.BOTTOMFEEDER);
                Console.Write((i + 1) + ". " + create.getTeam(averages.ElementAt(i).i));
            }
        }
        else
        {
            List<DoubleDoubles> averages = new List<DoubleDoubles>();
            for (int i = 0; i < create.size(); i++)
            {
                averages.Add(new DoubleDoubles(i, i));
            }
            averages.OrderBy(a => a.average);
            for (int i = 0; i < 10; i++)
            {
                create.getTeam(averages.ElementAt(i).i).getTeamResults().setTeamTier(teamTier.ELITE);
                Console.Write((i + 1) + ". " + create.getTeam(averages.ElementAt(i).i));
            }
            for (int i = 10; i < 23; i++)
            {
                create.getTeam(averages.ElementAt(i).i).getTeamResults().setTeamTier(teamTier.MIDRANGE);
                Console.Write((i + 1) + ". " + create.getTeam(averages.ElementAt(i).i));
            }
            for (int i = 23; i < create.size(); i++)
            {
                create.getTeam(i).setTeamResults(new teamResults(new int[] { }));
                create.getTeam(averages.ElementAt(i).i).getTeamResults().setTeamTier(teamTier.BOTTOMFEEDER);
                Console.Write((i + 1) + ". " + create.getTeam(averages.ElementAt(i).i));
            }
        }

    }

    public static void ResetStats()
    {
        for (int i = 0; i < create.size(); i++)
        {
            for (int j = 0; j < create.getTeam(i).getAllPlayer().Count; j++)
            {
                create.getTeam(i).getAllPlayer().ElementAt(j).resetAllStats();
            }

        }
    }

    public static string mockPlayoffs(bool full, int num = 0)
    {
        Playoffs playoffs = new Playoffs();
        playoffs.setBracket(bracket, num);
        bracket.Visible = true;
        if (full)
        {
            while (playoffs.queue.Count != 0)
            {
                playoffs.queue.Dequeue().Invoke();
                System.Threading.Thread.Sleep(5);
            }
        }
        else
        {
            if (playoffs.queue.Count != 0)
            {
                playoffs.queue.Dequeue().Invoke();
                System.Threading.Thread.Sleep(5);
            }
        }

        return playoffs.GetChampion();
    }
    public static void removePlayer()
    {
        Console.Write("Enter the team number");
        int teamNum = int.Parse(Console.ReadLine());
        Console.Write("Team: " + create.getTeam(teamNum).ToString());

        Console.Write("Enter the player number of the former player from " + create.getTeam(teamNum).ToString());
        int firstTeamPlayer = int.Parse(Console.ReadLine());

        create.getTeam(teamNum).removePlayer(firstTeamPlayer);
    }
    public static void addPlayer()
    {
        Console.Write("Enter the team number");
        int teamNum = int.Parse(Console.ReadLine());
        Console.ReadLine();
        String playerName;
        int pos, layupStat, dunkStat, jumpStat, passing, shotContest, defenseIQ, jumping, seperation, staminaRating, threeStat, durabilityRating;

        Console.Write("Enter the name:");
        playerName = Console.ReadLine();
        Console.Write("Enter pos: ");
        pos = int.Parse(Console.ReadLine());
        layupStat = int.Parse(Console.ReadLine());
        dunkStat = int.Parse(Console.ReadLine());
        jumpStat = int.Parse(Console.ReadLine());
        threeStat = int.Parse(Console.ReadLine());
        passing = int.Parse(Console.ReadLine());
        shotContest = int.Parse(Console.ReadLine());
        defenseIQ = int.Parse(Console.ReadLine());
        jumping = int.Parse(Console.ReadLine());
        seperation = int.Parse(Console.ReadLine());
        durabilityRating = int.Parse(Console.ReadLine());
        staminaRating = int.Parse(Console.ReadLine());
        create.getTeam(teamNum).addPlayer(new player(pos, layupStat, dunkStat, jumpStat, threeStat, passing, shotContest, defenseIQ, jumping, seperation, durabilityRating, staminaRating, playerName, false));
    }
    public static void changeName()
    {
        Console.Write("Enter the team number");
        int teamNum = int.Parse(Console.ReadLine());
        Console.Write("Team: " + create.getTeam(teamNum).ToString());

        Console.Write("Enter the player number of the  player from " + create.getTeam(teamNum).ToString() + " that you wish to change the name of.");
        int firstTeamPlayer = int.Parse(Console.ReadLine());
        Console.ReadLine();

        Console.Write("What would you like to change his name to?");
        String newName = Console.ReadLine();
        create.getTeam(teamNum).getPlayer(firstTeamPlayer).setName(newName);

    }
    public static void printTeam()
    {
        Console.Write("Enter the team number");
        int firstTeamNum = int.Parse(Console.ReadLine());

        for (int i = 0; i < create.getTeam(firstTeamNum).getSize(); i++)
        {
            Console.Write(create.getTeam(firstTeamNum).getPlayer(i).getName() + " " + create.getTeam(firstTeamNum).getPlayer(i).getPosition());
        }

    }
    public static void trade()
    {
        Console.Write("Enter the first team number");
        int firstTeamNum = int.Parse(Console.ReadLine());
        Console.Write("Team One: " + create.getTeam(firstTeamNum).ToString());
        Console.Write("Enter the second team number");
        int secondTeamNum = int.Parse(Console.ReadLine());
        Console.Write("Team One: " + create.getTeam(secondTeamNum).ToString());

        Console.Write("Enter the player number of the former player from " + create.getTeam(firstTeamNum).ToString());
        int firstTeamPlayer = int.Parse(Console.ReadLine());
        Console.Write("Enter the player number of the former player from " + create.getTeam(secondTeamNum).ToString());
        int secondTeamPlayer = int.Parse(Console.ReadLine());

        player temp = create.getTeam(firstTeamNum).getPlayer(firstTeamPlayer);
        player othertemp = null;
        if (secondTeamPlayer != 100) othertemp = create.getTeam(secondTeamNum).getPlayer(secondTeamPlayer);

        create.getTeam(firstTeamNum).removePlayer(firstTeamPlayer);
        if (secondTeamPlayer != 100) create.getTeam(secondTeamNum).removePlayer(secondTeamPlayer);

        if (secondTeamPlayer != 100) create.getTeam(firstTeamNum).addPlayer(othertemp);
        create.getTeam(secondTeamNum).addPlayer(temp);
    }
    public static void calculateStandings(Boolean flag)
    {
        if (flag)
        {
            DivisionA = new List<team>();
            DivisionB = new List<team>();
            DivisionC = new List<team>();
            DivisionD = new List<team>();
            ConferenceA = new List<team>();
            ConferenceB = new List<team>();
            League = new List<team>();

            for (int i = 0; i < 8; i++)
            {
                DivisionA.Add(create.getTeam(i));
                DivisionB.Add(create.getTeam(i + 8));
                DivisionC.Add(create.getTeam(i + 16));
                DivisionD.Add(create.getTeam(i + 24));
            }


            DivisionA.Sort();

            DivisionB.Sort();

            DivisionC.Sort();

            DivisionD.Sort();

            ConferenceA.AddRange(DivisionA);
            ConferenceA.AddRange(DivisionB);
            ConferenceA.Sort();
            ConferenceB.AddRange(DivisionC);
            ConferenceB.AddRange(DivisionD);
            ConferenceB.Sort();
            League.AddRange(ConferenceA);
            League.AddRange(ConferenceB);
            League.Sort();
            for (int i = 0; i < DivisionA.Count; i++)
            {
                DivisionA.ElementAt(i).setDivisionRank(i + 1);
                DivisionB.ElementAt(i).setDivisionRank(i + 1);
                DivisionC.ElementAt(i).setDivisionRank(i + 1);
                DivisionD.ElementAt(i).setDivisionRank(i + 1);
            }
            for (int i = 0; i < ConferenceA.Count; i++)
            {
                ConferenceA.ElementAt(i).setConferenceRank(i + 1);
                ConferenceB.ElementAt(i).setConferenceRank(i + 1);
            }
            for (int i = 0; i < League.Count; i++)
            {
                League.ElementAt(i).setLeagueRank(i + 1);
            }
            standingsContents += "Division A, Wins,Losses,Points Scored,Points Against,Division Rank,Conference Rank,League Rank, Division Wins, Division Losses, Conference Wins, Conference Losses\n";
            for (int i = 0; i < DivisionA.Count; i++)
            {
                standings(DivisionA.ElementAt(i));

            }
            standingsContents += "Division B\n";
            for (int i = 0; i < DivisionB.Count; i++)
            {
                standings(DivisionB.ElementAt(i));

            }
            standingsContents += "Division C\n";
            for (int i = 0; i < DivisionC.Count; i++)
            {
                standings(DivisionC.ElementAt(i));

            }
            standingsContents += "Division D\n";
            for (int i = 0; i < DivisionD.Count; i++)
            {
                standings(DivisionD.ElementAt(i));

            }
        }
        else
        {
            List<team>[] division = new List<team>[10];
            List<team> league = new List<team>();
            for (int i = 0; i < 10; i++)
            {
                division[i] = new List<team>();
                for (int j = 0; j < 10; j++)
                {
                    division[i].Add(create.getTeam(i * 10 + j));

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

                standingsContents += "Division " + i + ", Wins,Losses,Points Scored,Points Against,Division Rank,Conference Rank,League Rank, Division Wins, Division Losses, Conference Wins, Conference Losses\n";
                for (int j = 0; j < 10; j++)
                {
                    division[i][j].setDivisionRank(j + 1);
                    division[i][j].setConferenceRank(j + 1);
                    standings(division[i][j]);
                }
            }

        }


    }
    public static void changeStarter()
    {
        Console.Write("Enter the team number");
        int teamNum = int.Parse(Console.ReadLine());
        Console.Write("Enter the player number of the former starter");
        int oldStarter = int.Parse(Console.ReadLine());
        Console.Write("Enter the player number of the new starter");
        int newStarter = int.Parse(Console.ReadLine());

        create.getTeam(teamNum).getPlayer(oldStarter).setStarter(false);
        create.getTeam(teamNum).getPlayer(newStarter).setStarter(true);
    }
    public static void playGames(int firstGame, int secondGame)
    {
        create.playGames(firstGame, secondGame, r);

        if (gameWriter != null) gameWriter.writeLines();

        printFianances();

        printInjuries();


    }
    public static void playDLeagueGames(int firstGame, int secondGame)
    {
        create.playDLeagueGames(firstGame, secondGame, r);

        if (gameWriter != null) gameWriter.writeLines();

        printFianances();

        printInjuries();


    }

    public static void printFianances()
    {
        String tempwriterContents = null;

        String tempWriterFile = "Fianances.csv";


        tempwriterContents += "Team Name,Ticket Sales,Concession Sales,Shared Revenue,Sponsor Income,Merchandise/Licensing,Player Contracts,Staff Contracts,Stadium Maintenance,Travel Costs,Current Money\n";
        for (int i = 0; i < create.size(); i++)
        {
            StringBuilder temp = new StringBuilder();
            double[] tempIncome = create.getTeam(i).getTotalIncomes();
            double[] tempExpenses = create.getTeam(i).getTotalExpenses();
            long[] totalIncome = new long[tempIncome.Length];
            long[] totalExpenses = new long[tempExpenses.Length];


            temp.Append(create.getTeam(i).ToString());
            for (int j = 0; j < totalIncome.Length; j++)
            {
                totalIncome[j] = (long)Math.Round(tempIncome[j]);
                temp.Append("," + totalIncome[j]);
            }
            temp.Append("," + create.getTeam(i).getSeasonMerchandise());
            for (int j = 0; j < totalExpenses.Length; j++)
            {
                totalExpenses[j] = (long)Math.Round(tempExpenses[j]);
                temp.Append("," + totalExpenses[j]);
            }
            temp.Append("," + create.getTeam(i).getTravelCosts());
            temp.Append("," + create.getTeam(i).getFianances());
            tempwriterContents += temp.ToString() + "\n";

        }

        File.WriteAllText(tempWriterFile, tempwriterContents);
    }
    public static void doWeeklyFianances()
    {
        if (startingGame % 4 == 0)
        {
            for (int i = 0; i < create.size(); i++)
            {
                create.getTeam(i).doExpenses();
            }
        }

    }
    public static void printInjuries()
    {
        String injuryWriterContents = null;

        String injuryWriterFile = "Injuries.txt";

        for (int i = 0; i < create.size(); i++)
        {
            int numInjuries = 0;
            for (int j = 0; j < create.getTeam(i).getAllPlayer().Count; j++)
            {
                numInjuries += create.getTeam(i).getPlayer(j).getInjuryTotal();
            }
            injuryWriterContents += create.getTeam(i).ToString() + " injuries: (" + numInjuries + " total)\n";
            for (int j = 0; j < create.getTeam(i).getAllPlayer().Count; j++)
            {
                if (create.getTeam(i).getPlayer(j).isInjured())
                {
                    injuryWriterContents += "	" + create.getTeam(i).getPlayer(j).getName() + " is injured for " + create.getTeam(i).getPlayer(j).getInjuryLength() + " more games.";
                }
            }
            injuryWriterContents += "\n";
        }
        File.WriteAllText(injuryWriterFile, injuryWriterContents);
    }
    public static void stats()
    {
        for (int i = 0; i < create.size(); i++)
        {

            writerContents += "" + create.getTeam(i).ToString() + " went " + create.getTeam(i).getWins() + " - " + (create.getTeam(i).getLosses()) + ". They scored " + create.getTeam(i).getPoints() + " points and gave up " + create.getTeam(i).getPointsAgainst() + " points. Here are their player stats!\n";
            statsContents += (create.getTeam(i).ToString() + " players,Games Played,Minutes,Assists,Points,Shots Taken,Shots Made,Field Goal Percentage,Threes Taken,Threes Made,Free Throws Taken,Free Throws Made,Turnovers,Steals,Rebounds,Offensive Rebounds,Defensive Rebounds,Fouls,Opponent Shots Against,Opponent Shots Made,Opponent Shot Percent,Point Differential\n");
            for (int k = 0; k < create.getTeam(i).getSize(); k++)
            {
                double shootingPercentage = 0.0, opponentPercentage = 0.0;
                if (create.getTeam(i).getPlayer(k).getShotsTaken() != 0)
                {

                    shootingPercentage = ((double)create.getTeam(i).getPlayer(k).getShotsMade() / (double)create.getTeam(i).getPlayer(k).getShotsTaken()) * 100;
                }
                double plus_minus = 0.0;
                if (create.getTeam(i).getPlayer(k).getGamesPlayed() != 0)
                {
                    plus_minus = ((double)create.getTeam(i).getPlayer(k).teamPoints / (double)create.getTeam(i).getPlayer(k).getGamesPlayed());
                }
                if (create.getTeam(i).getPlayer(k).getShotsAttemptedAgainst() != 0)
                    opponentPercentage = ((double)create.getTeam(i).getPlayer(k).getShotsMadeAgainst() / (double)create.getTeam(i).getPlayer(k).getShotsAttemptedAgainst()) * 100;
                statsContents += (create.getTeam(i).getPlayer(k).getName() + "," + create.getTeam(i).getPlayer(k).getGamesPlayed() + "," + create.getTeam(i).getPlayer(k).getMinutes() + "," + create.getTeam(i).getPlayer(k).getAssists() + "," + create.getTeam(i).getPlayer(k).getPoints() + "," + create.getTeam(i).getPlayer(k).getShotsTaken() + ","
                        + create.getTeam(i).getPlayer(k).getShotsMade() + "," + shootingPercentage + "," + create.getTeam(i).getPlayer(k).getThreesTaken() + "," + create.getTeam(i).getPlayer(k).getThreePointersMade() + "," + create.getTeam(i).getPlayer(k).getFreeThrowsTaken() + "," + create.getTeam(i).getPlayer(k).getFreeThrowsMade()
                        + "," + create.getTeam(i).getPlayer(k).getTurnovers() + "," + create.getTeam(i).getPlayer(k).getSteals() + "," + create.getTeam(i).getPlayer(k).getRebounds() + "," + create.getTeam(i).getPlayer(k).getOffensiveRebounds() + "," + create.getTeam(i).getPlayer(k).getDefensiveRebounds()
                        + "," + create.getTeam(i).getPlayer(k).getFouls() + "," + create.getTeam(i).getPlayer(k).getShotsAttemptedAgainst() + "," + create.getTeam(i).getPlayer(k).getShotsMadeAgainst() + ","
                        + opponentPercentage + ", " + plus_minus + "\n");
            }
            //standings(create.getTeam(i));
        }

    }

    public static void standings(team team)
    {
        standingsContents += "" + team.ToString() + "," + team.getWins() + "," + team.getLosses() + "," + team.getPoints() + "," + team.getPointsAgainst() + "," + team.getDivisionRank() + "," + team.getConferenceRank() + "," + team.getLeagueRank() + "," + team.getDivisionWins() + "," + team.getDivisionLosses() + "," + team.getConferenceWins() + "," + team.getConferenceLosses() + "," + team.getStreak() + "," + team.GetLastTen() + "\n";

    }

    public static bool executeGame(bool b, int i, int j, bool dLeague = false)
    {
        bool retVal = false;

        team awayTeam = dLeague ? create.getTeam(i).GetAffiliate() : create.getTeam(i);
        team homeTeam = dLeague ? create.getTeam(j).GetAffiliate() : create.getTeam(j);

        int away = awayTeam.lastThreeGames(-1);
        int home = homeTeam.lastThreeGames(-1);



        int randomValue = r.Next(0, 100);
        if (away == 0 && home == 0)
        {
            if (randomValue < 10)
            {
                awayTeam.setModifier(new BounceBackGame());
                homeTeam.setModifier(new None());
            }
            else if (randomValue < 30)
            {
                awayTeam.setModifier(new DefensiveNightmare());
                homeTeam.setModifier(new DefensiveNightmare());
            }
            else if (randomValue < 40)
            {
                awayTeam.setModifier(new None());
                homeTeam.setModifier(new BounceBackGame());
            }
            else
            {
                awayTeam.setModifier(new None());
                homeTeam.setModifier(new None());
            }
        }
        else if ((away == 0 || away == 1) && home == 3)
        {
            if (randomValue < 15)
            {
                awayTeam.setModifier(new BounceBackGame());
                homeTeam.setModifier(new LetDownGame());
            }
            else if (randomValue < 25)
            {
                awayTeam.setModifier(new StrugglesContinue());
                homeTeam.setModifier(new ContinueRolling());
            }
            else
            {
                awayTeam.setModifier(new None());
                homeTeam.setModifier(new None());
            }

        }
        else if ((home == 0 || home == 1) && away == 3)
        {
            if (randomValue < 15)
            {
                homeTeam.setModifier(new BounceBackGame());
                awayTeam.setModifier(new LetDownGame());
            }
            else if (randomValue < 25)
            {
                homeTeam.setModifier(new StrugglesContinue());
                awayTeam.setModifier(new ContinueRolling());
            }
            else
            {
                homeTeam.setModifier(new None());
                awayTeam.setModifier(new None());
            }
        }
        else if (away == 3 && home == 3)
        {
            if (randomValue < 5)
            {
                awayTeam.setModifier(new ContinueRolling());
                homeTeam.setModifier(new LetDownGame());
            }
            else if (randomValue < 10)
            {
                awayTeam.setModifier(new LetDownGame());
                homeTeam.setModifier(new ContinueRolling());
            }
            else
            {
                awayTeam.setModifier(new None());
                homeTeam.setModifier(new None());
            }

        }
        else
        {
            if (randomValue < 12)
            {
                awayTeam.setModifier(new DefensiveNightmare());
                homeTeam.setModifier(new None());
            }
            else if (randomValue < 25)
            {
                awayTeam.setModifier(new OffenisveNightmare());
                homeTeam.setModifier(new OffenisveNightmare());
            }
            else
            {
                awayTeam.setModifier(new None());
                homeTeam.setModifier(new None());
            }
        }
        homeTeam.addModifier(new HomeTeam());
        awayTeam.addModifier(awayTeam.getCoachModifier());
        homeTeam.addModifier(homeTeam.getCoachModifier());


        if (!dLeague && (i == 26 || i == 2 || i == 19 || i == 22 || i == 23))
            awayTeam.addModifier(new HotStreak());
        else if (!dLeague && (j == 26 || j == 2 || j == 19 || j == 22 || j == 23))
            homeTeam.addModifier(new HotStreak());

        if (!dLeague && (i == 7))
            awayTeam.addModifier(new gettingHot());
        else if (!dLeague && (j == 7))
            homeTeam.addModifier(new gettingHot());

        game newGame = new game(gameWriter, awayTeam, homeTeam, r);


        retVal = newGame.getWinner();

        awayTeam.AddResult(j, newGame.getAwayTeamScore(), newGame.getHomeTeamScore());
        homeTeam.AddResult(i, newGame.getHomeTeamScore(), newGame.getAwayTeamScore());

        printer.AddResult(awayTeam, homeTeam, newGame.getAwayTeamScore(), newGame.getHomeTeamScore(), dLeague);
       
        gameResultsContents += ("," + awayTeam.ToString() + "," + newGame.getAwayTeamScore() + "," + homeTeam.ToString() + "," + newGame.getHomeTeamScore() + "\n");


        /*attendance temp = awayTeam.getStadium().getAttendance(awayTeam, homeTeam, false);
        awayTeam.setFianances((int)temp.income, false);
        attendance[] concessions = awayTeam.getStadium().getConcessions(temp);
        for (int k = 0; k < concessions.Length; k++)
        {
            awayTeam.setFianances((int)concessions[k].income, true);
        }
        awayTeam.homeGameOccurred();
        homeTeam.awayGameOccurred(j, i);
        /*if (b)
        {
            string tempWriterFile ="Game " + (startingGame - 1) + " - " + awayTeam.ToString() + " - " + homeTeam.ToString() + " box score.txt";
            string tempWriterContents = "";
            tempWriterContents += "-----------------------------------------------------------");
            tempWriterContents += ("| " + StringUtils.rightPad(awayTeam.ToString(), 25) + " | " + newGame.getQuarterOneScore()[0] + " | " + newGame.getQuarterTwoScore()[0] + " | " + newGame.getQuarterThreeScore()[0] + " | " + newGame.getQuarterFourScore()[0] + " | " + newGame.getQuarterOTScore()[0] + " | " + StringUtils.rightPad("" + newGame.getAwayTeamScore(), 3) + " |\n");
            tempWriterContents += ("| " + StringUtils.rightPad(homeTeam.ToString(), 25) + " | " + newGame.getQuarterOneScore()[1] + " | " + newGame.getQuarterTwoScore()[1] + " | " + newGame.getQuarterThreeScore()[1] + " | " + newGame.getQuarterFourScore()[1] + " | " + newGame.getQuarterOTScore()[1] + " | " + StringUtils.rightPad("" + newGame.getHomeTeamScore(), 3) + " |\n");
            tempWriterContents += "-----------------------------------------------------------");
            tempWriterContents += awayTeam.ToString());
            tempWriterContents += "POS NAME                    MIN  PTS  AST  FGA  FGM    FG%  3TA  3TM  FTA FTM   TO  STL  REB  ORB  DRB  FLS  OSA  OSM    OS%");
            for (int k = 0; k < awayTeam.getSize(); k++)
            {
                String position = "";
                switch (awayTeam.getPlayer(k).getPosition())
                {
                    case 1:
                        position = "C  ";
                        break;
                    case 2:
                        position = "PF ";
                        break;
                    case 3:
                        position = "SF ";
                        break;
                    case 4:
                        position = "SG ";
                        break;
                    case 5:
                        position = "PG ";
                        break;
                }
                double shootingPercentage = 0.0, opponentPercentage = 0.0;
                if (awayTeam.getPlayer(k).getGameShotsTaken() != 0)
                {

                    shootingPercentage = ((double)awayTeam.getPlayer(k).getGameShotsMade() / (double)awayTeam.getPlayer(k).getGameShotsTaken()) * 100;
                }
                if (awayTeam.getPlayer(k).getGameShotsAttemptedAgainst() != 0)
                    opponentPercentage = ((double)awayTeam.getPlayer(k).getGameShotsMadeAgainst() / (double)awayTeam.getPlayer(k).getGameShotsAttemptedAgainst()) * 100;
                writer.printf(position + StringUtils.rightPad(awayTeam.getPlayer(k).getName(), 25) + "%2d   %2d   %2d   %2d   %2d   %4.1f   %2d   %2d   %2d  %2d   %2d   %2d   %2d   %2d   %2d   %2d   %2d   %2d   %3.1f\n", awayTeam.getPlayer(k).getGameMinutes(), awayTeam.getPlayer(k).getGamePoints(), awayTeam.getPlayer(k).getGameAssists(), awayTeam.getPlayer(k).getGameShotsTaken()
                        , awayTeam.getPlayer(k).getGameShotsMade(), shootingPercentage, awayTeam.getPlayer(k).getGameThreesTaken(), awayTeam.getPlayer(k).getGameThreePointersMade(), awayTeam.getPlayer(k).getGameFreeThrowsTaken(), awayTeam.getPlayer(k).getGameFreeThrowsMade()
                        , awayTeam.getPlayer(k).getGameTurnovers(), awayTeam.getPlayer(k).getGameSteals(), awayTeam.getPlayer(k).getGameRebounds(), awayTeam.getPlayer(k).getGameOffensiveRebounds(), awayTeam.getPlayer(k).getGameDefensiveRebounds()
                        , awayTeam.getPlayer(k).getBoxScoreFouls(), awayTeam.getPlayer(k).getGameShotsAttemptedAgainst(), awayTeam.getPlayer(k).getGameShotsMadeAgainst(),
                        opponentPercentage);
            }
            writerContents += homeTeam.ToString());
            writerContents += "POS NAME                    MIN  PTS  AST  FGA  FGM    FG%  3TA  3TM  FTA FTM   TO  STL  REB  ORB  DRB  FLS  OSA  OSM    OS%");
            for (int k = 0; k < homeTeam.getSize(); k++)
            {
                String position = "";
                switch (homeTeam.getPlayer(k).getPosition())
                {
                    case 1:
                        position = "C  ";
                        break;
                    case 2:
                        position = "PF ";
                        break;
                    case 3:
                        position = "SF ";
                        break;
                    case 4:
                        position = "SG ";
                        break;
                    case 5:
                        position = "PG ";
                        break;
                }
                double shootingPercentage = 0.0, opponentPercentage = 0.0;
                if (homeTeam.getPlayer(k).getGameShotsTaken() != 0)
                {

                    shootingPercentage = ((double)homeTeam.getPlayer(k).getGameShotsMade() / (double)homeTeam.getPlayer(k).getGameShotsTaken()) * 100;
                }
                if (homeTeam.getPlayer(k).getGameShotsAttemptedAgainst() != 0)
                    opponentPercentage = ((double)homeTeam.getPlayer(k).getGameShotsMadeAgainst() / (double)homeTeam.getPlayer(k).getGameShotsAttemptedAgainst()) * 100;
                writer.printf(position + StringUtils.rightPad(homeTeam.getPlayer(k).getName(), 25) + "%2d   %2d   %2d   %2d   %2d   %4.1f   %2d   %2d   %2d  %2d   %2d   %2d   %2d   %2d   %2d   %2d   %2d   %2d   %3.1f\n", homeTeam.getPlayer(k).getGameMinutes(), homeTeam.getPlayer(k).getGamePoints(), homeTeam.getPlayer(k).getGameAssists(), homeTeam.getPlayer(k).getGameShotsTaken()
                        , homeTeam.getPlayer(k).getGameShotsMade(), shootingPercentage, homeTeam.getPlayer(k).getGameThreesTaken(), homeTeam.getPlayer(k).getGameThreePointersMade(), homeTeam.getPlayer(k).getGameFreeThrowsTaken(), homeTeam.getPlayer(k).getGameFreeThrowsMade()
                        , homeTeam.getPlayer(k).getGameTurnovers(), homeTeam.getPlayer(k).getGameSteals(), homeTeam.getPlayer(k).getGameRebounds(), homeTeam.getPlayer(k).getGameOffensiveRebounds(), homeTeam.getPlayer(k).getGameDefensiveRebounds()
                        , homeTeam.getPlayer(k).getBoxScoreFouls(), homeTeam.getPlayer(k).getGameShotsAttemptedAgainst(), homeTeam.getPlayer(k).getGameShotsMadeAgainst(),
                        opponentPercentage);

            }


            writer.close();*/


        player rebounds = newGame.GetGameRebound();
        player points = newGame.GetHighestScorer();
        player assists = newGame.GetHighestAssister();

        if(rebounds.getGameRebounds() > mostRebounds)
        {
            playerRebounds = rebounds;
            mostRebounds = rebounds.getGameRebounds();
        }
        if (points.getGamePoints() > mostPoints)
        {
            playersPoints = points;
            mostPoints = points.getGamePoints();
        }
        if (assists.getGameAssists() > mostAssists)
        {
            playersAssists = assists;
            mostAssists = assists.getGameAssists();
        }

        for (int k = 0; k < awayTeam.getSize(); k++)
        {
            awayTeam.getPlayer(k).resetGameStats(awayTeam, homeTeam);
        }
        for (int k = 0; k < homeTeam.getSize(); k++)
        {
            homeTeam.getPlayer(k).resetGameStats(homeTeam, awayTeam);
        }
        return retVal;
    }
    private static int mostRebounds, mostAssists, mostPoints;
    private static player playerRebounds, playersAssists, playersPoints;

}
    