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
            DataContainer datacontainer = new DataContainer();
            List<PetrolPump> loadedPumps = datacontainer.Load<PetrolPump>();

            foreach(PetrolPump pump in loadedPumps)
            {
                AddPump(pump);
            }
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

        public List<int> GetListOfPumpIds()
        {
            List<int> pumpIds = new List<int>();
            foreach(PetrolPump pump in petrolPumps)
            {
                pumpIds.Add(pump.GetId());
            }

            return pumpIds;
        }

        public void ResetAndUnlockPump(int ppumpId)
        {
            PetrolPump pump = petrolPumps.Where(x => x.GetId() == ppumpId).FirstOrDefault();
            pump.ResetAmountToPay();
            pump.UnlockTaps();
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
