using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class PetrolPump
    {
        private int number;
        private int fueledVolume;
        private List<Tap> taps;

        public int GetNumber()
        {
            return number;
        }

        public void SetNumber(int pnumber)
        {
            number = pnumber;
        }


        public void UnlockTaps()
        {
            foreach (Tap tap in taps)
            {
                
            }
        }

        public int GetAmountToPay()
        {
            return 0;
        }

        public void Fuelling(Tap ptap)
        {

        }
    }
}
