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

        private List<PetrolPump> petrolPumps;

        // public methods
        public PetrolPumpController GetInstance()
        {
            if (instance == null)
            {
                instance = new PetrolPumpController();
            }
            return instance;
        }

        public PetrolPumpController UnlockPump(int ppumpId)
        {
            return petrolPumps.Where(x => x.Id == ppumpId).First();
        }

        public void AddPump(PetrolPump ppetrolPump)
        {
            int petrolPumpId = petrolPumps.Count();
            petrolPumps.SetKey()
            petrolPumps.Add(ppetrolPump);
        }

    }
}
