using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    [Serializable]
    public class StatsHolders
    {
        private int[] stats;
        private string team, opponent;
        public StatsHolders(team team, int[] stats, team opponent)
        {
            this.team = team.ToString();
            this.stats = stats;
            this.opponent = opponent.ToString();
        }
        public int getPoints()
        {
            return stats[0];
        }
        public int getShotsTaken()
        {
            return stats[1];
        }
        public int getShotsMade()
        {
            return stats[2];
        }
        public int getAssists()
        {
            return stats[3];
        }
        public int getTurnovers()
        {
            return stats[4];
        }
        public int getSteals()
        {
            return stats[5];
        }
        public int getMinutes()
        {
            return (int)Math.Round(stats[6] / 60.0);
        }
        public int getRebounds()
        {
            return stats[7];
        }
        public int getOffensiveRebounds()
        {
            return stats[8];
        }
        public int getDefensiveRebounds()
        {
            return stats[9];
        }
        public int getFouls()
        {
            return stats[10];
        }
        public int getThreesTaken()
        {
            return stats[11];
        }
        public int getFreeThrowsTaken()
        {
            return stats[12];
        }
        public int getFreeThrowsMade()
        {
            return stats[13];
        }
        public int getThreePointersMade()
        {
            return stats[14];
        }
        public int getShotsAttemptedAgainst()
        {
            return stats[15];
        }
        public int getShotsMadeAgainst()
        {
            return stats[16];
        }
    }
}
