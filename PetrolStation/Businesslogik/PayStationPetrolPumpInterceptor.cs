using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Businesslogic
{
    public class PayStationPetrolPumpInterceptor
    {
        // private members
        private List<PetrolPump> petrolPumps;

        // public methods
        public PetrolPump GetPetrolPumpById(int pid)
        {
            return new PetrolPump();
        }
    }
}
