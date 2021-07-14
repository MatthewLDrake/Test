using System;
using System.Collections.Generic;

namespace FormulaBasketball
{
    [Serializable]
    public class SeasonStats
    {
        private SeasonStatsHolder oldSystem;
        private List<GameStats> stats;
        public SeasonStats(SeasonStatsHolder oldSystem)
        {
            this.oldSystem = oldSystem;
        }
        public SeasonStats(List<GameStats> stats)
        {
            this.stats = stats;
        }
        public int gamesPlayed, gamesStarted, season;
        public double minutes, points, oRebounds, dRebounds, assists, steals, blocks, turnovers, fouls, plusMinus;
        public List<string> teamsPlayedFor;
        public SeasonStats(string stats, int season)
        {
            string[] arr = stats.Split(',');

            gamesPlayed = int.Parse(arr[2]);
            gamesStarted = int.Parse(arr[3]);

            minutes = double.Parse(arr[4]);
            points = double.Parse(arr[5]);
            oRebounds = double.Parse(arr[6]);
            dRebounds = double.Parse(arr[7]);
            assists = double.Parse(arr[8]);
            steals = double.Parse(arr[9]);
            blocks = double.Parse(arr[10]);
            turnovers = double.Parse(arr[11]);
            fouls = double.Parse(arr[12]);
            plusMinus = double.Parse(arr[13]);

            this.season = season;
        }        
    }
}