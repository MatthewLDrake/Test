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
    public partial class displayPlayers : Form
    {
        private List<player> players;
        public displayPlayers()
        {
            InitializeComponent();
        }
        public void setPlayers(List<player> players)
        {
            this.players = players;
            foreach (player player in players)
            {
                String teamName = "Free Agency";
                if(player.getTeam() != null)
                {
                    teamName = player.getTeam().ToString();
                }
                list.Rows.Add(new object[] { player.getName(), player.getLayupRating(), player.getDunkRating(), player.getJumpShotRating(), player.getThreeShotRating(), player.getPassing(), player.getShotContestRating(), player.getDefenseIQRating(), player.getJumpingRating(), player.getSeperation(), player.getDurabilityRating(), player.getStaminaRating(), teamName });
            }
        }
    }
}
