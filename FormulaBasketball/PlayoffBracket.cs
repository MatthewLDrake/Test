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
    public partial class PlayoffBracket : Form
    {
        public PlayoffBracket()
        {
            InitializeComponent();
        }
        

        public void setBrackets(List<team> conferenceA, List<team> conferenceB)
        {
            conferenceATopSeed.setTeamNames(conferenceA[0].ToString(), conferenceA[7].ToString());
            conferenceAFourthSeed.setTeamNames(conferenceA[3].ToString(), conferenceA[4].ToString());
            conferenceAThirdSeed.setTeamNames(conferenceA[2].ToString(), conferenceA[5].ToString());
            conferenceASecondSeed.setTeamNames(conferenceA[1].ToString(), conferenceA[6].ToString());
            conferenceBTopSeed.setTeamNames(conferenceB[0].ToString(), conferenceB[7].ToString());
            conferenceBFourthSeed.setTeamNames(conferenceB[3].ToString(), conferenceB[4].ToString());
            conferenceBThirdSeed.setTeamNames(conferenceB[2].ToString(), conferenceB[5].ToString());
            conferenceBSecondSeed.setTeamNames(conferenceB[1].ToString(), conferenceB[6].ToString());
            Refresh();
        }
        public void updateFirstRoundScores(int[] conferenceAScores, int[] conferenceBScores)
        {
            conferenceATopSeed.updateScores(conferenceAScores[0], conferenceAScores[7]);
            conferenceAFourthSeed.updateScores(conferenceAScores[3], conferenceAScores[4]);
            conferenceAThirdSeed.updateScores(conferenceAScores[2], conferenceAScores[5]);
            conferenceASecondSeed.updateScores(conferenceAScores[1], conferenceAScores[6]);

            String top = conferenceATopSeed.getWinner();
            String fourth = conferenceAFourthSeed.getWinner();
            String third = conferenceAThirdSeed.getWinner();
            String second = conferenceASecondSeed.getWinner();

            bracket1.setTeamNames(top, fourth);
            bracket2.setTeamNames(third, second);

            conferenceBTopSeed.updateScores(conferenceBScores[0], conferenceBScores[7]);
            conferenceBFourthSeed.updateScores(conferenceBScores[3], conferenceBScores[4]);
            conferenceBThirdSeed.updateScores(conferenceBScores[2], conferenceBScores[5]);
            conferenceBSecondSeed.updateScores(conferenceBScores[1], conferenceBScores[6]);

            top = conferenceBTopSeed.getWinner();
            fourth = conferenceBFourthSeed.getWinner();
            third = conferenceBThirdSeed.getWinner();
            second = conferenceBSecondSeed.getWinner();

            bracket6.setTeamNames(top, fourth);
            bracket7.setTeamNames(third, second);

            Refresh();
        }
        public void updateSecondRoundScores(int[] conferenceAScores, int[] conferenceBScores)
        {
            bracket1.updateScores(conferenceAScores[0], conferenceAScores[7]);
            bracket2.updateScores(conferenceAScores[1], conferenceAScores[6]);
            String top = bracket1.getWinner();
            String fourth = bracket2.getWinner();
            bracket3.setTeamNames(top, fourth);

            bracket6.updateScores(conferenceBScores[0], conferenceBScores[7]);
            bracket7.updateScores(conferenceBScores[1], conferenceBScores[6]);
            top = bracket6.getWinner();
            fourth = bracket7.getWinner();
            bracket5.setTeamNames(top, fourth);
        }

        public void updateThirdRoundScores(int[] conferenceAScores, int[] conferenceBScores)
        {
            bracket3.updateScores(conferenceAScores[0], conferenceAScores[7]);
            bracket5.updateScores(conferenceBScores[0], conferenceBScores[7]);

            String top = bracket3.getWinner();
            String fourth = bracket5.getWinner();

            bracket4.setTeamNames(top, fourth);

        }
        public void updateFourthRoundScores(int[] conferenceAScores)
        {
            bracket4.updateScores(conferenceAScores[0], conferenceAScores[7]);
            

        }
    }
}
