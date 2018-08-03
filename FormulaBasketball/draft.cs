using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class draft : Form
    {
        private List<listInfo> officialList;
        private List<draftPlayer> officialClass;
        private int round;
        private int pick;
        private int currentTeamChoosing;
        private FormulaBasketball.Random r;
        private DataGridView[] grids;
        private List<player>[] listOfPlayers;
        private Timer timer;
        public draft(bool firstDraft, List<player> players, List<team> teams,List<int> humanPlayers, FormulaBasketball.Random r)
        {
            timer = new Timer();
            this.r = r;
            InitializeComponent();
            grids = new DataGridView[5];
            grids[0] = centerLists;
            grids[1] = powerForwardList;
            grids[2] = smallForwardList;
            grids[3] = shootingGuardList;
            grids[4] = pointGuardList;
            if(firstDraft)
            {
                FirstDraftSetup(players, teams, humanPlayers);
            }
            else
            {
                DraftSetup(players, teams, humanPlayers);
            }

            

        }
        private void DraftSetup(List<player> players, List<team> teams, List<int> humanPlayers)
        {
            int[] locations = new int[5];
            foreach(player p in players)
            {

            }
        }
        private void FirstDraftSetup(List<player> players, List<team> teams,List<int> humanPlayers)
        {
            List<team> temp = (List<team>)teams.OrderBy(a => r.Next(0, 1000));


            officialClass = new List<draftPlayer>();
           
            int[] posCounter = new int[5];
            listOfPlayers = new List<player>[5];
            for (int i = 0; i < listOfPlayers.Length; i++)
            {
                listOfPlayers[i] = new List<player>();
            }
            foreach (player player in players)
            {
                officialClass.Add(new draftPlayer(player, posCounter[player.getPosition() - 1]++));
                grids[player.getPosition() - 1].Rows.Add(new object[] { player.getName(), player.getLayupRating(), player.getDunkRating(), player.getJumpShotRating(), player.getThreeShotRating(), player.getPassing(), player.getShotContestRating(), player.getDefenseIQRating(), player.getJumpingRating(), player.getSeperation(), player.getDurabilityRating(), player.getStaminaRating(), null });
                listOfPlayers[player.getPosition() - 1].Add(player);
            }

            officialList = new List<listInfo>();
            foreach (team team in temp)
            {
                officialList.Add(new listInfo(team, false, r));
            }
            for (int i = 0; i < humanPlayers.Count; i++)
            {
                officialList[humanPlayers[i]].human = true;
            }
            round = 1;
            pick = 1;
            currentTeamChoosing = 0;

            draftButton.Enabled = false;
        }
        private void TimerEventProcessor(Object myObject,
                                             EventArgs myEventArgs)
        {
            

            // Displays a message box asking whether to continue running the timer.
            if (!officialList[currentTeamChoosing].human)
            {
                object[] retVal = aiDraft(officialList[currentTeamChoosing]);

                String playerName = (String)retVal[0];
                int position = (int)retVal[1];
                int posNumber = (int)retVal[2];

                grids[position - 1][12, posNumber].Value = officialList[currentTeamChoosing].teamName;

                label1.Text = "Round " + round + "/13 Pick " +  (((pick + 1) % 32)+1) + "/32 \n Previous Pick: " + officialList[currentTeamChoosing].teamName + " Selected " + playerName;
                //System.Threading.Thread.Sleep(2000);
                if (pickHappened()) timer.Stop();
            }
            else
            {
                timer.Stop();
                draftButton.Enabled = true;
                //exitFlag = true;
            }
        }

        private void startDraft()
        {
            
            timer.Interval = 50;
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Start();
            
            
        }

        private bool pickHappened()
        {
            pick++;
            if (round % 2 == 0)
            {
                currentTeamChoosing--;
            }
            else
            {
                currentTeamChoosing++;
            }
            if (pick % 32 == 0)
            {
                if (round % 2 == 0)
                {
                    currentTeamChoosing = 0;
                }
                else
                {
                    currentTeamChoosing = 31;
                }
                round++;
                if (round == 14)
                {
                    DraftIsOver();
                    return true;
                }

            }
            return false;
        }

        private void DraftIsOver()
        {

        }
        
        private object[] aiDraft(listInfo listInfo)
        {
            String returnVal;
            int values;

            List<draftPlayer> playersAvail;

            returnVal = "";
            values = listInfo.getNextPositionToDraft();

            playersAvail = new List<draftPlayer>();
            for (int i = 0; i < officialClass.Count; i++)
            {
                if (officialClass[i].player.getPosition() == values && !officialClass[i].taken)
                {
                    playersAvail.Add(officialClass[i]);
                }

            }
            
            StringBuilder temp3 = new StringBuilder();
            switch (values)
            {
                case 1:
                    temp3.Append("Center");
                    break;
                case 2:
                    temp3.Append("Power Forward");
                    break;
                case 3:
                    temp3.Append("Small Forward");
                    break;
                case 4:
                    temp3.Append("Shooting Guard");
                    break;
                case 5:
                    temp3.Append("Point Guard");
                    break;

            }

            int temp2 = findBestPlayer(playersAvail);
            //System.out.println(temp2);
            for (int i = 0; i < officialClass.Count; i++)
            {
                if (officialClass[i].player.getPosition() == values && officialClass[i].posNum == temp2 && !officialClass[i].taken)
                {
                    officialClass[i].taken = true;
                    listInfo.addPlayer(officialClass[i]);

                    temp3.Append(" " + officialClass[i].player.getName());
                    break;
                }
            }
            returnVal = temp3.ToString();
            return new object[] { returnVal, values, temp2 };
        }
        private int findBestPlayer(List<draftPlayer> playersAvail)
        {
            int returnVal = 0;
            
            double value = 0;
            int holder = 0;
            for (int i = 0; i < playersAvail.Count; i++)
            {
                double temp = playersAvail[i].player.getOverall(null);
                if (temp > value)
                {
                    holder = i;
                    value = temp;
                }

            }

            returnVal = playersAvail[holder].posNum;


            return returnVal;

        }
        //private String humanDraft(listInfo listInfo)
        //{
            
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            int position = tabControl.SelectedIndex;
            int posNumber = grids[tabControl.SelectedIndex].CurrentRow.Index;
            player temp = listOfPlayers[position][posNumber];
            //MessageBox.Show(position + " " + posNumber);
            grids[position][12, posNumber].Value = officialList[currentTeamChoosing].teamName;
            temp.setTeam(officialList[currentTeamChoosing].getTeam());
            officialList[currentTeamChoosing].getTeam().addPlayer(temp);

            for (int i = 0; i < officialClass.Count; i++)
            {
                if (officialClass[i].player.getPosition() == position && officialClass[i].posNum == posNumber && !officialClass[i].taken)
                {
                    officialClass[i].taken = true;
                    officialList[currentTeamChoosing].addPlayer(officialClass[i]);
                    
                    break;
                }
            }
            draftButton.Enabled = false;

            label1.Text = "Round " + round + "/13 Pick " + (((pick+1) % 32) + 1) + "/32 \n Previous Pick: " + officialList[currentTeamChoosing].teamName + " Selected " + temp.getName();
            //System.Threading.Thread.Sleep(2000);
            if (!pickHappened()) startDraft();

        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            startDraft();
            startbutton.Visible = false;
            draftButton.Visible = true;
        }
    }
}
