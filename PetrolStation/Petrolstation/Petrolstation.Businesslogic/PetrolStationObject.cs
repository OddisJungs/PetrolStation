using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    [Serializable]
    public class PetrolStationObject : DataItem
    {
        // Private Members
        private int id;

        // Constructor
        public PetrolStationObject()
            : base()
        {
            // Add himself to the PetrolPumpController
            PetrolStationInstanceController.GetInstance().AddInstance(this);
        }

        // public methods Item
        public int GetId()
        {
            return id;
        }

        public void SetId(int pid)
        {
            id = pid;
        }

    }
}
