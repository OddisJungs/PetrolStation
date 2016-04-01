using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class PetrolPumpInstanceController
    {
        // private members
        private static PetrolPumpInstanceController instance;

        private List<PetrolPump> petrolPumps;

        // Private Konstruktor
        private PetrolPumpInstanceController()
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
        public static PetrolPumpInstanceController GetInstance()
        {
            if (instance == null)
            {
                instance = new PetrolPumpInstanceController();
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

        public PetrolPump GetPump(int ppumpId)
        {
            return petrolPumps.Where(x => x.GetId() == ppumpId).FirstOrDefault();
        }

        public void AddPump(PetrolPump ppetrolPump)
        {
            int petrolPumpId = petrolPumps.Count();
            ppetrolPump.SetId(petrolPumpId + 1);
            petrolPumps.Add(ppetrolPump);
        }
    }
}
