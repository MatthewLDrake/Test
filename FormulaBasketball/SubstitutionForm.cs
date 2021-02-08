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
    public partial class SubstitutionForm : Form
    {
        private NewPlayer[] current;
        private NewPlayer playerToMove;
        private NewTeam team;
        public SubstitutionForm(NewTeam team, NewPlayer[] current)
        {
            InitializeComponent();
            this.team = team;
            this.current = current;

            int[] arr = new int[5];
            int index = 0;
            foreach (NewPlayer activePlayers in team.GetActivePlayers())
            {
                dataGridView2.Rows.Add(new object[] { activePlayers.GetPositionAsString(), activePlayers.GetName(), activePlayers.GetBestOverall(), activePlayers.GetGameStats().GetMinutes(), "Move", activePlayers });
                //comboColumn.Items.Add(activePlayers.GetName() + " - " + activePlayers.GetBestOverall());                
                if(current != null)
                {
                    for(int i = 0; i < 5; i++)
                    {
                        if(current[i].GetPlayerID() == activePlayers.GetPlayerID())
                            arr[i] = index;
                    }
                }
                index++;
            }
            if (current == null)
            {
                for(int i = 0; i < 5; i++)
                    dataGridView1.Rows.Add(new object[] {"","", "Move" });

                this.current = new NewPlayer[5];
            }
            else
            {
                for (int i = 0; i < 5; i++)
                    dataGridView1.Rows.Add(new object[] {current[i].GetPositionAsString(), current[i].GetName(), "Move"});
            }
            label1.Text = team.GetCoach().ToString();
        }
        public NewPlayer[] GetPlayers()
        {
            return current;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            playerToMove = dataGridView2.Rows[e.RowIndex].Cells[5].Value as NewPlayer;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (playerToMove == null)
            {
                dataGridView1.Rows[e.RowIndex].SetValues(new object[] { "", "", "Move" });
                current[e.RowIndex] = null;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].SetValues(new object[] { playerToMove.GetPositionAsString(), playerToMove.GetName(), "Move" });
                current[e.RowIndex] = playerToMove;
            }
            playerToMove = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Tuple<int, double, NewPlayer>> bestPlayers = new List<Tuple<int, double, NewPlayer>>();
            foreach(NewPlayer p in team)
            {
                bool flag = false;
                for(int i = 0; i < bestPlayers.Count; i++)
                {
                    if(bestPlayers[i].Item1 == p.GetPosition())
                    {
                        flag = true;
                        if(p.GetBestOverall() > bestPlayers[i].Item2)
                        {
                            bestPlayers[i] = new Tuple<int, double, NewPlayer>(p.GetPosition(), p.GetBestOverall(), p);
                        }
                    }
                }
                if(!flag)
                {
                    bestPlayers.Add(new Tuple<int, double, NewPlayer>(p.GetPosition(), p.GetBestOverall(), p));
                }
            }

        }
    }
}
