using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NewGame
{
    private NewCurrentTeam awayTeam, homeTeam;
    private Random r;
    public NewGame(team awayTeam, team homeTeam, Random r)
    {
        this.awayTeam = new NewCurrentTeam(awayTeam);
        this.homeTeam = new NewCurrentTeam(homeTeam);
        this.r = r;
    }
}
class NewCurrentTeam
{
    private player[] currentPlayers;
    private Coach coach;
    private team team;
    public NewCurrentTeam(team team)
    {
        this.team = team;
        coach = team.getCoach();
    }
            
}

