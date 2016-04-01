using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class PetrolStationInstanceController
    {
        // private members
        private static PetrolStationInstanceController instance;

        private List<PetrolStationObjectInstance> petrolStationObjectInstances;

        // Private Konstruktor
        private PetrolStationInstanceController()
        {
            DataContainer datacontainer = new DataContainer();
            petrolStationObjectInstances = new List<PetrolStationObjectInstance>();
            // Load Pumps
            petrolStationObjectInstances.AddRange(datacontainer.Load<PetrolPump>());
        }

        // public methods
        public static PetrolStationInstanceController GetInstance()
        {
            if (instance == null)
            {
                instance = new PetrolStationInstanceController();
            }
            return instance;
        }

        public List<int> GetListOfPumpIds()
        {
            List<int> pumpIds = new List<int>();
            foreach(PetrolStationObjectInstance pump in petrolStationObjectInstances.Where(x => x.GetType() == typeof(PetrolPump)))
            {
                pumpIds.Add(pump.GetId());
            }

            return pumpIds;
        }

        public T GetObjectInstance<T>(int pid)
        {
            return (T)Convert.ChangeType(petrolStationObjectInstances.FirstOrDefault(x => x.GetId() == pid && x.GetType() == typeof(T)), typeof(T));
        }

        public void AddInstance(PetrolStationObjectInstance ppetrolStationObjectInstance)
        {
            int id = petrolStationObjectInstances.Count(x => x.GetType() == ppetrolStationObjectInstance.GetType()) + 1;
            ppetrolStationObjectInstance.SetId(id);
            petrolStationObjectInstances.Add(ppetrolStationObjectInstance);
        }
    }
}
