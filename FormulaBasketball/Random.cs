using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    [Serializable]
    public class Random
    {
        private System.Random r;
        public Random()
        {
            r = new System.Random();
        }
        public int Next(int v1, int v2)
        {
            return r.Next(v1, v2);
        }
        public int Next(int maxValue)
        {
            return r.Next(maxValue);
        }
        public double NextDouble()
        {
            return r.NextDouble();
        }
        public bool NextBool()
        {
            return r.Next(2) == 0;
        }
        public T Select<T>(List<T> list)
        {
            return list[r.Next(list.Count)];
        }
        private bool _hasDeviate;
        private double _storedDeviate;
        public int NextGaussian(int mu = 0, int sigma = 1)
        {
            if (sigma <= 0)
                throw new ArgumentOutOfRangeException("sigma", "Must be greater than zero.");
            if (_hasDeviate)
            {
                _hasDeviate = false;
                return (int)Math.Round(_storedDeviate * sigma + mu);
            }

            double v1, v2, rSquared;
            do
            {
                // two random values between -1.0 and 1.0
                v1 = 2 * r.NextDouble() - 1;
                v2 = 2 * r.NextDouble() - 1;
                rSquared = v1 * v1 + v2 * v2;
                // ensure within the unit circle
            } while (rSquared >= 1 || rSquared == 0);

            // calculate polar tranformation for each deviate
            var polar = Math.Sqrt(-2 * Math.Log(rSquared) / rSquared);
            // store first deviate
            _storedDeviate = v2 * polar;
            // return second deviate
            return (int)Math.Round(v1 * polar * sigma + mu);
        }
    }
}
