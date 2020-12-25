using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class NewShots
    {
        public static ShotResult TakeFreeThrow(int amount,  bool clutchSituation, NewPlayer shooter)
        {
            int made = 0;
            for (int i = 0; i < amount; i++)
            {
                double rating = shooter.GetJumpShotRating(true, clutchSituation);
                double boundary;
                if (rating >= 130)
                {
                    boundary = (rating + 2345) / 26.0;
                }
                else
                {
                    boundary = (-(7 * rating * rating) / 4000.0) + ((27.0 * rating) / 40.0) + (186.0 / 5.0);
                }
                made +=League.r.Next(100) + 1 < boundary ? 1 : 0;
                
                
            }
            ResultType resultType;

            switch (made)
            {
                case 1:
                    resultType = ResultType.MAKE_ONE_FREETHROW;
                    break;
                case 2:
                    resultType = ResultType.MAKE_TWO_FREETHROW;
                    break;
                case 3:
                    resultType = ResultType.MAKE_THREE_FREETHROW;
                    break;
                default:
                    resultType = ResultType.MISS;
                    break;
            }
            return new ShotResult(resultType, shooter);
        }
        public static ShotResult TakeShot(ShotType type, bool clutchSituation, NewPlayer shooter, NewPlayer mainDefender, double percentCovered, NewPlayer helpDefender = null)
        {
            switch(type)
            {
                case ShotType.LAYUP:
                    return HandleLayup(clutchSituation, shooter, mainDefender, percentCovered, helpDefender);                
                case ShotType.DUNK:
                    return HandleDunk(clutchSituation, shooter, mainDefender, percentCovered, helpDefender);
                case ShotType.CORNER_THREE:
                case ShotType.TOP_THREE:
                case ShotType.JUMP:
                    return HandleJumpShot(clutchSituation, shooter, mainDefender, percentCovered, helpDefender, type != ShotType.JUMP);
                case ShotType.THREE:
                    return HandleThree(clutchSituation, shooter, mainDefender, percentCovered, helpDefender);
                    
            }
            return null;
        }
        private static ShotResult HandleLayup(bool clutchSituation, NewPlayer shooter, NewPlayer mainDefender, double percentCovered, NewPlayer helpDefender)
        {
            double number = (-9.0 * percentCovered)/5.0 + 200;
            double baseLine = shooter.GetInsideRating(true, clutchSituation) / 6.0 + number / 3.0;
            

            double shotContestRating = 0;
            if(mainDefender != null)
            {                
                if (helpDefender != null)
                    shotContestRating = helpDefender.GetShotContestRating(true, clutchSituation) * .5 + mainDefender.GetShotContestRating(true, clutchSituation) * .9;
                else
                    shotContestRating = mainDefender.GetShotContestRating(true, clutchSituation);
            }
            shotContestRating = shotContestRating * 2 * (percentCovered / 100);

            double boundary = -(shotContestRating * shotContestRating) / 800 - (17 * shotContestRating) / 80 + 20 + baseLine +League.r.Next(10);

            int randNumber =League.r.Next(100) + 1;

            double result = boundary - randNumber;

            ResultType type;

            if (percentCovered >= 50 && result > 35)
                type = ResultType.AND_ONE;
            else if (result > 0)
                type = ResultType.MAKE;
            else if (percentCovered >= 50 && result > -15)
                type = ResultType.FOUL;
            else if (result > -60 || mainDefender == null)
                type = ResultType.MISS;
            else
                type = ResultType.BLOCK;

            return new ShotResult(type, type == ResultType.BLOCK ? mainDefender : shooter);
        }
        private static ShotResult HandleDunk(bool clutchSituation, NewPlayer dunker, NewPlayer mainDefender, double percentCovered, NewPlayer helpDefender)
        {
            

            double shotContestRating = 0;
            if (mainDefender != null)
            {
                if (helpDefender != null)
                    shotContestRating = helpDefender.GetShotContestRating(true, clutchSituation) * .5 + mainDefender.GetShotContestRating(true, clutchSituation) * .9;
                else
                    shotContestRating = mainDefender.GetShotContestRating(true, clutchSituation);
            }
            shotContestRating = shotContestRating * 2 * (percentCovered / 100);

            ResultType type = ResultType.MAKE;
            return new ShotResult(type, type == ResultType.BLOCK ? mainDefender : dunker);
        }
        private static ShotResult HandleJumpShot(bool clutchSituation, NewPlayer shooter, NewPlayer mainDefender, double percentCovered, NewPlayer helpDefender, bool three)
        {
            double number = -(13 * percentCovered)/ 5 + 330;
            double baseLine = (3 * (three ? shooter.GetThreePointRating(true, clutchSituation) : shooter.GetJumpShotRating(true, clutchSituation))) / 13 + number / 13;

            double shotContestRating = 0;
            if (mainDefender != null)
            {
                if (helpDefender != null)
                    shotContestRating = helpDefender.GetShotContestRating(true, clutchSituation) * .5 + mainDefender.GetShotContestRating(true, clutchSituation) * .9;
                else
                    shotContestRating = mainDefender.GetShotContestRating(true, clutchSituation);
            }
            shotContestRating = shotContestRating * 2 * (percentCovered / 100);

            double boundary = -(shotContestRating * shotContestRating) / 800 - (17 * shotContestRating) / 80 + 20 + baseLine +League.r.Next(10);

            int randNumber =League.r.Next(100) + 1;

            double result = boundary - randNumber;


            ResultType type;

            if (percentCovered >= 75 && result > 35)
                type = ResultType.AND_ONE;
            else if (result > 0)
                type = ResultType.MAKE;
            else if (percentCovered >= 75 && result > -10)
                type = ResultType.FOUL;
            else if (result > -70 || percentCovered < 75 || mainDefender == null)
                type = ResultType.MISS;
            else
                type = ResultType.BLOCK;


            return new ShotResult(type, type == ResultType.BLOCK ? mainDefender : shooter);
        }
        private static ShotResult HandleThree(bool clutchSituation,  NewPlayer shooter, NewPlayer mainDefender, double percentCovered, NewPlayer helpDefender)
        {
            double number = -(13 * percentCovered) / 5 + 330;
            double baseLine = (3 * shooter.GetThreePointRating(true, clutchSituation)) / 13 + number / 13;

            double shotContestRating = 0;
            if (mainDefender != null)
            {
                if (helpDefender != null)
                    shotContestRating = helpDefender.GetShotContestRating(true, clutchSituation) * .5 + mainDefender.GetShotContestRating(true, clutchSituation) * .9;
                else
                    shotContestRating = mainDefender.GetShotContestRating(true, clutchSituation);
            }
            if(percentCovered >= 50)
            {
                shotContestRating += shotContestRating * ((percentCovered - 50) / 100);
            }
            else
                shotContestRating = shotContestRating * 2 * (percentCovered / 100);

            double boundary = -(shotContestRating * shotContestRating) / 800 - (17 * shotContestRating) / 80 + 20 + baseLine +League.r.Next(10);

            int randNumber =League.r.Next(100) + 1;

            double result = boundary - randNumber;


            ResultType type;

            if (percentCovered >= 75 && result > 40)
                type = ResultType.AND_ONE;
            else if (result > 5)
                type = ResultType.MAKE;
            else if (percentCovered >= 75 && result > -5)
                type = ResultType.FOUL;
            else if (result > -70 || percentCovered < 75 || mainDefender == null)
                type = ResultType.MISS;
            else
                type = ResultType.BLOCK;


            return new ShotResult(type, type == ResultType.BLOCK ? mainDefender : shooter);
        }
    }
    public class ShotResult
    {
        private ResultType type;
        private NewPlayer statGetter;
        public ShotResult(ResultType type, NewPlayer statGetter)
        {
            this.type = type;
            this.statGetter = statGetter;
        }
        public ResultType Type
        {
            get
            {
                return type;
            }
        }
        public NewPlayer StatGetter
        {
            get
            {
                return statGetter;
            }
        }
    }
    public enum ResultType
    {
        MAKE, MISS, BLOCK, MAKE_ONE_FREETHROW, MAKE_TWO_FREETHROW, MAKE_THREE_FREETHROW, FOUL, AND_ONE
    }
}
