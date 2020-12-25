using System;
using System.Collections.Generic;
using System.IO;

namespace FormulaBasketball
{
    public class NewFormulaBasketball
    {
        public static League league;
        public NewFormulaBasketball(createTeams create)
        {
            FirstTimeSetup(create);

            NameGenerator gen = NameGenerator.Instance();
            string content = "";
            foreach (string str in File.ReadAllLines("countriesRookies.txt"))
            {
                Country c = StringUtils.GetCountryFromString(str);
                content += gen.GenerateName(c) + '\n';
            }
            File.WriteAllText("test.txt",content);
            string text = "", teamText = "", pickText = "";

            for(int i = 0; i < 32; i++)
            {
                NewTeam team = league.GetTeam(i);
                teamText += i + "," + team.ToString() + "\n";
                teamText += (i + 32) + "," + league.GetDLeagueTeam(i).ToString() + "\n";
                foreach (NewPlayer player in team)
                {
                    text += i + ",";
                    text += player.GetText();
                }
                foreach (NewPlayer player in league.GetDLeagueTeam(i))
                {
                    text += (i + 32) + ",";
                    text += player.GetText();
                }
                foreach(NewDraftPick pick in team.GetCurrentPicks())
                {
                    pickText += pick.GetOwner() + "," + pick.GetSeason() + "," + pick.GetRound() + "," + pick.GetTeam() + "\n";
                }
                foreach (NewDraftPick pick in team.GetNextPicks())
                {
                    pickText += pick.GetOwner() + "," + pick.GetSeason() + "," + pick.GetRound() + "," + pick.GetTeam() + "\n";
                }
            }

            foreach (player p in create.getFreeAgents().GetAllPlayers())
            {
                NewPlayer newP = new NewPlayer(p);
                text += "-1,";
                text += newP.GetText();
            }

            File.WriteAllText("C:\\Users\\Matthew\\source\\repos\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\players.csv", text);

            File.WriteAllText("C:\\Users\\Matthew\\source\\repos\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\teams.csv", teamText);

            File.WriteAllText("C:\\Users\\Matthew\\source\\repos\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\picks.csv", pickText);
            /*int remainingShots = 25;
            int assistsRemaining = 16;

            while(remainingShots != 0)
            {
                double num = League.r.NextDouble();
                double percent = (double)assistsRemaining / (double)remainingShots;

                if(num < percent)
                {
                    assistsRemaining--;
                }
                remainingShots--;

            }

            Dictionary<int, int> map = new Dictionary<int, int>();
            for(int i = 0; i < 1000; i++)
            {
                int potentialAssists = League.r.NextGaussian(0, 1);
                if (map.ContainsKey(potentialAssists))
                    map[potentialAssists]++;
                else
                    map.Add(potentialAssists, 1);
            }

            foreach (KeyValuePair<int, int> pair in map)
                Console.WriteLine(pair.Key + ": " + pair.Value);*/
            league.CreateSchedule();
            bool flag = false;
            while (!flag)
            {
                new ControlForm().ShowDialog();
               
                switch (ControlForm.result)
                {
                    case 0:
                        List<Tuple<int, int>> list = league.GetNextGames();
                        foreach(Tuple<int, int> item in list)
                        {
                            new GameResult(league.GetTeam(item.Item1), league.GetTeam(item.Item2)).ShowDialog();
                        }
                        break;
                    default:
                        flag = true;
                        break;
                }
            }
            

           /* for (int i = 0; i < 1000; i++)
            {
                league.CreateSchedule();
                league.PlayGames(84);
                league.DoPlayoffs();
                Console.WriteLine(i);
            }

            int bestSeason = 0, worstSeason = int.MaxValue, mostWins = 0;
            string mostWinnerTeam = "", bestSeasonTeam = "", worstSeasonTeam = "";
            for (int i = 0; i < 32; i ++)
            {
                if(league.GetTeam(i).GetBestPlace() > bestSeason)
                {
                    bestSeason = league.GetTeam(i).GetBestPlace();
                    bestSeasonTeam = league.GetTeam(i).ToString();
                }
                if (league.GetTeam(i).GetWorstPlace() < worstSeason)
                {
                    worstSeason = league.GetTeam(i).GetWorstPlace();
                    worstSeasonTeam = league.GetTeam(i).ToString();
                }
                if(league.GetTeam(i).GetChampionships() > mostWins)
                {
                    mostWins = league.GetTeam(i).GetChampionships();
                    mostWinnerTeam = league.GetTeam(i).ToString();
                }


                if (i == 2)
                {
                    league.GetTeam(i).PrintInfo("calto");
                }
                else if(i == 7)
                {
                    league.GetTeam(i).PrintInfo("solea");
                }
                else if(i == 12)
                {
                    league.GetTeam(i).PrintInfo("nova");
                }
                else if(i == 19)
                {
                    league.GetTeam(i).PrintInfo("dotruga");
                }
                //NewGame game = new NewGame(league.GetTeam(i), league.GetTeam(i + 1));
            }
            Console.WriteLine("event:all:The most common winner was the " + mostWinnerTeam + " who won " + mostWins + "/1000 championships.");
            Console.WriteLine("event:all:The best season was a " + bestSeason + "-" + (84 - bestSeason) + " campaign by the " + bestSeasonTeam + ".");
            Console.WriteLine("event:all:The worst season was a " + worstSeason + "-" + (84 - worstSeason) + " campaign by the " + worstSeasonTeam + ".");*/
        }
        private void FirstTimeSetup(createTeams create)
        {
            league = new League(new Random());

            double bestStamina = 0, worstStamina = double.MaxValue;

            foreach (team t in create.getTeams())
            {
                NewTeam team = new NewTeam(t);
                NewTeam dLeague = new NewTeam(t.GetAffiliate());

                league.AddTeam(team, dLeague);

                foreach (NewPlayer p in team)
                {
                    if (p.GetStaminaRating(false, false) > bestStamina)
                        bestStamina = p.GetStaminaRating(false, false);

                    if (p.GetStaminaRating(false, false) < worstStamina)
                        worstStamina = p.GetStaminaRating(false, false);
                }
                foreach (NewPlayer p in dLeague)
                {
                    if (p.GetStaminaRating(false, false) > bestStamina)
                        bestStamina = p.GetStaminaRating(false, false);

                    if (p.GetStaminaRating(false, false) < worstStamina)
                        worstStamina = p.GetStaminaRating(false, false);
                }
            }            
            foreach(player p in create.getFreeAgents().GetAllPlayers())
            {
                if (p.getStaminaRating(false) < 11)
                {
                    p.updateRatings(League.r);
                }
                league.AddPlayerToFreeAgents(new NewPlayer(p));
            }
            foreach(NewPlayer p in league.GetFreeAgents().GetAllPlayers())
            {
                if (p.GetStaminaRating(false, false) > bestStamina)
                    bestStamina = p.GetStaminaRating(false, false);

                if (p.GetStaminaRating(false, false) < worstStamina)
                    worstStamina = p.GetStaminaRating(false, false);

            }

            double slope = 85.0 / 70.0;
            double yIntercept = 15 - slope * 40;
            bestStamina = 0;
            worstStamina = double.MaxValue;

            foreach (NewPlayer p in league.GetFreeAgents().GetAllPlayers())
            {
                byte newStamina = (byte)Math.Round(slope * Math.Max(League.r.Next(40, 50), p.GetStaminaRating(false, false)) + yIntercept);
                if (newStamina > bestStamina)
                    bestStamina = newStamina;

                if (newStamina < worstStamina)
                    worstStamina = newStamina;

                p.ChangeRating(9, newStamina);
            }
            for(int i = 0; i < 32; i++)
            {
                foreach(NewPlayer p in league.GetTeam(i))
                {
                    byte newStamina = (byte)Math.Round(slope * Math.Max(League.r.Next(40, 50), p.GetStaminaRating(false, false)) + yIntercept);
                    if (newStamina > bestStamina)
                        bestStamina = newStamina;

                    if (newStamina < worstStamina)
                        worstStamina = newStamina;

                    p.ChangeRating(9, newStamina);
                }
                foreach(NewPlayer p in league.GetDLeagueTeam(i))
                {
                    byte newStamina = (byte)Math.Round(slope * Math.Max(League.r.Next(40, 50), p.GetStaminaRating(false, false)) + yIntercept);
                    if (newStamina > bestStamina)
                        bestStamina = newStamina;

                    if (newStamina < worstStamina)
                        worstStamina = newStamina;

                    p.ChangeRating(9, newStamina);
                }
            }
            

        }
    }
   
}
