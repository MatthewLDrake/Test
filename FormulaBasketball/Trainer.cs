using System;
[Serializable]
public class Trainer
{
    private String name;
    private int injuryPrevention, injuryDuration;
    private double staminaModifier;
    private FormulaBasketball.Random r;
    public Trainer(String name, int injuryPrevention, int injuryDuration, double staminaModifier, FormulaBasketball.Random r)
    {
        this.r = r;
        this.setName(name);
        this.setInjuryDuration(injuryDuration);
        this.setInjuryPrevention(injuryPrevention);
        this.setStaminaModifier(staminaModifier);
    }
    public String getName()
    {
        return name;
    }
    public void setName(String name)
    {
        this.name = name;
    }
    public int getInjuryPrevention(player player)
    {
        int injuryNumber = (int)player.getDurabilityRating() + injuryPrevention;

        if(injuryNumber < 0)
        {
            Console.WriteLine(player.getDurabilityRating() + " " + injuryPrevention);
        }

        return injuryNumber * 1250;
    }
    public void setInjuryPrevention(int injuryPrevention)
    {
        this.injuryPrevention = injuryPrevention;
    }
    public int getInjuryDuration(int i)
    {

        if (i == 0)
        {
            if (injuryDuration > 4) return 0;
            else if (injuryDuration == 3) return 1;
            else if (injuryDuration == 2) return r.Next(0, 2);
            else return r.Next(0, 5);
        }
        else if (i == 1)
        {
            if (injuryDuration == 10) return r.Next(0, 2) + 1;
            else if (injuryDuration == 9) return r.Next(0, 3) + 1;
            else if (injuryDuration == 8) return r.Next(0, 5) + 2;
            else if (injuryDuration == 7) return r.Next(0, 5) + 2;
            else if (injuryDuration == 6) return r.Next(0, 5) + 3;
            else if (injuryDuration == 5) return r.Next(0, 7) + 3;
            else if (injuryDuration == 4) return r.Next(0, 7) + 5;
            else if (injuryDuration == 3) return r.Next(0, 7) + 7;
            else if (injuryDuration == 2) return r.Next(0, 7) + 9;
            else if (injuryDuration == 1) return r.Next(0, 10) + 10;
        }
        else if (i == 2)
        {
            if (injuryDuration == 10) return r.Next(0, 5) + 5;
            else if (injuryDuration == 9) return r.Next(0, 7) + 5;
            else if (injuryDuration == 8) return r.Next(0, 7) + 10;
            else if (injuryDuration == 7) return r.Next(0, 10) + 12;
            else if (injuryDuration == 6) return r.Next(0, 10) + 15;
            else if (injuryDuration == 5) return r.Next(0, 13) + 15;
            else if (injuryDuration == 4) return r.Next(0, 13) + 17;
            else if (injuryDuration == 3) return r.Next(0, 15) + 17;
            else if (injuryDuration == 2) return r.Next(0, 15) + 20;
            else if (injuryDuration == 1) return r.Next(0, 20) + 20;
        }
        else if (i == 3)
        {
            if (injuryDuration == 10) return r.Next(0, 5) + 15;
            else if (injuryDuration == 9) return r.Next(0, 5) + 20;
            else if (injuryDuration == 8) return r.Next(0, 10) + 22;
            else if (injuryDuration == 7) return r.Next(0, 15) + 25;
            else if (injuryDuration == 6) return r.Next(0, 20) + 25;
            else if (injuryDuration == 5) return r.Next(0, 25) + 25;
            else if (injuryDuration == 4) return r.Next(0, 30) + 30;
            else if (injuryDuration == 3) return r.Next(0, 35) + 30;
            else if (injuryDuration == 2) return r.Next(0, 35) + 35;
            else if (injuryDuration == 1) return r.Next(0, 40) + 40;
        }

        return injuryDuration;
    }
    public void setInjuryDuration(int injuryDuration)
    {
        this.injuryDuration = injuryDuration;
    }
    public double getStaminaModifier()
    {
        return staminaModifier;
    }
    public void setStaminaModifier(double staminaModifier)
    {
        this.staminaModifier = staminaModifier;
    }


    public string SaveTeam()
    {
        string content = "<trainer>";
        content += name + "," + injuryPrevention + "," + injuryDuration + "," + staminaModifier;
        return content + "\n";
    }
}
