using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[Serializable]
public abstract class CollegeTeamType
{
    public abstract int GetSuperstarPotential();
    public abstract int GetGoodPotential();
    public abstract int GetAveragePotential();
    public abstract int GetPoorPotential();
    public abstract int GetBadPotential();

    public int GetPlayerType(FormulaBasketball.Random r)
    {
        int value = r.Next(1000);
        int runningTotal = GetSuperstarPotential();
        if (value < runningTotal) return 1;
        runningTotal += GetGoodPotential();
        if (value < runningTotal) return 2;
        runningTotal += GetAveragePotential();
        if (value < runningTotal) return 3;
        runningTotal += GetPoorPotential();
        if (value < runningTotal) return 4;
        return 5;
    }

}
[Serializable]
public class EliteCollegeTeam : CollegeTeamType
{
    int[] potentials;
    public EliteCollegeTeam()
    {
        potentials = new int[]{10, 425, 375, 185, 5};
        
    }
    public override int GetSuperstarPotential()
    {
        return potentials[0];
    }

    public override int GetGoodPotential()
    {
        return potentials[1];
    }

    public override int GetAveragePotential()
    {
        return potentials[2];
    }

    public override int GetPoorPotential()
    {
        return potentials[3];
    }

    public override int GetBadPotential()
    {
        return potentials[4];
    }
}
[Serializable]
public class GoodCollegeTeam : CollegeTeamType
{
    int[] potentials;
    public GoodCollegeTeam()
    {
        potentials = new int[] { 3, 300, 435, 250, 12 };

    }
    public override int GetSuperstarPotential()
    {
        return potentials[0];
    }

    public override int GetGoodPotential()
    {
        return potentials[1];
    }

    public override int GetAveragePotential()
    {
        return potentials[2];
    }

    public override int GetPoorPotential()
    {
        return potentials[3];
    }

    public override int GetBadPotential()
    {
        return potentials[4];
    }
}
[Serializable]
public class AverageCollegeTeam : CollegeTeamType
{
    int[] potentials;
    public AverageCollegeTeam()
    {
        potentials = new int[] { 1, 180, 450, 270, 99 };

    }
    public override int GetSuperstarPotential()
    {
        return potentials[0];
    }

    public override int GetGoodPotential()
    {
        return potentials[1];
    }

    public override int GetAveragePotential()
    {
        return potentials[2];
    }

    public override int GetPoorPotential()
    {
        return potentials[3];
    }

    public override int GetBadPotential()
    {
        return potentials[4];
    }
}
[Serializable]
public class PoorCollegeTeam : CollegeTeamType
{
    int[] potentials;
    public PoorCollegeTeam()
    {
        potentials = new int[] { 0, 150, 250, 400, 200 };

    }
    public override int GetSuperstarPotential()
    {
        return potentials[0];
    }

    public override int GetGoodPotential()
    {
        return potentials[1];
    }

    public override int GetAveragePotential()
    {
        return potentials[2];
    }

    public override int GetPoorPotential()
    {
        return potentials[3];
    }

    public override int GetBadPotential()
    {
        return potentials[4];
    }
}
[Serializable]
public class BadCollegeTeam : CollegeTeamType
{
    int[] potentials;
    public BadCollegeTeam()
    {
        potentials = new int[] { 0, 50, 200, 500, 250};

    }
    public override int GetSuperstarPotential()
    {
        return potentials[0];
    }

    public override int GetGoodPotential()
    {
        return potentials[1];
    }

    public override int GetAveragePotential()
    {
        return potentials[2];
    }

    public override int GetPoorPotential()
    {
        return potentials[3];
    }

    public override int GetBadPotential()
    {
        return potentials[4];
    }
}