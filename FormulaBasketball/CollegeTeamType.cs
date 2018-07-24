using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class CollegeTeamType
{
    public abstract int GetSuperstarPotential();
    public abstract int GetGoodPotential();
    public abstract int GetAveragePotential();
    public abstract int GetPoorPotential();
    public abstract int GetBadPotential();

    public int GetPlayerType(FormulaBasketball.Random r)
    {
        int value = r.Next(100);
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

public class EliteCollegeTeam : CollegeTeamType
{
    int[] potentials;
    public EliteCollegeTeam()
    {
        potentials = new int[]{5, 40, 34, 18, 3};
        
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
public class GoodCollegeTeam : CollegeTeamType
{
    int[] potentials;
    public GoodCollegeTeam()
    {
        potentials = new int[] { 3, 30, 35, 25, 7 };

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

public class AverageCollegeTeam : CollegeTeamType
{
    int[] potentials;
    public AverageCollegeTeam()
    {
        potentials = new int[] { 2, 18, 50, 20, 10 };

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

public class PoorCollegeTeam : CollegeTeamType
{
    int[] potentials;
    public PoorCollegeTeam()
    {
        potentials = new int[] { 1, 18, 25, 40, 16 };

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
public class BadCollegeTeam : CollegeTeamType
{
    int[] potentials;
    public BadCollegeTeam()
    {
        potentials = new int[] { 0, 5, 20, 50, 25};

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