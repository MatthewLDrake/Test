using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    [Serializable]
    public class TempoHolder
    {
        public int randTime, minimumTime;
        public TempoHolder(int randTime, int minimumTime)
        {
            this.randTime = randTime;
            this.minimumTime = minimumTime;
        }
        public int getRandomTime()
        {
            return randTime;
        }
        public int getMinimumTime()
        {
            return minimumTime;
        }
    }
}
