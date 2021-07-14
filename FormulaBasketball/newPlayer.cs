using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    [Serializable]
    public class NewPlayer : IComparable<NewPlayer> , IComparable
    {

        public byte[] ratings;
        public byte[] maxRatings;
        private byte seasonStarts;
        private sbyte team;
        private GameStats currentGame;
        private List<GameStats> seasonStats;
        private List<SeasonStats> playerCareerStats;
        private String name;
        private uint playerID;
        private bool injured, retired;
        private byte position, age, peakStart, peakEnd, development;
        private float stamina;
        private Contract contract;
        private Country country;
        public NewPlayer(player oldPlayer)
        {
            ratings = new byte[oldPlayer.ratings.Length];
            // Inside Scoring
            ratings[0] = (byte)Math.Max(oldPlayer.ratings[0], oldPlayer.ratings[1]);
            // Jumpshot
            ratings[1] = (byte)oldPlayer.ratings[2];
            // Three Point
            ratings[2] = (byte)oldPlayer.ratings[9];
            // Offense IQ
            ratings[3] = (byte)((oldPlayer.ratings[4] + (oldPlayer.ratings[5] + oldPlayer.ratings[7]) / 2 + oldPlayer.ratings[6]) / 3);
            // Defense IQ
            ratings[4] = (byte)oldPlayer.ratings[4];
            // Shot Contest
            ratings[5] = (byte)oldPlayer.ratings[3];
            // Jumping
            ratings[6] = (byte)oldPlayer.ratings[5];
            // Seperation
            ratings[7] = (byte)oldPlayer.ratings[6];
            // Passing
            ratings[8] = (byte)oldPlayer.ratings[7];
            // Stamina
            ratings[9] = (byte)oldPlayer.ratings[8];
            // Durability
            ratings[10] = (byte)oldPlayer.ratings[10];

            country = oldPlayer.GetCountry();

            maxRatings = new byte[ratings.Length];

            if (oldPlayer.maxRatings == null)
            {
                for (int i = 0; i < maxRatings.Length; i++)
                    maxRatings[i] = ratings[i];
            }
            else
            {
                for (int i = 0; i < maxRatings.Length; i++)
                    maxRatings[i] = i > oldPlayer.maxRatings.Length ? (byte)oldPlayer.maxRatings[i] : ratings[i];
            }
            name = oldPlayer.getName().Trim();
            seasonStarts = 0;
            stamina = 100;

            contract = oldPlayer.GetContract();

            age = (byte)oldPlayer.age;
            peakStart = (byte)oldPlayer.peakStart;
            peakEnd = (byte)oldPlayer.peakEnd;
            development = (byte)oldPlayer.development;
            retired = oldPlayer.GetRetired();

            List<SeasonStatsHolder> oldCareerStats = oldPlayer.GetCareerStats();

            playerCareerStats = new List<SeasonStats>();
            if (oldCareerStats != null)
            {
                foreach (SeasonStatsHolder oldStat in oldCareerStats)
                    playerCareerStats.Add(new SeasonStats(oldStat));
            }

            seasonStats = new List<GameStats>();

            team = -1;

            if (playerID == 571)
                position = 1;
            else if (playerID == 210)
                position = 2;
            else
                position = (byte)oldPlayer.getPosition();
            injured = false;

            
        }
        public void ChangePosition(byte newPosition)
        {
            position = newPosition;
        }
        public NewPlayer(uint playerID, byte position, string name, byte[] ratings, byte[] maxRatings, Country country, byte age, byte peakStart, byte peakEnd, byte development)
        {
            this.ratings = ratings;

            this.country = country;

            this.maxRatings = maxRatings;
            
            this.name = name;
            seasonStarts = 0;
            stamina = 100;

            this.age = age;
            this.peakStart = peakStart;
            this.peakEnd = peakEnd;
            this.development = development;
            retired = false;

            List<SeasonStatsHolder> oldCareerStats = new List<SeasonStatsHolder>();

            playerCareerStats = new List<SeasonStats>();
            
            seasonStats = new List<GameStats>();

            this.playerID = playerID;

            team = -1;

            injured = false;

            this.position = position;
        }
        // To be called when the offseason is over.
        public void FinishOffseason()
        {
            seasonStarts = 0;
            playerCareerStats.Add(new SeasonStats(seasonStats));
            seasonStats = new List<GameStats>();
        }
        public void AddSeasonStats(int seasonNum, string stats)
        {
            playerCareerStats.Add(new SeasonStats(stats, seasonNum));
        }
        public SeasonStats GetSeasonStats(int seasonNum)
        {
            foreach (SeasonStats stats in playerCareerStats)
            {
                if (stats.season == seasonNum)
                    return stats;
            }
            return null;
        }
        public Contract GetContract()
        {
            return contract;
        }
        public void SetContract(Contract contract)
        {
            this.contract = contract;
        }
        public void SetTeam(team team)
        {
            this.team = (sbyte)team.getTeamNum();
        }
        public void Retire()
        {
            retired = true;
            League.league.RetirePlayer(this);
        }
        public void SetTeam(NewTeam team)
        {
            this.team = team.GetTeamNum();
        }
        public void SetTeam(int teamNum)
        {
            team = (sbyte)teamNum;
        }
        public int GetTeam()
        {
            return team;
        }
        public int GetSecondsUntilSubstituion()
        {
            return 0;
        }
        public uint GetPlayerID()
        {
            return playerID;
        }
        public bool IsInjured()
        {
            return injured;
        }
        public byte GetPosition()
        {
            return position;
        }
        public bool IsRetired()
        {
            return retired;
        }
        public int GetPeakStart()
        {
            return peakStart;
        }
        public int GetPeakEnd()
        {
            return peakEnd;
        }
        public int GetDevelopment()
        {
            return development;
        }
        public void AdvanceYear()
        {
            age++;
            if (contract != null)
                contract.AdvanceYear();
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
        public void TimePassed(ref float stamina, int seconds, bool didPlay)
        {
            float value;

            if (didPlay)
                value = -.085f + (0.0003f * (float)GetStaminaRating(true, false) + -0.03f);
            else
                value = .035f + (float)GetStaminaRating(true, false) * .001f;


            stamina += value * seconds;

            if (stamina > 100)
                stamina = 100;

        }
        public int GetMaxMinutes()
        {
            float startingStamina = stamina;

            TimePassed(ref startingStamina, 12 * 60, true);

            int retVal = 0;

            return retVal;
        }
        public bool CanPlay()
        {
            return currentGame == null || (currentGame.GetFouls() != 6 && !injured);
        }
        public byte GetAge()
        {
            return age;
        }
        private int offers, status;
        public int GetOffers()
        {
            return offers;
        }
        public void SetOffers(int offers)
        {
            this.offers = offers;
        }            
        public int GetStatus()
        {
            return status;
        }
        public void SetStatus(int status)
        {
            this.status = status;
        }
        public string GetCeilingAsString()
        {
            string potential = "";

            int average = Math.Max(1, Math.Min(10, (int)Math.Floor(.2 * NewPlayerEditor.GetMainOverall(position, maxRatings) - 9)));
            switch (average)
            {
                case 1:
                    potential = "F";
                    break;
                case 2:
                    potential = "F+";
                    break;
                case 3:
                    potential = "D";
                    break;
                case 4:
                    potential = "D+";
                    break;
                case 5:
                    potential = "C";
                    break;
                case 6:
                    potential = "C+";
                    break;
                case 7:
                    potential = "B";
                    break;
                case 8:
                    potential = "B+";
                    break;
                case 9:
                    potential = "A";
                    break;
                case 10:
                    potential = "A+";
                    break;
            }
            return potential;
        }

        public string GetDevelopmentAsString()
        {
            string potential = "";
            int normalizedPS = (peakStart - 27) * 2;
            int normalizedPE = (peakEnd - 30) * 2;

            int average = Math.Max(1, Math.Min(10, (int)Math.Round((normalizedPE + normalizedPS + development * 3.5f) / 5.0f)));

            switch (average)
            {
                case 1:
                    potential = "F";
                    break;
                case 2:
                    potential = "F+";
                    break;
                case 3:
                    potential = "D";
                    break;
                case 4:
                    potential = "D+";
                    break;
                case 5:
                    potential = "C";
                    break;
                case 6:
                    potential = "C+";
                    break;
                case 7:
                    potential = "B";
                    break;
                case 8:
                    potential = "B+";
                    break;
                case 9:
                    potential = "A";
                    break;
                case 10:
                    potential = "A+";
                    break;
            }
            return potential;
        }
        public string GetText()
        {
            return playerID + "," + GetPositionAsString() + "," + name + "," + ratings[0] + "," + ratings[1] + "," + ratings[2] + "," + ratings[3] + "," + ratings[4] + "," + ratings[5] + "," + ratings[6] + "," + ratings[7] + "," + ratings[8] + "," + ratings[9] + "," + ratings[10]  + "," + string.Format("{0:N2}", GetBestOverall()) + "," + age  + "," + GetDevelopmentAsString() + "," + ((contract != null) ? contract.GetYearsLeft() + "," + string.Format("{0:N2}", contract.GetMoney()) : ",") + (injured ? ",Injured\n" : ",Healthy\n");
        }
        public string GetName()
        {
            return name;
        }
        public override string ToString()
        {
            return GetPositionAsString() + " " + name;
        }
        #region Ratings
        /*
        * Ratings: 
        * 
        * ratings[0] = inside
        * ratings[1] = jumpshot
        * ratings[2] = three point
        * ratings[3] = offense iq
        * ratings[4] = defense iq
        * ratings[5] = shot contest
        * ratings[6] = jumping
        * ratings[7] = seperation
        * ratings[8] = passing
        * ratings[9] = stamina
        * ratings[10] = durability
        */
        public double GetInsideRating(bool game, bool clutchSituation)
        {
            if (game)
                return ratings[0] * 0.2171 * Math.Log(stamina);
            return ratings[0];
        }
        public double GetJumpShotRating(bool game, bool clutchSituation)
        {
            if (game)
                return ratings[1] * 0.2171 * Math.Log(stamina);
            return ratings[1];
        }
        public double GetThreePointRating(bool game, bool clutchSituation)
        {
            if (game)
                return ratings[2] * 0.2171 * Math.Log(stamina);
            return ratings[2];
        }
        public double GetOffenseIQRating(bool game, bool clutchSituation)
        {
            if (game)
                return ratings[3] * 0.2171 * Math.Log(stamina);
            return ratings[3];
        }
        public double GetDefenseIQRating(bool game, bool clutchSituation)
        {
            if (game)
                return ratings[4] * 0.2171 * Math.Log(stamina);
            return ratings[4];
        }
        public double GetShotContestRating(bool game, bool clutchSituation)
        {
            if (game)
                return ratings[5] * 0.2171 * Math.Log(stamina);
            return ratings[5];
        }
        public double GetJumpingRating(bool game, bool clutchSituation)
        {
            if (game)
                return ratings[6] * 0.2171 * Math.Log(stamina);
            return ratings[6];
        }
        public double GetSeperationRating(bool game, bool clutchSituation)
        {
            if (game)
                return ratings[7] * 0.2171 * Math.Log(stamina);
            return ratings[7];
        }
        public double GetPassingRating(bool game, bool clutchSituation)
        {
            if (game)
                return ratings[8] * 0.2171 * Math.Log(stamina);
            return ratings[8];
        }
        public double GetStaminaRating(bool game, bool clutchSituation)
        {
            return ratings[9];
        }

        public void SetStats(int playerIndex, NewPlayer[] opposingPlayer, NewTeam opposingTeam, int points)
        {            
            while(points != 0)
            {
                int type = 0;

                if(points > 1)
                {
                    int[] chance = new int[3] { 25, 61 ,0};

                    if (points > 2)
                    {
                        if (ratings[2] < 35)
                            chance[2] = 2;
                        else if (ratings[2] < 48)
                            chance[2] = 4;
                        else if (ratings[2] < 60)
                            chance[2] = 7;
                        else if (ratings[2] < 72)
                            chance[2] = 10;
                        else if (ratings[2] < 84)
                            chance[2] = 15;
                        else
                            chance[2] = 20;
                    }
                    int sum = 0;
                    foreach (int i in chance)
                        sum += i;

                    int rNum = League.r.Next(sum), currSum = 0;
                    for (int i = 0; i < chance.Length; i++)
                    {
                        if(rNum < currSum + chance[i])
                        {
                            type = i;
                            break;
                        }
                        currSum += chance[i];
                    }

                }

                switch(type)
                {
                    default:
                        currentGame.AddFreeThrows(1, 1);
                        points--;
                        break;
                    case 1:
                        currentGame.AddFieldGoalMade();
                        points -= 2;
                        break;
                    case 2:
                        currentGame.AddThreeMade();
                        points -= 3;
                        break;
                }
            }                
        }

        public double GetDurabilityRating(bool game, bool clutchSituation)
        {
            if (game)
                return ratings[10] * 0.2171 * Math.Log(stamina);
            return ratings[10];
        }
        public void ChangeRating(int index, byte newRating)
        {
            ratings[index] = newRating;
        }
        #endregion

        #region Stats
        public byte GetStarts()
        {
            return seasonStarts;
        }
        public void StartGame(bool starter, int opponent)
        {
            // Ignores this if already a starter
            if(currentGame == null || starter)
            {
                currentGame = new GameStats(team, opponent);
                if (starter)
                    seasonStarts++;
            }
        }
        public void EndGame()
        {
            seasonStats.Add(currentGame);
            currentGame = null;
            stamina += 20;

            if (stamina > 100)
                stamina = 100;

        }
        public int GetPoints()
        {
            return currentGame.GetPoints();
        }
        public void AddSteal()
        {
            currentGame.AddSteal();
        }
        public void AddTurnover()
        {
            currentGame.AddTurnover();
        }
        public void AddFreeThrows(int attempted, int made)
        {
            currentGame.AddFreeThrows(attempted, made);
        }
        public int AddFouls(int fouls, int quarter)
        {
            int currFouls = currentGame.GetFouls();
            int maxFouls = quarter <= 3 ? 5 : 6;

            if(currFouls + fouls <= maxFouls)
            {
                currentGame.AddFouls((byte)fouls);
                return fouls;
            }
            else
            {
                currentGame.AddFouls((byte)(maxFouls - currFouls));
                return maxFouls - currFouls;
            }
        }
        public void AddBlock()
        {
            currentGame.AddBlock();
        }
        public void AddRebounds(bool offensive)
        {
            if (offensive)
                currentGame.AddOffensiveRebound();
            else
                currentGame.AddDefensiveRebound();
        }
        public byte AddThreePointer(bool made)
        {            
            if(made)
            {
                currentGame.AddThreeMade();
                return 3;
            }
            currentGame.AddThreeAttempted();
            return 0;
        }
        public byte AddTwoPointer(bool made)
        {
            if (made)
            {
                currentGame.AddFieldGoalMade();
                return 2;
            }
            currentGame.AddFieldGoalAttempted();
            return 0;
        }
        public void AddThreePointerAgainst(bool made)
        {
            if (made)            
                currentGame.AddThreeMadeAgainst();
            else
                currentGame.AddThreePointerAgainst();

        }
        public void AddTwoPointerAgainst(bool made)
        {
            if (made)            
                currentGame.AddFieldGoalMadeAgainst();
            else
                currentGame.AddFieldGoalAttemptedAgainst();
        }
        public void AddAssist()
        {
            currentGame.AddAssist();
        }
        public void AddMinutes(int minutes)
        {
            currentGame.AddMinutes(minutes);
        }
        public GameStats GetGameStats()
        {
            return currentGame;
        }
        public GameStats GetStats()
        {
            return seasonStats[seasonStats.Count - 1];
        }
        #endregion

        #region Overalls
        public double GetRatingAsCenter(bool staminaAffected)
        {
            if (staminaAffected)
                return GetRatingAsCenterStamina();
            else
                return GetRatingAsCenter();
        }
        public double GetRatingAsPowerForward(bool staminaAffected)
        {
            if (staminaAffected)
                return GetRatingAsPowerForwardStamina();
            else
                return GetRatingAsPowerForward();
        }

        public double GetRatingAsSmallForward(bool staminaAffected)
        {
            if (staminaAffected)
                return GetRatingAsSmallForwardStamina();
            else
                return GetRatingAsSmallForward();
        }
        public double GetRatingAsShootingGuard(bool staminaAffected)
        {
            if (staminaAffected)
                return GetRatingAsShootingGuardStamina();
            else
                return GetRatingAsShootingGuard();
        }
        public double GetRatingAsPointGuard(bool staminaAffected)
        {
            if (staminaAffected)
                return GetRatingAsPointGuardStamina();
            else
                return GetRatingAsPointGuard();
        }
        private double GetRatingAsCenter()
        {
            double retVal = ratings[0] * 1.5;
            retVal += ratings[1] * 0.7;
            retVal += ratings[2] * 0.5;
            retVal += ratings[3] * 1.3;
            retVal += ratings[4] * 1.3;
            retVal += ratings[5] * 1.3;
            retVal += ratings[6] * 1.5;
            retVal += ratings[7] * 1;
            retVal += ratings[8] * 0.4;
            retVal += ratings[9] * 0.5;

            if (position == 2)
                retVal *= .9;
            else if (position == 3)
                retVal *= .85;
            else if (position > 3)
                retVal *= .75;
                
            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);
 
            return retVal;
        }       
        private double GetRatingAsCenterStamina()
        {
            double retVal = GetInsideRating(true, false) * 1.5;
            retVal += GetJumpShotRating(true, false) * 0.7;
            retVal += GetThreePointRating(true, false) * 0.5;
            retVal += GetOffenseIQRating(true, false) * 1.3;
            retVal += GetDefenseIQRating(true, false) * 1.3;
            retVal += GetShotContestRating(true, false) * 1.3;
            retVal += GetJumpingRating(true, false) * 1.5;
            retVal += GetSeperationRating(true, false) * 1;
            retVal += GetPassingRating(true, false) * 0.4;
            retVal += GetStaminaRating(true, false) * 0.5;

            if (position == 2)
                retVal *= .9;
            else if (position == 3)
                retVal *= .85;
            else if (position > 3)
                retVal *= .75;

            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);

            return retVal;
        }
        private double GetRatingAsPowerForward()
        {
            double retVal = ratings[0] * 1.3;
            retVal += ratings[1] * 0.8;
            retVal += ratings[2] * 0.6;
            retVal += ratings[3] * 1.3;
            retVal += ratings[4] * 1.3;
            retVal += ratings[5] * 1.3;
            retVal += ratings[6] * 1.2;
            retVal += ratings[7] * 1;
            retVal += ratings[8] * 0.7;
            retVal += ratings[9] * 0.5;

            if (position == 1 || position == 3)
                retVal *= .9;
            else if (position == 4)
                retVal *= .85;
            else if (position == 5)
                retVal *= .75;

            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);

            return retVal;
        }
        private double GetRatingAsPowerForwardStamina()
        {
            double retVal = GetInsideRating(true, false) * 1.3;
            retVal += GetJumpShotRating(true, false) * 0.8;
            retVal += GetThreePointRating(true, false) * 0.6;
            retVal += GetOffenseIQRating(true, false) * 1.3;
            retVal += GetDefenseIQRating(true, false) * 1.3;
            retVal += GetShotContestRating(true, false) * 1.3;
            retVal += GetJumpingRating(true, false) * 1.2;
            retVal += GetSeperationRating(true, false) * 1;
            retVal += GetPassingRating(true, false) * 0.7;
            retVal += GetStaminaRating(true, false) * 0.5;

            if (position == 1 || position == 3)
                retVal *= .9;
            else if (position == 4)
                retVal *= .85;
            else if (position == 5)
                retVal *= .75;

            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);

            return retVal;
        }
        private double GetRatingAsSmallForward()
        {
            double retVal = ratings[0] * 1.2;
            retVal += ratings[1] * 1.2;
            retVal += ratings[2] * 0.8;
            retVal += ratings[3] * 1.3;
            retVal += ratings[4] * 1.3;
            retVal += ratings[5] * 1.3;
            retVal += ratings[6] * 0.6;
            retVal += ratings[7] * 1;
            retVal += ratings[8] * 0.8;
            retVal += ratings[9] * 0.5;

            if (position == 2 || position == 4)
                retVal *= .9;
            else if (position == 1 || position == 5)
                retVal *= .85;

            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);

            return retVal;
        }
        private double GetRatingAsSmallForwardStamina()
        {
            double retVal = GetInsideRating(true, false) * 1.2;
            retVal += GetJumpShotRating(true, false) * 1.2;
            retVal += GetThreePointRating(true, false) * 0.8;
            retVal += GetOffenseIQRating(true, false) * 1.3;
            retVal += GetDefenseIQRating(true, false) * 1.3;
            retVal += GetShotContestRating(true, false) * 1.3;
            retVal += GetJumpingRating(true, false) * .6;
            retVal += GetSeperationRating(true, false) * 1;
            retVal += GetPassingRating(true, false) * 0.8;
            retVal += GetStaminaRating(true, false) * 0.5;

            if (position == 2 || position == 4)
                retVal *= .9;
            else if (position == 1 || position == 5)
                retVal *= .85;

            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);

            return retVal;
        }

        public void FixMaxRatings()
        {
            if (age >= peakStart)
                return;

            double overall = GetMainOverall();

            if (League.r.Next(15) == 3)
            {
                overall += League.r.Next(2, 5);
            }
            else if(League.r.Next(7) == 3)
            {
                overall += League.r.Next(25, 35);
            }
            else
            {
                int ageDiff = Math.Min(10, peakStart - age) - 1;
                double ageModifier = ageDiff * .1 + .5;

                double overallModifier = -0.02 * overall + 2.7;

                double developmentModifier = development / 6 + (1 / 3);

                int randNum = League.r.Next(-5, 6);

                int increaseMin = (int)Math.Round(randNum - 2 * ageModifier * overallModifier * developmentModifier);
                int increaseMax = (int)Math.Round(randNum + 2 * ageModifier * overallModifier * developmentModifier);

                overall += League.r.Next(increaseMin, increaseMax);
            }   

            maxRatings = NewPlayerEditor.UpdateUntil(overall, maxRatings, position);
        }
        private double GetRatingAsShootingGuard()
        {
            double retVal = ratings[0] * 0.8;
            retVal += ratings[1] * 1.2;
            retVal += ratings[2] * 1.1;
            retVal += ratings[3] * 1.3;
            retVal += ratings[4] * 1.3;
            retVal += ratings[5] * 1.3;
            retVal += ratings[6] * 0.5;
            retVal += ratings[7] * 1;
            retVal += ratings[8] * 1;
            retVal += ratings[9] * 0.5;

            if (position == 3 || position == 5)
                retVal *= .9;
            else if (position == 2)
                retVal *= .85;
            else if (position == 1)
                retVal *= .75;

            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);

            return retVal;
        }
        private double GetRatingAsShootingGuardStamina()
        {
            double retVal = GetInsideRating(true, false) * 0.8;
            retVal += GetJumpShotRating(true, false) * 1.2;
            retVal += GetThreePointRating(true, false) * 1.1;
            retVal += GetOffenseIQRating(true, false) * 1.3;
            retVal += GetDefenseIQRating(true, false) * 1.3;
            retVal += GetShotContestRating(true, false) * 1.3;
            retVal += GetJumpingRating(true, false) * .5;
            retVal += GetSeperationRating(true, false) * 1;
            retVal += GetPassingRating(true, false) * 1;
            retVal += GetStaminaRating(true, false) * 0.5;

            if (position == 3 || position == 5)
                retVal *= .9;
            else if (position == 2)
                retVal *= .85;
            else if (position == 1)
                retVal *= .75;

            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);

            return retVal;
        }
        private double GetRatingAsPointGuard()
        {
            double retVal = ratings[0] * 0.7;
            retVal += ratings[1] * 1.1;
            retVal += ratings[2] * 1.1;
            retVal += ratings[3] * 1.3;
            retVal += ratings[4] * 1.3;
            retVal += ratings[5] * 1.3;
            retVal += ratings[6] * 0.3;
            retVal += ratings[7] * 1;
            retVal += ratings[8] * 1.4;
            retVal += ratings[9] * 0.5;

            if (position == 4)
                retVal *= .9;
            else if (position == 3)
                retVal *= .85;
            else if (position < 3)
                retVal *= .75;

            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);

            return retVal;
        }
        private double GetRatingAsPointGuardStamina()
        {
            double retVal = GetInsideRating(true, false) * .7;
            retVal += GetJumpShotRating(true, false) * 1.1;
            retVal += GetThreePointRating(true, false) * 1.1;
            retVal += GetOffenseIQRating(true, false) * 1.3;
            retVal += GetDefenseIQRating(true, false) * 1.3;
            retVal += GetShotContestRating(true, false) * 1.3;
            retVal += GetJumpingRating(true, false) * .3;
            retVal += GetSeperationRating(true, false) * 1;
            retVal += GetPassingRating(true, false) * 1.4;
            retVal += GetStaminaRating(true, false) * 0.5;

            if (position == 4)
                retVal *= .9;
            else if (position == 3)
                retVal *= .85;
            else if (position < 3)
                retVal *= .75;

            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);

            return retVal;
        }
        public double GetBestOverall()
        {
            double overall = GetRatingAsCenter();

            double temp = GetRatingAsPowerForward();

            if (overall < temp)
                overall = temp;

            temp = GetRatingAsSmallForward();

            if (overall < temp)
                overall = temp;

            temp = GetRatingAsShootingGuard();

            if (overall < temp)
                overall = temp;

            temp = GetRatingAsPointGuard();

            if (overall < temp)
                overall = temp;

            return overall;
        }
        public double GetMainOverall()
        {
            switch(position)
            {
                case 1:
                    return GetRatingAsCenter();
                case 2:
                    return GetRatingAsPowerForward();
                case 3:
                    return GetRatingAsSmallForward();
                case 4:
                    return GetRatingAsShootingGuard();
                case 5:
                    return GetRatingAsPointGuard();
            }
            return 0;
        }
        public double GetMaxOverall()
        {
            switch (position)
            {
                case 1:
                    return NewPlayerEditor.GetRatingAsCenter(maxRatings);
                case 2:
                    return NewPlayerEditor.GetRatingAsPowerForward(maxRatings);
                case 3:
                    return NewPlayerEditor.GetRatingAsSmallForward(maxRatings);
                case 4:
                    return NewPlayerEditor.GetRatingAsShootingGuard(maxRatings);
                case 5:
                    return NewPlayerEditor.GetRatingAsPointGuard(maxRatings);
            }
            return 0;
        }
        public int CompareTo(Object other)
        {
            if (other is NewPlayer)
                return CompareTo(other as NewPlayer);
            else return 0;
        }
        public int CompareTo(NewPlayer other)
        {
            double result = GetBestOverall() - other.GetBestOverall();
            if (result > 0)
                return -1;
            else if (result < 0)
                return 1;
            else return 0;
        }
        #endregion
    }
}
