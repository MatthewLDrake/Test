using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
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
        }
        public List<NewPlayer> GetAllPlayers()
        {
            return players;
        }
    }
}
