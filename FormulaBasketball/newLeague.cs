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
    public partial class newLeague : Form
    {
        public List<team> teams;
        private List<player> players;
        private Random r;
        private List<int> humanTeams;
        private string fileName;
        private string[] fileNames;

        public newLeague(List<team> teams, Random r)
        {
            InitializeComponent();
            humanTeams = new List<int>();
            this.r = r;
            this.teams = teams;
            players = new List<player>();
            foreach (team team in teams)
            {
                listOfTeams.Rows.Add(new object[] { team.ToString(), team.getThreeLetters(), team.getDivisionLetter() });
            }
        }
        public newLeague(Random r)
        {
            InitializeComponent();
            teams = new List<team>();
            players = new List<player>();
            this.r = r;
        }

        public newLeague(string[] fileNames, Random r)
        {
            InitializeComponent();
            this.fileNames = fileNames;
            this.r = r;
            teams = new List<team>();
            foreach (string file in fileNames)
            {
                teams.Add(DeSerializeTeam(file));
            }
            players = new List<player>();
            foreach (team team in teams)
            {
                listOfTeams.Rows.Add(new object[] { team.ToString(), team.getThreeLetters(), team.getDivisionLetter() });
                foreach(player player in team.getAllPlayer())
                {
                    listOfPlayers.Rows.Add(new object[] { player.getName(), team.getThreeLetters(), player });
                }
                team.setBestStarters();
            }

        }

        private void newPlayerButton_Click(object sender, EventArgs e)
        {
            newPlayer player = new newPlayer(teams);
            player.ShowDialog();
            int team = player.getTeam();
            player newPlayer = player.getNewPlayer();
            players.Add(newPlayer);
            newPlayer.setTeam(teams[team]);
            if (team != -1)
            {
                teams[team].addPlayer(newPlayer);
                listOfPlayers.Rows.Add(new object[] { newPlayer.getName(), teams[team].getThreeLetters(), newPlayer });
            }
            else
            {
                listOfPlayers.Rows.Add(new object[] { newPlayer.getName(), "None", newPlayer });
            }
        }

        private void newTeamButton_Click(object sender, EventArgs e)
        {
            formulaBasketball formula = new formulaBasketball(false, fileName, teams, null);
            /*newTeam newTeam = new newTeam(r);
            newTeam.ShowDialog();
            team team = newTeam.getNewTeam();
            listOfTeams.Rows.Add(new object[] { team.ToString(), team.getThreeLetters(), team.getDivisionLetter() });
            teams.Add(team);*/
        }

        public void setFileName(string fileName)
        {
            this.fileName = fileName;
        }

        private void scrimmage_Click(object sender, EventArgs e)
        {
            teamPicker picker = new teamPicker(teams);
            picker.ShowDialog();
            team teamOne = picker.getFirstTeam();
            team teamTwo = picker.getSecondTeam();

            if (teamOne == null || teamTwo == null)
            {
                MessageBox.Show("One or both of the teams were not properly selected.");
                return;
            }

            playScrimmage scrimmage = new playScrimmage(teamOne, teamTwo, r);
            scrimmage.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (team team in teams)
            {
                fillTeam(team);
                team.setBestStarters();
            }
            
        }
        private void fillTeam(team team)
        {
            int centers = team.getCenters();
            int powerForwards = team.getPowerForwards();
            int smallForwards = team.getSmallForwards();
            int shootingGuards = team.getShootingGuards();
            int pointGuards = team.getPointGuards();

            int randomPlayerNum = 1;

            while (centers < 3)
            {
                player player = getRandomCenter(team.ToString(), randomPlayerNum++);
                team.addPlayer(player);
                player.setTeam(team);
                player.age = r.Next(20, 30);
                centers++;
                listOfPlayers.Rows.Add(new object[] { player.getName(), team.getThreeLetters() });
                players.Add(player);
            }
            while (powerForwards < 3)
            {
                player player = getRandomPowerForward(team.ToString(), randomPlayerNum++);
                team.addPlayer(player);
                player.setTeam(team);
                player.age = r.Next(20, 30);
                powerForwards++;
                listOfPlayers.Rows.Add(new object[] { player.getName(), team.getThreeLetters() });
                players.Add(player);
            }
            while (smallForwards < 3)
            {
                player player = getRandomSmallForward(team.ToString(), randomPlayerNum++);
                team.addPlayer(player);
                player.setTeam(team);
                player.age = r.Next(20, 30);
                smallForwards++;
                listOfPlayers.Rows.Add(new object[] { player.getName(), team.getThreeLetters() });
                players.Add(player);
            }
            while (shootingGuards < 3)
            {
                player player = getRandomShootingGuard(team.ToString(), randomPlayerNum++);
                team.addPlayer(player);
                player.setTeam(team);
                player.age = r.Next(20, 30);
                shootingGuards++;
                listOfPlayers.Rows.Add(new object[] { player.getName(), team.getThreeLetters() });
                players.Add(player);
            }
            while (pointGuards < 3)
            {
                player player = getRandomPointGuard(team.ToString(), randomPlayerNum++);
                team.addPlayer(player);
                player.setTeam(team);
                player.age = r.Next(20, 30);
                pointGuards++;
                listOfPlayers.Rows.Add(new object[] { player.getName(), team.getThreeLetters() });
                players.Add(player);
            }



        }

        private player getRandomPointGuard(string teamName, int v2, bool freeAgent = false)
        {
            if(!freeAgent)return new player(5, r.Next(2, 4), r.Next(1, 5), r.Next(1, 7), r.Next(1, 7), r.Next(1, 10), r.Next(1, 5), r.Next(1, 5), r.Next(1, 2), r.Next(1, 4), r.Next(4, 7), r.Next(5, 10), " Player #" + v2, false);
            return new player(5, r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7),  "Point Guard #" + v2, false);
        }

        private player getRandomShootingGuard(string teamName, int v2, bool freeAgent = false)
        {
            if (!freeAgent) return new player(4, r.Next(1, 6), r.Next(1, 6), r.Next(1, 7), r.Next(1, 6), r.Next(1, 4), r.Next(1, 5), r.Next(1, 6), r.Next(1, 4), r.Next(1, 6), r.Next(5, 9), r.Next(5, 8), " Player #" + v2, false);
            return new player(4, r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), "Shooting Guard #" + v2, false);
        }

        private player getRandomSmallForward(string teamName, int v2, bool freeAgent = false)
        {
            if (!freeAgent) return new player(3, r.Next(1, 7), r.Next(1, 7), r.Next(1, 6), r.Next(1, 5), r.Next(1, 3), r.Next(1, 6), r.Next(1, 6), r.Next(1, 5), r.Next(1, 6), r.Next(5, 7), r.Next(5, 9), " Player #" + v2, false);
            return new player(3, r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), "Small Forward #" + v2, false);
        }

        private player getRandomPowerForward(string teamName, int v, bool freeAgent = false)
        {
            if (!freeAgent) return new player(2, r.Next(1, 6), r.Next(1, 7), r.Next(1, 5), r.Next(1, 4), r.Next(1, 3), r.Next(1, 7), r.Next(1, 6), r.Next(1, 6), r.Next(1, 6), r.Next(5, 9), r.Next(5, 9), " Player #" + v, false);
            return new player(2, r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), "Power Forward #" + v, false);
        }

        private player getRandomCenter(string teamName, int v, bool freeAgent = false)
        {
            if (!freeAgent) return new player(1, r.Next(1, 7), r.Next(1, 7), r.Next(1, 4), r.Next(1, 4), r.Next(1, 2), r.Next(1, 7), r.Next(1, 6), r.Next(1, 7), r.Next(1, 7), r.Next(5, 9), r.Next(5, 9), " Player #" + v, false);
            return new player(1, r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), r.Next(4, 7), "Center #" + v, false);
        }

        private void listOfTeams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            newTeam team = new newTeam(teams[row]);
            team.ShowDialog();
            DataGridView view = (DataGridView)sender;
            view[0, row].Value = teams[row].ToString();
            view[1, row].Value = teams[row].getThreeLetters();
            view[2, row].Value = teams[row].getDivisionLetter();
        }

        private void listOfPlayers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int teamName = -1;
            if (players[row].getTeam() != null)
            {
                teamName = players[row].getTeam().getTeamNum();
            }
            newPlayer player = new newPlayer(teams, players[row], teamName);
            player.ShowDialog();
            player temp = player.getNewPlayer();
            if (teamName != -1) teams[teamName].removePlayer(players[row]);
            int team = player.getTeam();
            if (team != -1) teams[team].addPlayer(temp);
            temp.setTeam(teams[team]);


            DataGridView view = (DataGridView)sender;
            view[0, row].Value = temp.getName();
            if (team != -1)
            {
                teams[team].addPlayer(temp);
                view[1, row].Value = teams[team].getThreeLetters();
            }
            else view[1, row].Value = "None";
            view[2, row].Value = temp;
            players[row] = temp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] posCounter = new int[5];
            foreach (player player in players)
            {
                int teamName = -1;
                if (player.getTeam() != null)
                {
                    teamName = player.getTeam().getTeamNum();
                    if (teamName != -1) teams[teamName].removePlayer(player);
                }
                posCounter[player.getPosition() - 1]++;

            }
            int randomPlayerNum = 0;
            while (posCounter[0] < 100)
            {
                player player = getRandomCenter("", randomPlayerNum++, true);
                player.age = r.Next(20, 30);
                posCounter[0]++;
                listOfPlayers.Rows.Add(new object[] { player.getName(), "None" });
                players.Add(player);
            }
            randomPlayerNum = 0;
            while (posCounter[1] < 100)
            {
                player player = getRandomPowerForward("", randomPlayerNum++, true);
                player.age = r.Next(20, 30);
                posCounter[1]++;
                listOfPlayers.Rows.Add(new object[] { player.getName(), "None" });
                players.Add(player);
            }
            randomPlayerNum = 0;
            while (posCounter[2] < 100)
            {
                player player = getRandomSmallForward("", randomPlayerNum++, true);
                player.age = r.Next(20, 30);
                posCounter[2]++;
                listOfPlayers.Rows.Add(new object[] { player.getName(), "None" });
                players.Add(player);
            }
            randomPlayerNum = 0;
            while (posCounter[3] < 100)
            {
                player player = getRandomShootingGuard("", randomPlayerNum++, true);
                player.age = r.Next(20, 30);
                posCounter[3]++;
                listOfPlayers.Rows.Add(new object[] { player.getName(), "None" });
                players.Add(player);
            }
            randomPlayerNum = 0;
            while (posCounter[4] < 100)
            {
                player player = getRandomPointGuard("", randomPlayerNum++,true);
                player.age = r.Next(20, 30);
                posCounter[4]++;
                listOfPlayers.Rows.Add(new object[] { player.getName(), "None" });
                players.Add(player);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            draft newDraft = new draft(true, players, teams, humanTeams, r);
            this.Visible = false;
            newDraft.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            teamPicker picker = new teamPicker(teams, false);
            picker.ShowDialog();
            team teamOne = picker.getFirstTeam();
            humanTeams.Add(teams.IndexOf(teamOne));
        }

        private void teamSave_Click(object sender, EventArgs e)
        {
            team teamToSave = teams[listOfTeams.SelectedRows[0].Index];
            SerializeObject(teamToSave, teamToSave.ToString() + ".fbteam");

        }
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public void SerializeObject(object serializableObject, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, serializableObject);
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


        /// <summary>
        /// Deserializes a binary file into an object list
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <returns></returns>
        public createTeams DeSerializeObject(string fileName)
        {
            createTeams temp = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream(fileName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                temp = (createTeams)formatter.Deserialize(fs);
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

        /// <summary>
        /// Deserializes a binary file into an object list
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <returns></returns>
        public team DeSerializeTeam(string fileName)
        {
            team temp = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream(fileName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                temp = (team)formatter.Deserialize(fs);
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

        private void teamLoad_Click(object sender, EventArgs e)
        {

        }

        private void playerSave_Click(object sender, EventArgs e)
        {
            player playerToSave = players[listOfPlayers.SelectedRows[0].Index];
            SerializeObject(playerToSave, playerToSave.getName() + ".fbplayer");
        }

        private void playerLoad_Click(object sender, EventArgs e)
        {

        }
    }
}

