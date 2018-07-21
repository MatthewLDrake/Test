using System;
[Serializable]
public class Merchandise
{
    private int weeklyRevenue;
    public Merchandise(FormulaBasketball.Random r)
    {
        
        weeklyRevenue = r.Next(0,100000) + 1950000;
    }
    public int getWeeklyRevenue()
    {
        return weeklyRevenue;
    }
}