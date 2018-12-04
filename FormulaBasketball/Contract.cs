using System;

[Serializable]
public class Contract
{
    private int years, yearsIn;
    private double money, bonus;
    public Contract(int years, double money, int yearsIn = 0, double bonus = 0)
    {
        this.years = years;
        this.money = money;
        this.yearsIn = yearsIn;
        this.bonus = bonus;
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
        return years * money;
    }
    public bool IsExpired()
    {
        return yearsIn == years;
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

}