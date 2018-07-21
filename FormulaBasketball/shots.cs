using System;

public class shots
{
    private double shotSkill, defenseSkill;
    private bool madeShotBool, wasFouledBool;
    private int pointsScored;
    private ShotType typeOfShot;
    private FormulaBasketball.Random r;
    public shots(int variation, double shotType, double d, ShotType shot, FormulaBasketball.Random r)
    {
        this.r = r;
        typeOfShot = shot;
        this.shotSkill = shotType;
        this.defenseSkill = d;
        madeShotBool = false;
        wasFouledBool = false;
        pointsScored = 0;

        switch (typeOfShot)
        {
            case ShotType.FREE:
                if (variation == 4) takeFreeThrows(2);
                else if (variation == 5) takeFreeThrows(3);
                else if (variation == 6) takeFreeThrows(1);
                break;
            case ShotType.THREE:
                if (variation == 1) takeOpenShot(50);
                else if (variation == 2) takeMildlyContestedShot(30);
                else if (variation == 3) takeSmotheredShot(20);
                break;
            case ShotType.JUMP:
                if (variation == 1) takeOpenShot(55);
                else if (variation == 2) takeMildlyContestedShot(35);
                else if (variation == 3) takeSmotheredShot(20);
                break;
            case ShotType.LAYUP:
                if (variation == 1) takeOpenShot(70);
                else if (variation == 2) takeMildlyContestedShot(35);
                else if (variation == 3) takeSmotheredShot(20);
                break;
            case ShotType.DUNK:
                if (variation == 1) takeOpenShot(75);
                else if (variation == 2) takeMildlyContestedShot(40);
                else if (variation == 3) takeSmotheredShot(15);
                break;
        }
        //takeShot();
    }
    private void takeFreeThrows(int i)
    {
        double temp = shotSkill;
        

        for (int j = 0; j < i; j++)
        {
            double temp2 = r.Next(0,15) + temp - 3.5;

            if (temp2 > 6) pointsScored++;
        }

    }
    public int getPointsScored()
    {
        return pointsScored;
    }
    private void takeOpenShot(int percent)
    {
        double temp = shotSkill;

        
        double num = percent + (r.Next(0,5) - 2);
        temp -= 6;
        num = num + (temp);
        double temp2 = r.Next(0,105);

        if (temp2 < num) madeShotBool = true;
    }
    private void takeMildlyContestedShot(int percent)
    {
        double temp = shotSkill - defenseSkill;

        
        double num = percent + (r.Next(0,5) - 2);
        num = num + (temp);
        double temp2 = r.Next(0,105);
        //Console.WriteLine(temp2);
        if (temp2 < num) madeShotBool = true;
        //if((Math.floor(temp2) == 3 && Math.round(temp2+.25) == 3) || (Math.floor(temp2) == 6 && Math.round(temp2+.4) == 6))
        if (temp2 < 35)
        {
            wasFouledBool = true;
        }
    }
    private void takeSmotheredShot(int percent)
    {
        double temp = shotSkill - (2 * defenseSkill);

        
        double num = percent + (r.Next(0,5) - 2);
        num = num + (temp);
        double temp2 = r.Next(0,105);

        if (temp2 < num) madeShotBool = true;
        //if((Math.floor(temp2) == 3 && Math.round(temp2+.25) == 3) || (Math.floor(temp2) == 6 && Math.round(temp2+.4) == 6))
        if (temp2 < 50)
        {
            wasFouledBool = true;
        }
    }
    public bool madeShot()
    {
        return madeShotBool;
    }
    public bool wasFouled()
    {
        return wasFouledBool;
    }


}
