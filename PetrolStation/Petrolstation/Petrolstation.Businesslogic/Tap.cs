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
        private FuelTank fuelTank;
        private bool locked;
        private int id;

        // Constructor

        /// <summary>
        /// Constructs a Tap object, only internal, because the taps should be created in the petrolpump
        /// </summary>
        internal Tap(FuelTank pfueltank, int pid)
        {
            locked = false;
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

        public bool IsLocked()
        {
            return locked;
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
        /// Get the value of 'fuelTank.GetFueltype()'.
        /// </summary>
        /// <returns></returns>
        public Fueltype GetFueltype()
        {
            return fuelTank.GetFueltype();
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
