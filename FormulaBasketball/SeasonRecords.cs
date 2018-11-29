using System;
using System.Collections.Generic;
using System.IO;
[Serializable]
public class SeasonRecords
{
    private Dictionary<String, RecordHolder> records;
    private string teamName;
    private team team;
    public SeasonRecords(team team)
    {
        records = new Dictionary<string, RecordHolder>();
        records.Add("Points", new RecordHolder(0, 0, null, "points"));
        records.Add("Rebounds", new RecordHolder(0, 0, null, "rebounds"));
        records.Add("Assists", new RecordHolder(0, 0, null, "assists"));
        records.Add("Team Points", new RecordHolder(0, 0, teamName, "points"));
        records.Add("Least Team Points", new RecordHolder(int.MaxValue, 0, teamName, "points"));
        records.Add("Opponent Points", new RecordHolder(int.MaxValue, 0, teamName, "points"));
        records.Add("Most Opponent Points", new RecordHolder(0, 0, teamName, "points"));
        teamName = team.ToString();
        this.team = team;
    }

    public void Update(player[] activePlayers, int teamPoints, int opponentPoints, string teamAgainst, int gameNum)
    {
        if(records["Team Points"].GetStat() < teamPoints)
        {
            records["Team Points"].UpdateValues(teamPoints, gameNum, teamName, teamAgainst);
        }
        if (records["Least Team Points"].GetStat() > teamPoints)
        {
            records["Least Team Points"].UpdateValues(teamPoints, gameNum, teamName, teamAgainst);
        }
        if (records["Opponent Points"].GetStat() > opponentPoints)
        {
            records["Opponent Points"].UpdateValues(opponentPoints, gameNum, teamName, teamAgainst);
        }
        if (records["Most Opponent Points"].GetStat() < opponentPoints)
        {
            records["Most Opponent Points"].UpdateValues(opponentPoints, gameNum, teamName, teamAgainst);
        }
        int topForPlayers = 0;
        player currentTop = null;
        for (int i = 0; i < activePlayers.Length; i++)
        {
            if(activePlayers[i].getGamePoints() > topForPlayers)
            {
                currentTop = activePlayers[i];
                topForPlayers = currentTop.getGamePoints();
            }
        }

        if(records["Points"].GetStat() < topForPlayers)
        {
            records["Points"].UpdateValues(topForPlayers, gameNum, currentTop.getName(), teamAgainst);
        }

        topForPlayers = 0;
        currentTop = null;

        for (int i = 0; i < activePlayers.Length; i++)
        {
            if (activePlayers[i].getGameRebounds() > topForPlayers)
            {
                currentTop = activePlayers[i];
                topForPlayers = currentTop.getGameRebounds();
            }
        }

        if (records["Rebounds"].GetStat() < topForPlayers)
        {
            records["Rebounds"].UpdateValues(topForPlayers, gameNum, currentTop.getName(), teamAgainst);
        }

        topForPlayers = 0;
        currentTop = null;

        for (int i = 0; i < activePlayers.Length; i++)
        {
            if (activePlayers[i].getGameRebounds() > topForPlayers)
            {
                currentTop = activePlayers[i];
                topForPlayers = currentTop.getGameAssists();
            }
        }

        if (records["Assists"].GetStat() < topForPlayers)
        {
            records["Assists"].UpdateValues(topForPlayers, gameNum, currentTop.getName(), teamAgainst);
        }
    }
    public void Print(Record[] vsTeamRankings)
    {
        String fileName = teamName.Replace(" ", "") + "SeasonStats.txt";
        String content = teamName + " Stats\n";
        content += "Player Record of Points: " + records["Points"].ToString();
        content += "Player Record of Assists: " + records["Assists"].ToString();
        content += "Player Record of Rebounds: " + records["Rebounds"].ToString();
        content += "Team Record in Most Points Scored: " + records["Team Points"].ToString();
        content += "Team Record in Least Points Scored: " + records["Least Team Points"].ToString();
        content += "Team Record in Least Points Allowed: " + records["Opponent Points"].ToString();
        content += "Team Record in Most Points Allowed: " + records["Most Opponent Points"].ToString();

        if(teamName.Contains("Dotruga") || teamName.Contains("Solea"))
        {
            foreach(player p in team)
            {
                p.Print();
            }
        }
        content += "Records vs. Each Team this season:\n";
        for(int i= 0; i < formulaBasketball.create.size(); i++)
        {
            content += formulaBasketball.create.getTeam(i).ToString() + ": " + vsTeamRankings[i].GetWins() + "-" + vsTeamRankings[i].GetLosses() + "\n";
        }

        File.WriteAllText(fileName, content);
    }
}
[Serializable]
class RecordHolder
{
    private int stat, gameNum;
    private String playerName, statName, teamAgainst;
    public RecordHolder(int stat, int gameNum, String playerName, String statName)
    {
        this.stat = stat;
        this.gameNum = gameNum;
        this.playerName = playerName;
        this.statName = statName;
    }
    public void UpdateValues(int stat, int gameNum, String playerName, String teamAgainst)
    {
        this.stat = stat;
        this.gameNum = gameNum;
        this.playerName = playerName;
        this.teamAgainst = teamAgainst;
    }
    public int GetStat()
    {
        return stat;
    }
    public override string ToString()
    {

        return playerName + ": " + stat + " " + statName + " on game " + gameNum + " against the " + teamAgainst + "\n";
    }
}