using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    [Serializable]
    public class Tap
    {
        // private members
        private Func<Tap, String> fuellingMethod;
        private FuelTank fuelTank;
        private bool locked;

        // Constructor
        /// <summary>
        /// Constructs a Tap object
        /// </summary>
        /// <param name="pfuellingMethod">The Fuelling-Method of his PetrolPump</param>
        public Tap(Func<Tap, String> pfuellingMethod, FuelTank pfueltank)
        {
            locked = false;
            fuellingMethod = pfuellingMethod;
            fuelTank = pfueltank;
        }

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

        public void DecreaseFuelLevelOfTank(int pamount)
        {
            fuelTank.DecreaseFuelLevel(pamount);
        }

        public int GetPricePerLiter()
        {
            return fuelTank.GetPricePerLiter();
        }

        public string GetFuelTypeName()
        {
            return fuelTank.GetFuelTypeName();
        }
    }
}
