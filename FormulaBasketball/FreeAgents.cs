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
    public void UpdateOffers(List<Dictionary<int, Contract>> listOffers, List<team> teams)
    {
        if (listOffers == null || listOffers.Count < 1) return;
        foreach (player p in allPlayers)
        {
            foreach(team t in teams)
            if (p.HasOfferFromTeam(t))
            {
                p.RemoveFreeAgentOffer(t);
            }
        }
        for (int i = 0; i < listOffers.Count; i++)
        {
            if (listOffers[i] == null || listOffers[i].Count < 1)
                continue;
            foreach (KeyValuePair<int, Contract> offer in listOffers[i])
            {
                GetPlayerByID(offer.Key).OfferFreeAgentContract(offer.Value, teams[i]);
            }
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


