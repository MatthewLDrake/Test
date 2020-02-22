using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    class PlayerGenerator
    {
        private static int[][] probabilites = new int[][] { new int[] { 25, 5, 15, 15, 30, 15, 5, 2 }, new int[] { 25, 10, 15, 15, 20, 15, 10, 5 }, new int[] { 20, 10, 15, 15, 15, 15, 10, 5 }, new int[] { 15, 25, 20, 20, 5, 15, 15, 15 }, new int[] { 20, 20, 15, 15, 5, 25, 10, 15 }, new int[] { 10, 20, 15, 15, 10, 15, 35, 20 } };
        public static player GeneratePlayer(int pos, Country country, int overall, int age, int development, int peakStart, int peakEnd, FormulaBasketball.Random r)
        {
            NameGenerator gen = NameGenerator.Instance();
            String name = gen.GenerateName(country);
            overall += 5;
            int[] ratings = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, r.Next(5, 10), r.Next(1, 10) };

            double currentOverall = player.getOverall(pos, ratings);
            int[] selectedProbability;
            if (pos < 3 || (pos == 3 && r.NextBool()))
            {
                selectedProbability = probabilites[pos - 1];
            }
            else
            {
                selectedProbability = probabilites[pos];
            }
            int sum = 0;
            foreach (int num in selectedProbability)
            {
                sum += num;
            }

            int selected = r.Next(sum);
            int currSum = 0;
            int i;
            while (currentOverall < overall)
            {
                selected = r.Next(sum);
                currSum = 0;
                for (i = 0; i < selectedProbability.Length - 1; i++)
                {
                    if (selected < selectedProbability[i] + currSum)
                    {
                        break;
                    }
                    currSum += selectedProbability[i];
                }
                if (ratings[i] == 10) continue;
                ratings[i]++;
                currentOverall = player.getOverall(pos, ratings);
            }
            selected = r.Next(sum);
            currSum = 0;
            for (i = 0; i < selectedProbability.Length - 1; i++)
            {
                if (selected < selectedProbability[i] + currSum)
                {
                    break;
                }
                currSum += selectedProbability[i];
            }
            if (ratings[i] != 10)
                ratings[i]++;
            return new player(pos, ratings, age, name, country, development, peakStart, peakEnd, r);

        }
    }
}
