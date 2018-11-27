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
    public partial class Standings : Form
    {

        public Standings()
        {
            InitializeComponent();
        }

        public void updateStandings(createTeams create)
        {
            List<team> divisionA = new List<team>();
            List<team> divisionB = new List<team>();
            List<team> divisionC = new List<team>();
            List<team> divisionD = new List<team>();
            for (int i = 0; i < 8; i++)
            {
                divisionA.Add(create.getTeam(i));
                divisionB.Add(create.getTeam(i + 8));
                divisionC.Add(create.getTeam(i + 16));
                divisionD.Add(create.getTeam(i + 24));
            }
            List<team> conferenceA = new List<team>();
            List<team> conferenceB = new List<team>();

            conferenceA.AddRange(divisionA);
            conferenceA.AddRange(divisionB);
            conferenceB.AddRange(divisionC);
            conferenceB.AddRange(divisionD);

            this.divisionA.setTeams(divisionA);
            this.divisionA.setLabel("Division A");
            this.divisionB.setTeams(divisionB);
            this.divisionB.setLabel("Division B");
            this.divisionC.setTeams(divisionC);
            this.divisionC.setLabel("Division C");
            this.divisionD.setTeams(divisionD);
            this.divisionD.setLabel("Division D");

            conferenceOne.setTeams(conferenceA);
            conferenceTwo.setTeams(conferenceB);

            conferenceOne.setLabel("Southern Conference");
            conferenceTwo.setLabel("Northern Conference");

        }

        private void doubleClick(object sender, EventArgs e)
        {
            Division division = (Division)sender;
            soloScreen solo = new soloScreen(division.getTeams(), division.getLabel());
            solo.ShowDialog();
        }

        public void SaveForm()
        {
            using (var bmp = new Bitmap(this.Width, this.Height))
            {
                this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save("images/standings.png");
            }
        }
    }
}
