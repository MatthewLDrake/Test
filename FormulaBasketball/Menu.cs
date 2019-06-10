
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class Menu : Form
    {
        private createTeams create;
        private team team;

        private FormulaBasketball.Random r;
        private int teamNum;
        public static List<int> humans;
        private int stage;
        private ResignPlayers resignForm;
        private FreeAgencyForm freeAgentForm;
        private bool master = true;
        private List<player> rookies;
        private DraftPick[] picks;
        private Scouting scoutingForm; 
        private AwardVoting voting;
        private player roty, mvp;
        private Dictionary<int, int> mvpVotes, rotyVotes, cotyVotes;
        public static Menu menu;
        public Menu(createTeams create, FormulaBasketball.Random r)
        {
            InitializeComponent();

            this.create = create;

            this.r = r;
        }
        private void Contruct()
        {
            menu = this;
            mvpVotes = new Dictionary<int, int>();
            rotyVotes = new Dictionary<int, int>();
            cotyVotes = new Dictionary<int, int>();

            events = new List<Event>();
            events.Add(new Event("Players from new countries enter the draft!", "Players from the nations of Tjedigar have joined the draft for the first time in UBA history. The only question remaining is whether or not they will ever see the court."));
            events.Add(new Event("Players from new countries enter the draft!", "Players from the nations of Aovensiiv have joined the draft for the first time in UBA history. The only question remaining is whether or not they will ever see the court."));
            events.Add(new Event("Players from new countries enter the draft!", "Players from the nations of Eqkirium have joined the draft for the first time in UBA history. The only question remaining is whether or not they will ever see the court."));
            events.Add(new Event("Players from new countries enter the draft!", "Players from the nations of Teralm have joined the draft for the first time in UBA history. The only question remaining is whether or not they will ever see the court."));
            events.Add(new Event("Players from new countries enter the draft!", "Players from the nations of Timbalta have joined the draft for the first time in UBA history. The only question remaining is whether or not they will ever see the court."));
            events.Add(new Event("Players from new countries enter the draft!", "Players from the nations of Helvaena have joined the draft for the first time in UBA history. The only question remaining is whether or not they will ever see the court."));
            events.Add(new Event("Players from new countries enter the draft!", "Players from the nations of Ipal have joined the draft for the first time in UBA history. The only question remaining is whether or not they will ever see the court."));
            events.Add(new Event("Players from new countries enter the draft!", "Players from the nations of Eksola have joined the draft for the first time in UBA history. The only question remaining is whether or not they will ever see the court."));
            events.Add(new Event("Players from new countries enter the draft!", "Players from the nations of Kolauk have joined the draft for the first time in UBA history. The only question remaining is whether or not they will ever see the court."));
            events.Add(new Event("Players from new countries enter the draft!", "Players from the nations of Elvine have joined the draft for the first time in UBA history. The only question remaining is whether or not they will ever see the court."));
            eventViewer = new EventViewer(events);
            UpdatedEvents();

            team = create.getTeam(teamNum);

            humans = new List<int>
            {
                2, 7, 19
            };


            foreach (team t in create.getTeams())
            {
                foreach (DraftPick pick in t.GetPicks())
                {
                    pick.SetSeason(6);
                }
                foreach (DraftPick pick in t.GetNextSeasonPicks())
                {
                    pick.SetSeason(7);
                }
                if (t.GetDraftPlace() < 10) t.DraftStrategy = DraftStrategy.REBUILD;
                else if (t.GetDraftPlace() < 20) t.DraftStrategy = DraftStrategy.WIN_SOON;
                else t.DraftStrategy = DraftStrategy.WIN_NOW;

                t.StartOffSeason();

            }
            //create.getFreeAgents().AdvanceSeason();
            rookies = create.GetRookies();

            voting = new AwardVoting(create);
            scoutingForm = new Scouting(rookies, team.GetScout(), r);
            create.SetupSalaryInfo();
            stage = 0;

            picks = new DraftPick[64];

            foreach (team t in create.getTeams())
            {
                foreach (DraftPick pick in t.GetPicks())
                {
                    picks[pick.GetPickNumber() - 1] = pick;
                }
            }
        }
        private void UpdatedEvents()
        {
            int num = eventViewer.GetUnreadEvents();
            eventCounter.Text = "" + num;
            if (num == 0) eventCounter.Visible = false;
            else eventCounter.Visible = true;
            
        }
        private void resignPlayersButton_Click(object sender, EventArgs e)
        {
            if (stage == 0)
            {
                this.Visible = false;
                if(resignForm == null)
                    resignForm = new ResignPlayers(create, team, r);
                resignForm.ShowDialog();
                this.Visible = true;
            }
            else if(stage < 4)
            {
                this.Visible = false;
                if (freeAgentForm == null)
                    freeAgentForm = new FreeAgencyForm(create.getFreeAgents(), team, create);
                else
                    freeAgentForm.UpdateFreeAgents(create);
                freeAgentForm.ShowDialog();
                this.Visible = true;
            }
            else
            {
                this.Visible = false;
                DepthChart depthChart = new DepthChart(team);
                depthChart.ShowDialog();
                this.Visible = true;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            formulaBasketball.SerializeObject(create, "testSave.fbdata");
            //Close();
        }

        private void viewRoster_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ViewRoster rosterForm = new ViewRoster(team.GetOffSeasonPlayers(false));
            rosterForm.ShowDialog();
            this.Visible = true;
        }

        private void viewDLeagueRoster_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ViewRoster rosterForm = new ViewRoster(team.GetAffiliate().getAllPlayer());
            rosterForm.ShowDialog();
            this.Visible = true;
        }

        private void scoutButton_Click(object sender, EventArgs e)
        {
            if (stage < 4)
            {
                this.Visible = false;                
                scoutingForm.ShowDialog();
                this.Visible = true;
            }
            else
            {                
                this.Visible = false;
                draft draft = new draft(rookies, picks, humans, new FormulaBasketball.Random(69420));
                draft.ShowDialog();
                this.Visible = true;
                create.getFreeAgents().Add(draft.GetUndraftedPlayers());
                
            }
        }
        private List<player> ConvertToProPlayers(List<CollegePlayer> players)
        {
            List<player> pros = new List<player>();

            foreach(CollegePlayer player in players)
            {
                pros.Add(new player(player, createTeams.nextID));
                createTeams.nextID++;
            }


            return pros;

        }
        private void awardsButton_Click(object sender, EventArgs e)
        {
            if (stage == 0)
            {
                this.Visible = false;
                
                voting.ShowDialog();
                this.Visible = true;
            }
            else
            {
                this.Visible = false;
                TradeForm tradeForm = new TradeForm(create, team, teamNum);
                tradeForm.ShowDialog();
                this.Visible = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to advance? All uncompleted tasks will be autocompleted.", "Confirmation", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                stage++;
                if(stage == 1)
                {
                    if(resignForm == null)
                        resignForm = new ResignPlayers(create, team, r);
                    List<player> players = resignForm.GetRejectedPlayers();
                    

                    if(master)
                    {
                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.Multiselect = true;

                        dialog.ShowDialog();
                        

                        String[] fileNames = dialog.FileNames;
                        List<int> teamNumbers = new List<int>();
                        if(fileNames != null)
                        {
                            foreach (string file in fileNames)
                            {
                                FreeAgentInfo temp;
                                // Open the file containing the data that you want to deserialize.
                                FileStream fs = new FileStream(file, FileMode.Open);
                                try
                                {
                                    BinaryFormatter formatter = new BinaryFormatter();

                                    // Deserialize the hashtable from the file and 
                                    // assign the reference to the local variable.
                                    temp = (FreeAgentInfo)formatter.Deserialize(fs);
                                }
                                catch (SerializationException exc)
                                {
                                    Console.WriteLine("Failed to deserialize. Reason: " + exc.Message);
                                    throw;
                                }
                                finally
                                {
                                    fs.Close();
                                }
                                create.getFreeAgents().Add(temp.players);
                                create.getTeam(temp.teamNum).OffSeasonRemovePlayers(temp.players);
                                teamNumbers.Add(temp.teamNum);
                                
                            }
                        }
                        VoteMVP();

                        MessageBox.Show(mvp.getName() + " of " + mvp.getTeam() + " wins the MVP!\n");
                        

                        create.getFreeAgents().Add(players);
                        team.OffSeasonRemovePlayers(players);
                        teamNumbers.Add(teamNum);
                        for(int i = 0; i < create.size(); i++)
                        {
                            if (teamNumbers.Contains(i)) continue;
                            players = create.getTeam(i).resignPlayers(create, r);
                            create.getFreeAgents().Add(players);
                            create.getTeam(i).OffSeasonRemovePlayers(players);
                            create.getTeam(i).SetFree();
                        }
                        FileStream createFS = new FileStream("Stage1Results.fbdata", FileMode.Create);

                        // Construct a BinaryFormatter and use it to serialize the data to the stream.
                        BinaryFormatter outFormatter = new BinaryFormatter();
                        try
                        {
                            outFormatter.Serialize(createFS, create);
                        }
                        catch (SerializationException ex)
                        {
                            Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                            throw;
                        }
                        finally
                        {
                            createFS.Close();
                        }
                    }
                    else
                    {
                        string fileName = team.ToString() + "Stage1.fbteam";
                        FileStream fs = new FileStream(fileName, FileMode.Create);

                        // Construct a BinaryFormatter and use it to serialize the data to the stream.
                        BinaryFormatter formatter = new BinaryFormatter();
                        try
                        {
                            formatter.Serialize(fs, new FreeAgentInfo(teamNum, players, voting.GetVotes()));
                        }
                        catch (SerializationException ex)
                        {
                            Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                            throw;
                        }
                        finally
                        {
                            fs.Close();
                        }
                        resignPlayersButton.Enabled = false;                        
                        awardsButton.Enabled = false;
                    }

                    resignPlayersButton.Text = "Free Agency";
                    awardsButton.Text = "Trade";

                    for(int i = 0; i < create.size(); i++)
                    {
                        foreach(player p in create.getTeam(i))
                            p.IsRookie(false);
                        
                        foreach(player p in create.getTeam(i).GetAffiliate())
                            p.IsRookie(false);
                    }

                }
                 
                else if(stage <= 4)
                {
                    if (stage == 4)
                    {
                        scoutButton.Text = "Draft";
                        resignPlayersButton.Text = "Change Depth Chart";
                    }

                    if(master)
                    {
                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.Multiselect = true;

                        dialog.ShowDialog();


                        String[] fileNames = dialog.FileNames;
                        List<int> teamNumbers = new List<int>();
                        foreach (string file in fileNames)
                        {
                            team temp;
                            // Open the file containing the data that you want to deserialize.
                            FileStream fs = new FileStream(file, FileMode.Open);
                            try
                            {
                                BinaryFormatter formatter = new BinaryFormatter();

                                // Deserialize the hashtable from the file and 
                                // assign the reference to the local variable.
                                temp = (team)formatter.Deserialize(fs);
                                create.ReplaceTeam(temp);
                            }
                            catch (SerializationException exc)
                            {
                                Console.WriteLine("Failed to deserialize. Reason: " + exc.Message);
                                throw;
                            }
                            finally
                            {
                                fs.Close();
                            }
                            create.getFreeAgents().UpdateOffers(temp.GetOffers(), temp);
                            
                            teamNumbers.Add(temp.getTeamNum());

                            

                        }

                        create.getFreeAgents().UpdateOffers(team.GetOffers(), team);
                        teamNumbers.Add(teamNum);
                        for (int i = 0; i < create.size(); i++)
                        {
                            if (teamNumbers.Contains(i)) continue;
                            create.getTeam(i).OfferFreeAgents(create.getFreeAgents(), r, stage == 2);
                        }
                        /*FreeAgents newFreeAgents = new FreeAgents();
                        foreach (player p in create.getFreeAgents().GetAllPlayers())
                        {
                            if (!p.Signed(r, stage == 4, create))
                            {
                                newFreeAgents.Add(p);
                            }
                            else
                            {
                                PlayerSigned playerSigned = new PlayerSigned(p, create);
                                playerSigned.ShowDialog();
                            }
                        }
                        create.SetFreeAgents(newFreeAgents);*/
                        new LeagueRoster(humans, create).Show();
                        OffseasonFreeAgentForm form = new OffseasonFreeAgentForm(create.getFreeAgents(), create);
                        form.ShowDialog();

                        FileStream createFS = new FileStream("Stage" + stage + "Results.fbdata", FileMode.Create);

                        // Construct a BinaryFormatter and use it to serialize the data to the stream.
                        BinaryFormatter outFormatter = new BinaryFormatter();
                        try
                        {
                            outFormatter.Serialize(createFS, create);
                        }
                        catch (SerializationException ex)
                        {
                            Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                            throw;
                        }
                        finally
                        {
                            createFS.Close();
                        }

                        //create.getFreeAgents().
                    }
                    else
                    {
                        string fileName = team.ToString() + "Stage" + stage + ".fbteam";
                        FileStream fs = new FileStream(fileName, FileMode.Create);

                        // Construct a BinaryFormatter and use it to serialize the data to the stream.
                        BinaryFormatter formatter = new BinaryFormatter();
                        try
                        {
                            formatter.Serialize(fs, team);
                        }
                        catch (SerializationException ex)
                        {
                            Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                            throw;
                        }
                        finally
                        {
                            fs.Close();
                        }
                        resignPlayersButton.Enabled = false;                        
                        awardsButton.Enabled = false;
                    
                    }

                }
                else
                {
                    MessageBox.Show("Nothing to advance");
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Open Formula Basketball File";
            fileDialog.Filter = "FBTrade files (*.fbtrade)|*.fbtrade|FBData files (*.fbdata)|*.fbdata|FB Trade Response File (*.fbtr)|*.fbtr";
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = fileDialog.FileName;
                string extension = Path.GetExtension(fileName);

                if(extension.Equals(".fbtrade"))
                {
                    Trade trade = TradeForm.DeSerializeObject(fileName);
                    if (trade.CanView(team.ToString()))
                    {
                        OfferedTrade offer = new OfferedTrade(trade, create, teamNum);
                        offer.ShowDialog();
                    }
                    
                    // TODO: something with trades
                }
                else if(extension.Equals(".fbdata"))
                {
                    create = formulaBasketball.DeSerializeObject(fileName);
                    resignPlayersButton.Enabled = true;
                    awardsButton.Enabled = true;
                    team = create.getTeam(teamNum);
                }
                else if(extension.Equals(".fbtr"))
                {
                    try
                    {
                        Trade t = TradeForm.DeSerializeObject(fileName);
                        team teamOne = create.getTeam(t.teamOneID);
                        team teamTwo = create.getTeam(t.teamTwoID);

                        foreach(Object item in t.GetTeamOneTradeItems())
                        {
                            if(item is player)
                            {
                                player p = item as player;
                                teamOne.OffSeasonRemovePlayer(p);
                                teamTwo.OffSeasonAddPlayer(p);
                            }
                            else if(item is DraftPick)
                            {
                                DraftPick p = item as DraftPick;
                                teamOne.RemoveDraftPick(p, p.GetSeason() == 6);
                                teamTwo.AddDraftPick(p, p.GetSeason() == 6);
                            }
                        }
                        foreach (Object item in t.GetTeamTwoTradeItems())
                        {
                            if (item is player)
                            {
                                player p = item as player;
                                teamTwo.OffSeasonRemovePlayer(p);
                                teamOne.OffSeasonAddPlayer(p);
                            }
                            else if (item is DraftPick)
                            {
                                DraftPick p = item as DraftPick;
                                teamTwo.RemoveDraftPick(p, p.GetSeason() == 6);
                                teamOne.AddDraftPick(p, p.GetSeason() == 6);
                            }
                        }
                        UpdatePicks();
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Trade was rejected");
                    }
                }
            }
            
        }
        public void UpdatePicks()
        {
            picks = new DraftPick[64];

            foreach (team t in create.getTeams())
            {
                foreach (DraftPick pick in t.GetPicks())
                {
                    picks[pick.GetPickNumber() - 1] = pick;
                }
            }
        }
        private draft currentDraft;
        private void mockDraft_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if(currentDraft == null || stage == 4)
            {
                currentDraft = new draft(rookies, picks, new List<int>(), r);     
                if(stage == 4)
                {
                    List<player> mock = currentDraft.GetMockedDraft();
                    player topPick = mock[0];
                    bool teamIndex = true;
                    for(int i = 0; i < picks.Length; i++)
                    {
                        if(picks[i].GetOwner().Equals(team))
                        {
                            teamIndex = false;
                            if(i == 0)
                                AddEvent(new Event("Newest Mock Draft Released!", "The newest mock draft, done by draft experts in " + team.GetLocation() + " has " + topPick.getName() + " going first overall to " + team.ToString()));
                            else
                                AddEvent(new Event("Newest Mock Draft Released!", "The newest mock draft, done by draft experts in " + team.GetLocation() + " has " + topPick.getName() + " going first overall to " + picks[0].GetOwner().ToString() +
                                    ". Additionally, " + mock[i].getName() + " is mocked to the " + team.ToString() + " at pick #" + (i + 1)));
                            break;
                        }
                    }
                    if(teamIndex)
                    {
                        AddEvent(new Event("Newest Mock Draft Released!", "The newest mock draft, done by draft experts in " + team.GetLocation() + " has " + topPick.getName() + " going first overall to " + picks[0].GetOwner().ToString()));
                    }
                    
                }
                else
                {
                    List<player> mock = currentDraft.GetMockedDraft();
                    player topPick = mock[0];
                    bool teamIndex = true;
                    for (int i = 0; i < picks.Length; i++)
                    {
                        if (picks[i].GetOwner().Equals(team))
                        {
                            teamIndex = false;
                            if (i == 0)
                                AddEvent(new Event("First Mock Draft Released!", "The first mock draft of the season, done by draft experts in " + team.GetLocation() + " has " + topPick.getName() + " going first overall to " + team.ToString()));
                            else
                                AddEvent(new Event("First Mock Draft Released!", "The first mock draft of the season, done by draft experts in " + team.GetLocation() + " has " + topPick.getName() + " going first overall to " + picks[0].GetOwner().ToString() +
                                    ". Additionally, " + mock[i].getName() + " is mocked to the " + team.ToString() + " at pick #" + (i + 1)));
                            break;
                        }
                    }
                    if (teamIndex)
                    {
                        AddEvent(new Event("First Mock Draft Released!", "The first mock draft of the season, done by draft experts in " + team.GetLocation() + " has " + topPick.getName() + " going first overall to " + picks[0].GetOwner().ToString()));
                    }
                }
            }
            MockDraftView mdv = new MockDraftView(currentDraft.GetMockedDraft(), picks);
            mdv.ShowDialog();
            this.Visible = true;
        }
        private EventViewer eventViewer;
        private List<Event> events;
        private void eventButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if(eventViewer == null)
            {
                eventViewer = new EventViewer(events);
            }
            eventViewer.GotSelected();
            eventViewer.ShowDialog();
            UpdatedEvents();
            this.Visible = true;
        }
        private void VoteMVP()
        {
            List<player> playerList = new List<player>();
            foreach (team team in create.getTeams())
            {
                foreach (player p in team)
                {
                    if (p.getMinutes() > 2000)
                    {
                        mvpVotes.Add(p.GetPlayerID(), 0);
                        playerList.Add(p);
                    }
                }
            }
            mvp = FindBest(playerList, mvpVotes);
            
        }
        private void VoteROTY()
        {
            List<player> playerList = new List<player>();
            foreach (team team in create.getTeams())
            {
                foreach (player p in team)
                {
                    if (p.Rookie())
                    {
                        rotyVotes.Add(p.GetPlayerID(), 0);
                        playerList.Add(p);
                    }
                }
            }
            roty = FindBest(playerList, rotyVotes);
        }
        
        private player FindBest(List<player> list, Dictionary<int, int> dict)
        {
            if (list.Count == 0) return null;

            for (int teamNum = 0; teamNum < create.size(); teamNum++)
            {
                int[] points = GetPoints(create.getTeam(teamNum), list);
                for (int i = 0; i < points.Length; i++)
                {                    
                    dict[points[i]] += 10 - i;
                    
                }
            }
            int id = 0;
            int highest = 0;
            foreach(KeyValuePair<int, int> pair in dict)
            {               
                if (highest < pair.Value)
                {
                    highest = pair.Value;
                    id = pair.Key;
                }
            }
            for (int i = 0; i < list.Count; i++ )
            {
                if (list[i].GetPlayerID() == id) return list[i];
            }

            return null;

        }
        private int[] GetPoints(team team, List<player> list)
        {
            int[] retVal = new int[Math.Min(10, list.Count)];
            //double[] scores = new double[list.Count];
            double[] tempList = new double[retVal.Length];
            int value = r.Next(1, 100);
            int focus = 6;
            if (value <= 10)
                focus = 1;
            else if (value <= 20)
                focus = 2;
            else if (value <= 50)
                focus = 3;
            else if (value <= 75)
                focus = 4;
            else if (value <= 90)
                focus = 5;

            for (int i = 0; i < list.Count; i++)
            {
                double score = GetScore(list[i], focus, team);
                int playerID = list[i].GetPlayerID();
                for(int j = 0; j < retVal.Length; j++)
                {
                    if(tempList[j] < score)
                    {
                        double temp = score;
                        score = tempList[j];
                        tempList[j] = temp;
                        int pID = playerID;
                        playerID = retVal[j];
                        retVal[j] = pID;
                    }
                }
            }

           

            return retVal;
        }
        private double GetScore(player p, int focus, team team)
        {
            int bonus = 0;

            if (p.getTeam().Equals(team))
                bonus = 20;
            // read in minutes first, then find out the per minute situations
            int Minutes = p.getMinutes();
            double APM = ((double)p.getAssists() / (double)Minutes) * 100;
            double PPM = ((double)p.getPoints() / (double)Minutes) * 100;
            double Percent = 0;
            if (p.getShotsTaken() > 0)
                Percent = p.getShotsMade() / p.getShotsTaken() * 100;
            double Turnovers = ((double)p.getTurnovers() / (double)Minutes) * 100;
            double Steals = ((double)p.getSteals() / (double)Minutes) * 100;
            // add the random value
            double retVal = bonus + r.Next(-40, 60);

            // this is probably bad style, but eh it was the best way I thought of doing it
            if (focus == 1)
                retVal += APM * 4 + PPM + Percent - Turnovers + Steals;
            else if (focus == 2)
                retVal += APM + PPM + Percent - Turnovers + Steals * 100;
            else if (focus == 3)
                retVal += APM * 2 + PPM + Percent * 3 - Turnovers + Steals * 2;
            else if (focus == 4)
                retVal += APM + PPM * 4 + Percent * 3 - Turnovers + Steals;
            else if (focus == 5)
                retVal += APM * 4 + PPM + Percent * 5 - Turnovers + Steals * 2;
            else
                retVal += APM + PPM + Percent - Turnovers + Steals;

            return retVal;
        }
        private double[] Sort(double[] list)
        {
            double temp = 0;
            for (int write = 0; write < list.Length; write++)
            {
                for (int sort = 0; sort < list.Length - 1; sort++)
                {
                    if (list[sort] < list[sort + 1])
                    {
                        temp = list[sort + 1];
                        list[sort + 1] = list[sort];
                        list[sort] = temp;
                    }
                }
            }
            return list;
        }

        public void AddEvent(Event p)
        {
            eventViewer.AddEvent(p);
            UpdatedEvents();
        }

        private void teamSelected(object sender, EventArgs e)
        {
            teamNum = int.Parse((String)((RadioButton)sender).Tag);
            groupBox1.Visible = false;
            tableLayoutPanel1.Visible = true;
            master = teamNum == 2;
            Contruct();
        }
    }    
    [Serializable]
    public class FreeAgentInfo
    {
        public List<player> players;
        public int teamNum;
        public AwardVotes votes;
        public FreeAgentInfo(int teamNum, List<player> players, AwardVotes votes)
        {
            this.teamNum = teamNum;
            this.players = players;
            this.votes = votes;
        }
        
    }
}
