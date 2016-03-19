using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class PetrolPumpController
    {
        // private members
        private static PetrolPumpController instance;

        private List<PetrolPump> petrolPumps;

        // Private Konstruktor
        private PetrolPumpController()
        {
            petrolPumps = new List<PetrolPump>();
        }

        // public methods
        public static PetrolPumpController GetInstance()
        {
            if (instance == null)
            {
                instance = new PetrolPumpController();
            }
            return instance;
        }

        public void ResetAndUnlockPump(int ppumpId)
        {
            PetrolPump pump = petrolPumps.Where(x => x.GetId() == ppumpId).FirstOrDefault();
            pump.ResetAmountToPay();
        }

        public int GetAmountToPay(int ppumpId)
        {
            return petrolPumps.Where(x => x.GetId() == ppumpId).First().GetAmountToPay();
        }

        public void AddPump(PetrolPump ppetrolPump)
        {
            int petrolPumpId = petrolPumps.Count();
            ppetrolPump.SetId(petrolPumpId + 1);
            petrolPumps.Add(ppetrolPump);
        }
    }
}
