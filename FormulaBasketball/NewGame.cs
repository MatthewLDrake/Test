using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    public class NewGame
    {
        private NewCurrentTeam awayTeam, homeTeam;
        private Random r;
        private List<byte[]> scores;
        private byte[] currentQuarterScore;
        private int timeLeft;
        private bool awayTipOff;
        public NewGame(team awayTeam, team homeTeam, Random r)
        {
            this.awayTeam = new NewCurrentTeam(awayTeam);
            this.homeTeam = new NewCurrentTeam(homeTeam);
            this.r = r;
            scores = new List<byte[]>();
            StartGame();
        }
        public int GetAwayTeamScore()
        {
            int totalScore = 0;
            foreach (byte[] arr in scores)
            {
                totalScore += arr[0];
            }
            return totalScore;
        }
        public int GetHomeTeamScore()
        {
            int totalScore = 0;
            foreach (byte[] arr in scores)
            {
                totalScore += arr[1];
            }
            return totalScore;
        }
        private void StartGame()
        {

            awayTipOff = TipOff();
            // 60 * 12
            timeLeft = 720;
            scores.Add(PlayQuarter(awayTipOff, 1));
            timeLeft = 720;
            scores.Add(PlayQuarter(!awayTipOff, 2));
            timeLeft = 720;
            scores.Add(PlayQuarter(!awayTipOff, 3));
            timeLeft = 720;
            scores.Add(PlayQuarter(awayTipOff, 4));

            while (GetAwayTeamScore() == GetHomeTeamScore())
            {
                timeLeft = 300;
                PlayQuarter(TipOff(), 5);
            }

        }
        private byte[] PlayQuarter(bool awayStarts, int quarterNum)
        {
            currentQuarterScore = new byte[2];

            bool awayTeamHasBall = awayStarts;
            while(timeLeft > 0)
            {

                int awayScoreDiff = GetAwayTeamScore() - GetHomeTeamScore() + currentQuarterScore[0] - currentQuarterScore[1];

                PlayResult result;
                if (awayTeamHasBall)
                    result = awayTeam.RunPlay(homeTeam, awayScoreDiff, quarterNum, timeLeft);
                else
                    result = homeTeam.RunPlay(awayTeam, -awayScoreDiff, quarterNum, timeLeft);

                timeLeft -= result.timeElapsed;
                currentQuarterScore[0] += result.awayPoints;
                currentQuarterScore[1] += result.homePoints;
            }

            return currentQuarterScore;
        }
        private bool TipOff()
        {
            double temp = awayTeam.GetCurrentPlayers()[0].getJumpingRating() - homeTeam.GetCurrentPlayers()[0].getJumpingRating();

            double temp2 = r.Next(0, 10) + temp;

            return temp2 > 5;
        }
    }
    public class NewCurrentTeam
    {
        private player[] currentPlayers;
        private Coach coach;
        private team team;
        public NewCurrentTeam(team team)
        {
            this.team = team;
            coach = team.getCoach();
            currentPlayers = team.getActivePlayers().Take(5).ToArray();

        }
        public player[] GetCurrentPlayers()
        {
            return currentPlayers;
        }
        public PlayResult RunPlay(NewCurrentTeam opponent, int scoreDiff, int quarterNum, int timeLeft)
        {
            OffensivePlay offensivePlay = coach.GetOffensivePlay(scoreDiff, quarterNum, timeLeft);
            DefensivePlay defensivePlay = opponent.coach.GetDefensivePlay(-scoreDiff, quarterNum, timeLeft);
            PlayExecutor play = null;
            switch(defensivePlay)
            {
                case DefensivePlay.MAN_SWITCH:
                    play = new ManPlayExecutor(1);
                    break;
                case DefensivePlay.MAN_NO_SWITCH:
                    play = new ManPlayExecutor(0);
                    break;
                case DefensivePlay.MAN_DOUBLE_BALL:
                    play = new ManPlayExecutor(2);
                    break;
            }

            if (play != null)
                return play.RunPlay(offensivePlay, this, opponent);

            return null;
        }
    }
    public class PlayResult
    {
        public byte awayPoints, homePoints;
        public int timeElapsed;
        public PlayResult(byte awayPoints, byte homePoints, int timeElapsed)
        {
            this.awayPoints = awayPoints;
            this.homePoints = homePoints;
            this.timeElapsed = timeElapsed;
        }
    }
    public abstract class PlayExecutor
    {
        public PlayResult RunPlay();
    }
}