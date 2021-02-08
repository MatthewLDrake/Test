using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    [Serializable]
    public class GameStats
    {
        private int team, opponent;
        private byte minutes, fouls;
        private byte fieldGoalsAttempted, fieldGoalsMade, threesAttempted, threesMade, freeThrowsAttempted, freeThrowsMade, points;
        private byte offensiveRebounds, defensiveRebounds;
        private byte assists, steals, blocks, turnovers;
        private byte defensiveFieldGoalsAttempted, defensiveFieldGoalsMade, defensiveThreesMade, defensiveThreesAgainst;
        public GameStats(int team, int opponent)
        {
            this.team = team;
            this.opponent = opponent;
        }
#region Add Stats
        public void AddMinutes(int minutes)
        {
            this.minutes += (byte)minutes;
        }        
        public void AddThreeMade()
        {
            AddThreeAttempted();
            threesMade++;
            fieldGoalsMade++;

            points += 3;
        }
        public void AddThreeAttempted()
        {
            threesAttempted++;
            fieldGoalsAttempted++;
        }
        public void AddFieldGoalMade()
        {
            AddFieldGoalAttempted();
            fieldGoalsMade++;

            points += 2;
        }
        public void AddFieldGoalAttemptedAgainst()
        {
            defensiveFieldGoalsAttempted++;
        }
        public void AddFieldGoalMadeAgainst()
        {
            defensiveFieldGoalsAttempted++;
            defensiveFieldGoalsMade++;
        }
        public void AddThreePointerAgainst()
        {
            defensiveFieldGoalsAttempted++;
            defensiveThreesAgainst++;
        }
        public void AddThreeMadeAgainst()
        {
            AddThreePointerAgainst();
            defensiveThreesMade++;
            defensiveFieldGoalsMade++;
        }
        public void AddFieldGoalAttempted()
        {
            fieldGoalsAttempted++;
        }
        public void AddFreeThrows(int attempted, int made)
        {
            freeThrowsAttempted += (byte)attempted;
            freeThrowsMade += (byte)made;

            points += (byte)made;
        }
        public void AddOffensiveRebound()
        {
            offensiveRebounds++;
        }
        public void AddDefensiveRebound()
        {
            defensiveRebounds++;
        }
        public void AddAssist()
        {
            assists++;
        }
        public void AddSteal()
        {
            steals++;
        }
        public void AddTurnover()
        {
            turnovers++;
        }
        public void AddBlock()
        {
            blocks++;
        }
        public void AddFoul()
        {
            fouls++;
        }
        public void AddFouls(byte fouls)
        {
            this.fouls += fouls;
        }
#endregion
        #region Get Stats
        public bool DidPlay()
        {
            return minutes > 0;
        }
        public int GetShotsMadeAgainst()
        {
            return defensiveFieldGoalsMade;
        }
        public int GetShotsAgainst()
        {
            return defensiveFieldGoalsAttempted;
        }
        public int GetMinutes()
        {
            return minutes;
        }
        public int GetPoints()
        {
            return points;
        }
        public int GetFieldGoalsAttempted()
        {
            return fieldGoalsAttempted;
        }
        public int GetFieldGoalsMade()
        {
            return fieldGoalsMade;
        }
        public int GetThreePointsMade()
        {
            return threesMade;
        }
        public int GetThreePointsAttempted()
        {
            return threesAttempted;
        }
        public int GetFreeThrowsMade()
        {
            return freeThrowsMade;
        }
        public int GetFreeThrowsAttempted()
        {
            return freeThrowsAttempted;
        }
        public int GetRebounds()
        {
            return offensiveRebounds + defensiveRebounds;
        }
        public int GetDefensiveRebounds()
        {
            return defensiveRebounds;
        }
        public int GetOffensiveRebounds()
        {
            return offensiveRebounds;
        }
        public int GetAssists()
        {
            return assists;
        }
        public int GetSteals()
        {
            return steals;
        }
        public int GetTurnovers()
        {
            return turnovers;
        }
        public int GetBlocks()
        {
            return blocks;
        }
        public int GetFouls()
        {
            return fouls;
        }

        #endregion

    }
}
