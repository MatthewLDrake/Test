
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
        private List<int> humans;
        private int stage;
        private ResignPlayers resignForm;
        private FreeAgencyForm freeAgentForm;
        private bool master = false;
        private List<player> rookies;
        private DraftPick[] picks;
        public Menu(createTeams create, int teamNum, FormulaBasketball.Random r)
        {
            InitializeComponent();
            this.create = create;

            events = new List<Event>();
            events.Add(new Event("Players from new countries enter the draft!", "Players from the nations of Helvaena have joined the draft for the first time in UBA history. The only question remaining is whether or not they will ever see the court."));
            eventViewer = new EventViewer(events);
            UpdatedEvents();

            string fileName = "college.fbcollege";
            FileStream fs = new FileStream(fileName, FileMode.Open);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                create.SetCollege((College)formatter.Deserialize(fs));
                //formatter.Serialize(fs, college);
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
            team = create.getTeam(teamNum);
            humans = new List<int>
            {
                3, 7, 19
            };
            

            foreach(team t in create.getTeams())
            {
                foreach(DraftPick pick in t.GetPicks())
                {
                    pick.SetSeason(6);
                }
                foreach(DraftPick pick in t.GetNextSeasonPicks())
                {
                    pick.SetSeason(7);
                }
                if (t.GetDraftPlace() < 10) t.DraftStrategy = DraftStrategy.REBUILD;
                else if (t.GetDraftPlace() < 20) t.DraftStrategy = DraftStrategy.WIN_SOON;
                else t.DraftStrategy = DraftStrategy.WIN_NOW;
            }
            //create.getFreeAgents().AdvanceSeason();
            rookies = create.GetRookies();
            create.SetupSalaryInfo();
            this.r = r;
            this.teamNum = teamNum;
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
                create.getFreeAgents().Verify();
                freeAgentForm = new FreeAgencyForm(create.getFreeAgents(), team, create);
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
            ViewRoster rosterForm = new ViewRoster(team);
            rosterForm.ShowDialog();
            this.Visible = true;
        }

        private void viewDLeagueRoster_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ViewRoster rosterForm = new ViewRoster(team.GetAffiliate());
            rosterForm.ShowDialog();
            this.Visible = true;
        }

        private void scoutButton_Click(object sender, EventArgs e)
        {
            if (stage < 4)
            {
                this.Visible = false;
                Scouting scoutingForm = new Scouting(rookies,team.GetScout(), r);
                scoutingForm.ShowDialog();
                this.Visible = true;
            }
            else
            {                
                this.Visible = false;
                draft draft = new draft(rookies, picks, humans, r);
                draft.ShowDialog();
                this.Visible = true;

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
                AwardVoting voting = new AwardVoting(create);
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
                        DialogResult dResult = DialogResult.Cancel;
                        OpenFileDialog dialog = null;
                        while (dResult != DialogResult.OK)
                        {
                            dialog = new OpenFileDialog();
                            dialog.Multiselect = true;

                            dResult = dialog.ShowDialog();
                        }

                        String[] fileNames = dialog.FileNames;
                        List<int> teamNumbers = new List<int>();
                        foreach(string file in fileNames)
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
                            create.getTeam(temp.teamNum).removePlayer(temp.players);
                            teamNumbers.Add(temp.teamNum);
                        }

                        create.getFreeAgents().Add(players);
                        team.removePlayer(players);
                        teamNumbers.Add(teamNum);
                        for(int i = 0; i < create.size(); i++)
                        {
                            if (teamNumbers.Contains(i)) continue;
                            players = create.getTeam(i).resignPlayers(create, r);
                            create.getFreeAgents().Add(players);
                            create.getTeam(i).removePlayer(players);
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
                            formatter.Serialize(fs, new FreeAgentInfo(teamNum, players));
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
                    }

                    resignPlayersButton.Text = "Free Agency";
                    awardsButton.Text = "Trade";
                }
                 
                else if(stage <= 4)
                {
                    if (stage == 4)
                    {
                        scoutButton.Text = "Draft";
                        resignPlayersButton.Text = "Change Depth Chart";
                    }
                    List<FreeAgentOffers> offers = null;
                    if(freeAgentForm != null)
                        offers = freeAgentForm.GetOffers();

                    if(master)
                    {
                        DialogResult dResult = DialogResult.Cancel;
                        OpenFileDialog dialog = null;
                        while (dResult != DialogResult.OK)
                        {
                            dialog = new OpenFileDialog();
                            dialog.Multiselect = true;

                            dResult = dialog.ShowDialog();
                        }

                        String[] fileNames = dialog.FileNames;
                        List<int> teamNumbers = new List<int>();
                        foreach (string file in fileNames)
                        {
                            List<FreeAgentOffers> temp;
                            // Open the file containing the data that you want to deserialize.
                            FileStream fs = new FileStream(file, FileMode.Open);
                            try
                            {
                                BinaryFormatter formatter = new BinaryFormatter();

                                // Deserialize the hashtable from the file and 
                                // assign the reference to the local variable.
                                temp = (List<FreeAgentOffers>)formatter.Deserialize(fs);
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
                            create.getFreeAgents().UpdateOffers(temp, create);
                            teamNumbers.Add(temp[0].teamID);

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

                        }

                        create.getFreeAgents().UpdateOffers(offers, create);
                        teamNumbers.Add(teamNum);
                        for (int i = 0; i < create.size(); i++)
                        {
                            if (teamNumbers.Contains(i)) continue;
                            create.getTeam(i).offerToFreeAgents(create.getFreeAgents(), r);
                        }
                        FreeAgents newFreeAgents = new FreeAgents();
                        foreach (player p in create.getFreeAgents().GetAllPlayers())
                        {
                            if (!p.Signed(r, stage == 4))
                            {
                                newFreeAgents.Add(p);
                            }
                        }
                        create.SetFreeAgents(newFreeAgents);
                        //create.getFreeAgents().
                    }
                    else
                    {
                        string fileName = team.ToString() + "Stage" + stage + ".fbteam";
                        if (offers == null) return;

                        FileStream fs = new FileStream(fileName, FileMode.Create);
                       
                        // Construct a BinaryFormatter and use it to serialize the data to the stream.
                        BinaryFormatter formatter = new BinaryFormatter();
                        try
                        {
                            formatter.Serialize(fs, offers);
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
            fileDialog.Title = "Open Trade File";
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
                                teamOne.removePlayer(p);
                                teamTwo.addPlayer(p);
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
                                teamTwo.removePlayer(p);
                                teamOne.addPlayer(p);
                            }
                            else if (item is DraftPick)
                            {
                                DraftPick p = item as DraftPick;
                                teamTwo.RemoveDraftPick(p, p.GetSeason() == 6);
                                teamOne.AddDraftPick(p, p.GetSeason() == 6);
                            }
                        }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Trade was rejected");
                    }
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
    }    
    [Serializable]
    public class FreeAgentInfo
    {
        public List<player> players;
        public int teamNum;
        public FreeAgentInfo(int teamNum, List<player> players)
        {
            this.teamNum = teamNum;
            this.players = players;
        }
        
    }
}
