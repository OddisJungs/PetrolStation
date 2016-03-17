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
        private PetrolPumpController() { }

        // private members
        private static PetrolPumpController instance;

        public PetrolPumpController GetInstance()
        {
            if (instance == null)
            {
                instance = new PetrolPumpController();
            }
            return instance;
        }

    }
}
