using System;

public class CollegeTeam : team
{
    private Country country;
    private FormulaBasketball.Random r;
    public CollegeTeam(String teamName, String threeLetter, FormulaBasketball.Random r, Country country) : base(teamName, threeLetter, r)
    {
        this.country = country;
        this.r = r;
    }
    public void FillTeam()
    {
        while (getNumberPlayers() < 15)
        {
            player player = null;

            if (getNumPlayersByPos(1) < 3) player = GenerateCenter();
            else if (getNumPlayersByPos(2) < 3) player = GeneratePowerForward();
            else if (getNumPlayersByPos(3) < 3) player = GenerateSmallForward();
            else if (getNumPlayersByPos(4) < 3) player = GenerateShootingGuard();
            else if (getNumPlayersByPos(5) < 3) player = GeneratePointGuard();


            addPlayer(player);
        }
        GenerateCoach();
    }
    public void GenerateCoach()
    {
        int staminaSubOut = r.Next(70, 85);
        addCoach(new Coach("Coach", staminaSubOut, staminaSubOut + r.Next(5, 15), r.NextDouble() * 2 - 1, r.Next(0, 50), r.NextDouble() * 2 - 1, r.Next(0, 50), new Tempo(r.Next(0, 2)), coachShotType.BALANCED, ssInvolvment.MEDIUM, r));
    }
    public player GenerateCenter()
    {
        return new player(1, r.Next(3, 6), r.Next(2, 5), r.Next(1, 3), r.Next(1, 2), r.Next(1, 2), r.Next(3, 5), r.Next(3, 5), r.Next(4, 6), r.Next(2, 4), r.Next(1, 10), r.Next(5, 10), "Center", false); 
    }
    public player GeneratePowerForward()
    {
        return new player(2, r.Next(3, 6), r.Next(1, 4), r.Next(2, 4), r.Next(1, 2), r.Next(1, 2), r.Next(3, 5), r.Next(3, 5), r.Next(4, 6), r.Next(2, 4), r.Next(1, 10), r.Next(5, 10), "Power Forward", false);
    }
    public player GenerateSmallForward()
    {
        if(r.NextBool()) return new player(3, r.Next(3, 6), r.Next(1, 4), r.Next(2, 4), r.Next(3, 5), r.Next(1, 2), r.Next(3, 5), r.Next(3, 5), r.Next(4, 6), r.Next(2, 4), r.Next(1, 10), r.Next(5, 10), "Small Forward", false);
        else return new player(3, r.Next(2, 4), r.Next(1, 3), r.Next(3, 5), r.Next(3, 4), r.Next(3, 5), r.Next(3, 5), r.Next(3, 5), r.Next(1, 2), r.Next(3, 5), r.Next(1, 10), r.Next(5, 10), "Small Forward", false);
    }
    public player GenerateShootingGuard()
    {
        return new player(4, r.Next(2, 4), r.Next(1, 3), r.Next(4, 6), r.Next(3, 4), r.Next(3, 5), r.Next(3, 5), r.Next(3, 5), r.Next(1, 2), r.Next(3, 5), r.Next(1, 10), r.Next(5, 10), "Shooting Guard", false);
    }
    public player GeneratePointGuard()
    {
        return new player(5, r.Next(2, 4), r.Next(1, 3), r.Next(3, 5), r.Next(3, 4), r.Next(5, 7), r.Next(3, 5), r.Next(3, 5), r.Next(1, 2), r.Next(3, 5), r.Next(1, 10), r.Next(5, 10), "Point Guard", false);
    }

    public Country GetCountry()
    {
        return country;
    }
}