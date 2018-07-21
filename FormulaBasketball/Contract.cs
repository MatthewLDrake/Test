using System;

[Serializable]
public class Contract
{
    private int years, yearsIn;
    private double money;
    public Contract(int years, double money, int yearsIn = 0)
    {
        this.years = years;
        this.money = money;
        this.yearsIn = yearsIn;
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


}