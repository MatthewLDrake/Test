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
    public partial class PlayerRetirement : Form
    {
        private bool old;
        public PlayerRetirement(createTeams create)
        {
            InitializeComponent();
            old = true;
            foreach (team t in create.getTeams())
            {
                foreach(player p in t)
                {
                    if (p.GetRetired())
                        continue;
                    double[] ratings = new double[10];
                    ratings[0] = Math.Max(p.ratings[0], p.ratings[1]);
                    ratings[1] = p.ratings[2];
                    ratings[2] = p.ratings[9];
                    ratings[3] = (p.ratings[4] + (p.ratings[5] + p.ratings[7]) / 2 + p.ratings[6]) / 3;
                    ratings[4] = p.ratings[4];
                    ratings[5] = p.ratings[3];
                    ratings[6] = p.ratings[5];
                    ratings[7] = p.ratings[6];
                    ratings[8] = p.ratings[7];
                    ratings[9] = p.ratings[8];

                    double overall = 0, maxOverall = 0;

                    double[] maxRatings = p.maxRatings;
                    if (maxRatings == null)
                        maxRatings = ratings;

                    switch (p.getPosition())
                    {
                        case 1:
                            overall = GetRatingAsCenter(ratings);
                            maxOverall = GetRatingAsCenter(maxRatings);
                            break;
                        case 2:
                            overall = GetRatingAsPowerForward(ratings);
                            maxOverall = GetRatingAsPowerForward(maxRatings);
                            break;
                        case 3:
                            overall = GetRatingAsSmallForward(ratings);
                            maxOverall = GetRatingAsSmallForward(maxRatings);
                            break;
                        case 4:
                            overall = GetRatingAsShootingGuard(ratings);
                            maxOverall = GetRatingAsShootingGuard(maxRatings);
                            break;
                        case 5:
                            overall = GetRatingAsPointGuard(ratings);
                            maxOverall = GetRatingAsPointGuard(maxRatings);
                            break;
                    }

                    dataGridView1.Rows.Add(new object[] { p.getName(), p.getTeam().ToString(), p.age, p.peakStart, p.peakEnd, overall, maxOverall, "Retire", p, p.GetContract() != null ? p.GetContract().GetYearsLeft() : 0, p.GetContract() != null ? p.GetContract().GetMoney() : 0, "New Contract" });

                }
                foreach(player p in t.GetAffiliate())
                {
                    if (p.GetRetired())
                        continue;
                    double[] ratings = new double[10];
                    ratings[0] = Math.Max(p.ratings[0], p.ratings[1]);
                    ratings[1] = p.ratings[2];
                    ratings[2] = p.ratings[9];
                    ratings[3] = (p.ratings[4] + (p.ratings[5] + p.ratings[7]) / 2 + p.ratings[6]) / 3;
                    ratings[4] = p.ratings[4];
                    ratings[5] = p.ratings[3];
                    ratings[6] = p.ratings[5];
                    ratings[7] = p.ratings[6];
                    ratings[8] = p.ratings[7];
                    ratings[9] = p.ratings[8];

                    double overall = 0, maxOverall = 0;

                    double[] maxRatings = p.maxRatings;

                    if (maxRatings == null)
                        maxRatings = ratings;

                    switch (p.getPosition())
                    {
                        case 1:
                            overall = GetRatingAsCenter(ratings);
                            maxOverall = GetRatingAsCenter(maxRatings);
                            break;
                        case 2:
                            overall = GetRatingAsPowerForward(ratings);
                            maxOverall = GetRatingAsPowerForward(maxRatings);
                            break;
                        case 3:
                            overall = GetRatingAsSmallForward(ratings);
                            maxOverall = GetRatingAsSmallForward(maxRatings);
                            break;
                        case 4:
                            overall = GetRatingAsShootingGuard(ratings);
                            maxOverall = GetRatingAsShootingGuard(maxRatings);
                            break;
                        case 5:
                            overall = GetRatingAsPointGuard(ratings);
                            maxOverall = GetRatingAsPointGuard(maxRatings);
                            break;
                    }

                    dataGridView1.Rows.Add(new object[] { p.getName(), p.getTeam().ToString(), p.age, p.peakStart, p.peakEnd, overall, maxOverall, "Retire", p, p.GetContract() != null ? p.GetContract().GetYearsLeft() : 0, p.GetContract() != null ? p.GetContract().GetMoney() : 0, "New Contract" });
                }
            }
            foreach(player p in create.getFreeAgents().GetAllPlayers())
            {
                if (p.GetRetired())
                    continue;
                double[] ratings = new double[10];
                ratings[0] = Math.Max(p.ratings[0], p.ratings[1]);
                ratings[1] = p.ratings[2];
                ratings[2] = p.ratings[9];
                ratings[3] = (p.ratings[4] + (p.ratings[5] + p.ratings[7]) / 2 + p.ratings[6]) / 3;
                ratings[4] = p.ratings[4];
                ratings[5] = p.ratings[3];
                ratings[6] = p.ratings[5];
                ratings[7] = p.ratings[6];
                ratings[8] = p.ratings[7];
                ratings[9] = p.ratings[8];

                double overall = 0, maxOverall = 0;

                double[] maxRatings = p.maxRatings;
                if (maxRatings == null)
                    maxRatings = ratings;
                switch (p.getPosition())
                {
                    case 1:
                        overall = GetRatingAsCenter(ratings);
                        maxOverall = GetRatingAsCenter(maxRatings);
                        break;
                    case 2:
                        overall = GetRatingAsPowerForward(ratings);
                        maxOverall = GetRatingAsPowerForward(maxRatings);
                        break;
                    case 3:
                        overall = GetRatingAsSmallForward(ratings);
                        maxOverall = GetRatingAsSmallForward(maxRatings);
                        break;
                    case 4:
                        overall = GetRatingAsShootingGuard(ratings);
                        maxOverall = GetRatingAsShootingGuard(maxRatings);
                        break;
                    case 5:
                        overall = GetRatingAsPointGuard(ratings);
                        maxOverall = GetRatingAsPointGuard(maxRatings);
                        break;
                }

                dataGridView1.Rows.Add(new object[] { p.getName(), "", p.age, p.peakStart, p.peakEnd, overall, maxOverall, "Retire", p, p.GetContract() != null ? p.GetContract().GetYearsLeft() : 0, p.GetContract() != null ? p.GetContract().GetMoney() : 0, "New Contract" });
            }
        }
        public PlayerRetirement(League create)
        {
            InitializeComponent();
            old = false;
            foreach (NewTeam t in create)
            {
                foreach (NewPlayer p in t)
                {
                    if (p.GetPlayerID() < 1283)
                        continue;

                    double[] ratings = new double[p.ratings.Length];
                    for(int i= 0; i < ratings.Length; i++)
                    {
                        ratings[i] = p.ratings[i];
                    }

                    double overall = 0, maxOverall = 0;

                    double[] maxRatings = new double[p.maxRatings.Length];
                    for (int i = 0; i < ratings.Length; i++)
                    {
                        maxRatings[i] = p.maxRatings[i];
                    }
                    if (maxRatings == null)
                        maxRatings = ratings;

                    switch (p.GetPosition())
                    {
                        case 1:
                            overall = GetRatingAsCenter(ratings);
                            maxOverall = GetRatingAsCenter(maxRatings);
                            break;
                        case 2:
                            overall = GetRatingAsPowerForward(ratings);
                            maxOverall = GetRatingAsPowerForward(maxRatings);
                            break;
                        case 3:
                            overall = GetRatingAsSmallForward(ratings);
                            maxOverall = GetRatingAsSmallForward(maxRatings);
                            break;
                        case 4:
                            overall = GetRatingAsShootingGuard(ratings);
                            maxOverall = GetRatingAsShootingGuard(maxRatings);
                            break;
                        case 5:
                            overall = GetRatingAsPointGuard(ratings);
                            maxOverall = GetRatingAsPointGuard(maxRatings);
                            break;
                    }

                    dataGridView1.Rows.Add(new object[] { p.ToString(), t.ToString(), p.GetAge(), p.GetPeakStart(), p.GetPeakStart(), overall, maxOverall, "Retire", p, p.GetContract() != null ? p.GetContract().GetYearsLeft() : 0, p.GetContract() != null ? p.GetContract().GetMoney() : 0, "New Contract" });

                }
                /*foreach (NewPlayer p in create.GetDLeagueTeam(t.GetTeamNum()))
                {
                    double[] ratings = new double[p.ratings.Length];
                    for (int i = 0; i < ratings.Length; i++)
                    {
                        ratings[i] = p.ratings[i];
                    }

                    double overall = 0, maxOverall = 0;

                    double[] maxRatings = new double[p.maxRatings.Length];
                    for (int i = 0; i < ratings.Length; i++)
                    {
                        maxRatings[i] = p.maxRatings[i];
                    }

                    switch (p.GetPosition())
                    {
                        case 1:
                            overall = GetRatingAsCenter(ratings);
                            maxOverall = GetRatingAsCenter(maxRatings);
                            break;
                        case 2:
                            overall = GetRatingAsPowerForward(ratings);
                            maxOverall = GetRatingAsPowerForward(maxRatings);
                            break;
                        case 3:
                            overall = GetRatingAsSmallForward(ratings);
                            maxOverall = GetRatingAsSmallForward(maxRatings);
                            break;
                        case 4:
                            overall = GetRatingAsShootingGuard(ratings);
                            maxOverall = GetRatingAsShootingGuard(maxRatings);
                            break;
                        case 5:
                            overall = GetRatingAsPointGuard(ratings);
                            maxOverall = GetRatingAsPointGuard(maxRatings);
                            break;
                    }

                    dataGridView1.Rows.Add(new object[] { p.ToString(), create.GetDLeagueTeam(t.GetTeamNum()).ToString(), p.GetAge(), p.GetPeakStart(), p.GetPeakStart(), overall, maxOverall, "Retire", p, p.GetContract() != null ? p.GetContract().GetYearsLeft() : 0, p.GetContract() != null ? p.GetContract().GetMoney() : 0, "New Contract" });
                }*/
            }
            /*foreach (NewPlayer p in create.GetFreeAgents().GetAllPlayers())
            {
                double[] ratings = new double[p.ratings.Length];
                for (int i = 0; i < ratings.Length; i++)
                {
                    ratings[i] = p.ratings[i];
                }

                double overall = 0, maxOverall = 0;

                double[] maxRatings = new double[p.maxRatings.Length];
                for (int i = 0; i < ratings.Length; i++)
                {
                    maxRatings[i] = p.maxRatings[i];
                }

                switch (p.GetPosition())
                {
                    case 1:
                        overall = GetRatingAsCenter(ratings);
                        maxOverall = GetRatingAsCenter(maxRatings);
                        break;
                    case 2:
                        overall = GetRatingAsPowerForward(ratings);
                        maxOverall = GetRatingAsPowerForward(maxRatings);
                        break;
                    case 3:
                        overall = GetRatingAsSmallForward(ratings);
                        maxOverall = GetRatingAsSmallForward(maxRatings);
                        break;
                    case 4:
                        overall = GetRatingAsShootingGuard(ratings);
                        maxOverall = GetRatingAsShootingGuard(maxRatings);
                        break;
                    case 5:
                        overall = GetRatingAsPointGuard(ratings);
                        maxOverall = GetRatingAsPointGuard(maxRatings);
                        break;
                }

                dataGridView1.Rows.Add(new object[] { p.ToString(), "", p.GetAge(), p.GetPeakStart(), p.GetPeakStart(), overall, maxOverall, "Retire", p, p.GetContract() != null ? p.GetContract().GetYearsLeft() : 0, p.GetContract() != null ? p.GetContract().GetMoney() : 0, "New Contract" });
            }*/
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(old)
            {
                player p = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[8].Value as player;
                if (dataGridView1.SelectedCells[0].ColumnIndex == 7)
                {
                    p.Retire();
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
                }
                if (dataGridView1.SelectedCells[0].ColumnIndex == 11)
                {
                    NewContract contract = new NewContract();
                    contract.ShowDialog();
                    p.SetNewContract(contract.GetContract());


                    dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[9].Value = p.GetContract().GetYearsLeft();
                    dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[10].Value = p.GetContract().GetMoney();

                }
            }
            else
            {
                NewPlayer p = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[8].Value as NewPlayer;
                if (dataGridView1.SelectedCells[0].ColumnIndex == 7)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
                }
                if (dataGridView1.SelectedCells[0].ColumnIndex == 11)
                {
                    NewContract contract = new NewContract();
                    contract.ShowDialog();
                    p.SetContract(contract.GetContract());
                    if (contract.GetContract() != null)
                    {
                        dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[9].Value = p.GetContract().GetYearsLeft();
                        dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[10].Value = p.GetContract().GetMoney();
                    }
                    else
                    {
                        dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[9].Value = 0;
                        dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[10].Value = 0;
                    }

                }
            }
        }
    }
}
