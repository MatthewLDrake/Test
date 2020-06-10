using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class ManPlayExecutor : PlayExecutor
    {
        private bool switchMan, doubleUp;
        public ManPlayExecutor(int manType)
        {
            switchMan = manType == 1;
            doubleUp = manType == 2;
        }

        public override PlayResult RunPlay(OffensivePlay offensivePlay, NewCurrentTeam offense, NewCurrentTeam defense)
        {
            OffensivePlayerOnCourt[] currOffense = offensivePlay.GetPlayers(offense);
            DefensivePlayerOnCourt[] currDefense = new DefensivePlayerOnCourt[5];
            for (int i = 0; i < defense.GetCurrentPlayers().Length; i++ )
            {
                currDefense[i] = new DefensivePlayerOnCourt(defense.GetCurrentPlayers()[i], i + 1, currOffense[i].GetLocation(), 1);
            }
            bool playIsOver = false;
            while (!playIsOver)
            {
                offensivePlay.RunPlay(currOffense, currDefense, null);
            }

            return null;
        }
    }
    
}
