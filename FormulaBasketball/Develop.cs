using System;

namespace FormulaBasketball
{
    public class Develop
    {
        public static void DevelopPlayer(NewPlayer p, NewRealCoach coach = null)
        {
            double targetOverall = p.GetMainOverall();
            int totalDev = p.GetDevelopment() + (coach != null ? coach.GetDevelopmentSkillForPosition(p.GetPosition()) : 0);

            int age = Math.Min(10, p.GetPeakStart() - p.GetAge());

            bool goDown = false;

            if (p.GetAge() > p.GetPeakEnd())
            {
                goDown = true;
                age = p.GetPeakEnd() - p.GetAge();

                targetOverall -= 0.92 - (totalDev - 1) * 0.03 + .3 * (Math.Abs(age) - 1);

            }
            else
            {
                double increase;
                if(p.GetPlayerID() < 1283)
                    increase = ( 2 * totalDev / 3 + (League.r.NextDouble() - .5)) * age / 10;
                else
                    increase = (totalDev * 1.4 + (League.r.NextDouble() - .5)) * age / 10;

                if (p.GetPlayerID() == 223)
                {
                    increase += 3;
                    new NewPlayerEditor(p).ShowDialog();
                }
                if (increase > 1)
                    Console.WriteLine(p + ": " + increase);
                targetOverall += increase;
            }

            byte[] maxRatings = new byte[11];

            if(coach != null)
            {
                for (int i = 0; i < maxRatings.Length - 1; i++)
                    maxRatings[i] = coach.GetMaxRatingBoosts(i);
            }
            bool showDialog = age > 0 && p.GetMaxOverall() <= p.GetMainOverall() && p.GetMaxOverall() < 75 && p.GetMainOverall() <= 83;

            //if(showDialog)
            //{
                p.FixMaxRatings();
            //}

            NewPlayerEditor editor = new NewPlayerEditor(p, targetOverall, goDown, maxRatings);
           
                //editor.ShowDialog();
        }
    }
}