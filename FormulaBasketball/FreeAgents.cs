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
    public void Add(IEnumerable<player> newPlayers)
    {
        foreach (player player in newPlayers)
        {
            Add(player);
        }
    }
    public void Fix()
    {
        foreach (player p in allPlayers)
            p.setTeam(null);
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
        if (player == null)
            return;
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
    public void Remove(String name, double overall)
    {
        Remove(GetPlayer(name, overall));
    }
    public bool HasPlayer(String name, double overall)
    {
        return GetPlayer(name, overall) != null;
    }
    private player GetPlayer(String name, double overall)
    {
        foreach (player p in allPlayers)
        {
            if (p.getName().Equals(name) && p.getOverall() == overall) return p;
        }
        return null;
    }
    public void GeneratePlayers(FormulaBasketball.Random r)
    {
        CollegePlayerGen playerGen = new CollegePlayerGen(r);
        for (int i = 0; i < 47; i++ )
        {
            Country country;
            int randForCountry = r.Next(100);
            if (randForCountry < 5)
                country = Country.Aeridani;
            else if (randForCountry < 10)
                country = Country.Tri_National_Dominion;
            else if (randForCountry < 23)
                country = Country.Auspikitan;
            else if (randForCountry < 28)
                country = Country.Bielosia;
            else if (randForCountry < 30)
                country = Country.Blaist_Blaland;
            else if (randForCountry < 33)
                country = Country.Bongatar;
            else if (randForCountry < 35)
                country = Country.Czalliso;
            else if (randForCountry < 38)
                country = Country.Darvincia;
            else if (randForCountry < 43)
                country = Country.Pyxanovia;
            else if (randForCountry < 50)
                country = Country.Wyverncliff;
            else if (randForCountry < 68)
                country = Country.Ethanthova;
            else if (randForCountry < 90)
                country = Country.Dotruga;
            else if (randForCountry < 95)
                country = Country.Solea;
            else
                country = Country.Sagua;

            int peakStart = r.Next(26, 30);
            Add(playerGen.GenerateCenter(r.Next(30, 60), country, r.Next(3, 7), peakStart, peakStart + r.Next(1, 4), true, r.Next(1, 10), 0));
        }
        for (int i = 0; i < 34; i++)
        {
            Country country;
            int randForCountry = r.Next(100);
            if (randForCountry < 5)
                country = Country.Aeridani;
            else if (randForCountry < 10)
                country = Country.Tri_National_Dominion;
            else if (randForCountry < 23)
                country = Country.Auspikitan;
            else if (randForCountry < 28)
                country = Country.Bielosia;
            else if (randForCountry < 30)
                country = Country.Blaist_Blaland;
            else if (randForCountry < 33)
                country = Country.Bongatar;
            else if (randForCountry < 35)
                country = Country.Czalliso;
            else if (randForCountry < 38)
                country = Country.Darvincia;
            else if (randForCountry < 43)
                country = Country.Pyxanovia;
            else if (randForCountry < 50)
                country = Country.Wyverncliff;
            else if (randForCountry < 68)
                country = Country.Ethanthova;
            else if (randForCountry < 90)
                country = Country.Dotruga;
            else if (randForCountry < 95)
                country = Country.Solea;
            else
                country = Country.Sagua;

            int peakStart = r.Next(26, 30);
            Add(playerGen.GeneratePowerForward(r.Next(30, 60), country, r.Next(3, 7), peakStart, peakStart + r.Next(1, 4), true, r.Next(1, 10), 0));
        }
        for (int i = 0; i < 27; i++)
        {
            Country country;
            int randForCountry = r.Next(100);
            if (randForCountry < 5)
                country = Country.Aeridani;
            else if (randForCountry < 10)
                country = Country.Tri_National_Dominion;
            else if (randForCountry < 23)
                country = Country.Auspikitan;
            else if (randForCountry < 28)
                country = Country.Bielosia;
            else if (randForCountry < 30)
                country = Country.Blaist_Blaland;
            else if (randForCountry < 33)
                country = Country.Bongatar;
            else if (randForCountry < 35)
                country = Country.Czalliso;
            else if (randForCountry < 38)
                country = Country.Darvincia;
            else if (randForCountry < 43)
                country = Country.Pyxanovia;
            else if (randForCountry < 50)
                country = Country.Wyverncliff;
            else if (randForCountry < 68)
                country = Country.Ethanthova;
            else if (randForCountry < 90)
                country = Country.Dotruga;
            else if (randForCountry < 95)
                country = Country.Solea;
            else
                country = Country.Sagua;

            int peakStart = r.Next(26, 30);
            Add(playerGen.GenerateSmallForward(r.Next(30, 60), country, r.Next(3, 7), peakStart, peakStart + r.Next(1, 4), true, r.Next(1, 10), 0));
        }
        for (int i = 0; i < 36; i++)
        {
            Country country;
            int randForCountry = r.Next(100);
            if (randForCountry < 5)
                country = Country.Aeridani;
            else if (randForCountry < 10)
                country = Country.Tri_National_Dominion;
            else if (randForCountry < 23)
                country = Country.Auspikitan;
            else if (randForCountry < 28)
                country = Country.Bielosia;
            else if (randForCountry < 30)
                country = Country.Blaist_Blaland;
            else if (randForCountry < 33)
                country = Country.Bongatar;
            else if (randForCountry < 35)
                country = Country.Czalliso;
            else if (randForCountry < 38)
                country = Country.Darvincia;
            else if (randForCountry < 43)
                country = Country.Pyxanovia;
            else if (randForCountry < 50)
                country = Country.Wyverncliff;
            else if (randForCountry < 68)
                country = Country.Ethanthova;
            else if (randForCountry < 90)
                country = Country.Dotruga;
            else if (randForCountry < 95)
                country = Country.Solea;
            else
                country = Country.Sagua;

            int peakStart = r.Next(26, 30);
            Add(playerGen.GenerateShootingGuard(r.Next(30, 60), country, r.Next(3, 7), peakStart, peakStart + r.Next(1, 4), true, r.Next(1, 10), 0));
        }
        for (int i = 0; i < 27; i++)
        {
            Country country;
            int randForCountry = r.Next(100);
            if (randForCountry < 5)
                country = Country.Aeridani;
            else if (randForCountry < 10)
                country = Country.Tri_National_Dominion;
            else if (randForCountry < 23)
                country = Country.Auspikitan;
            else if (randForCountry < 28)
                country = Country.Bielosia;
            else if (randForCountry < 30)
                country = Country.Blaist_Blaland;
            else if (randForCountry < 33)
                country = Country.Bongatar;
            else if (randForCountry < 35)
                country = Country.Czalliso;
            else if (randForCountry < 38)
                country = Country.Darvincia;
            else if (randForCountry < 43)
                country = Country.Pyxanovia;
            else if (randForCountry < 50)
                country = Country.Wyverncliff;
            else if (randForCountry < 68)
                country = Country.Ethanthova;
            else if (randForCountry < 90)
                country = Country.Dotruga;
            else if (randForCountry < 95)
                country = Country.Solea;
            else
                country = Country.Sagua;

            int peakStart = r.Next(26, 30);
            Add(playerGen.GeneratePointGuard(r.Next(30, 60), country, r.Next(3, 7), peakStart, peakStart + r.Next(1, 4), true, r.Next(1, 10), 0));
        }
    }
    public List<player> GetAllPlayers()
    {
        return allPlayers;
    }
}


