using System;

namespace FormulaBasketball
{
    public class NewCoach
    {
        private NewOffensivePhilosophy offense;
        private NewDefensivePhilosophy defense;
        private PlayerPhilosophy personnel;
        public NewCoach(string name, NewOffensivePhilosophy offensivePersonality, NewDefensivePhilosophy defensivePersonality, PlayerPhilosophy personnelPhilosophy)
        {
            offense = offensivePersonality;
            defense = defensivePersonality;
            personnel = personnelPhilosophy;
        }
        public NewOffensivePhilosophy PreviousPhilosophy()
        {
            return offense;
        }
        public NewOffensivePhilosophy GetOffensivePhilosophy()
        {
            return offense;
        }
        public NewDefensivePhilosophy GetDefensivePhilosophy()
        {
            return defense;
        }
        public PlayerPhilosophy GetPlayerPhilosophy()
        {
            return personnel;
        }
        public NewPlayer[] GetStartingFive(NewTeam team)
        {
            return personnel.GetStartingFive(team);
        }


    }
   /* public class AdvancedNewCoach
    {
        private string name;
        private CoachingPersonalities personality;
        public AdvancedNewCoach(string name, CoachingPersonalities personality)
        {
            this.personality = personality;
            this.name = name;
        }
        public byte TakeShot(NewCurrentTeam team, NewCurrentTeam opponent,ShotType type, ref NewPlayer starter, NewPlayer previousPlayer = null)
        {
            NewPlayer shooter;
            bool three = true;
            switch(type)
            {
                case ShotType.LAYUP:
                case ShotType.DUNK:
                    three = false;
                    shooter = personality.GetInsideShooter(team, starter);
                    break;
                case ShotType.JUMP:
                    three = false;
                    shooter = personality.GetJumpShooter(team, starter);
                    break;
                case ShotType.CORNER_THREE:
                case ShotType.TOP_THREE:
                    shooter = personality.GetJumpShooter(team, starter);
                    break;
                default:
                    shooter = personality.GetThreeShooter(team, starter);
                    break;
            }
            double randBarrier = 0;

            if (previousPlayer != null)
            {
                NewPlayer passDefender = opponent.GetCoach().GetPersonality().GetDefender(previousPlayer, opponent, team);

                randBarrier += previousPlayer.GetPassingRating(true, false) + previousPlayer.GetOffenseIQRating(true, false) * .5 - passDefender.GetDefenseIQRating(true, false) * 1.5;

            }
            

            NewPlayer shotDefender = opponent.GetCoach().GetPersonality().GetDefender(shooter, opponent, team);
            randBarrier += shooter.GetSeperationRating(true, false) + shooter.GetOffenseIQRating(true, false) * .5 - shotDefender.GetDefenseIQRating(true, false) * 1.5;


            

            ShotResult result = NewShots.TakeShot(type, false, shooter, shotDefender, League.r.NextGaussian((int)randBarrier, 5));


            bool made = result.Type != ResultType.MISS;

            if (made)
                return (byte)(three ? 3 : 2);
            else
                return 0;
        }
        public PlayResult DoNormalPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter = null)
        {
            Tuple<ShotType, int, NewPlayer> shotType = personality.DoNormalPlay(team, opponent, starter);

            if (shotType.Item1 == ShotType.OFFENSIVE_FOUL || shotType.Item1 == ShotType.STEAL || shotType.Item1 == ShotType.TURNOVER)
                return new PlayResult(0, 0, shotType.Item2, shotType.Item3);

            byte score = TakeShot(team, opponent, shotType.Item1, ref starter);
            byte awayScore = 0, homeScore = 0;

            if (team.IsAwayTeam())
                awayScore = score;
            else
                homeScore = score;
            return new PlayResult(awayScore, homeScore, shotType.Item2, starter);
        }
        public PlayResult DoLessRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter = null)
        {
            Tuple<ShotType, int, NewPlayer> shotType = personality.DoLessRiskyPlay(team, opponent, starter);

            if (shotType.Item1 < 0)
                return new PlayResult(0, 0, shotType.Item2, shotType.Item3);

            byte score = TakeShot(team, opponent, shotType.Item1, ref starter);
            byte awayScore = 0, homeScore = 0;

            if (team.IsAwayTeam())
                awayScore = score;
            else
                homeScore = score;
            return new PlayResult(awayScore, homeScore, shotType.Item2, starter);
        }
        public PlayResult DoMoreRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter = null)
        {
            Tuple<ShotType, int, NewPlayer> shotType = personality.DoMoreRiskyPlay(team, opponent, starter);

            if (shotType.Item1 < 0)
                return new PlayResult(0, 0, shotType.Item2, shotType.Item3);

            byte score = TakeShot(team, opponent, shotType.Item1, ref starter);
            byte awayScore = 0, homeScore = 0;

            if (team.IsAwayTeam())
                awayScore = score;
            else
                homeScore = score;
            return new PlayResult(awayScore, homeScore, shotType.Item2, starter);
        }
        public NewPlayer[] GetStartingFive(NewTeam team)
        {
            return personality.GetStartingFive(team);
        }
        public PlayResult InboundPlay(NewCurrentTeam team, NewCurrentTeam opponent)
        {
            return null;
        }
        // Update this so they have a chance of being any personality
        public CoachingPersonalities GetPersonality()
        {
            return personality;
        }
        
    }*/
    // This class outlines the differences in coaching personalities, and is what the difference is
    // between each coach. The different personalities are all listed in the CoachingPersonalities.cs file
    // and all implement the various methods listed in here.
    public abstract class CoachingPersonalities
    {
        public CoachingPersonalities()
        {

        }
        // Shooters
        public abstract NewPlayer GetThreeShooter(NewCurrentTeam team, NewPlayer starter);
        public abstract NewPlayer GetJumpShooter(NewCurrentTeam team, NewPlayer starter);
        public abstract NewPlayer GetInsideShooter(NewCurrentTeam team, NewPlayer starter);

        // Various different players
        public abstract NewPlayer GetDefender(NewPlayer shooter, NewCurrentTeam team, NewCurrentTeam opponent);
        public abstract NewPlayer GetPlayStarter(NewCurrentTeam team);

        // Plays
        public abstract Tuple<ShotType, int, NewPlayer> DoNormalPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter);
        public abstract Tuple<ShotType, int, NewPlayer> DoLessRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter);
        public abstract Tuple<ShotType, int, NewPlayer> DoMoreRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter);

        public abstract NewPlayer[] GetStartingFive(NewTeam team);

    }
}