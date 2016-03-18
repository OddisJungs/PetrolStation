using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class Tap
    {
        // Constructor
        /// <summary>
        /// Constructs a Tap object
        /// </summary>
        /// <param name="pfuellingMethod">The Fuelling-Method of his PetrolPump</param>
        public Tap(Delegate pfuellingMethod, FuelTank pfueltank)
        {
            locked = false;
            fuellingMethod = pfuellingMethod;
            fuelTank = pfueltank;
        }

        // private members
        private Delegate fuellingMethod;
        private FuelTank fuelTank;
        private bool locked;

        // public Methods
        public void Take()
        {
            fuellingMethod.DynamicInvoke(this);
        }

        public void Lock()
        {
            locked = true;
        }

        public void Unlock()
        {
            locked = false;
        }
    }
}
