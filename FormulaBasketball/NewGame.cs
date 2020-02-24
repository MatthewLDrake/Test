using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NewGame
{
    private NewCurrentTeam awayTeam, homeTeam;
    private Random r;
    private List<byte[]> scores;
    private byte[] currentQuarterScore;
    private int timeLeft;
    private bool awayTipOff;
    public NewGame(team awayTeam, team homeTeam, Random r)
    {
        this.awayTeam = new NewCurrentTeam(awayTeam);
        this.homeTeam = new NewCurrentTeam(homeTeam);
        this.r = r;
        StartGame();
    }
    public int GetAwayTeamScore()
    {
        int totalScore = 0;
        foreach(byte[] arr in scores)
        {
            totalScore += arr[0];
        }
        return totalScore;
    }
    public int GetHomeTeamScore()
    {
        int totalScore = 0;
        foreach (byte[] arr in scores)
        {
            totalScore += arr[1];
        }
        return totalScore;
    }
    private void StartGame()
    {
        /*
        awayTipOff = TipOff();
        // 60 * 12
        timeLeft = 720;
        scores.Add(PlayQuarter(awayTipOff));
        timeLeft = 720;
        scores.Add(PlayQuarter());
        timeLeft = 720;
        scores.Add(PlayQuarter());
        timeLeft = 720;
        scores.Add(PlayQuarter());

        while(GetAwayTeamScore() == GetHomeTeamScore())
        {
            timeLeft = 300;
            PlayQuarter();
        }
        */
    }
    private byte[] PlayQuarter()
    {
        currentQuarterScore = new byte[2];



        return currentQuarterScore;
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
        currentPlayers = team.getActivePlayers().Take(5).ToArray();

    }
    public player[] GetCurrentPlayers()
    {
        return currentPlayers;
    }
}

