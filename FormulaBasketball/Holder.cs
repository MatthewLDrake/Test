using System;
using System.Collections.Generic;


namespace FormulaBasketball
{

    [Serializable]
    public class Holder
    {
        private int playersLeft;
        private List<player> players;
        private List<List<player>> playersByPos;
        private Dictionary<int, player> player;
        private int scoutSkill;
        private FormulaBasketball.Random r;
        public Holder(List<player> collegePlayers, Scout scout, FormulaBasketball.Random r)
        {
            players = collegePlayers;
            playersByPos = new List<List<player>>();
            playersLeft = scout.GetNumPlayers();
            this.scoutSkill = scout.GetScoutSkill();
            this.r = r;
            player = new Dictionary<int,player>();
            
            for (int i = 1; i <= 5; i++)
            {
                playersByPos.Add(new List<player>());
                for (int j = 0; j < players.Count; j++)
                {
                    if (players[j].getPosition() == i)
                    {
                        playersByPos[i - 1].Add(players[j]);
                        players[j].Scout(r, scoutSkill);
                        player.Add(players[j].GetPlayerID(), players[j]);
                    }
                }
            }

        }
        public int GetNumLeft()
        {
            return playersLeft;
        }

        public List<player> GetPlayers(int pos)
        {
            return playersByPos[pos-1];
        }
        public player GetPlayer(int playerID)
        {
            return player[playerID];
        }


        public player GetPlayer(int currList, int i, bool scouted = false)
        {
            if (playersLeft == 0 && scouted) return null;
            if (scouted) playersLeft--;
            return playersByPos[currList][i];
        }

        
        

    }
}
