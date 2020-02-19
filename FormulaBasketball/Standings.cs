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
        private createTeams create;
        public Standings(bool normalViewer)
        {
            InitializeComponent();
            checkBox1.Visible = !normalViewer;
            label1.Visible = normalViewer;
            label2.Visible = normalViewer;
        }

        public void updateStandings(createTeams create, bool main)
        {
            this.create = create;
            List<team> divisionA = new List<team>();
            List<team> divisionB = new List<team>();
            List<team> divisionC = new List<team>();
            List<team> divisionD = new List<team>();
            for (int i = 0; i < 8; i++)
            {
                divisionA.Add(main ? create.getTeam(i) : create.getTeam(i).GetAffiliate());
                divisionB.Add(main ? create.getTeam(i + 8) : create.getTeam(i + 8).GetAffiliate());
                divisionC.Add(main ? create.getTeam(i + 16) : create.getTeam(i + 16).GetAffiliate());
                divisionD.Add(main ? create.getTeam(i + 24) : create.getTeam(i + 24).GetAffiliate());
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

        public void SaveForm(string location)
        {
            using (var bmp = new Bitmap(this.Width, this.Height))
            {
                this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(location);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (create != null)
                updateStandings(create, !checkBox1.Checked);
        }
    }
}
