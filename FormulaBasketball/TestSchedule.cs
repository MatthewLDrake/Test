using System;
using System.Collections.Generic;
public class TestSchedule
{
    private List<Action> list;
    private TestLeague test;
    public TestSchedule(TestLeague test)
    {
        this.test = test;

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
    public void playGames(int firstGame, int lastGame)
    {
        for (int i = firstGame - 1; i < lastGame; i++)
        {
            list[i].Invoke();

            if(i == 10)
            {
                test.DevelopPlayers();
            }

        }
    }
    private void Game1()
    {
        
        
        
        test.executeGame(false, 30, 0);
        test.executeGame(false, 31, 29);
        test.executeGame(false, 1, 28);
        test.executeGame(false, 2, 27);
        test.executeGame(false, 3, 26);
        test.executeGame(false, 4, 25);
        test.executeGame(false, 5, 24);
        test.executeGame(false, 6, 23);
        test.executeGame(false, 7, 22);
        test.executeGame(false, 8, 21);
        test.executeGame(false, 9, 20);
        test.executeGame(false, 10, 19);
        test.executeGame(false, 11, 18);
        test.executeGame(false, 12, 17);
        test.executeGame(false, 13, 16);
        test.executeGame(false, 14, 15);
    }
    private void Game2()
    {
        
        
        
        test.executeGame(false, 13, 0);
        test.executeGame(false, 12, 14);
        test.executeGame(false, 11, 15);
        test.executeGame(false, 10, 16);
        test.executeGame(false, 9, 17);
        test.executeGame(false, 8, 18);
        test.executeGame(false, 7, 19);
        test.executeGame(false, 6, 20);
        test.executeGame(false, 5, 21);
        test.executeGame(false, 4, 22);
        test.executeGame(false, 3, 23);
        test.executeGame(false, 2, 24);
        test.executeGame(false, 1, 25);
        test.executeGame(false, 31, 26);
        test.executeGame(false, 30, 27);
        test.executeGame(false, 29, 28);
    }
    private void Game3()
    {
        
        
        
        test.executeGame(false, 0, 27);
        test.executeGame(false, 28, 26);
        test.executeGame(false, 29, 25);
        test.executeGame(false, 30, 24);
        test.executeGame(false, 31, 23);
        test.executeGame(false, 1, 22);
        test.executeGame(false, 2, 21);
        test.executeGame(false, 3, 20);
        test.executeGame(false, 4, 19);
        test.executeGame(false, 5, 18);
        test.executeGame(false, 6, 17);
        test.executeGame(false, 7, 16);
        test.executeGame(false, 8, 15);
        test.executeGame(false, 9, 14);
        test.executeGame(false, 10, 13);
        test.executeGame(false, 11, 12);
    }
    private void Game4()
    {
        
        
        
        test.executeGame(false, 23, 0);
        test.executeGame(false, 22, 24);
        test.executeGame(false, 21, 25);
        test.executeGame(false, 20, 26);
        test.executeGame(false, 19, 27);
        test.executeGame(false, 18, 28);
        test.executeGame(false, 17, 29);
        test.executeGame(false, 16, 30);
        test.executeGame(false, 15, 31);
        test.executeGame(false, 14, 1);
        test.executeGame(false, 13, 2);
        test.executeGame(false, 12, 3);
        test.executeGame(false, 11, 4);
        test.executeGame(false, 10, 5);
        test.executeGame(false, 9, 6);
        test.executeGame(false, 8, 7);
    }
    private void Game5()
    {
        
        
        
        test.executeGame(false, 0, 12);
        test.executeGame(false, 11, 13);
        test.executeGame(false, 10, 14);
        test.executeGame(false, 9, 15);
        test.executeGame(false, 8, 16);
        test.executeGame(false, 7, 17);
        test.executeGame(false, 6, 18);
        test.executeGame(false, 5, 19);
        test.executeGame(false, 4, 20);
        test.executeGame(false, 3, 21);
        test.executeGame(false, 2, 22);
        test.executeGame(false, 1, 23);
        test.executeGame(false, 31, 24);
        test.executeGame(false, 30, 25);
        test.executeGame(false, 29, 26);
        test.executeGame(false, 28, 27);
    }
    private void Game6()
    {
        
        
        
        test.executeGame(false, 20, 0);
        test.executeGame(false, 21, 19);
        test.executeGame(false, 22, 18);
        test.executeGame(false, 23, 17);
        test.executeGame(false, 24, 16);
        test.executeGame(false, 25, 15);
        test.executeGame(false, 26, 14);
        test.executeGame(false, 27, 13);
        test.executeGame(false, 28, 12);
        test.executeGame(false, 29, 11);
        test.executeGame(false, 30, 10);
        test.executeGame(false, 31, 9);
        test.executeGame(false, 1, 8);
        test.executeGame(false, 2, 7);
        test.executeGame(false, 3, 6);
        test.executeGame(false, 4, 5);
    }
    private void Game7()
    {
        
        
        
        test.executeGame(false, 1, 0);
        test.executeGame(false, 31, 2);
        test.executeGame(false, 30, 3);
        test.executeGame(false, 29, 4);
        test.executeGame(false, 28, 5);
        test.executeGame(false, 27, 6);
        test.executeGame(false, 26, 7);
        test.executeGame(false, 25, 8);
        test.executeGame(false, 24, 9);
        test.executeGame(false, 23, 10);
        test.executeGame(false, 22, 11);
        test.executeGame(false, 21, 12);
        test.executeGame(false, 20, 13);
        test.executeGame(false, 19, 14);
        test.executeGame(false, 18, 15);
        test.executeGame(false, 17, 16);
    }
    private void Game8()
    {
        
        
        
        test.executeGame(false, 31, 24);
        test.executeGame(false, 23, 25);
        test.executeGame(false, 22, 26);
        test.executeGame(false, 21, 27);
        test.executeGame(false, 20, 28);
        test.executeGame(false, 19, 29);
        test.executeGame(false, 18, 30);
        test.executeGame(false, 17, 16);
        test.executeGame(false, 0, 7);
        test.executeGame(false, 8, 6);
        test.executeGame(false, 9, 5);
        test.executeGame(false, 10, 4);
        test.executeGame(false, 11, 3);
        test.executeGame(false, 12, 2);
        test.executeGame(false, 13, 1);
        test.executeGame(false, 14, 15);
    }
    private void Game9()
    {
        
        
        
        test.executeGame(false, 15, 0);
        test.executeGame(false, 14, 16);
        test.executeGame(false, 13, 17);
        test.executeGame(false, 12, 18);
        test.executeGame(false, 11, 19);
        test.executeGame(false, 10, 20);
        test.executeGame(false, 9, 21);
        test.executeGame(false, 8, 22);
        test.executeGame(false, 7, 23);
        test.executeGame(false, 6, 24);
        test.executeGame(false, 5, 25);
        test.executeGame(false, 4, 26);
        test.executeGame(false, 3, 27);
        test.executeGame(false, 2, 28);
        test.executeGame(false, 1, 29);
        test.executeGame(false, 31, 30);
    }
    private void Game10()
    {
        
        
        
        test.executeGame(false, 0, 7);
        test.executeGame(false, 8, 6);
        test.executeGame(false, 9, 5);
        test.executeGame(false, 10, 4);
        test.executeGame(false, 11, 3);
        test.executeGame(false, 12, 2);
        test.executeGame(false, 13, 1);
        test.executeGame(false, 14, 31);
        test.executeGame(false, 15, 30);
        test.executeGame(false, 16, 29);
        test.executeGame(false, 17, 28);
        test.executeGame(false, 18, 27);
        test.executeGame(false, 19, 26);
        test.executeGame(false, 20, 25);
        test.executeGame(false, 21, 24);
        test.executeGame(false, 22, 23);
    }
    private void Game11()
    {
        
        
        
        test.executeGame(false, 0, 29);
        test.executeGame(false, 30, 28);
        test.executeGame(false, 31, 27);
        test.executeGame(false, 1, 26);
        test.executeGame(false, 2, 25);
        test.executeGame(false, 3, 24);
        test.executeGame(false, 4, 23);
        test.executeGame(false, 5, 22);
        test.executeGame(false, 6, 21);
        test.executeGame(false, 7, 20);
        test.executeGame(false, 8, 19);
        test.executeGame(false, 9, 18);
        test.executeGame(false, 10, 17);
        test.executeGame(false, 11, 16);
        test.executeGame(false, 12, 15);
        test.executeGame(false, 13, 14);
    }
    private void Game12()
    {
        
        
        
        test.executeGame(false, 0, 23);
        test.executeGame(false, 24, 22);
        test.executeGame(false, 25, 21);
        test.executeGame(false, 26, 20);
        test.executeGame(false, 27, 19);
        test.executeGame(false, 28, 18);
        test.executeGame(false, 29, 17);
        test.executeGame(false, 30, 16);
        test.executeGame(false, 31, 15);
        test.executeGame(false, 1, 14);
        test.executeGame(false, 2, 13);
        test.executeGame(false, 3, 12);
        test.executeGame(false, 4, 11);
        test.executeGame(false, 5, 10);
        test.executeGame(false, 6, 9);
        test.executeGame(false, 7, 8);
    }
    private void Game13()
    {
        
        
        
        test.executeGame(false, 0, 7);
        test.executeGame(false, 1, 6);
        test.executeGame(false, 2, 5);
        test.executeGame(false, 3, 4);
        test.executeGame(false, 8, 15);
        test.executeGame(false, 9, 14);
        test.executeGame(false, 10, 13);
        test.executeGame(false, 11, 12);
        test.executeGame(false, 31, 24);
        test.executeGame(false, 30, 25);
        test.executeGame(false, 29, 26);
        test.executeGame(false, 28, 27);
        test.executeGame(false, 23, 16);
        test.executeGame(false, 22, 17);
        test.executeGame(false, 21, 18);
        test.executeGame(false, 20, 19);
    }
    private void Game14()
    {
        
        
        
        test.executeGame(false, 31, 26);
        test.executeGame(false, 25, 27);
        test.executeGame(false, 24, 28);
        test.executeGame(false, 23, 29);
        test.executeGame(false, 22, 30);
        test.executeGame(false, 21, 16);
        test.executeGame(false, 20, 17);
        test.executeGame(false, 19, 18);
        test.executeGame(false, 0, 5);
        test.executeGame(false, 6, 4);
        test.executeGame(false, 7, 3);
        test.executeGame(false, 8, 2);
        test.executeGame(false, 9, 1);
        test.executeGame(false, 10, 15);
        test.executeGame(false, 11, 14);
        test.executeGame(false, 12, 13);
    }
    private void Game15()
    {
        
        
        
        test.executeGame(false, 31, 30);
        test.executeGame(false, 29, 16);
        test.executeGame(false, 28, 17);
        test.executeGame(false, 27, 18);
        test.executeGame(false, 26, 19);
        test.executeGame(false, 25, 20);
        test.executeGame(false, 24, 21);
        test.executeGame(false, 23, 22);
        test.executeGame(false, 0, 1);
        test.executeGame(false, 2, 15);
        test.executeGame(false, 3, 14);
        test.executeGame(false, 4, 13);
        test.executeGame(false, 5, 12);
        test.executeGame(false, 6, 11);
        test.executeGame(false, 7, 10);
        test.executeGame(false, 8, 9);
    }
    private void Game16()
    {
        
        
        
        test.executeGame(false, 19, 31);
        test.executeGame(false, 18, 20);
        test.executeGame(false, 17, 21);
        test.executeGame(false, 16, 22);
        test.executeGame(false, 30, 23);
        test.executeGame(false, 29, 24);
        test.executeGame(false, 28, 25);
        test.executeGame(false, 27, 26);
        test.executeGame(false, 12, 0);
        test.executeGame(false, 13, 11);
        test.executeGame(false, 14, 10);
        test.executeGame(false, 15, 9);
        test.executeGame(false, 1, 8);
        test.executeGame(false, 2, 7);
        test.executeGame(false, 3, 6);
        test.executeGame(false, 4, 5);
    }
    private void Game17()
    {
        
        
        
        test.executeGame(false, 31, 28);
        test.executeGame(false, 27, 29);
        test.executeGame(false, 26, 30);
        test.executeGame(false, 25, 16);
        test.executeGame(false, 24, 17);
        test.executeGame(false, 23, 18);
        test.executeGame(false, 22, 19);
        test.executeGame(false, 21, 20);
        test.executeGame(false, 0, 3);
        test.executeGame(false, 4, 2);
        test.executeGame(false, 5, 1);
        test.executeGame(false, 6, 15);
        test.executeGame(false, 7, 14);
        test.executeGame(false, 8, 13);
        test.executeGame(false, 9, 12);
        test.executeGame(false, 10, 11);
    }
    private void Game18()
    {
        
        
        
        test.executeGame(false, 3, 0);
        test.executeGame(false, 2, 4);
        test.executeGame(false, 1, 5);
        test.executeGame(false, 31, 6);
        test.executeGame(false, 30, 7);
        test.executeGame(false, 29, 8);
        test.executeGame(false, 28, 9);
        test.executeGame(false, 27, 10);
        test.executeGame(false, 26, 11);
        test.executeGame(false, 25, 12);
        test.executeGame(false, 24, 13);
        test.executeGame(false, 23, 14);
        test.executeGame(false, 22, 15);
        test.executeGame(false, 21, 16);
        test.executeGame(false, 20, 17);
        test.executeGame(false, 19, 18);
    }
    private void Game19()
    {
        
        
        
        test.executeGame(false, 6, 0);
        test.executeGame(false, 7, 5);
        test.executeGame(false, 1, 4);
        test.executeGame(false, 3, 2);
        test.executeGame(false, 14, 8);
        test.executeGame(false, 15, 13);
        test.executeGame(false, 9, 12);
        test.executeGame(false, 11, 10);
        test.executeGame(false, 25, 31);
        test.executeGame(false, 24, 26);
        test.executeGame(false, 30, 27);
        test.executeGame(false, 28, 29);
        test.executeGame(false, 17, 23);
        test.executeGame(false, 16, 18);
        test.executeGame(false, 22, 19);
        test.executeGame(false, 20, 21);
    }
    private void Game20()
    {
        
        
        
        test.executeGame(false, 0, 9);
        test.executeGame(false, 10, 8);
        test.executeGame(false, 11, 7);
        test.executeGame(false, 12, 6);
        test.executeGame(false, 13, 5);
        test.executeGame(false, 14, 4);
        test.executeGame(false, 15, 3);
        test.executeGame(false, 16, 2);
        test.executeGame(false, 17, 1);
        test.executeGame(false, 18, 31);
        test.executeGame(false, 19, 30);
        test.executeGame(false, 20, 29);
        test.executeGame(false, 21, 28);
        test.executeGame(false, 22, 27);
        test.executeGame(false, 23, 26);
        test.executeGame(false, 24, 25);
    }
    private void Game21()
    {
        
        
        
        test.executeGame(false, 0, 10);
        test.executeGame(false, 9, 11);
        test.executeGame(false, 8, 12);
        test.executeGame(false, 7, 13);
        test.executeGame(false, 6, 14);
        test.executeGame(false, 5, 15);
        test.executeGame(false, 4, 16);
        test.executeGame(false, 3, 17);
        test.executeGame(false, 2, 18);
        test.executeGame(false, 1, 19);
        test.executeGame(false, 31, 20);
        test.executeGame(false, 30, 21);
        test.executeGame(false, 29, 22);
        test.executeGame(false, 28, 23);
        test.executeGame(false, 27, 24);
        test.executeGame(false, 26, 25);
    }
    private void Game22()
    {
        
        
        
        test.executeGame(false, 1, 0);
        test.executeGame(false, 2, 7);
        test.executeGame(false, 3, 6);
        test.executeGame(false, 5, 4);
        test.executeGame(false, 9, 8);
        test.executeGame(false, 10, 15);
        test.executeGame(false, 11, 14);
        test.executeGame(false, 13, 12);
        test.executeGame(false, 30, 31);
        test.executeGame(false, 29, 24);
        test.executeGame(false, 28, 25);
        test.executeGame(false, 26, 27);
        test.executeGame(false, 22, 23);
        test.executeGame(false, 21, 16);
        test.executeGame(false, 20, 17);
        test.executeGame(false, 18, 19);
    }
    private void Game23()
    {
        
        
        
        test.executeGame(false, 7, 0);
        test.executeGame(false, 6, 8);
        test.executeGame(false, 5, 9);
        test.executeGame(false, 4, 10);
        test.executeGame(false, 3, 11);
        test.executeGame(false, 2, 12);
        test.executeGame(false, 1, 13);
        test.executeGame(false, 31, 14);
        test.executeGame(false, 30, 15);
        test.executeGame(false, 29, 16);
        test.executeGame(false, 28, 17);
        test.executeGame(false, 27, 18);
        test.executeGame(false, 26, 19);
        test.executeGame(false, 25, 20);
        test.executeGame(false, 24, 21);
        test.executeGame(false, 23, 22);
    }
    private void Game24()
    {
        
        
        
        test.executeGame(false, 0, 16);
        test.executeGame(false, 15, 17);
        test.executeGame(false, 14, 18);
        test.executeGame(false, 13, 19);
        test.executeGame(false, 12, 20);
        test.executeGame(false, 11, 21);
        test.executeGame(false, 10, 22);
        test.executeGame(false, 9, 23);
        test.executeGame(false, 8, 24);
        test.executeGame(false, 7, 25);
        test.executeGame(false, 6, 26);
        test.executeGame(false, 5, 27);
        test.executeGame(false, 4, 28);
        test.executeGame(false, 3, 29);
        test.executeGame(false, 2, 30);
        test.executeGame(false, 1, 31);
    }
    private void Game25()
    {
        
        
        
        test.executeGame(false, 6, 0);
        test.executeGame(false, 7, 5);
        test.executeGame(false, 8, 4);
        test.executeGame(false, 9, 3);
        test.executeGame(false, 10, 2);
        test.executeGame(false, 11, 1);
        test.executeGame(false, 12, 31);
        test.executeGame(false, 13, 30);
        test.executeGame(false, 14, 29);
        test.executeGame(false, 15, 28);
        test.executeGame(false, 16, 27);
        test.executeGame(false, 17, 26);
        test.executeGame(false, 18, 25);
        test.executeGame(false, 19, 24);
        test.executeGame(false, 20, 23);
        test.executeGame(false, 21, 22);
    }
    private void Game26()
    {
        
        
        
        test.executeGame(false, 17, 31);
        test.executeGame(false, 16, 18);
        test.executeGame(false, 30, 19);
        test.executeGame(false, 29, 20);
        test.executeGame(false, 28, 21);
        test.executeGame(false, 27, 22);
        test.executeGame(false, 26, 23);
        test.executeGame(false, 25, 24);
        test.executeGame(false, 14, 0);
        test.executeGame(false, 15, 13);
        test.executeGame(false, 1, 12);
        test.executeGame(false, 2, 11);
        test.executeGame(false, 3, 10);
        test.executeGame(false, 4, 9);
        test.executeGame(false, 5, 8);
        test.executeGame(false, 6, 7);
    }
    private void Game27()
    {
        
        
        
        test.executeGame(false, 0, 5);
        test.executeGame(false, 6, 4);
        test.executeGame(false, 7, 3);
        test.executeGame(false, 8, 2);
        test.executeGame(false, 9, 1);
        test.executeGame(false, 10, 31);
        test.executeGame(false, 11, 30);
        test.executeGame(false, 12, 29);
        test.executeGame(false, 13, 28);
        test.executeGame(false, 14, 27);
        test.executeGame(false, 15, 26);
        test.executeGame(false, 16, 25);
        test.executeGame(false, 17, 24);
        test.executeGame(false, 18, 23);
        test.executeGame(false, 19, 22);
        test.executeGame(false, 20, 21);
    }
    private void Game28()
    {
        
        
        
        test.executeGame(false, 0, 31);
        test.executeGame(false, 1, 30);
        test.executeGame(false, 2, 29);
        test.executeGame(false, 3, 28);
        test.executeGame(false, 4, 27);
        test.executeGame(false, 5, 26);
        test.executeGame(false, 6, 25);
        test.executeGame(false, 7, 24);
        test.executeGame(false, 8, 23);
        test.executeGame(false, 9, 22);
        test.executeGame(false, 10, 21);
        test.executeGame(false, 11, 20);
        test.executeGame(false, 12, 19);
        test.executeGame(false, 13, 18);
        test.executeGame(false, 14, 17);
        test.executeGame(false, 15, 16);
    }
    private void Game29()
    {
        
        
        
        test.executeGame(false, 0, 30);
        test.executeGame(false, 29, 31);
        test.executeGame(false, 28, 1);
        test.executeGame(false, 27, 2);
        test.executeGame(false, 26, 3);
        test.executeGame(false, 25, 4);
        test.executeGame(false, 24, 5);
        test.executeGame(false, 23, 6);
        test.executeGame(false, 22, 7);
        test.executeGame(false, 21, 8);
        test.executeGame(false, 20, 9);
        test.executeGame(false, 19, 10);
        test.executeGame(false, 18, 11);
        test.executeGame(false, 17, 12);
        test.executeGame(false, 16, 13);
        test.executeGame(false, 15, 14);
    }
    private void Game30()
    {
        
        
        
        test.executeGame(false, 0, 15);
        test.executeGame(false, 16, 14);
        test.executeGame(false, 17, 13);
        test.executeGame(false, 18, 12);
        test.executeGame(false, 19, 11);
        test.executeGame(false, 20, 10);
        test.executeGame(false, 21, 9);
        test.executeGame(false, 22, 8);
        test.executeGame(false, 23, 7);
        test.executeGame(false, 24, 6);
        test.executeGame(false, 25, 5);
        test.executeGame(false, 26, 4);
        test.executeGame(false, 27, 3);
        test.executeGame(false, 28, 2);
        test.executeGame(false, 29, 1);
        test.executeGame(false, 30, 31);
    }
    private void Game31()
    {
        
        
        
        test.executeGame(false, 21, 31);
        test.executeGame(false, 20, 22);
        test.executeGame(false, 19, 23);
        test.executeGame(false, 18, 24);
        test.executeGame(false, 17, 25);
        test.executeGame(false, 16, 26);
        test.executeGame(false, 30, 27);
        test.executeGame(false, 29, 28);
        test.executeGame(false, 10, 0);
        test.executeGame(false, 11, 9);
        test.executeGame(false, 12, 8);
        test.executeGame(false, 13, 7);
        test.executeGame(false, 14, 6);
        test.executeGame(false, 15, 5);
        test.executeGame(false, 1, 4);
        test.executeGame(false, 2, 3);
    }
    private void Game32()
    {
        
        
        
        test.executeGame(false, 0, 1);
        test.executeGame(false, 2, 31);
        test.executeGame(false, 3, 30);
        test.executeGame(false, 4, 29);
        test.executeGame(false, 5, 28);
        test.executeGame(false, 6, 27);
        test.executeGame(false, 7, 26);
        test.executeGame(false, 8, 25);
        test.executeGame(false, 9, 24);
        test.executeGame(false, 10, 23);
        test.executeGame(false, 11, 22);
        test.executeGame(false, 12, 21);
        test.executeGame(false, 13, 20);
        test.executeGame(false, 14, 19);
        test.executeGame(false, 15, 18);
        test.executeGame(false, 16, 17);
    }
    private void Game33()
    {
        
        
        
        test.executeGame(false, 12, 0);
        test.executeGame(false, 13, 11);
        test.executeGame(false, 14, 10);
        test.executeGame(false, 15, 9);
        test.executeGame(false, 16, 8);
        test.executeGame(false, 17, 7);
        test.executeGame(false, 18, 6);
        test.executeGame(false, 19, 5);
        test.executeGame(false, 20, 4);
        test.executeGame(false, 21, 3);
        test.executeGame(false, 22, 2);
        test.executeGame(false, 23, 1);
        test.executeGame(false, 24, 31);
        test.executeGame(false, 25, 30);
        test.executeGame(false, 26, 29);
        test.executeGame(false, 27, 28);
    }
    private void Game34()
    {
        
        
        
        test.executeGame(false, 0, 20);
        test.executeGame(false, 19, 21);
        test.executeGame(false, 18, 22);
        test.executeGame(false, 17, 23);
        test.executeGame(false, 16, 24);
        test.executeGame(false, 15, 25);
        test.executeGame(false, 14, 26);
        test.executeGame(false, 13, 27);
        test.executeGame(false, 12, 28);
        test.executeGame(false, 11, 29);
        test.executeGame(false, 10, 30);
        test.executeGame(false, 9, 31);
        test.executeGame(false, 8, 1);
        test.executeGame(false, 7, 2);
        test.executeGame(false, 6, 3);
        test.executeGame(false, 5, 4);
    }
    private void Game35()
    {
        
        
        
        test.executeGame(false, 8, 0);
        test.executeGame(false, 9, 7);
        test.executeGame(false, 10, 6);
        test.executeGame(false, 11, 5);
        test.executeGame(false, 12, 4);
        test.executeGame(false, 13, 3);
        test.executeGame(false, 14, 2);
        test.executeGame(false, 15, 1);
        test.executeGame(false, 16, 31);
        test.executeGame(false, 17, 30);
        test.executeGame(false, 18, 29);
        test.executeGame(false, 19, 28);
        test.executeGame(false, 20, 27);
        test.executeGame(false, 21, 26);
        test.executeGame(false, 22, 25);
        test.executeGame(false, 23, 24);
    }
    private void Game36()
    {
        
        
        
        test.executeGame(false, 0, 22);
        test.executeGame(false, 21, 23);
        test.executeGame(false, 20, 24);
        test.executeGame(false, 19, 25);
        test.executeGame(false, 18, 26);
        test.executeGame(false, 17, 27);
        test.executeGame(false, 16, 28);
        test.executeGame(false, 15, 29);
        test.executeGame(false, 14, 30);
        test.executeGame(false, 13, 31);
        test.executeGame(false, 12, 1);
        test.executeGame(false, 11, 2);
        test.executeGame(false, 10, 3);
        test.executeGame(false, 9, 4);
        test.executeGame(false, 8, 5);
        test.executeGame(false, 7, 6);
    }
    private void Game37()
    {
        
        
        
        test.executeGame(false, 19, 0);
        test.executeGame(false, 18, 20);
        test.executeGame(false, 17, 21);
        test.executeGame(false, 16, 22);
        test.executeGame(false, 15, 23);
        test.executeGame(false, 14, 24);
        test.executeGame(false, 13, 25);
        test.executeGame(false, 12, 26);
        test.executeGame(false, 11, 27);
        test.executeGame(false, 10, 28);
        test.executeGame(false, 9, 29);
        test.executeGame(false, 8, 30);
        test.executeGame(false, 7, 31);
        test.executeGame(false, 6, 1);
        test.executeGame(false, 5, 2);
        test.executeGame(false, 4, 3);
    }
    private void Game38()
    {
        
        
        
        test.executeGame(false, 0, 3);
        test.executeGame(false, 4, 2);
        test.executeGame(false, 5, 1);
        test.executeGame(false, 7, 6);
        test.executeGame(false, 8, 11);
        test.executeGame(false, 12, 10);
        test.executeGame(false, 13, 9);
        test.executeGame(false, 15, 14);
        test.executeGame(false, 31, 28);
        test.executeGame(false, 27, 29);
        test.executeGame(false, 26, 30);
        test.executeGame(false, 24, 25);
        test.executeGame(false, 23, 20);
        test.executeGame(false, 19, 21);
        test.executeGame(false, 18, 22);
        test.executeGame(false, 16, 17);
    }
    private void Game39()
    {
        
        
        
        test.executeGame(false, 31, 22);
        test.executeGame(false, 21, 23);
        test.executeGame(false, 20, 24);
        test.executeGame(false, 19, 25);
        test.executeGame(false, 18, 26);
        test.executeGame(false, 17, 27);
        test.executeGame(false, 16, 28);
        test.executeGame(false, 30, 29);
        test.executeGame(false, 0, 9);
        test.executeGame(false, 10, 8);
        test.executeGame(false, 11, 7);
        test.executeGame(false, 12, 6);
        test.executeGame(false, 13, 5);
        test.executeGame(false, 14, 4);
        test.executeGame(false, 15, 3);
        test.executeGame(false, 1, 2);
    }
    private void Game40()
    {
        
        
        
        test.executeGame(false, 27, 0);
        test.executeGame(false, 26, 28);
        test.executeGame(false, 25, 29);
        test.executeGame(false, 24, 30);
        test.executeGame(false, 23, 31);
        test.executeGame(false, 22, 1);
        test.executeGame(false, 21, 2);
        test.executeGame(false, 20, 3);
        test.executeGame(false, 19, 4);
        test.executeGame(false, 18, 5);
        test.executeGame(false, 17, 6);
        test.executeGame(false, 16, 7);
        test.executeGame(false, 15, 8);
        test.executeGame(false, 14, 9);
        test.executeGame(false, 13, 10);
        test.executeGame(false, 12, 11);
    }
    private void Game41()
    {
        
        
        
        test.executeGame(false, 16, 0);
        test.executeGame(false, 17, 15);
        test.executeGame(false, 18, 14);
        test.executeGame(false, 19, 13);
        test.executeGame(false, 20, 12);
        test.executeGame(false, 21, 11);
        test.executeGame(false, 22, 10);
        test.executeGame(false, 23, 9);
        test.executeGame(false, 24, 8);
        test.executeGame(false, 25, 7);
        test.executeGame(false, 26, 6);
        test.executeGame(false, 27, 5);
        test.executeGame(false, 28, 4);
        test.executeGame(false, 29, 3);
        test.executeGame(false, 30, 2);
        test.executeGame(false, 31, 1);
    }
    private void Game42()
    {
        
        
        
        test.executeGame(false, 0, 6);
        test.executeGame(false, 5, 7);
        test.executeGame(false, 4, 8);
        test.executeGame(false, 3, 9);
        test.executeGame(false, 2, 10);
        test.executeGame(false, 1, 11);
        test.executeGame(false, 31, 12);
        test.executeGame(false, 30, 13);
        test.executeGame(false, 29, 14);
        test.executeGame(false, 28, 15);
        test.executeGame(false, 27, 16);
        test.executeGame(false, 26, 17);
        test.executeGame(false, 25, 18);
        test.executeGame(false, 24, 19);
        test.executeGame(false, 23, 20);
        test.executeGame(false, 22, 21);
    }
    private void Game43()
    {
        
        
        
        test.executeGame(false, 0, 3);
        test.executeGame(false, 4, 2);
        test.executeGame(false, 5, 1);
        test.executeGame(false, 6, 31);
        test.executeGame(false, 7, 30);
        test.executeGame(false, 8, 29);
        test.executeGame(false, 9, 28);
        test.executeGame(false, 10, 27);
        test.executeGame(false, 11, 26);
        test.executeGame(false, 12, 25);
        test.executeGame(false, 13, 24);
        test.executeGame(false, 14, 23);
        test.executeGame(false, 15, 22);
        test.executeGame(false, 16, 21);
        test.executeGame(false, 17, 20);
        test.executeGame(false, 18, 19);
    }
    private void Game44()
    {
        
        
        
        test.executeGame(false, 18, 0);
        test.executeGame(false, 19, 17);
        test.executeGame(false, 20, 16);
        test.executeGame(false, 21, 15);
        test.executeGame(false, 22, 14);
        test.executeGame(false, 23, 13);
        test.executeGame(false, 24, 12);
        test.executeGame(false, 25, 11);
        test.executeGame(false, 26, 10);
        test.executeGame(false, 27, 9);
        test.executeGame(false, 28, 8);
        test.executeGame(false, 29, 7);
        test.executeGame(false, 30, 6);
        test.executeGame(false, 31, 5);
        test.executeGame(false, 1, 4);
        test.executeGame(false, 2, 3);
    }
    private void Game45()
    {
        
        
        
        test.executeGame(false, 22, 0);
        test.executeGame(false, 23, 21);
        test.executeGame(false, 24, 20);
        test.executeGame(false, 25, 19);
        test.executeGame(false, 26, 18);
        test.executeGame(false, 27, 17);
        test.executeGame(false, 28, 16);
        test.executeGame(false, 29, 15);
        test.executeGame(false, 30, 14);
        test.executeGame(false, 31, 13);
        test.executeGame(false, 1, 12);
        test.executeGame(false, 2, 11);
        test.executeGame(false, 3, 10);
        test.executeGame(false, 4, 9);
        test.executeGame(false, 5, 8);
        test.executeGame(false, 6, 7);
    }
    private void Game46()
    {
        
        
        
        test.executeGame(false, 25, 0);
        test.executeGame(false, 24, 26);
        test.executeGame(false, 23, 27);
        test.executeGame(false, 22, 28);
        test.executeGame(false, 21, 29);
        test.executeGame(false, 20, 30);
        test.executeGame(false, 19, 31);
        test.executeGame(false, 18, 1);
        test.executeGame(false, 17, 2);
        test.executeGame(false, 16, 3);
        test.executeGame(false, 15, 4);
        test.executeGame(false, 14, 5);
        test.executeGame(false, 13, 6);
        test.executeGame(false, 12, 7);
        test.executeGame(false, 11, 8);
        test.executeGame(false, 10, 9);
    }
    private void Game47()
    {
        
        
        
        test.executeGame(false, 10, 0);
        test.executeGame(false, 11, 9);
        test.executeGame(false, 12, 8);
        test.executeGame(false, 13, 7);
        test.executeGame(false, 14, 6);
        test.executeGame(false, 15, 5);
        test.executeGame(false, 16, 4);
        test.executeGame(false, 17, 3);
        test.executeGame(false, 18, 2);
        test.executeGame(false, 19, 1);
        test.executeGame(false, 20, 31);
        test.executeGame(false, 21, 30);
        test.executeGame(false, 22, 29);
        test.executeGame(false, 23, 28);
        test.executeGame(false, 24, 27);
        test.executeGame(false, 25, 26);
    }
    private void Game48()
    {
        
        
        
        test.executeGame(false, 0, 17);
        test.executeGame(false, 18, 16);
        test.executeGame(false, 19, 15);
        test.executeGame(false, 20, 14);
        test.executeGame(false, 21, 13);
        test.executeGame(false, 22, 12);
        test.executeGame(false, 23, 11);
        test.executeGame(false, 24, 10);
        test.executeGame(false, 25, 9);
        test.executeGame(false, 26, 8);
        test.executeGame(false, 27, 7);
        test.executeGame(false, 28, 6);
        test.executeGame(false, 29, 5);
        test.executeGame(false, 30, 4);
        test.executeGame(false, 31, 3);
        test.executeGame(false, 1, 2);
    }
    private void Game49()
    {
        
        
        
        test.executeGame(false, 0, 21);
        test.executeGame(false, 22, 20);
        test.executeGame(false, 23, 19);
        test.executeGame(false, 24, 18);
        test.executeGame(false, 25, 17);
        test.executeGame(false, 26, 16);
        test.executeGame(false, 27, 15);
        test.executeGame(false, 28, 14);
        test.executeGame(false, 29, 13);
        test.executeGame(false, 30, 12);
        test.executeGame(false, 31, 11);
        test.executeGame(false, 1, 10);
        test.executeGame(false, 2, 9);
        test.executeGame(false, 3, 8);
        test.executeGame(false, 4, 7);
        test.executeGame(false, 5, 6);
    }
    private void Game50()
    {
        
        
        
        test.executeGame(false, 29, 31);
        test.executeGame(false, 28, 30);
        test.executeGame(false, 27, 16);
        test.executeGame(false, 26, 17);
        test.executeGame(false, 25, 18);
        test.executeGame(false, 24, 19);
        test.executeGame(false, 23, 20);
        test.executeGame(false, 22, 21);
        test.executeGame(false, 2, 0);
        test.executeGame(false, 3, 1);
        test.executeGame(false, 4, 15);
        test.executeGame(false, 5, 14);
        test.executeGame(false, 6, 13);
        test.executeGame(false, 7, 12);
        test.executeGame(false, 8, 11);
        test.executeGame(false, 9, 10);
    }
    private void Game51()
    {
        
        
        
        test.executeGame(false, 0, 4);
        test.executeGame(false, 3, 5);
        test.executeGame(false, 2, 6);
        test.executeGame(false, 1, 7);
        test.executeGame(false, 31, 8);
        test.executeGame(false, 30, 9);
        test.executeGame(false, 29, 10);
        test.executeGame(false, 28, 11);
        test.executeGame(false, 27, 12);
        test.executeGame(false, 26, 13);
        test.executeGame(false, 25, 14);
        test.executeGame(false, 24, 15);
        test.executeGame(false, 23, 16);
        test.executeGame(false, 22, 17);
        test.executeGame(false, 21, 18);
        test.executeGame(false, 20, 19);
    }
    private void Game52()
    {
        
        
        
        test.executeGame(false, 0, 28);
        test.executeGame(false, 27, 29);
        test.executeGame(false, 26, 30);
        test.executeGame(false, 25, 31);
        test.executeGame(false, 24, 1);
        test.executeGame(false, 23, 2);
        test.executeGame(false, 22, 3);
        test.executeGame(false, 21, 4);
        test.executeGame(false, 20, 5);
        test.executeGame(false, 19, 6);
        test.executeGame(false, 18, 7);
        test.executeGame(false, 17, 8);
        test.executeGame(false, 16, 9);
        test.executeGame(false, 15, 10);
        test.executeGame(false, 14, 11);
        test.executeGame(false, 13, 12);
    }
    private void Game53()
    {
        
        
        
        test.executeGame(false, 0, 24);
        test.executeGame(false, 23, 25);
        test.executeGame(false, 22, 26);
        test.executeGame(false, 21, 27);
        test.executeGame(false, 20, 28);
        test.executeGame(false, 19, 29);
        test.executeGame(false, 18, 30);
        test.executeGame(false, 17, 31);
        test.executeGame(false, 16, 1);
        test.executeGame(false, 15, 2);
        test.executeGame(false, 14, 3);
        test.executeGame(false, 13, 4);
        test.executeGame(false, 12, 5);
        test.executeGame(false, 11, 6);
        test.executeGame(false, 10, 7);
        test.executeGame(false, 9, 8);
    }
    private void Game54()
    {
        
        
        
        test.executeGame(false, 2, 0);
        test.executeGame(false, 3, 1);
        test.executeGame(false, 4, 7);
        test.executeGame(false, 5, 6);
        test.executeGame(false, 10, 8);
        test.executeGame(false, 11, 9);
        test.executeGame(false, 12, 15);
        test.executeGame(false, 13, 14);
        test.executeGame(false, 29, 31);
        test.executeGame(false, 28, 30);
        test.executeGame(false, 27, 24);
        test.executeGame(false, 26, 25);
        test.executeGame(false, 21, 23);
        test.executeGame(false, 20, 22);
        test.executeGame(false, 19, 16);
        test.executeGame(false, 18, 17);
    }
    private void Game55()
    {
        
        
        
        test.executeGame(false, 0, 8);
        test.executeGame(false, 7, 9);
        test.executeGame(false, 6, 10);
        test.executeGame(false, 5, 11);
        test.executeGame(false, 4, 12);
        test.executeGame(false, 3, 13);
        test.executeGame(false, 2, 14);
        test.executeGame(false, 1, 15);
        test.executeGame(false, 31, 16);
        test.executeGame(false, 30, 17);
        test.executeGame(false, 29, 18);
        test.executeGame(false, 28, 19);
        test.executeGame(false, 27, 20);
        test.executeGame(false, 26, 21);
        test.executeGame(false, 25, 22);
        test.executeGame(false, 24, 23);
    }
    private void Game56()
    {
        
        
        
        test.executeGame(false, 0, 11);
        test.executeGame(false, 12, 10);
        test.executeGame(false, 13, 9);
        test.executeGame(false, 14, 8);
        test.executeGame(false, 15, 7);
        test.executeGame(false, 16, 6);
        test.executeGame(false, 17, 5);
        test.executeGame(false, 18, 4);
        test.executeGame(false, 19, 3);
        test.executeGame(false, 20, 2);
        test.executeGame(false, 21, 1);
        test.executeGame(false, 22, 31);
        test.executeGame(false, 23, 30);
        test.executeGame(false, 24, 29);
        test.executeGame(false, 25, 28);
        test.executeGame(false, 26, 27);
    }
    private void Game57()
    {
        
        
        
        test.executeGame(false, 31, 20);
        test.executeGame(false, 19, 21);
        test.executeGame(false, 18, 22);
        test.executeGame(false, 17, 23);
        test.executeGame(false, 16, 24);
        test.executeGame(false, 30, 25);
        test.executeGame(false, 29, 26);
        test.executeGame(false, 28, 27);
        test.executeGame(false, 0, 11);
        test.executeGame(false, 12, 10);
        test.executeGame(false, 13, 9);
        test.executeGame(false, 14, 8);
        test.executeGame(false, 15, 7);
        test.executeGame(false, 1, 6);
        test.executeGame(false, 2, 5);
        test.executeGame(false, 3, 4);
    }
    private void Game58()
    {
        
        
        
        test.executeGame(false, 0, 13);
        test.executeGame(false, 14, 12);
        test.executeGame(false, 15, 11);
        test.executeGame(false, 16, 10);
        test.executeGame(false, 17, 9);
        test.executeGame(false, 18, 8);
        test.executeGame(false, 19, 7);
        test.executeGame(false, 20, 6);
        test.executeGame(false, 21, 5);
        test.executeGame(false, 22, 4);
        test.executeGame(false, 23, 3);
        test.executeGame(false, 24, 2);
        test.executeGame(false, 25, 1);
        test.executeGame(false, 26, 31);
        test.executeGame(false, 27, 30);
        test.executeGame(false, 28, 29);
    }
    private void Game59()
    {
        
        
        
        test.executeGame(false, 17, 0);
        test.executeGame(false, 16, 18);
        test.executeGame(false, 15, 19);
        test.executeGame(false, 14, 20);
        test.executeGame(false, 13, 21);
        test.executeGame(false, 12, 22);
        test.executeGame(false, 11, 23);
        test.executeGame(false, 10, 24);
        test.executeGame(false, 9, 25);
        test.executeGame(false, 8, 26);
        test.executeGame(false, 7, 27);
        test.executeGame(false, 6, 28);
        test.executeGame(false, 5, 29);
        test.executeGame(false, 4, 30);
        test.executeGame(false, 3, 31);
        test.executeGame(false, 2, 1);
    }
    private void Game60()
    {
        
        
        
        test.executeGame(false, 0, 25);
        test.executeGame(false, 26, 24);
        test.executeGame(false, 27, 23);
        test.executeGame(false, 28, 22);
        test.executeGame(false, 29, 21);
        test.executeGame(false, 30, 20);
        test.executeGame(false, 31, 19);
        test.executeGame(false, 1, 18);
        test.executeGame(false, 2, 17);
        test.executeGame(false, 3, 16);
        test.executeGame(false, 4, 15);
        test.executeGame(false, 5, 14);
        test.executeGame(false, 6, 13);
        test.executeGame(false, 7, 12);
        test.executeGame(false, 8, 11);
        test.executeGame(false, 9, 10);
    }
    private void Game61()
    {
        
        
        
        test.executeGame(false, 31, 18);
        test.executeGame(false, 17, 19);
        test.executeGame(false, 16, 20);
        test.executeGame(false, 30, 21);
        test.executeGame(false, 29, 22);
        test.executeGame(false, 28, 23);
        test.executeGame(false, 27, 24);
        test.executeGame(false, 26, 25);
        test.executeGame(false, 0, 13);
        test.executeGame(false, 14, 12);
        test.executeGame(false, 15, 11);
        test.executeGame(false, 1, 10);
        test.executeGame(false, 2, 9);
        test.executeGame(false, 3, 8);
        test.executeGame(false, 4, 7);
        test.executeGame(false, 5, 6);
    }
    private void Game62()
    {
        
        
        
        test.executeGame(false, 29, 0);
        test.executeGame(false, 28, 30);
        test.executeGame(false, 27, 31);
        test.executeGame(false, 26, 1);
        test.executeGame(false, 25, 2);
        test.executeGame(false, 24, 3);
        test.executeGame(false, 23, 4);
        test.executeGame(false, 22, 5);
        test.executeGame(false, 21, 6);
        test.executeGame(false, 20, 7);
        test.executeGame(false, 19, 8);
        test.executeGame(false, 18, 9);
        test.executeGame(false, 17, 10);
        test.executeGame(false, 16, 11);
        test.executeGame(false, 15, 12);
        test.executeGame(false, 14, 13);
    }
    private void Game63()
    {
        
        
        
        test.executeGame(false, 4, 0);
        test.executeGame(false, 5, 3);
        test.executeGame(false, 6, 2);
        test.executeGame(false, 7, 1);
        test.executeGame(false, 12, 8);
        test.executeGame(false, 13, 11);
        test.executeGame(false, 14, 10);
        test.executeGame(false, 15, 9);
        test.executeGame(false, 27, 31);
        test.executeGame(false, 26, 28);
        test.executeGame(false, 25, 29);
        test.executeGame(false, 24, 30);
        test.executeGame(false, 19, 23);
        test.executeGame(false, 18, 20);
        test.executeGame(false, 17, 21);
        test.executeGame(false, 16, 22);
    }
    private void Game64()
    {
        
        
        
        test.executeGame(false, 5, 0);
        test.executeGame(false, 4, 6);
        test.executeGame(false, 3, 7);
        test.executeGame(false, 2, 8);
        test.executeGame(false, 1, 9);
        test.executeGame(false, 31, 10);
        test.executeGame(false, 30, 11);
        test.executeGame(false, 29, 12);
        test.executeGame(false, 28, 13);
        test.executeGame(false, 27, 14);
        test.executeGame(false, 26, 15);
        test.executeGame(false, 25, 16);
        test.executeGame(false, 24, 17);
        test.executeGame(false, 23, 18);
        test.executeGame(false, 22, 19);
        test.executeGame(false, 21, 20);
    }
    private void Game65()
    {
        
        
        
        test.executeGame(false, 2, 0);
        test.executeGame(false, 3, 1);
        test.executeGame(false, 4, 31);
        test.executeGame(false, 5, 30);
        test.executeGame(false, 6, 29);
        test.executeGame(false, 7, 28);
        test.executeGame(false, 8, 27);
        test.executeGame(false, 9, 26);
        test.executeGame(false, 10, 25);
        test.executeGame(false, 11, 24);
        test.executeGame(false, 12, 23);
        test.executeGame(false, 13, 22);
        test.executeGame(false, 14, 21);
        test.executeGame(false, 15, 20);
        test.executeGame(false, 16, 19);
        test.executeGame(false, 17, 18);
    }
    private void Game66()
    {
        
        
        
        test.executeGame(false, 21, 0);
        test.executeGame(false, 20, 22);
        test.executeGame(false, 19, 23);
        test.executeGame(false, 18, 24);
        test.executeGame(false, 17, 25);
        test.executeGame(false, 16, 26);
        test.executeGame(false, 15, 27);
        test.executeGame(false, 14, 28);
        test.executeGame(false, 13, 29);
        test.executeGame(false, 12, 30);
        test.executeGame(false, 11, 31);
        test.executeGame(false, 10, 1);
        test.executeGame(false, 9, 2);
        test.executeGame(false, 8, 3);
        test.executeGame(false, 7, 4);
        test.executeGame(false, 6, 5);
    }
    private void Game67()
    {
        
        
        
        test.executeGame(false, 0, 14);
        test.executeGame(false, 13, 15);
        test.executeGame(false, 12, 16);
        test.executeGame(false, 11, 17);
        test.executeGame(false, 10, 18);
        test.executeGame(false, 9, 19);
        test.executeGame(false, 8, 20);
        test.executeGame(false, 7, 21);
        test.executeGame(false, 6, 22);
        test.executeGame(false, 5, 23);
        test.executeGame(false, 4, 24);
        test.executeGame(false, 3, 25);
        test.executeGame(false, 2, 26);
        test.executeGame(false, 1, 27);
        test.executeGame(false, 31, 28);
        test.executeGame(false, 30, 29);
    }
    private void Game68()
    {
        
        
        
        test.executeGame(false, 14, 0);
        test.executeGame(false, 15, 13);
        test.executeGame(false, 16, 12);
        test.executeGame(false, 17, 11);
        test.executeGame(false, 18, 10);
        test.executeGame(false, 19, 9);
        test.executeGame(false, 20, 8);
        test.executeGame(false, 21, 7);
        test.executeGame(false, 22, 6);
        test.executeGame(false, 23, 5);
        test.executeGame(false, 24, 4);
        test.executeGame(false, 25, 3);
        test.executeGame(false, 26, 2);
        test.executeGame(false, 27, 1);
        test.executeGame(false, 28, 31);
        test.executeGame(false, 29, 30);
    }
    private void Game69()
    {
        
        
        
        test.executeGame(false, 27, 31);
        test.executeGame(false, 26, 28);
        test.executeGame(false, 25, 29);
        test.executeGame(false, 24, 30);
        test.executeGame(false, 23, 16);
        test.executeGame(false, 22, 17);
        test.executeGame(false, 21, 18);
        test.executeGame(false, 20, 19);
        test.executeGame(false, 4, 0);
        test.executeGame(false, 5, 3);
        test.executeGame(false, 6, 2);
        test.executeGame(false, 7, 1);
        test.executeGame(false, 8, 15);
        test.executeGame(false, 9, 14);
        test.executeGame(false, 10, 13);
        test.executeGame(false, 11, 12);
    }
    private void Game70()
    {
        
        
        
        test.executeGame(false, 25, 31);
        test.executeGame(false, 24, 26);
        test.executeGame(false, 23, 27);
        test.executeGame(false, 22, 28);
        test.executeGame(false, 21, 29);
        test.executeGame(false, 20, 30);
        test.executeGame(false, 19, 16);
        test.executeGame(false, 18, 17);
        test.executeGame(false, 6, 0);
        test.executeGame(false, 7, 5);
        test.executeGame(false, 8, 4);
        test.executeGame(false, 9, 3);
        test.executeGame(false, 10, 2);
        test.executeGame(false, 11, 1);
        test.executeGame(false, 12, 15);
        test.executeGame(false, 13, 14);
    }
    private void Game71()
    {
        
        
        
        test.executeGame(false, 31, 16);
        test.executeGame(false, 30, 17);
        test.executeGame(false, 29, 18);
        test.executeGame(false, 28, 19);
        test.executeGame(false, 27, 20);
        test.executeGame(false, 26, 21);
        test.executeGame(false, 25, 22);
        test.executeGame(false, 24, 23);
        test.executeGame(false, 0, 15);
        test.executeGame(false, 1, 14);
        test.executeGame(false, 2, 13);
        test.executeGame(false, 3, 12);
        test.executeGame(false, 4, 11);
        test.executeGame(false, 5, 10);
        test.executeGame(false, 6, 9);
        test.executeGame(false, 7, 8);
    }
    private void Game72()
    {
        
        
        
        test.executeGame(false, 31, 0);
        test.executeGame(false, 30, 1);
        test.executeGame(false, 29, 2);
        test.executeGame(false, 28, 3);
        test.executeGame(false, 27, 4);
        test.executeGame(false, 26, 5);
        test.executeGame(false, 25, 6);
        test.executeGame(false, 24, 7);
        test.executeGame(false, 23, 8);
        test.executeGame(false, 22, 9);
        test.executeGame(false, 21, 10);
        test.executeGame(false, 20, 11);
        test.executeGame(false, 19, 12);
        test.executeGame(false, 18, 13);
        test.executeGame(false, 17, 14);
        test.executeGame(false, 16, 15);
    }
    private void Game73()
    {
        
        
        
        test.executeGame(false, 4, 0);
        test.executeGame(false, 5, 3);
        test.executeGame(false, 6, 2);
        test.executeGame(false, 7, 1);
        test.executeGame(false, 8, 31);
        test.executeGame(false, 9, 30);
        test.executeGame(false, 10, 29);
        test.executeGame(false, 11, 28);
        test.executeGame(false, 12, 27);
        test.executeGame(false, 13, 26);
        test.executeGame(false, 14, 25);
        test.executeGame(false, 15, 24);
        test.executeGame(false, 16, 23);
        test.executeGame(false, 17, 22);
        test.executeGame(false, 18, 21);
        test.executeGame(false, 19, 20);
    }
    private void Game74()
    {
        
        
        
        test.executeGame(false, 0, 2);
        test.executeGame(false, 1, 3);
        test.executeGame(false, 31, 4);
        test.executeGame(false, 30, 5);
        test.executeGame(false, 29, 6);
        test.executeGame(false, 28, 7);
        test.executeGame(false, 27, 8);
        test.executeGame(false, 26, 9);
        test.executeGame(false, 25, 10);
        test.executeGame(false, 24, 11);
        test.executeGame(false, 23, 12);
        test.executeGame(false, 22, 13);
        test.executeGame(false, 21, 14);
        test.executeGame(false, 20, 15);
        test.executeGame(false, 19, 16);
        test.executeGame(false, 18, 17);
    }
    private void Game75()
    {
        
        
        
        test.executeGame(false, 11, 0);
        test.executeGame(false, 10, 12);
        test.executeGame(false, 9, 13);
        test.executeGame(false, 8, 14);
        test.executeGame(false, 7, 15);
        test.executeGame(false, 6, 16);
        test.executeGame(false, 5, 17);
        test.executeGame(false, 4, 18);
        test.executeGame(false, 3, 19);
        test.executeGame(false, 2, 20);
        test.executeGame(false, 1, 21);
        test.executeGame(false, 31, 22);
        test.executeGame(false, 30, 23);
        test.executeGame(false, 29, 24);
        test.executeGame(false, 28, 25);
        test.executeGame(false, 27, 26);
    }
    private void Game76()
    {
        
        
        
        test.executeGame(false, 9, 0);
        test.executeGame(false, 8, 10);
        test.executeGame(false, 7, 11);
        test.executeGame(false, 6, 12);
        test.executeGame(false, 5, 13);
        test.executeGame(false, 4, 14);
        test.executeGame(false, 3, 15);
        test.executeGame(false, 2, 16);
        test.executeGame(false, 1, 17);
        test.executeGame(false, 31, 18);
        test.executeGame(false, 30, 19);
        test.executeGame(false, 29, 20);
        test.executeGame(false, 28, 21);
        test.executeGame(false, 27, 22);
        test.executeGame(false, 26, 23);
        test.executeGame(false, 25, 24);
    }
    private void Game77()
    {
        
        
        
        test.executeGame(false, 24, 0);
        test.executeGame(false, 25, 23);
        test.executeGame(false, 26, 22);
        test.executeGame(false, 27, 21);
        test.executeGame(false, 28, 20);
        test.executeGame(false, 29, 19);
        test.executeGame(false, 30, 18);
        test.executeGame(false, 31, 17);
        test.executeGame(false, 1, 16);
        test.executeGame(false, 2, 15);
        test.executeGame(false, 3, 14);
        test.executeGame(false, 4, 13);
        test.executeGame(false, 5, 12);
        test.executeGame(false, 6, 11);
        test.executeGame(false, 7, 10);
        test.executeGame(false, 8, 9);
    }
    private void Game78()
    {
        
        
        
        test.executeGame(false, 28, 0);
        test.executeGame(false, 29, 27);
        test.executeGame(false, 30, 26);
        test.executeGame(false, 31, 25);
        test.executeGame(false, 1, 24);
        test.executeGame(false, 2, 23);
        test.executeGame(false, 3, 22);
        test.executeGame(false, 4, 21);
        test.executeGame(false, 5, 20);
        test.executeGame(false, 6, 19);
        test.executeGame(false, 7, 18);
        test.executeGame(false, 8, 17);
        test.executeGame(false, 9, 16);
        test.executeGame(false, 10, 15);
        test.executeGame(false, 11, 14);
        test.executeGame(false, 12, 13);
    }
    private void Game79()
    {
        
        
        
        test.executeGame(false, 23, 31);
        test.executeGame(false, 22, 24);
        test.executeGame(false, 21, 25);
        test.executeGame(false, 20, 26);
        test.executeGame(false, 19, 27);
        test.executeGame(false, 18, 28);
        test.executeGame(false, 17, 29);
        test.executeGame(false, 16, 30);
        test.executeGame(false, 8, 0);
        test.executeGame(false, 9, 7);
        test.executeGame(false, 10, 6);
        test.executeGame(false, 11, 5);
        test.executeGame(false, 12, 4);
        test.executeGame(false, 13, 3);
        test.executeGame(false, 14, 2);
        test.executeGame(false, 15, 1);
    }
    private void Game80()
    {
        
        
        
        test.executeGame(false, 0, 19);
        test.executeGame(false, 20, 18);
        test.executeGame(false, 21, 17);
        test.executeGame(false, 22, 16);
        test.executeGame(false, 23, 15);
        test.executeGame(false, 24, 14);
        test.executeGame(false, 25, 13);
        test.executeGame(false, 26, 12);
        test.executeGame(false, 27, 11);
        test.executeGame(false, 28, 10);
        test.executeGame(false, 29, 9);
        test.executeGame(false, 30, 8);
        test.executeGame(false, 31, 7);
        test.executeGame(false, 1, 6);
        test.executeGame(false, 2, 5);
        test.executeGame(false, 3, 4);
    }
    private void Game81()
    {
        
        
        
        test.executeGame(false, 26, 0);
        test.executeGame(false, 27, 25);
        test.executeGame(false, 28, 24);
        test.executeGame(false, 29, 23);
        test.executeGame(false, 30, 22);
        test.executeGame(false, 31, 21);
        test.executeGame(false, 1, 20);
        test.executeGame(false, 2, 19);
        test.executeGame(false, 3, 18);
        test.executeGame(false, 4, 17);
        test.executeGame(false, 5, 16);
        test.executeGame(false, 6, 15);
        test.executeGame(false, 7, 14);
        test.executeGame(false, 8, 13);
        test.executeGame(false, 9, 12);
        test.executeGame(false, 10, 11);
    }
    private void Game82()
    {
        
        
        
        test.executeGame(false, 0, 5);
        test.executeGame(false, 6, 4);
        test.executeGame(false, 7, 3);
        test.executeGame(false, 1, 2);
        test.executeGame(false, 8, 13);
        test.executeGame(false, 14, 12);
        test.executeGame(false, 15, 11);
        test.executeGame(false, 9, 10);
        test.executeGame(false, 31, 26);
        test.executeGame(false, 25, 27);
        test.executeGame(false, 24, 28);
        test.executeGame(false, 30, 29);
        test.executeGame(false, 23, 18);
        test.executeGame(false, 17, 19);
        test.executeGame(false, 16, 20);
        test.executeGame(false, 22, 21);
    }
    private void Game83()
    {
        
        
        
        test.executeGame(false, 0, 18);
        test.executeGame(false, 17, 19);
        test.executeGame(false, 16, 20);
        test.executeGame(false, 15, 21);
        test.executeGame(false, 14, 22);
        test.executeGame(false, 13, 23);
        test.executeGame(false, 12, 24);
        test.executeGame(false, 11, 25);
        test.executeGame(false, 10, 26);
        test.executeGame(false, 9, 27);
        test.executeGame(false, 8, 28);
        test.executeGame(false, 7, 29);
        test.executeGame(false, 6, 30);
        test.executeGame(false, 5, 31);
        test.executeGame(false, 4, 1);
        test.executeGame(false, 3, 2);
    }
    private void Game84()
    {
        
        
        
        test.executeGame(false, 0, 26);
        test.executeGame(false, 25, 27);
        test.executeGame(false, 24, 28);
        test.executeGame(false, 23, 29);
        test.executeGame(false, 22, 30);
        test.executeGame(false, 21, 31);
        test.executeGame(false, 20, 1);
        test.executeGame(false, 19, 2);
        test.executeGame(false, 18, 3);
        test.executeGame(false, 17, 4);
        test.executeGame(false, 16, 5);
        test.executeGame(false, 15, 6);
        test.executeGame(false, 14, 7);
        test.executeGame(false, 13, 8);
        test.executeGame(false, 12, 9);
        test.executeGame(false, 11, 10);

    }
}