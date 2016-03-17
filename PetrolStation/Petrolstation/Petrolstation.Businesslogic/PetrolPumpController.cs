using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class PetrolPumpController
    {
        // Private Konstruktor
        private PetrolPumpController() { }

        // private members
        private static PetrolPumpController instance;

        private Dictionary<int, PetrolPump> petrolpumps;

        // public methods
        public PetrolPumpController GetInstance()
        {
            if (instance == null)
            {
                instance = new PetrolPumpController();
            }
            return instance;
        }

        public void UnlockPump(int ppumpId)
        {
            petrolpumps.Where(x => x.Id == )
        }

        public void AddPump(PetrolPump ppetrolPump)
        {
            int lastKey = petrolpumps.Keys.Last();
            lastKey += 1;
            petrolpumps.Add(lastKey, ppetrolPump);
        }

    }
}
