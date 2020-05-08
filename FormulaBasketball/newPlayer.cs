using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class NewPlayer
    {
        private byte[] ratings;
        private byte seasonStarts;
        private byte team;
        private List<StatsHolders> seasonStats;
        private List<SeasonStatsHolder> playerCareerStats;
        public NewPlayer(player oldPlayer)
        {
            ratings = new byte[oldPlayer.ratings.Length];
            for(int i = 0; i < ratings.Length;i++)
            {
                ratings[i] = (byte)oldPlayer.ratings[i];
            }
            seasonStarts = 0;
            playerCareerStats = oldPlayer.GetCareerStats();
            if (playerCareerStats == null)
                playerCareerStats = new List<SeasonStatsHolder>();
            seasonStats = new List<StatsHolders>();
        }
        // To be called when the offseason is over.
        public void FinishOffseason()
        {
            seasonStarts = 0;
            playerCareerStats.Add(new SeasonStatsHolder(seasonStats));
            seasonStats = new List<StatsHolders>();
        }
        public void SetTeam(team team)
        {
            this.team = (byte)team.getTeamNum();
        }
        public void SetTeam(NewTeam team)
        {
            this.team = team.GetTeamNum();
        }
        public void SetTeam(int teamNum)
        {
            team = (byte)teamNum;
        }
        public team GetTeam(createTeams create)
        {
            return create.getTeam(team);
        }

        #region Ratings
        
        #endregion
    }
}
