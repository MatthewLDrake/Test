using System;
using FormulaBasketball;
using System.Collections.Generic;
[Serializable]
public class CollegeTeam : team
{
    private Country country;
    private FormulaBasketball.Random r;
    private CollegeTeamType type;
    private Record currentSeason;
    private List<CollegePlayer> collegePlayers, redshirtPlayers;
    private CollegePlayerGen playerGen;
    private const int ONE_AND_DONE = 1, FOUR_YEAR_PLAYER = 2, SUCCESS_BASED = 3, OVERALL_BASED = 4, MIXED = 5;
    private List<CollegePlayer> injuredPlayers;
    public CollegeTeam(String teamName, String threeLetter, FormulaBasketball.Random r, Country country, CollegeTeamType type, int season) : base(teamName, threeLetter, r)
    {
        this.type = type;
        this.country = country;
        this.r = r;
        playerGen = new CollegePlayerGen(r);
        currentSeason = new Record();
        collegePlayers = new List<CollegePlayer>();
        redshirtPlayers = new List<CollegePlayer>();
        FillTeam(season, true);
        injuredPlayers = new List<CollegePlayer>();
        setBestStarters();
    }
    public void EndCollegeSeason()
    {
        endSeason();
        foreach(CollegePlayer player in collegePlayers)
        {
            player.EndCollegeSeason();
        }
    }
    public void AddCollegePlayer(CollegePlayer player)
    {
        addPlayer(player);
        collegePlayers.Add(player);
    }
    private int GetNumberActivePlayers()
    {
        return collegePlayers.Count;
    }
    private int GetNumberTotalPlayers()
    {
        return collegePlayers.Count + redshirtPlayers.Count;
    }
    public void CollegeInjuries()
    {
        if(injuredPlayers == null)
        {
            injuredPlayers = new List<CollegePlayer>();
        }
        int[] healthyPlayers = new int[5];
        foreach (player p in activePlayers)
        {
            if (p == null) continue;
            if(p.isInjured())
            {
                removePlayer(p);
                injuredPlayers.Add(p as CollegePlayer);
            }
            else
            {
                healthyPlayers[p.getPosition() - 1]++;
            }
        }

        
                
               
        //Country playerCountry = GenerateNewCountry();
        Country playerCountry = country;
        while (healthyPlayers[0] < 3)
        {
            int overallGoal = r.Next(15, 20);
            int personality = r.NextGaussian(3, 1);
            if (personality < 2) personality = SUCCESS_BASED;
            else if (personality > 5) personality = FOUR_YEAR_PLAYER;
            int development = 1;
            addPlayer(playerGen.GenerateCenter(overallGoal, playerCountry, development, 24, 26, false, 1, personality));
            healthyPlayers[0]++;
        }
        while (healthyPlayers[1] < 3)
        {
            int overallGoal = r.Next(15, 20);
            int personality = r.NextGaussian(3, 1);
            if (personality < 2) personality = SUCCESS_BASED;
            else if (personality > 5) personality = FOUR_YEAR_PLAYER;
            int development = 1;
            addPlayer(playerGen.GeneratePowerForward(overallGoal, playerCountry, development, 24, 26, false, 1, personality));
            healthyPlayers[1]++;
        }
        while (healthyPlayers[2] < 3)
        {
            int overallGoal = r.Next(15, 20);
            int personality = r.NextGaussian(3, 1);
            if (personality < 2) personality = SUCCESS_BASED;
            else if (personality > 5) personality = FOUR_YEAR_PLAYER;
            int development = 1;
            addPlayer(playerGen.GenerateSmallForward(overallGoal, playerCountry, development, 24, 26, false, 1, personality));
            healthyPlayers[2]++;
        }
        while (healthyPlayers[3] < 3)
        {
            int overallGoal = r.Next(15, 20);
            int personality = r.NextGaussian(3, 1);
            if (personality < 2) personality = SUCCESS_BASED;
            else if (personality > 5) personality = FOUR_YEAR_PLAYER;
            int development = 1;
            addPlayer(playerGen.GenerateShootingGuard(overallGoal, playerCountry, development, 24, 26, false, 1, personality));
            healthyPlayers[3]++;
        }
        while (healthyPlayers[4] < 3)
        {
            int overallGoal = r.Next(15, 20);
            int personality = r.NextGaussian(3, 1);
            if (personality < 2) personality = SUCCESS_BASED;
            else if (personality > 5) personality = FOUR_YEAR_PLAYER;
            int development = 1;
            addPlayer(playerGen.GeneratePointGuard(overallGoal, playerCountry, development, 24, 26, false, 1, personality));
            healthyPlayers[4]++;
        }
    }

    public void FillTeam(int season, bool firstTime = false)
    {
        while (true)
        {
            CollegePlayer player = null;
            int playerExpectation = type.GetPlayerType(r);

            int overallGoal = 0;
            int development = 1;
            int peakStart = r.Next(28, 32);
            int peakEnd = peakStart + r.Next(2, 5);
            int personality = 0;
            bool isRedshirt = false;
            int year = 1;

            if (firstTime)
            {
                isRedshirt = r.Next(4) == 2;
                year = r.Next(1, 5);
            }

            switch (playerExpectation)
            {
                case 1:
                    if (r.Next(100) == 3)
                    {
                        development = r.Next(7, 10);
                        peakStart += 2;
                        peakEnd++;
                        overallGoal = 68;
                        personality = ONE_AND_DONE;
                    }
                    else
                    {
                        overallGoal = r.Next(55, 60);
                        development = r.Next(5, 9);
                        if (r.NextBool()) personality = ONE_AND_DONE;
                        else
                        {
                            personality = SUCCESS_BASED;
                        }
                    }
                    break;
                case 2:
                    overallGoal = r.Next(45, 50);
                    development = r.Next(4, 8);
                    if (development == 8) personality = ONE_AND_DONE;
                    else
                    {
                        personality = r.NextGaussian(3, 1);
                        if (personality < 1) personality = SUCCESS_BASED;
                        else if (personality > 5) personality = FOUR_YEAR_PLAYER;
                    }
                    break;
                case 3:
                    overallGoal = r.Next(35, 40);
                    development = r.Next(3, 6);
                    personality = r.NextGaussian(3, 1);
                    if (personality < 1) personality = SUCCESS_BASED;
                    else if (personality > 5) personality = FOUR_YEAR_PLAYER;
                    break;
                case 4:
                    overallGoal = r.Next(25, 30);
                    personality = r.NextGaussian(3, 1);
                    if (personality < 1) personality = SUCCESS_BASED;
                    else if (personality > 5) personality = FOUR_YEAR_PLAYER;
                    if (r.Next(5) != 3) development = r.Next(3, 6);
                    else development = r.Next(1, 3);
                    break;
                default:
                    overallGoal = r.Next(15, 20);
                    personality = r.NextGaussian(3, 1);
                    if (personality < 2) personality = SUCCESS_BASED;
                    else if (personality > 5) personality = FOUR_YEAR_PLAYER;
                    if (r.Next(5) < 2) development = r.Next(3, 6);
                    else development = r.Next(1, 3);
                    break;
            }
            //Country playerCountry = GenerateNewCountry();
            Country playerCountry = country;
            if (getNumPlayersByPos(1) < 3)
            {
                player = playerGen.GenerateCenter(overallGoal, playerCountry, development, peakStart, peakEnd, isRedshirt, year, personality);
            }
            else if (getNumPlayersByPos(2) < 3)
            {
                player = playerGen.GeneratePowerForward(overallGoal, playerCountry, development, peakStart, peakEnd, isRedshirt, year, personality);
            }
            else if (getNumPlayersByPos(3) < 3)
            {
                player = playerGen.GenerateSmallForward(overallGoal, playerCountry, development, peakStart, peakEnd, isRedshirt, year, personality);
            }
            else if (getNumPlayersByPos(4) < 3)
            {
                player = playerGen.GenerateShootingGuard(overallGoal, playerCountry, development, peakStart, peakEnd, isRedshirt, year, personality);
            }
            else if (getNumPlayersByPos(5) < 3)
            {
                player = playerGen.GeneratePointGuard(overallGoal, playerCountry, development, peakStart, peakEnd, isRedshirt, year, personality);
            }
            else break;
            AddCollegePlayer(player);
            
        }
        GenerateCoach();
    }
    public void GenerateCoach()
    {
        int staminaSubOut = r.Next(70, 85);
        addCoach(new Coach("Coach", staminaSubOut, staminaSubOut + r.Next(5, 15), r.NextDouble() * 2 - 1, r.Next(0, 50), r.NextDouble() * 2 - 1, r.Next(0, 50), new Tempo(r.Next(0, 2)), coachShotType.BALANCED, ssInvolvment.MEDIUM, r));
    }


    public Country GetCountry()
    {
        return country;
    }
    public override void AddResult(int opponent, int teamScore, int opposingScore, bool isPlayoffs = false)
    {
        if (teamScore > opposingScore && !isPlayoffs) AddWin();
        else AddLoss();

        AddPoints(teamScore);
        AddPointsAgainst(opposingScore);

        List<CollegePlayer> stillInjured = new List<CollegePlayer>();

        foreach(CollegePlayer p in injuredPlayers)
        {
            if(!p.isInjured())
            {
                addPlayer(p);
                stillInjured.Add(p);
                
            }
            
        }
        players = new List<player>();
        injuredPlayers = stillInjured;
    }


    private void AddWin()
    {
        currentSeason.AddWins();
        lastThreeGames(1);
    }
    private void AddLoss()
    {
        currentSeason.AddLosses();
        lastThreeGames(0);
    }

    public override int getWins()
    {
        if (currentSeason == null) currentSeason = new Record();
        return currentSeason.GetWins();
    }

    public override int getLosses()
    {
        if (currentSeason == null) currentSeason = new Record();
        return currentSeason.GetLosses();
    }
    public CollegePlayer GenerateCollegePlayer(int i)
    {
        CollegePlayer player = null;
        int playerExpectation = type.GetPlayerType(r);

        int overallGoal = 0;
        int development = 1;
        int peakStart = r.Next(28, 32);
        int peakEnd = peakStart + r.Next(2, 5);
        int personality = 0;

        switch (playerExpectation)
        {
            case 1:
                if (r.Next(100) == 3)
                {
                    development = r.Next(7, 10);
                    peakStart += 2;
                    peakEnd++;
                    overallGoal = 68;
                    personality = ONE_AND_DONE;
                }
                else
                {
                    overallGoal = r.Next(55, 60);
                    development = r.Next(5, 9);
                    if (r.NextBool()) personality = ONE_AND_DONE;
                    else
                    {
                        personality = SUCCESS_BASED;
                    }
                }
                break;
            case 2:
                overallGoal = r.Next(45, 50);
                development = r.Next(4, 8);
                if (development == 8) personality = ONE_AND_DONE;
                else
                {
                    personality = r.NextGaussian(3, 1);
                    if (personality < 1) personality = SUCCESS_BASED;
                    else if (personality > 5) personality = FOUR_YEAR_PLAYER;
                }
                break;
            case 3:
                overallGoal = r.Next(35, 40);
                development = r.Next(3, 6);
                personality = r.NextGaussian(3, 1);
                if (personality < 1) personality = SUCCESS_BASED;
                else if (personality > 5) personality = FOUR_YEAR_PLAYER;
                break;
            case 4:
                overallGoal = r.Next(25, 30);
                personality = r.NextGaussian(3, 1);
                if (personality < 1) personality = SUCCESS_BASED;
                else if (personality > 5) personality = FOUR_YEAR_PLAYER;
                if (r.Next(5) != 3) development = r.Next(3, 6);
                else development = r.Next(1, 3);
                break;
            default:
                overallGoal = r.Next(15, 20);
                personality = r.NextGaussian(3, 1);
                if (personality < 2) personality = SUCCESS_BASED;
                else if (personality > 5) personality = FOUR_YEAR_PLAYER;
                if (r.Next(5) < 2) development = r.Next(3, 6);
                else development = r.Next(1, 3);
                break;
        }
        //Country playerCountry = GenerateNewCountry();
        Country playerCountry = country;
        if (i == 0) player = playerGen.GenerateCenter(overallGoal, playerCountry, development, peakStart, peakEnd, false, 1, personality);
        else if (i == 1) player = playerGen.GeneratePowerForward(overallGoal, playerCountry, development, peakStart, peakEnd, false, 1, personality);
        else if (i == 2) player = playerGen.GenerateSmallForward(overallGoal, playerCountry, development, peakStart, peakEnd, false, 1, personality);
        else if (i == 3) player = playerGen.GenerateShootingGuard(overallGoal, playerCountry, development, peakStart, peakEnd, false, 1, personality);
        else player = playerGen.GeneratePointGuard(overallGoal, playerCountry, development, peakStart, peakEnd, false, 1, personality);


        return player;
    }
    public void RemoveLeavingPlayers(int season)
    {
        List<CollegePlayer> leavingPlayers = new List<CollegePlayer>();
        for (int i = collegePlayers.Count - 1; i >= 0; i--)
        {
            CollegePlayer collegePlayer = collegePlayers[i];
            if (collegePlayer.WentPro() || collegePlayer.Graduated())
            {
                leavingPlayers.Add(collegePlayer);

            }
        }
        foreach(CollegePlayer player in leavingPlayers)
        {
            collegePlayers.Remove(player);
        }
        FillTeam(season);
        foreach(CollegePlayer collegePlayer in redshirtPlayers)
        {
            collegePlayers.Add(collegePlayer);
            
        }
        redshirtPlayers = new List<CollegePlayer>();
        for(int i = 0; i < 5; i++)
        {
            if(r.NextBool() && r.NextBool())
            {
                collegePlayers.Add(GenerateCollegePlayer(i));
            }
        }
        CollegePlayer[] fullRoster = new CollegePlayer[15];

        for (int i = 1; i < 6; i++)
        {
            List<CollegePlayer> positionPlayers = new List<CollegePlayer>();
            foreach (CollegePlayer player in collegePlayers)
            {
                if (player.getPosition() == i)
                {
                    positionPlayers.Add(player);
                }
            }
            positionPlayers.Sort();
            int playerCount = 3;
            while(positionPlayers.Count < 3)
            {
                positionPlayers.Add(GenerateCollegePlayer(i - 1));
            }
            while (positionPlayers.Count > 3)
            {
                if (positionPlayers[playerCount].CanRedshirt())
                {
                    positionPlayers[playerCount].Redshirt();
                    redshirtPlayers.Add(positionPlayers[playerCount]);
                    collegePlayers.Remove(positionPlayers[playerCount]);
                    positionPlayers.RemoveAt(playerCount);
                }
                else
                {
                    if (positionPlayers[2].CanRedshirt())
                    {
                        positionPlayers[2].Redshirt();
                        redshirtPlayers.Add(positionPlayers[2]);
                        collegePlayers.Remove(positionPlayers[2]);
                        positionPlayers.RemoveAt(2);
                    }
                    else
                    {
                        collegePlayers.Remove(positionPlayers[playerCount]);
                        positionPlayers.RemoveAt(playerCount);
                    }
                }

            }
            fullRoster[i - 1] = positionPlayers[0];
            fullRoster[i + 4] = positionPlayers[1];
            fullRoster[i + 9] = positionPlayers[2];
        }
        
        players = new List<player>();
        collegePlayers = new List<CollegePlayer>();
        for(int i = 0; i < fullRoster.Length; i++)
        {
            addPlayer(fullRoster[i]);
            collegePlayers.Add(fullRoster[i]);
        }
        foreach(player player in players)
        {
            player.Stamina();
        }
    }

}