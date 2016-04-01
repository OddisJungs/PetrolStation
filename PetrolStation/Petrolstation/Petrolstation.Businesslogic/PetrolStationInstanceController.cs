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

        private List<PetrolStationObject> petrolStationObjectInstances;

        // Private Konstruktor
        private PetrolStationInstanceController()
        {
            DataContainer datacontainer = new DataContainer();
            petrolStationObjectInstances = new List<PetrolStationObject>();
            // Load Pumps
            petrolStationObjectInstances.AddRange(datacontainer.Load<PetrolPump>());
            // Load Fueltanks
            petrolStationObjectInstances.AddRange(datacontainer.Load<FuelTank>());
            // PayStation
            petrolStationObjectInstances.AddRange(datacontainer.Load<PayStation>());
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
            foreach(PetrolStationObject pump in petrolStationObjectInstances.Where(x => x.GetType() == typeof(PetrolPump)))
            {
                pumpIds.Add(pump.GetId());
            }

            return pumpIds;
        }

        public T GetObjectInstance<T>(int pid)
        {
            return (T)Convert.ChangeType(petrolStationObjectInstances.FirstOrDefault(x => x.GetId() == pid && x.GetType() == typeof(T)), typeof(T));
        }

        public void AddInstance(PetrolStationObject ppetrolStationObject)
        {
            int id = petrolStationObjectInstances.Count(x => x.GetType() == ppetrolStationObject.GetType()) + 1;
            ppetrolStationObject.SetId(id);
            petrolStationObjectInstances.Add(ppetrolStationObject);
        }
    }
}
