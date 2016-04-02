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
        private Func<Tap, int> fuellingMethod;
        private FuelTank fuelTank;
        private bool locked;
        private int id;

        // Constructor

        /// <summary>
        /// Constructs a Tap object
        /// </summary>
        /// <param name="pfuellingMethod">The Fuelling-Method of his PetrolPump</param>
        public Tap(FuelTank pfueltank, int pid)
        {
            locked = false;
            fuellingMethod = pfuellingMethod;
            fuelTank = pfueltank;
            id = pid;
        }

        // public Methods

        /// <summary>
        /// Set 'locked' to 'true'.
        /// </summary>
        public void Lock()
        {
            locked = true;
        }

        /// <summary>
        /// Set 'locked' to 'false'.
        /// </summary>
        public void Unlock()
        {
            locked = false;
        }

        /// <summary>
        /// Call the method 'DecreaseFuelLevel' from 'fuelTank'.
        /// </summary>
        /// <param name="pamount"></param>
        public void DecreaseFuelLevelOfTank(int pamount)
        {
            fuelTank.DecreaseFuelLevel(pamount);
        }

        /// <summary>
        /// Get the value of the method 'GetPricePerLiter' from 'fuelTank'.
        /// </summary>
        /// <returns></returns>
        public int GetPricePerLiter()
        {
            return fuelTank.GetPricePerLiter();
        }

        /// <summary>
        /// Get the value of the method 'GetFuelTypeName' from 'fuelTank'.
        /// </summary>
        /// <returns></returns>
        public string GetFuelTypeName()
        {
            return fuelTank.GetFuelTypeName();
        }

        /// <summary>
        /// Get the value of 'id'.
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            return id;
        }
    }
}
