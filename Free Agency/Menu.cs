using ResigningPlayers;
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

namespace Free_Agency
{
    public partial class Menu : Form
    {
        private createTeams create;
        private team team;
        private FormulaBasketball.Random r;
        private int teamNum;
        public Menu(String fileName, int teamNum, FormulaBasketball.Random r)
        {
            InitializeComponent();
            create = DeSerializeObject(fileName);
            team = create.getTeam(teamNum);
            this.r = r;
            this.teamNum = teamNum;
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

        private void freeAgencyButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            create.getFreeAgents().Verify();
            FreeAgencyForm freeAgentForm = new FreeAgencyForm(create.getFreeAgents(), team, create);
            freeAgentForm.ShowDialog();
            this.Visible = true;
        }
       

        private void tradeButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            TradeForm freeAgentForm = new TradeForm(create, team, teamNum);
            freeAgentForm.ShowDialog();
            this.Visible = true;
        }

        private void resignPlayersButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ResignPlayers freeAgentForm = new ResignPlayers(create, team, r);
            freeAgentForm.ShowDialog();
            this.Visible = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void viewRoster_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ViewRoster freeAgentForm = new ViewRoster(team);
            freeAgentForm.ShowDialog();
            this.Visible = true;
        }

        private void viewDLeagueRoster_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ViewRoster freeAgentForm = new ViewRoster(team.GetAffiliate());
            freeAgentForm.ShowDialog();
            this.Visible = true;
        }
    }
}
