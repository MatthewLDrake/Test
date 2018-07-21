using FormulaBasketball;
using System;
using System.Collections.Generic;

public class listInfo
{
    private bool isHuman;

    private String teamNames;
    private team team;
    private FormulaBasketball.Random r;
    public listInfo(team team, bool isHuman, FormulaBasketball.Random r)
    {
        this.r = r;
        //this.teamNeeds = teamNeeds;
        this.teamName = team.ToString();
        human = isHuman;
        this.team = team;
    }

    public String teamName
    {        
        get
        {
            return teamNames;
        }
        set
        {
            teamNames = value;
        }
    }
   

    public bool human
    {
        get
        {
            return isHuman;
        }
        set
        {
            isHuman = value;
        }
    }
    
    public void addPlayer(draftPlayer player)
    {
        team.addPlayer(player.player);

    }
    public team getTeam()
    {
        return team;
    }

    public int getNextPositionToDraft()
    {
        int[] pos = new int[5];
        pos[0] = team.getCenters();
        pos[1] = team.getPowerForwards();
        pos[2] = team.getSmallForwards();
        pos[3] = team.getShootingGuards();
        pos[4] = team.getPointGuards();

        List<int> list = new List<int>();

        int min = pos[0];
        for(int i = 1; i < pos.Length; i++)
        {
            if(pos[i] < min)
            {
                min = pos[i];
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (pos[i] == min)
            {
                list.Add(i + 1);
            }
        }

        return list[r.Next(0, list.Count)];



    }
}
