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
            league = FirstTimeSetup(create);

            
            string text = "", teamText = "", pickText = "", retiredText = "";

            for(int i = 0; i < 32; i++)
            {
                NewTeam team = league.GetTeam(i);
                teamText += i + "," + team.ToString() + "\n";
                teamText += (i + 32) + "," + league.GetDLeagueTeam(i).ToString() + "\n";
                foreach (NewPlayer player in team)
                {
                    if(player.IsRetired())
                    {
                        retiredText += i + ",";
                        retiredText += player.GetText();
                    }
                    else
                    {
                        text += i + ",";
                        text += player.GetText();
                    }
                }
                foreach (NewPlayer player in league.GetDLeagueTeam(i))
                {
                    if (player.IsRetired())
                    {
                        retiredText += (i + 32) + ",";
                        retiredText += player.GetText();
                    }
                    else
                    {
                        text += (i + 32) + ",";
                        text += player.GetText();
                    }
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

            foreach (NewPlayer p in league.GetFreeAgents().GetAllPlayers())
            {
                if (p.IsRetired())
                {
                    retiredText += "-1,";
                    retiredText += p.GetText();
                }
                else
                {
                    text += "-1,";
                    text += p.GetText();
                    p.SetContract(null);
                }
            }

            File.WriteAllText("C:\\Users\\Matthew\\source\\repos\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\players.csv", text);

            File.WriteAllText("C:\\Users\\Matthew\\source\\repos\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\teams.csv", teamText);

            File.WriteAllText("C:\\Users\\Matthew\\source\\repos\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\picks.csv", pickText);

            File.WriteAllText("C:\\Users\\Matthew\\source\\repos\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\retiredPlayers.csv", retiredText);
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
                    case 1:
                        new ManageTeam(league).ShowDialog();
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
        public NewFormulaBasketball(League league)
        {            
            ImagePrinter printer = new ImagePrinter(league.GetGamesPlayed() + 1, league);
            league.Update();
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
            //league.CreateSchedule();
            bool flag = false;
            while (!flag)
            {
                new ControlForm().ShowDialog();

                switch (ControlForm.result)
                {
                    case 0:

                        Standings standings = new Standings(true);
                        standings.Show();
                        standings.updateStandings(league, true);
                        for(int j = 0; j < 4; j++)
                        {
                            List<Tuple<int, int>> list = league.GetNextGames();
                            foreach (Tuple<int, int> item in list)
                            {
                                NewTeam awayTeam = league.GetTeam(item.Item1);
                                NewTeam homeTeam = league.GetTeam(item.Item2);
                                

                                if (item.Item1 != 2 && item.Item1 != 7 && item.Item1 != 12 && item.Item1 != 19)
                                    awayTeam.SortPlayers();
                                if (item.Item2 != 2 && item.Item2 != 7 && item.Item2 != 12 && item.Item2 != 19)
                                    homeTeam.SortPlayers();

                                ScoreCheater result = new ScoreCheater(awayTeam, homeTeam);

                                result.ShowDialog();

                                int awayScore = 0, homeScore = 0;
                                for (int i = 0; i < result.GetAwayScores().Count; i++)
                                {
                                    awayScore += result.GetAwayScores()[i];
                                    homeScore += result.GetHomeScores()[i];
                                }
                                printer.AddResult(awayTeam, homeTeam, awayScore, homeScore, false);

                                awayTeam.FinishGame(awayScore, homeScore, homeTeam.GetTeamNum(), false);
                                homeTeam.FinishGame(homeScore, awayScore, awayTeam.GetTeamNum(), false);

                                league.AddScores(result, awayTeam.GetTeamNum(), homeTeam.GetTeamNum(), awayTeam.GetWins() + awayTeam.GetLosses());

                                awayTeam = league.GetDLeagueTeam(item.Item1);
                                homeTeam = league.GetDLeagueTeam(item.Item2);

                                result = new ScoreCheater(awayTeam, homeTeam);

                                result.ShowDialog();

                                awayScore = 0;
                                homeScore = 0;
                                for (int i = 0; i < result.GetAwayScores().Count; i++)
                                {
                                    awayScore += result.GetAwayScores()[i];
                                    homeScore += result.GetHomeScores()[i];
                                }
                                printer.AddResult(awayTeam, homeTeam, awayScore, homeScore, true);

                                awayTeam.FinishGame(awayScore, homeScore, (sbyte)item.Item2, false);
                                homeTeam.FinishGame(homeScore, awayScore, (sbyte)item.Item1, false);

                                league.AddScores(result, item.Item1 + 32, item.Item2 + 32, awayTeam.GetWins() + awayTeam.GetLosses());
                            }
                            standings.updateStandings(league, true);
                        }
                        
                        League.SerializeObject(league, "league.fbleague");
                        Standings dLeague = new Standings(true);
                        dLeague.Show();
                        dLeague.updateStandings(league, false);
                        dLeague.SaveForm("images/dleague.png");
                        standings.SaveForm("images/standings.png");
                        break;
                    case 1:
                        new ManageTeam(league).ShowDialog();
                        break;
                    case 2:
                        new AddInjuryForm(league).ShowDialog();
                        League.SerializeObject(league, "league.fbleague");
                        break;
                    case 3:
                        league.DoPlayoffRound();
                        break;
                    case 4:
                        new CoachForm(league).ShowDialog();
                        break;
                    case 5:
                        new PlayerRetirement(league).ShowDialog();
                        foreach (NewTeam t in league)
                        {
                            if (t.GetTeamNum() == 7 || t.GetTeamNum() == 19 || t.GetTeamNum() == 12)
                                continue;

                            List<NewPlayer> players = new List<NewPlayer>();

                            foreach (NewPlayer p in t)
                            {
                                if (p.GetContract() == null || p.GetContract().GetYearsLeft() <= 0)
                                    players.Add(p);
                            }
                            foreach (NewPlayer p in players)
                            {
                                league.GetFreeAgents().Add(p);
                                t.RemovePlayer(p);
                            }
                            players = new List<NewPlayer>();
                            foreach (NewPlayer p in league.GetDLeagueTeam(t.GetTeamNum()))
                            {
                                if (p.GetAge() >= 27)
                                    players.Add(p);
                            }
                            foreach (NewPlayer p in players)
                            {
                                league.GetFreeAgents().Add(p);
                                league.GetDLeagueTeam(t.GetTeamNum()).RemovePlayer(p);
                            }
                        }
                        League.SerializeObject(league, "league.fbleague");
                        break;
                    default:
                        flag = true;
                        break;
                }
            }
        }
        public static League FirstTimeSetup(createTeams create)
        {
            League league = new League(new Random());
            bool continueFlag = true;
            foreach(team t in create.getTeams())
            {
                foreach(player p in t)
                {
                    if(!p.GetHasBeenEdited() && continueFlag)
                    {
                        PlayerEditor playerEditor = new PlayerEditor(p);
                        continueFlag = playerEditor.ShowDialog() == System.Windows.Forms.DialogResult.Yes;
                    }
                    if (!continueFlag)
                        break;
                }
                if (!continueFlag)
                    break;
            }


            new PlayerRetirement(create).ShowDialog();

            formulaBasketball.SerializeObject(create, "0Test.fbdata");


            double bestStamina = 0, worstStamina = double.MaxValue;
            Dictionary<uint, NewPlayer> newPlayers = new Dictionary<uint, NewPlayer>();
            foreach (team t in create.getTeams())
            {
                NewTeam team = new NewTeam(t);
                NewTeam dLeague = new NewTeam(t.GetAffiliate());
                List<NewPlayer> playersToRemove = new List<NewPlayer>(), dLeaguePlayersToRemove = new List<NewPlayer>();
                league.AddTeam(team, dLeague);

                foreach (NewPlayer p in team)
                {
                    newPlayers.Add(p.GetPlayerID(), p);
                    if(p.GetPlayerID() == 733)
                    {
                        Console.WriteLine("How do you exist");
                    }
                    if (p.GetContract().GetYearsLeft() <= 0 && !p.IsRetired())
                    {
                        league.AddPlayerToFreeAgents(p);
                        playersToRemove.Add(p);
                    }

                    if (p.GetStaminaRating(false, false) > bestStamina)
                        bestStamina = p.GetStaminaRating(false, false);

                    if (p.GetStaminaRating(false, false) < worstStamina)
                        worstStamina = p.GetStaminaRating(false, false);
                }

                NewPlayer promotedPlayer = null;

                foreach (NewPlayer p in dLeague)
                {
                    newPlayers.Add(p.GetPlayerID(), p);
                    if (p.GetPlayerID() == 733)
                    {
                        Console.WriteLine("How do you exist");
                    }
                    if (p.GetPlayerID() == 378 || p.GetPlayerID() == 76)
                        promotedPlayer = p;

                    switch(p.GetPlayerID())
                    {
                        case 585:
                        case 588:
                        case 589:
                        case 592:
                        case 596:
                        case 376:
                        case 379:
                        case 383:
                        case 384:
                        case 389:
                            dLeaguePlayersToRemove.Add(p);
                            break;
                    }

                    p.SetContract(new Contract(1, 1));

                    if (p.GetStaminaRating(false, false) > bestStamina)
                        bestStamina = p.GetStaminaRating(false, false);

                    if (p.GetStaminaRating(false, false) < worstStamina)
                        worstStamina = p.GetStaminaRating(false, false);
                }

                if(promotedPlayer != null)
                    team.AddPlayer(promotedPlayer);

                foreach (NewPlayer p in playersToRemove)
                    team.RemovePlayer(p);

                foreach (NewPlayer p in dLeaguePlayersToRemove)
                    dLeague.RemovePlayer(p);
            }            
            foreach(player p in create.getFreeAgents().GetAllPlayers())
            {
                
                if (p.GetPlayerID() == 733)
                {
                    Console.WriteLine("How do you exist");
                }

                p.SetNewContract(null);

                if (p.getStaminaRating(false) < 11)
                {
                    p.updateRatings(League.r);
                }
                NewPlayer temp = new NewPlayer(p);
                if(temp.GetPlayerID() < 1283)
                    newPlayers.Add(temp.GetPlayerID(), temp);
                league.AddPlayerToFreeAgents(temp);

                
            }
            foreach(NewPlayer p in league.GetFreeAgents().GetAllPlayers())
            {
                if (p.GetStaminaRating(false, false) > bestStamina)
                    bestStamina = p.GetStaminaRating(false, false);

                if (p.GetStaminaRating(false, false) < worstStamina)
                    worstStamina = p.GetStaminaRating(false, false);

            }

            string[] lines = File.ReadAllLines("C:\\Users\\Matthew\\source\\repos\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\players.csv");
            string[] rookies = File.ReadAllLines("C:\\Users\\Matthew\\source\\repos\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\newplayers.csv");
            string[] picks = File.ReadAllLines("C:\\Users\\Matthew\\source\\repos\\FormulaBasketballBot\\FormulaBasketballBot\\Modules\\picks.csv");
            foreach (NewTeam t in league)
            {
                t.ClearPlayers();
                //t.AdvancePicks();
                t.VerifyPicks(picks);
            }
            for (int i = 0; i < 32; i++) 
            {
                league.GetDLeagueTeam(i).ClearPlayers();
            }
            league.GetFreeAgents().Clear();
            foreach (string line in lines)
            {
                string[] stats = line.Split(',');
                int team = int.Parse(stats[0]);

                if (team == -2)
                    continue;

                NewPlayer curr;

                if (newPlayers.ContainsKey(uint.Parse(stats[1])))
                    curr = newPlayers[uint.Parse(stats[1])];
                else
                {
                    byte position;
                    byte[] ratings = new byte[11], maxRatings = new byte[11];
                    switch(stats[2])
                    {
                        default:
                            position = 1;
                            break;
                        case "PF":
                            position = 2;
                            break;
                        case "SF":
                            position = 3;
                            break;
                        case "SG":
                            position = 4;
                            break;
                        case "PG":
                            position = 5;
                            break;
                    }

                    string[] r = rookies[uint.Parse(stats[1]) - 1283].Split(',');

                    for(int i = 0; i <ratings.Length; i++)
                    {
                        ratings[i] = byte.Parse(r[2 + i]);
                        maxRatings[i] = byte.Parse(r[13 + i]);
                    }
                    curr = new NewPlayer(uint.Parse(stats[1]), position, stats[3], ratings, maxRatings, StringUtils.GetCountryFromString(r[1]), byte.Parse(r[25]), byte.Parse(r[26]), byte.Parse(r[27]), byte.Parse(r[24]));
                                         
                    NewPlayerEditor temp = new NewPlayerEditor(curr, double.Parse(r[28]), double.Parse(r[29]));
                    
                }                
                
                if(team == -1)
                {
                    league.GetFreeAgents().Add(curr);
                }
                else if(team < 32)
                {
                    league.GetTeam(team).AddPlayer(curr);
                }
                else
                {
                    league.GetDLeagueTeam(team - 32).AddPlayer(curr);
                }
                
            }


            League.SerializeObject(league, "league.fbleague");
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
            return league;

        }
    }
   
}
