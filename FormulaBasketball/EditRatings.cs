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
    public partial class EditRatings : Form
    {
        private player p;
        public EditRatings(player p)
        {
            this.p = p;

            InitializeComponent();
            name.Text = p.getName();
            position.Text = "" + p.getPosition();
            position.Enabled = false;
            layup.Value = (decimal)p.getLayupRating(false);
            dunk.Value = (decimal)p.getDunkRating(false);
            jumpShot.Value = (decimal)p.getJumpShotRating(false);
            threePoint.Value = (decimal)p.getThreeShotRating(false);
            passing.Value = (decimal)p.getPassing(false);
            shotContest.Value = (decimal)p.getShotContestRating(false);
            defenseIQ.Value = (decimal)p.getDefenseIQRating(false);
            jumping.Value = (decimal)p.getJumpingRating(false);
            seperation.Value = (decimal)p.getSeperation(false);
            durability.Value = (decimal)p.getDurabilityRating(false);
            stamina.Value = (decimal)p.getStaminaRating(false);
        }
        /*
         * Ratings: 
         * 
         * ratings[0] = layup
         * ratings[1] = dunk
         * ratings[2] = jumpshot
         * ratings[3] = shot contest
         * ratings[4] = defense iq
         * ratings[5] = jumping
         * ratings[6] = seperation
         * ratings[7] = passing
         * ratings[8] = stamina
         * ratings[9] = threepoint
         * ratings[10] = durability
         */
        private void EditRatings_FormClosed(object sender, FormClosedEventArgs e)
        {
            p.ratings = new double[] {(int)layup.Value, (int)dunk.Value, (int)jumpShot.Value , (int)shotContest.Value , (int)defenseIQ.Value , (int)jumping.Value , (int)seperation.Value , (int)passing.Value , (int)stamina.Value , (int)threePoint.Value, (int) durability.Value };
            p.setName(name.Text);
        }
    }
}
