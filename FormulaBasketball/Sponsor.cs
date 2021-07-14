using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    [Serializable]
    public class Sponsor
    {
        private static List<Tuple<int, string>> sponsors;
        private string thisSponsor;
        private int sponsorArea, yearsLeft;
        private double bonusMoney, moneyPerYear;
        private bool upgradeCapacity, accepted;
        public Sponsor(int teamNum, Random r, bool allowAll, int sponsorArea, int years, double bonusMoney, double moneyPerYear, bool upgradeCapacity = false)
        {
            if (sponsors == null)
            {
                sponsors = new List<Tuple<int, string>>();
                string[] lines = File.ReadAllLines("C:\\Users\\dmatt\\Documents\\GitHub\\Test\\FormulaBasketball\\bin\\Debug\\Sponsors.txt");
                foreach (string line in lines)
                {
                    string[] arr = line.Split(':');
                    sponsors.Add(new Tuple<int, string>(int.Parse(arr[0]), arr[1]));
                }
            }
            List<string> temp = new List<string>();
            foreach (Tuple<int, string> tuple in sponsors)
            {
                if (tuple.Item1 == teamNum || (allowAll && tuple.Item1 == -1))
                    temp.Add(tuple.Item2);
            }
            thisSponsor = temp[r.Next(temp.Count)];
            this.sponsorArea = sponsorArea;
            yearsLeft = years;
            this.bonusMoney = bonusMoney;
            this.moneyPerYear = moneyPerYear;
            this.upgradeCapacity = upgradeCapacity;
            accepted = false;
        }
        public double Accept()
        {
            accepted = true;
            return bonusMoney;
        }
        public bool GetAccepted()
        {
            return accepted;
        }
        public bool GetUpgradeCapacity()
        {
            return upgradeCapacity;
        }
        public int GetSponsorArea()
        {
            return sponsorArea;
        }
        public string GetName()
        {
            return thisSponsor;
        }
        public string GetOffer()
        {
            return (accepted ? "[ACCEPTED] " : "") + thisSponsor + " for " + yearsLeft + " years. This sponsor will give " + bonusMoney + " million right now, and pay " + moneyPerYear + " million every year for the duration of the sponsorship." + (upgradeCapacity ? " They will also pay for a singular upgrade to the stadium capacity" : "");

        }
        public double GetMoneyPerYear()
        {
            return moneyPerYear;
        }
        public override string ToString()
        {
            return thisSponsor + " for " + yearsLeft;
        }
    }
}
