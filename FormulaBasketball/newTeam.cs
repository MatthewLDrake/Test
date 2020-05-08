using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class NewTeam
    {
        private List<NewPlayer> players;
        private Coach coach;
        private byte teamNum;
        public NewTeam(team oldStyle)
        {
            foreach(player p in oldStyle)
            {
                players.Add(new NewPlayer(p));
            }
            coach = oldStyle.getCoach();
            teamNum = (byte)oldStyle.getTeamNum();
        }
        public byte GetTeamNum()
        {
            return teamNum;
        }
        public void SetCoach(Coach coach)
        {
            this.coach = coach;
        }
        public Coach GetCoach()
        {
            return coach;
        }
        public List<NewPlayer> GetPlayers()
        {
            return players;
        }



    }
}
