using System;
using System.Collections.Generic;
[Serializable]
public class FIBUTeam : team
{
    private double[] lowestOveralls = new double[5];
    public FIBUTeam(string teamName, FormulaBasketball.Random r) : base(teamName, r)
    {

    }
    public void ConditionalAddPlayer(player newPlayer)
    {
        if (playersPerPos[newPlayer.getPosition() - 1] == 3 && lowestOveralls[newPlayer.getPosition() - 1] > newPlayer.getOverall()) return;
        if (lowestOveralls[newPlayer.getPosition() - 1] == 0 || lowestOveralls[newPlayer.getPosition() - 1] > newPlayer.getOverall()) lowestOveralls[newPlayer.getPosition() - 1] = newPlayer.getOverall();
        players.Add(newPlayer);
        newPlayer.setTeam(this);
        addPos(newPlayer.getPosition() - 1);
    }
    public void Reorder(Country country)
    {
        player[] orderedRoster = new player[15];
        for (int i = 0; i < players.Count; i++)
        {
            player currPlayer = players[i];
            int position = currPlayer.getPosition() - 1;
            while (true)
            {
                if (position > 14)
                {
                    break;
                }
                else if (orderedRoster[position] == null)
                {
                    orderedRoster[position] = currPlayer;
                    break;
                }
                else if (currPlayer.getOverall() > orderedRoster[position].getOverall())
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
            if (orderedRoster[i] == null)
            {
                int pos = ((i % 5) + 1);
                orderedRoster[i] = NewPlayer(pos, country);
                orderedRoster[i].updateRatings(r);
            }
        }
        players = new List<player>();
        for (int i = 0; i < orderedRoster.Length; i++)
        {
            players.Add(orderedRoster[i]);
        }
    }
    private player NewPlayer(int position, Country country)
    {

        int overallGoal = 0;
        int development = 5;
        int peakStart = 28;
        int peakEnd = 32;

        switch (position)
        {
            case 1:
                if (r.Next(10) == 3)
                {
                    overallGoal = 77;
                }
                else
                {
                    overallGoal = r.Next(60, 65);
                }
                break;
            case 2:
                overallGoal = r.Next(50, 55);
                while (r.NextBool()) overallGoal += 5;
                break;
            case 3:
                overallGoal = r.Next(40, 45);
                while (r.NextBool()) overallGoal += 3;
                break;
            case 4:
                overallGoal = r.Next(30, 35);
                while (r.NextBool()) overallGoal += 5;
                break;
            default:
                overallGoal = r.Next(30, 35);
                while (r.NextBool()) overallGoal += 5;
                break;
        }

        if (position == 1) return GenerateCenter(overallGoal, country, development, peakStart, peakEnd, false, r.Next(1, 12));
        else if (position == 2) return GeneratePowerForward(overallGoal, country, development, peakStart, peakEnd, false, r.Next(1, 12));
        else if (position == 3) return GenerateSmallForward(overallGoal, country, development, peakStart, peakEnd, false, r.Next(1, 12));
        else if (position == 4) return GenerateShootingGuard(overallGoal, country, development, peakStart, peakEnd, false, r.Next(1, 12));
        else return GeneratePointGuard(overallGoal, country, development, peakStart, peakEnd, false, r.Next(1,12));        
    }

    public player GenerateCenter(int overallGoal, Country country, int development, int peakStart, int peakEnd, bool isRedshirt, int year)
    {
        int age = 17;
        if (isRedshirt) age++;
        age += year;
        CollegePlayer retVal = new CollegePlayer(1, 1, 1, 1, 1, 1, 1, 1, 1, r.Next(1, 10), r.Next(5, 10), age, "Center", peakStart, peakEnd, development, country, isRedshirt, year);

        int[] collegeProbabilties = new int[] { 25, 5, 15, 15, 30, 15, 5, 2 };
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
    private void UpgradePlayer(CollegePlayer player, int skill)
    {
        switch (skill)
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
    public player GeneratePowerForward(int overallGoal, Country country, int development, int peakStart, int peakEnd, bool isRedshirt, int year)
    {
        int age = 17;
        if (isRedshirt) age++;
        age += year;
        CollegePlayer retVal = new CollegePlayer(2, 1, 1, 1, 1, 1, 1, 1, 1, r.Next(1, 10), r.Next(5, 10), age, "Power Forward", peakStart, peakEnd, development, country, isRedshirt, year);

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
        CollegePlayer retVal = new CollegePlayer(3, 1, 1, 1, 1, 1, 1, 1, 1, r.Next(1, 10), r.Next(5, 10), age, "Small Forward", peakStart, peakEnd, development, country, isRedshirt, year);
        int[] collegeProbabilties;
        if (r.NextBool()) collegeProbabilties = new int[] { 20, 10, 15, 15, 15, 15, 10, 5 };
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
        if (isRedshirt) age++;
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
}