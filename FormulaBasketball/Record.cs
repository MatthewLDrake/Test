using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[Serializable]
public class Record
{
    private int wins, losses;
    public Record(int wins = 0, int losses = 0)
    {
        this.wins = wins;
        this.losses = losses;
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
}

