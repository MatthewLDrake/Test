using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    [Serializable]
    public class NewFreeAgents
    {
        private List<NewPlayer> players;
        public NewFreeAgents()
        {
            players = new List<NewPlayer>();
        }
        public void Add(NewPlayer player)
        {
            players.Add(player);
            player.SetTeam(-1);
        }
        public void Add(List<NewPlayer> players)
        {
            foreach (NewPlayer p in players)
                Add(p);
        }
        public List<NewPlayer> GetAllPlayers()
        {
            return players;
        }
        public void RemovePlayer(NewPlayer player)
        {
            foreach (NewPlayer p in players)
            {
                if(p.GetPlayerID() == player.GetPlayerID())
                {
                    players.Remove(p);
                    break;
                }
            }
        }
        public List<NewPlayer> GetPlayersByPos(int pos)
        {
            List<NewPlayer> retVal = new List<NewPlayer>();
            foreach(NewPlayer p in players)
            {
                if (p.GetPosition() == pos)
                    retVal.Add(p);
            }

            return retVal;
        }
        public void Clear()
        {
            players = new List<NewPlayer>();
        }
    }
}
