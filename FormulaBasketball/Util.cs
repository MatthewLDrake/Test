using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class Util
    {
        public static double[] GetLineGivenPoints(double x1, double y1, double x2, double y2)
        {
            double slope = (y2 - y1) / (x2 - x1);
            double yIntercept = y1 - (x1 * slope);
            return new double[] { slope, yIntercept };
        }
    }
}
