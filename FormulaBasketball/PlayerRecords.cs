using System;
using System.Collections.Generic;
using System.IO;
[Serializable]
public class PlayerRecords
{
    private int tripleDoubles, doubleDoubles;
    private int careerTripleDoubles, careerDoubleDoubles;
    private Dictionary<String, RecordHolder> records;
    private string playerName;
    public PlayerRecords(string playerName)
    {
        this.playerName = playerName;
        records = new Dictionary<string, RecordHolder>();
        records.Add("Points", new RecordHolder(0, 0, null, "points"));
        records.Add("Rebounds", new RecordHolder(0, 0, null, "rebounds"));
        records.Add("Assists", new RecordHolder(0, 0, null, "assists"));
    }
    public void CheckRecords(player player, int gameNum, string opposingTeam)
    {
        int assists = player.getGameAssists();
        int points = player.getGamePoints();
        int rebounds = player.getGameRebounds();

        int count = 0;
        if (assists >= 10) count++;
        if (rebounds >= 10) count++;
        if (points >= 10) count++;

        if (count == 3) tripleDoubles++;
        else if (count == 2) doubleDoubles++;

        if (records["Points"].GetStat() < points) records["Points"].UpdateValues(points, gameNum, playerName, opposingTeam);
        if (records["Rebounds"].GetStat() < rebounds) records["Rebounds"].UpdateValues(rebounds, gameNum, playerName, opposingTeam);
        if (records["Assists"].GetStat() < assists) records["Assists"].UpdateValues(assists, gameNum, playerName, opposingTeam);

       

    }
    public void Print()
    {
        String fileName = playerName.Replace(" ", "") + "SeasonStats.txt";
        String content = playerName + " Stats\n";
        content += "Player Record of Points: " + records["Points"].ToString();
        content += "Player Record of Assists: " + records["Assists"].ToString();
        content += "Player Record of Rebounds: " + records["Rebounds"].ToString();
        content += "This season, " + playerName + " had " + doubleDoubles + " double doubles.";
        content += "This season, " + playerName + " had " + tripleDoubles + " triple doubles.";

        File.WriteAllText(fileName, content);
    }
}