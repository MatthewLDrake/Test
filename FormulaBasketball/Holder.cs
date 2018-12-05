using System;
using System.Collections.Generic;


namespace FormulaBasketball
{

    [Serializable]
    public class Holder
    {
        private int playersLeft;
        private List<CollegePlayer> players;
        private List<List<CollegePlayer>> playersByPos;

        public Holder(List<CollegePlayer> collegePlayers, FormulaBasketball.Random r)
        {
            players = collegePlayers;
            playersByPos = new List<List<CollegePlayer>>();
            playersLeft = 80;
            
            for (int i = 1; i <= 5; i++)
            {
                playersByPos.Add(new List<CollegePlayer>());
                for (int j = 0; j < players.Count; j++)
                {
                    if (players[j].GetPosition() == i)
                    {
                        playersByPos[i - 1].Add(players[j]);
                        players[j].Create(r);
                    }
                }
            }

        }
        public int GetNumLeft()
        {
            return playersLeft;
        }

        public List<CollegePlayer> GetPlayers(int pos)
        {
            return playersByPos[pos-1];
        }



        public CollegePlayer GetPlayer(int currList, int i, bool scouted = false)
        {
            if (playersLeft == 0 && scouted) return null;
            if (scouted) playersLeft--;
            return playersByPos[currList][i];
        }
    }
}
