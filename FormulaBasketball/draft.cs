﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class draft : Form
    {
        private Dictionary<int, player> players;
        private List<int> humanPlayers;
        private DraftPick[] picks;
        private int currentPick;
        private FormulaBasketball.Random r;
        private DataGridView[] grids;
        private List<player> mockDraft, drafted, undrafted;
        private createTeams create;
        public draft(List<player> collegePlayers, DraftPick[] picks, List<int> humanPlayers, FormulaBasketball.Random r, createTeams create)
        {
            InitializeComponent();
            grids = new DataGridView[5];
            grids[0] = centerLists;
            grids[1] = powerForwardGrid;
            grids[2] = smallForwardGrid;
            grids[3] = shootingGuardList;
            grids[4] = pointGuardList;

            this.create = create;
            this.r = r;

            this.humanPlayers = humanPlayers;

            drafted = new List<player>();

            Holder hol = Scouting.DeSerializeObject();

            players = new Dictionary<int, player>();
            foreach(player p in collegePlayers)
            {
                player temp = hol.GetPlayer(p.GetPlayerID());
                if (temp.scout)
                    grids[temp.getPosition() - 1].Rows.Add(new object[] { temp.getName(), temp.layupStr, temp.dunkStr, temp.jumpshotStr, temp.threepointStr, temp.passStr, temp.shotcontestStr, temp.defenseiqStr, temp.jumpingStr, temp.seperationStr, temp.durabilityStr, temp.staminaStr, temp.potential , "", temp.GetPlayerID()});
                else
                    grids[temp.getPosition() - 1].Rows.Add(new object[] { temp.getName(), "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "", temp.GetPlayerID() });
                players.Add(temp.GetPlayerID(), temp);
            }
            
            this.picks = picks;
            this.r = create.GetRandom();

            currentPick = 0;

           
            if(humanPlayers.Count == 0)
            {
                mockDraft = new List<player>();

                foreach(team t in create.getTeams())
                {
                    t.DraftStrategy = DraftStrategy.WIN_NOW;
                }

                while(currentPick < 64)
                {
                   
                    List<player> roster = picks[currentPick].GetOwner(create).GetMockRoster();
                    player selectedPlayer = PickPlayer(roster, picks[currentPick].GetOwner(create).DraftStrategy);
                    players.Remove(selectedPlayer.GetPlayerID());

                    picks[currentPick].GetOwner(create).AddMockedPlayer(selectedPlayer);
                    mockDraft.Add(selectedPlayer);


                    currentPick++;
                }
                foreach(team t in create.getTeams())
                {
                    if (t.ToString().Equals("Serkr Atolls"))
                    {
                        t.DraftStrategy = DraftStrategy.WIN_NOW;
                    }
                    else
                    {
                        if (t.GetDraftPlace() < 10) t.DraftStrategy = DraftStrategy.REBUILD;
                        else if (t.GetDraftPlace() < 20) t.DraftStrategy = DraftStrategy.WIN_SOON;
                        else t.DraftStrategy = DraftStrategy.WIN_NOW;
                    }
                }

                
            }


        }
        public List<player> GetMockedDraft()
        {
            return mockDraft;
        }
        
        private void AiPick()
        {
            // TODO: Implement new draft logic for AI
            List<player> roster = picks[currentPick].GetOwner(create).GetOffSeasonPlayers();
            player selectedPlayer = PickPlayer(roster, picks[currentPick].GetOwner(create).DraftStrategy);
            players.Remove(selectedPlayer.GetPlayerID());
            drafted.Add(selectedPlayer);
            picks[currentPick].GetOwner(create).OffSeasonAddPlayer(selectedPlayer);
            label3.Text = "Previous pick: " + selectedPlayer.GetPositionAsString() + " " + selectedPlayer.getName() + " by the " + picks[currentPick].GetOwner(create);
            bool flag = false;
            for(int i = 0; i < grids.Length; i++)
            {
                for(int j = 0; j < grids[i].Rows.Count; j++)
                {
                    if((int)grids[i].Rows[j].Cells[14].Value == selectedPlayer.GetPlayerID())
                    {
                        flag = true;
                        UpdateGrid(grids[i].Rows[j], selectedPlayer);
                        break;
                    }
                }
                if (flag) break;
            }
        }
        private player PickPlayer(List<player> roster, DraftStrategy strat)
        {
            List<player>[] players = new List<player>[5];
            for (int i = 0; i < players.Length; i++)
                players[i] = new List<player>();
            foreach (player p in roster)
            {
                if (p == null)
                    continue;
                players[p.getPosition() - 1].Add(p);
            }
            for (int i = 0; i < players.Length; i++)
                players[i] = Sort(players[i]);
            double[] topScores = new double[] { double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue };
            player[] topPlayers = new player[7];

            foreach (KeyValuePair<int, player> entry in this.players)
            {
                player p = entry.Value;
                double score = GetScore(players[p.getPosition() - 1], p, strat);

                if (score > topScores[p.getPosition() - 1] || (score == topScores[p.getPosition() - 1] && topPlayers[p.getPosition() - 1].GetPlayerID() > p.GetPlayerID()))
                {
                    topScores[p.getPosition() - 1] = score;
                    topPlayers[p.getPosition() - 1] = p;
                }
                else
                {
                    for(int i = 5; i < topScores.Length; i++)
                    {
                        if(score > topScores[i] || (score == topScores[i] && topPlayers[i].GetPlayerID() > p.GetPlayerID()))
                        {
                            topScores[i] = score;
                            topPlayers[i] = p;
                            break;
                        }
                    }
                }
            }
            List<player> finalPlayers = new List<player>();
            List<double> finalScores = new List<double>();
            while(finalPlayers.Count != topScores.Length)
            {
                int loc = 0;
                double topScore = Double.MinValue;
                for(int i = 0; i < topScores.Length; i++)
                {
                    if(topScores[i] > topScore)
                    {
                        loc = i;
                        topScore = topScores[i];
                    }

                }
                finalPlayers.Add(topPlayers[loc]);
                finalScores.Add(topScore);
                topPlayers[loc] = null;
                topScores[loc] = Double.MinValue;
            }
            int[] chances = new int[finalPlayers.Count];
            int totalChance = 0;

            
            chances[0] = 85;
            totalChance += 85;

            if (finalScores[0] - finalScores[1] < 100)
            {
                chances[1] = 35;
                totalChance += 35;
                if (finalScores[1] - finalScores[2] < 100)
                {
                    chances[2] = 20;
                    totalChance += 20;
                    if (finalScores[2] - finalScores[3] < 100)
                    {
                        chances[3] = 10;
                        totalChance += 10;
                        if (finalScores[3] - finalScores[4] < 100)
                        {
                            chances[4] = 7;
                            totalChance += 7;
                            if (finalScores[4] - finalScores[5] < 100)
                            {
                                chances[5] = 4;
                                totalChance += 4;
                                if (finalScores[5] - finalScores[6] < 100)
                                {
                                    chances[6] = 2;
                                    totalChance += 2;
                                }
                            }
                        }
                    }
                }
            }
            int decision = r.Next(totalChance);
            int currSum = 0;
            for (int i = 0; i < chances.Length-1; i++ )
            {
                if(decision < chances[i] + currSum)
                {
                    return finalPlayers[i];
                }
                currSum += chances[i];
            }


            return finalPlayers[chances.Length - 1];
        }
        private List<player> Sort(List<player> players)
        {
            List<player> slowSort = new List<player>();

            while (players.Count != 0)
            {
                player highestPlayer = null;
                double highestOverall = 0;
                foreach (player p in players)
                {
                    if (p.getOverall() > highestOverall)
                    {
                        highestPlayer = p;
                        highestOverall = p.getOverall();
                    }
                }
                slowSort.Add(highestPlayer);
                players.Remove(highestPlayer);
            }

            return slowSort;
        }
        private double GetScore(List<player> roster, player player, DraftStrategy strat)
        {
            double overallBest, overallMid, overallLow;
            int ageBest, timeToPeakStart, timeToPeakEnd;

            double overall = player.getOverall();
            if(roster.Count > 0 && roster[0] != null)
            {
                overallBest = overall - roster[0].getOverall();
                ageBest = roster[0].age - player.age;
            }
            else
            {
                overallBest = overall;
                ageBest = 10;
            }
            if (roster.Count > 1 && roster[1] != null)
            {
                overallMid = overall - roster[1].getOverall();
            }
            else
            {
                overallMid = overall;
            }
            if (roster.Count > 2 && roster[2] != null)
            {
                overallLow = overall - roster[2].getOverall();
            }
            else
            {
                overallLow = overall;
            }


            timeToPeakStart = player.peakStart - player.age;
            timeToPeakEnd = player.peakEnd - player.age;

            double projectedOverall = Math.Min(99.99,overall + (((double)player.development)/3.0) * timeToPeakStart);

            double score = 0.0;

            switch(strat)
            {
                case DraftStrategy.REBUILD:

                    score += ageBest * 100;
                    score += projectedOverall * 5;
                    score += timeToPeakStart * 20;
                    score += (timeToPeakEnd - timeToPeakStart) * 10;

                    break;
                case DraftStrategy.WIN_NOW:
                    if (overallBest > 0)
                    {
                        score += 1000 + overallBest;
                    }
                    else if (overallMid > 0)
                    {
                        score += 250 + overallMid + overallBest;
                    }
                    else if (overallLow > 0)
                    {
                        score += 50 + overallLow + overallMid + overallBest;
                    }
                    else score = -50 + projectedOverall + (overall/10);
                    break;
                case DraftStrategy.WIN_SOON:

                    score += projectedOverall * 5;
                    if (overallBest > 0)
                    {
                        score += 500 + overallBest;
                    }
                    else if (overallMid > 0)
                    {
                        score += 125 + overallMid + overallBest;
                    }
                    else if (overallLow > 0)
                    {
                        score += 35 + overallLow + overallMid + overallBest;
                    }
                    else score -= 100;
                    break;
            }
            

            return score;
        }
        private void nextPick(object sender, EventArgs e)
        {
            AiPick();
            currentPick++;
            if (currentPick == 64) FinishDraft();
            else label1.Text = "Round " + (currentPick / 32 + 1) + " - Pick " + (currentPick % 32 + 1) + "/32\n" + picks[currentPick].GetOwner(create) + " is on the clock";

            if(currentPick >= picks.Length)
            {
                draftButton.Enabled = false;
                nextPickButton.Enabled = false;
                nextUserButton.Enabled = false;
            }
            if (humanPlayers.Contains(picks[currentPick].GetOwner(create).getTeamNum()))
            {
                draftButton.Enabled = true;
                nextPickButton.Enabled = false;
                nextUserButton.Enabled = false;
            }
            else
            {
                draftButton.Enabled = false;
                nextPickButton.Enabled = true;
                nextUserButton.Enabled = true;
            }

        }
        private void FinishDraft()
        {
            label1.Text = "Draft Finished";
            undrafted = players.Values.ToList();
            drafted[0].SetNewContract(new Contract(2, 10));
            drafted[1].SetNewContract(new Contract(2, 8));
            drafted[2].SetNewContract(new Contract(2, 7));
            drafted[3].SetNewContract(new Contract(2, 5.5));
            drafted[4].SetNewContract(new Contract(2, 4.5));
            int i = 5;
            for(; i < 32; i++)
            {
                drafted[i].SetNewContract(new Contract(2, 3));
            }
            for(; i < 64; i++)
            {
                drafted[i].SetNewContract(new Contract(2, 1));
            }
        }
        public List<player> GetUndraftedPlayers()
        {
            return undrafted;
        }
        public List<player> GetDraftedPlayers()
        {
            return drafted;
        }
        private void humanDraft(object sender, EventArgs e)
        {
            int playerID = (int)grids[tabControl.SelectedIndex].SelectedRows[0].Cells[14].Value;
            player selectedPlayer = players[playerID];
            players.Remove(playerID);
            drafted.Add(selectedPlayer);
            UpdateGrid(grids[tabControl.SelectedIndex].SelectedRows[0], selectedPlayer);
            picks[currentPick].GetOwner(create).OffSeasonAddPlayer(selectedPlayer);
            label3.Text = "Previous pick: " + selectedPlayer.GetPositionAsString() + " " + selectedPlayer.getName() + " by the " + picks[currentPick].GetOwner(create);
            currentPick++;
            if (currentPick == 64) FinishDraft();
            else label1.Text = "Round " + (currentPick / 32 + 1) + " - Pick " + (currentPick % 32 + 1) + "/32\n" + picks[currentPick].GetOwner(create) + " is on the clock";
            
            if(currentPick >= picks.Length)
            {
                draftButton.Enabled = false;
                nextPickButton.Enabled = false;
                nextUserButton.Enabled = false;
            }
            else if (humanPlayers.Contains(picks[currentPick].GetOwner(create).getTeamNum()))
            {
                draftButton.Enabled = true;
                nextPickButton.Enabled = false;
                nextUserButton.Enabled = false;
            }
            else
            {
                draftButton.Enabled = false;
                nextPickButton.Enabled = true;
                nextUserButton.Enabled = true;
            }

           
        }
        private void UpdateGrid(DataGridViewRow row, player selectedPlayer)
        {
            row.Cells[1].Value = selectedPlayer.getLayupRating(false);
            row.Cells[2].Value = selectedPlayer.getDunkRating(false);
            row.Cells[3].Value = selectedPlayer.getJumpShotRating(false);
            row.Cells[4].Value = selectedPlayer.getThreeShotRating(false);
            row.Cells[5].Value = selectedPlayer.getPassing(false);
            row.Cells[6].Value = selectedPlayer.getShotContestRating(false);
            row.Cells[7].Value = selectedPlayer.getDefenseIQRating(false);
            row.Cells[8].Value = selectedPlayer.getJumpingRating(false);
            row.Cells[9].Value = selectedPlayer.getSeperation(false);
            row.Cells[10].Value = selectedPlayer.getDurabilityRating(false);
            row.Cells[11].Value = selectedPlayer.getLayupRating(false);
            row.Cells[12].Value = selectedPlayer.getDevelopment();
            row.Cells[13].Value = picks[currentPick].GetOwner(create).ToString();
        }
       private void advanceToHuman(object sender, EventArgs e)
        {

           while(currentPick <= 63 && !humanPlayers.Contains(picks[currentPick].GetOwner(create).getTeamNum()))
           {
               AiPick();
               currentPick++;
               if (currentPick == 64) FinishDraft();
               else label1.Text = "Round " + (currentPick / 32 + 1) + " - Pick " + (currentPick % 32 + 1) + "/32\n" + picks[currentPick].GetOwner(create) + " is on the clock";
           }
           if (currentPick >= picks.Length)
           {
               draftButton.Enabled = false;
               nextPickButton.Enabled = false;
               nextUserButton.Enabled = false;
           }
           else
           {
               draftButton.Enabled = true;
               nextPickButton.Enabled = false;
               nextUserButton.Enabled = false;
           }
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            label1.Text = "Round 1 - Pick 1/32\n" + picks[currentPick].GetOwner(create) + " is on the clock";

            if (humanPlayers.Contains(picks[currentPick].GetOwner(create).getTeamNum()))
            {
                draftButton.Enabled = true;
                nextPickButton.Enabled = false;
                nextUserButton.Enabled = false;
            }
            else
            {
                draftButton.Enabled = false;
                nextPickButton.Enabled = true;
                nextUserButton.Enabled = true;
            }

            startbutton.Visible = false;
            draftButton.Visible = true;
            nextPickButton.Visible = true;
            nextUserButton.Visible = true;
        }
    }
}
