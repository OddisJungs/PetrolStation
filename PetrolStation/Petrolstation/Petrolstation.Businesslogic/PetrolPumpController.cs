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
        private PetrolPumpController()
        {
            petrolPumps = new List<PetrolPump>();
        }

        // private members
        private static PetrolPumpController instance;

        private List<PetrolPump> petrolPumps;

        // public methods
        public static PetrolPumpController GetInstance()
        {
            if (instance == null)
            {
                instance = new PetrolPumpController();
            }
            return instance;
        }

        public PetrolPump UnlockPump(int ppumpId)
        {
            return petrolPumps.Where(x => x.GetId() == ppumpId).FirstOrDefault();
        }

        public void AddPump(PetrolPump ppetrolPump)
        {
            int petrolPumpId = petrolPumps.Count();
            ppetrolPump.SetId(petrolPumpId);
            petrolPumps.Add(ppetrolPump);
        }
    }
}
