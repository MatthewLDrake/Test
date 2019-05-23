using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormulaBasketball;
[Serializable]
public class FreeAgents
{
    private List<player> allPlayers;
    private List<player>[] playersByPos;
    public FreeAgents()
    {
        playersByPos = new List<player>[5];
        for (int i = 0; i < playersByPos.Length; i++)
        {
            playersByPos[i] = new List<player>();
        }
        allPlayers = new List<player>();
    }
    public void Add(List<player> newPlayers)
    {
        foreach (player player in newPlayers)
        {
            Add(player);
        }
    }
    public void UpdateOffers(List<FreeAgentOffers> offers, createTeams create)
    {
        if (offers.Count < 1) return;
        team t = create.getTeam(offers[0].teamID);
        foreach (player p in allPlayers)
        {
            if (p.HasOfferFromTeam(t))
            {
                p.RemoveFreeAgentOffer(t);
            }
        }
        foreach (FreeAgentOffers offer in offers)
        {
            GetPlayerByID(offer.playerID).OfferFreeAgentContract(offer.offer, t);
        }
    }
    public void Add(player player)
    {
        if (allPlayers.Contains(player)) return;
        AddToList(player, allPlayers);
        AddToList(player, playersByPos[player.getPosition() - 1]);
    }
    private void AddToList(player player, List<player> list)
    {
        int i = 0;
        while (i != list.Count)
        {
            if (player.CompareTo(list[i]) > 0) break;
            i++;
        }
        list.Insert(i, player);
    }
    public void AdvanceSeason()
    {
        foreach (player p in allPlayers)
        {
            p.endSeason();
        }
    }
    public List<player> GetPlayersByPos(int pos)
    {
        return playersByPos[pos - 1];
    }
    public player GetTopPlayerByPos(int pos)
    {
        player retVal = null;
        while (true)
        {
            retVal = playersByPos[pos - 1][0];
            if (retVal.getPosition() != pos)
            {
                playersByPos[pos - 1].RemoveAt(0);
                Remove(retVal);
                Add(retVal);
            }
            else break;
        }

        Remove(retVal);
        return retVal;
    }
    public player GetPlayerByID(int playerID)
    {
        foreach (player p in allPlayers)
        {
            if (p.GetPlayerID() == playerID) return p;
        }
        return null;
    }
    public void Remove(player player)
    {
        if (allPlayers.Contains(player))
        {
            allPlayers.Remove(player);
            for (int i = 0; i < playersByPos.Length; i++)
            {
                playersByPos[i].Remove(player);
            }
        }
    }
    public void Remove(List<player> players)
    {
        foreach (player player in players)
        {
            Remove(player);
        }
    }
    public List<player> GetAllPlayers()
    {
        return allPlayers;
    }
}


