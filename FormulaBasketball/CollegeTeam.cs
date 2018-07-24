using System;
using FormulaBasketball;

public class CollegeTeam : team
{
    private Country country;
    private FormulaBasketball.Random r;
    private CollegeTeamType type;
    private Record currentSeason;
    public CollegeTeam(String teamName, String threeLetter, FormulaBasketball.Random r, Country country, CollegeTeamType type) : base(teamName, threeLetter, r)
    {
        this.type = type;
        this.country = country;
        this.r = r;
        currentSeason = new Record();
        FillTeam(true);
    }
    public void FillTeam(bool firstTime = false)
    {
        while (getNumberPlayers() < 15)
        {
            player player = null;
            int playerExpectation = type.GetPlayerType(r);

            int overallGoal = 0;
            int development = 1;
            int peakStart = r.Next(28, 32);
            int peakEnd = peakStart + r.Next(2, 5);

            bool isRedshirt = false;
            int year = 1;

            if(firstTime)
            {
                isRedshirt = r.Next(4) == 2;
                year = r.Next(1,4);
            }

            switch(playerExpectation)
            {
                case 1:
                    if (r.Next(10) == 3)
                    {
                        development = r.Next(7, 10);
                        peakStart += 2;
                        peakEnd++;
                        overallGoal = 75;
                    }
                    else
                    {
                        overallGoal = r.Next(60, 65);
                        development = r.Next(6, 10);
                    }
                    break;
                case 2:
                    overallGoal = r.Next(50, 55);
                    development = r.Next(5, 9);
                    break;
                case 3:
                    overallGoal = r.Next(40, 45);
                    development = r.Next(1, 10);
                    break;
                case 4:
                    overallGoal = r.Next(30, 35);
                    if (r.Next(5) != 3) development = r.Next(1, 10);
                    else development = r.Next(1, 3);
                    break;
                default:
                    overallGoal = r.Next(15, 20);
                    if (r.Next(5) < 2) development = r.Next(5, 10);
                    else development = r.Next(1, 3);
                    break;
            }
            //Country playerCountry = GenerateNewCountry();
            Country playerCountry = country;
            if (getNumPlayersByPos(1) < 3)
            {
                player = GenerateCenter(overallGoal, playerCountry, development, peakStart, peakEnd, isRedshirt, year);
            }
            else if (getNumPlayersByPos(2) < 3)
            {
                player = GeneratePowerForward(overallGoal, playerCountry, development, peakStart, peakEnd, isRedshirt, year);
            }
            else if (getNumPlayersByPos(3) < 3)
            {
                player = GenerateSmallForward(overallGoal, playerCountry, development, peakStart, peakEnd, isRedshirt, year);
            }
            else if (getNumPlayersByPos(4) < 3)
            {
                player = GenerateShootingGuard(overallGoal, playerCountry, development, peakStart, peakEnd, isRedshirt, year);
            }
            else if (getNumPlayersByPos(5) < 3)
            {
                player = GeneratePointGuard(overallGoal, playerCountry, development, peakStart, peakEnd, isRedshirt, year);
            }


            addPlayer(player);
        }
        GenerateCoach();
    }
    public void GenerateCoach()
    {
        int staminaSubOut = r.Next(70, 85);
        addCoach(new Coach("Coach", staminaSubOut, staminaSubOut + r.Next(5, 15), r.NextDouble() * 2 - 1, r.Next(0, 50), r.NextDouble() * 2 - 1, r.Next(0, 50), new Tempo(r.Next(0, 2)), coachShotType.BALANCED, ssInvolvment.MEDIUM, r));
    }
    /*
     * Ratings: 
     * 
     * 
     * collegeProbabilties[1] = inside
     * collegeProbabilties[2] = jumpshot
     * collegeProbabilties[3] = shot contest
     * collegeProbabilties[4] = defense iq
     * collegeProbabilties[5] = jumping
     * collegeProbabilties[6] = seperation
     * collegeProbabilties[7] = passing
     * collegeProbabilties[8] = threepoint
     */
    private void UpgradePlayer(CollegePlayer player, int skill)
    {
        switch(skill)
        {
            case 1:
                player.IncreaseInsideScoring();
                break;
            case 2:
                player.IncreaseJumpShot();
                break;
            case 3:
                player.IncreaseShotContest();
                break;
            case 4:
                player.IncreaseDefenseIQ();
                break;
            case 5:
                player.IncreaseJumping();
                break;
            case 6:
                player.IncreaseSeperation();
                break;
            case 7:
                player.IncreasePassing();
                break;
            case 8:
                player.IncreaseThreePoint();
                break;
        }
    }
    public player GenerateCenter(int overallGoal, Country country, int development, int peakStart, int peakEnd, bool isRedshirt, int year)
    {
        int age = 17;
        if (isRedshirt) age++;
        age += year;
        CollegePlayer retVal = new CollegePlayer(1, 1, 1, 1, 1, 1, 1, 1, 1, r.Next(1, 10), r.Next(5, 10), age, "Center", peakStart, peakEnd, development, country, isRedshirt, year);
        
        int[] collegeProbabilties = new int[] {25, 5, 15, 15, 30, 15, 5, 2 };
        int sum = 0;
        for (int i = 0; i < collegeProbabilties.Length; i++)
            sum += collegeProbabilties[i]; 

        while (retVal.GetOldOverall() < overallGoal)
        {
            CollegePlayer copy = (CollegePlayer)retVal.Clone();
            int currSum = 0;
            int num = r.Next(sum);
           
            for (int i = 0; i < collegeProbabilties.Length; i++)
            {
                currSum += collegeProbabilties[i];
                if(currSum > num)
                {
                    UpgradePlayer(copy, i+1);
                    break;
                }
            }
            if (copy.GetOldOverall() - overallGoal > .5)
            {
                continue;
            }
            retVal = copy;

        }
        retVal.updateRatings(r);
        return retVal;
    }
    
    public player GeneratePowerForward(int overallGoal, Country country, int development, int peakStart, int peakEnd, bool isRedshirt, int year)
    {
        int age = 17;
        if (isRedshirt) age++;
        age += year;
        CollegePlayer retVal = new CollegePlayer(2, 1, 1, 1, 1, 1, 1, 1, 1, r.Next(1,10), r.Next(5,10), age, "Power Forward", peakStart, peakEnd, development, country, isRedshirt, year);

        int[] collegeProbabilties = new int[] { 25, 10, 15, 15, 20, 15, 10, 5 };
        int sum = 0;
        for (int i = 0; i < collegeProbabilties.Length; i++)
            sum += collegeProbabilties[i];

        while (retVal.GetOldOverall() < overallGoal)
        {
            CollegePlayer copy = (CollegePlayer)retVal.Clone();
            int currSum = 0;
            int num = r.Next(sum);

            for (int i = 0; i < collegeProbabilties.Length; i++)
            {
                currSum += collegeProbabilties[i];
                if (currSum > num)
                {
                    UpgradePlayer(copy, i + 1);
                    break;
                }
            }
            if (copy.GetOldOverall() - overallGoal > .5)
            {
                continue;
            }
            retVal = copy;

        }
        retVal.updateRatings(r);
        return retVal;
    }    
    public player GenerateSmallForward(int overallGoal, Country country, int development, int peakStart, int peakEnd, bool isRedshirt, int year)
    {
        int age = 17;
        if (isRedshirt) age++;
        age += year;
        CollegePlayer retVal = new CollegePlayer(3, 1, 1, 1, 1, 1, 1, 1, 1, r.Next(1,10), r.Next(5,10),age, "Small Forward", peakStart, peakEnd, development, country, isRedshirt, year);
        int[] collegeProbabilties;
        if(r.NextBool()) collegeProbabilties = new int[] { 20, 10, 15, 15, 15, 15, 10, 5 };
        else collegeProbabilties = new int[] { 15, 25, 20, 20, 5, 15, 15, 15 };
        int sum = 0;
        for (int i = 0; i < collegeProbabilties.Length; i++)
            sum += collegeProbabilties[i];

        while (retVal.GetOldOverall() < overallGoal)
        {
            CollegePlayer copy = (CollegePlayer)retVal.Clone();
            int currSum = 0;
            int num = r.Next(sum);

            for (int i = 0; i < collegeProbabilties.Length; i++)
            {
                currSum += collegeProbabilties[i];
                if (currSum > num)
                {
                    UpgradePlayer(copy, i + 1);
                    break;
                }
            }
            if (copy.GetOldOverall() - overallGoal > .5)
            {
                continue;
            }
            retVal = copy;

        }
        retVal.updateRatings(r);
        return retVal;
    }    
    public player GenerateShootingGuard(int overallGoal, Country country, int development, int peakStart, int peakEnd, bool isRedshirt, int year)
    {
        int age = 17;
        if (isRedshirt) age++;
        age += year;
        CollegePlayer retVal = new CollegePlayer(4, 1, 1, 1, 1, 1, 1, 1, 1, r.Next(1, 10), r.Next(5, 10), age, "Shooting Guard", peakStart, peakEnd, development, country, isRedshirt, year);

        int[] collegeProbabilties = new int[] { 20, 20, 15, 15, 5, 25, 10, 15 };
        int sum = 0;
        for (int i = 0; i < collegeProbabilties.Length; i++)
            sum += collegeProbabilties[i];

        while (retVal.GetOldOverall() < overallGoal)
        {
            CollegePlayer copy = (CollegePlayer)retVal.Clone();
            int currSum = 0;
            int num = r.Next(sum);

            for (int i = 0; i < collegeProbabilties.Length; i++)
            {
                currSum += collegeProbabilties[i];
                if (currSum > num)
                {
                    UpgradePlayer(copy, i + 1);
                    break;
                }
            }
            if (copy.GetOldOverall() - overallGoal > .5)
            {
                continue;
            }
            retVal = copy;

        }
        retVal.updateRatings(r);
        return retVal;
    }
    public player GeneratePointGuard(int overallGoal, Country country, int development, int peakStart, int peakEnd, bool isRedshirt, int year)
    {
        int age = 17;
        if(isRedshirt)age++;
        age += year;
        CollegePlayer retVal = new CollegePlayer(5, 1, 1, 1, 1, 1, 1, 1, 1, r.Next(1, 10), r.Next(5, 10), age, "Point Guard", peakStart, peakEnd, development, country, isRedshirt, year);

        int[] collegeProbabilties = new int[] { 10, 20, 15, 15, 10, 15, 35, 20 };
        int sum = 0;
        for (int i = 0; i < collegeProbabilties.Length; i++)
            sum += collegeProbabilties[i];

        while (retVal.GetOldOverall() < overallGoal)
        {
            CollegePlayer copy = (CollegePlayer)retVal.Clone();
            int currSum = 0;
            int num = r.Next(sum);

            for (int i = 0; i < collegeProbabilties.Length; i++)
            {
                currSum += collegeProbabilties[i];
                if (currSum > num)
                {
                    UpgradePlayer(copy, i + 1);
                    break;
                }
            }
            if (copy.GetOldOverall() - overallGoal > .5)
            {
                continue;
            }
            retVal = copy;

        }
        retVal.updateRatings(r);
        return retVal;
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

}