using System;
using System.Collections.Generic;
[Serializable]
public class Contract
{
    private int years, yearsIn;
    private double money, bonus, maxDiff;
    private List<Promises> promises;
    private bool dLeague;
    public Contract(int years, double money, int yearsIn = 0, double bonus = 0, List<Promises> promises = null, double maxDiff = 0)
    {
        this.years = years;
        this.money = money;
        this.yearsIn = yearsIn;
        this.bonus = bonus;
        if (promises == null) this.promises = new List<Promises>();
        else this.promises = promises;
        this.maxDiff = maxDiff;
    }
    public Contract(string information)
    {
        if (information.Equals("DLeague"))
        {
            dLeague = true;
            years = 1;
            money = 1;
        }
        else
        {
            string[] strs = information.Split('-');
            years = int.Parse(strs[0]);
            money = double.Parse(strs[1]);
            bonus = double.Parse(strs[2]);
            maxDiff = double.Parse(strs[3]);
            promises = new List<Promises>();
            for(int i = 4; i < strs.Length; i++)
            {
                promises.Add(IntToPromise(int.Parse(strs[i])));
            }

            dLeague = false;
        }
    }
    public string SaveAsString()
    {
        if (dLeague)
            return "DLeague";

        string retVal = years + "-" + money + "-" + bonus + "-" + maxDiff;
        foreach (Promises promise in promises)
        {
            retVal += "-" + PromiseToInt(promise);
        }

        return retVal;
    }
    public override string ToString()
    {
        if (dLeague)
            return "DLeague";

        string retVal = years + " years averaging " + money + " per year with a " + bonus + " million dollar bonus and a " + maxDiff + " load with ";
        if (promises.Count == 0)
            retVal += " no promises";
        else
            retVal += " the following promises:";
        foreach(Promises promise in promises)
        {
            retVal += " " + promise;
        }

        return retVal;
    }
    private Promises IntToPromise(int i)
    {
        switch(i)
        {
            default:
                return Promises.Year_One_Starter;
            case 1:
                return Promises.Win_Division;
            case 2:
                return Promises.Win_Conference;
            case 3:
                return Promises.Win_Championship;
            case 4:
                return Promises.Make_Playoffs;
            case 5:
                return Promises.No_Trade;
            case 6:
                return Promises.Over_Five_Hundred;
            case 7:
                return Promises.Win_Over_Fifty;
        }
    }
    private int PromiseToInt(Promises promise)
    {
        switch(promise)
        {
            case Promises.Year_One_Starter:
                return 0;                
            case Promises.Win_Division:
                return 1;
            case Promises.Win_Conference:
                return 2;
            case Promises.Win_Championship:
                return 3;
            case Promises.Make_Playoffs:
                return 4;
            case Promises.No_Trade:
                return 5;
            case Promises.Over_Five_Hundred:
                return 6;
            case Promises.Win_Over_Fifty:
                return 7;
            default: 
                return -1;
        }
    }
    public bool IsDLeague()
    {
        return dLeague;
    }
    public double GetBonus()
    {
        return bonus;
    }
    
    public double GetTotalMoney()
    {
        return years * money + bonus;
    }
    public bool IsExpired()
    {
        return yearsIn >= years;
    }
    public void AdvanceYear(int years = 1)
    {
        yearsIn += years;
    }
    public double GetAverageMoney()
    {
        return money;
    }
    public double GetMoney()
    {
        if (maxDiff != 0 && years != 1)
        {
            double startMoney = maxDiff * money;            

            double slope = (startMoney * 2) / (years - 1);

            double yIntercept = money - startMoney;            

            return (yearsIn * slope + yIntercept);
        }
        else
        {
            return money;
        }
    }
    public int GetYearsLeft()
    {
        return years - yearsIn;
    }
    public List<Promises> GetPromises()
    {
        if (promises == null) promises = new List<Promises>();
        return promises;
    }

}