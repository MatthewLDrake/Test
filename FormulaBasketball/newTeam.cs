using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class NewTeam : IEnumerable<NewPlayer>, IComparable<NewTeam>
    {
        private List<NewPlayer> players;
        private NewCoach coach;
        private sbyte teamNum;
        private String teamName;
        private byte playoffSeed, wins, losses;
        private int pointsFor, pointsAgainst;
        private List<NewDraftPick> currentSeasonPicks, nextSeasonPicks;
        public NewTeam(team oldStyle)
        {
            teamNum = (sbyte)oldStyle.getTeamNum();
            teamName = oldStyle.ToString();

            players = new List<NewPlayer>();
            foreach(player p in oldStyle)
            {
                players.Add(new NewPlayer(p));
                players[players.Count - 1].SetTeam(teamNum);
            }
            coach = new NewCoach(oldStyle.ToString() + " Coach", new BalancedOffense(), new BalancedDefense(), new OverallPersonnel());
            //coach = new NewCoach(oldStyle.getCoach());


            if(oldStyle.moreImportantTeam)
            {
                currentSeasonPicks = new List<NewDraftPick>();
                nextSeasonPicks = new List<NewDraftPick>();
                foreach (DraftPick pick in oldStyle.GetPicks())
                {
                    currentSeasonPicks.Add(new NewDraftPick(9, (byte)pick.GetRound(), (byte)pick.FromTeam(), (byte)teamNum));
                }
                foreach (DraftPick pick in oldStyle.GetNextSeasonPicks())
                {
                    nextSeasonPicks.Add(new NewDraftPick(10, (byte)pick.GetRound(), (byte)pick.FromTeam(), (byte)teamNum));
                }
            }
            
        }
        public List<NewDraftPick> GetCurrentPicks()
        {
            return currentSeasonPicks;
        }
        public List<NewDraftPick> GetNextPicks()
        {
            return nextSeasonPicks;
        }
        
        public sbyte GetTeamNum()
        {
            return teamNum;
        }
        public void SetCoach(NewCoach coach)
        {
            this.coach = coach;
        }
        public NewCoach GetCoach()
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
        public void SetSeed(int seed)
        {
            playoffSeed = (byte)seed;
        }
        public int GetSeed()
        {
            return playoffSeed;
        }

        public int CompareTo(NewTeam other)
        {
            if(wins == other.wins)
            {
                if((pointsFor - pointsAgainst) == (other.pointsFor - other.pointsAgainst))
                {
                    return other.teamNum - teamNum;
                }
                return (other.pointsFor - other.pointsAgainst) - (pointsFor - pointsAgainst);
            }
            return other.wins - wins;
        }
        public void FinishGame(int score, int opponentScore, sbyte opposingTeam, bool playoffs)
        {
            if (!playoffs)
            {
                // TODO: TEAM SPECIFIC STATS
                pointsFor += score;
                pointsAgainst += opponentScore;

                wins += (byte)(score > opponentScore ? 1 : 0);
                losses += (byte)(score < opponentScore ? 1 : 0);
            }
            foreach(NewPlayer p in this)
            {
                p.EndGame();                
            }
        }
        private int seasons, places, championships, mostWins, leastWins = int.MaxValue, topResult, worstResult, totalWins;
        public int GetBestPlace()
        {
            return mostWins;
        }
        public int GetWorstPlace()
        {
            return leastWins;
        }
        public int GetChampionships()
        {
            return championships;
        }
        public void PrintInfo(string eventName)
        {
            int averageWins = totalWins / seasons;
            string record = averageWins + "-" + (84 - averageWins);
            Console.WriteLine("event:" + eventName + ":In 1000 simulations, the " + teamName + " won " + championships + " championships, and ended with an average regular season record of " + record + ".");

            record = mostWins + "-" + (84 - mostWins);

            Console.WriteLine("event:" + eventName + ":Their best season was a  " + record + " campaign, which ended in " + topResult + " place.");

            record = leastWins + "-" + (84 - leastWins);

            Console.WriteLine("event:" + eventName + ":Their worst season was a  " + record + " campaign, which ended in " + worstResult + " place.");
        }
        public void EndPlayoffs(int endPlace)
        {
            if (endPlace == 1)
                championships++;

            if (wins > mostWins || (wins == mostWins && endPlace < topResult))
            {
                mostWins = wins;
                topResult = endPlace;
            }

            if (wins < leastWins || (wins == leastWins && endPlace > worstResult))
            {
                leastWins = wins;
                worstResult = endPlace;
            }

            totalWins += wins;

            wins = 0;
            losses = 0;
            pointsAgainst = 0;
            pointsFor = 0;

            seasons++;
            places += endPlace;
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
    [Serializable]
    public class NewDraftPick
    {
        private byte season, round, team, owner;
        public NewDraftPick(byte season, byte round, byte team, byte owner)
        {
            this.season = season;
            this.round = round;
            this.team = team;
            this.owner = owner;
        }
        public int GetSeason()
        {
            return season;
        }
        public int GetRound()
        {
            return round;
        }
        public int GetTeam()
        {
            return team;
        }
        public int GetOwner()
        {
            return owner;
        }
    }
}
