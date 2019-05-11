using System;
using System.Collections.Generic;
[Serializable]
public class Contract
{
    private int years, yearsIn;
    private double money, bonus;
    private List<Promises> promises;
    public Contract(int years, double money, int yearsIn = 0, double bonus = 0, List<Promises> promises = null)
    {
        this.years = years;
        this.money = money;
        this.yearsIn = yearsIn;
        this.bonus = bonus;
        if (promises == null) this.promises = new List<Promises>();
        else this.promises = promises;
    }
    public Contract(String contract)
    {
        String[] info = contract.Split('\t');
        years = int.Parse(info[0]);
        money = double.Parse(info[1]);
        yearsIn = 0;
        bonus = 0;
        this.promises = new List<Promises>();
    }
    public double GetBonus()
    {
        return bonus;
    }
    public override string ToString()
    {
        return "" + (years - yearsIn) + "\t" + money;
    }
    public double GetTotalMoney()
    {
        return years * money + bonus;
    }
    public bool IsExpired()
    {
        return yearsIn >= years;
    }
    public void AdvanceYear()
    {
        yearsIn++;
    }
    public double GetMoney()
    {
        return money;
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