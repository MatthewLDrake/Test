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
    public partial class PlayerEditor : Form
    {
        private player p;
        private double[] ratings, maxRatings;
        private static ExtraInfo extraScreen;
        public PlayerEditor(player p)
        {
            this.p = p;
            
            p.endSeason();

            if(extraScreen == null)
            {
                extraScreen = new ExtraInfo();
                extraScreen.Show();
            }
            extraScreen.SetPlayer(p);
            extraScreen.Visible = true;

            ratings = new double[10];
            maxRatings = new double[10];

            ratings[9] = p.getStaminaRating(false);
            maxRatings[9] = p.getStaminaRating(false);

            InitializeComponent();

            int minMax = 0, maxMax = 0;

            int ageDiff = p.GetPeakStart() - p.age;

            if (ageDiff > 0)
            {
                minMax = ageDiff + (int)Math.Round(1.25 * p.development);
                maxMax = minMax + (int)Math.Round(2.75 * p.development);
            }


            insideScoringTrack.Value = (int)Math.Min(150, Math.Max(p.ratings[0], p.ratings[1]));
            maxInsideScoringTrack.Value = Math.Min(150, (int)Math.Max(p.ratings[0], p.ratings[1]) + League.r.Next(minMax, maxMax));           

            jumpShotTrack.Value = (int)Math.Min(150, p.ratings[2]);
            maxJumpShotTrack.Value = (int)Math.Min(150, p.ratings[2] + League.r.Next(minMax, maxMax));

            threePointTrack.Value = (int)Math.Min(150, p.ratings[9]);
            maxThreePointTrack.Value = (int)Math.Min(150, p.ratings[9] + League.r.Next(minMax, maxMax));

            offenseIQTrack.Value = (int)Math.Min(150, (((p.ratings[4] + (p.ratings[5] + p.ratings[7]) / 2 + p.ratings[6]) / 3)));
            maxOffenseIQTrack.Value = (int)Math.Min(150, ((p.ratings[4] + (p.ratings[5] + p.ratings[7]) / 2 + p.ratings[6]) / 3) + League.r.Next(minMax, maxMax));

            defenseIQTrack.Value = (int)Math.Min(150, p.ratings[4]);
            maxDefenseIQTrack.Value = (int)Math.Min(150, p.ratings[4] + League.r.Next(minMax, maxMax));
            
            shotContestTrack.Value = (int)Math.Min(150, p.ratings[3]);
            maxShotContestTrack.Value = (int)Math.Min(150, p.ratings[3] + League.r.Next(minMax, maxMax));
            
            jumpingTrack.Value = (int)Math.Min(150, p.ratings[5]);
            maxJumpingTrack.Value = (int)Math.Min(150, p.ratings[5] + League.r.Next(minMax, maxMax));

            seperationTrack.Value = (int)Math.Min(150, p.ratings[6]);
            maxSeperationTrack.Value = (int)Math.Min(150, p.ratings[6] + League.r.Next(minMax, maxMax));

            passingTrack.Value = (int)Math.Min(150, p.ratings[7]);
            maxPassingTrack.Value = (int)Math.Min(150, p.ratings[7] + League.r.Next(minMax, maxMax));
            

            UpdateOveralls();

        }
        private void UpdateOveralls()
        {
            switch(p.getPosition())
            {
                case 1:
                    currentOverall.Text = "" + GetRatingAsCenter(ratings);
                    maxOverall.Text = "" + GetRatingAsCenter(maxRatings);
                    break;
                case 2:
                    currentOverall.Text = "" + GetRatingAsPowerForward(ratings);
                    maxOverall.Text = "" + GetRatingAsPowerForward(maxRatings);
                    break;
                case 3:
                    currentOverall.Text = "" + GetRatingAsSmallForward(ratings);
                    maxOverall.Text = "" + GetRatingAsSmallForward(maxRatings);
                    break;
                case 4:
                    currentOverall.Text = "" + GetRatingAsShootingGuard(ratings);
                    maxOverall.Text = "" + GetRatingAsShootingGuard(maxRatings);
                    break;
                case 5:
                    currentOverall.Text = "" + GetRatingAsPointGuard(ratings);
                    maxOverall.Text = "" + GetRatingAsPointGuard(maxRatings);
                    break;
            }
        }
        /*
        * Ratings: 
        * 
        * ratings[0] = inside
        * ratings[1] = jumpshot
        * ratings[2] = three point
        * ratings[3] = offense iq
        * ratings[4] = defense iq
        * ratings[5] = shot contest
        * ratings[6] = jumping
        * ratings[7] = seperation
        * ratings[8] = passing
        * ratings[9] = stamina
        * ratings[10] = durability
        */
        private void doneButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            p.EditRatings(new double[] {ratings[0], ratings[0], ratings[1], ratings[5], ratings[4], ratings[6], ratings[7], ratings[8], p.getStaminaRating(false), ratings[2], p.getDurabilityRating(false) }, maxRatings);
            extraScreen.Visible = false;
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            p.EditRatings(new double[] { ratings[0], ratings[0], ratings[1], ratings[5], ratings[4], ratings[6], ratings[7], ratings[8], p.getStaminaRating(false), ratings[2], p.getDurabilityRating(false) }, maxRatings);
            extraScreen.Visible = false;
            Close();
        }

        private double GetRatingAsCenter(double[] ratings)
        {
            double retVal = ratings[0] * 1.5;
            retVal += ratings[1] * 0.7;
            retVal += ratings[2] * 0.5;
            retVal += ratings[3] * 1.3;
            retVal += ratings[4] * 1.3;
            retVal += ratings[5] * 1.3;
            retVal += ratings[6] * 1.5;
            retVal += ratings[7] * 1;
            retVal += ratings[8] * 0.4;
            retVal += ratings[9] * 0.5;            

            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);

            return retVal;
        }
       
        private double GetRatingAsPowerForward(double[] ratings)
        {
            double retVal = ratings[0] * 1.3;
            retVal += ratings[1] * 0.8;
            retVal += ratings[2] * 0.6;
            retVal += ratings[3] * 1.3;
            retVal += ratings[4] * 1.3;
            retVal += ratings[5] * 1.3;
            retVal += ratings[6] * 1.2;
            retVal += ratings[7] * 1;
            retVal += ratings[8] * 0.7;
            retVal += ratings[9] * 0.5;

          
            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);

            return retVal;
        }
        
        private double GetRatingAsSmallForward(double[] ratings)
        {
            double retVal = ratings[0] * 1.2;
            retVal += ratings[1] * 1.2;
            retVal += ratings[2] * 0.8;
            retVal += ratings[3] * 1.3;
            retVal += ratings[4] * 1.3;
            retVal += ratings[5] * 1.3;
            retVal += ratings[6] * 0.6;
            retVal += ratings[7] * 1;
            retVal += ratings[8] * 0.8;
            retVal += ratings[9] * 0.5;           

            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);

            return retVal;
        }
        
        private double GetRatingAsShootingGuard(double[] ratings)
        {
            double retVal = ratings[0] * 0.8;
            retVal += ratings[1] * 1.2;
            retVal += ratings[2] * 1.1;
            retVal += ratings[3] * 1.3;
            retVal += ratings[4] * 1.3;
            retVal += ratings[5] * 1.3;
            retVal += ratings[6] * 0.5;
            retVal += ratings[7] * 1;
            retVal += ratings[8] * 1;
            retVal += ratings[9] * 0.5;

            retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);

            return retVal;
        }
        private double GetRatingAsPointGuard(double[] ratings)
        {
            double retVal = ratings[0] * 0.7;
            retVal += ratings[1] * 1.1;
            retVal += ratings[2] * 1.1;
            retVal += ratings[3] * 1.3;
            retVal += ratings[4] * 1.3;
            retVal += ratings[5] * 1.3;
            retVal += ratings[6] * 0.3;
            retVal += ratings[7] * 1;
            retVal += ratings[8] * 1.4;
            retVal += ratings[9] * 0.5;

            retVal = Math.Min(99.99, ((retVal / 10) / 100) * 100);

            return retVal;
        }

        private void insideScoringTrack_ValueChanged(object sender, EventArgs e)
        {
            insideScoringLabel.Text = "" + insideScoringTrack.Value;
            ratings[0] = insideScoringTrack.Value;
            UpdateOveralls();
        }

        private void maxInsideScoringTrack_ValueChanged(object sender, EventArgs e)
        {
            maxInsideScoringLabel.Text = "" + maxInsideScoringTrack.Value;
            maxRatings[0] = maxInsideScoringTrack.Value;
            UpdateOveralls();
        }

        private void jumpShotTrack_ValueChanged(object sender, EventArgs e)
        {
            jumpShotLabel.Text = "" + jumpShotTrack.Value;
            ratings[1] = jumpShotTrack.Value;
            UpdateOveralls();
        }

        private void maxJumpShotTrack_ValueChanged(object sender, EventArgs e)
        {
            maxJumpShotLabel.Text = "" + maxJumpShotTrack.Value;
            maxRatings[1] = maxJumpShotTrack.Value;
            UpdateOveralls();
        }

        private void threePointTrack_ValueChanged(object sender, EventArgs e)
        {
            threePointLabel.Text = "" + threePointTrack.Value;
            ratings[2] = threePointTrack.Value;
            UpdateOveralls();
        }

        private void maxThreePointTrack_ValueChanged(object sender, EventArgs e)
        {
            maxThreePointLabel.Text = "" + maxThreePointTrack.Value;
            maxRatings[2] = maxThreePointTrack.Value;
            UpdateOveralls();
        }

        private void offenseIQTrack_ValueChanged(object sender, EventArgs e)
        {
            offenseIQLabel.Text = "" + offenseIQTrack.Value;
            ratings[3] = offenseIQTrack.Value;
            UpdateOveralls();

        }

        private void maxOffenseIQTrack_ValueChanged(object sender, EventArgs e)
        {
            maxOffenseIQLabel.Text = "" + maxOffenseIQTrack.Value;
            maxRatings[3] = maxOffenseIQTrack.Value;
            UpdateOveralls();
        }

        private void defenseIQTrack_ValueChanged(object sender, EventArgs e)
        {
            defenseIQLabel.Text = "" + defenseIQTrack.Value;
            ratings[4] = defenseIQTrack.Value;
            offenseIQTrack.Value = (int)((ratings[4] + ratings[7] + (ratings[6] + ratings[8]) / 2) / 3);
            UpdateOveralls();

        }

        private void maxDefenseIQTrack_ValueChanged(object sender, EventArgs e)
        {
            maxDefenseIQLabel.Text = "" + maxDefenseIQTrack.Value;
            maxRatings[4] = maxDefenseIQTrack.Value;
            UpdateOveralls();
        }

        private void shotContestTrack_ValueChanged(object sender, EventArgs e)
        {
            shotContestLabel.Text = "" + shotContestTrack.Value;
            ratings[5] = shotContestTrack.Value;
            UpdateOveralls();

        }

        private void maxShotContestTrack_ValueChanged(object sender, EventArgs e)
        {
            maxShotContestLabel.Text = "" + maxShotContestTrack.Value;
            maxRatings[5] = maxShotContestTrack.Value;
            UpdateOveralls();

        }

        private void jumpingTrack_ValueChanged(object sender, EventArgs e)
        {
            jumpingLabel.Text = "" + jumpingTrack.Value;
            ratings[6] = jumpingTrack.Value;
            offenseIQTrack.Value = (int)((ratings[4] + ratings[7] + (ratings[6] + ratings[8]) / 2) / 3);
            UpdateOveralls();
        }

        private void maxJumpingTrack_ValueChanged(object sender, EventArgs e)
        {
            maxJumpingLabel.Text = "" + maxJumpingTrack.Value;
            maxRatings[6] = maxJumpingTrack.Value;
            UpdateOveralls();
        }

        private void seperationTrack_ValueChanged(object sender, EventArgs e)
        {
            seperationLabel.Text = "" + seperationTrack.Value;
            ratings[7] = seperationTrack.Value;
            offenseIQTrack.Value = (int)((ratings[4] + ratings[7] + (ratings[6] + ratings[8]) / 2) / 3);
            UpdateOveralls();

        }

        private void maxSeperationTrack_ValueChanged(object sender, EventArgs e)
        {
            maxSeperationLabel.Text = "" + maxSeperationTrack.Value;
            maxRatings[7] = maxSeperationTrack.Value;
            UpdateOveralls();
        }

        private void passingTrack_ValueChanged(object sender, EventArgs e)
        {
            passingLabel.Text = "" + passingTrack.Value;
            ratings[8] = passingTrack.Value;
            offenseIQTrack.Value = (int)((ratings[4] + ratings[7] + (ratings[6] + ratings[8]) / 2) / 3);
            UpdateOveralls();

        }

        private void maxPassingTrack_ValueChanged(object sender, EventArgs e)
        {
            maxPassingLabel.Text = "" + maxPassingTrack.Value;
            maxRatings[8] = maxPassingTrack.Value;
            UpdateOveralls();
        }

        
    }
}
