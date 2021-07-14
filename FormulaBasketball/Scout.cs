using System;
using System.Collections.Generic;
namespace FormulaBasketball
{
    [Serializable]
    public class Scout
    {
        private int skill, num;
        private string name;
        public Scout(string name, int skill, int num)
        {
            this.skill = skill;
            this.num = num;
            this.name = name;
        }
        

        public int GetNumPlayers()
        {
            return num;
        }
        public int GetScoutSkill()
        {
            return skill;
        }
        public override string ToString()
        {
            return name;
        }
    }

}