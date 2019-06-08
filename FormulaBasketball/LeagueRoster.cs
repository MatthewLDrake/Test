using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class LeagueRoster : Form
    {
        private RosterControl[] controls;
        private createTeams create;
        private List<int> humans;
        public LeagueRoster(List<int> humans, createTeams create)
        {
            InitializeComponent();
            controls = new RosterControl[32];
            this.humans = humans;
            this.create = create;

            controls[0] = rosterControl1;
            controls[1] = rosterControl2;
            controls[2] = rosterControl3;
            controls[3] = rosterControl4;
            controls[4] = rosterControl5;
            controls[5] = rosterControl6;
            controls[6] = rosterControl7;
            controls[7] = rosterControl8;
            controls[8] = rosterControl9;
            controls[9] = rosterControl10;
            controls[10] = rosterControl11;
            controls[11] = rosterControl12;
            controls[12] = rosterControl13;
            controls[13] = rosterControl14;
            controls[14] = rosterControl15;
            controls[15] = rosterControl16;
            controls[16] = rosterControl17;
            controls[17] = rosterControl18;
            controls[18] = rosterControl19;
            controls[19] = rosterControl20;
            controls[20] = rosterControl21;
            controls[21] = rosterControl22;
            controls[22] = rosterControl23;
            controls[23] = rosterControl24;
            controls[24] = rosterControl25;
            controls[25] = rosterControl26;
            controls[26] = rosterControl27;
            controls[27] = rosterControl28;
            controls[28] = rosterControl29;
            controls[29] = rosterControl30;
            controls[30] = rosterControl31;
            controls[31] = rosterControl32;

        }
        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int pos = int.Parse((String)button.Tag);

            List<team> teams = new List<team>(create.getTeams());

            SortedList<double, team> list = new SortedList<double, team>(new DuplicateKeyComparer<double>());
            for(int i = 0; i < teams.Count; i++)
            {
                team team = teams[i];
                
                double highestOverall = 0;
                if (humans.Contains(i)) highestOverall = 100 + i;
                foreach(player p in team.GetOffSeasonPlayers())
                {
                    if(p.getPosition() == pos && p.getOverall() > highestOverall)
                    {
                        highestOverall = p.getOverall();
                    }
                }
                list.Add(highestOverall, team);
            }
            for(int i = 0; i < list.Count; i ++)
            {
                controls[i].SetControl(list.ElementAt(i).Value.GetOffSeasonPlayers(), pos, list.ElementAt(i).Value.ToString());
            }

        }
    }
}
/// <summary>
/// Comparer for comparing two keys, handling equality as beeing greater
/// Use this Comparer e.g. with SortedLists or SortedDictionaries, that don't allow duplicate keys
/// </summary>
/// <typeparam name="TKey"></typeparam>
public class DuplicateKeyComparer<TKey>
                :
             IComparer<TKey> where TKey : IComparable
{
    #region IComparer<TKey> Members

    public int Compare(TKey x, TKey y)
    {
        int result = x.CompareTo(y);

        if (result == 0)
            return 1;   // Handle equality as beeing greater
        else
            return result;
    }

    #endregion
}
