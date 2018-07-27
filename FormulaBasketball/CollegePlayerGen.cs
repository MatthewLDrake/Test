using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CollegePlayerGen
{
    private FormulaBasketball.Random r;
    public CollegePlayerGen(FormulaBasketball.Random r)
    {
        this.r = r;
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
    public CollegePlayer GenerateCenter(int overallGoal, Country country, int development, int peakStart, int peakEnd, bool isRedshirt, int year, int personality)
    {
        NameGenerator gen = NameGenerator.Instance();
        String name = gen.GenerateName(country);
        int age = 17;
        if (isRedshirt) age++;
        age += year;
        CollegePlayer retVal = new CollegePlayer(1, 1, 1, 1, 1, 1, 1, 1, 1, r.Next(1, 10), r.Next(5, 10), age, name, peakStart, peakEnd, development, country, isRedshirt, year, personality);

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

    public CollegePlayer GeneratePowerForward(int overallGoal, Country country, int development, int peakStart, int peakEnd, bool isRedshirt, int year, int personality)
    {
        NameGenerator gen = NameGenerator.Instance();
        String name = gen.GenerateName(country);
        int age = 17;
        if (isRedshirt) age++;
        age += year;
        CollegePlayer retVal = new CollegePlayer(2, 1, 1, 1, 1, 1, 1, 1, 1, r.Next(1, 10), r.Next(5, 10), age, name, peakStart, peakEnd, development, country, isRedshirt, year, personality);

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
    public CollegePlayer GenerateSmallForward(int overallGoal, Country country, int development, int peakStart, int peakEnd, bool isRedshirt, int year, int personality)
    {
        NameGenerator gen = NameGenerator.Instance();
        String name = gen.GenerateName(country);
        int age = 17;
        if (isRedshirt) age++;
        age += year;
        CollegePlayer retVal = new CollegePlayer(3, 1, 1, 1, 1, 1, 1, 1, 1, r.Next(1, 10), r.Next(5, 10), age, name, peakStart, peakEnd, development, country, isRedshirt, year, personality);
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
    public CollegePlayer GenerateShootingGuard(int overallGoal, Country country, int development, int peakStart, int peakEnd, bool isRedshirt, int year, int personality)
    {
        NameGenerator gen = NameGenerator.Instance();
        String name = gen.GenerateName(country);
        int age = 17;
        if (isRedshirt) age++;
        age += year;
        CollegePlayer retVal = new CollegePlayer(4, 1, 1, 1, 1, 1, 1, 1, 1, r.Next(1, 10), r.Next(5, 10), age, name, peakStart, peakEnd, development, country, isRedshirt, year, personality);

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
    public CollegePlayer GeneratePointGuard(int overallGoal, Country country, int development, int peakStart, int peakEnd, bool isRedshirt, int year, int personality)
    {
        NameGenerator gen = NameGenerator.Instance();
        String name = gen.GenerateName(country);
        int age = 17;
        if (isRedshirt) age++;
        age += year;
        CollegePlayer retVal = new CollegePlayer(5, 1, 1, 1, 1, 1, 1, 1, 1, r.Next(1, 10), r.Next(5, 10), age, name, peakStart, peakEnd, development, country, isRedshirt, year, personality);

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