using System;
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
    public class DraftClass
    {
        private Dictionary<uint, DraftablePlayer> players;
        private List<GeneralManager> scouts;
        private List<DraftablePlayer> draftables;
        private int totalPlayers;
        public DraftClass()
        {
            players = new Dictionary<uint, DraftablePlayer>();

            totalPlayers = League.r.Next(124, 160);
            GeneratePlayers();

            scouts = new List<GeneralManager>();

            foreach (NewTeam t in League.league)
            {
                scouts.Add(t.GetScout());
                t.GetScout().SetNewInformation(players, League.r);
            }
        }
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public static void SerializeObject(DraftClass serializableObject, string fileName)
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
        public static DraftClass DeSerializeObject(string fileName)
        {
            DraftClass temp = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream(fileName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                temp = (DraftClass)formatter.Deserialize(fs);
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
            return temp;
        }
        public void ReplaceScout(int teamNum)
        {
            scouts[teamNum].SetNewInformation(players, League.r);
        }
        public List<DraftablePlayer> GetDraftablePlayers()
        {
            return draftables;
        }
        public Dictionary<uint, DraftablePlayer> GetDraftablePlayersDictionary()
        {
            return players;
        }
        public GeneralManager GetScout(int teamNum)
        {
            return scouts[teamNum];
        }
        
        private void GeneratePlayers()
        {
            draftables = new List<DraftablePlayer>();
            int eightyOveralls = (int)Math.Round(League.r.NextDoubleGaussian(1.25, .5));

            NameGenerator gen = NameGenerator.Instance();

            for (int i = 0; i < eightyOveralls; i++)
            {
                string story = null;

                double overall = 80;

                int randNum = League.r.Next(10);
                if (randNum < 5)
                    overall += League.r.NextDouble();
                else if(randNum < 7)
                    overall += 1 + League.r.NextDouble();
                else if (randNum < 8)
                    overall += 2 + League.r.NextDouble();
                else if (randNum < 9)
                    overall += 3 + League.r.NextDouble();
                else
                    overall += 4 + League.r.NextDouble();

                double maxOverall = overall;

                randNum = League.r.Next(10);
                if (randNum < 3)
                    maxOverall += League.r.Next(5, 10) + League.r.NextDouble();
                else if (randNum < 5)
                    maxOverall += League.r.Next(5, 15) + League.r.NextDouble();
                else if (randNum < 7)
                    maxOverall += League.r.Next(10, 15) + League.r.NextDouble();
                else if (randNum < 9)
                    maxOverall += League.r.Next(10, 20) + League.r.NextDouble();
                else
                {
                    maxOverall += League.r.Next(20, 30) + League.r.NextDouble();
                    story = "This is an ideal looking prospect";
                }

                int age;

                randNum = League.r.Next(10);

                if (randNum == 0)
                    age = 18;
                else if (randNum < 4)
                    age = 19;
                else if (randNum < 7)
                    age = 20;
                else
                    age = 14 + randNum;

                Tuple<Country, string> tuple = gen.GenerateName();

                draftables.Add(GeneratePlayer(overall, maxOverall, age, tuple.Item2, tuple.Item1, story));
            }
            int seventyOveralls = (int)Math.Round(League.r.NextDoubleGaussian(16.25, 1.5));

            for (int i = 0; i < seventyOveralls; i++)
            {
                string story = null;

                double overall = 70;

                int randNum = League.r.Next(10);
                if (randNum < 5)
                    overall += League.r.NextDouble();
                else if (randNum < 7)
                    overall += 1 + League.r.NextDouble();
                else if (randNum < 8)
                    overall += 2 + League.r.NextDouble();
                else if (randNum < 9)
                    overall += 3 + League.r.NextDouble();
                else
                    overall += 4 + League.r.NextDouble();

                double maxOverall = overall;

                randNum = League.r.Next(10);
                if (randNum < 3)
                    maxOverall += League.r.Next(5, 10) + League.r.NextDouble();
                else if (randNum < 5)
                    maxOverall += League.r.Next(5, 15) + League.r.NextDouble();
                else if (randNum < 7)
                    maxOverall += League.r.Next(10, 15) + League.r.NextDouble();
                else if (randNum < 9)
                    maxOverall += League.r.Next(10, 20) + League.r.NextDouble();
                else
                {
                    maxOverall += League.r.Next(20, 30) + League.r.NextDouble();
                }

                int age;

                randNum = League.r.Next(10);

                if (randNum == 0)
                    age = 18;
                else if (randNum < 4)
                    age = 19;
                else if (randNum < 7)
                    age = 20;
                else
                    age = 14 + randNum;

                Tuple<Country, string> tuple = gen.GenerateName();

                draftables.Add(GeneratePlayer(overall, maxOverall, age, tuple.Item2, tuple.Item1, story));
            }
            for(int i = 0; i < totalPlayers - seventyOveralls - eightyOveralls;i++)
            {
                string story = null;

                double overall = (int)Math.Round(League.r.NextDoubleGaussian(58, 5.5));

                int randNum = League.r.Next(10);
                if (randNum < 5)
                    overall += League.r.NextDouble();
                else if (randNum < 7)
                    overall += 1 + League.r.NextDouble();
                else if (randNum < 8)
                    overall += 2 + League.r.NextDouble();
                else if (randNum < 9)
                    overall += 3 + League.r.NextDouble();
                else
                    overall += 4 + League.r.NextDouble();

                double maxOverall = overall;

                randNum = League.r.Next(10);
                if (randNum < 2)
                    maxOverall += League.r.Next(5, 10) + League.r.NextDouble();
                else if (randNum < 4)
                    maxOverall += League.r.Next(5, 15) + League.r.NextDouble();
                else if (randNum < 6)
                    maxOverall += League.r.Next(10, 15) + League.r.NextDouble();
                else if (randNum < 8)
                    maxOverall += League.r.Next(10, 20) + League.r.NextDouble();
                else
                {
                    maxOverall += League.r.Next(20, 30) + League.r.NextDouble();
                }

                int age;

                randNum = League.r.Next(10);

                if (randNum == 0)
                    age = 18;
                else if (randNum < 4)
                    age = 19;
                else if (randNum < 7)
                    age = 20;
                else
                    age = 14 + randNum;

                Tuple<Country, string> tuple = gen.GenerateName();

                draftables.Add(GeneratePlayer(overall, maxOverall, age, tuple.Item2, tuple.Item1, story));
            }
        }
        private DraftablePlayer GeneratePlayer(double overall, double maxOverall, int age, string name, Country country, string story)
        {
            int position = League.r.Next(1, 6);
            byte[] ratings = new byte[11];
            ratings = NewPlayerEditor.UpdateUntil(overall, ratings, position);
            ratings[10] = (byte)League.r.Next(10, 100);
            byte[] maxRatings = new byte[11];
            for (int i = 0; i < ratings.Length; i++)
                maxRatings[i] = ratings[i];

            maxRatings = NewPlayerEditor.UpdateUntil(maxOverall, maxRatings, position);

            DraftablePlayer player = new DraftablePlayer(name, country, ratings, maxRatings, age, position, story);

            uint nextID = League.league.NextID++;

            players.Add(nextID, player);

            return player;
        }
        public string GetCombinedRanking(int teamNum = -1)
        {
            if (teamNum == -1)
            {
                foreach (GeneralManager scout in scouts)
                    scout.SortPlayers(0);

                return GetRanking();
            }
            else
            {
                scouts[teamNum].SortPlayers(0);
                return PrintTeamRatings(scouts[teamNum]);
            }
        }
        public string GetRatingRanking(int teamNum = -1)
        {
            if (teamNum == -1)
            {
                foreach (GeneralManager scout in scouts)
                    scout.SortPlayers(1);

                return GetRanking();
            }
            else
            {
                scouts[teamNum].SortPlayers(1);
                return PrintTeamRatings(scouts[teamNum]);
            }
        }
        public string GetMaxRatingRanking(int teamNum = -1)
        {
            if (teamNum == -1)
            {
                foreach (GeneralManager scout in scouts)
                    scout.SortPlayers(2);

                return GetRanking();
            }
            else
            {
                scouts[teamNum].SortPlayers(2);
                return PrintTeamRatings(scouts[teamNum]);
            }
        }
        private string PrintTeamRatings(GeneralManager scout)
        {
            string retVal = "Team List";
            List<PlayerItem> scoutsPlayers = scout.GetPlayers();
            foreach (PlayerItem player in scoutsPlayers)
            {
                retVal += "\n" + players[player.GetPlayerID()].ToString();
            }
            return retVal;
        }
        private string GetRanking()
        {
            Dictionary<uint, double> allPlayers = new Dictionary<uint, double>();

            string retVal = "Player List";
            foreach (GeneralManager scout in scouts)
            {
                List<PlayerItem> scoutsPlayers = scout.GetPlayers();
                for (int i = 0; i < scoutsPlayers.Count; i++)
                {
                    uint id = scoutsPlayers[i].GetPlayerID();
                    if (allPlayers.ContainsKey(id))
                        allPlayers[id] += i + 1;
                    else
                        allPlayers.Add(id, i + 1);
                }
            }
            List<DraftablePlayer> finalRank = new List<DraftablePlayer>();
            List<double> scores = new List<double>();

            foreach (KeyValuePair<uint, double> pair in allPlayers)
            {
                bool inserted = false;
                for (int i = 0; i < finalRank.Count; i++)
                {
                    if (scores[i] > pair.Value / 32.0)
                    {
                        scores.Insert(i, pair.Value / 32.0);
                        finalRank.Add(players[pair.Key]);
                        inserted = true;
                        break;
                    }
                }
                if (!inserted)
                {
                    scores.Add(pair.Value / 32.0);
                    finalRank.Add(players[pair.Key]);
                }
            }
            uint firstID = 1389;
            foreach (DraftablePlayer player in finalRank)
            {
                player.SetPlayerID(firstID);                
                retVal += "\n" + player.GetName() + "," + firstID;
                firstID++;
            }
            return retVal;
        }
    }
    [Serializable]
    public class PlayerItem : IComparable<PlayerItem>
    {
        private double rating, maxRating, combinedRating;
        private int sortNumber, position;
        private uint playerID;
        public PlayerItem(uint playerID, double rating, double maxRating, double combinedRating)
        {
            this.playerID = playerID;
            this.rating = rating;
            this.maxRating = maxRating;
            this.combinedRating = combinedRating;
        }
        public void SetPlayerIDAndPositon(uint newPlayerID, int position)
        {
            playerID = newPlayerID;
            this.position = position;
        }
        public uint GetPlayerID()
        {
            return playerID;
        }
        public void RedoCombinedRank(double combinedRatingNum)
        {
            double ratingNum = rating * combinedRatingNum;
            double maxRatingNum = maxRating * (1 - combinedRatingNum);
            combinedRating = ratingNum + maxRatingNum;
        }
        public void SetSortNumber(int sortNumber)
        {
            this.sortNumber = sortNumber;
        }
        public int CompareTo(PlayerItem other)
        {
            if (other == null)
                return 1;

            switch (sortNumber)
            {
                default:
                    return other.combinedRating.CompareTo(combinedRating);
                case 1:
                    return other.rating.CompareTo(rating);
                case 2:
                    return other.maxRating.CompareTo(maxRating);
            }

        }
        public double GetCombinedDouble()
        {
            return combinedRating;
        }
        public string GetCombinedScore()
        {
            string retVal;

            if (combinedRating > 85)
                retVal = "Elite Prospect";
            else if (combinedRating > 75)
                retVal = "Good Prospect";
            else if (combinedRating > 65)
                retVal = "Average Prospect";
            else if (combinedRating > 55)
                retVal = "Below Average Prospect";
            else
                retVal = "Complete Bum";

            return retVal;
        }
        public double GetRatingDouble()
        {
            return rating;
        }
        public string GetRatingScore()
        {
            string retVal;

            if (rating > 85)
                retVal = "Quality Starter";
            else if (rating > 75)
                retVal = "Starter";
            else if (rating > 62.5)
                retVal = "Backup";
            else if (rating > 50)
                retVal = "D League Player";
            else
                retVal = "Complete Bum";

            return retVal;
        }
        public double GetCeilingDouble()
        {
            return maxRating;
        }
        public string GetCeilingScore()
        {
            string retVal;

            if (maxRating > 95)
                retVal = "Super Star";
            else if (maxRating > 85)
                retVal = "Quality Starter";
            else if (maxRating > 77.5)
                retVal = "Decent Starter";
            else if (maxRating > 67.5)
                retVal = "Quality Backup";
            else if (maxRating > 60)
                retVal = "Situational Backup";
            else
                retVal = "Complete Bum";

            return retVal;
        }
    }
    [Serializable]
    public class DraftablePlayer : IComparable<DraftablePlayer>
    {
        private NewPlayer p;
        private double ratingsModifiers, maxRatingsModifiers;
        private byte[] ratings, maxRatings;
        private List<string> stories;
        private int position, type, age;
        private string name;
        private Country country;
        private uint playerID;
        public DraftablePlayer(string name, Country country, byte[] ratings, byte[] maxRatings, int age, int position, string story)
        {
            stories = new List<string>();

            this.name = name;
            this.country = country;

            this.age = age;
            this.ratings = ratings;
            this.maxRatings = maxRatings;

            this.position = position;

            if(story != null)
                stories.Add(story);
        }
        public void ResetDraft()
        {
            drafted = false;
        }
        public void SetPlayerID(uint playerID)
        {
            this.playerID = playerID;
        }
        public uint GetPlayerID()
        {
            return playerID;
        }
        public void AddStory(string story)
        {
            stories.Add(story);
        }
        public void SetComparisonType(int type)
        {
            this.type = type;
        }
        public string GetName()
        {
            return name;
        }
        public void ReplaceName(Tuple<Country, string> newName)
        {
            name = newName.Item2;
            country = newName.Item1;
        }
        public Country GetCountry()
        {
            return country;
        }
        public int GetAge()
        {
            return age;
        }
        public int GetPosition()
        {
            return position;
        }
        public byte[] GetRatings()
        {
            return ratings;
        }
        public byte[] GetMaxRatings()
        {
            return maxRatings;
        }
        public double GetRating()
        {
            return NewPlayerEditor.GetMainOverall(position, ratings);
        }
        public double GetMaxRating()
        {
            return NewPlayerEditor.GetMainOverall(position, maxRatings);
        }
        public int CompareTo(DraftablePlayer other)
        {
            switch(type)
            {
                case 0:
                    double result = (NewPlayerEditor.GetMainOverall(position, ratings) + ratingsModifiers) - (NewPlayerEditor.GetMainOverall(other.position, other.ratings) + other.ratingsModifiers);
                    if (result > 0)
                        return -1;
                    else if (result < 0)
                        return 1;
                    else return 0;
                case 1:
                    result = (NewPlayerEditor.GetMainOverall(position, maxRatings) + maxRatingsModifiers) - (NewPlayerEditor.GetMainOverall(other.position, other.maxRatings) + other.maxRatingsModifiers);
                    if (result > 0)
                        return -1;
                    else if (result < 0)
                        return 1;
                    else return 0;
                case 2:
                    result = (NewPlayerEditor.GetMainOverall(position, maxRatings) + maxRatingsModifiers) - (NewPlayerEditor.GetMainOverall(other.position, other.maxRatings) + other.maxRatingsModifiers);
                    result += (NewPlayerEditor.GetMainOverall(position, ratings) + ratingsModifiers) - (NewPlayerEditor.GetMainOverall(other.position, other.ratings) + other.ratingsModifiers);

                    result /= 2;
                    
                    if (result > 0)
                        return -1;
                    else if (result < 0)
                        return 1;
                    else return 0;
                default:
                    return 0;
            }
            
        }
        public string GetPositionAsString()
        {
            switch (position)
            {
                case 1:
                    return "C";
                case 2:
                    return "PF";
                case 3:
                    return "SF";
                case 4:
                    return "SG";
                case 5:
                    return "PG";
            }
            return "ERROR";
        }
        private bool drafted;
        public NewPlayer Draft(int pickNumber)
        {
            byte peakStart = (byte)League.r.Next(26, 30), peakEnd = (byte)(peakStart + League.r.Next(1, 5)), development;

            double money = 0;

            if (pickNumber == -1)
            {
                if (League.r.Next(75) == 15)
                {
                    development = 10;                    
                }
                else
                {
                    int rand = League.r.Next(80);

                    if (rand < 7)
                        development = 1;
                    else if (rand < 15)
                        development = 2;
                    else if (rand < 25)
                        development = 3;
                    else if (rand < 35)
                        development = 4;
                    else if (rand < 50)
                        development = 5;
                    else if (rand < 60)
                        development = 6;
                    else if (rand < 70)
                        development = 7;
                    else if (rand < 75)
                        development = 8;
                    else
                        development = 9;
                }
                
            }
            else if(pickNumber < 32)
            {                
                int rand = League.r.Next(90);

                if (rand < 3)
                    development = 1;
                else if (rand < 7)
                    development = 2;
                else if (rand < 12)
                    development = 3;
                else if (rand < 20)
                    development = 4;
                else if (rand < 30)
                    development = 5;
                else if (rand < 50)
                    development = 6;
                else if (rand < 70)
                    development = 7;
                else if (rand < 80)
                    development = 8;
                else if (rand < 85)
                    development = 9;
                else
                    development = 10;

                switch(pickNumber)
                {
                    case 1:
                        money = 10;
                        break;
                    case 2:
                        money = 8.5;
                        break;
                    case 3:
                        money = 8;
                        break;
                    case 4:
                        money = 7.5;
                        break;
                    case 5:
                        money = 7;
                        break;
                    case 6:
                        money = 6.5;
                        break;
                    case 7:
                        money = 6;
                        break;
                    case 8:
                        money = 5.5;
                        break;
                    default:
                        money = 5;
                        break;
                }
                    
            }
            else
            {                
                int rand = League.r.Next(75);

                if (rand < 5)
                    development = 1;
                else if (rand < 10)
                    development = 2;
                else if (rand < 17)
                    development = 3;
                else if (rand < 25)
                    development = 4;
                else if (rand < 35)
                    development = 5;
                else if (rand < 45)
                    development = 6;
                else if (rand < 55)
                    development = 7;
                else if (rand < 70)
                    development = 8;
                else if (rand < 73)
                    development = 9;
                else
                    development = 10;

                money = 1;
            }

            NewPlayer p = new NewPlayer(playerID, (byte)position, name, ratings, maxRatings, country, (byte)age, peakStart, peakEnd, development);

            if (pickNumber != -1)
                p.SetContract(new Contract(2, money));

            drafted = true;
            return p;
        }
        public bool IsDrafted()
        {
            return drafted;
        }
    }
}
