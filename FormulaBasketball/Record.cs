using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[Serializable]
public class Record
{
    private int wins, losses;
    private bool dLeague;
    public Record(int wins = 0, int losses = 0, bool dLeague = false)
    {
        this.wins = wins;
        this.losses = losses;
        this.dLeague = dLeague;
    }

    public Record(string p1, string p2)
    {
        wins = int.Parse(p1);
        losses = int.Parse(p2);
    }
    public void AddWins(int newWins = 1)
    {
        wins += newWins;
    }
    public void AddLosses(int newLosses = 1)
    {
        losses += newLosses;
    }
    public int GetWins()
    {
        return wins;
    }
    public int GetLosses()
    {
        return losses;
    }
    public int GetTotalGames()
    {
        return wins + losses;
    }
    public bool GetDLeague()
    {
        return dLeague;
    }
}

