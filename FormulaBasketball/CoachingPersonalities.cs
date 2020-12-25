using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class BalancedOffense : NewOffensivePhilosophy
    {
        public override int GetNumberOfPlays(int seconds)
        {
            return League.r.NextGaussian((seconds * 25) / 720, 1);
        }
        public override PlayStats GetStats(int plays, NewCurrentTeam offense, NewCurrentTeam defense, int quarter, bool clutchSituation)
        {
            // TODO: Add extra possesions for offensive rebounds?

            double[] offenseUsageRate = GetOffensiveUsageRate(offense);
            NewPlayer[] players = offense.GetCurrentPlayers();

            Tuple<int, double>[] offenseTuple = new Tuple<int, double>[5];

            for (int i = 0; i < players.Length; i++)
                offenseTuple[i] = new Tuple<int, double>(players[i].GetPosition(), offenseUsageRate[i]);

            Tuple<double[], int[]> defensiveUsage = defense.GetCoach().GetDefensivePhilosophy().GetDefensiveUsageRate(defense, offenseTuple);

            double ratingDiff = GetOffensiveIQTeamRating(offense, offenseUsageRate, clutchSituation) - NewDefensivePhilosophy.GetDefensiveIQTeamRating(defense, defensiveUsage.Item1, clutchSituation);

            double turnoverPercent;

            if (ratingDiff >= 0)
                turnoverPercent = Math.Round(League.r.NextDoubleGaussian(13 + (-0.003333 * ratingDiff * ratingDiff - 0.06667 * ratingDiff), .3), 1);
            else
                turnoverPercent = Math.Round(League.r.NextDoubleGaussian(13 + (0.003333 * ratingDiff * ratingDiff - 0.06667 * ratingDiff), .3), 1);

            int turnovers = (int)Math.Round(turnoverPercent * plays / 100);
            turnovers = League.r.Next(turnovers - 1, turnovers + 2);
            int steals = (int)Math.Round(((40 - ratingDiff) / 100) * turnovers);

            int totalAttempts = plays - turnovers;

            int potentialAssists = (int)(totalAttempts * (League.r.NextGaussian(60, 1) / 100.0) - 3 + League.r.Next(6));

            int threePointAttempts = (int)Math.Round(totalAttempts * League.r.NextDoubleGaussian(.38288, .05));
            int fouls = 0;
            if (quarter < 4)
                fouls = (int)League.r.NextDoubleGaussian(3.75, 1.25);
            else if (quarter == 4)
                fouls = (int)League.r.NextDoubleGaussian(5.5, .75);
            else
                fouls = (int)League.r.NextDoubleGaussian(3.25, .5);

            if(quarter != 5)
                fouls = (int)Math.Round(1.0 * plays * fouls / 23.0);

            return new PlayStats(totalAttempts - threePointAttempts, threePointAttempts, steals, turnovers - steals, offenseUsageRate, defensiveUsage, fouls, .2, potentialAssists);            
        }
        public override double[] GetOffensiveUsageRate(NewCurrentTeam team)
        {
            double[] usageRate = new double[5], overalls = new double[5];

            NewPlayer[] players = team.GetCurrentPlayers();

            for(int i = 0; i < players.Length; i++)
            {
                overalls[i] = players[i].GetOffenseIQRating(true, false) + players[i].GetSeperationRating(true, false) * .6 + players[i].GetPassingRating(true, false) + players[i].GetInsideRating(true, false) * .35 + players[i].GetJumpShotRating(true, false) * .3 + players[i].GetThreePointRating(true, false) * .35;
            }

            double sum = 0.0;
            foreach(double overall in overalls)
            {
                sum += overall;
            }

            for(int i = 0; i < usageRate.Length; i++)
            {
                usageRate[i] = overalls[i] / sum;
            }

            return usageRate;
        }
        public override byte DistributeShots(PlayStats stats, NewCurrentTeam offense, NewCurrentTeam defense, bool clutch)
        {
            byte score = 0;

            double[] threeProbabilityPostion = new double[] { .1, .15, .25, .25, .25 };
            double[] updatedUsage = new double[5];
            for(int i = 0; i < updatedUsage.Length;i++)
            {
                updatedUsage[i] = (((threeProbabilityPostion[i] * 2 + offense.GetCurrentPlayers()[i].GetThreePointRating(false, false) * 1.5 + stats.offensiveUsage[i] * 3 + offense.GetCurrentPlayers()[i].GetSeperationRating(true, clutch)) / 10.0))/100;
            }

            int remainingShots = stats.twosAttempted + stats.threesAttempted;
            int assistsRemaining = stats.potentialAssists;

            for (int i = 0; i < stats.threesAttempted; i++)
            {
                double num = League.r.NextDouble();
                double curr = 0.0;

                double assistsNum = League.r.NextDouble();
                double percent = (double)assistsRemaining / (double)remainingShots;

                bool assistPossible = assistsNum < percent;
               

                for (int j = 0; j < offense.GetCurrentPlayers().Length; j++)
                {
                    if (curr + updatedUsage[j] > num)
                    {
                        score += (byte) (AttemptThree(j, stats, offense, defense, clutch, offense.GetCurrentPlayers()[j], assistPossible) ? 3: 0);
                        if (assistPossible)
                            assistsRemaining--;
                        remainingShots--;
                        break;
                    }
                    curr += updatedUsage[j];
                }
            }

            double[] twoProbabilityPostion = new double[] { .225, .225, .2, .175, .175 };
            updatedUsage = new double[5];
            for (int i = 0; i < updatedUsage.Length; i++)
            {
                updatedUsage[i] = ((twoProbabilityPostion[i] * 2 + offense.GetCurrentPlayers()[i].GetInsideRating(false, false) * .75 + offense.GetCurrentPlayers()[i].GetJumpShotRating(false, false) * .75 + stats.offensiveUsage[i] * 3 + offense.GetCurrentPlayers()[i].GetSeperationRating(true, clutch)) / 10.0) /100;
            }

            for (int i = 0; i < stats.twosAttempted; i++)
            {
                double num = League.r.NextDouble();
                double curr = 0.0;

                double assistsNum = League.r.NextDouble();
                double percent = (double)assistsRemaining / (double)remainingShots;

                bool assistPossible = assistsNum <= percent;


                for (int j = 0; j < offense.GetCurrentPlayers().Length; j++)
                {
                    if (curr + updatedUsage[j] > num)
                    {
                        score += (byte)(AttemptTwo(j, stats, offense, defense, clutch, offense.GetCurrentPlayers()[j], assistPossible) ? 2 : 0);
                        if (assistPossible)
                            assistsRemaining--;
                        remainingShots--;
                        break;
                    }
                    curr += updatedUsage[j];
                }
            }
            return score;
        }
        private bool AttemptTwo(int index, PlayStats stats, NewCurrentTeam offense, NewCurrentTeam defense, bool clutch, NewPlayer shooter, bool assister)
        {
            bool made = false, jumper;
            double mainPosition = .85; // 1 - .025 -.025 - .025 -.075 
            if (index != 0 || index != 4)
                mainPosition -= .05; // Additional 

            if (index < 2)
                jumper = .3 < League.r.NextDouble();
            else
                jumper = .55 < League.r.NextDouble();

            double[] defenderProbablility = new double[5];
            for (int i = 0; i < defenderProbablility.Length; i++)
            {
                if (i == index)
                    defenderProbablility[i] = mainPosition;
                else if (Math.Abs(i - index) == 1)
                    defenderProbablility[i] = .075;
                else
                    defenderProbablility[i] = .025;
            }

            int position = 0;
            double num = League.r.NextDouble(), curr = 0.0;
            for (int i = 0; i < defenderProbablility.Length; i++)
            {
                if (defenderProbablility[i] + curr > num)
                {
                    position = i;
                    break;
                }
                curr += defenderProbablility[i];
            }
            NewPlayer defender = null;
            for (int i = 0; i < stats.defensiveUsage.Item2.Length; i++)
            {
                if (position == stats.defensiveUsage.Item2[i])
                    defender = defense.GetCurrentPlayers()[i];
            }

            NewPlayer theAssister = null;

            if (assister)
            {
                double[] passingRating = new double[5];
                double[] probability = new double[5];
                for (int i = 0; i < offense.GetCurrentPlayers().Length; i++)
                {
                    if (i == index)
                        passingRating[i] = -1;
                    else
                        passingRating[i] = offense.GetCurrentPlayers()[i].GetPassingRating(false, false);

                }
                double sum = 0;
                for (int i = 0; i < passingRating.Length; i++)
                {
                    if (passingRating[i] != -1)
                    {
                        sum += passingRating[i];
                    }
                }
                for (int i = 0; i < probability.Length; i++)
                {
                    if (passingRating[i] == -1)
                        probability[i] = 0;
                    else
                        probability[i] = ((passingRating[i] / sum) * 4.0 + (stats.offensiveUsage[i] + stats.offensiveUsage[index] / 4)) / 5.0;
                }
                num = League.r.NextDouble();
                curr = 0.0;
                for (int i = 0; i < probability.Length; i++)
                {
                    if (probability[i] + curr > num)
                    {
                        position = i;
                        break;
                    }
                    curr += probability[i];
                }
                theAssister = offense.GetCurrentPlayers()[position];
            }

            double score;
            if(theAssister != null)
                score = theAssister.GetPassingRating(true, clutch) + shooter.GetSeperationRating(true, clutch) + (jumper ? shooter.GetJumpShotRating(true, clutch) : shooter.GetInsideRating(true, clutch)) * 3 - (defender.GetShotContestRating(true, clutch) * 5);
            else
                score = shooter.GetSeperationRating(true, clutch) * 1.75 + (jumper ? shooter.GetJumpShotRating(true, clutch) : shooter.GetInsideRating(true, clutch)) * 3 - (defender.GetShotContestRating(true, clutch) * 5);

            double chance = 48 + score / 10 + League.r.NextGaussian(0, 1);

            made = League.r.Next(101) < chance;

            shooter.AddTwoPointer(made);

            if (made && theAssister != null)
                theAssister.AddAssist();

            defender.AddTwoPointerAgainst(made);

            return made;
        }
        private bool AttemptThree(int index, PlayStats stats, NewCurrentTeam offense, NewCurrentTeam defense, bool clutch, NewPlayer shooter, bool assister)
        {
            bool made = false;
            double mainPosition = .85; // 1 - .025 -.025 - .025 -.075 
            if (index != 0 || index != 4)
                mainPosition -= .05; // Additional 

            double[] defenderProbablility = new double[5];
            for(int i = 0; i < defenderProbablility.Length; i++)
            {
                if (i == index)
                    defenderProbablility[i] = mainPosition;
                else if (Math.Abs(i - index) == 1)
                    defenderProbablility[i] = .075;
                else
                    defenderProbablility[i] = .025;
            }

            int position = 0;
            double num = League.r.NextDouble(), curr = 0.0;
            for(int i = 0; i < defenderProbablility.Length; i++)
            {
                if(defenderProbablility[i] + curr > num)
                {
                    position = i;
                    break;
                }
                curr += defenderProbablility[i];
            }
            NewPlayer defender = null;
            for(int i = 0; i < stats.defensiveUsage.Item2.Length; i++)
            {
                if (position == stats.defensiveUsage.Item2[i])
                    defender = defense.GetCurrentPlayers()[i];
            }

            NewPlayer theAssister = null;

            if (assister)
            {
                double[] passingRating = new double[5];
                double[] probability = new double[5];
                for (int i = 0; i < offense.GetCurrentPlayers().Length; i++)
                {
                    if (i == index)
                        passingRating[i] = -1;
                    else
                        passingRating[i] = offense.GetCurrentPlayers()[i].GetPassingRating(false, false);
                    
                }
                double sum = 0;
                for(int i = 0; i < passingRating.Length; i++)
                {
                    if(passingRating[i] != -1)
                    {
                        sum += passingRating[i];
                    }
                }
                for(int i = 0; i < probability.Length;i++)
                {
                    if (passingRating[i] == -1)                    
                        probability[i] = 0;                    
                    else
                        probability[i] = ((passingRating[i] / sum) * 4.0 + (stats.offensiveUsage[i] + stats.offensiveUsage[index] / 4)) / 5.0;
                }
                num = League.r.NextDouble();
                curr = 0.0;
                for (int i = 0; i < probability.Length; i++)
                {
                    if (probability[i] + curr > num)
                    {
                        position = i;
                        break;
                    }
                    curr += probability[i];
                }
                theAssister = offense.GetCurrentPlayers()[position];
            }
            double score;

            if(theAssister != null)
                score = theAssister.GetPassingRating(true, clutch) + shooter.GetSeperationRating(true, clutch) + shooter.GetThreePointRating(true, clutch) * 3 - (defender.GetShotContestRating(true, clutch) * 5);
            else
                score = shooter.GetSeperationRating(true, clutch) * 1.75 + shooter.GetThreePointRating(true, clutch) * 3 - (defender.GetShotContestRating(true, clutch) * 5);

            double chance = 32 + score / 10 + League.r.NextGaussian(0, 1);

            made = League.r.Next(101) < chance;

            shooter.AddThreePointer(made);

            if (made && theAssister != null)
                theAssister.AddAssist();

            defender.AddThreePointerAgainst(made);

            return made;
        }
    }
    public class BalancedDefense : NewDefensivePhilosophy
    {
        public override Tuple<double[],int[]> GetDefensiveUsageRate(NewCurrentTeam team, Tuple<int, double>[] offenseUsageRate)
        {
            double[] usageRate = new double[5], overalls = new double[5];
                        
            NewPlayer[] players = team.GetCurrentPlayers();

            int[] positionalMatchup = GetPositionalMatchup(offenseUsageRate, players);

            for (int i = 0; i < players.Length; i++)
            {
                overalls[i] = (players[i].GetDefenseIQRating(true, false) * 1.25 + players[i].GetShotContestRating(true, false) * .8 + players[i].GetJumpingRating(true, false) * .35) * .15 + offenseUsageRate[positionalMatchup[i]].Item2 * .85;
            }

            double sum = 0.0;
            foreach (double overall in overalls)
            {
                sum += overall;
            }

            for (int i = 0; i < usageRate.Length; i++)
            {
                usageRate[i] = overalls[i] / sum;
            }

            return new Tuple<double[], int[]>(usageRate, positionalMatchup);
        }
        private int[] GetPositionalMatchup(Tuple<int, double>[] offense, NewPlayer[] defense)
        {
            int[] positionalMatchup = new int[5];
            bool[] usedBefore = new bool[5];
            for(int i = 0; i < defense.Length; i++)
            {
                positionalMatchup[i] = -1;
                for(int j = 0; j < offense.Length; j++)
                {
                    if(defense[i].GetPosition() == offense[j].Item1 && !usedBefore[j])
                    {
                        positionalMatchup[i] = j;
                        usedBefore[j] = true;
                        break;
                    }
                }
            }

            List<int> neededPositions = new List<int>();
            for(int i = 0; i < defense.Length; i++)
            {
                if (positionalMatchup[i] == -1)
                    neededPositions.Add(defense[i].GetPosition());
            }

            if(neededPositions.Count > 0)
            {
                for (int i = 0; i < defense.Length; i++)
                {
                    if (positionalMatchup[i] == -1)
                    {
                        for (int j = 0; j < offense.Length; j++)
                        {
                            if (((defense[i].GetPosition() - 1) == offense[j].Item1 || (defense[i].GetPosition() + 1) == offense[j].Item1) && !usedBefore[j])
                            {
                                positionalMatchup[i] = j;
                                usedBefore[j] = true;
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < defense.Length; i++)
                {
                    if (positionalMatchup[i] == -1)
                    {
                        for (int j = 0; j < offense.Length; j++)
                        {
                            if (!usedBefore[j])
                            {
                                positionalMatchup[i] = j;
                                usedBefore[j] = true;
                                break;
                            }
                        }
                    }
                }
            }

            return positionalMatchup;
        }
    }
    public class OverallPersonnel : PlayerPhilosophy
    {
        private bool InFoulTrouble(NewPlayer player, int quarter)
        {
            return false;
        }
        public override NewPlayer[] DoSubstitutions(NewTeam team, int quarter)
        {
            NewPlayer[] currentFive = new NewPlayer[5];

            List<Tuple<NewPlayer, double, int>>[] list = GetLists(team, true);

            for (int i = 0; i < 5; i++)
            {
                int index = 0;
                NewPlayer player = null;
                double topStarter = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (currentFive[j] == null)
                    {
                        if (list[j][0].Item2 > topStarter && !InFoulTrouble(list[j][0].Item1, quarter))
                        {
                            player = list[j][0].Item1;
                            topStarter = list[j][0].Item2;
                            index = j;
                        }
                    }
                }
                currentFive[index] = player;
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < list[j].Count; k++)
                    {
                        if (list[j][k].Item1.Equals(player))
                        {
                            list[j].RemoveAt(k);
                            break;
                        }
                    }
                }
            }

            // Check for foul trouble

            foreach(NewPlayer p in currentFive)
            {

            }

            return currentFive;
        }

        public override int GetSecondsUntilSubstitutions(NewCurrentTeam team)
        {
            return League.r.Next(160, 200);
        }

        public override NewPlayer[] GetStartingFive(NewTeam team)
        {
            return startingFive;
        }

        public override void StartGame(NewTeam team)
        {
            startingFive = new NewPlayer[5];

            List<Tuple<NewPlayer, double, int>>[] list = GetLists(team, true);

            for (int i = 0; i < 5; i++)
            {
                int index = 0;
                NewPlayer player = null;
                double topStarter = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (startingFive[j] == null)
                    {
                        if (list[j][0].Item2 > topStarter)
                        {
                            player = list[j][0].Item1;
                            topStarter = list[j][0].Item2;
                            index = j;
                        }
                    }
                }
                startingFive[index] = player;
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < list[j].Count; k++)
                    {
                        if (list[j][k].Item1.Equals(player))
                        {
                            list[j].RemoveAt(k);
                            break;
                        }
                    }
                }
            }
        }
    }
    public class BalancedPersonnel : PlayerPhilosophy
    {

        public override void StartGame(NewTeam team)
        {
            startingFive = new NewPlayer[5];
            double[] overalls = new double[5];

            List<Tuple<NewPlayer, double, int>>[] list = GetLists(team, false);

            for (int i = 0; i < 5; i++)
            {
                int index = 0;
                NewPlayer player = null;
                double topStarter = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (startingFive[j] == null)
                    {
                        if (list[j][0].Item2 > topStarter)
                        {
                            player = list[j][0].Item1;
                            topStarter = list[j][0].Item2;
                            index = j;
                        }
                    }
                }
                startingFive[index] = player;
                overalls[index] = topStarter;
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < list[j].Count; k++)
                    {
                        if (list[j][k].Item1.Equals(player))
                        {
                            list[j].RemoveAt(k);
                            break;
                        }
                    }
                }
            }

            List<Tuple<NewPlayer, double>>[] playerArr = new List<Tuple<NewPlayer, double>>[5];

            for (int j = 0; j < 5; j++)
                playerArr[j] = new List<Tuple<NewPlayer,double>>();


            for (int i = 0; i < 5; i++)
            {

                int index = 0;
                NewPlayer player = null;
                double lowestDifference = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (playerArr[j].Count < 1)
                    {
                        if (list[j][0].Item2 - overalls[j] < lowestDifference)
                        {
                            player = list[j][0].Item1;
                            lowestDifference = list[j][0].Item2 - overalls[j];
                            index = j;
                        }
                    }
                }
                playerArr[index].Add(new Tuple<NewPlayer, double>(player, lowestDifference));
                for (int l = 0; l < 5; l++)
                {
                    for (int k = 0; k < list[l].Count; k++)
                    {
                        if (list[l][k].Item1.Equals(player))
                        {
                            list[l].RemoveAt(k);
                            break;
                        }
                    }
                }       
            }
            Console.WriteLine(playerArr);

            int[] starterMaxMinutes = new int[5];
            bool[] requiresThird = new bool[5];
            for (int i = 0; i < 5; i++)
            {
                starterMaxMinutes[i] = startingFive[i].GetMaxMinutes();
                if(starterMaxMinutes[i] < 24)
                {
                    // TODO: Find new player for third string
                }
                double difference = playerArr[i][0].Item2;

            }
            



        }

        public override NewPlayer[] DoSubstitutions(NewTeam team, int quarter)
        {
            return GetStartingFive(team);
        }
        public override int GetSecondsUntilSubstitutions(NewCurrentTeam team)
        {
            int minSecondsUntilSubstitution = int.MaxValue;
            for(int i = 0; i < team.GetCurrentPlayers().Length; i++)
            {
                minSecondsUntilSubstitution = Math.Min(team.GetCurrentPlayers()[i].GetSecondsUntilSubstituion(), minSecondsUntilSubstitution);
            }
            return minSecondsUntilSubstitution;
        }
        public override NewPlayer[] GetStartingFive(NewTeam team)
        {
            return startingFive;
        }       
        
    }

    /*public class SevenSecondOffense : CoachingPersonalities
    {
        private NewPlayer[] roles;
        public override Tuple<ShotType, int, NewPlayer> DoLessRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter)
        {
            throw new NotImplementedException();
        }

        public override Tuple<ShotType, int, NewPlayer> DoMoreRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter)
        {
            throw new NotImplementedException();
        }

        public override Tuple<ShotType, int, NewPlayer> DoNormalPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter)
        {
            Random r = League.r;

            int timeElapsed = 0;
            ShotType shotType = ShotType.TURNOVER;

            AssignRoles(team);

            if (starter == null)
                starter = GetPlayStarter(team);

            int timeTemp = r.Next(10);

            bool fastUpTempo = timeTemp >= 3;
            bool turnover;

            NewPlayer offensivePlayer = GetPlayer(starter, team);
            NewPlayer defensivePlayer = opponent.GetCoach().GetPersonality().GetDefender(offensivePlayer, opponent, team);

            if (fastUpTempo)
            {
                timeElapsed = r.Next(6, 11);
                turnover = r.Next(100) < 18;
            }
            else
            {
                timeElapsed = League.r.Next(16, 23);
                turnover = r.Next(100) < 12;
            }

            int val = r.Next(100);
            if (turnover)
            {


                // Offensive Foul - (maybe include who was fouled as the player)
                if (val < 10)
                    return new Tuple<ShotType, int, NewPlayer>(ShotType.OFFENSIVE_FOUL, timeElapsed, defensivePlayer);
                else
                    return new Tuple<ShotType, int, NewPlayer>(val < 60 ? ShotType.TURNOVER : ShotType.STEAL, timeElapsed, val < 60 ? null : defensivePlayer);
            }

            int role = GetRole(offensivePlayer);

            // Shot Types: 0 = inside, 1 = jumper, 2 = three
            if (fastUpTempo)
            {
                switch (role)
                {
                    case 0:
                        if (val < 20)
                            shotType = ShotType.LAYUP;
                        else if (val < 40)
                            shotType = ShotType.DUNK;
                        else if (val < 60)
                            shotType = ShotType.JUMP;
                        else if (val < 80)
                            shotType = ShotType.TOP_THREE;
                        else if (val < 95)
                            shotType = ShotType.THREE;
                        else
                            shotType = ShotType.CORNER_THREE;
                        break;

                    case 1:
                        if (val < 10)
                            shotType = ShotType.LAYUP;
                        else if (val < 20)
                            shotType = ShotType.DUNK;
                        else if (val < 40)
                            shotType = ShotType.JUMP;
                        else if (val < 50)
                            shotType = ShotType.TOP_THREE;
                        else if (val < 65)
                            shotType = ShotType.THREE;
                        else
                            shotType = ShotType.CORNER_THREE;
                        break;
                    case 2:
                        if (val < 10)
                            shotType = ShotType.LAYUP;
                        else if (val < 20)
                            shotType = ShotType.DUNK;
                        else if (val < 45)
                            shotType = ShotType.JUMP;
                        else if (val < 50)
                            shotType = ShotType.TOP_THREE;
                        else if (val < 65)
                            shotType = ShotType.THREE;
                        else
                            shotType = ShotType.CORNER_THREE;
                        break;
                    case 3:
                        if (val < 15)
                            shotType = ShotType.LAYUP;
                        else if (val < 30)
                            shotType = ShotType.DUNK;
                        else if (val < 50)
                            shotType = ShotType.JUMP;
                        else if (val < 70)
                            shotType = ShotType.TOP_THREE;
                        else if (val < 85)
                            shotType = ShotType.THREE;
                        else
                            shotType = ShotType.CORNER_THREE;
                        break;
                    case 4:
                        if (val < 38)
                            shotType = ShotType.LAYUP;
                        else if (val < 75)
                            shotType = ShotType.DUNK;
                        else if (val < 90)
                            shotType = ShotType.JUMP;
                        else if (val < 93)
                            shotType = ShotType.TOP_THREE;
                        else if (val < 98)
                            shotType = ShotType.THREE;
                        else
                            shotType = ShotType.CORNER_THREE;
                        break;

                    default:
                        break;
                }

            }
            else
            {
                switch (role)
                {
                    case 0:
                        if (val < 20)
                            shotType = ShotType.LAYUP;
                        else if (val < 40)
                            shotType = ShotType.DUNK;
                        else if (val < 60)
                            shotType = ShotType.JUMP;
                        else if (val < 70)
                            shotType = ShotType.TOP_THREE;
                        else if (val < 80)
                            shotType = ShotType.THREE;
                        else
                            shotType = ShotType.CORNER_THREE;
                        break;

                    case 1:
                        if (val < 15)
                            shotType = ShotType.LAYUP;
                        else if (val < 30)
                            shotType = ShotType.DUNK;
                        else if (val < 60)
                            shotType = ShotType.JUMP;
                        else if (val < 70)
                            shotType = ShotType.TOP_THREE;
                        else if (val < 80)
                            shotType = ShotType.THREE;
                        else
                            shotType = ShotType.CORNER_THREE;
                        break;
                    case 2:
                        if (val < 15)
                            shotType = ShotType.LAYUP;
                        else if (val < 30)
                            shotType = ShotType.DUNK;
                        else if (val < 60)
                            shotType = ShotType.JUMP;
                        else if (val < 70)
                            shotType = ShotType.TOP_THREE;
                        else if (val < 80)
                            shotType = ShotType.THREE;
                        else
                            shotType = ShotType.CORNER_THREE;
                        break;
                    case 3:
                        if (val < 20)
                            shotType = ShotType.LAYUP;
                        else if (val < 40)
                            shotType = ShotType.DUNK;
                        else if (val < 70)
                            shotType = ShotType.JUMP;
                        else if (val < 75)
                            shotType = ShotType.TOP_THREE;
                        else if (val < 90)
                            shotType = ShotType.THREE;
                        else
                            shotType = ShotType.CORNER_THREE;
                        break;
                    case 4:
                        if (val < 38)
                            shotType = ShotType.LAYUP;
                        else if (val < 75)
                            shotType = ShotType.DUNK;
                        else if (val < 90)
                            shotType = ShotType.JUMP;
                        else if (val < 94)
                            shotType = ShotType.TOP_THREE;
                        else if (val < 98)
                            shotType = ShotType.THREE;
                        else
                            shotType = ShotType.CORNER_THREE;
                        break;

                    default:
                        break;
                }
            }

            return new Tuple<ShotType, int, NewPlayer>(shotType, timeElapsed, offensivePlayer);
        }
        private int GetRole(NewPlayer player)
        {
            for (int i = 0; i < roles.Length; i++)
            {
                if (roles[i].GetPlayerID() == player.GetPlayerID())
                    return i;
            }
            return 0;
        }
        private void AssignRoles(NewCurrentTeam team)
        {
            roles = new NewPlayer[5];
            List<NewPlayer> players = new List<NewPlayer>(team.GetCurrentPlayers());

            double score = 0;
            NewPlayer best = players[0];
            foreach (NewPlayer p in players)
            {
                double tempScore = p.GetOffenseIQRating(true, false) * .8 + p.GetPassingRating(true, false) * .6 + p.GetInsideRating(true, false) * .2;
                if (tempScore > score)
                {
                    score = tempScore;
                    best = p;
                }
            }
            players.Remove(best);
            roles[0] = best;

            score = 0;
            best = players[0];

            foreach (NewPlayer p in players)
            {
                double tempScore = p.GetOffenseIQRating(true, false) * .4 + p.GetThreePointRating(true, false) * .7 + p.GetJumpShotRating(true, false) * .5;
                if (tempScore > score)
                {
                    score = tempScore;
                    best = p;
                }
            }
            players.Remove(best);
            roles[1] = best;

            score = 0;
            best = players[0];

            foreach (NewPlayer p in players)
            {
                double tempScore = p.GetOffenseIQRating(true, false) * .4 + p.GetThreePointRating(true, false) * .7 + p.GetJumpShotRating(true, false) * .5;
                if (tempScore > score)
                {
                    score = tempScore;
                    best = p;
                }
            }
            players.Remove(best);
            roles[2] = best;

            score = 0;
            best = players[0];

            foreach (NewPlayer p in players)
            {
                double tempScore = p.GetOffenseIQRating(true, false) * .4 + p.GetInsideRating(true, false) * .7 + p.GetJumpShotRating(true, false) * .5;
                if (tempScore > score)
                {
                    score = tempScore;
                    best = p;
                }
            }
            players.Remove(best);
            roles[3] = best;

            roles[4] = players[0];

        }
        private NewPlayer GetPlayer(NewPlayer starter, NewCurrentTeam team)
        {
            NewPlayer[] players = team.GetCurrentPlayers();
            int[] probabilities = new int[5];

            for (int i = 0; i < players.Length; i++)
            {
                for (int j = 0; j < roles.Length; j++)
                {
                    if (roles[j].GetPlayerID() == players[i].GetPlayerID())
                    {
                        switch (j)
                        {
                            case 0:
                                probabilities[i] = 60;
                                break;
                            case 1:
                                probabilities[i] = 35;
                                break;
                            case 2:
                                probabilities[i] = 35;
                                break;
                            case 3:
                                probabilities[i] = 25;
                                break;
                            default:
                                probabilities[i] = 10;
                                break;
                        }
                    }
                }

                if (players[i].GetPlayerID() == starter.GetPlayerID())
                {
                    probabilities[i] += 50;
                }
            }

            int sum = 0;
            foreach (int probability in probabilities)
                sum += probability;

            int randNum = League.r.Next(sum);
            int runningSum = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                runningSum += probabilities[i];
                if (randNum < runningSum)
                    return players[i];
            }

            return players[0];
        }
        public override NewPlayer[] GetStartingFive(NewTeam team)
        {
            NewPlayer[] startingFive = new NewPlayer[5];
            List<NewPlayer> players = new List<NewPlayer>(team.GetPlayers());

            List<NewPlayer> injuredOrUnavailable = new List<NewPlayer>();
            foreach (NewPlayer p in players)
            {
                if (p.IsInjured())
                {
                    injuredOrUnavailable.Add(p);
                }
            }
            foreach (NewPlayer p in injuredOrUnavailable)
            {
                players.Remove(p);
            }

            double score = 0;
            NewPlayer best = players[0];
            foreach (NewPlayer p in players)
            {
                double tempScore = p.GetOffenseIQRating(true, false) * .8 + p.GetPassingRating(true, false) * .6 + p.GetInsideRating(true, false) * .2;
                if (tempScore > score)
                {
                    score = tempScore;
                    best = p;
                }
            }
            players.Remove(best);
            startingFive[0] = best;

            score = 0;
            best = players[0];

            foreach (NewPlayer p in players)
            {
                double tempScore = p.GetOffenseIQRating(true, false) * .4 + p.GetThreePointRating(true, false) * .7 + p.GetJumpShotRating(true, false) * .5;
                if (tempScore > score)
                {
                    score = tempScore;
                    best = p;
                }
            }
            players.Remove(best);
            startingFive[1] = best;

            score = 0;
            best = players[0];

            foreach (NewPlayer p in players)
            {
                double tempScore = p.GetOffenseIQRating(true, false) * .4 + p.GetThreePointRating(true, false) * .7 + p.GetJumpShotRating(true, false) * .5;
                if (tempScore > score)
                {
                    score = tempScore;
                    best = p;
                }
            }
            players.Remove(best);
            startingFive[2] = best;

            score = 0;
            best = players[0];

            foreach (NewPlayer p in players)
            {
                double tempScore = p.GetOffenseIQRating(true, false) * .4 + p.GetInsideRating(true, false) * .7 + p.GetJumpShotRating(true, false) * .5;
                if (tempScore > score)
                {
                    score = tempScore;
                    best = p;
                }
            }
            players.Remove(best);
            startingFive[3] = best;

            score = 0;
            best = players[0];

            foreach (NewPlayer p in players)
            {
                double tempScore = p.GetOffenseIQRating(true, false) * .4 + p.GetInsideRating(true, false) * .7 + p.GetJumpingRating(true, false) * .7;
                if (tempScore > score)
                {
                    score = tempScore;
                    best = p;
                }
            }
            players.Remove(best);
            startingFive[4] = best;

            return startingFive;
        }
        public override NewPlayer GetDefender(NewPlayer shooter, NewCurrentTeam team, NewCurrentTeam opponent)
        {
            byte position = shooter.GetPosition();
            NewPlayer[] players = team.GetCurrentPlayers();
            int[] probabilities = new int[5];

            for (int i = 0; i < players.Length; i++)
            {
                int num = Math.Abs(players[i].GetPosition() - position);
                if (num == 0)
                {
                    probabilities[i] = 60;
                }
                else if (num == 1)
                {
                    probabilities[i] = 25;
                }
                else if (num == 2)
                {
                    probabilities[i] = 10;
                }
                else
                {
                    probabilities[i] = 1;
                }
            }

            int sum = 0;
            foreach (int probability in probabilities)
                sum += probability;

            int randNum = League.r.Next(sum);
            int runningSum = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                runningSum += probabilities[i];
                if (randNum < runningSum)
                    return players[i];
            }

            return players[0];

        }
        public override NewPlayer GetPlayStarter(NewCurrentTeam team)
        {
            NewPlayer[] players = team.GetCurrentPlayers();
            int[] probabilities = new int[5];

            // Set the probability of each player getting the ball to start the play.

            int sum = 0;
            foreach (int probability in probabilities)
                sum += probability;

            int randNum = League.r.Next(sum);
            int runningSum = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                runningSum += probabilities[i];
                if (randNum < runningSum)
                    return players[i];
            }

            return players[0];
        }
        public override NewPlayer GetInsideShooter(NewCurrentTeam team, NewPlayer starter)
        {
            NewPlayer[] players = team.GetCurrentPlayers();
            int[] probabilities = new int[5];

            // Set the probability of each player getting the ball to shoot.
            if (starter == null)
                starter = GetPlayStarter(team);

            int sum = 0;
            foreach (int probability in probabilities)
                sum += probability;

            int randNum = League.r.Next(sum);
            int runningSum = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                runningSum += probabilities[i];
                if (randNum < runningSum)
                    return players[i];
            }

            return players[0];
        }

        public override NewPlayer GetJumpShooter(NewCurrentTeam team, NewPlayer starter)
        {
            NewPlayer[] players = team.GetCurrentPlayers();
            int[] probabilities = new int[5];

            // Set the probability of each player getting the ball to shoot.
            if (starter == null)
                starter = GetPlayStarter(team);

            int sum = 0;
            foreach (int probability in probabilities)
                sum += probability;

            int randNum = League.r.Next(sum);
            int runningSum = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                runningSum += probabilities[i];
                if (randNum < runningSum)
                    return players[i];
            }

            return players[0];
        }

        public override NewPlayer GetThreeShooter(NewCurrentTeam team, NewPlayer starter)
        {
            NewPlayer[] players = team.GetCurrentPlayers();
            int[] probabilities = new int[5];

            // Set the probability of each player getting the ball to shoot.
            if (starter == null)
                starter = GetPlayStarter(team);

            int sum = 0;
            foreach (int probability in probabilities)
                sum += probability;

            int randNum = League.r.Next(sum);
            int runningSum = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                runningSum += probabilities[i];
                if (randNum < runningSum)
                    return players[i];
            }

            return players[0];
        }
    }*/

    public abstract class NewOffensivePhilosophy
    {
        public abstract int GetNumberOfPlays(int seconds);
        public abstract PlayStats GetStats(int plays, NewCurrentTeam offense, NewCurrentTeam defense, int quarter, bool clutchSituation);
        public abstract double[] GetOffensiveUsageRate(NewCurrentTeam team);
        public static double GetOffensiveIQTeamRating(NewCurrentTeam team, double[] usageRate, bool clutchSituation)
        {
            NewPlayer[] players = team.GetCurrentPlayers();

            double teamRating = 0.0;

            for(int i = 0; i < players.Length; i++)
            {
                teamRating += players[i].GetOffenseIQRating(true, clutchSituation) * usageRate[i];                
            }

            return teamRating;
        }

        public abstract byte DistributeShots(PlayStats stats, NewCurrentTeam offense, NewCurrentTeam defense, bool clutch);
    }
    public abstract class NewDefensivePhilosophy
    {
        public abstract Tuple<double[], int[]> GetDefensiveUsageRate(NewCurrentTeam team, Tuple<int, double>[] offenseUsageRate);
        public static double GetDefensiveIQTeamRating(NewCurrentTeam team, double[] usageRate, bool clutchSituation)
        {
            NewPlayer[] players = team.GetCurrentPlayers();

            double teamRating = 0.0;

            for (int i = 0; i < players.Length; i++)
            {
                teamRating += players[i].GetDefenseIQRating(true, clutchSituation) * usageRate[i];
            }

            return teamRating;
        }
    }
    public abstract class PlayerPhilosophy
    {
        protected NewPlayer[] startingFive;
        public abstract void StartGame(NewTeam team);
        public abstract NewPlayer[] GetStartingFive(NewTeam team);
        public abstract NewPlayer[] DoSubstitutions(NewTeam team, int quarter);
        public abstract int GetSecondsUntilSubstitutions(NewCurrentTeam team);
        protected List<Tuple<NewPlayer, double, int>>[] GetLists(NewTeam team, bool staminaAffected)
        {
            List<Tuple<NewPlayer, double, int>>[] list = new List<Tuple<NewPlayer, double, int>>[5];

            list[0] = new List<Tuple<NewPlayer, double, int>>();
            list[1] = new List<Tuple<NewPlayer, double, int>>();
            list[2] = new List<Tuple<NewPlayer, double, int>>();
            list[3] = new List<Tuple<NewPlayer, double, int>>();
            list[4] = new List<Tuple<NewPlayer, double, int>>();

            foreach (NewPlayer p in team)
            {
                if (!p.CanPlay())
                    continue;

                list[0].Add(new Tuple<NewPlayer, double, int>(p, p.GetRatingAsCenter(staminaAffected), p.GetPosition()));
                list[1].Add(new Tuple<NewPlayer, double, int>(p, p.GetRatingAsPowerForward(staminaAffected), p.GetPosition()));
                list[2].Add(new Tuple<NewPlayer, double, int>(p, p.GetRatingAsSmallForward(staminaAffected), p.GetPosition()));
                list[3].Add(new Tuple<NewPlayer, double, int>(p, p.GetRatingAsShootingGuard(staminaAffected), p.GetPosition()));
                list[4].Add(new Tuple<NewPlayer, double, int>(p, p.GetRatingAsPointGuard(staminaAffected), p.GetPosition()));
            }

            for (int i = 0; i < list.Length; i++)
            {
                list[i] = SortList(list[i], i + 1);
            }
            return list;
        }
        protected List<Tuple<NewPlayer, double, int>> SortList(List<Tuple<NewPlayer, double, int>> list, int position)
        {
            List<Tuple<NewPlayer, double, int>> retVal = new List<Tuple<NewPlayer, double, int>>();
            int count = list.Count;

            while (count != 0)
            {
                NewPlayer player = null;
                double num = 0;
                int index = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    Tuple<NewPlayer, double, int> p = list[i];
                    if (p.Item2 > num || (p.Item2 == num && p.Item3 == position && player.GetPosition() != position))
                    {
                        player = p.Item1;
                        num = p.Item2;
                        index = i;
                    }
                }
                retVal.Add(list[index]);
                list.RemoveAt(index);

                count--;
            }

            return retVal;
        }
    }
    public class PlayStats
    {
        public readonly int threesAttempted, twosAttempted, steals, nonStealTurnovers, freeThrowsAttempted, fouls, potentialAssists;
        public readonly double[] offensiveUsage;
        public readonly Tuple<double[], int[]> defensiveUsage;
        public PlayStats(int threesAttempted, int twosAttempted, int steals, int nonStealTurnovers, double[] offensiveUsageRate, Tuple<double[], int[]> defensiveUsageRate, int fouls, double freeThrowRate, int potentialAssists)
        {
            this.threesAttempted = threesAttempted;
            this.twosAttempted = twosAttempted;
            this.steals = steals;
            this.nonStealTurnovers = nonStealTurnovers;
            this.fouls = fouls;
            this.potentialAssists = potentialAssists;
            freeThrowsAttempted = League.r.NextGaussian((int)((twosAttempted + threesAttempted) * freeThrowRate) + 1, 1);

            offensiveUsage = offensiveUsageRate;
            defensiveUsage = defensiveUsageRate;

        }
    }
}
