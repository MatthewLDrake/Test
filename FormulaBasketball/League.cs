using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    [Serializable]
    // equivalent to createTeams in old version
    public class League : IEnumerable<NewTeam>
    {
        private List<NewTeam> teams, dLeague;
        private List<NewRealCoach> newCoaches;
        private NewFreeAgents freeAgents;
        public static Random r;
        private List<GameList> schedule;
        private int gamesPlayed;
        public static League league;
        public uint NextID;
        private List<Event> events;
        public static uint seasonNum = 10;
        private List<NewPlayer> playersOnWaivers, retiredPlayers;
        public uint tradeID = 0 , coachID;
        private int saveNum = 0;
        private Dictionary<int, List<Tuple<Tuple<int, int>, List<Tuple<int, int>>>>> newScores;
        private Dictionary<Tuple<int, int>, List<Tuple<Tuple<int, int>, List<Tuple<int, int>>>>> playoffScores;
        public League(Random r)
        {
            League.r = r;
            League.league = this;
            teams = new List<NewTeam>();
            dLeague = new List<NewTeam>();
            freeAgents = new NewFreeAgents();
            playersOnWaivers = new List<NewPlayer>();
            retiredPlayers = new List<NewPlayer>();
            events = new List<Event>();
            gamesPlayed = 0;
        }
        public List<NewRealCoach> GetCoaches()
        {
            return newCoaches;
        }
        public List<List<Tuple<Tuple<int, int>, List<Tuple<int, int>>>>> GetPlayoffScores(int round, int gameNum)
        {
            List<List<Tuple<Tuple<int, int>, List<Tuple<int, int>>>>> retVal = new List<List<Tuple<Tuple<int, int>, List<Tuple<int, int>>>>>();

            foreach(KeyValuePair<Tuple<int, int>, List<Tuple<Tuple<int, int>, List<Tuple<int, int>>>>> pair in playoffScores)
            {
                if(pair.Key.Item1 == round && pair.Key.Item2 == gameNum)
                {
                    retVal.Add(pair.Value);
                }
            }

            return retVal;
        }
        public void Update()
        {
            // Keep this

            r = new Random();
            league = this;

            // Stuff to remove
            

            /*foreach(NewTeam team in teams)
            {
                team.AdvanceYear(false);
            }
            foreach (NewTeam team in dLeague)
            {
                team.AdvanceYear(true);
            }
            foreach(NewPlayer player in freeAgents.GetAllPlayers())
            {
                player.AdvanceYear();
            }
            foreach(NewRealCoach coach in GetCoaches())
            {
                if(coach.GetTeam() != -1)
                    coach.AdvanceYear(null);
            }
            retiredPlayers = new List<NewPlayer>();
            retirementList = "";
            new PlayerRetirement(league).ShowDialog();

            File.WriteAllText("retirements.txt", retirementList);

            teams[3].RemoveCoach(teams[10].GetCoach());
            teams[10].RemoveCoach(teams[10].GetCoach());
            teams[14].RemoveCoach(teams[14].GetCoach());
            */
            
        }
        private string retirementList;
        public void AddRetiree(NewPlayer p)
        {
            retirementList += p.ToString() + " " + p.GetPlayerID() + "\n";
        }
        public void AddCoach(NewRealCoach coach)
        {
            newCoaches.Add(coach);
        }
        private void EndOfSeasonDevelopment()
        {
            foreach (NewTeam t in league)
            {
                foreach (NewPlayer p in t)
                {
                    Develop.DevelopPlayer(p, t.GetCoach());
                }
            }
            for (int i = 0; i < 32; i++)
            {
                foreach (NewPlayer p in league.GetDLeagueTeam(i))
                {
                    Develop.DevelopPlayer(p, league.GetDLeagueTeam(i).GetCoach());
                }
            }
            foreach (NewPlayer p in league.GetFreeAgents().GetAllPlayers())
            {
                Develop.DevelopPlayer(p);
            }
        }
        public static void AddPlayoffScore(ScoreCheater cheater, int awayTeam, int homeTeam, Tuple<int, int> gameNum)
        {
            List<Tuple<int, int>> quarterScores = new List<Tuple<int, int>>();

            for (int i = 0; i < cheater.GetAwayScores().Count; i++)
                quarterScores.Add(new Tuple<int, int>(cheater.GetAwayScores()[i], cheater.GetHomeScores()[i]));

            if (!league.playoffScores.ContainsKey(gameNum))
                league.playoffScores.Add(gameNum, new List<Tuple<Tuple<int, int>, List<Tuple<int, int>>>>());

            league.playoffScores[gameNum].Add(new Tuple<Tuple<int, int>, List<Tuple<int, int>>>(new Tuple<int, int>(awayTeam, homeTeam), quarterScores));
        }
        public void AddScores(ScoreCheater cheater, int awayTeam, int homeTeam, int gameNum)
        {
            List<Tuple<int, int>> quarterScores = new List<Tuple<int, int>>();

            for (int i = 0; i < cheater.GetAwayScores().Count; i++)
                quarterScores.Add(new Tuple<int, int>(cheater.GetAwayScores()[i], cheater.GetHomeScores()[i]));

            if (!newScores.ContainsKey(gameNum))                
                newScores.Add(gameNum, new List<Tuple<Tuple<int, int>, List<Tuple<int, int>>>>());

            newScores[gameNum].Add(new Tuple<Tuple<int, int>, List<Tuple<int, int>>>(new Tuple<int, int>(awayTeam, homeTeam), quarterScores));

        }
        public List<List<Tuple<Tuple<int, int>, List<Tuple<int, int>>>>> GetLastFourGames(int startingNum)
        {
            List<List<Tuple<Tuple<int, int>, List<Tuple<int, int>>>>> retVal = new List<List<Tuple<Tuple<int, int>, List<Tuple<int, int>>>>>();

            for (int i = startingNum; i < startingNum + 4; i++)
                retVal.Add(newScores[i]);

            return retVal;
        }
        public void AddCoaches()
        {
            newCoaches = new List<NewRealCoach>
            {
                new NewRealCoach("Woganure", Country.Aiyota, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 52, 1, "C+", "A", "A"),
                new NewRealCoach("Pratnoxpro Ikro", Country.Red_Rainbow, OffenseType.BALANCED_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 49, 2, "B", "A", "B"),
                new NewRealCoach("Duuśuś Peśqu", Country.Pentadominion, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 55, 3, "B", "B+", "B+"),
                new NewRealCoach("Zagësba Gasbërr", Country.Nausicaa, OffenseType.PRINCETON_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 77, 4, "A", "B+", "C"),
                new NewRealCoach("napuk nittaɰoikakáŋ", Country.Solea, OffenseType.PRINCETON_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.TEAM_LEADER, 58, 5, "D+", "A", "A+"),
                new NewRealCoach("Kwómhan Kaḿomhkwa", Country.Key_to_Don, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 47, 6, "C+", "B", "A+"),
                new NewRealCoach("Kibido Asoertotrisei", Country.Dotruga, OffenseType.BALANCED_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 71, 7, "C+", "B", "A+"),
                new NewRealCoach("Sabau Nide", Country.Auspikitan, OffenseType.PRINCETON_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 59, 8, "C+", "B+", "B+"),
                new NewRealCoach("Alexander Bailey", Country.Ethanthova, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 76, 9, "A", "B+", "D"),
                new NewRealCoach("tac", Country.Norkute, OffenseType.BALANCED_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.TEAM_LEADER, 38, 10, "C+", "B+", "B"),
                new NewRealCoach("nap", Country.Czalliso, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 75, 11, "B", "B", "B"),
                new NewRealCoach("Kantitat Plainukool", Country.Bielosia, OffenseType.BIG_BALL_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.PLAYERS_COACH, 47, 12, "B", "A", "D"),
                new NewRealCoach("ket", Country.Czalliso, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.LAID_BACK, 61, 13, "B+", "B", "C"),
                new NewRealCoach("lagak npéŋat", Country.Solea, OffenseType.PICK_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.INSPIRING, 48, 14, "B+", "B", "C"),
                new NewRealCoach("The Turnover Devastator", Country.Transhimalia, OffenseType.SMALL_BALL_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.LAID_BACK, 50, 15, "B", "B+", "D+"),
                new NewRealCoach("Chu Chin-Ho", Country.Shmupland, OffenseType.PRINCETON_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.ANALYTICAL, 51, 16, "B+", "C", "B+"),
                new NewRealCoach("Brynner Wolff", Country.Tri_National_Dominion, OffenseType.PRINCETON_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.ANALYTICAL, 53, 17, "C+", "B+", "C"),
                new NewRealCoach("Danomobei Elomos", Country.Dotruga, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 37, 18, "B+", "B", "D+"),
                new NewRealCoach("Adrian Owens", Country.Wyverncliff, OffenseType.BALANCED_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.ANALYTICAL, 52, 19, "A", "C", "C+"),
                new NewRealCoach("Nomura Sumiteru", Country.Aahrus, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 52, 20, "C", "B", "B+"),
                new NewRealCoach("pot", Country.Norkute, OffenseType.BALANCED_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.TEAM_LEADER, 50, 21, "B+", "C", "B"),
                new NewRealCoach("Imobesei Maxamos", Country.Ipal, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 29, 22, "C+", "B", "C+"),
                new NewRealCoach("koy", Country.Czalliso, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.OVERALL_BASED, Personality.LAID_BACK, 54, 23, "D+", "B+", "B"),
                new NewRealCoach("hur", Country.Czalliso, OffenseType.BALANCED_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.ANALYTICAL, 42, 24, "B", "C", "B+"),
                new NewRealCoach("Phetdum Thammavong", Country.Lyintaria, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.PLAYERS_COACH, 49, 25, "B", "C", "B+"),
                new NewRealCoach("The Moment Bender", Country.Transhimalia, OffenseType.BIG_BALL_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.ANALYTICAL, 49, 26, "B", "C+", "C+"),
                new NewRealCoach("Nagasawa Bunrakuken", Country.Aeridani, OffenseType.PRINCETON_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.TEAM_LEADER, 64, 27, "B", "C+", "C+"),
                new NewRealCoach("Mwu Txali", Country.Hinaika, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.LAID_BACK, 40, 28, "B", "C+", "C+"),
                new NewRealCoach("Sokolnox Auprat", Country.Blaist_Blaland, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.INSPIRING, 55, 29, "C", "B", "B"),
                new NewRealCoach("Charles Tucker", Country.Helvaena, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.ANALYTICAL, 45, 30, "B", "C+", "C+"),
                new NewRealCoach("Ekoŋa Tzuikaŋi", Country.Eqkirium, OffenseType.BALANCED_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.INSPIRING, 26, 31, "C", "B+", "C"),
                new NewRealCoach("nib", Country.Norkute, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.TEAM_LEADER, 34, 32, "C", "B+", "C"),
                new NewRealCoach("nánugaɰí táthiluv", Country.Pqalik, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.PLAYERS_COACH, 47, 33, "A+", "D+", "C"),
                new NewRealCoach("Iwayanagi Matsuyo", Country.Aahrus, OffenseType.BALANCED_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.LAID_BACK, 66, 34, "D+", "B", "B+"),
                new NewRealCoach("Paɰe Naksik", Country.Nausicaa, OffenseType.BALANCED_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 37, 35, "C+", "B", "C"),
                new NewRealCoach("Tanau Toso", Country.Red_Rainbow, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.TEAM_LEADER, 53, 36, "B", "C+", "C"),
                new NewRealCoach("Komori Tetsuya", Country.Aeridani, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 58, 37, "C", "B", "C+"),
                new NewRealCoach("Kaden Black", Country.Helvaena, OffenseType.BALANCED_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.PLAYERS_COACH, 52, 38, "C", "B", "C+"),
                new NewRealCoach("Ixbla Toso", Country.Blaist_Blaland, OffenseType.SMALL_BALL_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.INSPIRING, 37, 39, "C", "B", "C+"),
                new NewRealCoach("aqurak átnhílekh", Country.Solea, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 41, 40, "C+", "C", "B+"),
                new NewRealCoach("Annie River", Country.Nova_Chrysalia, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 48, 41, "B+", "C", "C"),
                new NewRealCoach("Mhokba Pŕasa", Country.Sagua, OffenseType.PRINCETON_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.ANALYTICAL, 55, 42, "C+", "C+", "C+"),
                new NewRealCoach("Bane Siyavong", Country.Bielosia, OffenseType.BALANCED_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.LAID_BACK, 51, 43, "C+", "B", "D+"),
                new NewRealCoach("Bane Phothisarath", Country.Bielosia, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.INSPIRING, 33, 44, "A", "D", "B"),
                new NewRealCoach("Leakuqw'opwui Latj'enetenwa", Country.Hinaika, OffenseType.SMALL_BALL_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 47, 45, "C", "C+", "B"),
                new NewRealCoach("Kye Khotpanya", Country.Bielosia, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.INSPIRING, 66, 46, "C", "C+", "B"),
                new NewRealCoach("Lillie Rowan", Country.Nova_Chrysalia, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 67, 47, "B", "C+", "D+"),
                new NewRealCoach("Osiei Bexomos", Country.Dotruga, OffenseType.PRINCETON_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.ANALYTICAL, 40, 48, "B", "C+", "D+"),
                new NewRealCoach("Vioŋeki Poi", Country.Auspikitan, OffenseType.SMALL_BALL_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.LAID_BACK, 35, 49, "B", "C+", "D+"),
                new NewRealCoach("Bryan Harrison", Country.Wyverncliff, OffenseType.BALANCED_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.PLAYERS_COACH, 22, 50, "D+", "C+", "B+"),
                new NewRealCoach("Versi Asolomundi", Country.Dotruga, OffenseType.PRINCETON_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.TEAM_LEADER, 47, 51, "C+", "C", "B"),
                new NewRealCoach("yob", Country.Czalliso, OffenseType.BALANCED_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.ANALYTICAL, 43, 52, "B+", "C", "D+"),
                new NewRealCoach("telel lekeŋ", Country.Solea, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 50, 53, "B+", "C", "D+"),
                new NewRealCoach("šaitón theh", Country.Kareng, OffenseType.BALANCED_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.LAID_BACK, 23, 54, "C+", "C+", "C"),
                new NewRealCoach("koiŋaih eiɰákeɰ", Country.Eksola, OffenseType.BIG_BALL_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.INSPIRING, 52, 55, "C+", "B", "D"),
                new NewRealCoach("Payhèmàw Ggàdéʃ", Country.Antarion, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 40, 56, "C+", "B+", "F"),
                new NewRealCoach("Iix Faraulik", Country.Blaist_Blaland, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 44, 57, "B", "D+", "B"),
                new NewRealCoach("Ajanis Bexotrugo", Country.Dotruga, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.LAID_BACK, 62, 58, "C", "C", "B+"),
                new NewRealCoach("kihá klpoik", Country.Solea, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 47, 59, "B", "C", "C"),
                new NewRealCoach("zin", Country.Czalliso, OffenseType.BALANCED_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.LAID_BACK, 36, 60, "C", "C+", "C+"),
                new NewRealCoach("Nouka Sw'akonenis'a", Country.Atapwa, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.OVERALL_BASED, Personality.PLAYERS_COACH, 64, 61, "C", "C+", "C+"),
                new NewRealCoach("Kuilikki Kipafar", Country.Blaist_Blaland, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 47, 62, "C+", "C", "C+"),
                new NewRealCoach("Danaix Lizaxium", Country.Blaist_Blaland, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.INSPIRING, 49, 63, "C+", "C", "C+"),
                new NewRealCoach("Osiei Bexoxek", Country.Tjedigar, OffenseType.BALANCED_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.INSPIRING, 62, 64, "C+", "C", "C+"),
                new NewRealCoach("Ajanis Xiahelvi", Country.Dotruga, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.ANALYTICAL, 26, 65, "C+", "C", "C+"),
                new NewRealCoach("Benjamin Thompson", Country.Ethanthova, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.ANALYTICAL, 63, 66, "B+", "C", "D"),
                new NewRealCoach("Carter Gray", Country.Wyverncliff, OffenseType.BALANCED_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.ANALYTICAL, 61, 67, "C+", "C+", "D+"),
                new NewRealCoach("coh", Country.Czalliso, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.PLAYERS_COACH, 60, 68, "C+", "C+", "D+"),
                new NewRealCoach("Danobamobesa Halapodetsei", Country.Tjedigar, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.INSPIRING, 65, 69, "C+", "B", "F+"),
                new NewRealCoach("Iausi Mokiuk", Country.Aitessek, OffenseType.PICK_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.PLAYERS_COACH, 33, 70, "C+", "B", "F+"),
                new NewRealCoach("dio", Country.Norkute, OffenseType.BALANCED_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.OVERALL_BASED, Personality.TEAM_LEADER, 41, 71, "B", "D+", "C+"),
                new NewRealCoach("Laura Finley", Country.Nova_Chrysalia, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.PLAYERS_COACH, 29, 72, "C", "C+", "C"),
                new NewRealCoach("Konala Thepsenavong", Country.Holy_Yektonisa, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.LAID_BACK, 46, 73, "D", "B+", "D+"),
                new NewRealCoach("Kibibei Motxev", Country.Tjedigar, OffenseType.PICK_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 50, 74, "F+", "C+", "A"),
                new NewRealCoach("Kawaii Viravongs", Country.Pyxanovia, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 65, 75, "C+", "D+", "B"),
                new NewRealCoach("Viiŕce Ttéśve", Country.Antarion, OffenseType.BALANCED_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 52, 76, "C+", "C", "C"),
                new NewRealCoach("Leah Oscar", Country.Nova_Chrysalia, OffenseType.SMALL_BALL_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.OVERALL_BASED, Personality.ANALYTICAL, 40, 77, "C+", "C", "C"),
                new NewRealCoach("qolšŋ kuvkithet", Country.Solea, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.OVERALL_BASED, Personality.PLAYERS_COACH, 51, 78, "C+", "C", "C"),
                new NewRealCoach("Colin Andrews", Country.Ethanthova, OffenseType.PRINCETON_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 53, 79, "D+", "B", "D+"),
                new NewRealCoach("Atusosa Eloalerko", Country.Timbalta, OffenseType.BALANCED_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.LAID_BACK, 59, 80, "B", "D", "B"),
                new NewRealCoach("Stanley Stevens", Country.Ethanthova, OffenseType.SMALL_BALL_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.ANALYTICAL, 46, 81, "D", "C", "A"),
                new NewRealCoach("Sadie Alfie", Country.Nova_Chrysalia, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.ANALYTICAL, 63, 82, "D", "C+", "B"),
                new NewRealCoach("Danaix Proki", Country.Red_Rainbow, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.INSPIRING, 27, 83, "C", "C", "C+"),
                new NewRealCoach("tikit' nittaɰoikakáŋ", Country.Solea, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.OVERALL_BASED, Personality.PLAYERS_COACH, 47, 84, "B", "D+", "C"),
                new NewRealCoach("Amoda Tuvek", Country.Dotruga, OffenseType.BIG_BALL_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 43, 85, "D", "B", "C"),
                new NewRealCoach("Lincoln Clark", Country.Wyverncliff, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.LAID_BACK, 23, 86, "C", "C+", "D+"),
                new NewRealCoach("Aloli Bexemetadotsei", Country.Dotruga, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 51, 87, "C+", "D+", "C+"),
                new NewRealCoach("Dextros Tadotsei", Country.Lemos, OffenseType.BIG_BALL_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.OVERALL_BASED, Personality.PLAYERS_COACH, 47, 88, "C+", "C", "D+"),
                new NewRealCoach("vaŋun tŋken", Country.Solea, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.INSPIRING, 47, 89, "C+", "C+", "F+"),
                new NewRealCoach("Declan Kelley", Country.Wyverncliff, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 56, 90, "C", "D", "A"),
                new NewRealCoach("Kubeitratoik Ŋuikanaga", Country.Kaeshar, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.INSPIRING, 55, 91, "C", "D+", "B"),
                new NewRealCoach("Teyvada Siyavong", Country.Holy_Yektonisa, OffenseType.BALANCED_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.ANALYTICAL, 37, 92, "C", "C", "C"),
                new NewRealCoach("Bamuel Ball", Country.Bongatar, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.INSPIRING, 54, 93, "C", "C+", "D"),
                new NewRealCoach("Gracie Finley", Country.Nova_Chrysalia, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.OVERALL_BASED, Personality.PLAYERS_COACH, 46, 94, "C+", "D+", "C"),
                new NewRealCoach("Peodo Ifet", Country.Auspikitan, OffenseType.BALANCED_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 45, 95, "D+", "C", "C+"),
                new NewRealCoach("Kakvei Pitai", Country.Aovensiiv, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.OVERALL_BASED, Personality.INSPIRING, 39, 96, "D+", "C", "C+"),
                new NewRealCoach("Waldemar Hofmann", Country.Tri_National_Dominion, OffenseType.SMALL_BALL_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.TEAM_LEADER, 35, 97, "D+", "C", "C+"),
                new NewRealCoach("Wukukwok'u Na", Country.Futiakep, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.LAID_BACK, 55, 98, "B+", "D", "D+"),
                new NewRealCoach("Tikka Fokaipa", Country.Aitessek, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.ANALYTICAL, 57, 99, "B", "F+", "B"),
                new NewRealCoach("ešanéki takiŋa", Country.Kolauk, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 54, 100, "C", "C", "D+"),
                new NewRealCoach("Himiba Xiahelvi", Country.Dotruga, OffenseType.SMALL_BALL_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.LAID_BACK, 52, 101, "C", "C+", "F+"),
                new NewRealCoach("Meka Tayvihane", Country.Holy_Yektonisa, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.LAID_BACK, 63, 102, "C", "C+", "F+"),
                new NewRealCoach("Go Tameyoshi", Country.Aahrus, OffenseType.BALANCED_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.INSPIRING, 56, 103, "C+", "D", "C+"),
                new NewRealCoach("Hënila Saχi", Country.Darvincia, OffenseType.PRINCETON_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.PLAYERS_COACH, 47, 104, "C+", "D", "C+"),
                new NewRealCoach("Carson Harris", Country.Wyverncliff, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.PLAYERS_COACH, 49, 105, "C+", "D", "C+"),
                new NewRealCoach("Hòŕcò Dova'mar'éxànè", Country.Pentadominion, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 64, 106, "D+", "D+", "B"),
                new NewRealCoach("Sathanalat Viravongs", Country.Holy_Yektonisa, OffenseType.BALANCED_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.TEAM_LEADER, 69, 107, "D+", "C", "C"),
                new NewRealCoach("Kayden King", Country.Ethanthova, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.TEAM_LEADER, 60, 108, "D+", "C", "C"),
                new NewRealCoach("Molly Muhammad", Country.Nova_Chrysalia, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 44, 109, "C+", "C", "F+"),
                new NewRealCoach("Bavid Bose", Country.Bongatar, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 45, 110, "D+", "C+", "D"),
                new NewRealCoach("Ikkrosovi Proki", Country.Blaist_Blaland, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.LAID_BACK, 58, 111, "D", "C", "C+"),
                new NewRealCoach("Ni'áqŕópłá Nasa", Country.Height_Sagua, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.INSPIRING, 41, 112, "D", "C", "C+"),
                new NewRealCoach("Paramendr Thumying", Country.Bielosia, OffenseType.PRINCETON_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.LAID_BACK, 57, 113, "C+", "D", "C"),
                new NewRealCoach("Grady Ward", Country.Ethanthova, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.INSPIRING, 43, 114, "D+", "C", "D+"),
                new NewRealCoach("Olandi Kixidosu", Country.Dotruga, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 67, 115, "C+", "D+", "D"),
                new NewRealCoach("Liko Ketthavong", Country.Bielosia, OffenseType.BALANCED_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.INSPIRING, 51, 116, "C+", "C", "F"),
                new NewRealCoach("Bryce Franklin", Country.Wyverncliff, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.OVERALL_BASED, Personality.TEAM_LEADER, 34, 117, "D", "D+", "B"),
                new NewRealCoach("Duuśuś Nùx́iś", Country.Nja, OffenseType.PRINCETON_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.PLAYERS_COACH, 46, 118, "B", "F+", "C"),
                new NewRealCoach("Beisei Rexem", Country.Teralm, OffenseType.BALANCED_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.PLAYERS_COACH, 69, 119, "C", "D", "C+"),
                new NewRealCoach("Làto Daho", Country.Darvincia, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.TEAM_LEADER, 50, 120, "D", "C+", "D"),
                new NewRealCoach("Tanner Dietrich", Country.Tri_National_Dominion, OffenseType.PICK_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 40, 121, "D+", "D", "B"),
                new NewRealCoach("Atumobei Kixibesei", Country.Teralm, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.LAID_BACK, 44, 122, "C+", "F+", "C+"),
                new NewRealCoach("Gexek Alodetsei", Country.Teralm, OffenseType.BALANCED_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.LAID_BACK, 49, 123, "C+", "D", "D+"),
                new NewRealCoach("Kimámháh Mhákĩnimɲika", Country.Dtersauuw_Sagua, OffenseType.PICK_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.ANALYTICAL, 60, 124, "C+", "D", "D+"),
                new NewRealCoach("Zaxkla Hjetohje", Country.Red_Rainbow, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.INSPIRING, 40, 125, "C+", "D", "D+"),
                new NewRealCoach("Abio Niobupau", Country.Aitessek, OffenseType.PRINCETON_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STREAK_BASED, Personality.ANALYTICAL, 62, 126, "C", "F", "A"),
                new NewRealCoach("Śa'guskeq Ciiśǵià", Country.Pentadominion, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.LAID_BACK, 55, 127, "C", "D", "C"),
                new NewRealCoach("kǔlaip ŋeqašlaš", Country.Kolauk, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.TEAM_LEADER, 62, 128, "C", "D", "C"),
                new NewRealCoach("Samuel Barnes", Country.Ethanthova, OffenseType.PICK_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 50, 129, "C", "C", "F"),
                new NewRealCoach("Atumobei Falnosoko", Country.Dotruga, OffenseType.BALANCED_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.TEAM_LEADER, 65, 130, "F+", "D+", "B"),
                new NewRealCoach("Kipana Ioŋ", Country.Auspikitan, OffenseType.SMALL_BALL_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.MATCHUP_BASED, Personality.INSPIRING, 59, 131, "D+", "D", "C+"),
                new NewRealCoach("Vwákoklóvá Blamhákpwano", Country.Key_to_Don, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 53, 132, "D+", "C", "F+"),
                new NewRealCoach("Malo Siyavong", Country.Bielosia, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 39, 133, "C", "D", "D+"),
                new NewRealCoach("Iix Ikro", Country.Blaist_Blaland, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.TEAM_LEADER, 52, 134, "D+", "F", "A"),
                new NewRealCoach("Atumundikeili Himadosadetsei", Country.Dotruga, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 53, 135, "D+", "F+", "B"),
                new NewRealCoach("nib", Country.Norkute, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.OVERALL_BASED, Personality.ANALYTICAL, 46, 136, "D+", "F+", "B"),
                new NewRealCoach("Kibibei Himadosamosei", Country.Dotruga, OffenseType.PICK_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.ANALYTICAL, 48, 137, "D+", "F+", "B"),
                new NewRealCoach("Pau Nibrit", Country.Auspikitan, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MAN_NO_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 50, 138, "D+", "D", "C"),
                new NewRealCoach("Tibiziŋag Gukle", Country.Auspikitan, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.TEAM_LEADER, 38, 139, "D", "D", "C+"),
                new NewRealCoach("Yoshida Paradiniton", Country.Barsein, OffenseType.SMALL_BALL_OFFENSE, DefenseType.TWO_THREE_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 59, 140, "C", "F+", "C"),
                new NewRealCoach("Klegna Taqri", Country.Auspikitan, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.INSPIRING, 33, 141, "D", "D+", "D+"),
                new NewRealCoach("Oke Saysamongdy", Country.Lyintaria, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.INSPIRING, 64, 142, "C", "D", "D"),
                new NewRealCoach("Xaisomboun Phommasane", Country.Bielosia, OffenseType.SEVEN_SECOND_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.TEAM_LEADER, 47, 143, "F+", "D", "B"),
                new NewRealCoach("telel nittaɰoikakáŋ", Country.Solea, OffenseType.BALANCED_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.PLAYERS_COACH, 48, 144, "C", "F+", "D+"),
                new NewRealCoach("Maxel Omobesei", Country.Lemos, OffenseType.BALANCED_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.PLAYERS_COACH, 59, 145, "F", "C", "D+"),
                new NewRealCoach("ǎtákei qagh", Country.Pqalik, OffenseType.SMALL_BALL_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.STAMINA_BASED, Personality.TEAM_LEADER, 35, 146, "D+", "D", "D"),
                new NewRealCoach("Mwu P'inwapatwunatwo", Country.Futiakep, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.MAN_SWITCH_DEFENSE, PersonnelType.SCHEDULE_BASED, Personality.TEAM_LEADER, 48, 147, "C", "F+", "D"),
                new NewRealCoach("Koqoka Nitip", Country.Auspikitan, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.MATCHUP_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.INSPIRING, 50, 148, "F+", "F+", "C+"),
                new NewRealCoach("Abi Kanix", Country.Darvincia, OffenseType.SUPERSTAR_FIRST_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STAMINA_BASED, Personality.LAID_BACK, 57, 149, "D", "F", "C"),
                new NewRealCoach("Kutxoat'alapak'a Sw'akonenis'a", Country.Atapwa, OffenseType.PERIMETER_CENTRIC_OFFENSE, DefenseType.THREE_TWO_ZONE_DEFENSE, PersonnelType.STREAK_BASED, Personality.PLAYERS_COACH, 48, 150, "D", "D", "F")
            };
            teams[16].AddCoach(newCoaches[0]);
            teams[21].AddCoach(newCoaches[1]);
            teams[8].AddCoach(newCoaches[2]);
            teams[14].AddCoach(newCoaches[3]);
            teams[26].AddCoach(newCoaches[4]);
            teams[18].AddCoach(newCoaches[5]);
            teams[3].AddCoach(newCoaches[6]);
            teams[28].AddCoach(newCoaches[7]);
            teams[10].AddCoach(newCoaches[8]);
            teams[17].AddCoach(newCoaches[9]);
            teams[22].AddCoach(newCoaches[10]);
            teams[12].AddCoach(newCoaches[11]);
            teams[2].AddCoach(newCoaches[12]);
            teams[24].AddCoach(newCoaches[13]);
            teams[1].AddCoach(newCoaches[14]);
            teams[29].AddCoach(newCoaches[15]);
            teams[23].AddCoach(newCoaches[16]);
            teams[5].AddCoach(newCoaches[17]);
            teams[4].AddCoach(newCoaches[18]);
            teams[31].AddCoach(newCoaches[19]);
            teams[11].AddCoach(newCoaches[20]);
            teams[9].AddCoach(newCoaches[21]);
            teams[13].AddCoach(newCoaches[22]);
            teams[25].AddCoach(newCoaches[23]);
            dLeague[25].AddCoach(newCoaches[24]);
            teams[20].AddCoach(newCoaches[25]);
            dLeague[17].AddCoach(newCoaches[26]);
            teams[7].AddCoach(newCoaches[27]);
            teams[30].AddCoach(newCoaches[28]);
            teams[27].AddCoach(newCoaches[29]);
            teams[15].AddCoach(newCoaches[30]);
            dLeague[15].AddCoach(newCoaches[31]);
            dLeague[18].AddCoach(newCoaches[32]);
            teams[0].AddCoach(newCoaches[33]);
            dLeague[4].AddCoach(newCoaches[34]);
            dLeague[13].AddCoach(newCoaches[35]);
            dLeague[21].AddCoach(newCoaches[36]);
            dLeague[30].AddCoach(newCoaches[37]);
            dLeague[23].AddCoach(newCoaches[38]);
            teams[6].AddCoach(newCoaches[41]);
            dLeague[19].AddCoach(newCoaches[43]);
            dLeague[9].AddCoach(newCoaches[44]);
            dLeague[12].AddCoach(newCoaches[46]);
            dLeague[22].AddCoach(newCoaches[47]);
            dLeague[1].AddCoach(newCoaches[48]);
            dLeague[5].AddCoach(newCoaches[49]);
            dLeague[28].AddCoach(newCoaches[50]);
            dLeague[2].AddCoach(newCoaches[51]);
            dLeague[7].AddCoach(newCoaches[52]);
            dLeague[31].AddCoach(newCoaches[53]);
            dLeague[6].AddCoach(newCoaches[54]);
            dLeague[27].AddCoach(newCoaches[55]);
            dLeague[10].AddCoach(newCoaches[56]);
            teams[19].AddCoach(newCoaches[58]);
            dLeague[11].AddCoach(newCoaches[61]);
            dLeague[20].AddCoach(newCoaches[65]);
            dLeague[3].AddCoach(newCoaches[68]);
            dLeague[0].AddCoach(newCoaches[70]);
            dLeague[16].AddCoach(newCoaches[74]);
            dLeague[29].AddCoach(newCoaches[79]);
            dLeague[26].AddCoach(newCoaches[83]);
            dLeague[24].AddCoach(newCoaches[87]);
            dLeague[14].AddCoach(newCoaches[97]);
            dLeague[8].AddCoach(newCoaches[98]);
            newCoaches[0].SetTeam(new Contract(5, 18), 16);
            newCoaches[1].SetTeam(new Contract(4, 8.9), 21);
            newCoaches[2].SetTeam(new Contract(3, 12.1), 8);
            newCoaches[3].SetTeam(new Contract(2, 10.5), 14);
            newCoaches[4].SetTeam(new Contract(4, 7.5), 26);
            newCoaches[5].SetTeam(new Contract(3, 8.3), 18);
            newCoaches[6].SetTeam(new Contract(2, 7.6), 3);
            newCoaches[7].SetTeam(new Contract(2, 5.8), 28);
            newCoaches[8].SetTeam(new Contract(3, 7.8), 10);
            newCoaches[9].SetTeam(new Contract(2, 6), 17);
            newCoaches[10].SetTeam(new Contract(1, 5), 22);
            newCoaches[11].SetTeam(new Contract(4, 9.5), 12);
            newCoaches[12].SetTeam(new Contract(1, 6.3), 2);
            newCoaches[13].SetTeam(new Contract(5, 11.5), 24);
            newCoaches[14].SetTeam(new Contract(2, 8.2), 1);
            newCoaches[15].SetTeam(new Contract(2, 5.4), 29);
            newCoaches[16].SetTeam(new Contract(4, 7.5), 23);
            newCoaches[17].SetTeam(new Contract(8, 5.6), 5);
            newCoaches[18].SetTeam(new Contract(4, 12.1), 4);
            newCoaches[19].SetTeam(new Contract(3, 3.1), 31);
            newCoaches[20].SetTeam(new Contract(1, 7), 11);
            newCoaches[21].SetTeam(new Contract(3, 4.8), 9);
            newCoaches[22].SetTeam(new Contract(4, 5), 13);
            newCoaches[23].SetTeam(new Contract(2, 4.2), 25);
            newCoaches[24].SetTeam(new Contract(2, 4.8), 57);
            newCoaches[25].SetTeam(new Contract(3, 7), 20);
            newCoaches[26].SetTeam(new Contract(3, 5), 49);
            newCoaches[27].SetTeam(new Contract(4, 10), 7);
            newCoaches[28].SetTeam(new Contract(4, 6.9), 30);
            newCoaches[29].SetTeam(new Contract(2, 4.6), 27);
            newCoaches[30].SetTeam(new Contract(1, 1), 15);
            newCoaches[31].SetTeam(new Contract(1, 1), 47);
            newCoaches[32].SetTeam(new Contract(4, 6.8), 50);
            newCoaches[33].SetTeam(new Contract(3, 3.2), 0);
            newCoaches[34].SetTeam(new Contract(2, 1.8), 36);
            newCoaches[35].SetTeam(new Contract(3, 4.6), 45);
            newCoaches[36].SetTeam(new Contract(3, 4), 53);
            newCoaches[37].SetTeam(new Contract(4, 2.6), 62);
            newCoaches[38].SetTeam(new Contract(5, 1.5), 55);
            newCoaches[41].SetTeam(new Contract(3, 2.1), 6);
            newCoaches[43].SetTeam(new Contract(3, 3), 51);
            newCoaches[44].SetTeam(new Contract(2, 5.1), 41);
            newCoaches[46].SetTeam(new Contract(2, 2), 44);
            newCoaches[47].SetTeam(new Contract(2, 2.8), 54);
            newCoaches[48].SetTeam(new Contract(2, 1.8), 33);
            newCoaches[49].SetTeam(new Contract(1, 1.8), 37);
            newCoaches[50].SetTeam(new Contract(2, 1.8), 60);
            newCoaches[51].SetTeam(new Contract(4, 2.8), 34);
            newCoaches[52].SetTeam(new Contract(3, 2.5), 39);
            newCoaches[53].SetTeam(new Contract(3, 1.3), 63);
            newCoaches[54].SetTeam(new Contract(4, 1.6), 38);
            newCoaches[55].SetTeam(new Contract(2, 1.1), 59);
            newCoaches[56].SetTeam(new Contract(3, 2.1), 42);
            newCoaches[58].SetTeam(new Contract(3, 4), 19);
            newCoaches[61].SetTeam(new Contract(1, 0.9), 43);
            newCoaches[65].SetTeam(new Contract(2, 2.1), 52);
            newCoaches[68].SetTeam(new Contract(2, 1.3), 35);
            newCoaches[70].SetTeam(new Contract(2, 1.5), 32);
            newCoaches[74].SetTeam(new Contract(2, 0.8), 48);
            newCoaches[79].SetTeam(new Contract(4, 1.9), 61);
            newCoaches[83].SetTeam(new Contract(2, 1.8), 58);
            newCoaches[87].SetTeam(new Contract(1, 0.5), 56);
            newCoaches[97].SetTeam(new Contract(5, 1.6), 46);
            newCoaches[98].SetTeam(new Contract(2, 2.6), 40);
        }
        public void RetirePlayer(NewPlayer p)
        {
            retiredPlayers.Add(p);
        }
        public List<NewPlayer> GetRetiredPlayers()
        {
            return retiredPlayers;
        }
        public void ResetWaivers()
        {
            playersOnWaivers = new List<NewPlayer>();
        }
        public void AddPlayerToWaivers(NewPlayer p)
        {
            
            playersOnWaivers.Add(p);
        }
        public List<NewPlayer> GetWaivers()
        {
            return playersOnWaivers;
        }

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public static void SerializeObject(League serializableObject, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, serializableObject);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        /// <summary>
        /// Deserializes a binary file into an object list
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <returns></returns>
        public static League DeSerializeObject(string fileName)
        {
            League temp = null;
           
            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream(fileName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                temp = (League)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            r = new Random();
            league = temp;
            temp.saveNum++;
            if (temp.saveNum >= 5)
            {
                temp.saveNum = 0;
                string backupFileName = fileName.Replace(".fbleague", "COPY.fbleague");
                
                SerializeObject(temp, backupFileName);
            }
            return temp;
        }
        public void AddEvent(Event e)
        {
            events.Add(e);
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
        public List<GameList> GetCustomSchedule()
        {
            List<GameList> schedule = new List<GameList>();

            schedule.AddRange(AddDivisionWideRoundRobin());
            schedule.AddRange(AddConferenceWideRoundRobin());
            schedule.AddRange(AddLeagueWideRoundRobin());

            return schedule;
        }
        public void CreateSchedule()
        {
            schedule = new List<GameList>();

            schedule.AddRange(AddDivisionWideRoundRobin());            
            schedule.AddRange(AddConferenceWideRoundRobin());            
            schedule.AddRange(AddLeagueWideRoundRobin());
            

            gamesPlayed = 0;
        }
        public int GetGamesPlayed()
        {
            return gamesPlayed;
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
        public NewPlayer FindPlayerByID(int id)
        {
            foreach(NewTeam t in teams)
            {
                foreach(NewPlayer p in t)
                {
                    if (p.GetPlayerID() == id)
                        return p;
                }
            }
            foreach (NewTeam t in dLeague)
            {
                foreach (NewPlayer p in t)
                {
                    if (p.GetPlayerID() == id)
                        return p;
                }
            }
            foreach(NewPlayer p in freeAgents.GetAllPlayers())
            {
                if (p.GetPlayerID() == id)
                    return p;
            }
            return null;
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
        public List<Tuple<int, int>> GetPreviewForTeam(int team)
        {
            List<Tuple<int, int>> upcomingGames = new List<Tuple<int, int>>();            

            for(int i = gamesPlayed; i < gamesPlayed + 4; i++ )
            {
                foreach (Tuple<int, int> tuple in schedule[i].GetGames())
                {
                    if (tuple.Item1 == team || tuple.Item2 == team)
                    {
                        upcomingGames.Add(tuple);
                        break;
                    }
                }
            }            

            return upcomingGames;
        }
        public Tuple<int, int> GetGameFromTeam(int team, int gameNum)
        {     
            foreach (Tuple<int, int> tuple in schedule[gameNum - 1].GetGames())
            {
                if (tuple.Item1 == team || tuple.Item2 == team)
                {
                    return tuple;
                }
            }           

            return null;
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
        private NewPlayoffs winners, losers, dLeagueWinners, dLeagueLosers;
        public void DoPlayoffRound()
        {
            league = this;
            if (winners == null)
            {
                playoffScores = new Dictionary<Tuple<int, int>, List<Tuple<Tuple<int, int>, List<Tuple<int, int>>>>>();
                List<NewTeam> southernConference = new List<NewTeam>(), northernConference = new List<NewTeam>(), league = new List<NewTeam>();

                for (int i = 0; i < teams.Count / 2; i++)
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

                for (int i = 0; i < 8; i++)
                {
                    southernConferenceWinners.Add(new Tuple<int, NewTeam>(i + 1, southernConference[i]));
                    southerConferenceLosers.Add(new Tuple<int, NewTeam>(i + 9, southernConference[i + 8]));

                    northernConferenceWinners.Add(new Tuple<int, NewTeam>(i + 1, northernConference[i]));
                    northernConferenceLosers.Add(new Tuple<int, NewTeam>(i + 9, northernConference[i + 8]));
                }

                winners = new NewPlayoffs(southernConferenceWinners, northernConferenceWinners, 1, false, false);
                losers = new NewPlayoffs(southerConferenceLosers, northernConferenceLosers, 17, false, false);


                southernConference = new List<NewTeam>();
                northernConference = new List<NewTeam>();
                league = new List<NewTeam>();


                for (int i = 0; i < teams.Count / 2; i++)
                {
                    southernConference.Add(dLeague[i]);
                    northernConference.Add(dLeague[i + 16]);

                    dLeague[i].SetTeamNum(32 + i);
                    dLeague[i + 16].SetTeamNum(48 + i);

                    league.Add(dLeague[i]);
                    league.Add(dLeague[i + 16]);
                }

                league.Sort();
                for (int i = 0; i < league.Count; i++)
                    league[i].SetSeed(i);
                southernConference.Sort();
                northernConference.Sort();

                southernConferenceWinners = new List<Tuple<int, NewTeam>>();
                southerConferenceLosers = new List<Tuple<int, NewTeam>>();
                northernConferenceWinners = new List<Tuple<int, NewTeam>>();
                northernConferenceLosers = new List<Tuple<int, NewTeam>>();

                for (int i = 0; i < 8; i++)
                {
                    southernConferenceWinners.Add(new Tuple<int, NewTeam>(i + 1, southernConference[i]));
                    southerConferenceLosers.Add(new Tuple<int, NewTeam>(i + 9, southernConference[i + 8]));

                    northernConferenceWinners.Add(new Tuple<int, NewTeam>(i + 1, northernConference[i]));
                    northernConferenceLosers.Add(new Tuple<int, NewTeam>(i + 9, northernConference[i + 8]));
                }

                dLeagueWinners = new NewPlayoffs(southernConferenceWinners, northernConferenceWinners, 1, false, true);
                dLeagueLosers = new NewPlayoffs(southerConferenceLosers, northernConferenceLosers, 17, false, true);
            }

            winners.DoNextRound();
            losers.DoNextRound();
            dLeagueWinners.DoNextRound();
            dLeagueLosers.DoNextRound();

            
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
    [Serializable]
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
    [Serializable]
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
