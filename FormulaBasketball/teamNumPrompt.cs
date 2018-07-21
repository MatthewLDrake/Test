using System;
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
    public partial class teamNumPrompt : Form
    {
        private int numTeams;
        private List<team> teams;
        private Random r;
        private string[] fileNames;
        public teamNumPrompt(FormulaBasketball.Random r)
        {
            fileNames = null;
            InitializeComponent();
            this.r = r;
            teams = new List<team>();
        }
        public Boolean hasLoaded()
        {
            return fileNames != null;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;

            numTeams = Int32.Parse((string)comboBox1.Items[comboBox1.SelectedIndex]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            
            for(int i = 0; i < numTeams; i ++)
            {
                newTeam newTeam = new newTeam(r);
                newTeam.ShowDialog();
                teams.Add(newTeam.getNewTeam());
            }

            this.Close();
        }
        public int getNumTeams()
        {
            return numTeams;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(numTeams == 100)
            {
                team newTeam = null;
                int i = 0;
                newTeam = new team("University of Pxalit'k'a", "UPX", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Sande Sitei", "USA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Kap'atŋpiri", "UKA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Futi'akep", "UFU", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Atapwa", "UAT", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Hinaika Oceanography Institute", "UHI", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Auspikitan", "UAU", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Alteus", "UAL", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Saelunavvk", "USA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Nausicaa", "UNA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);

                newTeam = new team("University of Noxium", "UNO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Prokax", "UPR", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Klanaxon", "UKL", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Naxda", "UNA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Sozaxon", "USO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Blanaxon", "UBL", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Autolik", "UAU", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Uxnua", "UUX", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Sovkagrad", "USO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Radugrad", "URA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);

                newTeam = new team("University of Sagua", "USA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Shigua", "USH", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Dongua", "UDO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Barsein", "UBA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Issamore", "UIS", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Antarion 2", "UAN", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Antarion 3", "UAN", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Nja", "UNJ", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Pentadominion 1", "UPE", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Pentadominion 2", "UPE", r); teams.Add(newTeam); newTeam.setTeamNum(i++);

                newTeam = new team("University of Shmupland 1", "USH", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Shmupland 2", "USH", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Shmupland 3", "USH", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Shmupland 4", "USH", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Shmupland 5", "USH", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Oasis City", "UOA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Sapphire Bay", "USA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Chromasheep Farm", "UCH", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Kaeshar 4", "UKA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Kaeshar 5", "UKA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);

                newTeam = new team("University of Lizabechai", "ULI", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Levikeana Solvae", "ULE", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Alieosia", "UAL", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Byisotia", "UBY", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Hkamnsi", "UHK", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Vrelinku", "UVR", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Lveinta", "ULV", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Nomvas", "UNO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Pyzus", "UPY", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Eastern Alveske", "UEA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);

                newTeam = new team("University of Quiita-Kyudosia", "UQU", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Svitharia", "USV", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Soniara", "USO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Kholka", "UKH", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Aavana", "UAA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Floria", "UFL", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Eirnvse", "UEI", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Venasul", "UVE", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Ncov Ntiajeb", "UNC", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Zhiwasen", "UZH", r); teams.Add(newTeam); newTeam.setTeamNum(i++);

                newTeam = new team("University of Vincent", "UVI", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Boltway", "UBO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Vigim", "UVI", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Arinis", "UAR", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Naskitrusk", "UNA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Stedro", "UST", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Tjedigar", "UTJ", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Oxtra", "UOX", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Herelle", "UHE", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Tri_National_Dominion 2", "UTN", r); teams.Add(newTeam); newTeam.setTeamNum(i++);

                newTeam = new team("University of Imperial Institute at Faehrenfall", "UIM", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Avura Aviation & Economics (A&E)", "UAV", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of University of Central Paradaniton", "UUN", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Chizait University", "UCH", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Imperial Institute at Levzent", "UIM", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Western University", "UWE", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Vikasa", "UVI", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Akarine", "UAK", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Ciulo", "UCI", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Yoka Tse", "UYO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);

                newTeam = new team("University of Protopolis", "UPR", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Biodry", "UBI", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Forssa", "UFO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Starrie", "UST", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Vatallus", "UVA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Pokoj", "UPO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Lumein", "ULU", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Seraphia", "USE", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Holykol", "UHO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Norkute", "UNO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);

                newTeam = new team("University of Ikkuvvuki", "UIK", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Fiik Lanki Akol", "UFI", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Yuofuan", "UYU", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Maxwmkakki", "UMA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Lnwm", "ULN", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Vikkada", "UVI", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Aahrus 1", "UAA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Aahrus 2", "UAA", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Bongatar 1", "UBO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);
                newTeam = new team("University of Bongatar 2", "UBO", r); teams.Add(newTeam); newTeam.setTeamNum(i++);

                Close();
            }
            else
            {
                for (int i = 0; i < numTeams; i++)
                {
                    String location = getRandomLocation();
                    team newTeam = new team(location + " " + getRandomNickname(), location.Substring(0, 3).ToUpper(), r);
                    teams.Add(newTeam);
                    newTeam.setTeamNum(i);
                }
                this.Close();

            }
            
        }
        public List<team> getTeams()
        {
            return teams;
        }

        private string getRandomLocation()
        {
            List<string> strings = new List<string>
            {
                "New York City",
                "Los Angeles",
                "Chicago",
                "Houston",
                "Phoenix",
                "Philadelphia",
                "San Antonio",
                "San Diego",
                "Dallas",
                "San Jose",
                "Austin",
                "Jacksonville",
                "San Francisco",
                "Columbus",
                "Indianapolis",
                "Fort Worth",
                "Charlotte",
                "Seattle",
                "Denver",
                "El Paso",
                "Washington",
                "Boston",
                "Detroit",
                "Nashville",
                "Memphis",
                "Portland",
                "Oklahoma City",
                "Las Vegas",
                "Louisville",
                "Baltimore",
                "Milwaukee",
                "Albuquerque",
                "Tucson",
                "Fresno",
                "Sacramento",
                "Mesa",
                "Kansas City",
                "Atlanta",
                "Long Beach",
                "Colorado Springs",
                "Raleigh",
                "Miami",
                "Virginia Beach",
                "Omaha",
                "Oakland",
                "Minneapolis",
                "Tulsa",
                "Arlington",
                "New Orleans",
                "Wichita",
                "Cleveland",
                "Tampa",
                "Bakersfield",
                "Aurora",
                "Honolulu",
                "Anaheim",
                "Santa Ana",
                "Corpus Christi",
                "Riverside",
                "Lexington",
                "St. Louis",
                "Stockton",
                "Pittsburgh",
                "St. Paul",
                "Cincinnati",
                "Anchorage",
                "Henderson",
                "Greensboro",
                "Plano",
                "Newark",
                "Lincoln",
                "Toledo",
                "Orlando",
                "Chula Vista",
                "Irvine",
                "Fort Wayne",
                "Jersey City",
                "Durham",
                "St. Petersburg",
                "Laredo",
                "Buffalo",
                "Madison",
                "Lubbock",
                "Chandler",
                "Scottsdale",
                "Glendale",
                "Reno",
                "Norfolk",
                "Winstonâ€“Salem",
                "North Las Vegas",
                "Irving",
                "Chesapeake",
                "Gilbert",
                "Hialeah",
                "Garland",
                "Fremont",
                "Baton Rouge",
                "Richmond",
                "Boise",
                "San Bernardino",
                "Spokane",
                "Des Moines",
                "Modesto",
                "Birmingham",
                "Tacoma",
                "Fontana",
                "Rochester",
                "Oxnard",
                "Moreno Valley",
                "Fayetteville",
                "Aurora",
                "Glendale",
                "Yonkers",
                "Huntington Beach",
                "Montgomery",
                "Amarillo",
                "Little Rock",
                "Akron",
                "Columbus",
                "Augusta",
                "Grand Rapids",
                "Shreveport",
                "Salt Lake City",
                "Huntsville",
                "Mobile",
                "Tallahassee",
                "Grand Prairie",
                "Overland Park",
                "Knoxville",
                "Port St. Lucie",
                "Worcester",
                "Brownsville",
                "Tempe",
                "Santa Clarita",
                "Newport News",
                "Cape Coral",
                "Providence",
                "Fort Lauderdale",
                "Chattanooga",
                "Rancho Cucamonga",
                "Oceanside",
                "Santa Rosa",
                "Garden Grove",
                "Vancouver",
                "Sioux Falls",
                "Ontario",
                "McKinney",
                "Elk Grove",
                "Jackson",
                "Pembroke Pines",
                "Salem",
                "Springfield",
                "Corona",
                "Eugene",
                "Fort Collins",
                "Peoria",
                "Frisco",
                "Cary",
                "Lancaster",
                "Hayward",
                "Palmdale",
                "Salinas",
                "Alexandria",
                "Lakewood",
                "Springfield",
                "Pasadena",
                "Sunnyvale",
                "Macon",
                "Pomona",
                "Hollywood",
                "Kansas City",
                "Escondido",
                "Clarksville",
                "Joliet",
                "Rockford",
                "Torrance",
                "Naperville",
                "Paterson",
                "Savannah",
                "Bridgeport",
                "Mesquite",
                "Killeen",
                "Syracuse",
                "McAllen",
                "Pasadena",
                "Bellevue",
                "Fullerton",
                "Orange",
                "Dayton",
                "Miramar",
                "Thornton",
                "West Valley City",
                "Olathe",
                "Hampton",
                "Warren",
                "Midland",
                "Waco",
                "Charleston",
                "Columbia",
                "Denton",
                "Carrollton",
                "Surprise",
                "Roseville",
                "Sterling Heights",
                "Murfreesboro",
                "Gainesville",
                "Cedar Rapids",
                "Visalia",
                "Coral Springs",
                "New Haven",
                "Stamford",
                "Thousand Oaks",
                "Concord",
                "Elizabeth",
                "Lafayette",
                "Kent",
                "Topeka",
                "Simi Valley",
                "Santa Clara",
                "Athens",
                "Hartford",
                "Victorville",
                "Abilene",
                "Norman",
                "Vallejo",
                "Berkeley",
                "Round Rock",
                "Ann Arbor",
                "Fargo",
                "Columbia",
                "Allentown",
                "Evansville",
                "Beaumont",
                "Odessa",
                "Wilmington",
                "Arvada",
                "Independence",
                "Provo",
                "Lansing",
                "El Monte",
                "Springfield",
                "Fairfield",
                "Clearwater",
                "Peoria",
                "Rochester",
                "Carlsbad",
                "Westminster",
                "West Jordan",
                "Pearland",
                "Richardson",
                "Downey",
                "Miami Gardens",
                "Temecula",
                "Costa Mesa",
                "College Station",
                "Elgin",
                "Murrieta",
                "Gresham",
                "High Point",
                "Antioch",
                "Inglewood",
                "Cambridge",
                "Lowell",
                "Manchester",
                "Billings",
                "Pueblo",
                "Palm Bay",
                "Centennial",
                "Richmond",
                "Ventura",
                "Pompano Beach",
                "North Charleston",
                "Everett",
                "Waterbury",
                "West Palm Beach",
                "Boulder",
                "West Covina",
                "Broken Arrow",
                "Clovis",
                "Daly City",
                "Lakeland",
                "Santa Maria",
                "Norwalk",
                "Sandy Springs",
                "Hillsboro",
                "Green Bay",
                "Tyler",
                "Wichita Falls",
                "Lewisville",
                "Burbank",
                "Greeley",
                "San Mateo",
                "El Cajon",
                "Jurupa Valley",
                "Rialto",
                "Davenport",
                "League City",
                "Edison",
                "Davie",
                "Las Cruces",
                "South Bend",
                "Vista",
                "Woodbridge",
                "Renton",
                "Lakewood",
                "San Angelo",
                "Clinton Township"
            };
            return strings[r.Next(0, strings.Count)];
        }

        public bool hasTeams()
        {
            return true;
        }

        private string getRandomNickname()
        {
            List<string> teamNames = new List<string>
            {
                "Eagles",
                "Tigers",
                "Bulldogs",
                "Panthers",
                "Wildcats",
                "Warriors",
                "Lions",
                "Indians",
                "Cougars",
                "Knights",
                "Mustangs",
                "Falcons",
                "Trojans",
                "Cardinals",
                "Vikings",
                "Pirates",
                "Raiders",
                "Rams",
                "Spartans",
                "Bears",
                "Hornets",
                "Patriots",
                "Hawks",
                "Crusaders",
                "Rebels",
                "Bobcats",
                "Saints",
                "Braves",
                "Blue Devils",
                "Titans",
                "Wolverines",
                "Jaguars",
                "Wolves",
                "Dragons",
                "Pioneers",
                "Chargers",
                "Rockets",
                "Huskies",
                "Red Devils",
                "Yellowjackets",
                "Chiefs",
                "Stars",
                "Comets",
                "Colts",
                "Lancers",
                "Rangers",
                "Broncos",
                "Giants",
                "Senators",
                "Bearcats",
                "Thunder",
                "Royals",
                "Storm",
                "Cowboys",
                "Cubs",
                "Cavaliers",
                "Golden Eagles",
                "Generals",
                "Owls",
                "Buccaneers",
                "Hurricanes",
                "Bruins",
                "Grizzlies",
                "Gators",
                "Bombers",
                "Red Raiders",
                "Flyers",
                "Lakers",
                "Miners",
                "Redskins",
                "Coyotes",
                "Longhorns",
                "Greyhounds",
                "Beavers",
                "Yellow Jackets",
                "Outlaws",
                "Reds",
                "Highlanders",
                "Sharks",
                "Oilers",
                "Jets",
                "Dodgers",
                "Mountaineers",
                "Red Sox",
                "Thunderbirds",
                "Blazers",
                "Clippers",
                "Aces",
                "Buffaloes",
                "Lightning",
                "Bluejays",
                "Gladiators",
                "Mavericks",
                "Monarchs",
                "Tornadoes",
                "Blues",
                "Cobras",
                "Bulls",
                "Express",
                "Stallions"
            };
            return teamNames[r.Next(0, teamNames.Count)];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFile = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                RestoreDirectory = true,
                Filter = "Formula Basketball Files (*.fbteam)|*.fbteam",
                Multiselect = true
            };

            loadFile.ShowDialog();

            fileNames = loadFile.FileNames;
            Close();

            
        }
        public string[] getFileNames()
        {
            return fileNames;
        }
    }
}
