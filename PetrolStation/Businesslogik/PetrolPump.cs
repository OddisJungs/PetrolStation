using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Businesslogic
{
    public class PetrolPump
    {
        // Konstruktor
        public PetrolPump()
        {

        }

        // private Member
        private int id;
        private int amountToPay;
        private List<Tap> taps;

        // Public Methoden
        public void Fuelling()
        {

        }

        public int GetId()
        {
            return id;
        }

        public void SetAmountToPayToZero()
        {
            amountToPay = 0;
        }

        public void SetDisplay()
        {

        }
    }
}
