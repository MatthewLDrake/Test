using System;
using System.Collections.Generic;
[Serializable]
public class Coach
{
    private int staminaSubOut;
    private int staminaSubIn;
    private double offenseModifier;
    private int offenseModifierProbability;
    private double defenseModifier;
    private int defenseModifierProbability;
    private Tempo preferredTempo;
    private coachShotType preferredShotType;
    private ssInvolvment superStarInvolvment;
    private String name;
    private FormulaBasketball.Random r;
    public team currTeam;
    public Coach(String name, int staminaSubOut, int staminaSubIn, double offenseModifier, int offenseModifierProbability, double defenseModifier, int defenseModifierProbability, Tempo preferredTempo, coachShotType preferredShotType, ssInvolvment superStarInvolvment, FormulaBasketball.Random r)
    {
        this.r = r;
        this.setName(name);
        this.setStaminaSubOut(staminaSubOut);
        this.setStaminaSubIn(staminaSubIn);
        this.setOffenseModifier(offenseModifier);
        this.setOffenseModifierProbability(offenseModifierProbability);
        this.setDefenseModifier(defenseModifier);
        this.setDefenseModifierProbability(defenseModifierProbability);
        this.setPreferredTempo(preferredTempo);
        this.setPreferredShotType(preferredShotType);
        this.setSuperStarInvolvment(superStarInvolvment);
    }
    public Coach(String info, FormulaBasketball.Random r, team team)
    {
        currTeam = team;
        this.r = r;
        String[] arr = info.Split(',');
        name = arr[0].Replace("<coach>", "");
        staminaSubIn = int.Parse(arr[1]);
        staminaSubOut = int.Parse(arr[2]);
        offenseModifier = Double.Parse(arr[3]);
        offenseModifierProbability = int.Parse(arr[4]);
        defenseModifier = Double.Parse(arr[5]);
        defenseModifierProbability = int.Parse(arr[6]);

        // TODO: Save this info
        preferredTempo = new Tempo(0);
        preferredShotType = coachShotType.BALANCED;
        superStarInvolvment = ssInvolvment.MEDIUM;
    }
    private OffensivePhilosophy offensivePhilosophy;
    private DefensivePhilosophy defensivePhilosophy;
    // New style of coach
    public Coach(string name, OffensivePhilosophy offense, DefensivePhilosophy defense, FormulaBasketball.Random r)
    {
        this.name = name;
        offensivePhilosophy = offense;
        defensivePhilosophy = defense;
        this.r = r;
    }


    public string SaveTeam()
    {
        string content = "<coach>";
        content += name + "," + staminaSubIn + "," + staminaSubOut + "," + offenseModifier + "," + offenseModifierProbability + "," + defenseModifier + "," + defenseModifierProbability;
        return content + "\n";
    }
    public int getStaminaSubOut()
    {
        return staminaSubOut;
    }
    public void setStaminaSubOut(int staminaSubOut)
    {
        this.staminaSubOut = staminaSubOut;
    }
    public int getStaminaSubIn()
    {
        return staminaSubIn;
    }
    public void setStaminaSubIn(int staminaSubIn)
    {
        this.staminaSubIn = staminaSubIn;
    }
    public double getOffenseModifier()
    {
        return offenseModifier;
    }
    public void setOffenseModifier(double offenseModifier)
    {
        this.offenseModifier = offenseModifier;
    }
    public int getOffenseModifierProbability()
    {
        return offenseModifierProbability;
    }
    public void setOffenseModifierProbability(int offenseModifierProbability)
    {
        this.offenseModifierProbability = offenseModifierProbability;
    }
    public double getDefenseModifier()
    {
        return defenseModifier;
    }
    public void setDefenseModifier(double defenseModifier)
    {
        this.defenseModifier = defenseModifier;
    }
    public int getDefenseModifierProbability()
    {
        return defenseModifierProbability;
    }
    public void setDefenseModifierProbability(int defenseModifierProbability)
    {
        this.defenseModifierProbability = defenseModifierProbability;
    }
    public Tempo getPreferredTempo()
    {
        return preferredTempo;
    }
    public void setPreferredTempo(Tempo preferredTempo)
    {
        this.preferredTempo = preferredTempo;
    }
    public coachShotType getPreferredShotType()
    {
        return preferredShotType;
    }
    public void setPreferredShotType(coachShotType preferredShotType)
    {
        this.preferredShotType = preferredShotType;
    }
    public ssInvolvment getSuperStarInvolvment()
    {
        return superStarInvolvment;
    }
    public void setSuperStarInvolvment(ssInvolvment superStarInvolvment)
    {
        this.superStarInvolvment = superStarInvolvment;
    }
    public String getName()
    {
        return name;
    }
    public void setName(String name)
    {
        this.name = name;
    }
    private team coachesTeam;
    public team Team
    {
        set
        {
            coachesTeam = value;
        }
        get
        {
            return coachesTeam;
        }
    }
    public bool useSuperStar()
    {        
        return r.Next(0, 100) + 1 < (int)superStarInvolvment;
    }
    public OffensivePlay GetOffensivePlay(int scoreDiff, int quarterNum, int timeLeft)
    {
        return offensivePhilosophy.PickPlay(scoreDiff, quarterNum, timeLeft);
    }
    public DefensivePlay GetDefensivePlay(int scoreDiff, int quarterNum, int timeLeft)
    {
        return defensivePhilosophy.PickPlay(scoreDiff, quarterNum, timeLeft);
    }
}
[Serializable]
public abstract class OffensivePhilosophy
{
    
    public OffensivePhilosophy()
    {
    }
    public static List<OffensivePhilosophy> GetPhilosophies()
    {
        return PhilosophyHolder.GetOffensivePhilosophies();
    }
    public abstract OffensivePlay PickPlay(int scoreDiff, int quarterNum, int timeLeft);
}
[Serializable]
public class SevenSecond : OffensivePhilosophy
{
    public SevenSecond()
    {

    }
    public override string ToString()
    {
 	    return "Seven Second";
    }
}
private class PhilosophyHolder
{
    private static List<DefensivePhilosophy> defensivePhilosophies;
    private static List<OffensivePhilosophy> offensivePhilosophies;

    static PhilosophyHolder()
    {
        defensivePhilosophies = new List<DefensivePhilosophy>();
        defensivePhilosophies.Add(new ManNoSwitch());
        defensivePhilosophies.Add(new ManSwitch());

        offensivePhilosophies = new List<OffensivePhilosophy>();
        offensivePhilosophies.Add(new SevenSecond());
    }
    public static List<DefensivePhilosophy> GetDefensivePhilosophies()
    {
        return defensivePhilosophies;
    }
    public static List<OffensivePhilosophy> GetOffensivePhilosophies()
    {
        return offensivePhilosophies;
    }
}
[Serializable]
public class DefensivePhilosophy
{
   
    public DefensivePhilosophy()
    {
    }
    public static List<DefensivePhilosophy> GetPhilosophies()
    {
        return PhilosophyHolder.GetDefensivePhilosophies();
    }
    public abstract DefensivePlay PickPlay(int scoreDiff, int quarterNum, int timeLeft);
}
[Serializable]
public class ManSwitch : DefensivePhilosophy
{
    public ManSwitch()
    {

    }
    public override string ToString()
    {
 	    return "Man Switch";
    }
    public override DefensivePlay PickPlay(int scoreDiff, int quarterNum, int timeLeft)
    {
        return DefensivePlay.MAN_SWITCH;
    }
}
[Serializable]
public class ManNoSwitch : DefensivePhilosophy
{
    public ManNoSwitch()
    {

    }
    public override string ToString()
    {
 	    return "Man No Switch";
    }
}
[Serializable]
public class OffensivePlay
{
    public OffensivePlay()
    {

    }
}
[Serializable]
public enum DefensivePlay
{
    MAN_SWITCH, MAN_NO_SWITCH, MAN_DOUBLE_BALL
}