
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
        public createTeams create;
        private team team;

        private FormulaBasketball.Random r;
        private int teamNum;
        public static List<int> humans;
        private int stage;
        private ResignPlayers resignForm;
        private FreeAgencyForm freeAgentForm;
        private bool master = true;
        private MyList<player> rookies;
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

            int temp = 1;

            foreach (team t in create.getTeams())
            {
                foreach (player p in t)
                {
                    p.StartOffseason();
                }
                foreach (player p in t.GetAffiliate())
                {
                    p.StartOffseason();
                }
            }

            List<player> retiringPlayers = new List<player>();
            foreach(team t in create.getTeams())
            {
                foreach(player p in t)
                {
                    p.addPlayerID(temp);
                    temp++;
                    if (p.GetPeakEnd() < p.age && r.Next(0,5) < 4)
                        retiringPlayers.Add(p);
                }
                foreach(player p in t.GetAffiliate())
                {
                    p.addPlayerID(temp);
                    temp++;
                    if (p.GetPeakStart() < p.age)
                        retiringPlayers.Add(p);
                }
            }
            foreach (player p in create.getFreeAgents().GetAllPlayers())
            {
                p.addPlayerID(temp);
                temp++;
                if (p.GetPeakStart() < p.age)
                    retiringPlayers.Add(p);
            }
            createTeams.nextID = temp;

            rookies = new MyList<player>();
            CollegePlayerGen playerGen = new CollegePlayerGen(r);
            rookies.Add(playerGen.GeneratePlayer(5, 46, Country.Wyverncliff, 3, 30, 32, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 58, Country.Wyverncliff, 4, 29, 32, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 60, Country.Shmupland, 2, 29, 32, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 56, Country.Oesa, 3, 31, 35, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 68, Country.Ethanthova, 6, 31, 35, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 50, Country.Darvincia, 4, 31, 32, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 46, Country.Czalliso, 3, 27, 28, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 45, Country.Lyintaria, 7, 29, 32, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 54, Country.Tri_National_Dominion, 5, 31, 35, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 64, Country.Dotruga, 7, 28, 31, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 79, Country.Bongatar, 6, 27, 28, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 65, Country.Sagua, 7, 27, 30, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 56, Country.Auspikitan, 7, 30, 31, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 45, Country.Bongatar, 6, 30, 31, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 52, Country.Aeridani, 6, 27, 28, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 44, Country.Czalliso, 6, 28, 30, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 50, Country.Dotruga, 5, 30, 32, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 64, Country.Dotruga, 4, 30, 32, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 49, Country.Blaist_Blaland, 5, 28, 30, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 66, Country.Ethanthova, 3, 29, 32, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 52, Country.Ethanthova, 3, 27, 29, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 65, Country.Dotruga, 7, 27, 29, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(5, 63, Country.Aeridani, 4, 29, 32, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 56, Country.Aeridani, 6, 31, 32, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 53, Country.Shmupland, 4, 27, 31, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 70, Country.Oesa, 8, 27, 31, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 61, Country.Bielosia, 7, 29, 30, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 77, Country.Dotruga, 4, 30, 34, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 57, Country.Aeridani, 6, 29, 33, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 76, Country.Transhimalia, 7, 27, 30, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 47, Country.Auspikitan, 5, 28, 32, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 52, Country.Oesa, 4, 31, 32, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 65, Country.Sagua, 6, 30, 31, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 59, Country.Wyverncliff, 6, 30, 34, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 53, Country.Pyxanovia, 2, 27, 29, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 51, Country.Tjedigar, 2, 30, 33, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 57, Country.Bongatar, 9, 33, 35, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 63, Country.Dotruga, 6, 28, 29, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 54, Country.Blaist_Blaland, 5, 29, 32, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 54, Country.Helvaena, 2, 28, 32, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 66, Country.Lyintaria, 6, 30, 33, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 65, Country.Solea, 4, 28, 32, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 48, Country.Solea, 5, 30, 31, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 60, Country.Bielosia, 7, 27, 30, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 59, Country.Dotruga, 3, 27, 29, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 32, Country.Wyverncliff, 5, 28, 29, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 63, Country.Height_Sagua, 6, 29, 33, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 57, Country.Ethanthova, 7, 31, 33, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(4, 31, Country.Dotruga, 7, 29, 33, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 51, Country.Wyverncliff, 7, 28, 32, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 68, Country.Auspikitan, 5, 29, 32, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 49, Country.Auspikitan, 5, 29, 30, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 55, Country.Darvincia, 5, 30, 33, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 44, Country.Pyxanovia, 4, 31, 35, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 38, Country.Tjedigar, 5, 28, 29, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 62, Country.Helvaena, 3, 31, 33, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 57, Country.Transhimalia, 4, 27, 31, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 58, Country.Solea, 5, 31, 32, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 65, Country.Darvincia, 3, 30, 32, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 57, Country.Transhimalia, 6, 27, 31, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 50, Country.Solea, 6, 31, 32, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 61, Country.Pyxanovia, 3, 29, 30, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 60, Country.Auspikitan, 6, 27, 30, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 55, Country.Shmupland, 6, 29, 33, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 53, Country.Aeridani, 6, 27, 31, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 56, Country.Aeridani, 6, 29, 33, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 65, Country.Norkute, 4, 28, 30, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 61, Country.Bielosia, 3, 27, 29, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 48, Country.Tri_National_Dominion, 5, 28, 30, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 64, Country.Height_Sagua, 7, 29, 30, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 54, Country.Auspikitan, 7, 28, 31, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 52, Country.Blaist_Blaland, 6, 27, 28, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 58, Country.Bongatar, 4, 31, 32, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 47, Country.Ethanthova, 5, 30, 34, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 47, Country.Tri_National_Dominion, 4, 27, 31, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 47, Country.Holykol, 8, 31, 34, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 44, Country.Bielosia, 6, 29, 32, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 70, Country.Holy_Yektonisa, 4, 28, 29, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 43, Country.Auspikitan, 5, 28, 32, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 62, Country.Wyverncliff, 6, 27, 28, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 64, Country.Sagua, 7, 30, 33, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 46, Country.Czalliso, 6, 27, 28, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 66, Country.Auspikitan, 5, 27, 29, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 75, Country.Solea, 4, 27, 29, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(3, 66, Country.Aiyota, 4, 31, 33, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 62, Country.Bielosia, 4, 28, 29, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 63, Country.Barsein, 3, 27, 28, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 62, Country.Wyverncliff, 9, 27, 29, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 61, Country.Tri_National_Dominion, 4, 28, 30, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 40, Country.Auspikitan, 3, 31, 32, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 65, Country.Pyxanovia, 4, 27, 28, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 62, Country.Blaist_Blaland, 5, 31, 32, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 44, Country.Kaeshar, 5, 30, 31, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 71, Country.Holykol, 6, 27, 29, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 54, Country.Dotruga, 5, 31, 32, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 59, Country.Bielosia, 5, 31, 34, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 54, Country.Wyverncliff, 5, 30, 31, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 51, Country.Ethanthova, 4, 31, 35, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 58, Country.Bongatar, 5, 28, 30, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 59, Country.Pyxanovia, 5, 30, 34, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 52, Country.Auspikitan, 6, 29, 33, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 65, Country.Ethanthova, 6, 30, 32, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 52, Country.Ethanthova, 6, 29, 31, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 68, Country.Transhimalia, 5, 29, 32, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 53, Country.Helvaena, 5, 28, 30, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 79, Country.Wyverncliff, 4, 29, 30, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 65, Country.Ethanthova, 8, 28, 30, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 57, Country.Transhimalia, 5, 27, 29, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 63, Country.Aeridani, 4, 29, 30, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 54, Country.Holykol, 7, 31, 34, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 72, Country.Bongatar, 3, 31, 32, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 44, Country.Aeridani, 6, 29, 33, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 75, Country.Dotruga, 6, 27, 30, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 60, Country.Timbalta, 7, 29, 30, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 48, Country.Bielosia, 3, 31, 35, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 52, Country.Solea, 3, 27, 28, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 48, Country.Tri_National_Dominion, 7, 29, 33, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 78, Country.Dotruga, 5, 27, 28, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 55, Country.Holy_Yektonisa, 5, 27, 31, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 49, Country.Bongatar, 3, 28, 32, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(2, 43, Country.Kaeshar, 6, 28, 29, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 66, Country.Ethanthova, 3, 27, 30, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 54, Country.Sagua, 5, 30, 34, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 44, Country.Pyxanovia, 4, 27, 31, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 61, Country.Czalliso, 5, 27, 31, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 64, Country.Aeridani, 7, 27, 28, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 64, Country.Bielosia, 6, 27, 31, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 57, Country.Bongatar, 5, 31, 35, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 63, Country.Solea, 3, 31, 34, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 52, Country.Darvincia, 8, 29, 33, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 48, Country.Dtersauuw_Sagua, 5, 30, 31, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 52, Country.Kaeshar, 7, 28, 32, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 82, Country.Ethanthova, 10, 30, 32, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 55, Country.Solea, 9, 29, 32, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 57, Country.Shmupland, 5, 29, 32, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 54, Country.Auspikitan, 7, 27, 28, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 56, Country.Oesa, 5, 27, 30, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 48, Country.Kaeshar, 6, 31, 33, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 66, Country.Tri_National_Dominion, 5, 29, 30, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 58, Country.Wyverncliff, 6, 28, 29, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 57, Country.Shmupland, 4, 30, 31, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 71, Country.Solea, 5, 30, 32, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 76, Country.Transhimalia, 6, 28, 31, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 72, Country.Oesa, 4, 27, 28, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 75, Country.Czalliso, 4, 29, 30, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 54, Country.Dtersauuw_Sagua, 1, 30, 31, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 62, Country.Holykol, 3, 30, 34, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 76, Country.Bongatar, 4, 31, 32, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 78, Country.Tri_National_Dominion, 6, 29, 33, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 60, Country.Holy_Yektonisa, 4, 27, 28, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 67, Country.Wyverncliff, 8, 30, 31, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 77, Country.Aeridani, 4, 29, 30, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 74, Country.Auspikitan, 6, 28, 31, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 66, Country.Transhimalia, 5, 31, 35, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 57, Country.Transhimalia, 5, 28, 29, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 46, Country.Bielosia, 2, 29, 33, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 73, Country.Kaeshar, 5, 30, 34, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 59, Country.Tri_National_Dominion, 5, 28, 31, false, 3, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 47, Country.Bongatar, 5, 30, 33, false, 2, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 68, Country.Wyverncliff, 3, 31, 34, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 56, Country.Aeridani, 4, 30, 32, false, 5, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 40, Country.Czalliso, 4, 28, 30, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 56, Country.Blaist_Blaland, 3, 31, 32, false, 4, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 65, Country.Bongatar, 6, 31, 34, false, 1, 0));
            rookies.Add(playerGen.GeneratePlayer(1, 76, Country.Pyxanovia, 6, 29, 30, false, 1, 0));

            
            foreach(player p in rookies)
            {
                p.addPlayerID(temp);
                temp++;
                p.IsRookie();
            }


            /*System.Threading.Thread thread = new System.Threading.Thread(LaunchFreeAgency);
            thread.Start();
            thread = new System.Threading.Thread(LaunchRoster);
            thread.Start();
            FreeAgentInfo info;
            FileStream fs = new FileStream("Solea_GeysersStage1.fbteam", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                info = (FreeAgentInfo)formatter.Deserialize(fs);
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
            team tempTeam = info.players[0].getTeam();
            foreach(player p in create.getTeam(7))
            {
                if(p.GetYearsLeft() <= 0)
                {
                    foreach(player player in tempTeam)
                    {
                        if(p.getName().Equals(player.getName()))
                        {
                            p.SetNewContract(new Contract(player.GetYearsLeft(), player.GetMoneyPerYear(), 0, player.GetBonus(), player.GetPromises()));
                        }
                    }
                }
            }
            fs = new FileStream("Dotruga_FalnoStage1.fbteam", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                info = (FreeAgentInfo)formatter.Deserialize(fs);
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
            tempTeam = info.players[0].getTeam();
            foreach (player p in create.getTeam(19))
            {
                if (p.GetYearsLeft() <= 0)
                {
                    foreach (player player in tempTeam)
                    {
                        if (p.getName().Equals(player.getName()))
                        {
                            p.SetNewContract(new Contract(player.GetYearsLeft(), player.GetMoneyPerYear(), 0, player.GetBonus(), player.GetPromises()));
                        }
                    }
                }
            }
            FileStream createFS = new FileStream("NextSeason.fbdata", FileMode.Create);

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
            }*/

            
            foreach(player p in retiringPlayers)
            {
                Console.WriteLine(p.getName() + " is retiring");
            }
        }
        private void LaunchRoster()
        {
            new FreeAgencyForm(create.getFreeAgents(), create.getTeam(2), create).ShowDialog();
        }
        private void LaunchFreeAgency()
        {
            new LeagueRoster(new List<int>(), create).ShowDialog();
        }
        private void Contruct()
        {
            menu = this;
            mvpVotes = new Dictionary<int, int>();
            rotyVotes = new Dictionary<int, int>();
            cotyVotes = new Dictionary<int, int>();

            events = new List<Event>();
           
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
                    pick.SetOwner(t);
                }
                foreach (DraftPick pick in t.GetNextSeasonPicks())
                {
                    pick.SetOwner(t);
                }
                if(t.ToString().Equals("Serkr Atolls"))
                {
                    DraftPick correct = null;
                    foreach(DraftPick pick in t.GetNextSeasonPicks())
                    {
                        if (pick.GetOwner().Equals(t) && pick.GetRound() == 2)
                        {
                            correct = pick;
                            break;
                        }
                    }
                    t.GetNextSeasonPicks().Remove(correct);
                    t.GetPicks().Add(correct);
                }
                if (t.GetDraftPlace() < 10) t.DraftStrategy = DraftStrategy.REBUILD;
                else if (t.GetDraftPlace() < 20) t.DraftStrategy = DraftStrategy.WIN_SOON;
                else t.DraftStrategy = DraftStrategy.WIN_NOW;

                t.StartOffSeason();

                

            }
            //create.getFreeAgents().AdvanceSeason();
            //rookies = create.GetRookies();

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
                TradeForm tradeForm = new TradeForm(create, team, teamNum, master);
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
                        VoteROTY();
                        

                        MessageBox.Show(mvp.getName() + " of " + mvp.getTeam() + " wins the MVP!\n");
                        MessageBox.Show(roty.getName() + " of " + roty.getTeam() + " wins the MVP!\n");

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
                        List<Dictionary<int, Contract>> offers = new List<Dictionary<int, Contract>>();
                        List<team> teams = new List<team>();
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
                            //create.getFreeAgents().UpdateOffers(temp.GetOffers(), temp);
                            offers.Add(temp.GetOffers());
                            teamNumbers.Add(temp.getTeamNum());
                            teams.Add(temp);

                            

                        }
                        teams.Add(team);
                        offers.Add(team.GetOffers());
                        create.getFreeAgents().UpdateOffers(offers, teams);
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
                        OffseasonFreeAgentForm form = new OffseasonFreeAgentForm(create.getFreeAgents(), create, humans);
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
                    if (master)
                    {

                        create.FinishOffseason(humans);

                        FileStream createFS = new FileStream("NextSeason.fbdata", FileMode.Create);

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
                    }
                    MessageBox.Show("File Saved");
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Open Formula Basketball File";
            fileDialog.Filter = "FBData files (*.fbdata)|*.fbdata|FBTrade files (*.fbtrade)|*.fbtrade|FB Trade Response File (*.fbtr)|*.fbtr";
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
                        OfferedTrade offer = new OfferedTrade(trade, create);
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
                    freeAgentForm = null;
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
            playerList.Remove(mvp);
            player runnerUp = FindBest(playerList, mvpVotes);
            playerList.Remove(runnerUp);
            player thirdPlace = FindBest(playerList, mvpVotes);

            events.Add(new Event("MVP Voting Complete", "The MVP was decided, with " + mvp.getName() + " of the " + mvp.getTeam() + " winning the MVP! " + runnerUp.getName() + " of the " + runnerUp.getTeam() + " was the runner up and " + thirdPlace.getName() + " of the " + thirdPlace.getTeam() + " came in third."));
            eventViewer.AddEvent(events[events.Count - 1]);
            UpdatedEvents();
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
            playerList.Remove(roty);
            player runnerUp = FindBest(playerList, rotyVotes);
            playerList.Remove(runnerUp);
            player thirdPlace = FindBest(playerList, rotyVotes);

            events.Add(new Event("ROTY Voting Complete", "The ROTY was decided, with " + roty.getName() + " of the " + roty.getTeam() + " winning the MVP! " + runnerUp.getName() + " of the " + runnerUp.getTeam() + " was the runner up and " + thirdPlace.getName() + " of the " + thirdPlace.getTeam() + " came in third."));
            eventViewer.AddEvent(events[events.Count - 1]);
            UpdatedEvents();
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
