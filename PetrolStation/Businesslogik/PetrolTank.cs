using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businesslogik;

namespace PetrolStation.Businesslogic
{
    public class PetrolTank
    {
        // Konstruktor
        public PetrolTank(Fuel pfuel){

        }

        // private member
        private int fuelLevel; // remaining fuel in ml
        private int fuelPrice;
        private Fuel fuel;

        // public method
        public void DecreaseFuelLevel(int pamount)
        {
            fuelLevel -= pamount;
        }

        public int GetFuelLevel()
        {
            return fuelLevel;
        }
    }
}
