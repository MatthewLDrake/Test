using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class NewPlayer
    {
        /*
     * Ratings: 
     * 
     * ratings[0] = layup
     * ratings[1] = dunk
     * ratings[2] = jumpshot
     * ratings[3] = shot contest
     * ratings[4] = defense iq
     * ratings[5] = jumping
     * ratings[6] = seperation
     * ratings[7] = passing
     * ratings[8] = stamina
     * ratings[9] = threepoint
     * ratings[10] = durability
     */
        private byte[] ratings;
        private byte seasonStarts;
        private byte team;
        private List<StatsHolders> seasonStats;
        private List<SeasonStatsHolder> playerCareerStats;
        private String name;
        public NewPlayer(player oldPlayer)
        {
            ratings = new byte[oldPlayer.ratings.Length];
            for(int i = 0; i < ratings.Length;i++)
            {
                ratings[i] = (byte)oldPlayer.ratings[i];
            }
            name = oldPlayer.getName();
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
        public override string ToString()
        {
            return name;
        }
        #region Ratings
        public double GetLayupRating(bool game, bool clutchSituation)
        {
            return ratings[0];
        }
        public double GetJumpShotRating(bool game, bool clutchSituation)
        {
            return ratings[2];
        }
        public double GetShotContestRating(bool game, bool clutchSituation)
        {
            return ratings[3];
        }
        public double GetThreePointRating(bool game, bool clutchSituation)
        {
            return ratings[9];
        }
        #endregion
    }
}
