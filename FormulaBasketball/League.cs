using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    // equivalent to createTeams in old version
    public class League : IEnumerable<NewTeam>
    {
        private List<NewTeam> teams;
        public League()
        {
            teams = new List<NewTeam>();
        }
        public void AddTeam(NewTeam mainTeam, NewTeam affiliate)
        {
            teams.Add(mainTeam);
            // TODO: Handle affililate
        }
        


        public IEnumerator<NewTeam> GetEnumerator()
        {
            return new TeamEnumerator(teams);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
    public class TeamEnumerator : IEnumerator<NewTeam>
    {
        private List<NewTeam> teams;
        private int location = -1;
        public TeamEnumerator(List<NewTeam> teams)
        {
            this.teams = teams;
        }
        public NewTeam Current
        {
            get
            {
                try
                {

                    return teams[location];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current { get { return Current; } }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            location++;
            while (location < teams.Count && teams[location] == null) location++;
            return location < teams.Count;
        }

        public void Reset()
        {
            location = -1;
        }
    }
}
