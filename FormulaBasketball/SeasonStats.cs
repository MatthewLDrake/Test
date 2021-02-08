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
    }
}