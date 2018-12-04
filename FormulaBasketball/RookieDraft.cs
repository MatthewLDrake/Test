using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FormulaBasketball
{
    class RookieDraft
    {
        private List<player>[] rookiesByPos;
        private List<team> teams;
        private List<int> humans;
        private Random r;
        private DraftPick[] draftPicks;
        public RookieDraft(List<CollegePlayer> rookies, List<team> teams, List<int> humans, Random r)
        {
            // TODO: Complete member initialization
            this.rookiesByPos = new List<player>[5];
            for(int i = 0; i < rookiesByPos.Length; i++)
            {
                rookiesByPos[i] = new List<player>();
            }
            this.teams = teams;
            this.humans = humans;
            this.r = r;

            foreach(player p in rookies)
            {
                rookiesByPos[p.getPosition() - 1].Add(p);
                p.IsRookie();
            }
            for (int i = 0; i < rookiesByPos.Length; i++)
            {
                rookiesByPos[i] = Sort(rookiesByPos[i]);
                Console.WriteLine("Position " + (i + 1));
                foreach(player p in rookiesByPos[i])
                {
                    Console.WriteLine(p.getOverall());
                }
            }
            draftPicks = new DraftPick[64];

            foreach(team team in teams)
            {
                List<DraftPick> picks = team.GetPicks();
                foreach(DraftPick pick in picks)
                {
                    draftPicks[pick.GetPickNumber() - 1] = pick;
                }
            }

            if(humans.Count == 0)
            {
                for (int i = 0; i < draftPicks.Length; i++ )
                {
                    ExecutePick(draftPicks[i]);
                }
                PrintPicks();
            }
            


        }
        public List<player> GetUndraftedPlayers()
        {
            List<player> undraftedPlayers = new List<player>();
            for (int i = 0; i < rookiesByPos.Length; i++ )
                foreach (player p in rookiesByPos[i])
                {
                    undraftedPlayers.Add(p);
                }
            return undraftedPlayers;
        }
        private List<player> Sort(List<player> list)
        {
            player temp = null;
            for (int write = 0; write < list.Count; write++)
            {
                for (int sort = 0; sort < list.Count - 1; sort++)
                {
                    if (list[sort].getOverall() < list[sort + 1].getOverall())
                    {
                        temp = list[sort + 1];
                        list[sort + 1] = list[sort];
                        list[sort] = temp;
                    }
                }
            }
            return list;
        }
        public player[] BestPlayers()
        {
            player[] bestPlayers = new player[5];
            for(int i = 0; i < 5; i ++)
            {
                if (rookiesByPos[i].Count > 0) bestPlayers[i] = rookiesByPos[i][0];
                else bestPlayers[i] = new player(i, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Test", false);
            }
            return bestPlayers;
        }
        public void ExecutePick(DraftPick pick)
        {
            int position = 0;
            position = pick.GetOwner().GetPositionToDraft(BestPlayers());
            pick.SelectPlayer(rookiesByPos[position][0]);
            rookiesByPos[position].RemoveAt(0);
        }

        public void PrintPicks()
        {
            String data = "";
            foreach(DraftPick pick in draftPicks)
            {

                data += pick.GetPickNumber() + ". " + pick.GetOwner() + " ";
                if(pick.DifferentOwner())
                {
                    data += "(from " + pick.GetTeamOfOrigin() + ") ";
                }
                data += pick.GetPlayerSelected().GetPositionAsString() + " " + pick.GetPlayerSelected().getName() + "\n";
            }
            File.WriteAllText("picks.txt", data);
        }

    }
}
