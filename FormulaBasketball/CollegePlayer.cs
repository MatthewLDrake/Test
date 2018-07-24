using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CollegePlayer : player, ICloneable
{
    private bool isRedshirt, hasRedshirt;
    private int year;
    public CollegePlayer(int pos, int insideScoring, int jumpStat, int threePoint, int passing, int shotContest, int defenseIQ, int jumping, int separation, int durability, int stamina, int age, String name, int peakStart, int peakEnd, int development, Country country, bool hasRedshirt, int year)
        : base(pos, insideScoring, insideScoring, jumpStat, threePoint, passing, shotContest, defenseIQ, jumping, separation, durability, stamina, age, name, false, peakStart, peakEnd, development, country, -1)
    {
        this.hasRedshirt = hasRedshirt;
        this.year = year;
        isRedshirt = false;
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
    public bool GoPro()
    {
        if (starts > 20 && getOverall() > 50 && team.getWins() >= team.getLosses()) return true;
        if (starts > 20 && getOverall() > 60) return true;
        return false;
    }
}

