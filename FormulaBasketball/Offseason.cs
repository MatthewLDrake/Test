using FormulaBasketball;
using System;
using System.Collections.Generic;

public class Offseason
{
    private List<team> teams;
    private List<player> freeAgency;
    private FormulaBasketball.Random r;
    private List<player> rookies;
    public Offseason(List<team> teams, List<player> freeAgency, List<player> rookies, FormulaBasketball.Random r)
    {
        this.rookies = rookies;
        this.teams = teams;
        this.freeAgency = freeAgency;
        this.r = r;
        runOffseason();

    }
    private void runOffseason()
    {
        
        checkRetirements();
        EndSeasons();
        resignPlayers();
        ExecuteDrafts();
        signFreeAgents();
        
    }
    private void EndSeasons()
    {
        foreach(team team in teams)
        {
            team.endSeason();
            //team.GetAffiliate().endSeason();
            foreach(player p in team)
            {
                p.endSeason();
            }
        }
    }
    private void checkRetirements()
    {
        List<player> retiredPlayers = new List<player>();
        foreach (team team in teams)
        {
            for (int i = 0; i < team.getNumberPlayers(); i++)
            {
                if (team.getPlayer(i).retire(r) != retirements.None)
                {
                    retiredPlayers.Add(team.getPlayer(i));
                    team.addRetiredPlayer(team.getPlayer(i));
                }
                
            }
            team.removeRetiredPlayers();
        }
        List<player> tempFreeAgency = new List<player>();
        foreach (player player in freeAgency)
        {
            bool retireStatus = player.retire(r, true) != retirements.None;
            if(!retireStatus)
            {
                tempFreeAgency.Add(player);
            }
            else
            {
                retiredPlayers.Add(player);
            }
        }
        freeAgency = tempFreeAgency;

        displayPlayers display = new displayPlayers();
        display.setPlayers(retiredPlayers);
        display.ShowDialog();
    }
    private void resignPlayers()
    {
        foreach(team team in teams)
        {
            List<player> releasedPlayers = team.resignPlayers(r);
            foreach(player player in releasedPlayers)
            {
                freeAgency.Add(player);
            }
        }
    }
    private void ExecuteDrafts()
    {
        RookieDraft draft = new RookieDraft(rookies, teams, new List<int>(), r);
    }
    private void signFreeAgents()
    {
        foreach(team team in teams)
        {
            team.offerToFreeAgents(freeAgency, r);
        }
    }
}