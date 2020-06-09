using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class NewFormulaBasketball
    {
        public static League league;
        private static Random r;
        public NewFormulaBasketball(createTeams create)
        {
            league = new League();
            r = new Random();

            foreach(team t in create.getTeams())
            {
                league.AddTeam(new NewTeam(t), new NewTeam(t.GetAffiliate()));
            }
            foreach(NewTeam t in league)
            {
                foreach(NewPlayer p in t)
                {
                    Dictionary<ResultType, int> dict = new Dictionary<ResultType,int>();
                    for (int i = 0; i < 1000; i++)
                    {
                        ShotResult result = NewShots.TakeShot(ShotType.THREE, false, r, p, p, r.Next(100));
                        if(dict.ContainsKey(result.Type))
                        {
                            dict[result.Type] += 1;
                        }
                        else
                        {
                            dict.Add(result.Type, 1);
                        }
                        //made += NewShots.TakeFreeThrow(1, false, r, p).Type == ResultType.MAKE_ONE_FREETHROW ? 1 : 0;
                    }
                   
                    Console.WriteLine(p + " - " + p.GetThreePointRating(true, false) + " vs " + p.GetShotContestRating(true, false));
                    foreach (KeyValuePair<ResultType, int> pair in dict)
                    {
                        Console.WriteLine(pair.Key + ": " + pair.Value);
                    }
                }
            }
        }
    }
}
