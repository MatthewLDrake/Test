using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    // equivalent to createTeams in old version
    public class League : IEnumerable<NewTeam>
    {
        private List<NewTeam> teams, dLeague;
        private NewFreeAgents freeAgents;
        public static Random r;
        private List<GameList> schedule;
        private int gamesPlayed;
        public static League league;
        public static uint NextID;
        public League(Random r)
        {
            League.r = r;
            League.league = this;
            teams = new List<NewTeam>();
            dLeague = new List<NewTeam>();
            freeAgents = new NewFreeAgents();
            gamesPlayed = 0;
        }
        public void AddPlayersToFreeAgents(List<NewPlayer> players)
        {
            foreach (NewPlayer player in players)
                AddPlayerToFreeAgents(player);
        }
        public void AddPlayerToFreeAgents(NewPlayer player)
        {
            freeAgents.Add(player);
        }
        public NewFreeAgents GetFreeAgents()
        {
            return freeAgents;
        }
        public void AddTeam(NewTeam mainTeam, NewTeam affiliate)
        {
            teams.Add(mainTeam);
            dLeague.Add(affiliate);
            // TODO: Handle affililate
        }
        public NewTeam GetTeam(int index)
        {
            return teams[index];
        }
        public NewTeam GetDLeagueTeam(int index)
        {
            return dLeague[index];
        }
        public void CreateSchedule()
        {
            schedule = new List<GameList>();

            schedule.AddRange(AddDivisionWideRoundRobin());            
            schedule.AddRange(AddConferenceWideRoundRobin());            
            schedule.AddRange(AddLeagueWideRoundRobin());
            

            gamesPlayed = 0;
        }
        private List<GameList> AddConferenceWideRoundRobin()
        {
            List<int> randomizedAList = new List<int>(), randomizedBList = new List<int>(), randomizedCList = new List<int>(), randomizedDList = new List<int>();
            List<GameList> gameList = new List<GameList>();

            for (int i = 0; i < 32; i++)
            {
                if (i < 8)
                {
                    randomizedAList.Add(i);
                    gameList.Add(new GameList());
                }
                else if (i < 16)
                    randomizedBList.Add(i);
                else if (i < 24)
                    randomizedCList.Add(i);
                else
                    randomizedDList.Add(i);
            }
            randomizedAList.Shuffle(r);
            randomizedBList.Shuffle(r);
            randomizedCList.Shuffle(r);
            randomizedDList.Shuffle(r);

            for(int i = 0; i < 8; i++)
            {
                gameList[0].AddGame(randomizedAList[i], randomizedBList[i % 8]);
                gameList[1].AddGame(randomizedAList[i], randomizedBList[(i + 1) % 8]);
                gameList[2].AddGame(randomizedAList[i], randomizedBList[(i + 2) % 8]);
                gameList[3].AddGame(randomizedAList[i], randomizedBList[(i + 3) % 8]);
                gameList[4].AddGame(randomizedBList[(i + 4) % 8], randomizedAList[i]);
                gameList[5].AddGame(randomizedBList[(i + 5) % 8], randomizedAList[i]);
                gameList[6].AddGame(randomizedBList[(i + 6) % 8], randomizedAList[i]);
                gameList[7].AddGame(randomizedBList[(i + 7) % 8], randomizedAList[i]);

                gameList[0].AddGame(randomizedCList[i], randomizedDList[i % 8]);
                gameList[1].AddGame(randomizedCList[i], randomizedDList[(i + 1) % 8]);
                gameList[2].AddGame(randomizedCList[i], randomizedDList[(i + 2) % 8]);
                gameList[3].AddGame(randomizedCList[i], randomizedDList[(i + 3) % 8]);
                gameList[4].AddGame(randomizedDList[(i + 4) % 8], randomizedCList[i]);
                gameList[5].AddGame(randomizedDList[(i + 5) % 8], randomizedCList[i]);
                gameList[6].AddGame(randomizedDList[(i + 6) % 8], randomizedCList[i]);
                gameList[7].AddGame(randomizedDList[(i + 7) % 8], randomizedCList[i]);
            }

            return gameList;
        }
        public void PlayGames(int numberOfGames)
        {
            for(int i = 0; i < numberOfGames; i++)
            {
                List<Tuple<int, int>> games = schedule[i + gamesPlayed].GetGames();
                foreach(Tuple<int, int> game in games)
                {
                    NewGame basketballGame = new NewGame(teams[game.Item1], teams[game.Item2], false);                    
                }
            }
            gamesPlayed += numberOfGames;
        }
        public List<Tuple<int, int>> GetNextGames()
        {
            int temp = gamesPlayed;
            gamesPlayed++;
            return schedule[temp].GetGames();
        }
        public void DoPlayoffs()
        {
            List<NewTeam> southernConference = new List<NewTeam>(), northernConference = new List<NewTeam>(), league = new List<NewTeam>();

            for(int i = 0; i < teams.Count / 2; i++)
            {
                southernConference.Add(teams[i]);
                northernConference.Add(teams[i + 16]);

                league.Add(teams[i]);
                league.Add(teams[i + 16]);
            }

            league.Sort();
            for (int i = 0; i < league.Count; i++)
                league[i].SetSeed(i);
            southernConference.Sort();
            northernConference.Sort();

            List<Tuple<int, NewTeam>> southernConferenceWinners = new List<Tuple<int, NewTeam>>(), southerConferenceLosers = new List<Tuple<int, NewTeam>>(), northernConferenceWinners = new List<Tuple<int, NewTeam>>(), northernConferenceLosers = new List<Tuple<int, NewTeam>>();

            for(int i = 0; i < 8; i++)
            {
                southernConferenceWinners.Add(new Tuple<int, NewTeam>(i + 1, southernConference[i]));
                southerConferenceLosers.Add(new Tuple<int, NewTeam>(i + 9, southernConference[i + 8]));

                northernConferenceWinners.Add(new Tuple<int, NewTeam>(i + 1, northernConference[i]));
                northernConferenceLosers.Add(new Tuple<int, NewTeam>(i + 9, northernConference[i + 8]));
            }

            NewPlayoffs winners = new NewPlayoffs(southernConferenceWinners, northernConferenceWinners, 1, true);
            NewPlayoffs losers = new NewPlayoffs(southerConferenceLosers, northernConferenceLosers, 17, true);
        }
        private List<GameList> AddDivisionWideRoundRobin()
        {
            List<int> randomizedAList = new List<int>(), randomizedBList = new List<int>(), randomizedCList = new List<int>(), randomizedDList = new List<int>(), robinList = new List<int>();
            List<GameList> gameList = new List<GameList>();

            for (int i = 0; i < 32; i++)
            {
                if (i < 8)
                {
                    randomizedAList.Add(i);
                    robinList.Add(i);
                }
                else if (i < 16)
                    randomizedBList.Add(i);
                else if (i < 24)
                    randomizedCList.Add(i);
                else
                    randomizedDList.Add(i);
            }

            randomizedAList.Shuffle(r);
            randomizedBList.Shuffle(r);
            randomizedCList.Shuffle(r);
            randomizedDList.Shuffle(r);

            for (int i = 0; i < 7; i++)
            {
                GameList games = new GameList(), otherGames = new GameList();
                for (int j = 0; j < 4; j++)
                {
                    
                    games.AddGame(randomizedAList[robinList[j]], randomizedAList[robinList[7 - j]]);
                    games.AddGame(randomizedBList[robinList[j]], randomizedBList[robinList[7 - j]]);
                    games.AddGame(randomizedCList[robinList[j]], randomizedCList[robinList[7 - j]]);
                    games.AddGame(randomizedDList[robinList[j]], randomizedDList[robinList[7 - j]]);

                    otherGames.AddGame(randomizedAList[robinList[7 - j]], randomizedAList[robinList[j]]);
                    otherGames.AddGame(randomizedBList[robinList[7 - j]], randomizedBList[robinList[j]]);
                    otherGames.AddGame(randomizedCList[robinList[7 - j]], randomizedCList[robinList[j]]);
                    otherGames.AddGame(randomizedDList[robinList[7 - j]], randomizedDList[robinList[j]]);
                    
                }


                int lastNum = robinList[7];
                robinList.Remove(lastNum);
                robinList.Insert(1, lastNum);

                gameList.Add(games);
                gameList.Add(otherGames);
            }

            return gameList;
        }
        private List<GameList> AddLeagueWideRoundRobin()
        {
            List<int> randomizedList = new List<int>(), robinList = new List<int>();
            List<GameList> gameList = new List<GameList>();

            for (int i = 0; i < 32; i++)
            {
                randomizedList.Add(i);
                robinList.Add(i);
            }

            randomizedList.Shuffle(r);

            for(int i = 0; i < 31; i++)
            {
                GameList games = new GameList(), otherGames = new GameList();
                for (int j = 0; j < 16; j++)
                {
                    games.AddGame(randomizedList[robinList[j]], randomizedList[robinList[31 - j]]);
                    otherGames.AddGame(randomizedList[robinList[31 - j]], randomizedList[robinList[j]]);
                }

                int lastNum = robinList[31];
                robinList.Remove(lastNum);
                robinList.Insert(1, lastNum);

                gameList.Add(games);
                gameList.Add(otherGames);
            }
            return gameList;
        }
        public IEnumerator<NewTeam> GetEnumerator()
        {
            return new TeamEnumerator(teams);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
    public class TeamEnumerator : IEnumerator<NewTeam>
    {
        private List<NewTeam> teams;
        private int location = -1;
        public TeamEnumerator(List<NewTeam> teams)
        {
            this.teams = teams;
        }
        public NewTeam Current
        {
            get
            {
                try
                {

                    return teams[location];
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
            while (location < teams.Count && teams[location] == null) location++;
            return location < teams.Count;
        }

        public void Reset()
        {
            location = -1;
        }
    }
    public class GameList
    {
        private List<Tuple<int, int>> games;
        public GameList()
        {
            games = new List<Tuple<int, int>>();
        }
        public void AddGame(int teamOne, int teamTwo)
        {
            games.Add(new Tuple<int, int>(teamOne, teamTwo));
        }
        public List<Tuple<int, int>> GetGames()
        {
            return games;
        }
        public void ReplaceGames(List<Tuple<int, int>> games)
        {
            this.games = games;
        }
        
    }
}
