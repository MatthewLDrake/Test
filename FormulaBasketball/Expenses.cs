using System;
[Serializable]
public class Expenses
{
    private double[] weeklyExpenses;
    private double sharedIncome;
    private double[] sponsers;
    private int weeklySponser;

    private long sharedIncomeCount;
    private double[] totalExpenses;

    public Expenses(double[] expenses)
    {
        totalExpenses = new double[expenses.Length];
        sharedIncome = 2380952;
        weeklyExpenses = new double[expenses.Length];
        for (int i = 0; i < expenses.Length; i++)
        {
            weeklyExpenses[i] = (expenses[i] / 21) * 1000000;
        }
    }

    public int chargeExpenses(int fianance, double sponserMoney)
    {
        double retVal = (int)(fianance + sponserMoney);
        for (int i = 0; i < weeklyExpenses.Length; i++)
        {
            retVal -= weeklyExpenses[i];
            totalExpenses[i] += weeklyExpenses[i];
        }
        retVal += sharedIncome + weeklySponser;
        sharedIncomeCount += (long)sharedIncome;
        return (int)retVal;
    }

    public void setSponsers(double[] arr)
    {
        this.sponsers = arr;

    }
    private int homeGameMoneyEarned = 0;
    public int homeGameOccurred(int fianance)
    {
        int retVal = fianance;
        if (sponsers != null)
        {
            for (int i = 0; i < sponsers.Length; i++)
            {
                retVal += (int)sponsers[i];
                homeGameMoneyEarned += (int)sponsers[i];
            }
        }
        return retVal;
    }
    public int getHomeMoneyEarned()
    {
        int retVal = homeGameMoneyEarned;
        homeGameMoneyEarned = 0;
        return retVal;
    }
    public void setWeeklySponser(int i)
    {
        weeklySponser = i;

    }
    public int getWeeklySponser()
    {
        return weeklySponser;
    }

    public double getSharedRevenue()
    {
        return sharedIncomeCount;
    }

    public double[] getTotalExpenses()
    {
        return totalExpenses;
    }

}
