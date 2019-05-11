using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Scout
{
    private int skill, num;
    private String name;
    public Scout(String name, int skill, int num)
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
}

