using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class PetrolStationObjectController
    {
        // private members
        private static PetrolStationObjectController @object;

        private List<PetrolStationObject> petrolStationObjectInstances;

        // Private Konstruktor
        private PetrolStationObjectController()
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
        public static PetrolStationObjectController GetInstance()
        {
            if (@object == null)
            {
                @object = new PetrolStationObjectController();
            }
            return @object;
        }

        public List<int> GetInstanceIds<T>()
        {
            List<int> ids = new List<int>();
            foreach(PetrolStationObject petrolStationObject in petrolStationObjectInstances.Where(x => x.GetType() == typeof(T)))
            {
                ids.Add(petrolStationObject.GetId());
            }
            return ids.OrderBy(x => x).ToList();
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
