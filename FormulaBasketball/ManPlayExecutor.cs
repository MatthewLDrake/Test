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
            return null;
        }
    }
    
}
