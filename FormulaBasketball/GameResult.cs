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
    public partial class GameResult : Form
    {
        public GameResult(NewTeam awayTeam, NewTeam homeTeam)
        {
            InitializeComponent();

            label1.Text = "Away Team: " + awayTeam.ToString();
            label2.Text = "Home Team: " + homeTeam.ToString();

            awayTeam.GetCoach().GetPlayerPhilosophy().StartGame(awayTeam);
            homeTeam.GetCoach().GetPlayerPhilosophy().StartGame(homeTeam);

            NewPlayer[] awayStarters = awayTeam.GetCoach().GetStartingFive(awayTeam);
            NewPlayer[] homeStarters = homeTeam.GetCoach().GetStartingFive(homeTeam);

            foreach (NewPlayer player in awayStarters)
            {
                player.StartGame(true, homeTeam.GetTeamNum());
            }
            foreach (NewPlayer player in homeStarters)
            {
                player.StartGame(true, awayTeam.GetTeamNum());
            }
            foreach(NewPlayer player in awayTeam)
            {
                teamOneGrid.Rows.Add(new object[] { player.ToString(), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
                player.StartGame(false, homeTeam.GetTeamNum());
            }
            foreach (NewPlayer player in homeTeam)
            {
                teamTwoGrid.Rows.Add(new object[] { player.ToString(), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
                player.StartGame(false, awayTeam.GetTeamNum());
            }
        }
    }
}
