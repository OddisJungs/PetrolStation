using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class PetrolPump
    {
        // Constructor
        public PetrolPump()
        {
            PetrolPumpController.GetInstance().AddPump(this);
        }

        // private members
        private int petrolPumpId;

        // public methods
        public void SetId(int ppumpId)
        {
            petrolPumpId = ppumpId;
        }

        public int GetId()
        {
            return petrolPumpId;
        }
    }
}
