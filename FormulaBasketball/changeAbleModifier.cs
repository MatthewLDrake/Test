
public class changeAbleModifier : Modifier
{
    private double shootingModifier, defenseModifier;
    public changeAbleModifier(double shootingModifier, double defenseModifier)
    {
        this.shootingModifier = shootingModifier;
        this.defenseModifier = defenseModifier;
    }

    public double getShootingModifier()
    {
        return shootingModifier;
    }


    public double getDefenseModifier()
    {
        return defenseModifier;
    }


    public double getOtherModifier()
    {
        return 0;
    }

}
