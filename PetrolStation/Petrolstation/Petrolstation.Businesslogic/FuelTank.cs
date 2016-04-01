using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    [Serializable]
    public class FuelTank : PetrolStationObject
    {
        // Private attributes
        private int maxLevel;
        private int fuelLevel;
        private decimal lowCriticalVolumePercent;
        private Fueltype fuelType;
        private bool isCritical = false;

        // Constructor
        public FuelTank(int pmaxLevel, decimal plowCriticalVolumePercent, Fueltype pfuelType)
        {
            maxLevel = pmaxLevel;
            fuelLevel = 0;
            lowCriticalVolumePercent = plowCriticalVolumePercent;
            fuelType = pfuelType;
        }

        /// <summary>
        /// Decrease the actual value of 'fuelLevel'.
        /// </summary>
        /// <param name="pamount"></param>
        public void DecreaseFuelLevel(int pamount)
        {
            fuelLevel = fuelLevel - pamount;
            CheckIfCritical();
        }

        /// <summary>
        /// Get the value the Method 'GetPricePerLiter' from the 'fuelType'.
        /// </summary>
        /// <returns></returns>
        public int GetPricePerLiter()
        {
            return fuelType.GetPricePerLiter();
        }

        /// <summary>
        /// Get the value the Method 'GetFuelTypeName' from the 'fuelType'.
        /// </summary>
        /// <returns></returns>
        public string GetFuelTypeName()
        {
            return fuelType.GetName();
        }

        /// <summary>
        /// Get the value of 'IsCritical'.
        /// </summary>
        /// <returns></returns>
        public bool GetIsCritical()
        {
            return isCritical;
        }

        /// <summary>
        /// Check if the fuelLevel critical or not.
        /// </summary>
        private void CheckIfCritical()
        {
            decimal fuelLevelPercent = 100 / maxLevel * fuelLevel;
            if (fuelLevelPercent <= lowCriticalVolumePercent)
            {
                isCritical = true;
            }
        }
    }
}
