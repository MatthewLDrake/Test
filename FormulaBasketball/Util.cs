using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class Util
    {
        public static int ConvertLetterToNumber(string letterGrade)
        {
            switch(letterGrade)
            {
                case "A+":
                    return 10;
                case "A":
                    return 9;
                case "B+":
                    return 8;
                case "B":
                    return 7;
                case "C+":
                    return 6;
                case "C":
                    return 5;
                case "D+":
                    return 4;
                case "D":
                    return 3;
                case "F+":
                    return 2;
                case "F":
                    return 1;
            }
            return -1;
        }
        public static string ConvertNumberToLetter(int value)
        {
            switch (value)
            {
                case 1:
                    return "F";
                case 2:
                    return "F+";
                case 3:
                    return "D";
                case 4:
                    return "D+";
                case 5:
                    return "C";
                case 6:
                    return "C+";
                case 7:
                    return "B";
                case 8:
                    return "B+";
                case 9:
                    return "A";
                case 10:
                    return "A+";
            }
            return "";
        }
        public static double[] GetLineGivenPoints(double x1, double y1, double x2, double y2)
        {
            double slope = (y2 - y1) / (x2 - x1);
            double yIntercept = y1 - (x1 * slope);
            return new double[] { slope, yIntercept };
        }
    }
}
