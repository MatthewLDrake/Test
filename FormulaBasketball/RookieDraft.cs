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
        public RookieDraft(List<player> rookies, List<team> teams, List<int> humans, Random r)
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
            }
            for (int i = 0; i < rookiesByPos.Length; i++)
            {
                rookiesByPos[i].Sort();
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
        public player[] BestPlayers()
        {
            return new player[] { rookiesByPos[0][0], rookiesByPos[1][0], rookiesByPos[2][0], rookiesByPos[3][0], rookiesByPos[4][0] };
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
