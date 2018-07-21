using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormulaBasketball;
using System.IO;


public class TestLeague
{
    private FormulaBasketball.Random r;
    private team[] teams;
    public TestLeague(FormulaBasketball.Random r)
    {
        this.r = r;
        teams = new team[32];

        for (int i = 0; i < teams.Length; i++)
        {
            teams[i] = new team("Team " + i, r);
            
        }
        for(int i = 0; i < 15; i++)
        {
            teams[0].addPlayer(new player((i % 5)+1, 20, 20, 20, 20, 20, 20, 20, 20, 20, 50, 50, 20, "Player #" + (i + 1), i < 5, 32, 36, 10));
            teams[1].addPlayer(new player((i % 5) + 1, 100, 100, 100, 100, 100, 100, 100, 100, 100, 50, 50, 20, "Player #" + (i + 1), i < 5, 27, 30, 1));

            

        }

        for(int j = 2; j < teams.Length; j++)
        {
            int skill = r.Next(40, 80);
            int peakStart = r.NextGaussian(30, 1);
            int peakEnd = peakStart + Math.Max(1, r.NextGaussian(3, 1));
            int development = Math.Min(Math.Max(1, r.NextGaussian(6, 1)), 10);
            Console.WriteLine("Team #" + j + " has starting skill " + skill + " with a peak of " + peakStart + " - " + peakEnd + " and a development of " + development);
            for(int i = 0; i < 15; i++)
            {

                teams[j].addPlayer(new player((i % 5) + 1, skill, skill, skill, skill, skill, skill, skill, skill, skill, 50, 50, 20, "Player #" + (i + 1), i < 5, peakStart, peakEnd, development));

                

            }
       }


        for(int i = 0; i < 15; i++)
        {
            executeSeason(i);

        }

        TestSchedule schedule = new TestSchedule(this);



    }
    public void DevelopPlayers()
    {
        for(int i = 0; i < teams.Length; i++)
        {
            List<player> players = teams[i].getAllPlayer();
            for (int j = 0; j < players.Count; j++ )
            {
                players[j].Develop(r);
            }
        }
    }
    private void executeSeason(int season)
    {
        TestSchedule schedule = new TestSchedule(this);
        schedule.playGames(1, 84);

        List<player> players = new List<player>();
        String playersRatings = "";
       

        for (int i = 0; i < 32; i++)
        {
            team dLeague = teams[i];
            playersRatings += "Team #" + i + ",Player,Position,Layup,Dunk,Jumpshot,3PT,Pass,ShotContest,DefenseIQ,Jumping,Seperation,Durability,Stamina,Development,Age,Overall," + dLeague.getWins() + " - " + dLeague.getLosses() + "\n";
            foreach (player p in dLeague)
            {
                playersRatings += p.getRatingsAsString() + "\n";
                p.endSeason();
            }
            dLeague.endSeason();
        }

        String freeAgentFile = "Teams Season #" + season + ".csv";


        File.WriteAllText(freeAgentFile, playersRatings);




    }

    public bool executeGame(bool b, int i, int j)
    {
        bool retVal = false;
        int away = teams[i].lastThreeGames(-1);
        int home = teams[j].lastThreeGames(-1);



        int randomValue = r.Next(0, 100);
        if (away == 0 && home == 0)
        {
            if (randomValue < 10)
            {
                teams[i].setModifier(new BounceBackGame());
                teams[j].setModifier(new None());
            }
            else if (randomValue < 30)
            {
                teams[i].setModifier(new DefensiveNightmare());
                teams[j].setModifier(new DefensiveNightmare());
            }
            else if (randomValue < 40)
            {
                teams[i].setModifier(new None());
                teams[j].setModifier(new BounceBackGame());
            }
            else
            {
                teams[i].setModifier(new None());
                teams[j].setModifier(new None());
            }
        }
        else if ((away == 0 || away == 1) && home == 3)
        {
            if (randomValue < 15)
            {
                teams[i].setModifier(new BounceBackGame());
                teams[j].setModifier(new LetDownGame());
                
            }
            else if (randomValue < 25)
            {
                teams[i].setModifier(new StrugglesContinue());
                teams[j].setModifier(new ContinueRolling());
            }
            else
            {
                teams[i].setModifier(new None());
                teams[j].setModifier(new None());
            }

        }
        else if ((home == 0 || home == 1) && away == 3)
        {
            if (randomValue < 15)
            {
                teams[j].setModifier(new BounceBackGame());
                teams[i].setModifier(new LetDownGame());
                
            }
            else if (randomValue < 25)
            {
                teams[j].setModifier(new StrugglesContinue());
                teams[i].setModifier(new ContinueRolling());
            }
            else
            {
                teams[j].setModifier(new None());
                teams[i].setModifier(new None());
            }
        }
        else if (away == 3 && home == 3)
        {
            if (randomValue < 5)
            {
                teams[i].setModifier(new ContinueRolling());
                teams[j].setModifier(new LetDownGame());
            }
            else if (randomValue < 10)
            {
                teams[i].setModifier(new LetDownGame());
                teams[j].setModifier(new ContinueRolling());
            }
            else
            {
                teams[i].setModifier(new None());
                teams[j].setModifier(new None());
            }

        }
        else
        {
            if (randomValue < 12)
            {
                teams[i].setModifier(new DefensiveNightmare());
                teams[j].setModifier(new None());
            }
            else if (randomValue < 25)
            {
                teams[i].setModifier(new OffenisveNightmare());
                teams[j].setModifier(new OffenisveNightmare());
            }
            else
            {
                teams[i].setModifier(new None());
                teams[j].setModifier(new None());
            }
        }
        if (i == 26 || i == 7 || i == 19)
        {
            teams[i].setModifier(new gettingHot());
        }

        else if (j == 26 || j == 7 || j == 19)
        {
            teams[j].setModifier(new gettingHot());
        }
        teams[i].addModifier(new HomeTeam());
        teams[i].addModifier(teams[i].getCoachModifier());
        teams[j].addModifier(teams[j].getCoachModifier());
        gameWriter gameWriter = new gameWriter(-1);

        game newGame = new game(gameWriter, teams[i], teams[j], r);


        teams[i].AddResult(j, newGame.getAwayTeamScore(), newGame.getHomeTeamScore());
       teams[j].AddResult(i, newGame.getHomeTeamScore(), newGame.getAwayTeamScore());

        


        for (int k = 0; k < teams[i].getSize(); k++)
        {
            teams[i].getPlayer(k).resetGameStats();
        }
        for (int k = 0; k < teams[j].getSize(); k++)
        {
            teams[j].getPlayer(k).resetGameStats();
        }
        return retVal;
    }
}




