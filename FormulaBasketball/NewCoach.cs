using EnumsNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FormulaBasketball
{
    [Serializable]
    public class NewRealCoach : IComparable<NewRealCoach>
    {
        private OffenseType offense;
        private DefenseType defense;
        private PersonnelType personnel;
        private Personality personality;
        private string name, skill, maxRatingBoost, development;
        private Country country;
        private Contract contract;
        private int teamNum, age, coachID;
        private int[] developmentSkills, maxRatingBoostLocation, skillBoosts;
        private List<Record> records;
        public NewRealCoach(string name, Country country, OffenseType offense, DefenseType defense, PersonnelType personnel, Personality personality, int age, int coachID, string development, string skill, string maxRatingBoost)
        {
            this.offense = offense;
            this.defense = defense;
            this.personnel = personnel;
            this.country = country;
            this.name = name;
            this.personality = personality;
            this.age = age;
            this.coachID = coachID;
            this.skill = skill;
            this.maxRatingBoost = maxRatingBoost;
            this.development = development;

            UpdateSkills();
        }
        public void VerifyCoach()
        {
            if (contract == null)
                teamNum = -1;
        }
        public int GetAge()
        {
            return age;
        }
        public int GetTeam()
        {
            return teamNum;
        }
        public void AdvanceYear(Record record)
        {
            age++;
            if(record != null)
            {
                if (records == null)
                    records = new List<Record>();
                records.Add(record);
                contract.AdvanceYear();
            }
            
        }
        public byte GetMaxRatingBoosts(int i)
        {
            return (byte)maxRatingBoostLocation[i];
        }
        public void UpdateSkills()
        {
            developmentSkills = new int[] { 1, 1, 1, 1, 1};
            maxRatingBoostLocation = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            skillBoosts = new int[] { 1, 1, 1, 1, 1, 1 };
            

            int value = Util.ConvertLetterToNumber(development) * 10;
            value += League.r.Next(10) - 5;

            value = (Math.Max(5, Math.Min(100, value)) / 2) - 5;

            while(value > 0)
            {
                int num = League.r.Next(5);

                if (developmentSkills[num] < 10)
                {
                    developmentSkills[num]++;
                    value--;
                }
            }

            value = Util.ConvertLetterToNumber(maxRatingBoost) * 10;
            value += League.r.Next(10) - 5;

            value = (Math.Max(10, Math.Min(100, value))) - 10;

            while (value > 0)
            {
                int num = League.r.Next(10);

                if (maxRatingBoostLocation[num] < 10)
                {
                    maxRatingBoostLocation[num]++;
                    value--;
                }
            }

            value = Util.ConvertLetterToNumber(skill) * 10;
            value += League.r.Next(10) - 5;

            value = ((Math.Max(10, Math.Min(100, value)) * 3) / 5) - 7;

            while (value > 0)
            {
                int num = League.r.Next(10);

                if(num < 5)
                {
                    if (skillBoosts[num] < 10)
                    {
                        skillBoosts[num]++;
                        value--;
                    }
                }
                else if(skillBoosts[5] != 10)
                {
                    skillBoosts[5]++;
                    value--;                    
                }  
            }

            records = new List<Record>();
        }       
        public int GetCoachID()
        {
            return coachID;
        }
        public static NewPlayer[] GetDefensivePositioning(NewPlayer[] offense, NewPlayer[] defense)
        {
            NewPlayer[] retVal = new NewPlayer[5];

            List<NewPlayer>[] players = new List<NewPlayer>[5] { new List<NewPlayer>(), new List<NewPlayer>(), new List<NewPlayer>(), new List<NewPlayer>(), new List<NewPlayer>() };
            List<Tuple<NewPlayer, double>>[]    defensePlayers = new List<Tuple<NewPlayer, double>>[5] { new List<Tuple<NewPlayer, double>>(), new List<Tuple<NewPlayer, double>>(), new List<Tuple<NewPlayer, double>>(), new List<Tuple<NewPlayer, double>>(), new List<Tuple<NewPlayer, double>>() };
            for (int i = 0; i < offense.Length; i++)
            {
                if(offense[i] != null)
                    players[offense[i].GetPosition() - 1].Add(offense[i]);
                if(defense[i] != null)
                    defensePlayers[defense[i].GetPosition() - 1].Add(new Tuple<NewPlayer, double>(defense[i], (defense[i].GetDefenseIQRating(true, false) + defense[i].GetShotContestRating(true, false)) / 2.0));
            }
            for (int i = 0; i < players.Length; i++)
            {
                players[i].Sort();
                defensePlayers[i].Sort((x, y) => y.Item2.CompareTo(x.Item2));
            }
            bool flag = true;
            for (int i = 0; i < players.Length; i++)
            {
                if(players[i].Count > defensePlayers[i].Count)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                for(int i = 0; i < offense.Length; i++)
                {
                    for(int j = 0; j < players.Length; j++)
                    {
                        for(int k = 0; k < players[j].Count; k++)
                        {
                            if(offense[i] != null && offense[i].GetPlayerID() == players[j][k].GetPlayerID())
                                retVal[i] = defensePlayers[j][k].Item1;
                        }
                    }
                }
            }
            else
            {
                int[] num = new int[5];
                for (int i = 0; i < offense.Length; i++)
                {
                    int temp = 0;
                    for (int j = 0; j < players.Length; j++)
                    {
                        for (int k = 0; k < players[j].Count; k++)
                        {
                            if (offense[i] != null && offense[i].GetPlayerID() == players[j][k].GetPlayerID())
                            {
                                num[i] = temp;
                            }
                            temp++;
                        }
                    }
                }
                bool[] flags = new bool[5];
                for (int k = 0; k < offense.Length; k++)
                {
                    flag = false;
                    int temp = 0;
                    for (int i = 0; i < defensePlayers.Length; i++)
                    {
                        if (flag)
                            continue;
                        for (int j = 0; j < defensePlayers[i].Count; j++)
                        {
                            if(retVal[num[k]] == null && !flags[temp])
                            {
                                retVal[num[k]] = defensePlayers[i][j].Item1;
                                flags[temp] = true;
                                flag = true;
                                continue;
                            }
                            temp++;
                        }
                    }
                }

            }
            return retVal;        
        }
        public double[] GetQuarterDistribution(int num)
        {
            int[] probabilites = new int[] { 15 + skillBoosts[0], 15 + skillBoosts[1], 15 + skillBoosts[2], 15 + skillBoosts[3]};

            int sum = 60 + skillBoosts[0] + skillBoosts[1] + skillBoosts[2] + skillBoosts[3];

            switch (num)
            {
                default:
                    sum = 100 - sum;
                    int temp = sum / 3;
                    probabilites[0] += temp;
                    sum -= temp;
                    temp = (int)Math.Round(sum * .6);
                    probabilites[3] += temp;
                    sum -= temp;
                    temp = sum / 2;
                    probabilites[2] += temp;
                    sum -= temp;
                    temp = sum;
                    probabilites[1] += temp;
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            double[] retVal = new double[] { probabilites[0] / 100.0, probabilites[1] / 100.0, probabilites[2] / 100.0, probabilites[3] / 100.0 };
            return retVal;
        }
        public int GetQuarterBoost(int quarterNum)
        {
            if (quarterNum < 5)
                return skillBoosts[quarterNum];
            return -1;
        }
        public int GetSkill(int skill)
        {
            return skillBoosts[skill];            
        }
        public int GetDevelopmentSkillForPosition(int pos)
        {
            pos--;
            return developmentSkills[pos];
        }

        public Country GetCountry()
        {
            return country;
        }
        public void SetTeam(Contract contract, int teamNum)
        {
            this.contract = contract;
            this.teamNum = teamNum;
        }
        public OffenseType GetOffense()
        {
            return offense;
        }
        public DefenseType GetDefense()
        {
            return defense;
        }
        public Personality GetPersonality()
        {
            return personality;
        }
        public PersonnelType GetPersonnel()
        {
            return personnel;
        }
        public Contract GetContract()
        {
            return contract;
        }
        public override string ToString()
        {
            return name;
        }

        private static double GetCoachOverall(NewRealCoach coach)
        {
            //5, 10, 6
            // 7, 3.5, 6.5
            double overall = 0;

            foreach(double skill in coach.developmentSkills)
            {
                overall += (skill / 10.0) * 7.0;
            }
            foreach (double skill in coach.maxRatingBoostLocation)
            {
                overall += (skill / 10.0) * 3.5;
            }
            foreach (double skill in coach.skillBoosts)
            {
                overall += (skill / 10.0) * 6.5;
            }

            return overall;

        }

        public int CompareTo(NewRealCoach other)
        {
            double firstOverall = GetCoachOverall(this);
            double secondOverall = GetCoachOverall(other);

            if (secondOverall > firstOverall)
                return 1;
            else if (secondOverall == firstOverall)
                return 0;
            else return -1;
        }

        public int[] GetPointDistribution(NewPlayer[] currentPlayers, NewPlayer[] opposingPlayers)
        {
            Dictionary<uint, int> pointDistribution = new Dictionary<uint, int>();
            foreach(NewPlayer p in currentPlayers)
            {
                if(p != null)
                    pointDistribution.Add(p.GetPlayerID(), 20);
            }
            List<NewPlayer> playersByOverall = new List<NewPlayer>();

            foreach (NewPlayer p in currentPlayers)
                if(p != null)
                    playersByOverall.Add(p);

            playersByOverall.Sort();

            pointDistribution[playersByOverall[0].GetPlayerID()] += 50;
            pointDistribution[playersByOverall[1].GetPlayerID()] += 35;
            if(playersByOverall.Count > 2)
                pointDistribution[playersByOverall[2].GetPlayerID()] += 20;
            if(playersByOverall.Count > 3)
                pointDistribution[playersByOverall[3].GetPlayerID()] += 10;

            

            for(int i = 0; i < opposingPlayers.Length; i++)
            {
                if (currentPlayers[i] == null)
                    continue;

                if(opposingPlayers[i] == null)
                {                    
                    pointDistribution[currentPlayers[i].GetPlayerID()] += 5;
                    continue;
                }
                double defense = (opposingPlayers[i].GetShotContestRating(true, false) + opposingPlayers[i].GetDefenseIQRating(true, false)) / 2.0;
                if (defense > 95)
                    pointDistribution[currentPlayers[i].GetPlayerID()] -= 20;
                else if(defense > 90)
                    pointDistribution[currentPlayers[i].GetPlayerID()] -= 15;
                else if (defense > 80)
                    pointDistribution[currentPlayers[i].GetPlayerID()] -= 10;
                else if (defense > 70)
                    pointDistribution[currentPlayers[i].GetPlayerID()] += 5;
                else if (defense > 60)
                    pointDistribution[currentPlayers[i].GetPlayerID()] += 20;
                else if (defense > 50)
                    pointDistribution[currentPlayers[i].GetPlayerID()] += 35;
                else
                    pointDistribution[currentPlayers[i].GetPlayerID()] += 50;
            }

            int[] retVal = new int[5];

            for(int i = 0; i < retVal.Length;i++)
            {
                if(currentPlayers[i] != null)
                    retVal[i] = Math.Max(5, pointDistribution[currentPlayers[i].GetPlayerID()] + League.r.Next(-10, 11));
            }

            return retVal;
        }
    }
    public static class CoachHelper
    {
        public static string DistributeStats(NewTeam team, OffenseType offense)
        {
            string retVal = team.ToString() + ",Player Names,GP,GS,MIN,PTS,OR,DR,AST,STL,BLK,TO,PF,+/-\n";

            NewPlayer[] idealStarters = GetStarters(team, offense);

            double pointsPerGame = team.GetPointsFor() / 84.0;

            List<NewPlayer> backups = new List<NewPlayer>(team.GetPlayers());
            List<NewPlayer> orderedStarters = new List<NewPlayer>();
            foreach(NewPlayer p in idealStarters)
            {
                backups.Remove(p);
                orderedStarters.Add(p);
            }

            orderedStarters.Sort();

            NewPlayer[] topBackups = GetStarters(backups, offense);
                        
            Dictionary<uint, double[]> stats = new Dictionary<uint, double[]>();

            foreach(NewPlayer p in team)
            {
                stats.Add(p.GetPlayerID(), new double[12]);
            }


            double overallDiff;
            for (int i= 0; i < 5; i++)
            {
                overallDiff = (idealStarters[i].GetMainOverall() - topBackups[i].GetMainOverall());

                if(overallDiff > 7.5)
                {
                    stats[idealStarters[i].GetPlayerID()][0] = 84;
                    stats[idealStarters[i].GetPlayerID()][1] = 84;
                    stats[idealStarters[i].GetPlayerID()][2] = Math.Round(League.r.NextDoubleGaussian(33 + (.6 * overallDiff) - 3, 1.8), 1);

                    stats[topBackups[i].GetPlayerID()][0] = 84;
                    stats[topBackups[i].GetPlayerID()][1] = 0;
                    stats[topBackups[i].GetPlayerID()][2] = 48 - stats[idealStarters[i].GetPlayerID()][2];

                    switch(idealStarters[i].GetPosition())
                    {
                        case 1:
                            stats[idealStarters[i].GetPlayerID()][4] = Math.Round(League.r.NextDoubleGaussian(1.5, .3), 1);
                            stats[idealStarters[i].GetPlayerID()][5] = Math.Round(League.r.NextDoubleGaussian(10, .75), 1);
                            stats[idealStarters[i].GetPlayerID()][6] = Math.Round(League.r.NextDoubleGaussian(1, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][7] = Math.Round(League.r.NextDoubleGaussian(.4, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][8] = Math.Round(League.r.NextDoubleGaussian(2, .35), 1);
                            stats[idealStarters[i].GetPlayerID()][9] = Math.Round(League.r.NextDoubleGaussian(2, .3), 1);
                            stats[idealStarters[i].GetPlayerID()][10] = Math.Round(League.r.NextDoubleGaussian(2.5, .3), 1);
                            break;
                        case 2:
                            stats[idealStarters[i].GetPlayerID()][4] = Math.Round(League.r.NextDoubleGaussian(.8, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][5] = Math.Round(League.r.NextDoubleGaussian(7, .75), 1);
                            stats[idealStarters[i].GetPlayerID()][6] = Math.Round(League.r.NextDoubleGaussian(1.7, .2), 1);
                            stats[idealStarters[i].GetPlayerID()][7] = Math.Round(League.r.NextDoubleGaussian(.6, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][8] = Math.Round(League.r.NextDoubleGaussian(1, .2), 1);
                            stats[idealStarters[i].GetPlayerID()][9] = Math.Round(League.r.NextDoubleGaussian(2, .3), 1);
                            stats[idealStarters[i].GetPlayerID()][10] = Math.Round(League.r.NextDoubleGaussian(2.5, .3), 1);
                            break;
                        case 3:
                            stats[idealStarters[i].GetPlayerID()][4] = Math.Round(League.r.NextDoubleGaussian(.5, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][5] = Math.Round(League.r.NextDoubleGaussian(5, .5), 1);
                            stats[idealStarters[i].GetPlayerID()][6] = Math.Round(League.r.NextDoubleGaussian(4, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][7] = Math.Round(League.r.NextDoubleGaussian(.9, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][8] = Math.Round(League.r.NextDoubleGaussian(.5, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][9] = Math.Round(League.r.NextDoubleGaussian(2, .3), 1);
                            stats[idealStarters[i].GetPlayerID()][10] = Math.Round(League.r.NextDoubleGaussian(2.5, .3), 1);
                            break;
                        case 4:
                            stats[idealStarters[i].GetPlayerID()][4] = Math.Round(League.r.NextDoubleGaussian(.5, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][5] = Math.Round(League.r.NextDoubleGaussian(4, .75), 1);
                            stats[idealStarters[i].GetPlayerID()][6] = Math.Round(League.r.NextDoubleGaussian(5, .5), 1);
                            stats[idealStarters[i].GetPlayerID()][7] = Math.Round(League.r.NextDoubleGaussian(.8, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][8] = Math.Round(League.r.NextDoubleGaussian(.2, .05), 1);
                            stats[idealStarters[i].GetPlayerID()][9] = Math.Round(League.r.NextDoubleGaussian(2, .3), 1);
                            stats[idealStarters[i].GetPlayerID()][10] = Math.Round(League.r.NextDoubleGaussian(2.5, .3), 1);
                            break;
                        case 5:
                            stats[idealStarters[i].GetPlayerID()][4] = Math.Round(League.r.NextDoubleGaussian(.5, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][5] = Math.Round(League.r.NextDoubleGaussian(3, .5), 1);
                            stats[idealStarters[i].GetPlayerID()][6] = Math.Round(League.r.NextDoubleGaussian(5.5, .6), 1);
                            stats[idealStarters[i].GetPlayerID()][7] = Math.Round(League.r.NextDoubleGaussian(.8, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][8] = Math.Round(League.r.NextDoubleGaussian(.2, .05), 1);
                            stats[idealStarters[i].GetPlayerID()][9] = Math.Round(League.r.NextDoubleGaussian(2, .3), 1);
                            stats[idealStarters[i].GetPlayerID()][10] = Math.Round(League.r.NextDoubleGaussian(2.5, .3), 1);
                            break;
                    }
                    for(int j = 4; j < 11; j++)
                    {
                        stats[topBackups[i].GetPlayerID()][j] = Math.Round(stats[idealStarters[i].GetPlayerID()][j] * League.r.NextDoubleGaussian(.35, .15), 1);
                    }
                }
                else
                {
                    double starts = (overallDiff * .06)  + .5;

                    stats[idealStarters[i].GetPlayerID()][0] = 84;
                    stats[idealStarters[i].GetPlayerID()][1] = (int)Math.Round(84 * starts);
                    stats[idealStarters[i].GetPlayerID()][2] = Math.Round(League.r.NextDoubleGaussian(30, 1.2), 1);

                    stats[topBackups[i].GetPlayerID()][0] = 84;
                    stats[topBackups[i].GetPlayerID()][1] = 84- stats[idealStarters[i].GetPlayerID()][1];
                    stats[topBackups[i].GetPlayerID()][2] = 48 - stats[idealStarters[i].GetPlayerID()][2];

                    switch (idealStarters[i].GetPosition())
                    {
                        case 1:
                            stats[idealStarters[i].GetPlayerID()][4] = Math.Round(League.r.NextDoubleGaussian(1.3, .3), 1);
                            stats[idealStarters[i].GetPlayerID()][5] = Math.Round(League.r.NextDoubleGaussian(7, .75), 1);
                            stats[idealStarters[i].GetPlayerID()][6] = Math.Round(League.r.NextDoubleGaussian(.8, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][7] = Math.Round(League.r.NextDoubleGaussian(.2, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][8] = Math.Round(League.r.NextDoubleGaussian(1.5, .35), 1);
                            stats[idealStarters[i].GetPlayerID()][9] = Math.Round(League.r.NextDoubleGaussian(1.7, .3), 1);
                            stats[idealStarters[i].GetPlayerID()][10] = Math.Round(League.r.NextDoubleGaussian(2.2, .3), 1);
                            break;
                        case 2:
                            stats[idealStarters[i].GetPlayerID()][4] = Math.Round(League.r.NextDoubleGaussian(.6, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][5] = Math.Round(League.r.NextDoubleGaussian(5, .75), 1);
                            stats[idealStarters[i].GetPlayerID()][6] = Math.Round(League.r.NextDoubleGaussian(1.4, .2), 1);
                            stats[idealStarters[i].GetPlayerID()][7] = Math.Round(League.r.NextDoubleGaussian(.4, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][8] = Math.Round(League.r.NextDoubleGaussian(.8, .2), 1);
                            stats[idealStarters[i].GetPlayerID()][9] = Math.Round(League.r.NextDoubleGaussian(1.7, .3), 1);
                            stats[idealStarters[i].GetPlayerID()][10] = Math.Round(League.r.NextDoubleGaussian(2.2, .3), 1);
                            break;
                        case 3:
                            stats[idealStarters[i].GetPlayerID()][4] = Math.Round(League.r.NextDoubleGaussian(.3, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][5] = Math.Round(League.r.NextDoubleGaussian(4, .5), 1);
                            stats[idealStarters[i].GetPlayerID()][6] = Math.Round(League.r.NextDoubleGaussian(3.4, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][7] = Math.Round(League.r.NextDoubleGaussian(.7, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][8] = Math.Round(League.r.NextDoubleGaussian(.4, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][9] = Math.Round(League.r.NextDoubleGaussian(1.5, .3), 1);
                            stats[idealStarters[i].GetPlayerID()][10] = Math.Round(League.r.NextDoubleGaussian(1.8, .3), 1);
                            break;
                        case 4:
                            stats[idealStarters[i].GetPlayerID()][4] = Math.Round(League.r.NextDoubleGaussian(.3, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][5] = Math.Round(League.r.NextDoubleGaussian(2.8, .75), 1);
                            stats[idealStarters[i].GetPlayerID()][6] = Math.Round(League.r.NextDoubleGaussian(3, .5), 1);
                            stats[idealStarters[i].GetPlayerID()][7] = Math.Round(League.r.NextDoubleGaussian(.6, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][8] = Math.Round(League.r.NextDoubleGaussian(.15, .05), 1);
                            stats[idealStarters[i].GetPlayerID()][9] = Math.Round(League.r.NextDoubleGaussian(1.7, .3), 1);
                            stats[idealStarters[i].GetPlayerID()][10] = Math.Round(League.r.NextDoubleGaussian(2.3, .3), 1);
                            break;
                        case 5:
                            stats[idealStarters[i].GetPlayerID()][4] = Math.Round(League.r.NextDoubleGaussian(.4, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][5] = Math.Round(League.r.NextDoubleGaussian(2, .5), 1);
                            stats[idealStarters[i].GetPlayerID()][6] = Math.Round(League.r.NextDoubleGaussian(4.5, .6), 1);
                            stats[idealStarters[i].GetPlayerID()][7] = Math.Round(League.r.NextDoubleGaussian(.6, .1), 1);
                            stats[idealStarters[i].GetPlayerID()][8] = Math.Round(League.r.NextDoubleGaussian(.15, .05), 1);
                            stats[idealStarters[i].GetPlayerID()][9] = Math.Round(League.r.NextDoubleGaussian(1, .3), 1);
                            stats[idealStarters[i].GetPlayerID()][10] = Math.Round(League.r.NextDoubleGaussian(1.75, .3), 1);
                            break;
                    }
                    for (int j = 4; j < 11; j++)
                    {
                        stats[topBackups[i].GetPlayerID()][j] = Math.Round(stats[idealStarters[i].GetPlayerID()][j] * League.r.NextDoubleGaussian(.6, .15), 1);
                    }
                }              


            }
            overallDiff = (orderedStarters[0].GetMainOverall() - orderedStarters[1].GetMainOverall());

            if (overallDiff > 5)
            {
                double currPoints = pointsPerGame;
                double pointsAmount = Math.Round(League.r.NextDoubleGaussian(pointsPerGame / 3, 1.5), 1);
                stats[orderedStarters[0].GetPlayerID()][3] = pointsAmount;
                currPoints -= pointsAmount;

                for (int i = 1; i < 5; i++)
                {
                    pointsAmount = Math.Round(League.r.NextDoubleGaussian(pointsPerGame / (5 + (i * 1.5)), 1.5), 1);
                    stats[orderedStarters[i].GetPlayerID()][3] = pointsAmount;
                    currPoints -= pointsAmount;
                }
                pointsPerGame = currPoints;
            }
            else
            {
                double currPoints = pointsPerGame;
                double pointsAmount = Math.Round(League.r.NextDoubleGaussian(pointsPerGame / 5, 1.5), 1);
                stats[orderedStarters[0].GetPlayerID()][3] = pointsAmount;
                currPoints -= pointsAmount;

                for (int i = 1; i < 5; i++)
                {
                    pointsAmount = Math.Round(League.r.NextDoubleGaussian(pointsPerGame / (5 + (i * 1.25)), 1.5), 1);
                    stats[orderedStarters[i].GetPlayerID()][3] = pointsAmount;
                    currPoints -= pointsAmount;
                }
                pointsPerGame = currPoints;
            }

            orderedStarters.Clear();
            foreach(NewPlayer p in topBackups)
            {
                backups.Remove(p);
                orderedStarters.Add(p);
            }
            orderedStarters.Sort();

            overallDiff = (orderedStarters[0].GetMainOverall() - orderedStarters[1].GetMainOverall());

            if (overallDiff > 5)
            {
                double currPoints = pointsPerGame;
                double pointsAmount = Math.Round(League.r.NextDoubleGaussian(pointsPerGame / 3, 1.5), 1);
                stats[orderedStarters[0].GetPlayerID()][3] = pointsAmount;
                currPoints -= pointsAmount;

                for (int i = 1; i < 5; i++)
                {
                    pointsAmount = Math.Round(League.r.NextDoubleGaussian(pointsPerGame / (5 + (i * 1.5)), 1.5), 1);
                    stats[orderedStarters[i].GetPlayerID()][3] = pointsAmount;
                    currPoints -= pointsAmount;
                }
                pointsPerGame = currPoints;
            }
            else
            {
                double currPoints = pointsPerGame;
                double pointsAmount = Math.Round(League.r.NextDoubleGaussian(pointsPerGame / 5, 1.5), 1);
                stats[orderedStarters[0].GetPlayerID()][3] = pointsAmount;
                currPoints -= pointsAmount;

                for (int i = 1; i < 5; i++)
                {
                    pointsAmount = Math.Round(League.r.NextDoubleGaussian(pointsPerGame / (5 + (i * 1.25)), 1.5), 1);
                    stats[orderedStarters[i].GetPlayerID()][3] = pointsAmount;
                    currPoints -= pointsAmount;
                }
                pointsPerGame = currPoints;
            }


            team.SortPlayers();
            foreach(NewPlayer p in team)
            {
                retVal += p.GetPlayerID() + "," + p.GetName();
                foreach(double d in stats[p.GetPlayerID()])
                {
                    retVal += "," + Math.Max(0,d);
                }
                retVal += "\n";
            }

            return retVal;
        }
        public static string String(OffenseType offense)
        {
            switch(offense)
            {
                case OffenseType.BALANCED_OFFENSE:
                    return "BAL";
                case OffenseType.BIG_BALL_OFFENSE:
                    return "BBO";
                case OffenseType.PERIMETER_CENTRIC_OFFENSE:
                    return "PCO";
                case OffenseType.PICK_OFFENSE:
                    return "PIK";
                case OffenseType.PRINCETON_OFFENSE:
                    return "PRI";
                case OffenseType.SEVEN_SECOND_OFFENSE:
                    return "7SO";
                case OffenseType.SMALL_BALL_OFFENSE:
                    return "SBO";
                case OffenseType.SUPERSTAR_FIRST_OFFENSE:
                    return "SFO";
                default:
                    return null;
            }
        }
        public static string String(DefenseType defense)
        {
            switch (defense)
            {
                case DefenseType.MAN_NO_SWITCH_DEFENSE:
                    return "MNS";
                case DefenseType.MAN_SWITCH_DEFENSE:
                    return "MSW";
                case DefenseType.THREE_TWO_ZONE_DEFENSE:
                    return "32Z";
                case DefenseType.TWO_THREE_ZONE_DEFENSE:
                    return "23Z";
                case DefenseType.MATCHUP_ZONE_DEFENSE:
                    return "MUZ";               
                default:
                    return null;
            }
        }
        public static string String(PersonnelType personnel)
        {
            switch (personnel)
            {
                case PersonnelType.MATCHUP_BASED:
                    return "MUB";
                case PersonnelType.SCHEDULE_BASED:
                    return "SCH";
                case PersonnelType.STAMINA_BASED:
                    return "STA";
                case PersonnelType.STREAK_BASED:
                    return "STR";
                case PersonnelType.OVERALL_BASED:
                    return "OVR";
                default:
                    return null;
            }
        }
        public static string String(Personality personality)
        {
            switch (personality)
            {
                case Personality.INSPIRING:
                    return "INS";
                case Personality.ANALYTICAL:
                    return "ANA";
                case Personality.TEAM_LEADER:
                    return "TML";
                case Personality.LAID_BACK:
                    return "LDB";
                case Personality.PLAYERS_COACH:
                    return "PLC";
                default:
                    return null;
            }
        }
        public static OffenseType GenerateOffense()
        {
            int num = League.r.Next(100);
            if (num < 5)
                return OffenseType.BIG_BALL_OFFENSE;
            else if (num < 25)
                return OffenseType.BALANCED_OFFENSE;
            else if (num < 40)
                return OffenseType.PERIMETER_CENTRIC_OFFENSE;
            else if (num < 50)
                return OffenseType.SMALL_BALL_OFFENSE;
            else if (num < 55)
                return OffenseType.PICK_OFFENSE;
            else if (num < 70)
                return OffenseType.PRINCETON_OFFENSE;
            else if (num < 85)
                return OffenseType.SEVEN_SECOND_OFFENSE;
            else
                return OffenseType.SUPERSTAR_FIRST_OFFENSE;
        }
        public static DefenseType GenerateDefense()
        {
            int num = League.r.Next(100);
            if (num < 35)
                return DefenseType.MAN_SWITCH_DEFENSE;
            else if (num < 55)
                return DefenseType.MAN_NO_SWITCH_DEFENSE;
            else if (num < 70)
                return DefenseType.TWO_THREE_ZONE_DEFENSE;
            else if (num < 80)
                return DefenseType.THREE_TWO_ZONE_DEFENSE;            
            else
                return DefenseType.MATCHUP_ZONE_DEFENSE;
        }
        public static PersonnelType GeneratePersonnel()
        {
            int num = League.r.Next(100);            
            if (num < 10)
                return PersonnelType.MATCHUP_BASED;
            else if (num < 15)
                return PersonnelType.OVERALL_BASED;
            else if (num < 40)
                return PersonnelType.STREAK_BASED;
            else if (num < 70)
                return PersonnelType.SCHEDULE_BASED;
            else
                return PersonnelType.STAMINA_BASED;
        }
        public static Personality GeneratePersonality()
        {
            int num = League.r.Next(100);
            if (num < 20)
                return Personality.ANALYTICAL;
            else if (num < 40)
                return Personality.LAID_BACK;
            else if (num < 60)
                return Personality.PLAYERS_COACH;
            else if (num < 80)
                return Personality.TEAM_LEADER;
            else
                return Personality.INSPIRING;
        }
        public static string GenerateDevelopmentRating()
        {
            return Util.ConvertNumberToLetter(Math.Max(1, Math.Min(10, League.r.NextGaussian(5))));
        }
        public static string GenerateSkillRating()
        {
            return Util.ConvertNumberToLetter(Math.Max(1, Math.Min(10, League.r.NextGaussian(5))));
        }
        public static string GenerateMaxRatingBoost()
        {
            return Util.ConvertNumberToLetter(Math.Max(1, Math.Min(10, League.r.NextGaussian(5))));
        }

        public static NewPlayer[] GetStarters(IEnumerable<NewPlayer> team, OffenseType offense, NewTeam opponent = null)
        {            
            switch(offense)
            {
                case OffenseType.BALANCED_OFFENSE:
                    return BalancedStarters(team, opponent);
                case OffenseType.BIG_BALL_OFFENSE:
                    return BigBallStarters(team, opponent);
                case OffenseType.PERIMETER_CENTRIC_OFFENSE:
                    return PerimeterCentricStarters(team, opponent);
                case OffenseType.PICK_OFFENSE:
                    return PickStarters(team, opponent);
                case OffenseType.PRINCETON_OFFENSE:
                    return PrincetonStarters(team, opponent);
                case OffenseType.SEVEN_SECOND_OFFENSE:
                    return SevenSecondStarters(team, opponent);
                case OffenseType.SMALL_BALL_OFFENSE:
                    return SmallBallStarters(team, opponent);
                case OffenseType.SUPERSTAR_FIRST_OFFENSE:
                    return SuperstarFirstStarters(team, opponent);
                default:
                    return null;
            }
        }
        private static NewPlayer[] PerimeterCentricStarters(IEnumerable<NewPlayer> team, NewTeam opponent)
        {
            NewPlayer[] actualStarters = new NewPlayer[5];
            int counter = 0;
            double overallBest = 0;
            while (counter < 5)
            {
                NewPlayer[] starters = new NewPlayer[5];
                int loc = counter;
                double totalBest = 0;
                for (int i = 0; i < starters.Length; i++)
                {
                    int temp = (loc + i) % 5;
                    if (starters[temp] == null)
                    {
                        double bestrating = 0;
                        NewPlayer currBest = null;
                        switch (temp)
                        {
                            case 0:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsCenter(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsCenter(false);
                                        }
                                    }
                                }
                                break;
                            case 1:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPowerForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPowerForward(false);
                                        }
                                    }
                                }
                                break;
                            case 2:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsSmallForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsSmallForward(false);
                                        }
                                    }
                                }
                                break;
                            case 3:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsShootingGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsShootingGuard(false);
                                        }
                                    }
                                }
                                break;
                            case 4:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPointGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPointGuard(false);
                                        }
                                    }
                                }
                                break;
                        }

                        starters[temp] = currBest;
                        totalBest += bestrating;
                    }
                    if (overallBest < totalBest)
                    {
                        overallBest = totalBest;
                        actualStarters = starters;
                    }
                }
                counter++;
            }
            return actualStarters;
        }
        private static NewPlayer[] PickStarters(IEnumerable<NewPlayer> team, NewTeam opponent)
        {
            NewPlayer[] actualStarters = new NewPlayer[5];
            for(int i = 0; i < actualStarters.Length; i++)
            {
                double bestrating = 0;
                NewPlayer currBest = null;
                foreach(NewPlayer p in team)
                {
                    if (p.GetBestOverall() > bestrating)
                    {
                        bool flag = false;
                        for (int j = 0; j < actualStarters.Length; j++)
                        {
                            if (actualStarters[j] != null && actualStarters[j].GetPlayerID() == p.GetPlayerID())
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            currBest = p;
                            bestrating = p.GetBestOverall();
                        }
                    }
                    
                }
                actualStarters[i] = currBest;
            }
            return actualStarters;
        }
        private static NewPlayer[] PrincetonStarters(IEnumerable<NewPlayer> team, NewTeam opponent)
        {
            NewPlayer[] actualStarters = new NewPlayer[5];
            int counter = 0;
            double overallBest = 0;
            while (counter < 5)
            {
                NewPlayer[] starters = new NewPlayer[5];
                int loc = counter;
                double totalBest = 0;
                for (int i = 0; i < starters.Length; i++)
                {
                    int temp = (loc + i) % 5;
                    if (starters[temp] == null)
                    {
                        double bestrating = 0;
                        NewPlayer currBest = null;
                        switch (temp)
                        {
                            case 0:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsCenter(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsCenter(false);
                                        }
                                    }
                                }
                                break;
                            case 1:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPowerForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPowerForward(false);
                                        }
                                    }
                                }
                                break;
                            case 2:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsSmallForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsSmallForward(false);
                                        }
                                    }
                                }
                                break;
                            case 3:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsShootingGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsShootingGuard(false);
                                        }
                                    }
                                }
                                break;
                            case 4:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPointGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPointGuard(false);
                                        }
                                    }
                                }
                                break;
                        }

                        starters[temp] = currBest;
                        totalBest += bestrating;
                    }
                    if (overallBest < totalBest)
                    {
                        overallBest = totalBest;
                        actualStarters = starters;
                    }
                }
                counter++;
            }
            return actualStarters;
        }
        private static NewPlayer[] SevenSecondStarters(IEnumerable<NewPlayer> team, NewTeam opponent)
        {
            NewPlayer[] actualStarters = new NewPlayer[5];
            int counter = 0;
            double overallBest = 0;
            while (counter < 5)
            {
                NewPlayer[] starters = new NewPlayer[5];
                int loc = counter;
                double totalBest = 0;
                for (int i = 0; i < starters.Length; i++)
                {
                    int temp = (loc + i) % 5;
                    if (starters[temp] == null)
                    {
                        double bestrating = 0;
                        NewPlayer currBest = null;
                        switch (temp)
                        {
                            case 0:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsCenter(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsCenter(false);
                                        }
                                    }
                                }
                                break;
                            case 1:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPowerForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPowerForward(false);
                                        }
                                    }
                                }
                                break;
                            case 2:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsSmallForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsSmallForward(false);
                                        }
                                    }
                                }
                                break;
                            case 3:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsShootingGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsShootingGuard(false);
                                        }
                                    }
                                }
                                break;
                            case 4:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPointGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPointGuard(false);
                                        }
                                    }
                                }
                                break;
                        }

                        starters[temp] = currBest;
                        totalBest += bestrating;
                    }
                    if (overallBest < totalBest)
                    {
                        overallBest = totalBest;
                        actualStarters = starters;
                    }
                }
                counter++;
            }
            return actualStarters;
        }
        private static NewPlayer[] BalancedStarters(IEnumerable<NewPlayer> team, NewTeam opponent)
        {
            NewPlayer[] starters = new NewPlayer[5];

            foreach(NewPlayer p in team)
            {
                NewPlayer curr = starters[p.GetPosition() - 1];
                if (curr == null || curr.GetMainOverall() < p.GetMainOverall())
                    starters[p.GetPosition() - 1] = p;
            }
            for(int i = 0; i < starters.Length; i++)
            {
                if(starters[i] == null)
                {
                    double bestrating = 0;
                    NewPlayer currBest = null;
                    switch (i)
                    {
                        case 0:
                            foreach (NewPlayer p in team)
                            {
                                if(p.GetRatingAsCenter(false) > bestrating)
                                {
                                    bool flag = false;
                                    for(int j = 0; j < starters.Length; j++)
                                    {
                                        if(starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if(!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsCenter(false);
                                    }
                                }
                            }
                            break;
                        case 1:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsPowerForward(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsPowerForward(false);
                                    }
                                }
                            }
                            break;
                        case 2:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsSmallForward(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsSmallForward(false);
                                    }
                                }
                            }
                            break;
                        case 3:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsShootingGuard(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsShootingGuard(false);
                                    }
                                }
                            }
                            break;
                        case 4:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsPointGuard(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsPointGuard(false);
                                    }
                                }
                            }
                            break;
                    }

                    starters[i] = currBest;
                }
            }

            return starters;
        }
        private static NewPlayer[] BigBallStarters(IEnumerable<NewPlayer> team, NewTeam opponent)
        {
            NewPlayer[] starters = new NewPlayer[5];

            for (int i = 0; i < starters.Length; i++)
            {
                if (starters[i] == null)
                {
                    double bestrating = 0;
                    NewPlayer currBest = null;
                    switch (i)
                    {
                        case 0:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsCenter(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsCenter(false);
                                    }
                                }
                            }
                            break;
                        case 1:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsCenter(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsCenter(false);
                                    }
                                }
                            }
                            break;
                        case 2:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsPowerForward(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsPowerForward(false);
                                    }
                                }
                            }
                            break;
                        case 3:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetBestOverall() > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetBestOverall();
                                    }
                                }
                            }
                            break;
                        case 4:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetBestOverall() > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetBestOverall();
                                    }
                                }
                            }
                            break;
                    }

                    starters[i] = currBest;
                }
            }


            return starters;
        }
        private static NewPlayer[] SuperstarFirstStarters(IEnumerable<NewPlayer> team, NewTeam opponent)
        {
            NewPlayer[] actualStarters = new NewPlayer[5];
            int counter = 0;
            double overallBest = 0;
            while (counter < 5)
            {
                NewPlayer[] starters = new NewPlayer[5];
                int loc = counter;
                double totalBest = 0;
                for (int i = 0; i < starters.Length; i++)
                {
                    int temp = (loc + i) % 5;
                    if (starters[temp] == null)
                    {
                        double bestrating = 0;
                        NewPlayer currBest = null;
                        switch (temp)
                        {
                            case 0:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsCenter(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsCenter(false);
                                        }
                                    }
                                }
                                break;
                            case 1:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPowerForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPowerForward(false);
                                        }
                                    }
                                }
                                break;
                            case 2:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsSmallForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsSmallForward(false);
                                        }
                                    }
                                }
                                break;
                            case 3:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsShootingGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsShootingGuard(false);
                                        }
                                    }
                                }
                                break;
                            case 4:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPointGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPointGuard(false);
                                        }
                                    }
                                }
                                break;
                        }

                        starters[temp] = currBest;
                        totalBest += bestrating;
                    }
                    if (overallBest < totalBest)
                    {
                        overallBest = totalBest;
                        actualStarters = starters;
                    }
                }
                counter++;
            }
            return actualStarters;
        }
        private static NewPlayer[] SmallBallStarters(IEnumerable<NewPlayer> team, NewTeam opponent)
        {
            NewPlayer[] actualStarters = new NewPlayer[5];
            int counter = 0;
            double overallBest = 0;
            while(counter < 5)
            {
                NewPlayer[] starters = new NewPlayer[5];
                int loc = counter;
                double totalBest = 0;
                for (int i = 0; i < starters.Length; i++)
                {
                    int temp = (loc + i) % 5;
                    if (starters[temp] == null)
                    {
                        double bestrating = 0;
                        NewPlayer currBest = null;
                        switch (temp)
                        {
                            case 0:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsSmallForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsSmallForward(false);
                                        }
                                    }
                                }
                                break;
                            case 1:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsShootingGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsShootingGuard(false);
                                        }
                                    }
                                }
                                break;
                            case 2:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPointGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPointGuard(false);
                                        }
                                    }
                                }
                                break;
                            case 3:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetMainOverall() > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetMainOverall();
                                        }
                                    }
                                }
                                break;
                            case 4:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetMainOverall() > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetMainOverall();
                                        }
                                    }
                                }
                                break;
                        }

                        starters[temp] = currBest;
                        totalBest += bestrating;
                    }
                    if(overallBest < totalBest)
                    {
                        overallBest = totalBest;
                        actualStarters = starters;
                    }
                }
                counter++;
            }
            


            return actualStarters;
        }
    }
    [Serializable]
    public enum OffenseType
    {
        [Description("Balanced Offense")]
        BALANCED_OFFENSE,
        [Description("Superstar First Offense")]
        SUPERSTAR_FIRST_OFFENSE,
        [Description("Seven Second Offense")]
        SEVEN_SECOND_OFFENSE,
        [Description("Perimeter Centric Offense")]
        PERIMETER_CENTRIC_OFFENSE,
        [Description("Small Ball Offense")]
        SMALL_BALL_OFFENSE,
        [Description("Big Ball Offense")]
        BIG_BALL_OFFENSE,
        [Description("Pick Offense")]
        PICK_OFFENSE,
        [Description("Princeton Offense")]
        PRINCETON_OFFENSE,

        ANY
    }
    [Serializable]
    public enum DefenseType
    {
        [Description("Man Switch")]
        MAN_SWITCH_DEFENSE,
        [Description("Man No Switch")]
        MAN_NO_SWITCH_DEFENSE,
        [Description("2-3 Zone")]
        TWO_THREE_ZONE_DEFENSE,
        [Description("3-2 Zone")]
        THREE_TWO_ZONE_DEFENSE,
        [Description("Match-Up Zone")]
        MATCHUP_ZONE_DEFENSE,

        ANY
    }
    [Serializable]
    public enum PersonnelType
    {
        [Description("Overall Based")]
        OVERALL_BASED,
        [Description("Schedule Based")]
        SCHEDULE_BASED,
        [Description("Streak Based")]
        STREAK_BASED,
        [Description("Stamina Based")]
        STAMINA_BASED,
        [Description("Matchup Based")]
        MATCHUP_BASED,

        ANY
    }
    [Serializable]
    public enum Personality
    {
        [Description("Team Leader")]
        TEAM_LEADER,
        [Description("Player's Coach")]
        PLAYERS_COACH,
        [Description("Inspiring")]
        INSPIRING,
        [Description("Analytical")]
        ANALYTICAL,
        [Description("Laid Back")]
        LAID_BACK,

        ANY
    }
    [Serializable]
    public class NewCoach
    {
        private NewOffensivePhilosophy offense;
        private NewDefensivePhilosophy defense;
        private PlayerPhilosophy personnel;
        public NewCoach(string name, NewOffensivePhilosophy offensivePersonality, NewDefensivePhilosophy defensivePersonality, PlayerPhilosophy personnelPhilosophy)
        {
            offense = offensivePersonality;
            defense = defensivePersonality;
            personnel = personnelPhilosophy;
        }
        public NewOffensivePhilosophy PreviousPhilosophy()
        {
            return offense;
        }
        public NewOffensivePhilosophy GetOffensivePhilosophy()
        {
            return offense;
        }
        public NewDefensivePhilosophy GetDefensivePhilosophy()
        {
            return defense;
        }
        public PlayerPhilosophy GetPlayerPhilosophy()
        {
            return personnel;
        }
        public NewPlayer[] GetStartingFive(NewTeam team)
        {
            return personnel.GetStartingFive(team);
        }


    }
     public class AdvancedNewCoach
     {
         private string name;
         private CoachingPersonalities personality;
         public AdvancedNewCoach(string name, CoachingPersonalities personality)
         {
             this.personality = personality;
             this.name = name;
         }
         public byte TakeShot(NewCurrentTeam team, NewCurrentTeam opponent,ShotType type, ref NewPlayer starter, NewPlayer previousPlayer = null)
         {
             NewPlayer shooter;
             bool three = true;
             switch(type)
             {
                 case ShotType.LAYUP:
                 case ShotType.DUNK:
                     three = false;
                     shooter = personality.GetInsideShooter(team, starter);
                     break;
                 case ShotType.JUMP:
                     three = false;
                     shooter = personality.GetJumpShooter(team, starter);
                     break;
                 case ShotType.CORNER_THREE:
                 case ShotType.TOP_THREE:
                     shooter = personality.GetJumpShooter(team, starter);
                     break;
                 default:
                     shooter = personality.GetThreeShooter(team, starter);
                     break;
             }
             /*double randBarrier = 0;

             if (previousPlayer != null)
             {
                 //NewPlayer passDefender = opponent.GetCoach().GetPersonality().GetDefender(previousPlayer, opponent, team);

                 //randBarrier += previousPlayer.GetPassingRating(true, false) + previousPlayer.GetOffenseIQRating(true, false) * .5 - passDefender.GetDefenseIQRating(true, false) * 1.5;

             }


             //NewPlayer shotDefender = opponent.GetCoach().GetPersonality().GetDefender(shooter, opponent, team);
             //randBarrier += shooter.GetSeperationRating(true, false) + shooter.GetOffenseIQRating(true, false) * .5 - shotDefender.GetDefenseIQRating(true, false) * 1.5;




             //ShotResult result = NewShots.TakeShot(type, false, shooter, shotDefender, League.r.NextGaussian((int)randBarrier, 5));


             bool made = result.Type != ResultType.MISS;

             if (made)
                 return (byte)(three ? 3 : 2);
             else*/
                 return 0;
         }
         public PlayResult DoNormalPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter = null)
         {
             Tuple<ShotType, int, NewPlayer> shotType = personality.DoNormalPlay(team, opponent, starter);

             if (shotType.Item1 == ShotType.OFFENSIVE_FOUL || shotType.Item1 == ShotType.STEAL || shotType.Item1 == ShotType.TURNOVER)
                 return new PlayResult(0, 0, shotType.Item2, shotType.Item3);

             byte score = TakeShot(team, opponent, shotType.Item1, ref starter);
             byte awayScore = 0, homeScore = 0;

             if (team.IsAwayTeam())
                 awayScore = score;
             else
                 homeScore = score;
             return new PlayResult(awayScore, homeScore, shotType.Item2, starter);
         }
         public PlayResult DoLessRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter = null)
         {
             Tuple<ShotType, int, NewPlayer> shotType = personality.DoLessRiskyPlay(team, opponent, starter);

             if (shotType.Item1 < 0)
                 return new PlayResult(0, 0, shotType.Item2, shotType.Item3);

             byte score = TakeShot(team, opponent, shotType.Item1, ref starter);
             byte awayScore = 0, homeScore = 0;

             if (team.IsAwayTeam())
                 awayScore = score;
             else
                 homeScore = score;
             return new PlayResult(awayScore, homeScore, shotType.Item2, starter);
         }
         public PlayResult DoMoreRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter = null)
         {
             Tuple<ShotType, int, NewPlayer> shotType = personality.DoMoreRiskyPlay(team, opponent, starter);

             if (shotType.Item1 < 0)
                 return new PlayResult(0, 0, shotType.Item2, shotType.Item3);

             byte score = TakeShot(team, opponent, shotType.Item1, ref starter);
             byte awayScore = 0, homeScore = 0;

             if (team.IsAwayTeam())
                 awayScore = score;
             else
                 homeScore = score;
             return new PlayResult(awayScore, homeScore, shotType.Item2, starter);
         }
         public NewPlayer[] GetStartingFive(NewTeam team)
         {
             return personality.GetStartingFive(team);
         }
         public PlayResult InboundPlay(NewCurrentTeam team, NewCurrentTeam opponent)
         {
             return null;
         }
         // Update this so they have a chance of being any personality
         public CoachingPersonalities GetPersonality()
         {
             return personality;
         }

     }
    // This class outlines the differences in coaching personalities, and is what the difference is
    // between each coach. The different personalities are all listed in the CoachingPersonalities.cs file
    // and all implement the various methods listed in here.
    [Serializable]
    public abstract class CoachingPersonalities
    {
        public CoachingPersonalities()
        {

        }
        // Shooters
        public abstract NewPlayer GetThreeShooter(NewCurrentTeam team, NewPlayer starter);
        public abstract NewPlayer GetJumpShooter(NewCurrentTeam team, NewPlayer starter);
        public abstract NewPlayer GetInsideShooter(NewCurrentTeam team, NewPlayer starter);

        // Various different players
        public abstract NewPlayer GetDefender(NewPlayer shooter, NewCurrentTeam team, NewCurrentTeam opponent);
        public abstract NewPlayer GetPlayStarter(NewCurrentTeam team);

        // Plays
        public abstract Tuple<ShotType, int, NewPlayer> DoNormalPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter);
        public abstract Tuple<ShotType, int, NewPlayer> DoLessRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter);
        public abstract Tuple<ShotType, int, NewPlayer> DoMoreRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter);

        public abstract NewPlayer[] GetStartingFive(NewTeam team);

    }
    [Serializable]
    public class GeneralManager
    {
        private string name;
        private Country country;
        private List<PlayerItem> players;
        private int ratingsMiss, maxRatingsMiss;
        private double combinedRatingNum;
        public GeneralManager(string name, Country country)
        {
            this.name = name;
            this.country = country;
        }
        public GeneralManager(Country country)
        {
            this.country = country;
            NameGenerator gen = NameGenerator.Instance();
            name = gen.GenerateName(country);
        }
        public double GetCombinedRatingNum()
        {
            return combinedRatingNum;
        }
        public override string ToString()
        {
            return name;
        }
        public void Update(Random r)
        {
            combinedRatingNum = (r.Next(30, 70) + r.NextDouble()) / 100.0;
        }
        public void SetNewInformation(Dictionary<uint, DraftablePlayer> draftList, Random r)
        {            

            players = new List<PlayerItem>();
            foreach (KeyValuePair<uint, DraftablePlayer> pair in draftList)
            {
                double ratings = pair.Value.GetRating();
                double maxRatings = pair.Value.GetMaxRating();
                switch (r.Next(20))
                {
                    case 4:
                        ratings += 15;
                        maxRatings += 15;
                        break;
                    case 10:
                        ratings -= 15;
                        maxRatings -= 15;
                        break;
                    default:
                        ratings += r.Next(-ratingsMiss, ratingsMiss);
                        maxRatings += r.Next(-maxRatingsMiss, maxRatingsMiss);
                        break;
                }
                double combinedRating = ratings * combinedRatingNum + maxRatings * (1 - combinedRatingNum);
                players.Add(new PlayerItem(pair.Key, ratings, maxRatings, ratings * combinedRatingNum + maxRatings * (1 - combinedRatingNum)));
            }
        }

        public void SortPlayers(int sortNum)
        {
            foreach (PlayerItem item in players)
                item.SetSortNumber(sortNum);

            players.Sort();
        }
        public List<PlayerItem> GetPlayers()
        {
            return players;
        }
    }
}