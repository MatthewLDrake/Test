using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    [Serializable]
    public class NewTeam : IEnumerable<NewPlayer>, IComparable<NewTeam>
    {
        private List<NewPlayer> players, activePlayers;
        private List<Tuple<NewPlayer, int, int>> sevenDayInjury, fifteenInjury;
        private List<Tuple<NewPlayer, int>> injuredPlayers, seasonInjury;
        private NewRealCoach realCoach;
        private sbyte teamNum, streak;
        private String teamName;
        private byte playoffSeed, wins, losses;
        private int pointsFor, pointsAgainst;
        private Dictionary<sbyte, Tuple<byte, byte, int, int>> teamDictionary;
        private List<NewDraftPick> currentSeasonPicks, nextSeasonPicks;
        private List<bool> lastTen;
        private List<Tuple<uint, int, List<Object>, List<Object>, string, string>> trades, offeredTrades;
        private long money;
        public NewTeam(team oldStyle)
        {
            teamNum = (sbyte)oldStyle.getTeamNum();
            teamName = oldStyle.ToString();

            players = new List<NewPlayer>();
            foreach (player p in oldStyle)
            {
                players.Add(new NewPlayer(p));
                players[players.Count - 1].SetTeam(teamNum);
            }
            //coach = new NewCoach(oldStyle.ToString() + " Coach", new BalancedOffense(), new BalancedDefense(), new OverallPersonnel());
            //coach = new NewCoach(oldStyle.getCoach());
            activePlayers = new List<NewPlayer>();
            sevenDayInjury = new List<Tuple<NewPlayer, int, int>>();
            fifteenInjury = new List<Tuple<NewPlayer, int, int>>();
            injuredPlayers = new List<Tuple<NewPlayer, int>>();
            seasonInjury = new List<Tuple<NewPlayer, int>>();

            if (oldStyle.moreImportantTeam)
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
            lastTen = new List<bool>();
        }
        public void AddPotentialTrade(Tuple<uint, int, List<Object>, List<Object>, string, string> trade)
        {
            if (trades == null)
                trades = new List<Tuple<uint, int, List<object>, List<object>, string, string>>();
            trades.Add(trade);
        }
        public void OfferTrade(Tuple<uint, int, List<Object>, List<Object>, string, string> trade)
        {
            if (offeredTrades == null)
                offeredTrades = new List<Tuple<uint, int, List<object>, List<object>, string, string>>();
            offeredTrades.Add(trade);
        }
        public bool RejectTrade(uint tradeID)
        {
            foreach (Tuple<uint, int, List<Object>, List<Object>, string, string> trade in offeredTrades)
            {
                if (trade.Item1 == tradeID)
                {
                    offeredTrades.Remove(trade);
                    return true;
                }
            }
            return false;
        }
        public bool CancelTrade(uint tradeID)
        {
            foreach (Tuple<uint, int, List<Object>, List<Object>, string, string> trade in trades)
            {
                if (trade.Item1 == tradeID)
                {
                    trades.Remove(trade);
                    return true;
                }
            }
            return false;
        }
        public void SetTeamNum(int teamNum)
        {
            this.teamNum = (sbyte)teamNum;
        }
        public Tuple<uint, int, List<Object>, List<Object>, string, string> GetOfferedTrade(uint tradeID)
        {
            foreach (Tuple<uint, int, List<Object>, List<Object>, string, string> trade in offeredTrades)
            {
                if (trade.Item1 == tradeID)
                    return trade;
            }

            return null;
        }
        public Tuple<uint, int, List<Object>, List<Object>, string, string> GetTrade(uint tradeID)
        {
            foreach(Tuple<uint, int, List<Object>, List<Object>, string, string> trade in trades)
            {
                if (trade.Item1 == tradeID)
                    return trade;
            }

            return null;
        }
        public void AddItems(List<Object> receiving, List<Object> sending)
        {
            foreach(Object obj in receiving)
            {
                if(obj is NewPlayer)
                {
                    AddPlayer(obj as NewPlayer);
                }
                else if(obj is double)
                {
                    money += (long)Math.Round((double)obj * 1000000);
                }
                else
                {
                    NewDraftPick pick = obj as NewDraftPick;
                    if (League.seasonNum + 1 == pick.GetSeason())
                        currentSeasonPicks.Add(pick);
                    else
                        nextSeasonPicks.Add(pick);

                    pick.SetOwner((byte)teamNum);
                }
            }
            foreach(Object obj in sending)
            {
                if (obj is NewPlayer)
                {
                    RemovePlayer(obj as NewPlayer);
                }
                else if (obj is double)
                {
                    money -= (long)Math.Round((double)obj * 1000000);
                }
                else
                {
                    NewDraftPick pick = obj as NewDraftPick;

                    foreach (NewDraftPick picks in currentSeasonPicks)
                    {
                        if (pick.GetSeason() == picks.GetSeason() && pick.GetRound() == picks.GetRound() && pick.GetTeam() == picks.GetTeam())
                        {
                            currentSeasonPicks.Remove(picks);
                            break;
                        }
                    }
                    foreach (NewDraftPick picks in nextSeasonPicks)
                    {
                        if (pick.GetSeason() == picks.GetSeason() && pick.GetRound() == picks.GetRound() && pick.GetTeam() == picks.GetTeam())
                        {
                            nextSeasonPicks.Remove(picks);
                            break;
                        }
                    }
                }
            }
        }
        public void AddCoach(NewRealCoach coach)
        {
            this.realCoach = coach;
        }
        public void UpdateTeam()
        {
            currentSeasonPicks = new List<NewDraftPick>();
            nextSeasonPicks = new List<NewDraftPick>();
        }
        public void AddDraftPick(NewDraftPick pick)
        {
            if (pick.GetSeason() == 10)
            {
                currentSeasonPicks.Add(pick);
            }
            else
                nextSeasonPicks.Add(pick);
        }
        public Tuple<int, int, string> GetInjuryStatus(NewPlayer p)
        {
            foreach (Tuple<NewPlayer, int, int> player in sevenDayInjury)
            {
                if (p.GetPlayerID() == player.Item1.GetPlayerID())
                {
                    return new Tuple<int, int, string>(player.Item2, player.Item3, "7 Day");
                }
            }
            foreach (Tuple<NewPlayer, int, int> player in fifteenInjury)
            {
                if (p.GetPlayerID() == player.Item1.GetPlayerID())
                {
                    return new Tuple<int, int, string>(player.Item2, player.Item3, "15 Day");
                }
            }
            foreach (Tuple<NewPlayer, int> player in seasonInjury)
            {
                if (p.GetPlayerID() == player.Item1.GetPlayerID())
                {
                    return new Tuple<int, int, string>(player.Item2, 0, "Season");
                }
            }
            foreach (Tuple<NewPlayer, int> player in injuredPlayers)
            {
                if (p.GetPlayerID() == player.Item1.GetPlayerID())
                {
                    return new Tuple<int, int, string>(player.Item2, 0, "Injured");
                }
            }

            return new Tuple<int, int, string>(0, 0, "Healthy");
        }
        public void AddInjury(NewPlayer p, int injuryLength)
        {
            if (injuryLength < 6)
                injuredPlayers.Add(new Tuple<NewPlayer, int>(p, injuryLength));
            else if (injuryLength < 13)
                sevenDayInjury.Add(new Tuple<NewPlayer, int, int>(p, injuryLength, 7));
            else if (injuryLength < 84)
                fifteenInjury.Add(new Tuple<NewPlayer, int, int>(p, injuryLength, 15));
            else
                seasonInjury.Add(new Tuple<NewPlayer, int>(p, injuryLength));

            activePlayers.Remove(p);
        }
        public void AdvanceInjuries()
        {
            List<NewPlayer> activePlayers = new List<NewPlayer>();
            List<Tuple<NewPlayer, int>> newInjuredPlayers = new List<Tuple<NewPlayer, int>>();
            List<Tuple<NewPlayer, int, int>> newSevenDay = new List<Tuple<NewPlayer, int, int>>();
            List<Tuple<NewPlayer, int, int>> newFifteenDay = new List<Tuple<NewPlayer, int, int>>();

            if(injuredPlayers == null)
            {
                injuredPlayers = new List<Tuple<NewPlayer, int>>();
                sevenDayInjury = new List<Tuple<NewPlayer, int, int>>();
                fifteenInjury = new List<Tuple<NewPlayer, int, int>>();
                seasonInjury = new List<Tuple<NewPlayer, int>>();
            }

            foreach (Tuple<NewPlayer, int> tuple in injuredPlayers)
            {
                if (tuple.Item2 <= 1)
                    activePlayers.Add(tuple.Item1);
                else
                    newInjuredPlayers.Add(new Tuple<NewPlayer, int>(tuple.Item1, tuple.Item2 - 1));
            }

            foreach(Tuple<NewPlayer, int, int> tuple in sevenDayInjury)
            {
                if (tuple.Item3 <= 1)
                {
                    if (tuple.Item2 <= 1)
                        activePlayers.Add(tuple.Item1);
                    else if (tuple.Item2 < 6)
                        newInjuredPlayers.Add(new Tuple<NewPlayer, int>(tuple.Item1, tuple.Item2 - 1));
                    else
                        newSevenDay.Add(new Tuple<NewPlayer, int, int>(tuple.Item1, tuple.Item2 - 1, 7));
                }
                else
                    newSevenDay.Add(new Tuple<NewPlayer,int, int>(tuple.Item1, tuple.Item2 - 1, tuple.Item3 - 1));
            }
            foreach (Tuple<NewPlayer, int, int> tuple in fifteenInjury)
            {
                if (tuple.Item3 <= 1)
                {
                    if (tuple.Item2 <= 1)
                        activePlayers.Add(tuple.Item1);
                    else if (tuple.Item2 < 6)
                        newInjuredPlayers.Add(new Tuple<NewPlayer, int>(tuple.Item1, tuple.Item2 - 1));
                    else if (tuple.Item2 < 13)
                        newSevenDay.Add(new Tuple<NewPlayer, int, int>(tuple.Item1, tuple.Item2 - 1, 7));
                    else
                        newFifteenDay.Add(new Tuple<NewPlayer, int, int>(tuple.Item1, tuple.Item2 - 1, 15));
                }
                else
                    newSevenDay.Add(new Tuple<NewPlayer, int, int>(tuple.Item1, tuple.Item2 - 1, tuple.Item3 - 1));
            }

            this.activePlayers = activePlayers;
            injuredPlayers = newInjuredPlayers;
            sevenDayInjury = newSevenDay;
            fifteenInjury = newFifteenDay;
        }
        public string ChangeOrder(int[] playerNums)
        {
            List<NewPlayer> newOrder = new List<NewPlayer>();

            foreach (int playerID in playerNums)
            {
                bool flag = false;
                foreach (NewPlayer p in players)
                {
                    if (p.GetPlayerID() == playerID)
                    {
                        newOrder.Add(p);
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    return "Couldn't find player ID: " + playerID;
                }
            }
            foreach (NewPlayer p in newOrder)
                players.Remove(p);

            foreach (NewPlayer p in players)
                newOrder.Add(p);

            players = newOrder;

            return "Successfully changed order.";
        }
        public void ClearPlayers()
        {
            players = new List<NewPlayer>();
        }
        public void AddPlayer(NewPlayer player)
        {
            players.Add(player);
            player.SetTeam(teamNum);

            activePlayers.Add(player);
        }
        public void RemovePlayer(NewPlayer player)
        {
            foreach (NewPlayer p in players)
            {
                if (p.GetPlayerID() == player.GetPlayerID())
                {
                    players.Remove(p);
                    p.SetTeam(-1);
                    break;
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
        public int GetWins()
        {
            return wins;
        }
        public int GetLosses()
        {
            return losses;
        }
        public sbyte GetTeamNum()
        {
            return teamNum;
        }
        public List<NewPlayer> GetActivePlayers()
        {
            return activePlayers;
        }
        public NewRealCoach GetCoach()
        {
            return realCoach;
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
        public void SortPlayers()
        {
            activePlayers.Sort();
            players.Sort();
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
        public int GetPointDifferential()
        {
            return pointsFor - pointsAgainst;
        }
        public String GetStreak()
        {
            String retVal = "";
            if (streak > 0) retVal = "W";
            else retVal = "L";

            retVal += "" + Math.Abs(streak);


            return retVal;
        }
        public String GetLastTen()
        {
            if(lastTen == null)
                lastTen = new List<bool>();
            int wins = 0, losses = 0;
            for (int i = 0; i < lastTen.Count; i++)
            {
                if (lastTen[i]) wins++;
                else losses++;
            }
            return wins + " - " + losses;
        }
        
        public void FinishGame(int score, int opponentScore, sbyte opposingTeam, bool playoffs)
        {
            if (!playoffs)
            {
                if (teamDictionary == null)
                {
                    teamDictionary = new Dictionary<sbyte, Tuple<byte, byte, int, int>>();
                    if(lastTen == null)
                        lastTen = new List<bool>();
                    
                }
                if (!teamDictionary.ContainsKey(opposingTeam))
                    teamDictionary.Add(opposingTeam, new Tuple<byte, byte, int, int>(0, 0, 0, 0));

                pointsFor += score;
                pointsAgainst += opponentScore;

                wins += (byte)(score > opponentScore ? 1 : 0);
                losses += (byte)(score < opponentScore ? 1 : 0);

                if (streak > 0 && score > opponentScore) streak++;
                else if (streak < 0 && score < opponentScore) streak--;
                else if (score < opponentScore) streak = -1;
                else streak = 1;

                if (lastTen.Count == 10)
                    lastTen.RemoveAt(0);

                lastTen.Add(score > opponentScore);

                teamDictionary[opposingTeam] = new Tuple<byte, byte, int, int>((byte)((score > opponentScore ? 1 : 0) + teamDictionary[opposingTeam].Item1), (byte)((score < opponentScore ? 1 : 0) + teamDictionary[opposingTeam].Item2), score + teamDictionary[opposingTeam].Item3, opponentScore + teamDictionary[opposingTeam].Item4);
            }
            foreach(NewPlayer p in this)
            {
                p.EndGame();                
            }
            AdvanceInjuries();
        }
        public String GetThreeLetters()
        {
            if(teamName.StartsWith("Hol"))
            {
                string[] words = teamName.Split(' ');
                if (words.Length == 3)
                    return ("" + words[0][0] + words[1][0] + words[2][0]).ToUpper();
                else
                    return words[1].Substring(0, 3).ToUpper();
            }
            return teamName.Substring(0, 3).ToUpper();
        }
        public string GetRecordAgainst(int teamNum)
        {
            if (teamDictionary.ContainsKey((sbyte)teamNum))
                return "" + teamDictionary[(sbyte)teamNum].Item1 + " - " + teamDictionary[(sbyte)teamNum].Item2;
            else
                return "0 - 0";
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
            streak = 0;

            seasons++;
            places += endPlace;
        }

        public void AdvancePicks()
        {
            currentSeasonPicks = nextSeasonPicks;
            nextSeasonPicks = new List<NewDraftPick>();
            nextSeasonPicks.Add(new NewDraftPick((byte)(League.seasonNum + 2), 1, (byte)teamNum, (byte)teamNum));
            nextSeasonPicks.Add(new NewDraftPick((byte)(League.seasonNum + 2), 2, (byte)teamNum, (byte)teamNum));
        }
        public void VerifyPicks(string[] picks)
        {
            currentSeasonPicks = new List<NewDraftPick>();
            nextSeasonPicks = new List<NewDraftPick>();
            foreach(string pick in picks)
            {
                string[] stats = pick.Split(',');
                int tempTeamNum = int.Parse(stats[0]);
                if (tempTeamNum == teamNum && int.Parse(stats[1]) == 10)                
                    currentSeasonPicks.Add(new NewDraftPick(10, byte.Parse(stats[2]), byte.Parse(stats[3]), (byte)teamNum));                
                else if(tempTeamNum == teamNum)
                    nextSeasonPicks.Add(new NewDraftPick(10, byte.Parse(stats[2]), byte.Parse(stats[3]), (byte)teamNum));
            }
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
        public void SetOwner(byte owner)
        {
            this.owner = owner;
        }
        public override string ToString()
        {
            return "P" + team + "R" + round + "S" + season;
        }
    }
}
