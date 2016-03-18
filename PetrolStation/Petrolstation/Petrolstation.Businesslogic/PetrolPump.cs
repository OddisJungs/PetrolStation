using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class PetrolPump
    {
        // Constructor
        public PetrolPump()
        {
            // Add himself to the PetrolPumpController
            petrolPumpId = 0;
            PetrolPumpController.GetInstance().AddPump(this);
            taps = new List<Tap>();
        }

        // private members
        private int petrolPumpId;
        private List<Tap> taps;

        // public methods

        public void AddTap(Tap ptap)
        {
            taps.Add(ptap);
        }
       
        public void SetId(int ppumpId)
        {
            petrolPumpId = ppumpId;
        }

        public int GetId()
        {
            return petrolPumpId;
        }

        public void Fuelling(Tap ptap)
        {
            foreach(Tap oneTap in taps)
            {
                if (oneTap != ptap)
                {
                    oneTap.Lock();
                }
            }

            // Do fuelling
        }
    }
}
