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
    public partial class PlayerRatings : Form
    {
        private player p;
        public PlayerRatings(player p)
        {
            InitializeComponent();
            this.p = p;
            p.setDefensiveModifier(0);
            p.setOtherModifier(0);
            p.setShootingModifier(0);
            p.setStamina(100);

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
            dataGridView1.Rows.Add("Layup Rating", p.getLayupRating(false));
            dataGridView1.Rows.Add("Dunk Rating", p.getDunkRating(false));
            dataGridView1.Rows.Add("Jumpshot Rating", p.getJumpShotRating(false));
            dataGridView1.Rows.Add("Three Point Rating", p.getThreeShotRating(false));
            dataGridView1.Rows.Add("Shot Contest Rating", p.getShotContestRating(false));
            dataGridView1.Rows.Add("Defense IQ Rating", p.getDefenseIQRating(false));
            dataGridView1.Rows.Add("Jumping Rating", p.getJumpingRating(false));
            dataGridView1.Rows.Add("Seperation Rating", p.getSeperation(false));
            dataGridView1.Rows.Add("Passing Rating", p.getPassing(false));
            dataGridView1.Rows.Add("Stamina Rating", p.getStaminaRating(false));
            dataGridView1.Rows.Add("Durability Rating", p.getDurabilityRating(false));
        }
    }
}
