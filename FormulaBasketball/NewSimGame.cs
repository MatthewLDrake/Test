using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class NewSimGame
    {
        private readonly NewTeam homeTeam, awayTeam;
        private readonly Random r;
        private readonly bool playoffGame;
        private List<int> awayQuarterScores, homeQuarterScores;
        public NewSimGame(NewTeam homeTeam, NewTeam awayTeam, Random r, bool playoffGame)
        {
            this.homeTeam = homeTeam;
            this.awayTeam = awayTeam;
            this.playoffGame = playoffGame;

            awayQuarterScores = new List<int>();
            homeQuarterScores = new List<int>();

            this.r = r;

            PlayGame();
        }
        public List<int> GetAwayQuarterScores()
        {
            return awayQuarterScores;
        }
        public List<int> GetHomeQuarterScores()
        {
            return homeQuarterScores;
        }
        private int SkillBoostToPoints(int skillBoost, bool overtime = false)
        {
            if(!overtime)
                return (int)Math.Round(r.NextDoubleGaussian(-5.5 + (skillBoost), .5));

            return (int)Math.Round(r.NextDoubleGaussian(-2.75 + (skillBoost * .5), .5));
        }
        private void DistributeQuarterPoints(int points, double[] probabilites, bool homeTeam)
        {
            List<int> scores;
            if (homeTeam)
                scores = homeQuarterScores;
            else
                scores = awayQuarterScores;
            while (points > 0)
            {
                points--;
                double rNum = r.NextDouble();
                double currSum = 0;

                for(int i = 0; i < probabilites.Length; i++)
                {
                    if (rNum < probabilites[i] + currSum)
                    {
                        scores[i]++;
                        break;
                    }
                    currSum += probabilites[i];
                }                
            }
        }
        private void DistributePoints(int additionalPoints, NewTeam currentTeam, NewPlayer[] currentPlayers, NewPlayer[] opposingPlayers, ref Dictionary<uint, int> currentPoints, bool upToTwos = false)
        {
            int sum = 0;

            int[] pointDistribution = currentTeam.GetCoach().GetPointDistribution(currentPlayers, NewRealCoach.GetDefensivePositioning(currentPlayers, opposingPlayers));

            for (int j = 0; j < pointDistribution.Length; j++)
            {
                sum += pointDistribution[j];
            }


            while (additionalPoints != 0)
            {
                int num = r.Next(sum);
                int tempSum = 0;
                for (int j = 0; j < pointDistribution.Length; j++)
                {
                    if (tempSum + pointDistribution[j] > num)
                    {
                        if(additionalPoints > 1 && upToTwos)
                        {
                            currentPoints[currentPlayers[j].GetPlayerID()]++;
                            additionalPoints--;
                        }
                        currentPoints[currentPlayers[j].GetPlayerID()]++;
                        additionalPoints--;
                        break;
                    }
                    tempSum += pointDistribution[j];
                }
            }
        }
        private void DistributeMinutes(NewTeam team, NewPlayer[] starters)
        {
            int totalMinutes = 48 * 5;
            List<NewPlayer> players = new List<NewPlayer>(team.GetPlayers());
            foreach (NewPlayer p in starters)
            {
                int staminaBoost = (int)Math.Round(p.GetStaminaRating(true, false) / 20.0);
                int minutes = Math.Max(26, Math.Min(44, r.NextGaussian(30 + staminaBoost, 2)));

                p.AddMinutes(minutes);

                totalMinutes -= minutes;

                players.Remove(p);
            }

            starters = CoachHelper.GetStarters(players, team.GetCoach().GetOffense());


            foreach (NewPlayer p in starters)
            {
                int minutes = Math.Max(1, r.NextGaussian(12, 2));

                p.AddMinutes(minutes);

                totalMinutes -= minutes;

                players.Remove(p);
            }

            int playersLeft = 0;
            foreach(NewPlayer p in players)
            {
                if (p.GetPoints() > 0 || r.Next(3) == 1)
                    playersLeft++;
            }
            foreach (NewPlayer p in players)
            {
                if (p.GetPoints() > 0)
                    p.AddMinutes(totalMinutes / playersLeft);
            }

        }
        private int GetBonusPoints(NewTeam bonusTeam, NewTeam opposingTeam, bool betterTeam)
        {
            int bonusPoints = 0;

            OffenseType type = bonusTeam.GetCoach().GetOffense();
            DefenseType defenseType = opposingTeam.GetCoach().GetDefense();

            switch(type)
            {
                case OffenseType.BALANCED_OFFENSE:
                    switch(defenseType)
                    {
                        case DefenseType.MAN_NO_SWITCH_DEFENSE:
                            bonusPoints += 5; 
                            break;
                        case DefenseType.MAN_SWITCH_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.MATCHUP_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.THREE_TWO_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.TWO_THREE_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                    }
                    break;
                case OffenseType.SUPERSTAR_FIRST_OFFENSE:
                    List<NewPlayer> players = bonusTeam.GetPlayers();
                    players.Sort();                    

                    if (players[0].GetMainOverall() > 98)
                        bonusPoints += 10;
                    else if (players[0].GetMainOverall() > 96)
                        bonusPoints += 7;
                    else if (players[0].GetMainOverall() > 94)
                        bonusPoints += 4;
                    else if (players[0].GetMainOverall() > 90)
                        bonusPoints += 1;
                    else if (players[0].GetMainOverall() > 80)
                        bonusPoints -= 5;
                    else
                        bonusPoints -= 10;

                    switch (defenseType)
                    {
                        case DefenseType.MAN_NO_SWITCH_DEFENSE:
                            bonusPoints += 10;
                            break;
                        case DefenseType.MAN_SWITCH_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.MATCHUP_ZONE_DEFENSE:
                            bonusPoints += 0;
                            break;
                        case DefenseType.THREE_TWO_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.TWO_THREE_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                    }
                    break;
                case OffenseType.SEVEN_SECOND_OFFENSE:
                    switch (defenseType)
                    {
                        case DefenseType.MAN_NO_SWITCH_DEFENSE:
                            bonusPoints += 4;
                            break;
                        case DefenseType.MAN_SWITCH_DEFENSE:
                            bonusPoints += 4;
                            break;
                        case DefenseType.MATCHUP_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.THREE_TWO_ZONE_DEFENSE:
                            bonusPoints += 6;
                            break;
                        case DefenseType.TWO_THREE_ZONE_DEFENSE:
                            bonusPoints += 6;
                            break;
                    }
                    break;
                case OffenseType.PERIMETER_CENTRIC_OFFENSE:
                    players = bonusTeam.GetPlayers();
                    players.Sort();

                    double avg = 0;
                    for(int i = 0; i < 8; i++)
                    {
                        avg += players[i].GetPassingRating(true, false);
                    }
                    avg /= 8;

                    if (avg > 93)
                        bonusPoints += 10;
                    else if (avg > 85)
                        bonusPoints += 7;
                    else if (avg > 78)
                        bonusPoints += 4;
                    else if (avg > 70)
                        bonusPoints += 1;
                    else if (avg > 60)
                        bonusPoints -= 5;
                    else
                        bonusPoints -= 10;

                    switch (defenseType)
                    {
                        case DefenseType.MAN_NO_SWITCH_DEFENSE:
                            bonusPoints += 2;
                            break;
                        case DefenseType.MAN_SWITCH_DEFENSE:
                            bonusPoints += 2;
                            break;
                        case DefenseType.MATCHUP_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.THREE_TWO_ZONE_DEFENSE:
                            bonusPoints += 8;
                            break;
                        case DefenseType.TWO_THREE_ZONE_DEFENSE:
                            bonusPoints += 8;
                            break;
                    }
                    break;
                case OffenseType.SMALL_BALL_OFFENSE:
                    switch (defenseType)
                    {
                        case DefenseType.MAN_NO_SWITCH_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.MAN_SWITCH_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.MATCHUP_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.THREE_TWO_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.TWO_THREE_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                    }
                    break;
                case OffenseType.PICK_OFFENSE:
                    switch (defenseType)
                    {
                        case DefenseType.MAN_NO_SWITCH_DEFENSE:
                            bonusPoints += 10;
                            break;
                        case DefenseType.MAN_SWITCH_DEFENSE:
                            bonusPoints += 4;
                            break;
                        case DefenseType.MATCHUP_ZONE_DEFENSE:
                            bonusPoints += 3;
                            break;
                        case DefenseType.THREE_TWO_ZONE_DEFENSE:
                            bonusPoints += 4;
                            break;
                        case DefenseType.TWO_THREE_ZONE_DEFENSE:
                            bonusPoints += 4;
                            break;
                    }
                    break;
                case OffenseType.PRINCETON_OFFENSE:
                    switch (defenseType)
                    {
                        case DefenseType.MAN_NO_SWITCH_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.MAN_SWITCH_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.MATCHUP_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.THREE_TWO_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.TWO_THREE_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                    }
                    break;
                case OffenseType.BIG_BALL_OFFENSE:
                    switch (defenseType)
                    {
                        case DefenseType.MAN_NO_SWITCH_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.MAN_SWITCH_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.MATCHUP_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.THREE_TWO_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                        case DefenseType.TWO_THREE_ZONE_DEFENSE:
                            bonusPoints += 5;
                            break;
                    }
                    break;
            }

            return bonusPoints + r.Next(-10 - (betterTeam ? 5 : 0), 11 + (betterTeam ? 0 : 5));
        }
        private void PlayGame()
        {
            int homePoints = 0, awayPoints = 0, additionalPoints, homeStarterAddedPoints = 0, awayStarterAddedPoints = 0, homeBackupAddedPoints = 0, awayBackupAddedPoints = 0, homeThirdStringAddedPoints = 0, awayThirdStringAddedPoints = 0;
            List<NewPlayer> remainingHomePlayers = new List<NewPlayer>(), remainingAwayPlayers = new List<NewPlayer>();
            Dictionary<uint, int> homePlayerPoints = new Dictionary<uint, int>(), awayPlayerPoints = new Dictionary<uint, int>();            

            awayQuarterScores.Add(SkillBoostToPoints(awayTeam.GetCoach().GetQuarterBoost(0)));
            awayQuarterScores.Add(SkillBoostToPoints(awayTeam.GetCoach().GetQuarterBoost(1)));
            awayQuarterScores.Add(SkillBoostToPoints(awayTeam.GetCoach().GetQuarterBoost(2)));
            awayQuarterScores.Add(SkillBoostToPoints(awayTeam.GetCoach().GetQuarterBoost(3)));

            homeQuarterScores.Add(SkillBoostToPoints(homeTeam.GetCoach().GetQuarterBoost(0)));
            homeQuarterScores.Add(SkillBoostToPoints(homeTeam.GetCoach().GetQuarterBoost(1)));
            homeQuarterScores.Add(SkillBoostToPoints(homeTeam.GetCoach().GetQuarterBoost(2)));
            homeQuarterScores.Add(SkillBoostToPoints(homeTeam.GetCoach().GetQuarterBoost(3)));

            foreach (NewPlayer p in homeTeam)
            {
                remainingHomePlayers.Add(p);
                homePlayerPoints.Add(p.GetPlayerID(), 0);
            }
            foreach (NewPlayer p in awayTeam)
            {
                remainingAwayPlayers.Add(p);
                awayPlayerPoints.Add(p.GetPlayerID(), 0);
            }

            NewPlayer[] homePlayers = CoachHelper.GetStarters(homeTeam, homeTeam.GetCoach().GetOffense()), awayPlayers = CoachHelper.GetStarters(awayTeam, awayTeam.GetCoach().GetOffense());
            double tempHome = 0, tempAway = 0;
            for(int i = 0; i < homePlayers.Length; i++)
            {
                tempHome += homePlayers[i].GetMainOverall();
                tempAway += awayPlayers[i].GetMainOverall();
            }

            int bonus = GetBonusPoints(homeTeam, awayTeam, tempHome > tempAway);

            if(bonus > 0)
            {
                for (int i = 0; i < bonus; i++)
                {
                    homeQuarterScores[r.Next(4)]++;
                }
            }
            else
            {
                bonus = Math.Abs(bonus);
                for (int i = 0; i < bonus; i++)
                {
                    homeQuarterScores[r.Next(4)]--;
                }
            }

            bonus = GetBonusPoints(awayTeam, homeTeam, tempAway > tempHome);

            if(bonus > 0)
            {
                for (int i = 0; i < bonus; i++)
                {
                    awayQuarterScores[r.Next(4)]++;
                }
            }
            else
            {
                bonus = Math.Abs(bonus);
                for (int i = 0; i < bonus; i++)
                {
                    awayQuarterScores[r.Next(4)]--;
                }
            }

            for (int i = 0; i < 4; i++)
            {                
                if(awayQuarterScores[i] < 0)
                {
                    int temp = (int)Math.Round(awayQuarterScores[i] * .75);
                    awayStarterAddedPoints += temp;
                    awayBackupAddedPoints += awayQuarterScores[i] - temp;
                }
                else
                {
                    int temp = awayQuarterScores[i];
                    while(temp > 0)
                    {
                        int rNum = r.Next(100);
                        if (rNum < 70)
                            awayStarterAddedPoints++;
                        else if (rNum != 88)
                            awayBackupAddedPoints++;
                        else
                            awayThirdStringAddedPoints++;

                        temp--;
                    }
                }
                if (homeQuarterScores[i] < 0)
                {
                    int temp = (int)Math.Round(homeQuarterScores[i] * .75);
                    homeStarterAddedPoints += temp;
                    homeBackupAddedPoints += homeQuarterScores[i] - temp;
                }
                else
                {
                    int temp = homeQuarterScores[i];
                    while (temp > 0)
                    {
                        int rNum = r.Next(100);
                        if (rNum < 70)
                            homeStarterAddedPoints++;
                        else if (rNum != 88)
                            homeBackupAddedPoints++;
                        else
                            homeThirdStringAddedPoints++;

                        temp--;
                    }
                }

            }

           
           
            double average = 0;
            foreach (NewPlayer p in homePlayers)
            {
                p.StartGame(true, awayTeam.GetTeamNum());
                average += p.GetMainOverall();
                remainingHomePlayers.Remove(p);
            }
            average /= 5;

            additionalPoints = (int)Math.Round(r.NextDoubleGaussian(average - 13, 4)) + homeStarterAddedPoints;
            homePoints += additionalPoints;
            DistributePoints(additionalPoints, homeTeam, homePlayers, awayPlayers, ref homePlayerPoints);

            DistributeQuarterPoints(additionalPoints - homeStarterAddedPoints, homeTeam.GetCoach().GetQuarterDistribution(1), true);

            average = 0;

            foreach (NewPlayer p in awayPlayers)
            {
                p.StartGame(true, homeTeam.GetTeamNum());
                average += p.GetMainOverall();
                remainingAwayPlayers.Remove(p);
            }



            average /= 5;

            additionalPoints = (int)Math.Round(r.NextDoubleGaussian(average - 15, 4)) + awayStarterAddedPoints;
            awayPoints += additionalPoints;

            DistributePoints(additionalPoints, awayTeam, awayPlayers, homePlayers, ref awayPlayerPoints);
            // Starters get their stats at the ends of games, as they play in overtime.
            DistributeQuarterPoints(additionalPoints - awayStarterAddedPoints, awayTeam.GetCoach().GetQuarterDistribution(1), false);

            homePlayers = CoachHelper.GetStarters(remainingHomePlayers, homeTeam.GetCoach().GetOffense());
            awayPlayers = CoachHelper.GetStarters(remainingAwayPlayers, awayTeam.GetCoach().GetOffense());

            average = 0;

            foreach (NewPlayer p in homePlayers)
            {
                p.StartGame(false, awayTeam.GetTeamNum());
                average += p.GetMainOverall();
                remainingHomePlayers.Remove(p);
            }

            average /= 5;

            additionalPoints = (int)Math.Round(r.NextDoubleGaussian(average - 58, 4)) + homeBackupAddedPoints;
            homePoints += additionalPoints;

            DistributePoints(additionalPoints, homeTeam, homePlayers, awayPlayers, ref homePlayerPoints);

            DistributeQuarterPoints(additionalPoints - homeBackupAddedPoints, homeTeam.GetCoach().GetQuarterDistribution(2), true);

            average = 0;

            foreach (NewPlayer p in awayPlayers)
            {
                p.StartGame(false, homeTeam.GetTeamNum());
                average += p.GetMainOverall();
                remainingAwayPlayers.Remove(p);
            }

            average /= 5;

            additionalPoints = (int)Math.Round(r.NextDoubleGaussian(average - 60, 4)) + awayBackupAddedPoints;
            awayPoints += additionalPoints;

            DistributePoints(additionalPoints, awayTeam, awayPlayers, homePlayers, ref awayPlayerPoints);

            DistributeQuarterPoints(additionalPoints - awayBackupAddedPoints, awayTeam.GetCoach().GetQuarterDistribution(2), false);
            for (int i = 0; i < 5; i++)
            {
                homePlayers[i].SetStats(i, homePlayers, homeTeam, homePlayerPoints[homePlayers[i].GetPlayerID()]);
                awayPlayers[i].SetStats(i, awayPlayers, awayTeam, awayPlayerPoints[awayPlayers[i].GetPlayerID()]);
            }

            additionalPoints = Math.Max(0, (int)Math.Round(r.NextDoubleGaussian(3, 2))) + homeThirdStringAddedPoints;
            
            for (int i = 0; i < 5; i++)
            {
                if (remainingHomePlayers.Count <= i)
                    homePlayers[i] = null;
                else
                {
                    homePlayers[i] = remainingHomePlayers[i];
                    remainingHomePlayers[i].StartGame(false, awayTeam.GetTeamNum());
                }
            }
            DistributePoints(additionalPoints, homeTeam, homePlayers, awayPlayers, ref homePlayerPoints, true);

            DistributeQuarterPoints(additionalPoints - homeThirdStringAddedPoints, homeTeam.GetCoach().GetQuarterDistribution(3), true);
            homePoints += additionalPoints;

            additionalPoints = Math.Max(0, (int)Math.Round(r.NextDoubleGaussian(2, 2))) + awayThirdStringAddedPoints;

            for (int i = 0; i < 5; i++)
            {
                if (remainingAwayPlayers.Count <= i)
                    awayPlayers[i] = null;
                else
                {
                    awayPlayers[i] = remainingAwayPlayers[i];
                    remainingAwayPlayers[i].StartGame(false, homeTeam.GetTeamNum());
                }
            }
            DistributePoints(additionalPoints, awayTeam, awayPlayers, homePlayers, ref awayPlayerPoints, true);

            DistributeQuarterPoints(additionalPoints - awayThirdStringAddedPoints, awayTeam.GetCoach().GetQuarterDistribution(3), false);
            awayPoints += additionalPoints;
            for (int i = 0; i < 5; i++)
            {
                if(homePlayers[i] != null)
                    homePlayers[i].SetStats(i, homePlayers, homeTeam, homePlayerPoints[homePlayers[i].GetPlayerID()]);
                if (awayPlayers[i] != null)
                    awayPlayers[i].SetStats(i, awayPlayers, awayTeam, awayPlayerPoints[awayPlayers[i].GetPlayerID()]);
            }
            while (homePoints == awayPoints)
            {
                homePlayers = CoachHelper.GetStarters(homeTeam, homeTeam.GetCoach().GetOffense());
                awayPlayers = CoachHelper.GetStarters(awayTeam, awayTeam.GetCoach().GetOffense());
                average = 0;
                foreach (NewPlayer p in homePlayers)
                {
                    average += p.GetMainOverall();
                    p.AddMinutes(5);
                }

                average /= 5;

                additionalPoints = (int)Math.Round(r.NextDoubleGaussian(average / 10 + 2, 4)) + SkillBoostToPoints(homeTeam.GetCoach().GetQuarterBoost(4), true);
                homePoints += additionalPoints;
                DistributePoints(additionalPoints, homeTeam, homePlayers, awayPlayers, ref homePlayerPoints);

                if (homeQuarterScores.Count < 5)
                    homeQuarterScores.Add(additionalPoints);
                else
                    homeQuarterScores[4] += additionalPoints;

                average = 0;

                foreach (NewPlayer p in awayPlayers)
                    average += p.GetMainOverall();

                average /= 5;

                additionalPoints = (int)Math.Round(r.NextDoubleGaussian(average / 10, 4)) + SkillBoostToPoints(awayTeam.GetCoach().GetQuarterBoost(4), true);
                awayPoints += additionalPoints;

                DistributePoints(additionalPoints, awayTeam, awayPlayers, homePlayers, ref awayPlayerPoints);

                if (awayQuarterScores.Count < 5)
                    awayQuarterScores.Add(additionalPoints);
                else
                    awayQuarterScores[4] += additionalPoints;
            }
            homePlayers = CoachHelper.GetStarters(homeTeam, homeTeam.GetCoach().GetOffense());
            awayPlayers = CoachHelper.GetStarters(awayTeam, awayTeam.GetCoach().GetOffense());

            for (int i = 0; i < 5; i++)
            {
                homePlayers[i].SetStats(i,homePlayers, homeTeam, homePlayerPoints[homePlayers[i].GetPlayerID()]);
                awayPlayers[i].SetStats(i, awayPlayers, awayTeam, awayPlayerPoints[awayPlayers[i].GetPlayerID()]);
            }

            DistributeMinutes(homeTeam, homePlayers);
            DistributeMinutes(awayTeam, awayPlayers);

            // So first step, is to give the points 
            int homePlusMinusPoints = homePoints * 5;
            int awayPlusMinusPoints = awayPoints * 5;

            homeTeam.AddResult(homePoints, awayPoints, awayTeam.GetTeamNum(), true, playoffGame);
            awayTeam.AddResult(awayPoints, homePoints, homeTeam.GetTeamNum(), false, playoffGame);


           



        }
    }
}
