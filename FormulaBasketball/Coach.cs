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
    /*private OffensivePhilosophy offensivePhilosophy;
    private DefensivePhilosophy defensivePhilosophy;
    // New style of coach
    public Coach(string name, OffensivePhilosophy offense, DefensivePhilosophy defense, FormulaBasketball.Random r)
    {
        this.name = name;
        offensivePhilosophy = offense;
        defensivePhilosophy = defense;
        this.r = r;
    }*/


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
        return null;
        //return offensivePhilosophy.PickPlay(scoreDiff, quarterNum, timeLeft);
    }
    public DefensivePlay GetDefensivePlay(int scoreDiff, int quarterNum, int timeLeft)
    {
        return DefensivePlay.MAN_NO_SWITCH;
        //return defensivePhilosophy.PickPlay(scoreDiff, quarterNum, timeLeft);
    }
}
[Serializable]
public class OffensivePhilosophy
{
    
    public OffensivePhilosophy()
    {
    }
    public static List<OffensivePhilosophy> GetPhilosophies()
    {
        return PhilosophyHolder.GetOffensivePhilosophies();
    }
    public virtual OffensivePlay PickPlay(int scoreDiff, int quarterNum, int timeLeft)
    {
        return null;
    }
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
    public override OffensivePlay PickPlay(int scoreDiff, int quarterNum, int timeLeft)
    {
        return null;
    }
}
public class PhilosophyHolder
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
    public virtual DefensivePlay PickPlay(int scoreDiff, int quarterNum, int timeLeft)
    {
        return DefensivePlay.MAN_NO_SWITCH;
    }
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
    public override DefensivePlay PickPlay(int scoreDiff, int quarterNum, int timeLeft)
    {
        return DefensivePlay.MAN_NO_SWITCH;
    }
}
[Serializable]
public class OffensivePlay
{
    public OffensivePlay()
    {

    }
    public virtual OffensivePlayerOnCourt[] GetPlayers(FormulaBasketball.NewCurrentTeam team)
    {
        return null;
    }
}
[Serializable]
public class OffensivePlayerOnCourt
{
    private player p;
    private bool hasBall;
    private Location location;
    public OffensivePlayerOnCourt(player p, Boolean hasBall, Location location)
    {
        this.p = p;
        this.hasBall = hasBall;
        this.location = location;
    }
    public player GetPlayer()
    {
        return p;
    }
    public void SetHasBall(bool hasBall)
    {
        this.hasBall = hasBall;
    }
    public bool GetHasBall()
    {
        return hasBall;
    }
    public void SetLocation(Location newLocation)
    {
        location = newLocation;
    }
    public Location GetLocation()
    {
        return location;
    }
}
public class DefensivePlayerOnCourt
{
    private player p;
    private int assignment, proximity;
    private Location location;
    public DefensivePlayerOnCourt(player p, int assignment, Location location, int proximity)
    {
        this.p = p;
        this.assignment = assignment;
        this.location = location;
        this.proximity = proximity;
    }

}
[Serializable]
public enum Location
{
    LEFT_OUTER_CORNER, RIGHT_OUTER_CORNER, FREE_THROW_CIRCLE, TOP_OF_KEY, RIGHT_OF_KEY, LEFT_OF_KEY, PAINT, LEFT_BASKET, RIGHT_BASKET, 
}
[Serializable]
public enum DefensivePlay
{
    MAN_SWITCH, MAN_NO_SWITCH, MAN_DOUBLE_BALL
}