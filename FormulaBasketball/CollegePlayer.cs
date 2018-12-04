using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class CollegePlayer : player, ICloneable
{
    private bool isRedshirt, hasRedshirt, wentPro;
    private int year;
    private int personality;
    public bool scout = false;
    private const int ONE_AND_DONE = 1, FOUR_YEAR_PLAYER = 2, SUCCESS_BASED = 3, OVERALL_BASED = 4, MIXED = 5; 
    public CollegePlayer(int pos, int insideScoring, int jumpStat, int threePoint, int passing, int shotContest, int defenseIQ, int jumping, int separation, int durability, int stamina, int age, String name, int peakStart, int peakEnd, int development, Country country, bool hasRedshirt, int year, int personality = 0)
        : base(pos, insideScoring, insideScoring, jumpStat, threePoint, passing, shotContest, defenseIQ, jumping, separation, durability, stamina, age, name, false, peakStart, peakEnd, development, country, -1)
    {
        this.hasRedshirt = hasRedshirt;
        this.year = year;
        isRedshirt = false;
        wentPro = false;
        this.personality = personality;
    }
    public object Clone()
    {
        return this.MemberwiseClone();
    }
    /*
     * Ratings: 
     * 
     * ratings[0] = layup
     * ratings[1] = dunk
     * ratings[2] = jumpshot
     * ratings[3] = shot contest
     * ratings[4] = defense iq
     * ratings[5] = jumping
     * ratings[6] = seperation
     * ratings[7] = passing
     * ratings[8] = stamina
     * ratings[9] = threepoint
     * ratings[10] = durability
     */
    public void IncreaseInsideScoring()
    {
        if (ratings[0] == 10) return;
        ratings[0]++;
        ratings[1]++;
    }
    public void IncreaseJumpShot()
    {
        if (ratings[2] == 10) return;
        ratings[2]++;
    }
    public void IncreaseShotContest()
    {
        if (ratings[3] == 10) return;
        ratings[3]++;
    }
    public void IncreaseDefenseIQ()
    {
        if (ratings[4] == 10) return;
        ratings[4]++;
    }
    public void IncreaseJumping()
    {
        if (ratings[5] == 10) return;
        ratings[5]++;
    }
    public void IncreaseSeperation()
    {
        if (ratings[6] == 10) return;
        ratings[6]++;
    }
    public void IncreasePassing()
    {
        if (ratings[7] == 10) return;
        ratings[7]++;
    }
    public void IncreaseThreePoint()
    {
        if (ratings[9] == 10) return;
        ratings[9]++;
    }
    public bool WentPro()
    {
        return wentPro;
    }
    public bool Graduated()
    {
        return year > 4;
    }
    public bool CanRedshirt()
    {
        return !hasRedshirt;
    }
    public void Redshirt()
    {
        isRedshirt = true;
    }
    public void FixRatings(FormulaBasketball.Random r)
    {
        for(int i = 0; i < ratings.Length; i++)
        {
            if (ratings[i] > 100) ratings[i] = r.Next(90, 101);
        }
    }
    public bool GoPro(FormulaBasketball.Random r)
    {
        //int score = 0;
        if(getOverall() > 70)
        {
            wentPro = true;
            IsRookie();
            return true;
        }

        switch(personality)
        {
            case ONE_AND_DONE:
                wentPro = true;
                return true;
            case FOUR_YEAR_PLAYER:
                if (year > 4 && starts > 0)
                {
                    wentPro = true;
                    IsRookie();
                    return true;
                }
                else
                {
                    return false;
                }
            case OVERALL_BASED:
                if (getOverall() > 55)
                {
                    wentPro = true;
                    IsRookie();
                    return true;
                }
                break;

            case SUCCESS_BASED:
                break;
            case MIXED:
                break;
        }
        if (starts > 20 && getOverall() > 50 && team.getWins() >= team.getLosses())
        {
            wentPro = true;
            IsRookie();
            return true; 
        }
        if (starts > 20 && getOverall() > 60)
        {
            wentPro = true;
            IsRookie();
            return true;
        }
        return false;
    }
    public void EndCollegeSeason()
    {
        if(isRedshirt)
        {
            hasRedshirt = true;
            isRedshirt = false;
        }
        else
        {
            year++;
        }
        age++;
    }
    private const int SCOUT_SKILL = 20;
    private string layupStr;
    private string dunkStr;
    private string jumpshotStr;
    private string threepointStr;
    private string passStr;
    private string shotcontestStr;
    private string defenseiqStr;
    private string jumpingStr;
    private string seperationStr;
    private string durabilityStr;
    private string staminaStr;
    private string potential;
    public void Create(FormulaBasketball.Random r)
    {
        int[] elevens = new int[11];
        for (int i = 0; i < elevens.Length; i++)
        {
            elevens[i] = r.Next(-SCOUT_SKILL, 0);
        }

        layupStr = "" + (elevens[0] + getLayupRating(false)) + " -> " + (elevens[0] + getLayupRating(false) + SCOUT_SKILL);
        dunkStr = "" + (elevens[1] + getDunkRating(false)) + " -> " + (elevens[1] + getDunkRating(false) + SCOUT_SKILL);
        jumpshotStr = "" + (elevens[2] + getJumpShotRating(false)) + " -> " + (elevens[2] + getJumpShotRating(false) + SCOUT_SKILL);
        threepointStr = "" + (elevens[3] + getThreeShotRating(false)) + " -> " + (elevens[3] + getThreeShotRating(false) + SCOUT_SKILL);
        passStr = "" + (elevens[4] + getPassing(false)) + " -> " + (elevens[4] + getPassing(false) + SCOUT_SKILL);
        shotcontestStr = "" + (elevens[5] + getShotContestRating(false)) + " -> " + (elevens[5] + getShotContestRating(false) + SCOUT_SKILL);
        defenseiqStr = "" + (elevens[6] + getDefenseIQRating(false)) + " -> " + (elevens[6] + getDefenseIQRating(false) + SCOUT_SKILL);
        jumpingStr = "" + (elevens[7] + getJumpingRating(false)) + " -> " + (elevens[7] + getJumpingRating(false) + SCOUT_SKILL);
        seperationStr = "" + (elevens[8] + getSeperation(false)) + " -> " + (elevens[8] + getSeperation(false) + SCOUT_SKILL);
        durabilityStr = "" + (elevens[9] + getDurabilityRating(false)) + " -> " + (elevens[9] + getDurabilityRating(false) + SCOUT_SKILL);
        staminaStr = "" + (elevens[10] + getStaminaRating(false)) + " -> " + (elevens[10] + getStaminaRating(false) + SCOUT_SKILL);

        int normalizedPS = (peakStart - 27) * 2;
        int normalizedPE = (peakEnd - 30) * 2;

        int average = (normalizedPE + normalizedPS + development * 3) / 5;

        int temp = Math.Max(1, Math.Min(10, r.Next(-2, 2) + average));
        switch (temp)
        {
            case 1:
                potential = "F";
                break;
            case 2:
                potential = "F+";
                break;
            case 3:
                potential = "D";
                break;
            case 4:
                potential = "D+";
                break;
            case 5:
                potential = "C";
                break;
            case 6:
                potential = "C+";
                break;
            case 7:
                potential = "B";
                break;
            case 8:
                potential = "B+";
                break;
            case 9:
                potential = "A";
                break;
            case 10:
                potential = "A+";
                break;
        }
    }
    public int GetPosition()
    {
        return position;
    }
    public string GetLayup()
    {
        return layupStr;
    }
    public string GetDunk()
    {
        return dunkStr;
    }
    public string GetJumpshot()
    {
        return jumpshotStr;
    }
    public string GetThreePoint()
    {
        return threepointStr;
    }
    public string GetPass()
    {
        return passStr;
    }
        public string GetShotContest()
    {
        return shotcontestStr;
    }
        public string GetDefenseIQ()
    {
        return defenseiqStr;
    }
    public string GetJumping()
    {
        return jumpingStr;
    }
        public string GetSeperation()
    {
        return seperationStr;
    }
    public string GetDurability()
    {
        return durabilityStr;
    }
        public string GetStamina()
    {
        return staminaStr;
    }
    public string GetPotential()
    {
        return potential;
    }
}

