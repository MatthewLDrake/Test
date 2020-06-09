using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class NewTeam : IEnumerable<NewPlayer>
    {
        private List<NewPlayer> players;
        private Coach coach;
        private byte teamNum;
        private String teamName;
        public NewTeam(team oldStyle)
        {
            players = new List<NewPlayer>();
            foreach(player p in oldStyle)
            {
                players.Add(new NewPlayer(p));
            }
            coach = oldStyle.getCoach();
            teamNum = (byte)oldStyle.getTeamNum();
            teamName = oldStyle.ToString();
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
        public IEnumerator<NewPlayer> GetEnumerator()
        {
            return new PlayerEnum(players);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public override string ToString()
        {
            return teamName;
        }

    }
    [Serializable]
    class PlayerEnum : IEnumerator<NewPlayer>
    {
        private List<NewPlayer> players;
        private int location = -1;
        public PlayerEnum(List<NewPlayer> players)
        {
            this.players = players;
        }

        public NewPlayer Current
        {
            get
            {
                try
                {

                    return players[location];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current { get { return Current; } }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            location++;
            while (location < players.Count && players[location] == null) location++;
            return location < players.Count;
        }

        public void Reset()
        {
            location = -1;
        }
    }
}
