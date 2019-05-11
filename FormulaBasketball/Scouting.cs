using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace FormulaBasketball
{
    [Serializable]
    public partial class Scouting : Form
    {
        private List<DataGridView> lists;
        private Holder holder;
        private static string fileName = "scouting.save";
        public Scouting(List<player> collegePlayers, Scout scout, FormulaBasketball.Random r)
        {
            InitializeComponent();
            //holder = DeSerializeObject();
            holder = new Holder(collegePlayers, scout, r);
            SerializeObject();
            label1.Text = "Players Able to be Scouted: " + holder.GetNumLeft();

            lists = new List<DataGridView>();

            lists.Add(centerLists);
            lists.Add(powerForwardList);
            lists.Add(smallForwardList);
            lists.Add(shootingGuardList);
            lists.Add(pointGuardList);

            for (int i = 1; i <= 5; i++)
            {
                AddPlayersToLists(i);
            }
            
        }
        private void AddPlayersToLists(int i)
        {
            List<player> players = holder.GetPlayers(i);
            for(int j = 0; j < players.Count; j++)
            {
                if (!players[j].scout)
                {
                    lists[i - 1].Rows.Add(players[j].getName(), "?", "?", "?", "?", "?", "?", "?", "?", "?", "?", "?", "?");
                }
                else
                {
                    lists[i - 1].Rows.Add(players[j].getName(), players[j].layupStr, players[j].dunkStr, players[j].jumpshotStr, players[j].threepointStr, players[j].passStr, players[j].shotcontestStr, players[j].defenseiqStr, players[j].jumpingStr, players[j].seperationStr, players[j].durabilityStr, players[j].staminaStr, players[j].potential);
                }
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            int currList = tabControl.SelectedIndex;

            int i = lists[currList].SelectedRows[0].Index;

            player currentPlayer = holder.GetPlayer(currList, i, true);

            if(currentPlayer == null)
            {
                MessageBox.Show("Cannot scout anymore players", "Out of players to scout!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            label1.Text = "Players Able to be Scouted: " + holder.GetNumLeft();
            currentPlayer.scout = true;
            SerializeObject();

            lists[currList].Rows[i].SetValues(currentPlayer.getName(), currentPlayer.layupStr, currentPlayer.dunkStr, currentPlayer.jumpshotStr, currentPlayer.threepointStr, currentPlayer.passStr, currentPlayer.shotcontestStr, currentPlayer.defenseiqStr, currentPlayer.jumpingStr, currentPlayer.seperationStr, currentPlayer.durabilityStr, currentPlayer.staminaStr, currentPlayer.potential);
        }

        private void lists_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int currList = tabControl.SelectedIndex;

            int i = lists[currList].SelectedRows[0].Index;

            player currentPlayer = holder.GetPlayer(currList, i);

            DisplayPlayer display = new DisplayPlayer(currentPlayer);
            display.ShowDialog();
        }
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public void SerializeObject()
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, holder);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        public static Holder DeSerializeObject()
        {
            Holder temp = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open);
            }
            catch(FileNotFoundException)
            {
                DialogResult result = MessageBox.Show("Could not open save file, if you removed it please replace it.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                temp = (Holder)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            return temp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "Name,Position,Layup,Dunk,Jumpshot,3PT,Pass,ShotContest,DefenseIQ,Jumping,Seperation,Durability,Stamina,Potential,Age\n";

            for (int i = 1; i <= 5; i++)
            {
                List<player> players = holder.GetPlayers(i);
                for (int j = 0; j < players.Count; j++)
                {
                    if (!players[j].scout)
                    {
                        str += players[j].getName() + "," + players[j].getPosition() + ",?,?,?,?,?,?,?,?,?,?,?,?," + players[j].age + "\n";
                    }
                    else
                    {
                        str += players[j].getName() + "," + players[j].getPosition() + "," + players[j].layupStr + "," + players[j].dunkStr + "," + players[j].jumpshotStr + "," + players[j].threepointStr + "," + players[j].passStr + "," + players[j].shotcontestStr + "," + players[j].defenseiqStr + "," + players[j].jumpingStr + "," + players[j].seperationStr + "," + players[j].durabilityStr + "," + players[j].staminaStr + "," + players[j].potential + "," + players[j].age + "\n";
                    }
                }
            }

        File.WriteAllText("scouting.csv",str);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "Name,Position,Layup Low,Layup High,Dunk Low,Dunk High,Jumpshot Low,Jumpshot High,3PT Low,3PT High,Pass Low,Pass High,ShotContest Low,ShotContest High,DefenseIQ Low,DefenseIQ High,Jumping Low,Jumping High,Seperation Low,Seperation High,Durability Low,Durability High,Stamina Low,Stamina High,Potential,Age\n";

            for (int i = 1; i <= 5; i++)
            {
                List<player> players = holder.GetPlayers(i);
                for (int j = 0; j < players.Count; j++)
                {
                    if (!players[j].scout)
                    {
                        str += players[j].ToString() + "," + players[j].getPosition() + ",?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?," + players[j].age + "\n";
                    }
                    else
                    {
                        str += players[j].ToString() + "," + players[j].getPosition() + "," + players[j].layupStr.Replace(" -> ", ",") + "," + players[j].dunkStr.Replace(" -> ", ",") + "," + players[j].jumpshotStr.Replace(" -> ", ",") + "," + players[j].threepointStr.Replace(" -> ", ",") + "," + players[j].passStr.Replace(" -> ", ",") + "," + players[j].shotcontestStr.Replace(" -> ", ",") + "," + players[j].defenseiqStr.Replace(" -> ", ",") + "," + players[j].jumpingStr.Replace(" -> ", ",") + "," + players[j].seperationStr.Replace(" -> ", ",") + "," + players[j].durabilityStr.Replace(" -> ", ",") + "," + players[j].staminaStr.Replace(" -> ", ",") + "," + players[j].potential + "," + players[j].age + "\n";
                    }
                }
            }

            File.WriteAllText("splitscouting.csv", str);
        }
    }
    
}
