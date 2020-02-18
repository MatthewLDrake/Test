using System;
using System.Collections.Generic;
[Serializable]
public class Schedule
{
    List<Action> list;
    private static Schedule instance;
    private bool dLeague;
    public static Schedule GetInstance(FormulaBasketball.Random r)
    {
        if (instance == null) instance = new Schedule(r);
        return instance;
    }
    private Schedule(FormulaBasketball.Random r)
    {
        list = new List<Action>();
        list.Add(() => Game1());        
        list.Add(() => Game2());        
        list.Add(() => Game3());        
        list.Add(() => Game4());        
        list.Add(() => Game5());        
        list.Add(() => Game6());        
        list.Add(() => Game7());        
        list.Add(() => Game8());        
        list.Add(() => Game9());
        list.Add(() => Game10());
        list.Add(() => Game11());
        list.Add(() => Game12());
        list.Add(() => Game13());
        list.Add(() => Game14());
        list.Add(() => Game15());
        list.Add(() => Game16());
        list.Add(() => Game17());
        list.Add(() => Game18());
        list.Add(() => Game19());
        list.Add(() => Game20());
        list.Add(() => Game21());
        list.Add(() => Game22());
        list.Add(() => Game23());
        list.Add(() => Game24());
        list.Add(() => Game25());
        list.Add(() => Game26());
        list.Add(() => Game27());
        list.Add(() => Game28());
        list.Add(() => Game29());
        list.Add(() => Game30());
        list.Add(() => Game31());
        list.Add(() => Game32());
        list.Add(() => Game33());
        list.Add(() => Game34());
        list.Add(() => Game35());
        list.Add(() => Game36());
        list.Add(() => Game37());
        list.Add(() => Game38());
        list.Add(() => Game39());
        list.Add(() => Game40());
        list.Add(() => Game41());
        list.Add(() => Game42());
        list.Add(() => Game43());
        list.Add(() => Game44());
        list.Add(() => Game45());
        list.Add(() => Game46());
        list.Add(() => Game47());
        list.Add(() => Game48());
        list.Add(() => Game49());
        list.Add(() => Game50());
        list.Add(() => Game51());
        list.Add(() => Game52());
        list.Add(() => Game53());
        list.Add(() => Game54());
        list.Add(() => Game55());
        list.Add(() => Game56());
        list.Add(() => Game57());
        list.Add(() => Game58());
        list.Add(() => Game59());
        list.Add(() => Game60());
        list.Add(() => Game61());
        list.Add(() => Game62());
        list.Add(() => Game63());
        list.Add(() => Game64());
        list.Add(() => Game65());
        list.Add(() => Game66());
        list.Add(() => Game67());
        list.Add(() => Game68());
        list.Add(() => Game69());
        list.Add(() => Game70());
        list.Add(() => Game71());
        list.Add(() => Game72());
        list.Add(() => Game73());
        list.Add(() => Game74());
        list.Add(() => Game75());
        list.Add(() => Game76());
        list.Add(() => Game77());
        list.Add(() => Game78());
        list.Add(() => Game79());
        list.Add(() => Game80());
        list.Add(() => Game81());
        list.Add(() => Game82());
        list.Add(() => Game83());
        list.Add(() => Game84());
        
    }
    /*public void playGames(int firstGame, int lastGame, FormulaBasketball.Random r)
    {
        for(int i = firstGame - 1; i < lastGame; i++)
        {
            if(i % 28 == 0)
            {
                foreach(team team in formulaBasketball.create.getTeams())
                {
                    foreach(player p in team)
                    {
                        p.Develop(r);
                    }
                    team.CheckInjuries(formulaBasketball.create.getFreeAgents());
                }
            }
            
            list[i].Invoke();
            formulaBasketball.updateStandings();
        }
    }*/
    public void playGames(int gameNum)
    {
        dLeague = false;
        list[gameNum].Invoke();
    }
    public void playDLeagueGames(int gameNum)
    {
        dLeague = true;
        list[gameNum].Invoke();
    }
    private void Game1()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 30, 0, dLeague);
        formulaBasketball.executeGame(false, 31, 29, dLeague);
        formulaBasketball.executeGame(false, 1, 28, dLeague);
        formulaBasketball.executeGame(false, 2, 27, dLeague);
        formulaBasketball.executeGame(false, 3, 26, dLeague);
        formulaBasketball.executeGame(false, 4, 25, dLeague);
        formulaBasketball.executeGame(false, 5, 24, dLeague);
        formulaBasketball.executeGame(false, 6, 23, dLeague);
        formulaBasketball.executeGame(false, 7, 22, dLeague);
        formulaBasketball.executeGame(false, 8, 21, dLeague);
        formulaBasketball.executeGame(false, 9, 20, dLeague);
        formulaBasketball.executeGame(false, 10, 19, dLeague);
        formulaBasketball.executeGame(false, 11, 18, dLeague);
        formulaBasketball.executeGame(false, 12, 17, dLeague);
        formulaBasketball.executeGame(false, 13, 16, dLeague);
        formulaBasketball.executeGame(false, 14, 15, dLeague);
    }
    private void Game2()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 13, 0, dLeague);
        formulaBasketball.executeGame(false, 12, 14, dLeague);
        formulaBasketball.executeGame(false, 11, 15, dLeague);
        formulaBasketball.executeGame(false, 10, 16, dLeague);
        formulaBasketball.executeGame(false, 9, 17, dLeague);
        formulaBasketball.executeGame(false, 8, 18, dLeague);
        formulaBasketball.executeGame(false, 7, 19, dLeague);
        formulaBasketball.executeGame(false, 6, 20, dLeague);
        formulaBasketball.executeGame(false, 5, 21, dLeague);
        formulaBasketball.executeGame(false, 4, 22, dLeague);
        formulaBasketball.executeGame(false, 3, 23, dLeague);
        formulaBasketball.executeGame(false, 2, 24, dLeague);
        formulaBasketball.executeGame(false, 1, 25, dLeague);
        formulaBasketball.executeGame(false, 31, 26, dLeague);
        formulaBasketball.executeGame(false, 30, 27, dLeague);
        formulaBasketball.executeGame(false, 29, 28, dLeague);
    }
    private void Game3()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 27, dLeague);
        formulaBasketball.executeGame(false, 28, 26, dLeague);
        formulaBasketball.executeGame(false, 29, 25, dLeague);
        formulaBasketball.executeGame(false, 30, 24, dLeague);
        formulaBasketball.executeGame(false, 31, 23, dLeague);
        formulaBasketball.executeGame(false, 1, 22, dLeague);
        formulaBasketball.executeGame(false, 2, 21, dLeague);
        formulaBasketball.executeGame(false, 3, 20, dLeague);
        formulaBasketball.executeGame(false, 4, 19, dLeague);
        formulaBasketball.executeGame(false, 5, 18, dLeague);
        formulaBasketball.executeGame(false, 6, 17, dLeague);
        formulaBasketball.executeGame(false, 7, 16, dLeague);
        formulaBasketball.executeGame(false, 8, 15, dLeague);
        formulaBasketball.executeGame(false, 9, 14, dLeague);
        formulaBasketball.executeGame(false, 10, 13, dLeague);
        formulaBasketball.executeGame(false, 11, 12, dLeague);
    }
    private void Game4()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 23, 0, dLeague);
        formulaBasketball.executeGame(false, 22, 24, dLeague);
        formulaBasketball.executeGame(false, 21, 25, dLeague);
        formulaBasketball.executeGame(false, 20, 26, dLeague);
        formulaBasketball.executeGame(false, 19, 27, dLeague);
        formulaBasketball.executeGame(false, 18, 28, dLeague);
        formulaBasketball.executeGame(false, 17, 29, dLeague);
        formulaBasketball.executeGame(false, 16, 30, dLeague);
        formulaBasketball.executeGame(false, 15, 31, dLeague);
        formulaBasketball.executeGame(false, 14, 1, dLeague);
        formulaBasketball.executeGame(false, 13, 2, dLeague);
        formulaBasketball.executeGame(false, 12, 3, dLeague);
        formulaBasketball.executeGame(false, 11, 4, dLeague);
        formulaBasketball.executeGame(false, 10, 5, dLeague);
        formulaBasketball.executeGame(false, 9, 6, dLeague);
        formulaBasketball.executeGame(false, 8, 7, dLeague);
    }
    private void Game5()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 12, dLeague);
        formulaBasketball.executeGame(false, 11, 13, dLeague);
        formulaBasketball.executeGame(false, 10, 14, dLeague);
        formulaBasketball.executeGame(false, 9, 15, dLeague);
        formulaBasketball.executeGame(false, 8, 16, dLeague);
        formulaBasketball.executeGame(false, 7, 17, dLeague);
        formulaBasketball.executeGame(false, 6, 18, dLeague);
        formulaBasketball.executeGame(false, 5, 19, dLeague);
        formulaBasketball.executeGame(false, 4, 20, dLeague);
        formulaBasketball.executeGame(false, 3, 21, dLeague);
        formulaBasketball.executeGame(false, 2, 22, dLeague);
        formulaBasketball.executeGame(false, 1, 23, dLeague);
        formulaBasketball.executeGame(false, 31, 24, dLeague);
        formulaBasketball.executeGame(false, 30, 25, dLeague);
        formulaBasketball.executeGame(false, 29, 26, dLeague);
        formulaBasketball.executeGame(false, 28, 27, dLeague);
    }
    private void Game6()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 20, 0, dLeague);
        formulaBasketball.executeGame(false, 21, 19, dLeague);
        formulaBasketball.executeGame(false, 22, 18, dLeague);
        formulaBasketball.executeGame(false, 23, 17, dLeague);
        formulaBasketball.executeGame(false, 24, 16, dLeague);
        formulaBasketball.executeGame(false, 25, 15, dLeague);
        formulaBasketball.executeGame(false, 26, 14, dLeague);
        formulaBasketball.executeGame(false, 27, 13, dLeague);
        formulaBasketball.executeGame(false, 28, 12, dLeague);
        formulaBasketball.executeGame(false, 29, 11, dLeague);
        formulaBasketball.executeGame(false, 30, 10, dLeague);
        formulaBasketball.executeGame(false, 31, 9, dLeague);
        formulaBasketball.executeGame(false, 1, 8, dLeague);
        formulaBasketball.executeGame(false, 2, 7, dLeague);
        formulaBasketball.executeGame(false, 3, 6, dLeague);
        formulaBasketball.executeGame(false, 4, 5, dLeague);
    }
    private void Game7()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 1, 0, dLeague);
        formulaBasketball.executeGame(false, 31, 2, dLeague);
        formulaBasketball.executeGame(false, 30, 3, dLeague);
        formulaBasketball.executeGame(false, 29, 4, dLeague);
        formulaBasketball.executeGame(false, 28, 5, dLeague);
        formulaBasketball.executeGame(false, 27, 6, dLeague);
        formulaBasketball.executeGame(false, 26, 7, dLeague);
        formulaBasketball.executeGame(false, 25, 8, dLeague);
        formulaBasketball.executeGame(false, 24, 9, dLeague);
        formulaBasketball.executeGame(false, 23, 10, dLeague);
        formulaBasketball.executeGame(false, 22, 11, dLeague);
        formulaBasketball.executeGame(false, 21, 12, dLeague);
        formulaBasketball.executeGame(false, 20, 13, dLeague);
        formulaBasketball.executeGame(false, 19, 14, dLeague);
        formulaBasketball.executeGame(false, 18, 15, dLeague);
        formulaBasketball.executeGame(false, 17, 16, dLeague);
    }
    private void Game8()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 31, 24, dLeague);
        formulaBasketball.executeGame(false, 23, 25, dLeague);
        formulaBasketball.executeGame(false, 22, 26, dLeague);
        formulaBasketball.executeGame(false, 21, 27, dLeague);
        formulaBasketball.executeGame(false, 20, 28, dLeague);
        formulaBasketball.executeGame(false, 19, 29, dLeague);
        formulaBasketball.executeGame(false, 18, 30, dLeague);
        formulaBasketball.executeGame(false, 17, 16, dLeague);
        formulaBasketball.executeGame(false, 0, 7, dLeague);
        formulaBasketball.executeGame(false, 8, 6, dLeague);
        formulaBasketball.executeGame(false, 9, 5, dLeague);
        formulaBasketball.executeGame(false, 10, 4, dLeague);
        formulaBasketball.executeGame(false, 11, 3, dLeague);
        formulaBasketball.executeGame(false, 12, 2, dLeague);
        formulaBasketball.executeGame(false, 13, 1, dLeague);
        formulaBasketball.executeGame(false, 14, 15, dLeague);
    }
    private void Game9()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 15, 0, dLeague);
        formulaBasketball.executeGame(false, 14, 16, dLeague);
        formulaBasketball.executeGame(false, 13, 17, dLeague);
        formulaBasketball.executeGame(false, 12, 18, dLeague);
        formulaBasketball.executeGame(false, 11, 19, dLeague);
        formulaBasketball.executeGame(false, 10, 20, dLeague);
        formulaBasketball.executeGame(false, 9, 21, dLeague);
        formulaBasketball.executeGame(false, 8, 22, dLeague);
        formulaBasketball.executeGame(false, 7, 23, dLeague);
        formulaBasketball.executeGame(false, 6, 24, dLeague);
        formulaBasketball.executeGame(false, 5, 25, dLeague);
        formulaBasketball.executeGame(false, 4, 26, dLeague);
        formulaBasketball.executeGame(false, 3, 27, dLeague);
        formulaBasketball.executeGame(false, 2, 28, dLeague);
        formulaBasketball.executeGame(false, 1, 29, dLeague);
        formulaBasketball.executeGame(false, 31, 30, dLeague);
    }
    private void Game10()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 7, dLeague);
        formulaBasketball.executeGame(false, 8, 6, dLeague);
        formulaBasketball.executeGame(false, 9, 5, dLeague);
        formulaBasketball.executeGame(false, 10, 4, dLeague);
        formulaBasketball.executeGame(false, 11, 3, dLeague);
        formulaBasketball.executeGame(false, 12, 2, dLeague);
        formulaBasketball.executeGame(false, 13, 1, dLeague);
        formulaBasketball.executeGame(false, 14, 31, dLeague);
        formulaBasketball.executeGame(false, 15, 30, dLeague);
        formulaBasketball.executeGame(false, 16, 29, dLeague);
        formulaBasketball.executeGame(false, 17, 28, dLeague);
        formulaBasketball.executeGame(false, 18, 27, dLeague);
        formulaBasketball.executeGame(false, 19, 26, dLeague);
        formulaBasketball.executeGame(false, 20, 25, dLeague);
        formulaBasketball.executeGame(false, 21, 24, dLeague);
        formulaBasketball.executeGame(false, 22, 23, dLeague);
    }
    private void Game11()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 29, dLeague);
        formulaBasketball.executeGame(false, 30, 28, dLeague);
        formulaBasketball.executeGame(false, 31, 27, dLeague);
        formulaBasketball.executeGame(false, 1, 26, dLeague);
        formulaBasketball.executeGame(false, 2, 25, dLeague);
        formulaBasketball.executeGame(false, 3, 24, dLeague);
        formulaBasketball.executeGame(false, 4, 23, dLeague);
        formulaBasketball.executeGame(false, 5, 22, dLeague);
        formulaBasketball.executeGame(false, 6, 21, dLeague);
        formulaBasketball.executeGame(false, 7, 20, dLeague);
        formulaBasketball.executeGame(false, 8, 19, dLeague);
        formulaBasketball.executeGame(false, 9, 18, dLeague);
        formulaBasketball.executeGame(false, 10, 17, dLeague);
        formulaBasketball.executeGame(false, 11, 16, dLeague);
        formulaBasketball.executeGame(false, 12, 15, dLeague);
        formulaBasketball.executeGame(false, 13, 14, dLeague);
    }
    private void Game12()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 23, dLeague);
        formulaBasketball.executeGame(false, 24, 22, dLeague);
        formulaBasketball.executeGame(false, 25, 21, dLeague);
        formulaBasketball.executeGame(false, 26, 20, dLeague);
        formulaBasketball.executeGame(false, 27, 19, dLeague);
        formulaBasketball.executeGame(false, 28, 18, dLeague);
        formulaBasketball.executeGame(false, 29, 17, dLeague);
        formulaBasketball.executeGame(false, 30, 16, dLeague);
        formulaBasketball.executeGame(false, 31, 15, dLeague);
        formulaBasketball.executeGame(false, 1, 14, dLeague);
        formulaBasketball.executeGame(false, 2, 13, dLeague);
        formulaBasketball.executeGame(false, 3, 12, dLeague);
        formulaBasketball.executeGame(false, 4, 11, dLeague);
        formulaBasketball.executeGame(false, 5, 10, dLeague);
        formulaBasketball.executeGame(false, 6, 9, dLeague);
        formulaBasketball.executeGame(false, 7, 8, dLeague);
    }
    private void Game13()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 7, dLeague);
        formulaBasketball.executeGame(false, 1, 6, dLeague);
        formulaBasketball.executeGame(false, 2, 5, dLeague);
        formulaBasketball.executeGame(false, 3, 4, dLeague);
        formulaBasketball.executeGame(false, 8, 15, dLeague);
        formulaBasketball.executeGame(false, 9, 14, dLeague);
        formulaBasketball.executeGame(false, 10, 13, dLeague);
        formulaBasketball.executeGame(false, 11, 12, dLeague);
        formulaBasketball.executeGame(false, 31, 24, dLeague);
        formulaBasketball.executeGame(false, 30, 25, dLeague);
        formulaBasketball.executeGame(false, 29, 26, dLeague);
        formulaBasketball.executeGame(false, 28, 27, dLeague);
        formulaBasketball.executeGame(false, 23, 16, dLeague);
        formulaBasketball.executeGame(false, 22, 17, dLeague);
        formulaBasketball.executeGame(false, 21, 18, dLeague);
        formulaBasketball.executeGame(false, 20, 19, dLeague);
    }
    private void Game14()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 31, 26, dLeague);
        formulaBasketball.executeGame(false, 25, 27, dLeague);
        formulaBasketball.executeGame(false, 24, 28, dLeague);
        formulaBasketball.executeGame(false, 23, 29, dLeague);
        formulaBasketball.executeGame(false, 22, 30, dLeague);
        formulaBasketball.executeGame(false, 21, 16, dLeague);
        formulaBasketball.executeGame(false, 20, 17, dLeague);
        formulaBasketball.executeGame(false, 19, 18, dLeague);
        formulaBasketball.executeGame(false, 0, 5, dLeague);
        formulaBasketball.executeGame(false, 6, 4, dLeague);
        formulaBasketball.executeGame(false, 7, 3, dLeague);
        formulaBasketball.executeGame(false, 8, 2, dLeague);
        formulaBasketball.executeGame(false, 9, 1, dLeague);
        formulaBasketball.executeGame(false, 10, 15, dLeague);
        formulaBasketball.executeGame(false, 11, 14, dLeague);
        formulaBasketball.executeGame(false, 12, 13, dLeague);
    }
    private void Game15()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 31, 30, dLeague);
        formulaBasketball.executeGame(false, 29, 16, dLeague);
        formulaBasketball.executeGame(false, 28, 17, dLeague);
        formulaBasketball.executeGame(false, 27, 18, dLeague);
        formulaBasketball.executeGame(false, 26, 19, dLeague);
        formulaBasketball.executeGame(false, 25, 20, dLeague);
        formulaBasketball.executeGame(false, 24, 21, dLeague);
        formulaBasketball.executeGame(false, 23, 22, dLeague);
        formulaBasketball.executeGame(false, 0, 1, dLeague);
        formulaBasketball.executeGame(false, 2, 15, dLeague);
        formulaBasketball.executeGame(false, 3, 14, dLeague);
        formulaBasketball.executeGame(false, 4, 13, dLeague);
        formulaBasketball.executeGame(false, 5, 12, dLeague);
        formulaBasketball.executeGame(false, 6, 11, dLeague);
        formulaBasketball.executeGame(false, 7, 10, dLeague);
        formulaBasketball.executeGame(false, 8, 9, dLeague);
    }
    private void Game16()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 19, 31, dLeague);
        formulaBasketball.executeGame(false, 18, 20, dLeague);
        formulaBasketball.executeGame(false, 17, 21, dLeague);
        formulaBasketball.executeGame(false, 16, 22, dLeague);
        formulaBasketball.executeGame(false, 30, 23, dLeague);
        formulaBasketball.executeGame(false, 29, 24, dLeague);
        formulaBasketball.executeGame(false, 28, 25, dLeague);
        formulaBasketball.executeGame(false, 27, 26, dLeague);
        formulaBasketball.executeGame(false, 12, 0, dLeague);
        formulaBasketball.executeGame(false, 13, 11, dLeague);
        formulaBasketball.executeGame(false, 14, 10, dLeague);
        formulaBasketball.executeGame(false, 15, 9, dLeague);
        formulaBasketball.executeGame(false, 1, 8, dLeague);
        formulaBasketball.executeGame(false, 2, 7, dLeague);
        formulaBasketball.executeGame(false, 3, 6, dLeague);
        formulaBasketball.executeGame(false, 4, 5, dLeague);
    }
    private void Game17()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 31, 28, dLeague);
        formulaBasketball.executeGame(false, 27, 29, dLeague);
        formulaBasketball.executeGame(false, 26, 30, dLeague);
        formulaBasketball.executeGame(false, 25, 16, dLeague);
        formulaBasketball.executeGame(false, 24, 17, dLeague);
        formulaBasketball.executeGame(false, 23, 18, dLeague);
        formulaBasketball.executeGame(false, 22, 19, dLeague);
        formulaBasketball.executeGame(false, 21, 20, dLeague);
        formulaBasketball.executeGame(false, 0, 3, dLeague);
        formulaBasketball.executeGame(false, 4, 2, dLeague);
        formulaBasketball.executeGame(false, 5, 1, dLeague);
        formulaBasketball.executeGame(false, 6, 15, dLeague);
        formulaBasketball.executeGame(false, 7, 14, dLeague);
        formulaBasketball.executeGame(false, 8, 13, dLeague);
        formulaBasketball.executeGame(false, 9, 12, dLeague);
        formulaBasketball.executeGame(false, 10, 11, dLeague);
    }
    private void Game18()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 3, 0, dLeague);
        formulaBasketball.executeGame(false, 2, 4, dLeague);
        formulaBasketball.executeGame(false, 1, 5, dLeague);
        formulaBasketball.executeGame(false, 31, 6, dLeague);
        formulaBasketball.executeGame(false, 30, 7, dLeague);
        formulaBasketball.executeGame(false, 29, 8, dLeague);
        formulaBasketball.executeGame(false, 28, 9, dLeague);
        formulaBasketball.executeGame(false, 27, 10, dLeague);
        formulaBasketball.executeGame(false, 26, 11, dLeague);
        formulaBasketball.executeGame(false, 25, 12, dLeague);
        formulaBasketball.executeGame(false, 24, 13, dLeague);
        formulaBasketball.executeGame(false, 23, 14, dLeague);
        formulaBasketball.executeGame(false, 22, 15, dLeague);
        formulaBasketball.executeGame(false, 21, 16, dLeague);
        formulaBasketball.executeGame(false, 20, 17, dLeague);
        formulaBasketball.executeGame(false, 19, 18, dLeague);
    }
    private void Game19()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 6, 0, dLeague);
        formulaBasketball.executeGame(false, 7, 5, dLeague);
        formulaBasketball.executeGame(false, 1, 4, dLeague);
        formulaBasketball.executeGame(false, 3, 2, dLeague);
        formulaBasketball.executeGame(false, 14, 8, dLeague);
        formulaBasketball.executeGame(false, 15, 13, dLeague);
        formulaBasketball.executeGame(false, 9, 12, dLeague);
        formulaBasketball.executeGame(false, 11, 10, dLeague);
        formulaBasketball.executeGame(false, 25, 31, dLeague);
        formulaBasketball.executeGame(false, 24, 26, dLeague);
        formulaBasketball.executeGame(false, 30, 27, dLeague);
        formulaBasketball.executeGame(false, 28, 29, dLeague);
        formulaBasketball.executeGame(false, 17, 23, dLeague);
        formulaBasketball.executeGame(false, 16, 18, dLeague);
        formulaBasketball.executeGame(false, 22, 19, dLeague);
        formulaBasketball.executeGame(false, 20, 21, dLeague);
    }
    private void Game20()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 9, dLeague);
        formulaBasketball.executeGame(false, 10, 8, dLeague);
        formulaBasketball.executeGame(false, 11, 7, dLeague);
        formulaBasketball.executeGame(false, 12, 6, dLeague);
        formulaBasketball.executeGame(false, 13, 5, dLeague);
        formulaBasketball.executeGame(false, 14, 4, dLeague);
        formulaBasketball.executeGame(false, 15, 3, dLeague);
        formulaBasketball.executeGame(false, 16, 2, dLeague);
        formulaBasketball.executeGame(false, 17, 1, dLeague);
        formulaBasketball.executeGame(false, 18, 31, dLeague);
        formulaBasketball.executeGame(false, 19, 30, dLeague);
        formulaBasketball.executeGame(false, 20, 29, dLeague);
        formulaBasketball.executeGame(false, 21, 28, dLeague);
        formulaBasketball.executeGame(false, 22, 27, dLeague);
        formulaBasketball.executeGame(false, 23, 26, dLeague);
        formulaBasketball.executeGame(false, 24, 25, dLeague);
    }
    private void Game21()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 10, dLeague);
        formulaBasketball.executeGame(false, 9, 11, dLeague);
        formulaBasketball.executeGame(false, 8, 12, dLeague);
        formulaBasketball.executeGame(false, 7, 13, dLeague);
        formulaBasketball.executeGame(false, 6, 14, dLeague);
        formulaBasketball.executeGame(false, 5, 15, dLeague);
        formulaBasketball.executeGame(false, 4, 16, dLeague);
        formulaBasketball.executeGame(false, 3, 17, dLeague);
        formulaBasketball.executeGame(false, 2, 18, dLeague);
        formulaBasketball.executeGame(false, 1, 19, dLeague);
        formulaBasketball.executeGame(false, 31, 20, dLeague);
        formulaBasketball.executeGame(false, 30, 21, dLeague);
        formulaBasketball.executeGame(false, 29, 22, dLeague);
        formulaBasketball.executeGame(false, 28, 23, dLeague);
        formulaBasketball.executeGame(false, 27, 24, dLeague);
        formulaBasketball.executeGame(false, 26, 25, dLeague);
    }
    private void Game22()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 1, 0, dLeague);
        formulaBasketball.executeGame(false, 2, 7, dLeague);
        formulaBasketball.executeGame(false, 3, 6, dLeague);
        formulaBasketball.executeGame(false, 5, 4, dLeague);
        formulaBasketball.executeGame(false, 9, 8, dLeague);
        formulaBasketball.executeGame(false, 10, 15, dLeague);
        formulaBasketball.executeGame(false, 11, 14, dLeague);
        formulaBasketball.executeGame(false, 13, 12, dLeague);
        formulaBasketball.executeGame(false, 30, 31, dLeague);
        formulaBasketball.executeGame(false, 29, 24, dLeague);
        formulaBasketball.executeGame(false, 28, 25, dLeague);
        formulaBasketball.executeGame(false, 26, 27, dLeague);
        formulaBasketball.executeGame(false, 22, 23, dLeague);
        formulaBasketball.executeGame(false, 21, 16, dLeague);
        formulaBasketball.executeGame(false, 20, 17, dLeague);
        formulaBasketball.executeGame(false, 18, 19, dLeague);
    }
    private void Game23()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 7, 0, dLeague);
        formulaBasketball.executeGame(false, 6, 8, dLeague);
        formulaBasketball.executeGame(false, 5, 9, dLeague);
        formulaBasketball.executeGame(false, 4, 10, dLeague);
        formulaBasketball.executeGame(false, 3, 11, dLeague);
        formulaBasketball.executeGame(false, 2, 12, dLeague);
        formulaBasketball.executeGame(false, 1, 13, dLeague);
        formulaBasketball.executeGame(false, 31, 14, dLeague);
        formulaBasketball.executeGame(false, 30, 15, dLeague);
        formulaBasketball.executeGame(false, 29, 16, dLeague);
        formulaBasketball.executeGame(false, 28, 17, dLeague);
        formulaBasketball.executeGame(false, 27, 18, dLeague);
        formulaBasketball.executeGame(false, 26, 19, dLeague);
        formulaBasketball.executeGame(false, 25, 20, dLeague);
        formulaBasketball.executeGame(false, 24, 21, dLeague);
        formulaBasketball.executeGame(false, 23, 22, dLeague);
    }
    private void Game24()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 16, dLeague);
        formulaBasketball.executeGame(false, 15, 17, dLeague);
        formulaBasketball.executeGame(false, 14, 18, dLeague);
        formulaBasketball.executeGame(false, 13, 19, dLeague);
        formulaBasketball.executeGame(false, 12, 20, dLeague);
        formulaBasketball.executeGame(false, 11, 21, dLeague);
        formulaBasketball.executeGame(false, 10, 22, dLeague);
        formulaBasketball.executeGame(false, 9, 23, dLeague);
        formulaBasketball.executeGame(false, 8, 24, dLeague);
        formulaBasketball.executeGame(false, 7, 25, dLeague);
        formulaBasketball.executeGame(false, 6, 26, dLeague);
        formulaBasketball.executeGame(false, 5, 27, dLeague);
        formulaBasketball.executeGame(false, 4, 28, dLeague);
        formulaBasketball.executeGame(false, 3, 29, dLeague);
        formulaBasketball.executeGame(false, 2, 30, dLeague);
        formulaBasketball.executeGame(false, 1, 31, dLeague);
    }
    private void Game25()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 6, 0, dLeague);
        formulaBasketball.executeGame(false, 7, 5, dLeague);
        formulaBasketball.executeGame(false, 8, 4, dLeague);
        formulaBasketball.executeGame(false, 9, 3, dLeague);
        formulaBasketball.executeGame(false, 10, 2, dLeague);
        formulaBasketball.executeGame(false, 11, 1, dLeague);
        formulaBasketball.executeGame(false, 12, 31, dLeague);
        formulaBasketball.executeGame(false, 13, 30, dLeague);
        formulaBasketball.executeGame(false, 14, 29, dLeague);
        formulaBasketball.executeGame(false, 15, 28, dLeague);
        formulaBasketball.executeGame(false, 16, 27, dLeague);
        formulaBasketball.executeGame(false, 17, 26, dLeague);
        formulaBasketball.executeGame(false, 18, 25, dLeague);
        formulaBasketball.executeGame(false, 19, 24, dLeague);
        formulaBasketball.executeGame(false, 20, 23, dLeague);
        formulaBasketball.executeGame(false, 21, 22, dLeague);
    }
    private void Game26()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 17, 31, dLeague);
        formulaBasketball.executeGame(false, 16, 18, dLeague);
        formulaBasketball.executeGame(false, 30, 19, dLeague);
        formulaBasketball.executeGame(false, 29, 20, dLeague);
        formulaBasketball.executeGame(false, 28, 21, dLeague);
        formulaBasketball.executeGame(false, 27, 22, dLeague);
        formulaBasketball.executeGame(false, 26, 23, dLeague);
        formulaBasketball.executeGame(false, 25, 24, dLeague);
        formulaBasketball.executeGame(false, 14, 0, dLeague);
        formulaBasketball.executeGame(false, 15, 13, dLeague);
        formulaBasketball.executeGame(false, 1, 12, dLeague);
        formulaBasketball.executeGame(false, 2, 11, dLeague);
        formulaBasketball.executeGame(false, 3, 10, dLeague);
        formulaBasketball.executeGame(false, 4, 9, dLeague);
        formulaBasketball.executeGame(false, 5, 8, dLeague);
        formulaBasketball.executeGame(false, 6, 7, dLeague);
    }
    private void Game27()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 5, dLeague);
        formulaBasketball.executeGame(false, 6, 4, dLeague);
        formulaBasketball.executeGame(false, 7, 3, dLeague);
        formulaBasketball.executeGame(false, 8, 2, dLeague);
        formulaBasketball.executeGame(false, 9, 1, dLeague);
        formulaBasketball.executeGame(false, 10, 31, dLeague);
        formulaBasketball.executeGame(false, 11, 30, dLeague);
        formulaBasketball.executeGame(false, 12, 29, dLeague);
        formulaBasketball.executeGame(false, 13, 28, dLeague);
        formulaBasketball.executeGame(false, 14, 27, dLeague);
        formulaBasketball.executeGame(false, 15, 26, dLeague);
        formulaBasketball.executeGame(false, 16, 25, dLeague);
        formulaBasketball.executeGame(false, 17, 24, dLeague);
        formulaBasketball.executeGame(false, 18, 23, dLeague);
        formulaBasketball.executeGame(false, 19, 22, dLeague);
        formulaBasketball.executeGame(false, 20, 21, dLeague);
    }
    private void Game28()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 31, dLeague);
        formulaBasketball.executeGame(false, 1, 30, dLeague);
        formulaBasketball.executeGame(false, 2, 29, dLeague);
        formulaBasketball.executeGame(false, 3, 28, dLeague);
        formulaBasketball.executeGame(false, 4, 27, dLeague);
        formulaBasketball.executeGame(false, 5, 26, dLeague);
        formulaBasketball.executeGame(false, 6, 25, dLeague);
        formulaBasketball.executeGame(false, 7, 24, dLeague);
        formulaBasketball.executeGame(false, 8, 23, dLeague);
        formulaBasketball.executeGame(false, 9, 22, dLeague);
        formulaBasketball.executeGame(false, 10, 21, dLeague);
        formulaBasketball.executeGame(false, 11, 20, dLeague);
        formulaBasketball.executeGame(false, 12, 19, dLeague);
        formulaBasketball.executeGame(false, 13, 18, dLeague);
        formulaBasketball.executeGame(false, 14, 17, dLeague);
        formulaBasketball.executeGame(false, 15, 16, dLeague);
    }
    private void Game29()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 30, dLeague);
        formulaBasketball.executeGame(false, 29, 31, dLeague);
        formulaBasketball.executeGame(false, 28, 1, dLeague);
        formulaBasketball.executeGame(false, 27, 2, dLeague);
        formulaBasketball.executeGame(false, 26, 3, dLeague);
        formulaBasketball.executeGame(false, 25, 4, dLeague);
        formulaBasketball.executeGame(false, 24, 5, dLeague);
        formulaBasketball.executeGame(false, 23, 6, dLeague);
        formulaBasketball.executeGame(false, 22, 7, dLeague);
        formulaBasketball.executeGame(false, 21, 8, dLeague);
        formulaBasketball.executeGame(false, 20, 9, dLeague);
        formulaBasketball.executeGame(false, 19, 10, dLeague);
        formulaBasketball.executeGame(false, 18, 11, dLeague);
        formulaBasketball.executeGame(false, 17, 12, dLeague);
        formulaBasketball.executeGame(false, 16, 13, dLeague);
        formulaBasketball.executeGame(false, 15, 14, dLeague);
    }
    private void Game30()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 15, dLeague);
        formulaBasketball.executeGame(false, 16, 14, dLeague);
        formulaBasketball.executeGame(false, 17, 13, dLeague);
        formulaBasketball.executeGame(false, 18, 12, dLeague);
        formulaBasketball.executeGame(false, 19, 11, dLeague);
        formulaBasketball.executeGame(false, 20, 10, dLeague);
        formulaBasketball.executeGame(false, 21, 9, dLeague);
        formulaBasketball.executeGame(false, 22, 8, dLeague);
        formulaBasketball.executeGame(false, 23, 7, dLeague);
        formulaBasketball.executeGame(false, 24, 6, dLeague);
        formulaBasketball.executeGame(false, 25, 5, dLeague);
        formulaBasketball.executeGame(false, 26, 4, dLeague);
        formulaBasketball.executeGame(false, 27, 3, dLeague);
        formulaBasketball.executeGame(false, 28, 2, dLeague);
        formulaBasketball.executeGame(false, 29, 1, dLeague);
        formulaBasketball.executeGame(false, 30, 31, dLeague);
    }
    private void Game31()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 21, 31, dLeague);
        formulaBasketball.executeGame(false, 20, 22, dLeague);
        formulaBasketball.executeGame(false, 19, 23, dLeague);
        formulaBasketball.executeGame(false, 18, 24, dLeague);
        formulaBasketball.executeGame(false, 17, 25, dLeague);
        formulaBasketball.executeGame(false, 16, 26, dLeague);
        formulaBasketball.executeGame(false, 30, 27, dLeague);
        formulaBasketball.executeGame(false, 29, 28, dLeague);
        formulaBasketball.executeGame(false, 10, 0, dLeague);
        formulaBasketball.executeGame(false, 11, 9, dLeague);
        formulaBasketball.executeGame(false, 12, 8, dLeague);
        formulaBasketball.executeGame(false, 13, 7, dLeague);
        formulaBasketball.executeGame(false, 14, 6, dLeague);
        formulaBasketball.executeGame(false, 15, 5, dLeague);
        formulaBasketball.executeGame(false, 1, 4, dLeague);
        formulaBasketball.executeGame(false, 2, 3, dLeague);
    }
    private void Game32()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 1, dLeague);
        formulaBasketball.executeGame(false, 2, 31, dLeague);
        formulaBasketball.executeGame(false, 3, 30, dLeague);
        formulaBasketball.executeGame(false, 4, 29, dLeague);
        formulaBasketball.executeGame(false, 5, 28, dLeague);
        formulaBasketball.executeGame(false, 6, 27, dLeague);
        formulaBasketball.executeGame(false, 7, 26, dLeague);
        formulaBasketball.executeGame(false, 8, 25, dLeague);
        formulaBasketball.executeGame(false, 9, 24, dLeague);
        formulaBasketball.executeGame(false, 10, 23, dLeague);
        formulaBasketball.executeGame(false, 11, 22, dLeague);
        formulaBasketball.executeGame(false, 12, 21, dLeague);
        formulaBasketball.executeGame(false, 13, 20, dLeague);
        formulaBasketball.executeGame(false, 14, 19, dLeague);
        formulaBasketball.executeGame(false, 15, 18, dLeague);
        formulaBasketball.executeGame(false, 16, 17, dLeague);
    }
    private void Game33()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 12, 0, dLeague);
        formulaBasketball.executeGame(false, 13, 11, dLeague);
        formulaBasketball.executeGame(false, 14, 10, dLeague);
        formulaBasketball.executeGame(false, 15, 9, dLeague);
        formulaBasketball.executeGame(false, 16, 8, dLeague);
        formulaBasketball.executeGame(false, 17, 7, dLeague);
        formulaBasketball.executeGame(false, 18, 6, dLeague);
        formulaBasketball.executeGame(false, 19, 5, dLeague);
        formulaBasketball.executeGame(false, 20, 4, dLeague);
        formulaBasketball.executeGame(false, 21, 3, dLeague);
        formulaBasketball.executeGame(false, 22, 2, dLeague);
        formulaBasketball.executeGame(false, 23, 1, dLeague);
        formulaBasketball.executeGame(false, 24, 31, dLeague);
        formulaBasketball.executeGame(false, 25, 30, dLeague);
        formulaBasketball.executeGame(false, 26, 29, dLeague);
        formulaBasketball.executeGame(false, 27, 28, dLeague);
    }
    private void Game34()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 20, dLeague);
        formulaBasketball.executeGame(false, 19, 21, dLeague);
        formulaBasketball.executeGame(false, 18, 22, dLeague);
        formulaBasketball.executeGame(false, 17, 23, dLeague);
        formulaBasketball.executeGame(false, 16, 24, dLeague);
        formulaBasketball.executeGame(false, 15, 25, dLeague);
        formulaBasketball.executeGame(false, 14, 26, dLeague);
        formulaBasketball.executeGame(false, 13, 27, dLeague);
        formulaBasketball.executeGame(false, 12, 28, dLeague);
        formulaBasketball.executeGame(false, 11, 29, dLeague);
        formulaBasketball.executeGame(false, 10, 30, dLeague);
        formulaBasketball.executeGame(false, 9, 31, dLeague);
        formulaBasketball.executeGame(false, 8, 1, dLeague);
        formulaBasketball.executeGame(false, 7, 2, dLeague);
        formulaBasketball.executeGame(false, 6, 3, dLeague);
        formulaBasketball.executeGame(false, 5, 4, dLeague);
    }
    private void Game35()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 8, 0, dLeague);
        formulaBasketball.executeGame(false, 9, 7, dLeague);
        formulaBasketball.executeGame(false, 10, 6, dLeague);
        formulaBasketball.executeGame(false, 11, 5, dLeague);
        formulaBasketball.executeGame(false, 12, 4, dLeague);
        formulaBasketball.executeGame(false, 13, 3, dLeague);
        formulaBasketball.executeGame(false, 14, 2, dLeague);
        formulaBasketball.executeGame(false, 15, 1, dLeague);
        formulaBasketball.executeGame(false, 16, 31, dLeague);
        formulaBasketball.executeGame(false, 17, 30, dLeague);
        formulaBasketball.executeGame(false, 18, 29, dLeague);
        formulaBasketball.executeGame(false, 19, 28, dLeague);
        formulaBasketball.executeGame(false, 20, 27, dLeague);
        formulaBasketball.executeGame(false, 21, 26, dLeague);
        formulaBasketball.executeGame(false, 22, 25, dLeague);
        formulaBasketball.executeGame(false, 23, 24, dLeague);
    }
    private void Game36()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 22, dLeague);
        formulaBasketball.executeGame(false, 21, 23, dLeague);
        formulaBasketball.executeGame(false, 20, 24, dLeague);
        formulaBasketball.executeGame(false, 19, 25, dLeague);
        formulaBasketball.executeGame(false, 18, 26, dLeague);
        formulaBasketball.executeGame(false, 17, 27, dLeague);
        formulaBasketball.executeGame(false, 16, 28, dLeague);
        formulaBasketball.executeGame(false, 15, 29, dLeague);
        formulaBasketball.executeGame(false, 14, 30, dLeague);
        formulaBasketball.executeGame(false, 13, 31, dLeague);
        formulaBasketball.executeGame(false, 12, 1, dLeague);
        formulaBasketball.executeGame(false, 11, 2, dLeague);
        formulaBasketball.executeGame(false, 10, 3, dLeague);
        formulaBasketball.executeGame(false, 9, 4, dLeague);
        formulaBasketball.executeGame(false, 8, 5, dLeague);
        formulaBasketball.executeGame(false, 7, 6, dLeague);
    }
    private void Game37()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 19, 0, dLeague);
        formulaBasketball.executeGame(false, 18, 20, dLeague);
        formulaBasketball.executeGame(false, 17, 21, dLeague);
        formulaBasketball.executeGame(false, 16, 22, dLeague);
        formulaBasketball.executeGame(false, 15, 23, dLeague);
        formulaBasketball.executeGame(false, 14, 24, dLeague);
        formulaBasketball.executeGame(false, 13, 25, dLeague);
        formulaBasketball.executeGame(false, 12, 26, dLeague);
        formulaBasketball.executeGame(false, 11, 27, dLeague);
        formulaBasketball.executeGame(false, 10, 28, dLeague);
        formulaBasketball.executeGame(false, 9, 29, dLeague);
        formulaBasketball.executeGame(false, 8, 30, dLeague);
        formulaBasketball.executeGame(false, 7, 31, dLeague);
        formulaBasketball.executeGame(false, 6, 1, dLeague);
        formulaBasketball.executeGame(false, 5, 2, dLeague);
        formulaBasketball.executeGame(false, 4, 3, dLeague);
    }
    private void Game38()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 3, dLeague);
        formulaBasketball.executeGame(false, 4, 2, dLeague);
        formulaBasketball.executeGame(false, 5, 1, dLeague);
        formulaBasketball.executeGame(false, 7, 6, dLeague);
        formulaBasketball.executeGame(false, 8, 11, dLeague);
        formulaBasketball.executeGame(false, 12, 10, dLeague);
        formulaBasketball.executeGame(false, 13, 9, dLeague);
        formulaBasketball.executeGame(false, 15, 14, dLeague);
        formulaBasketball.executeGame(false, 31, 28, dLeague);
        formulaBasketball.executeGame(false, 27, 29, dLeague);
        formulaBasketball.executeGame(false, 26, 30, dLeague);
        formulaBasketball.executeGame(false, 24, 25, dLeague);
        formulaBasketball.executeGame(false, 23, 20, dLeague);
        formulaBasketball.executeGame(false, 19, 21, dLeague);
        formulaBasketball.executeGame(false, 18, 22, dLeague);
        formulaBasketball.executeGame(false, 16, 17, dLeague);
    }
    private void Game39()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 31, 22, dLeague);
        formulaBasketball.executeGame(false, 21, 23, dLeague);
        formulaBasketball.executeGame(false, 20, 24, dLeague);
        formulaBasketball.executeGame(false, 19, 25, dLeague);
        formulaBasketball.executeGame(false, 18, 26, dLeague);
        formulaBasketball.executeGame(false, 17, 27, dLeague);
        formulaBasketball.executeGame(false, 16, 28, dLeague);
        formulaBasketball.executeGame(false, 30, 29, dLeague);
        formulaBasketball.executeGame(false, 0, 9, dLeague);
        formulaBasketball.executeGame(false, 10, 8, dLeague);
        formulaBasketball.executeGame(false, 11, 7, dLeague);
        formulaBasketball.executeGame(false, 12, 6, dLeague);
        formulaBasketball.executeGame(false, 13, 5, dLeague);
        formulaBasketball.executeGame(false, 14, 4, dLeague);
        formulaBasketball.executeGame(false, 15, 3, dLeague);
        formulaBasketball.executeGame(false, 1, 2, dLeague);
    }
    private void Game40()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 27, 0, dLeague);
        formulaBasketball.executeGame(false, 26, 28, dLeague);
        formulaBasketball.executeGame(false, 25, 29, dLeague);
        formulaBasketball.executeGame(false, 24, 30, dLeague);
        formulaBasketball.executeGame(false, 23, 31, dLeague);
        formulaBasketball.executeGame(false, 22, 1, dLeague);
        formulaBasketball.executeGame(false, 21, 2, dLeague);
        formulaBasketball.executeGame(false, 20, 3, dLeague);
        formulaBasketball.executeGame(false, 19, 4, dLeague);
        formulaBasketball.executeGame(false, 18, 5, dLeague);
        formulaBasketball.executeGame(false, 17, 6, dLeague);
        formulaBasketball.executeGame(false, 16, 7, dLeague);
        formulaBasketball.executeGame(false, 15, 8, dLeague);
        formulaBasketball.executeGame(false, 14, 9, dLeague);
        formulaBasketball.executeGame(false, 13, 10, dLeague);
        formulaBasketball.executeGame(false, 12, 11, dLeague);
    }
    private void Game41()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 16, 0, dLeague);
        formulaBasketball.executeGame(false, 17, 15, dLeague);
        formulaBasketball.executeGame(false, 18, 14, dLeague);
        formulaBasketball.executeGame(false, 19, 13, dLeague);
        formulaBasketball.executeGame(false, 20, 12, dLeague);
        formulaBasketball.executeGame(false, 21, 11, dLeague);
        formulaBasketball.executeGame(false, 22, 10, dLeague);
        formulaBasketball.executeGame(false, 23, 9, dLeague);
        formulaBasketball.executeGame(false, 24, 8, dLeague);
        formulaBasketball.executeGame(false, 25, 7, dLeague);
        formulaBasketball.executeGame(false, 26, 6, dLeague);
        formulaBasketball.executeGame(false, 27, 5, dLeague);
        formulaBasketball.executeGame(false, 28, 4, dLeague);
        formulaBasketball.executeGame(false, 29, 3, dLeague);
        formulaBasketball.executeGame(false, 30, 2, dLeague);
        formulaBasketball.executeGame(false, 31, 1, dLeague);
    }
    private void Game42()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 6, dLeague);
        formulaBasketball.executeGame(false, 5, 7, dLeague);
        formulaBasketball.executeGame(false, 4, 8, dLeague);
        formulaBasketball.executeGame(false, 3, 9, dLeague);
        formulaBasketball.executeGame(false, 2, 10, dLeague);
        formulaBasketball.executeGame(false, 1, 11, dLeague);
        formulaBasketball.executeGame(false, 31, 12, dLeague);
        formulaBasketball.executeGame(false, 30, 13, dLeague);
        formulaBasketball.executeGame(false, 29, 14, dLeague);
        formulaBasketball.executeGame(false, 28, 15, dLeague);
        formulaBasketball.executeGame(false, 27, 16, dLeague);
        formulaBasketball.executeGame(false, 26, 17, dLeague);
        formulaBasketball.executeGame(false, 25, 18, dLeague);
        formulaBasketball.executeGame(false, 24, 19, dLeague);
        formulaBasketball.executeGame(false, 23, 20, dLeague);
        formulaBasketball.executeGame(false, 22, 21, dLeague);
    }
    private void Game43()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 3, dLeague);
        formulaBasketball.executeGame(false, 4, 2, dLeague);
        formulaBasketball.executeGame(false, 5, 1, dLeague);
        formulaBasketball.executeGame(false, 6, 31, dLeague);
        formulaBasketball.executeGame(false, 7, 30, dLeague);
        formulaBasketball.executeGame(false, 8, 29, dLeague);
        formulaBasketball.executeGame(false, 9, 28, dLeague);
        formulaBasketball.executeGame(false, 10, 27, dLeague);
        formulaBasketball.executeGame(false, 11, 26, dLeague);
        formulaBasketball.executeGame(false, 12, 25, dLeague);
        formulaBasketball.executeGame(false, 13, 24, dLeague);
        formulaBasketball.executeGame(false, 14, 23, dLeague);
        formulaBasketball.executeGame(false, 15, 22, dLeague);
        formulaBasketball.executeGame(false, 16, 21, dLeague);
        formulaBasketball.executeGame(false, 17, 20, dLeague);
        formulaBasketball.executeGame(false, 18, 19, dLeague);
    }
    private void Game44()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 18, 0, dLeague);
        formulaBasketball.executeGame(false, 19, 17, dLeague);
        formulaBasketball.executeGame(false, 20, 16, dLeague);
        formulaBasketball.executeGame(false, 21, 15, dLeague);
        formulaBasketball.executeGame(false, 22, 14, dLeague);
        formulaBasketball.executeGame(false, 23, 13, dLeague);
        formulaBasketball.executeGame(false, 24, 12, dLeague);
        formulaBasketball.executeGame(false, 25, 11, dLeague);
        formulaBasketball.executeGame(false, 26, 10, dLeague);
        formulaBasketball.executeGame(false, 27, 9, dLeague);
        formulaBasketball.executeGame(false, 28, 8, dLeague);
        formulaBasketball.executeGame(false, 29, 7, dLeague);
        formulaBasketball.executeGame(false, 30, 6, dLeague);
        formulaBasketball.executeGame(false, 31, 5, dLeague);
        formulaBasketball.executeGame(false, 1, 4, dLeague);
        formulaBasketball.executeGame(false, 2, 3, dLeague);
    }
    private void Game45()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 22, 0, dLeague);
        formulaBasketball.executeGame(false, 23, 21, dLeague);
        formulaBasketball.executeGame(false, 24, 20, dLeague);
        formulaBasketball.executeGame(false, 25, 19, dLeague);
        formulaBasketball.executeGame(false, 26, 18, dLeague);
        formulaBasketball.executeGame(false, 27, 17, dLeague);
        formulaBasketball.executeGame(false, 28, 16, dLeague);
        formulaBasketball.executeGame(false, 29, 15, dLeague);
        formulaBasketball.executeGame(false, 30, 14, dLeague);
        formulaBasketball.executeGame(false, 31, 13, dLeague);
        formulaBasketball.executeGame(false, 1, 12, dLeague);
        formulaBasketball.executeGame(false, 2, 11, dLeague);
        formulaBasketball.executeGame(false, 3, 10, dLeague);
        formulaBasketball.executeGame(false, 4, 9, dLeague);
        formulaBasketball.executeGame(false, 5, 8, dLeague);
        formulaBasketball.executeGame(false, 6, 7, dLeague);
    }
    private void Game46()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 25, 0, dLeague);
        formulaBasketball.executeGame(false, 24, 26, dLeague);
        formulaBasketball.executeGame(false, 23, 27, dLeague);
        formulaBasketball.executeGame(false, 22, 28, dLeague);
        formulaBasketball.executeGame(false, 21, 29, dLeague);
        formulaBasketball.executeGame(false, 20, 30, dLeague);
        formulaBasketball.executeGame(false, 19, 31, dLeague);
        formulaBasketball.executeGame(false, 18, 1, dLeague);
        formulaBasketball.executeGame(false, 17, 2, dLeague);
        formulaBasketball.executeGame(false, 16, 3, dLeague);
        formulaBasketball.executeGame(false, 15, 4, dLeague);
        formulaBasketball.executeGame(false, 14, 5, dLeague);
        formulaBasketball.executeGame(false, 13, 6, dLeague);
        formulaBasketball.executeGame(false, 12, 7, dLeague);
        formulaBasketball.executeGame(false, 11, 8, dLeague);
        formulaBasketball.executeGame(false, 10, 9, dLeague);
    }
    private void Game47()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 10, 0, dLeague);
        formulaBasketball.executeGame(false, 11, 9, dLeague);
        formulaBasketball.executeGame(false, 12, 8, dLeague);
        formulaBasketball.executeGame(false, 13, 7, dLeague);
        formulaBasketball.executeGame(false, 14, 6, dLeague);
        formulaBasketball.executeGame(false, 15, 5, dLeague);
        formulaBasketball.executeGame(false, 16, 4, dLeague);
        formulaBasketball.executeGame(false, 17, 3, dLeague);
        formulaBasketball.executeGame(false, 18, 2, dLeague);
        formulaBasketball.executeGame(false, 19, 1, dLeague);
        formulaBasketball.executeGame(false, 20, 31, dLeague);
        formulaBasketball.executeGame(false, 21, 30, dLeague);
        formulaBasketball.executeGame(false, 22, 29, dLeague);
        formulaBasketball.executeGame(false, 23, 28, dLeague);
        formulaBasketball.executeGame(false, 24, 27, dLeague);
        formulaBasketball.executeGame(false, 25, 26, dLeague);
    }
    private void Game48()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 17, dLeague);
        formulaBasketball.executeGame(false, 18, 16, dLeague);
        formulaBasketball.executeGame(false, 19, 15, dLeague);
        formulaBasketball.executeGame(false, 20, 14, dLeague);
        formulaBasketball.executeGame(false, 21, 13, dLeague);
        formulaBasketball.executeGame(false, 22, 12, dLeague);
        formulaBasketball.executeGame(false, 23, 11, dLeague);
        formulaBasketball.executeGame(false, 24, 10, dLeague);
        formulaBasketball.executeGame(false, 25, 9, dLeague);
        formulaBasketball.executeGame(false, 26, 8, dLeague);
        formulaBasketball.executeGame(false, 27, 7, dLeague);
        formulaBasketball.executeGame(false, 28, 6, dLeague);
        formulaBasketball.executeGame(false, 29, 5, dLeague);
        formulaBasketball.executeGame(false, 30, 4, dLeague);
        formulaBasketball.executeGame(false, 31, 3, dLeague);
        formulaBasketball.executeGame(false, 1, 2, dLeague);
    }
    private void Game49()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 21, dLeague);
        formulaBasketball.executeGame(false, 22, 20, dLeague);
        formulaBasketball.executeGame(false, 23, 19, dLeague);
        formulaBasketball.executeGame(false, 24, 18, dLeague);
        formulaBasketball.executeGame(false, 25, 17, dLeague);
        formulaBasketball.executeGame(false, 26, 16, dLeague);
        formulaBasketball.executeGame(false, 27, 15, dLeague);
        formulaBasketball.executeGame(false, 28, 14, dLeague);
        formulaBasketball.executeGame(false, 29, 13, dLeague);
        formulaBasketball.executeGame(false, 30, 12, dLeague);
        formulaBasketball.executeGame(false, 31, 11, dLeague);
        formulaBasketball.executeGame(false, 1, 10, dLeague);
        formulaBasketball.executeGame(false, 2, 9, dLeague);
        formulaBasketball.executeGame(false, 3, 8, dLeague);
        formulaBasketball.executeGame(false, 4, 7, dLeague);
        formulaBasketball.executeGame(false, 5, 6, dLeague);
    }
    private void Game50()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 29, 31, dLeague);
        formulaBasketball.executeGame(false, 28, 30, dLeague);
        formulaBasketball.executeGame(false, 27, 16, dLeague);
        formulaBasketball.executeGame(false, 26, 17, dLeague);
        formulaBasketball.executeGame(false, 25, 18, dLeague);
        formulaBasketball.executeGame(false, 24, 19, dLeague);
        formulaBasketball.executeGame(false, 23, 20, dLeague);
        formulaBasketball.executeGame(false, 22, 21, dLeague);
        formulaBasketball.executeGame(false, 2, 0, dLeague);
        formulaBasketball.executeGame(false, 3, 1, dLeague);
        formulaBasketball.executeGame(false, 4, 15, dLeague);
        formulaBasketball.executeGame(false, 5, 14, dLeague);
        formulaBasketball.executeGame(false, 6, 13, dLeague);
        formulaBasketball.executeGame(false, 7, 12, dLeague);
        formulaBasketball.executeGame(false, 8, 11, dLeague);
        formulaBasketball.executeGame(false, 9, 10, dLeague);
    }
    private void Game51()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 4, dLeague);
        formulaBasketball.executeGame(false, 3, 5, dLeague);
        formulaBasketball.executeGame(false, 2, 6, dLeague);
        formulaBasketball.executeGame(false, 1, 7, dLeague);
        formulaBasketball.executeGame(false, 31, 8, dLeague);
        formulaBasketball.executeGame(false, 30, 9, dLeague);
        formulaBasketball.executeGame(false, 29, 10, dLeague);
        formulaBasketball.executeGame(false, 28, 11, dLeague);
        formulaBasketball.executeGame(false, 27, 12, dLeague);
        formulaBasketball.executeGame(false, 26, 13, dLeague);
        formulaBasketball.executeGame(false, 25, 14, dLeague);
        formulaBasketball.executeGame(false, 24, 15, dLeague);
        formulaBasketball.executeGame(false, 23, 16, dLeague);
        formulaBasketball.executeGame(false, 22, 17, dLeague);
        formulaBasketball.executeGame(false, 21, 18, dLeague);
        formulaBasketball.executeGame(false, 20, 19, dLeague);
    }
    private void Game52()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 28, dLeague);
        formulaBasketball.executeGame(false, 27, 29, dLeague);
        formulaBasketball.executeGame(false, 26, 30, dLeague);
        formulaBasketball.executeGame(false, 25, 31, dLeague);
        formulaBasketball.executeGame(false, 24, 1, dLeague);
        formulaBasketball.executeGame(false, 23, 2, dLeague);
        formulaBasketball.executeGame(false, 22, 3, dLeague);
        formulaBasketball.executeGame(false, 21, 4, dLeague);
        formulaBasketball.executeGame(false, 20, 5, dLeague);
        formulaBasketball.executeGame(false, 19, 6, dLeague);
        formulaBasketball.executeGame(false, 18, 7, dLeague);
        formulaBasketball.executeGame(false, 17, 8, dLeague);
        formulaBasketball.executeGame(false, 16, 9, dLeague);
        formulaBasketball.executeGame(false, 15, 10, dLeague);
        formulaBasketball.executeGame(false, 14, 11, dLeague);
        formulaBasketball.executeGame(false, 13, 12, dLeague);
    }
    private void Game53()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 24, dLeague);
        formulaBasketball.executeGame(false, 23, 25, dLeague);
        formulaBasketball.executeGame(false, 22, 26, dLeague);
        formulaBasketball.executeGame(false, 21, 27, dLeague);
        formulaBasketball.executeGame(false, 20, 28, dLeague);
        formulaBasketball.executeGame(false, 19, 29, dLeague);
        formulaBasketball.executeGame(false, 18, 30, dLeague);
        formulaBasketball.executeGame(false, 17, 31, dLeague);
        formulaBasketball.executeGame(false, 16, 1, dLeague);
        formulaBasketball.executeGame(false, 15, 2, dLeague);
        formulaBasketball.executeGame(false, 14, 3, dLeague);
        formulaBasketball.executeGame(false, 13, 4, dLeague);
        formulaBasketball.executeGame(false, 12, 5, dLeague);
        formulaBasketball.executeGame(false, 11, 6, dLeague);
        formulaBasketball.executeGame(false, 10, 7, dLeague);
        formulaBasketball.executeGame(false, 9, 8, dLeague);
    }
    private void Game54()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 2, 0, dLeague);
        formulaBasketball.executeGame(false, 3, 1, dLeague);
        formulaBasketball.executeGame(false, 4, 7, dLeague);
        formulaBasketball.executeGame(false, 5, 6, dLeague);
        formulaBasketball.executeGame(false, 10, 8, dLeague);
        formulaBasketball.executeGame(false, 11, 9, dLeague);
        formulaBasketball.executeGame(false, 12, 15, dLeague);
        formulaBasketball.executeGame(false, 13, 14, dLeague);
        formulaBasketball.executeGame(false, 29, 31, dLeague);
        formulaBasketball.executeGame(false, 28, 30, dLeague);
        formulaBasketball.executeGame(false, 27, 24, dLeague);
        formulaBasketball.executeGame(false, 26, 25, dLeague);
        formulaBasketball.executeGame(false, 21, 23, dLeague);
        formulaBasketball.executeGame(false, 20, 22, dLeague);
        formulaBasketball.executeGame(false, 19, 16, dLeague);
        formulaBasketball.executeGame(false, 18, 17, dLeague);
    }
    private void Game55()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 8, dLeague);
        formulaBasketball.executeGame(false, 7, 9, dLeague);
        formulaBasketball.executeGame(false, 6, 10, dLeague);
        formulaBasketball.executeGame(false, 5, 11, dLeague);
        formulaBasketball.executeGame(false, 4, 12, dLeague);
        formulaBasketball.executeGame(false, 3, 13, dLeague);
        formulaBasketball.executeGame(false, 2, 14, dLeague);
        formulaBasketball.executeGame(false, 1, 15, dLeague);
        formulaBasketball.executeGame(false, 31, 16, dLeague);
        formulaBasketball.executeGame(false, 30, 17, dLeague);
        formulaBasketball.executeGame(false, 29, 18, dLeague);
        formulaBasketball.executeGame(false, 28, 19, dLeague);
        formulaBasketball.executeGame(false, 27, 20, dLeague);
        formulaBasketball.executeGame(false, 26, 21, dLeague);
        formulaBasketball.executeGame(false, 25, 22, dLeague);
        formulaBasketball.executeGame(false, 24, 23, dLeague);
    }
    private void Game56()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 11, dLeague);
        formulaBasketball.executeGame(false, 12, 10, dLeague);
        formulaBasketball.executeGame(false, 13, 9, dLeague);
        formulaBasketball.executeGame(false, 14, 8, dLeague);
        formulaBasketball.executeGame(false, 15, 7, dLeague);
        formulaBasketball.executeGame(false, 16, 6, dLeague);
        formulaBasketball.executeGame(false, 17, 5, dLeague);
        formulaBasketball.executeGame(false, 18, 4, dLeague);
        formulaBasketball.executeGame(false, 19, 3, dLeague);
        formulaBasketball.executeGame(false, 20, 2, dLeague);
        formulaBasketball.executeGame(false, 21, 1, dLeague);
        formulaBasketball.executeGame(false, 22, 31, dLeague);
        formulaBasketball.executeGame(false, 23, 30, dLeague);
        formulaBasketball.executeGame(false, 24, 29, dLeague);
        formulaBasketball.executeGame(false, 25, 28, dLeague);
        formulaBasketball.executeGame(false, 26, 27, dLeague);
    }
    private void Game57()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 31, 20, dLeague);
        formulaBasketball.executeGame(false, 19, 21, dLeague);
        formulaBasketball.executeGame(false, 18, 22, dLeague);
        formulaBasketball.executeGame(false, 17, 23, dLeague);
        formulaBasketball.executeGame(false, 16, 24, dLeague);
        formulaBasketball.executeGame(false, 30, 25, dLeague);
        formulaBasketball.executeGame(false, 29, 26, dLeague);
        formulaBasketball.executeGame(false, 28, 27, dLeague);
        formulaBasketball.executeGame(false, 0, 11, dLeague);
        formulaBasketball.executeGame(false, 12, 10, dLeague);
        formulaBasketball.executeGame(false, 13, 9, dLeague);
        formulaBasketball.executeGame(false, 14, 8, dLeague);
        formulaBasketball.executeGame(false, 15, 7, dLeague);
        formulaBasketball.executeGame(false, 1, 6, dLeague);
        formulaBasketball.executeGame(false, 2, 5, dLeague);
        formulaBasketball.executeGame(false, 3, 4, dLeague);
    }
    private void Game58()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 13, dLeague);
        formulaBasketball.executeGame(false, 14, 12, dLeague);
        formulaBasketball.executeGame(false, 15, 11, dLeague);
        formulaBasketball.executeGame(false, 16, 10, dLeague);
        formulaBasketball.executeGame(false, 17, 9, dLeague);
        formulaBasketball.executeGame(false, 18, 8, dLeague);
        formulaBasketball.executeGame(false, 19, 7, dLeague);
        formulaBasketball.executeGame(false, 20, 6, dLeague);
        formulaBasketball.executeGame(false, 21, 5, dLeague);
        formulaBasketball.executeGame(false, 22, 4, dLeague);
        formulaBasketball.executeGame(false, 23, 3, dLeague);
        formulaBasketball.executeGame(false, 24, 2, dLeague);
        formulaBasketball.executeGame(false, 25, 1, dLeague);
        formulaBasketball.executeGame(false, 26, 31, dLeague);
        formulaBasketball.executeGame(false, 27, 30, dLeague);
        formulaBasketball.executeGame(false, 28, 29, dLeague);
    }
    private void Game59()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 17, 0, dLeague);
        formulaBasketball.executeGame(false, 16, 18, dLeague);
        formulaBasketball.executeGame(false, 15, 19, dLeague);
        formulaBasketball.executeGame(false, 14, 20, dLeague);
        formulaBasketball.executeGame(false, 13, 21, dLeague);
        formulaBasketball.executeGame(false, 12, 22, dLeague);
        formulaBasketball.executeGame(false, 11, 23, dLeague);
        formulaBasketball.executeGame(false, 10, 24, dLeague);
        formulaBasketball.executeGame(false, 9, 25, dLeague);
        formulaBasketball.executeGame(false, 8, 26, dLeague);
        formulaBasketball.executeGame(false, 7, 27, dLeague);
        formulaBasketball.executeGame(false, 6, 28, dLeague);
        formulaBasketball.executeGame(false, 5, 29, dLeague);
        formulaBasketball.executeGame(false, 4, 30, dLeague);
        formulaBasketball.executeGame(false, 3, 31, dLeague);
        formulaBasketball.executeGame(false, 2, 1, dLeague);
    }
    private void Game60()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 25, dLeague);
        formulaBasketball.executeGame(false, 26, 24, dLeague);
        formulaBasketball.executeGame(false, 27, 23, dLeague);
        formulaBasketball.executeGame(false, 28, 22, dLeague);
        formulaBasketball.executeGame(false, 29, 21, dLeague);
        formulaBasketball.executeGame(false, 30, 20, dLeague);
        formulaBasketball.executeGame(false, 31, 19, dLeague);
        formulaBasketball.executeGame(false, 1, 18, dLeague);
        formulaBasketball.executeGame(false, 2, 17, dLeague);
        formulaBasketball.executeGame(false, 3, 16, dLeague);
        formulaBasketball.executeGame(false, 4, 15, dLeague);
        formulaBasketball.executeGame(false, 5, 14, dLeague);
        formulaBasketball.executeGame(false, 6, 13, dLeague);
        formulaBasketball.executeGame(false, 7, 12, dLeague);
        formulaBasketball.executeGame(false, 8, 11, dLeague);
        formulaBasketball.executeGame(false, 9, 10, dLeague);
    }
    private void Game61()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 31, 18, dLeague);
        formulaBasketball.executeGame(false, 17, 19, dLeague);
        formulaBasketball.executeGame(false, 16, 20, dLeague);
        formulaBasketball.executeGame(false, 30, 21, dLeague);
        formulaBasketball.executeGame(false, 29, 22, dLeague);
        formulaBasketball.executeGame(false, 28, 23, dLeague);
        formulaBasketball.executeGame(false, 27, 24, dLeague);
        formulaBasketball.executeGame(false, 26, 25, dLeague);
        formulaBasketball.executeGame(false, 0, 13, dLeague);
        formulaBasketball.executeGame(false, 14, 12, dLeague);
        formulaBasketball.executeGame(false, 15, 11, dLeague);
        formulaBasketball.executeGame(false, 1, 10, dLeague);
        formulaBasketball.executeGame(false, 2, 9, dLeague);
        formulaBasketball.executeGame(false, 3, 8, dLeague);
        formulaBasketball.executeGame(false, 4, 7, dLeague);
        formulaBasketball.executeGame(false, 5, 6, dLeague);
    }
    private void Game62()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 29, 0, dLeague);
        formulaBasketball.executeGame(false, 28, 30, dLeague);
        formulaBasketball.executeGame(false, 27, 31, dLeague);
        formulaBasketball.executeGame(false, 26, 1, dLeague);
        formulaBasketball.executeGame(false, 25, 2, dLeague);
        formulaBasketball.executeGame(false, 24, 3, dLeague);
        formulaBasketball.executeGame(false, 23, 4, dLeague);
        formulaBasketball.executeGame(false, 22, 5, dLeague);
        formulaBasketball.executeGame(false, 21, 6, dLeague);
        formulaBasketball.executeGame(false, 20, 7, dLeague);
        formulaBasketball.executeGame(false, 19, 8, dLeague);
        formulaBasketball.executeGame(false, 18, 9, dLeague);
        formulaBasketball.executeGame(false, 17, 10, dLeague);
        formulaBasketball.executeGame(false, 16, 11, dLeague);
        formulaBasketball.executeGame(false, 15, 12, dLeague);
        formulaBasketball.executeGame(false, 14, 13, dLeague);
    }
    private void Game63()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 4, 0, dLeague);
        formulaBasketball.executeGame(false, 5, 3, dLeague);
        formulaBasketball.executeGame(false, 6, 2, dLeague);
        formulaBasketball.executeGame(false, 7, 1, dLeague);
        formulaBasketball.executeGame(false, 12, 8, dLeague);
        formulaBasketball.executeGame(false, 13, 11, dLeague);
        formulaBasketball.executeGame(false, 14, 10, dLeague);
        formulaBasketball.executeGame(false, 15, 9, dLeague);
        formulaBasketball.executeGame(false, 27, 31, dLeague);
        formulaBasketball.executeGame(false, 26, 28, dLeague);
        formulaBasketball.executeGame(false, 25, 29, dLeague);
        formulaBasketball.executeGame(false, 24, 30, dLeague);
        formulaBasketball.executeGame(false, 19, 23, dLeague);
        formulaBasketball.executeGame(false, 18, 20, dLeague);
        formulaBasketball.executeGame(false, 17, 21, dLeague);
        formulaBasketball.executeGame(false, 16, 22, dLeague);
    }
    private void Game64()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 5, 0, dLeague);
        formulaBasketball.executeGame(false, 4, 6, dLeague);
        formulaBasketball.executeGame(false, 3, 7, dLeague);
        formulaBasketball.executeGame(false, 2, 8, dLeague);
        formulaBasketball.executeGame(false, 1, 9, dLeague);
        formulaBasketball.executeGame(false, 31, 10, dLeague);
        formulaBasketball.executeGame(false, 30, 11, dLeague);
        formulaBasketball.executeGame(false, 29, 12, dLeague);
        formulaBasketball.executeGame(false, 28, 13, dLeague);
        formulaBasketball.executeGame(false, 27, 14, dLeague);
        formulaBasketball.executeGame(false, 26, 15, dLeague);
        formulaBasketball.executeGame(false, 25, 16, dLeague);
        formulaBasketball.executeGame(false, 24, 17, dLeague);
        formulaBasketball.executeGame(false, 23, 18, dLeague);
        formulaBasketball.executeGame(false, 22, 19, dLeague);
        formulaBasketball.executeGame(false, 21, 20, dLeague);
    }
    private void Game65()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 2, 0, dLeague);
        formulaBasketball.executeGame(false, 3, 1, dLeague);
        formulaBasketball.executeGame(false, 4, 31, dLeague);
        formulaBasketball.executeGame(false, 5, 30, dLeague);
        formulaBasketball.executeGame(false, 6, 29, dLeague);
        formulaBasketball.executeGame(false, 7, 28, dLeague);
        formulaBasketball.executeGame(false, 8, 27, dLeague);
        formulaBasketball.executeGame(false, 9, 26, dLeague);
        formulaBasketball.executeGame(false, 10, 25, dLeague);
        formulaBasketball.executeGame(false, 11, 24, dLeague);
        formulaBasketball.executeGame(false, 12, 23, dLeague);
        formulaBasketball.executeGame(false, 13, 22, dLeague);
        formulaBasketball.executeGame(false, 14, 21, dLeague);
        formulaBasketball.executeGame(false, 15, 20, dLeague);
        formulaBasketball.executeGame(false, 16, 19, dLeague);
        formulaBasketball.executeGame(false, 17, 18, dLeague);
    }
    private void Game66()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 21, 0, dLeague);
        formulaBasketball.executeGame(false, 20, 22, dLeague);
        formulaBasketball.executeGame(false, 19, 23, dLeague);
        formulaBasketball.executeGame(false, 18, 24, dLeague);
        formulaBasketball.executeGame(false, 17, 25, dLeague);
        formulaBasketball.executeGame(false, 16, 26, dLeague);
        formulaBasketball.executeGame(false, 15, 27, dLeague);
        formulaBasketball.executeGame(false, 14, 28, dLeague);
        formulaBasketball.executeGame(false, 13, 29, dLeague);
        formulaBasketball.executeGame(false, 12, 30, dLeague);
        formulaBasketball.executeGame(false, 11, 31, dLeague);
        formulaBasketball.executeGame(false, 10, 1, dLeague);
        formulaBasketball.executeGame(false, 9, 2, dLeague);
        formulaBasketball.executeGame(false, 8, 3, dLeague);
        formulaBasketball.executeGame(false, 7, 4, dLeague);
        formulaBasketball.executeGame(false, 6, 5, dLeague);
    }
    private void Game67()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 14, dLeague);
        formulaBasketball.executeGame(false, 13, 15, dLeague);
        formulaBasketball.executeGame(false, 12, 16, dLeague);
        formulaBasketball.executeGame(false, 11, 17, dLeague);
        formulaBasketball.executeGame(false, 10, 18, dLeague);
        formulaBasketball.executeGame(false, 9, 19, dLeague);
        formulaBasketball.executeGame(false, 8, 20, dLeague);
        formulaBasketball.executeGame(false, 7, 21, dLeague);
        formulaBasketball.executeGame(false, 6, 22, dLeague);
        formulaBasketball.executeGame(false, 5, 23, dLeague);
        formulaBasketball.executeGame(false, 4, 24, dLeague);
        formulaBasketball.executeGame(false, 3, 25, dLeague);
        formulaBasketball.executeGame(false, 2, 26, dLeague);
        formulaBasketball.executeGame(false, 1, 27, dLeague);
        formulaBasketball.executeGame(false, 31, 28, dLeague);
        formulaBasketball.executeGame(false, 30, 29, dLeague);
    }
    private void Game68()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 14, 0, dLeague);
        formulaBasketball.executeGame(false, 15, 13, dLeague);
        formulaBasketball.executeGame(false, 16, 12, dLeague);
        formulaBasketball.executeGame(false, 17, 11, dLeague);
        formulaBasketball.executeGame(false, 18, 10, dLeague);
        formulaBasketball.executeGame(false, 19, 9, dLeague);
        formulaBasketball.executeGame(false, 20, 8, dLeague);
        formulaBasketball.executeGame(false, 21, 7, dLeague);
        formulaBasketball.executeGame(false, 22, 6, dLeague);
        formulaBasketball.executeGame(false, 23, 5, dLeague);
        formulaBasketball.executeGame(false, 24, 4, dLeague);
        formulaBasketball.executeGame(false, 25, 3, dLeague);
        formulaBasketball.executeGame(false, 26, 2, dLeague);
        formulaBasketball.executeGame(false, 27, 1, dLeague);
        formulaBasketball.executeGame(false, 28, 31, dLeague);
        formulaBasketball.executeGame(false, 29, 30, dLeague);
    }
    private void Game69()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 27, 31, dLeague);
        formulaBasketball.executeGame(false, 26, 28, dLeague);
        formulaBasketball.executeGame(false, 25, 29, dLeague);
        formulaBasketball.executeGame(false, 24, 30, dLeague);
        formulaBasketball.executeGame(false, 23, 16, dLeague);
        formulaBasketball.executeGame(false, 22, 17, dLeague);
        formulaBasketball.executeGame(false, 21, 18, dLeague);
        formulaBasketball.executeGame(false, 20, 19, dLeague);
        formulaBasketball.executeGame(false, 4, 0, dLeague);
        formulaBasketball.executeGame(false, 5, 3, dLeague);
        formulaBasketball.executeGame(false, 6, 2, dLeague);
        formulaBasketball.executeGame(false, 7, 1, dLeague);
        formulaBasketball.executeGame(false, 8, 15, dLeague);
        formulaBasketball.executeGame(false, 9, 14, dLeague);
        formulaBasketball.executeGame(false, 10, 13, dLeague);
        formulaBasketball.executeGame(false, 11, 12, dLeague);
    }
    private void Game70()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 25, 31, dLeague);
        formulaBasketball.executeGame(false, 24, 26, dLeague);
        formulaBasketball.executeGame(false, 23, 27, dLeague);
        formulaBasketball.executeGame(false, 22, 28, dLeague);
        formulaBasketball.executeGame(false, 21, 29, dLeague);
        formulaBasketball.executeGame(false, 20, 30, dLeague);
        formulaBasketball.executeGame(false, 19, 16, dLeague);
        formulaBasketball.executeGame(false, 18, 17, dLeague);
        formulaBasketball.executeGame(false, 6, 0, dLeague);
        formulaBasketball.executeGame(false, 7, 5, dLeague);
        formulaBasketball.executeGame(false, 8, 4, dLeague);
        formulaBasketball.executeGame(false, 9, 3, dLeague);
        formulaBasketball.executeGame(false, 10, 2, dLeague);
        formulaBasketball.executeGame(false, 11, 1, dLeague);
        formulaBasketball.executeGame(false, 12, 15, dLeague);
        formulaBasketball.executeGame(false, 13, 14, dLeague);
    }
    private void Game71()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 31, 16, dLeague);
        formulaBasketball.executeGame(false, 30, 17, dLeague);
        formulaBasketball.executeGame(false, 29, 18, dLeague);
        formulaBasketball.executeGame(false, 28, 19, dLeague);
        formulaBasketball.executeGame(false, 27, 20, dLeague);
        formulaBasketball.executeGame(false, 26, 21, dLeague);
        formulaBasketball.executeGame(false, 25, 22, dLeague);
        formulaBasketball.executeGame(false, 24, 23, dLeague);
        formulaBasketball.executeGame(false, 0, 15, dLeague);
        formulaBasketball.executeGame(false, 1, 14, dLeague);
        formulaBasketball.executeGame(false, 2, 13, dLeague);
        formulaBasketball.executeGame(false, 3, 12, dLeague);
        formulaBasketball.executeGame(false, 4, 11, dLeague);
        formulaBasketball.executeGame(false, 5, 10, dLeague);
        formulaBasketball.executeGame(false, 6, 9, dLeague);
        formulaBasketball.executeGame(false, 7, 8, dLeague);
    }
    private void Game72()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 31, 0, dLeague);
        formulaBasketball.executeGame(false, 30, 1, dLeague);
        formulaBasketball.executeGame(false, 29, 2, dLeague);
        formulaBasketball.executeGame(false, 28, 3, dLeague);
        formulaBasketball.executeGame(false, 27, 4, dLeague);
        formulaBasketball.executeGame(false, 26, 5, dLeague);
        formulaBasketball.executeGame(false, 25, 6, dLeague);
        formulaBasketball.executeGame(false, 24, 7, dLeague);
        formulaBasketball.executeGame(false, 23, 8, dLeague);
        formulaBasketball.executeGame(false, 22, 9, dLeague);
        formulaBasketball.executeGame(false, 21, 10, dLeague);
        formulaBasketball.executeGame(false, 20, 11, dLeague);
        formulaBasketball.executeGame(false, 19, 12, dLeague);
        formulaBasketball.executeGame(false, 18, 13, dLeague);
        formulaBasketball.executeGame(false, 17, 14, dLeague);
        formulaBasketball.executeGame(false, 16, 15, dLeague);
    }
    private void Game73()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 4, 0, dLeague);
        formulaBasketball.executeGame(false, 5, 3, dLeague);
        formulaBasketball.executeGame(false, 6, 2, dLeague);
        formulaBasketball.executeGame(false, 7, 1, dLeague);
        formulaBasketball.executeGame(false, 8, 31, dLeague);
        formulaBasketball.executeGame(false, 9, 30, dLeague);
        formulaBasketball.executeGame(false, 10, 29, dLeague);
        formulaBasketball.executeGame(false, 11, 28, dLeague);
        formulaBasketball.executeGame(false, 12, 27, dLeague);
        formulaBasketball.executeGame(false, 13, 26, dLeague);
        formulaBasketball.executeGame(false, 14, 25, dLeague);
        formulaBasketball.executeGame(false, 15, 24, dLeague);
        formulaBasketball.executeGame(false, 16, 23, dLeague);
        formulaBasketball.executeGame(false, 17, 22, dLeague);
        formulaBasketball.executeGame(false, 18, 21, dLeague);
        formulaBasketball.executeGame(false, 19, 20, dLeague);
    }
    private void Game74()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 2, dLeague);
        formulaBasketball.executeGame(false, 1, 3, dLeague);
        formulaBasketball.executeGame(false, 31, 4, dLeague);
        formulaBasketball.executeGame(false, 30, 5, dLeague);
        formulaBasketball.executeGame(false, 29, 6, dLeague);
        formulaBasketball.executeGame(false, 28, 7, dLeague);
        formulaBasketball.executeGame(false, 27, 8, dLeague);
        formulaBasketball.executeGame(false, 26, 9, dLeague);
        formulaBasketball.executeGame(false, 25, 10, dLeague);
        formulaBasketball.executeGame(false, 24, 11, dLeague);
        formulaBasketball.executeGame(false, 23, 12, dLeague);
        formulaBasketball.executeGame(false, 22, 13, dLeague);
        formulaBasketball.executeGame(false, 21, 14, dLeague);
        formulaBasketball.executeGame(false, 20, 15, dLeague);
        formulaBasketball.executeGame(false, 19, 16, dLeague);
        formulaBasketball.executeGame(false, 18, 17, dLeague);
    }
    private void Game75()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 11, 0, dLeague);
        formulaBasketball.executeGame(false, 10, 12, dLeague);
        formulaBasketball.executeGame(false, 9, 13, dLeague);
        formulaBasketball.executeGame(false, 8, 14, dLeague);
        formulaBasketball.executeGame(false, 7, 15, dLeague);
        formulaBasketball.executeGame(false, 6, 16, dLeague);
        formulaBasketball.executeGame(false, 5, 17, dLeague);
        formulaBasketball.executeGame(false, 4, 18, dLeague);
        formulaBasketball.executeGame(false, 3, 19, dLeague);
        formulaBasketball.executeGame(false, 2, 20, dLeague);
        formulaBasketball.executeGame(false, 1, 21, dLeague);
        formulaBasketball.executeGame(false, 31, 22, dLeague);
        formulaBasketball.executeGame(false, 30, 23, dLeague);
        formulaBasketball.executeGame(false, 29, 24, dLeague);
        formulaBasketball.executeGame(false, 28, 25, dLeague);
        formulaBasketball.executeGame(false, 27, 26, dLeague);
    }
    private void Game76()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 9, 0, dLeague);
        formulaBasketball.executeGame(false, 8, 10, dLeague);
        formulaBasketball.executeGame(false, 7, 11, dLeague);
        formulaBasketball.executeGame(false, 6, 12, dLeague);
        formulaBasketball.executeGame(false, 5, 13, dLeague);
        formulaBasketball.executeGame(false, 4, 14, dLeague);
        formulaBasketball.executeGame(false, 3, 15, dLeague);
        formulaBasketball.executeGame(false, 2, 16, dLeague);
        formulaBasketball.executeGame(false, 1, 17, dLeague);
        formulaBasketball.executeGame(false, 31, 18, dLeague);
        formulaBasketball.executeGame(false, 30, 19, dLeague);
        formulaBasketball.executeGame(false, 29, 20, dLeague);
        formulaBasketball.executeGame(false, 28, 21, dLeague);
        formulaBasketball.executeGame(false, 27, 22, dLeague);
        formulaBasketball.executeGame(false, 26, 23, dLeague);
        formulaBasketball.executeGame(false, 25, 24, dLeague);
    }
    private void Game77()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 24, 0, dLeague);
        formulaBasketball.executeGame(false, 25, 23, dLeague);
        formulaBasketball.executeGame(false, 26, 22, dLeague);
        formulaBasketball.executeGame(false, 27, 21, dLeague);
        formulaBasketball.executeGame(false, 28, 20, dLeague);
        formulaBasketball.executeGame(false, 29, 19, dLeague);
        formulaBasketball.executeGame(false, 30, 18, dLeague);
        formulaBasketball.executeGame(false, 31, 17, dLeague);
        formulaBasketball.executeGame(false, 1, 16, dLeague);
        formulaBasketball.executeGame(false, 2, 15, dLeague);
        formulaBasketball.executeGame(false, 3, 14, dLeague);
        formulaBasketball.executeGame(false, 4, 13, dLeague);
        formulaBasketball.executeGame(false, 5, 12, dLeague);
        formulaBasketball.executeGame(false, 6, 11, dLeague);
        formulaBasketball.executeGame(false, 7, 10, dLeague);
        formulaBasketball.executeGame(false, 8, 9, dLeague);
    }
    private void Game78()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 28, 0, dLeague);
        formulaBasketball.executeGame(false, 29, 27, dLeague);
        formulaBasketball.executeGame(false, 30, 26, dLeague);
        formulaBasketball.executeGame(false, 31, 25, dLeague);
        formulaBasketball.executeGame(false, 1, 24, dLeague);
        formulaBasketball.executeGame(false, 2, 23, dLeague);
        formulaBasketball.executeGame(false, 3, 22, dLeague);
        formulaBasketball.executeGame(false, 4, 21, dLeague);
        formulaBasketball.executeGame(false, 5, 20, dLeague);
        formulaBasketball.executeGame(false, 6, 19, dLeague);
        formulaBasketball.executeGame(false, 7, 18, dLeague);
        formulaBasketball.executeGame(false, 8, 17, dLeague);
        formulaBasketball.executeGame(false, 9, 16, dLeague);
        formulaBasketball.executeGame(false, 10, 15, dLeague);
        formulaBasketball.executeGame(false, 11, 14, dLeague);
        formulaBasketball.executeGame(false, 12, 13, dLeague);
    }
    private void Game79()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 23, 31, dLeague);
        formulaBasketball.executeGame(false, 22, 24, dLeague);
        formulaBasketball.executeGame(false, 21, 25, dLeague);
        formulaBasketball.executeGame(false, 20, 26, dLeague);
        formulaBasketball.executeGame(false, 19, 27, dLeague);
        formulaBasketball.executeGame(false, 18, 28, dLeague);
        formulaBasketball.executeGame(false, 17, 29, dLeague);
        formulaBasketball.executeGame(false, 16, 30, dLeague);
        formulaBasketball.executeGame(false, 8, 0, dLeague);
        formulaBasketball.executeGame(false, 9, 7, dLeague);
        formulaBasketball.executeGame(false, 10, 6, dLeague);
        formulaBasketball.executeGame(false, 11, 5, dLeague);
        formulaBasketball.executeGame(false, 12, 4, dLeague);
        formulaBasketball.executeGame(false, 13, 3, dLeague);
        formulaBasketball.executeGame(false, 14, 2, dLeague);
        formulaBasketball.executeGame(false, 15, 1, dLeague);
    }
    private void Game80()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 19, dLeague);
        formulaBasketball.executeGame(false, 20, 18, dLeague);
        formulaBasketball.executeGame(false, 21, 17, dLeague);
        formulaBasketball.executeGame(false, 22, 16, dLeague);
        formulaBasketball.executeGame(false, 23, 15, dLeague);
        formulaBasketball.executeGame(false, 24, 14, dLeague);
        formulaBasketball.executeGame(false, 25, 13, dLeague);
        formulaBasketball.executeGame(false, 26, 12, dLeague);
        formulaBasketball.executeGame(false, 27, 11, dLeague);
        formulaBasketball.executeGame(false, 28, 10, dLeague);
        formulaBasketball.executeGame(false, 29, 9, dLeague);
        formulaBasketball.executeGame(false, 30, 8, dLeague);
        formulaBasketball.executeGame(false, 31, 7, dLeague);
        formulaBasketball.executeGame(false, 1, 6, dLeague);
        formulaBasketball.executeGame(false, 2, 5, dLeague);
        formulaBasketball.executeGame(false, 3, 4, dLeague);
    }
    private void Game81()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 26, 0, dLeague);
        formulaBasketball.executeGame(false, 27, 25, dLeague);
        formulaBasketball.executeGame(false, 28, 24, dLeague);
        formulaBasketball.executeGame(false, 29, 23, dLeague);
        formulaBasketball.executeGame(false, 30, 22, dLeague);
        formulaBasketball.executeGame(false, 31, 21, dLeague);
        formulaBasketball.executeGame(false, 1, 20, dLeague);
        formulaBasketball.executeGame(false, 2, 19, dLeague);
        formulaBasketball.executeGame(false, 3, 18, dLeague);
        formulaBasketball.executeGame(false, 4, 17, dLeague);
        formulaBasketball.executeGame(false, 5, 16, dLeague);
        formulaBasketball.executeGame(false, 6, 15, dLeague);
        formulaBasketball.executeGame(false, 7, 14, dLeague);
        formulaBasketball.executeGame(false, 8, 13, dLeague);
        formulaBasketball.executeGame(false, 9, 12, dLeague);
        formulaBasketball.executeGame(false, 10, 11, dLeague);
    }
    private void Game82()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 5, dLeague);
        formulaBasketball.executeGame(false, 6, 4, dLeague);
        formulaBasketball.executeGame(false, 7, 3, dLeague);
        formulaBasketball.executeGame(false, 1, 2, dLeague);
        formulaBasketball.executeGame(false, 8, 13, dLeague);
        formulaBasketball.executeGame(false, 14, 12, dLeague);
        formulaBasketball.executeGame(false, 15, 11, dLeague);
        formulaBasketball.executeGame(false, 9, 10, dLeague);
        formulaBasketball.executeGame(false, 31, 26, dLeague);
        formulaBasketball.executeGame(false, 25, 27, dLeague);
        formulaBasketball.executeGame(false, 24, 28, dLeague);
        formulaBasketball.executeGame(false, 30, 29, dLeague);
        formulaBasketball.executeGame(false, 23, 18, dLeague);
        formulaBasketball.executeGame(false, 17, 19, dLeague);
        formulaBasketball.executeGame(false, 16, 20, dLeague);
        formulaBasketball.executeGame(false, 22, 21, dLeague);
    }
    private void Game83()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 18, dLeague);
        formulaBasketball.executeGame(false, 17, 19, dLeague);
        formulaBasketball.executeGame(false, 16, 20, dLeague);
        formulaBasketball.executeGame(false, 15, 21, dLeague);
        formulaBasketball.executeGame(false, 14, 22, dLeague);
        formulaBasketball.executeGame(false, 13, 23, dLeague);
        formulaBasketball.executeGame(false, 12, 24, dLeague);
        formulaBasketball.executeGame(false, 11, 25, dLeague);
        formulaBasketball.executeGame(false, 10, 26, dLeague);
        formulaBasketball.executeGame(false, 9, 27, dLeague);
        formulaBasketball.executeGame(false, 8, 28, dLeague);
        formulaBasketball.executeGame(false, 7, 29, dLeague);
        formulaBasketball.executeGame(false, 6, 30, dLeague);
        formulaBasketball.executeGame(false, 5, 31, dLeague);
        formulaBasketball.executeGame(false, 4, 1, dLeague);
        formulaBasketball.executeGame(false, 3, 2, dLeague);
    }
    private void Game84()
    {
        if (formulaBasketball.gameWriter != null) formulaBasketball.gameWriter.writeLines(); formulaBasketball.gameResultsContents += "Game " + formulaBasketball.startingGame + ",Home,Score,Away,Score\n";
        formulaBasketball.writerContents += "\n"; if (formulaBasketball.writeGames) formulaBasketball.gameWriter = new gameWriter(formulaBasketball.startingGame); else formulaBasketball.gameWriter = null; formulaBasketball.doWeeklyFianances();
        formulaBasketball.startingGame++; Console.Write(formulaBasketball.startingGame + "'s Games");
        formulaBasketball.executeGame(false, 0, 26, dLeague);
        formulaBasketball.executeGame(false, 25, 27, dLeague);
        formulaBasketball.executeGame(false, 24, 28, dLeague);
        formulaBasketball.executeGame(false, 23, 29, dLeague);
        formulaBasketball.executeGame(false, 22, 30, dLeague);
        formulaBasketball.executeGame(false, 21, 31, dLeague);
        formulaBasketball.executeGame(false, 20, 1, dLeague);
        formulaBasketball.executeGame(false, 19, 2, dLeague);
        formulaBasketball.executeGame(false, 18, 3, dLeague);
        formulaBasketball.executeGame(false, 17, 4, dLeague);
        formulaBasketball.executeGame(false, 16, 5, dLeague);
        formulaBasketball.executeGame(false, 15, 6, dLeague);
        formulaBasketball.executeGame(false, 14, 7, dLeague);
        formulaBasketball.executeGame(false, 13, 8, dLeague);
        formulaBasketball.executeGame(false, 12, 9, dLeague);
        formulaBasketball.executeGame(false, 11, 10, dLeague);

    }
}