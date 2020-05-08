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
    public partial class CreatePlayer : Form
    {
        private player player;
        private DataGridViewCell dataGridViewCell;

        public CreatePlayer(List<team> teams)
        {            
            InitializeComponent();
            foreach (team team in teams)
            {
                comboBox1.Items.Add(team.ToString());
            }
        }

        public CreatePlayer(List<team> teams, player player, int startTeam)
        {
            InitializeComponent();
            foreach (team team in teams)
            {
                comboBox1.Items.Add(team.ToString());
            }
            comboBox1.SelectedIndex = startTeam;

            this.player = player;
            position.Text = "" + player.getPosition();
            layup.Text = "" + player.getLayupRating();
            dunk.Text = "" + player.getDunkRating();
            jumpShot.Text = "" + player.getJumpShotRating();
            threePoint.Text = "" + player.getThreeShotRating();
            passing.Text = "" + player.getPassing();
            shotContest.Text = "" + player.getShotContestRating();
            defenseIQ.Text = "" + player.getDefenseIQRating();
            jumping.Text = "" + player.getJumpingRating();
            seperation.Text = "" + player.getSeperation();
            stamina.Text = "" + player.getStaminaRating();
            durability.Text = "" + player.getDurabilityRating();
            if (player.isStarter()) isStarter.Checked = true;
            else isStarter.Checked = false;

            name.Text = player.getName();
        }

        public player getNewPlayer()
        {
            return player;
        }
        public int getTeam()
        {
            return comboBox1.SelectedIndex;
        }
        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)(Keys.Back));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pos;
            int layupStat;
            int dunkStat;
            int jumpStat;
            int threePoint;
            int passing;
            int shotContest;
            int defenseIQ;
            int jumping;
            int seperation;
            int stamina;
            int durability;
            try
            {
                pos = Int32.Parse(position.Text);
                if(pos <= 0 || pos >= 6)
                {
                    MessageBox.Show("Position must be between 1 and 5. 1 = Center, 2 = Power Forward, 3 = Small Forward, 4 = Shooting Guard, 5 = Point Guard");
                    return;
                }
                layupStat = Int32.Parse(this.layup.Text);
                if (layupStat <= 0 || layupStat >= 11)
                {
                    MessageBox.Show("Layup must be between 1 and 10.");
                    return;
                }
                dunkStat = Int32.Parse(this.dunk.Text);
                if (dunkStat <= 0 || dunkStat >= 11)
                {
                    MessageBox.Show("Dunk must be between 1 and 10.");
                    return;
                }
                jumpStat = Int32.Parse(this.jumpShot.Text);
                if (jumpStat <= 0 || jumpStat >= 11)
                {
                    MessageBox.Show("Jump Shot must be between 1 and 10.");
                    return;
                }
                threePoint = Int32.Parse(this.threePoint.Text);
                if (threePoint <= 0 || threePoint >= 11)
                {
                    MessageBox.Show("Three Point must be between 1 and 10.");
                    return;
                }
                passing = Int32.Parse(this.passing.Text);
                if (passing <= 0 || passing >= 11)
                {
                    MessageBox.Show("Passing must be between 1 and 10.");
                    return;
                }
                shotContest = Int32.Parse(this.shotContest.Text);
                if (shotContest <= 0 || shotContest >= 11)
                {
                    MessageBox.Show("Shot Contest must be between 1 and 10.");
                    return;
                }
                defenseIQ = Int32.Parse(this.defenseIQ.Text);
                if (defenseIQ <= 0 || defenseIQ >= 11)
                {
                    MessageBox.Show("Defense IQ must be between 1 and 10.");
                    return;
                }
                jumping = Int32.Parse(this.jumping.Text);
                if (jumping <= 0 || jumping >= 11)
                {
                    MessageBox.Show("Jumping must be between 1 and 10.");
                    return;
                }
                seperation = Int32.Parse(this.seperation.Text);
                if (seperation <= 0 || seperation >= 11)
                {
                    MessageBox.Show("Seperation must be between 1 and 10.");
                    return;
                }
                stamina = Int32.Parse(this.stamina.Text);
                if (stamina <= 0 || stamina >= 11)
                {
                    MessageBox.Show("Stamina must be between 1 and 10.");
                    return;
                }
                durability = Int32.Parse(this.durability.Text);
                if (durability <= 0 || durability >= 11)
                {
                    MessageBox.Show("Durability must be between 1 and 10.");
                    return;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Please ensure all ratings are only numbers.");
                return;
            }
            

            bool starting = isStarter.Checked;
            player = new player(pos, layupStat, dunkStat, jumpStat,threePoint, passing, shotContest, defenseIQ, jumping, seperation, durability, stamina, name.Text, starting);
            this.Close();
        }
    }
}
