using FormulaBasketball;
using System;
using System.Collections.Generic;
[Serializable]
public class teamResults
{
    private List<Int32> history;
    private teamTier tier;
    private double average;
    public teamResults(int[] results)
    {
        history = new List<Int32>();
        for (int i = 0; i < results.Length; i++)
        {
            history.Add(results[i]);
        }

        int sum = 0;
        for (int i = history.Count - 1; i >= Math.Max(0, history.Count - 6); i--)
        {
            sum += history[i];
        }
        average = sum / Math.Max(history.Count, 5);
        if (average > 22) tier = teamTier.BOTTOMFEEDER;
        else if (average > 10) tier = teamTier.MIDRANGE;
        else tier = teamTier.ELITE;
    }
    public double getAverage()
    {
        return average;
    }
    public void setTeamTier(teamTier teamTier)
    {
        tier = teamTier;
    }
    public teamTier getTeamTier()
    {
        return tier;
    }
    public int compareTo(teamResults o)
    {
        return tier.CompareTo(o.getTeamTier());
    }
}
