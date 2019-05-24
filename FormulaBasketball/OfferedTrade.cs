using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class OfferedTrade : Form
    {
        private Trade trade;
        public int result;
        private createTeams create;
        private int teamNum;
        public OfferedTrade(Trade trade, createTeams create, int teamNum)
        {
            InitializeComponent();
            this.trade = trade;

            this.create = create;
            this.teamNum = teamNum;

            teamOneLabel.Text = trade.GetTeamOneName();
            teamTwoLabel.Text = trade.GetTeamTwoName();

            foreach(object item in trade.GetTeamOneTradeItems())
            {
                if(item is player)
                {
                    player p = item as player;
                    teamOneGrid.Rows.Add(p.getName(), String.Format("{0:0.00}", p.getOverall()), p.getDevelopment(), p.GetMoneyPerYear(), p);
                }
                else if(item is DraftPick)
                {
                    DraftPick p = item as DraftPick;
                    teamOneGrid.Rows.Add("Season " + p.GetSeason() +" Round " + p.GetRound() + " pick from " + p.GetTeamOfOrigin(), "???", "B", 0, p);
                }
            }
            foreach (object item in trade.GetTeamTwoTradeItems())
            {
                if (item is player)
                {
                    player p = item as player;
                    teamTwoGrid.Rows.Add(p.getName(), String.Format("{0:0.00}", p.getOverall()), p.getDevelopment(), p.GetMoneyPerYear(), p);
                }
                else if (item is DraftPick)
                {
                    DraftPick p = item as DraftPick;
                    teamTwoGrid.Rows.Add("Season " + p.GetSeason() + " Round " + p.GetRound() + " pick from " + p.GetTeamOfOrigin(), "???", "B", 0, p);
                }
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("tradeResponse.fbtr", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, trade);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            result = 1;
            Close();
        }

        private void negotiateButton_Click(object sender, EventArgs e)
        {
            TradeForm trade = new TradeForm(create, this.trade);
            result = 2;
            Close();
        }

        private void declineButton_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("tradeResponse.fbtr", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, -1);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            result = 3;
            Close();
        }

    }
}
