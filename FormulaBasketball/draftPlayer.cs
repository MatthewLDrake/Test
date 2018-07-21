using System;

namespace FormulaBasketball
{
    public class draftPlayer
    {
        public player player;
        private bool isTaken;
        private int poisitonNumber;
        public draftPlayer(player player, int posNumb)
        {
            this.player = player;
            poisitonNumber = posNumb;
            isTaken = false;
        }

        public bool taken
        {
            get { return isTaken; }
            set { isTaken = value; }
        }

        internal int posNum
        {
            get { return poisitonNumber; }
            set { poisitonNumber = value; }

        }
    }
}