using System;
using System.Globalization;

namespace FormulaBasketball
{
    [Serializable]
    public class NewStadium
    {
        private sbyte capacityStage, concessionStyle, souvenirShops, upgradesInProgress, capacityUpgradeProgress, concessionStyleProgress, souvenirShopsProgress;        
        private bool[] concessions;
        private const int MAX_UPGRADES = 5;
        private string stadiumName;
        private bool upgradeCapacity;
        private double luxuryBoxPrice, lowerDeckPrice, upperDeckPrice;
        private double[] profits;
        public NewStadium(string stadiumName)
        {
            capacityStage = 1;
            concessionStyle = 1;
            souvenirShops = 1;
            concessions = new bool[10];
            this.stadiumName = stadiumName;
        }
        public void SetPrices()
        {
            luxuryBoxPrice = 5000;
            lowerDeckPrice = 100;
            upperDeckPrice = 25;

            profits = new double[11] { 3.25, 3.25,  2.5, 2.5, 2.25, 2.25, 3, 2.25, 3, 3.25, .5};


        }
        public int GetMaxUpgrades()
        {
            return MAX_UPGRADES;
        }
        public void SetUpgradeCapacity(bool upgradeCapacity)
        {
            this.upgradeCapacity = upgradeCapacity;
        }
        public override string ToString()
        {
            return stadiumName;
        }
        public double HostFakeGame(int fanInterest, int opposingFanInterest, bool playoffGame, Random r, int fakeCapacity, int fakeConcessionsTypes, int fakeSouvenirs, bool[] fakeConcessions)
        {
            sbyte capacityStage = this.capacityStage, concessionStyle = this.concessionStyle, souvenirShops = this.souvenirShops;
            bool[] concessions = this.concessions;

            this.capacityStage = (sbyte)fakeCapacity;
            this.concessionStyle = (sbyte)fakeConcessionsTypes;
            this.souvenirShops = (sbyte)fakeSouvenirs;
            this.concessions = fakeConcessions;

            double retVal = HostGame(fanInterest, opposingFanInterest, playoffGame, r).Item2;

            this.capacityStage = capacityStage;
            this.concessionStyle = concessionStyle;
            this.souvenirShops = souvenirShops;
            this.concessions = concessions;

            return retVal;
        }
        public Tuple<int, double> HostGame(int fanInterest, int opposingFanInterest, bool playoffGame, Random r)
        {
            int capacity = GetCurrentCapacity(), gameCapacity, luxuryBoxes, lowerDeck, upperDeck;

            double moneyMade = 0;
            luxuryBoxes = GetCurrentLuxuryBoxes();

            if (fanInterest == 100 || playoffGame)
            {
                gameCapacity = capacity;
                lowerDeck = GetCurrentLowerDeck();
                upperDeck = GetCurrentUpperDeck();
            }
            else
            {
                gameCapacity = (int)Math.Round(r.NextDoubleGaussian((fanInterest * .8 + opposingFanInterest * .2) / 100.0 * capacity, 1000));
                gameCapacity = Math.Max(0, Math.Min(capacity, gameCapacity));

                int temp = gameCapacity - luxuryBoxes;

                double percent = r.Next(40, 70) / 100.0;

                lowerDeck = (int)Math.Round(temp * percent);
                if (lowerDeck > GetCurrentLowerDeck())
                    lowerDeck = GetCurrentLowerDeck();

                temp -= lowerDeck;
                upperDeck = temp;
            }

            moneyMade += luxuryBoxes * luxuryBoxPrice;
            moneyMade += lowerDeck * lowerDeckPrice;
            moneyMade += upperDeck * upperDeckPrice;

            int[] concessions = new int[11];

             int concessionTotal = GetCurrentTotalConcessions();

             concessions[10] = concessionTotal;


             int typesTotal = 0;
             foreach (bool b in this.concessions)
                 typesTotal += b ? 1 : 0;

             for (int i = 0; i < this.concessions.Length; i++)
             {
                 if(this.concessions[i])
                 {
                     concessions[i] = concessionTotal / typesTotal;
                 }
             }
            int totalConcessionsSold = (int) Math.Round(luxuryBoxes * (r.Next(50, 75) / 10.0));
            totalConcessionsSold += (int)Math.Round(lowerDeck * (r.Next(15, 25) / 10.0));
            totalConcessionsSold += (int)Math.Round(upperDeck * (r.Next(5, 15) / 10.0));

            int[] concessionsSold = new int[11];

            concessionsSold[10] = Math.Min(totalConcessionsSold, concessions[10]);

            if (concessionTotal * 2 < totalConcessionsSold)
            {
                concessionsSold = concessions;
            }
            else
            {
                for (int i = 0; i < this.concessions.Length; i++)
                {
                    if (this.concessions[i])
                    {
                        concessionsSold[i] = totalConcessionsSold / typesTotal;
                    }
                }

            }
            
            
            for (int i = 0; i <concessionsSold.Length;i++)
            {
                moneyMade += concessionsSold[i] * profits[i];
            }
            moneyMade += ConcessionAdditions();
            
            if (fanInterest > 80)
                moneyMade += GetCurrentTotalSouvenirs() * GetCurrentSouvenirProfit();
            else
            {
                double temp = (fanInterest + 20.0) / 100.0;
                moneyMade += Math.Round(GetCurrentTotalSouvenirs() * temp) * GetCurrentSouvenirProfit();
            }
            moneyMade += SouvenirAdditions();


            return new Tuple<int, double>(gameCapacity, moneyMade);

        }
        public void SetName(string newName)
        {
            stadiumName = newName;
        }
        public string GetInfo()
        {
            string retval = stadiumName + " Info:\n" + "Capacity: " + GetCurrentCapacity() + "\nConcession Style: " + GetConcessionStyle() + "\nSouvenir Shops: " + GetSouvenirShops() + "\nConcessions Purchased:\n";
            for(int i = 0; i < concessions.Length; i++)
            {
                retval += "\t" + ConcessionPurchases(i) + ": " + (concessions[i] ? "Yes" : "No") + "\n";
            }
            return retval + "Upgrades Still Available: " + (MAX_UPGRADES - upgradesInProgress);
        }
        public string GetCapacityInfo()
        {            
            string str = (capacityStage == 10 ? "```There are no upgrades left." : "```Capacity Upgrades Available:\n");

            for(int i = capacityStage + 1; i < 11; i++)
            {
                str += "Stage " + ("" + i).PadRight(2) + " (" + (string.Format("{0:n0}", GetCapacity(i)) + " seats):").PadRight(16) + string.Format("${0:n0}", GetCapacityPrice(i)).PadLeft(14) + "\n";
            }

            return str + "```";
        }
        public int GetCapacityPrice(int capacity, bool includeDiscount = true)
        {
            int[] price = new int[] { 0, 30000000, 65000000, 115000000, 150000000, 200000000, 275000000, 350000000, 500000000, 1000000000 };
            int discount = includeDiscount ? price[capacityStage - 1] / 2 : 0;

            return price[capacity - 1] - discount;
        }
        public string GetConcessionInfo()
        {
            string str = (concessionStyle == 10 ? "```There are no upgrades left." : "```Concession Upgrades Available:\n");

            for (int i = concessionStyle + 1; i < 11; i++)
            {
                str += "Stage " + ("" + i + ":").PadRight(3) + string.Format("${0:n0}", GetConcessionPrice(i)).PadLeft(13) + "\n";
            }

            return str + "```";
        }
        public int GetConcessionPrice(int concession, bool includeDiscount = true)
        {
            int[] price = new int[] { 0, 3000000, 6500000, 11500000, 15000000, 20000000, 27500000, 35000000, 50000000, 100000000 };
            int discount = includeDiscount ? price[concessionStyle - 1] / 2 : 0; 

            return price[concession - 1] - discount;
        }
        public string GetSouvenirInfo()
        {
            string str = (souvenirShops == 10 ? "```There are no upgrades left." : "```Souvenir Upgrades Available:\n");

            for (int i = souvenirShops + 1; i < 11; i++)
            {
                str += "Stage " + ("" + i + ":").PadRight(3) + string.Format("${0:n0}", GetSouvenirPrice(i)).PadLeft(13) + "\n";
            }
            return str + "```";
        }
        public int GetSouvenirPrice(int souvenir, bool includeDiscount = true)
        {
            int[] price = new int[] { 0, 3000000, 6500000, 11500000, 15000000, 20000000, 27500000, 35000000, 50000000, 100000000 };
            int discount = includeDiscount ? price[souvenirShops - 1] / 2 : 0;

            return price[souvenir - 1] - discount;
        }
        public string GetConcessionTypeInfo()
        {            
            int temp = 0;
            string val = "";
            for (int i = 0; i < concessions.Length; i++)
            {
                if (!concessions[i])
                    val += "\n" + ConcessionPurchases(i) + "(" + i + ")";               
                else
                    temp++;
            }
            string str = (temp == 10 ? "```There are no upgrades left." : "```Concession Purchases Available:\n");

            for (int i = temp + 1; i < 11; i++)
            {
                str += ("" + i).PadRight(2) + " Types of Concessions: " + string.Format("${0:n0}", GetConcessionPurchasePrice(i)).PadLeft(12) + "\n";
            }
            return str + "\nAvailable Concessions to Buy:" + val + "```";
        }
        public int GetConcessionPurchasePrice(int purchasePrice, bool includeDiscount = true)
        {
            int temp = 0;
            for (int i = 0; i < concessions.Length; i++)
            {
                if (concessions[i])
                    temp++;
            }
            int[] price = new int[] { 0 , 100000, 250000, 500000, 750000, 1000000, 1500000, 2000000, 3500000, 5000000, 10000000};
            int discount = includeDiscount ? price[temp] / 2 : 0;

            return price[purchasePrice] - discount;
        }
        public int GetCurrentCapacity()
        {
            switch (capacityStage)
            {
                default:
                    return 20000;
                case 2:
                    return 22500;
                case 3:
                    return 25000;
                case 4:
                    return 30000;
                case 5:
                    return 35000;
                case 6:
                    return 40000;
                case 7:                    
                    return 50000;
                case 8:
                    return 60000;
                case 9:
                    return 75000;
                case 10:
                    return 100000;

            }
        }
        public int GetCurrentTotalConcessions()
        {
            switch (concessionStyle)
            {
                default:
                    return 1000;
                case 2:
                    return 5000;
                case 3:
                    return 10000;
                case 4:
                    return 25000;
                case 5:
                    return 50000;
                case 6:
                    return 100000;
                case 7:
                    return 150000;
                case 8:
                    return 250000;
                case 9:
                    return 500000;
                case 10:
                    return 1000000;
            }
        }
        public int ConcessionAdditions()
        {
            switch (concessionStyle)
            {
                default:
                    return 0;
                case 2:
                    return 10000;
                case 3:
                    return 30000;
                case 4:
                    return 50000;
                case 5:
                    return 70000;
                case 6:
                    return 95000;
                case 7:
                    return 130000;
                case 8:
                    return 170000;
                case 9:
                    return 250000;
                case 10:
                    return 500000;
            }
        }
        public int SouvenirAdditions()
        {
            switch (souvenirShops)
            {
                default:
                    return 0;
                case 2:
                    return 10000;
                case 3:
                    return 30000;
                case 4:
                    return 50000;
                case 5:
                    return 70000;
                case 6:                    
                case 7:                    
                case 8:                    
                case 9:
                case 10:
                    return 95000;

            }
        }
        public int GetCurrentTotalSouvenirs()
        {
            switch (souvenirShops)
            {
                default:
                    return 1000;
                case 2:
                    return 5000;
                case 3:
                    return 10000;
                case 4:
                    return 25000;
                case 5:
                    return 50000;
                case 6:
                    return 100000;
                case 7:
                    return 150000;
                case 8:
                    return 250000;
                case 9:
                    return 350000;
                case 10:
                    return 500000;
            }
        }
        public double GetCurrentSouvenirProfit()
        {
            switch (souvenirShops)
            {
                default:
                    return -10;
                case 2:
                    return -8.5;
                case 3:
                    return -5;
                case 4:
                    return -2.5;
                case 5:
                    return 0;
                case 6:
                    return 2.5;
                case 7:
                    return 5;
                case 8:
                case 9:
                case 10:
                    return 7.5;
            }
        }
        private int GetCurrentLuxuryBoxes()
        {
            switch (capacityStage)
            {
                default:
                    return 5;
                case 2:
                    return 10;
                case 3:
                    return 50;
                case 4:
                    return 100;
                case 5:
                    return 500;
                case 6:
                    return 1000;
                case 7:
                    return 1500;
                case 8:
                    return 2000;
                case 9:
                    return 2500;
                case 10:
                    return 5000;

            }
        }
        private int GetCurrentUpperDeck()
        {
            switch (capacityStage)
            {
                default:
                    return 9995;
                case 2:
                    return 11240;
                case 3:
                    return 12450;
                case 4:
                    return 14900;
                case 5:
                    return 17000;
                case 6:
                    return 19000;
                case 7:
                    return 23500;
                case 8:
                    return 28000;
                case 9:
                    return 35000;
                case 10:
                    return 45000;

            }
        }
        private int GetCurrentLowerDeck()
        {
            switch (capacityStage)
            {
                default:
                    return 10000;
                case 2:
                    return 11250;
                case 3:
                    return 12500;
                case 4:
                    return 15000;
                case 5:
                    return 17500;
                case 6:
                    return 20000;
                case 7:
                    return 25000;
                case 8:
                    return 30000;
                case 9:
                    return 37500;
                case 10:
                    return 50000;

            }
        }
        public int GetCapacity(int capacityStage)
        {
            switch(capacityStage)
            {
                default:
                    return 20000;
                case 2:
                    return 22500;
                case 3:
                    return 25000;
                case 4:
                    return 30000;
                case 5:
                    return 35000;
                case 6:
                    return 40000;
                case 7:
                    return 50000;
                case 8:
                    return 60000;
                case 9:
                    return 75000;
                case 10:
                    return 100000;

            }
        }
        public int GetConcessionStyle()
        {
            return concessionStyle;
        }
        public int GetSouvenirShops()
        {
            return souvenirShops;
        }
        public int GetUpgradesInProgress()
        {
            return upgradesInProgress;
        }
        public bool GetConcessionStatus(int i)
        {
            return concessions[i];
        }
        public sbyte UpgradeCapacity(int stage)
        {
            if (capacityUpgradeProgress != 0)
                return 1;
            else if (upgradesInProgress + 4 > MAX_UPGRADES)
                return 2;
            else if (stage <= capacityStage || stage > 10)
                return 3;
            
            upgradesInProgress += 4;
            capacityUpgradeProgress = 1;

            return 0;
        }
        public sbyte UpgradeConcessionStyle(int stage)
        {
            if (concessionStyleProgress != 0)
                return 1;
            else if (upgradesInProgress + 2 > MAX_UPGRADES)
                return 2;
            else if (stage <= concessionStyle || stage > 10)
                return 3;

            upgradesInProgress += 2;
            concessionStyleProgress = 1;

            return 0;
        }
        public sbyte UpgradeSouvenirShops(int stage)
        {
            if (souvenirShopsProgress != 0)
                return 1;
            else if (upgradesInProgress + 2 > MAX_UPGRADES)
                return 2;
            else if (stage <= souvenirShops || stage > 10)
                return 3;

            upgradesInProgress += 2;
            souvenirShopsProgress = 1;

            return 0;
        }
        public void UpgradeConcession(int num)
        {
            upgradesInProgress++;
            concessions[num] = true;
        }
        public double GetMaintenance(int capacity = -1, int concessionTypes = -1, int souvenirs = -1, bool[] concessionNumbers = null)
        {
            int numOfConcessions = 0;
            if(capacity == -1)
            {
                capacity = capacityStage;
                concessionTypes = concessionStyle;
                souvenirs = souvenirShops;
                concessionNumbers = concessions;
            }
            else
            {
                capacity++;
                concessionTypes++;
                souvenirs++;
            }

            foreach (bool b in concessionNumbers)
                numOfConcessions += b ? 1 : 0;

            double price = 0;

            price += GetConcessionPurchasePrice(numOfConcessions);
            price += GetSouvenirPrice(souvenirs - 1);
            price += GetCapacityPrice(capacity - 1);
            price += GetConcessionPrice(concessionTypes - 1);

            return price * .2 + 2000000;
        }
        public string ConcessionPurchases(int num)
        {
            string[] temp = new string[] { "Beer", "Wine", "Hot Dogs", "French Fries", "Peanuts", "Cotton Candy", "Hamburgers", "Pretzels", "Wings", "Ice Cream" };
            return temp[num];            
        }
    }
}