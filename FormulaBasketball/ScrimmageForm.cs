using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class ScrimmageForm : Form
    {
        private createTeams create;
        private Random r;
        public ScrimmageForm(createTeams create, int teamNum)
        {
            InitializeComponent();
            this.create = create;
            this.r = new Random();
            foreach(team team in create.getTeams())
            {
                teamOneList.Items.Add(team.ToString());
                teamTwoList.Items.Add(team.ToString());
            }
            foreach (team team in create.getTeams())
            {
                teamOneList.Items.Add(team.GetAffiliate().ToString());
                teamTwoList.Items.Add(team.GetAffiliate().ToString());
            }
            teamOneList.SelectedIndex = teamNum;
            teamTwoList.SelectedIndex = teamNum == 0 ? 1 : 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            team copyTeam;
            if (teamOneList.SelectedIndex < 32)
                copyTeam = create.getTeam(teamOneList.SelectedIndex);
            else
                copyTeam = create.getTeam(teamOneList.SelectedIndex - 32).GetAffiliate();
            MemoryStream stream = SerializeTeam(copyTeam);

            team teamOne = DeSerializeTeam(stream);
            if (teamTwoList.SelectedIndex < 32)
                copyTeam = create.getTeam(teamTwoList.SelectedIndex);
            else
                copyTeam = create.getTeam(teamTwoList.SelectedIndex - 32).GetAffiliate();
            stream = SerializeTeam(copyTeam);
            team teamTwo = DeSerializeTeam(stream);

            

            new GameViewer(teamOne, teamTwo, r).ShowDialog();
        }

        public static MemoryStream SerializeTeam(team team)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter outFormatter = new BinaryFormatter();

            outFormatter.Serialize(stream, team);

            return stream;
        }
        public static team DeSerializeTeam(Stream stream)
        {
            BinaryFormatter inFormatter = new BinaryFormatter();
            stream.Position = 0;
            object t = inFormatter.Deserialize(stream);

            return t as team;
        }
    }
}
