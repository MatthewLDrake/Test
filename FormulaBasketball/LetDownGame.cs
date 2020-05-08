public class LetDownGame : Modifier
{
    public double getShootingModifier()
    {
        // TODO Auto-generated method stub
        return -.5;
    }
    
    public double getDefenseModifier()
    {
        // TODO Auto-generated method stub
        return -.5;
    }
    
    public double getOtherModifier()
    {
        // TODO Auto-generated method stub
        return -.5;
    }
}
public class TeamImplosion : Modifier
{
    public double getShootingModifier()
    {
        // TODO Auto-generated method stub
        return -1.5;
    }

    public double getDefenseModifier()
    {
        // TODO Auto-generated method stub
        return -1.5;
    }

    public double getOtherModifier()
    {
        // TODO Auto-generated method stub
        return -1.5;
    }
}
public class HotStreak : Modifier
{
    public double getShootingModifier()
    {
        // TODO Auto-generated method stub
        return 3;
    }

    public double getDefenseModifier()
    {
        // TODO Auto-generated method stub
        return 0;
    }

    public double getOtherModifier()
    {
        // TODO Auto-generated method stub
        return 2;
    }
}