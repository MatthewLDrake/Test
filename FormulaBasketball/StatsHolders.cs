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
        private byte[] smallStats;
        private string team, opponent;
        public StatsHolders(team team, byte[] stats, team opponent)
        {
            this.team = team.ToString();
            this.smallStats = stats;
            this.opponent = opponent.ToString();
        }
        public int getPoints()
        {
            return smallStats[0];
        }
        public int getShotsTaken()
        {
            return smallStats[1];
        }
        public int getShotsMade()
        {
            return smallStats[2];
        }
        public int getAssists()
        {
            return smallStats[3];
        }
        public int getTurnovers()
        {
            return smallStats[4];
        }
        public int getSteals()
        {
            return smallStats[5];
        }
        public int getMinutes()
        {
            return smallStats[6];
        }
        public int getRebounds()
        {
            return smallStats[7];
        }
        public int getOffensiveRebounds()
        {
            return smallStats[8];
        }
        public int getDefensiveRebounds()
        {
            return smallStats[9];
        }
        public int getFouls()
        {
            return smallStats[10];
        }
        public int getThreesTaken()
        {
            return smallStats[11];
        }
        public int getFreeThrowsTaken()
        {
            return smallStats[12];
        }
        public int getFreeThrowsMade()
        {
            return smallStats[13];
        }
        public int getThreePointersMade()
        {
            return smallStats[14];
        }
        public int getShotsAttemptedAgainst()
        {
            return smallStats[15];
        }
        public int getShotsMadeAgainst()
        {
            return smallStats[16];
        }
        public string GetTeamFor()
        {
            return team;
        }
        public string GetTeamAgainst()
        {
            return opponent;
        }
        
    }
}
