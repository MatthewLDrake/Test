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
    public partial class NewPlayerEditor : Form
    {
        private NewPlayer p;
        private byte[] ratings, maxRatings;
        private static ExtraInfo extraScreen;
        public NewPlayerEditor(NewPlayer p, double overall, bool goDown, byte[] maxRatingsBoost)
        {
            this.p = p;
            maxRatings = p.maxRatings;

            if(!goDown)
            {
                p.ratings = UpdateUntil(overall, p.ratings, p.GetPosition(), true, maxRatings, maxRatingsBoost);
            }
            else
            {
                p.ratings = DowndateUntil(overall, p.ratings);
            }
            InitializeComponent();
            //Setup();
            
        }
        public NewPlayerEditor(NewPlayer p, double overall = -1, double maxOverall = -1)
        {
            this.p = p;

            if (overall != -1)
                p.ratings = UpdateUntil(overall, p.ratings, p.GetPosition());
            if (maxOverall != -1)
            {
                for(int i =0; i < p.ratings.Length; i++)
                {
                    if(p.ratings[i] > p.maxRatings[i])
                    {
                        p.maxRatings[i] = (byte)(p.ratings[i] + League.r.Next(3,10));
                    }
                }
                p.maxRatings = UpdateUntil(maxOverall, p.maxRatings, p.GetPosition());
            }

            InitializeComponent();
            Setup();
        }
        private void Setup()
        {
            if (extraScreen == null)
            {
                extraScreen = new ExtraInfo();
                extraScreen.Show();
            }
            extraScreen.SetPlayer(p);
            extraScreen.Visible = true;

            ratings = new byte[11];
            maxRatings = new byte[11];

            ratings[9] = p.ratings[9];
            maxRatings[9] = p.maxRatings[9];

            ratings[10] = p.ratings[10];
            maxRatings[10] = maxRatings[10];

            insideScoringTrack.Value = p.ratings[0];
            maxInsideScoringTrack.Value = p.maxRatings[0];

            jumpShotTrack.Value = p.ratings[1];
            maxJumpShotTrack.Value = p.maxRatings[1];

            threePointTrack.Value = p.ratings[2];
            maxThreePointTrack.Value = p.maxRatings[2];

            offenseIQTrack.Value = p.ratings[3];
            maxOffenseIQTrack.Value = p.maxRatings[3];

            defenseIQTrack.Value = p.ratings[4];
            maxDefenseIQTrack.Value = p.maxRatings[4];

            shotContestTrack.Value = p.ratings[5];
            maxShotContestTrack.Value = p.maxRatings[5];

            jumpingTrack.Value = p.ratings[6];
            maxJumpingTrack.Value = p.maxRatings[6];

            seperationTrack.Value = p.ratings[7];
            maxSeperationTrack.Value = p.maxRatings[7];

            passingTrack.Value = p.ratings[8];
            maxPassingTrack.Value = p.maxRatings[8];


            UpdateOveralls();
        }
        public static byte[] UpdateUntil(double overall, byte[] ratings, int position, bool capAtMaxRating = false, byte[] maxRatings = null, byte[] maxRatingsBoost = null)
        {
            

            double theRating = 0;
            int[] liklihood = new int[10];
            switch (position)
            {
                case 1:
                    theRating = GetRatingAsCenter(ratings);
                    liklihood = new int[] { 20, 5, 4, 11, 10, 10, 15, 10, 5, 5, 5 };
                    break;
                case 2:
                    theRating = GetRatingAsPowerForward(ratings);
                    liklihood = new int[] { 15, 8, 7, 10, 10, 10, 13, 10, 7, 5, 5 };
                    break;
                case 3:
                    theRating = GetRatingAsSmallForward(ratings);
                    liklihood = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 5, 5, 5 };
                    break;
                case 4:
                    theRating = GetRatingAsShootingGuard(ratings);
                    liklihood = new int[] { 10, 13, 12, 10, 10, 10, 5, 10, 10, 5, 5 };
                    break;
                case 5:
                    theRating = GetRatingAsPointGuard(ratings);
                    liklihood = new int[] { 10, 10, 10, 10, 10, 10, 5, 10, 15, 5, 5 };
                    break;
            }



            bool flag = true;
            while (overall > theRating && flag)
            {
                int randNum = League.r.Next(100);
                int sum = 0;
                for(int i = 0; i < liklihood.Length; i++)
                {
                    if(liklihood[i] + sum > randNum)
                    {
                        if(!capAtMaxRating || ratings[i] < maxRatings[i] + maxRatingsBoost[i])
                            ratings[i]++;
                        else
                        {
                            flag = false;
                            for(int j = 0; j < ratings.Length; j++)
                            {
                                if (ratings[j] < maxRatings[j] + maxRatingsBoost[j])
                                {
                                    flag = true;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                    sum += liklihood[i];
                }

                switch (position)
                {
                    case 1:                        
                        theRating = GetRatingAsCenter(ratings, false);
                        break;
                    case 2:
                        theRating = GetRatingAsPowerForward(ratings, false);
                        break;
                    case 3:
                        theRating = GetRatingAsSmallForward(ratings, false);
                        break;
                    case 4:
                        theRating = GetRatingAsShootingGuard(ratings, false);
                        break;
                    case 5:
                        theRating = GetRatingAsPointGuard(ratings, false);
                        break;
                }
            }

            return ratings;
        }

        private byte[] DowndateUntil(double overall, byte[] ratings)
        {
            double theRating = 0;
            int[] liklihood = new int[10];
            switch (p.GetPosition())
            {
                case 1:
                    theRating = GetRatingAsCenter(ratings);
                    liklihood = new int[] { 10, 10, 10, 5, 5, 15, 25, 5, 5, 5 };
                    break;
                case 2:
                    theRating = GetRatingAsPowerForward(ratings);
                    liklihood = new int[] { 15, 10, 10, 5, 5, 15, 20, 5, 5, 5 };
                    break;
                case 3:
                    theRating = GetRatingAsSmallForward(ratings);
                    liklihood = new int[] { 12, 13, 15, 5, 5, 15, 10, 10, 5, 5 };
                    break;
                case 4:
                    theRating = GetRatingAsShootingGuard(ratings);
                    liklihood = new int[] { 12, 15, 15, 5, 5, 15, 8, 10, 5, 5 };
                    break;
                case 5:
                    theRating = GetRatingAsPointGuard(ratings);
                    liklihood = new int[] { 15, 15, 15, 5, 5, 10, 5, 10, 10, 5 };
                    break;
            }


            bool flag = true;
            while (overall < theRating && flag)
            {
                int randNum = League.r.Next(100);

                int sum = 0;
                for (int i = 0; i < liklihood.Length; i++)
                {
                    if (liklihood[i] + sum > randNum)
                    {
                        if(ratings[i] > 1)
                            ratings[i]--;
                        else
                        {
                            flag = false;
                            for (int j = 0; j < ratings.Length; j++)
                            {
                                if (ratings[i] > 1)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                    sum += liklihood[i];
                }

                switch (p.GetPosition())
                {
                    case 1:
                        theRating = GetRatingAsCenter(ratings, false);
                        break;
                    case 2:
                        theRating = GetRatingAsPowerForward(ratings, false);
                        break;
                    case 3:
                        theRating = GetRatingAsSmallForward(ratings, false);
                        break;
                    case 4:
                        theRating = GetRatingAsShootingGuard(ratings, false);
                        break;
                    case 5:
                        theRating = GetRatingAsPointGuard(ratings, false);
                        break;
                }
            }

            return ratings;
        }
        public static double GetMainOverall(int position, byte[] ratings)
        {
            double theRating = 0;
            switch (position)
            {
                case 1:
                    theRating = GetRatingAsCenter(ratings, false);
                    break;
                case 2:
                    theRating = GetRatingAsPowerForward(ratings, false);
                    break;
                case 3:
                    theRating = GetRatingAsSmallForward(ratings, false);
                    break;
                case 4:
                    theRating = GetRatingAsShootingGuard(ratings, false);
                    break;
                case 5:
                    theRating = GetRatingAsPointGuard(ratings, false);
                    break;
            }
            return theRating;
        }
        private void UpdateOveralls()
        {
            switch(p.GetPosition())
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
            p.ratings = ratings;
            p.maxRatings = maxRatings;
            extraScreen.Visible = false;
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            p.ratings = ratings;
            p.maxRatings = maxRatings;
            extraScreen.Visible = false;
            Close();
        }

        public static double GetRatingAsCenter(byte[] ratings, bool cap = true)
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

            if (cap)
                retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);
            else
                retVal = ((retVal / 10.5) / 100) * 100;

            return retVal;
        }

        public static double GetRatingAsPowerForward(byte[] ratings, bool cap = true)
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


            if (cap)
                retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);
            else
                retVal = ((retVal / 10.5) / 100) * 100;

            return retVal;
        }

        public static double GetRatingAsSmallForward(byte[] ratings, bool cap = true)
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

            if (cap)
                retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);
            else
                retVal = ((retVal / 10.5) / 100) * 100;

            return retVal;
        }

        public static double GetRatingAsShootingGuard(byte[] ratings, bool cap = true)
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

            if (cap)
                retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);
            else
                retVal = ((retVal / 10.5) / 100) * 100;

            return retVal;
        }
        public static double GetRatingAsPointGuard(byte[] ratings, bool cap = true)
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

            if (cap)
                retVal = Math.Min(99.99, ((retVal / 10.5) / 100) * 100);
            else
                retVal = ((retVal / 10.5) / 100) * 100;

            return retVal;
        }

        private void insideScoringTrack_ValueChanged(object sender, EventArgs e)
        {
            insideScoringLabel.Text = "" + insideScoringTrack.Value;
            ratings[0] = (byte)insideScoringTrack.Value;
            UpdateOveralls();
        }

        private void maxInsideScoringTrack_ValueChanged(object sender, EventArgs e)
        {
            maxInsideScoringLabel.Text = "" + maxInsideScoringTrack.Value;
            maxRatings[0] = (byte)maxInsideScoringTrack.Value;
            UpdateOveralls();
        }

        private void jumpShotTrack_ValueChanged(object sender, EventArgs e)
        {
            jumpShotLabel.Text = "" + jumpShotTrack.Value;
            ratings[1] = (byte)jumpShotTrack.Value;
            UpdateOveralls();
        }

        private void maxJumpShotTrack_ValueChanged(object sender, EventArgs e)
        {
            maxJumpShotLabel.Text = "" + maxJumpShotTrack.Value;
            maxRatings[1] = (byte)maxJumpShotTrack.Value;
            UpdateOveralls();
        }

        private void threePointTrack_ValueChanged(object sender, EventArgs e)
        {
            threePointLabel.Text = "" + threePointTrack.Value;
            ratings[2] = (byte)threePointTrack.Value;
            UpdateOveralls();
        }

        private void maxThreePointTrack_ValueChanged(object sender, EventArgs e)
        {
            maxThreePointLabel.Text = "" + maxThreePointTrack.Value;
            maxRatings[2] = (byte)maxThreePointTrack.Value;
            UpdateOveralls();
        }

        private void offenseIQTrack_ValueChanged(object sender, EventArgs e)
        {
            offenseIQLabel.Text = "" + offenseIQTrack.Value;
            ratings[3] = (byte)offenseIQTrack.Value;
            UpdateOveralls();

        }

        private void maxOffenseIQTrack_ValueChanged(object sender, EventArgs e)
        {
            maxOffenseIQLabel.Text = "" + maxOffenseIQTrack.Value;
            maxRatings[3] = (byte)maxOffenseIQTrack.Value;
            UpdateOveralls();
        }

        private void defenseIQTrack_ValueChanged(object sender, EventArgs e)
        {
            defenseIQLabel.Text = "" + defenseIQTrack.Value;
            ratings[4] = (byte)defenseIQTrack.Value;
            UpdateOveralls();

        }

        private void maxDefenseIQTrack_ValueChanged(object sender, EventArgs e)
        {
            maxDefenseIQLabel.Text = "" + maxDefenseIQTrack.Value;
            maxRatings[4] = (byte)maxDefenseIQTrack.Value;
            UpdateOveralls();
        }

        private void shotContestTrack_ValueChanged(object sender, EventArgs e)
        {
            shotContestLabel.Text = "" + shotContestTrack.Value;
            ratings[5] = (byte)shotContestTrack.Value;
            UpdateOveralls();

        }

        private void maxShotContestTrack_ValueChanged(object sender, EventArgs e)
        {
            maxShotContestLabel.Text = "" + maxShotContestTrack.Value;
            maxRatings[5] = (byte)maxShotContestTrack.Value;
            UpdateOveralls();

        }

        private void jumpingTrack_ValueChanged(object sender, EventArgs e)
        {
            jumpingLabel.Text = "" + jumpingTrack.Value;
            ratings[6] = (byte)jumpingTrack.Value;
            UpdateOveralls();
        }

        private void maxJumpingTrack_ValueChanged(object sender, EventArgs e)
        {
            maxJumpingLabel.Text = "" + maxJumpingTrack.Value;
            maxRatings[6] = (byte)maxJumpingTrack.Value;
            UpdateOveralls();
        }

        private void seperationTrack_ValueChanged(object sender, EventArgs e)
        {
            seperationLabel.Text = "" + seperationTrack.Value;
            ratings[7] = (byte)seperationTrack.Value;
            UpdateOveralls();

        }

        private void maxSeperationTrack_ValueChanged(object sender, EventArgs e)
        {
            maxSeperationLabel.Text = "" + maxSeperationTrack.Value;
            maxRatings[7] = (byte)maxSeperationTrack.Value;
            UpdateOveralls();
        }

        private void passingTrack_ValueChanged(object sender, EventArgs e)
        {
            passingLabel.Text = "" + passingTrack.Value;
            ratings[8] = (byte)passingTrack.Value;
            UpdateOveralls();

        }

        private void maxPassingTrack_ValueChanged(object sender, EventArgs e)
        {
            maxPassingLabel.Text = "" + maxPassingTrack.Value;
            maxRatings[8] = (byte)maxPassingTrack.Value;
            UpdateOveralls();
        }

        
    }
}
