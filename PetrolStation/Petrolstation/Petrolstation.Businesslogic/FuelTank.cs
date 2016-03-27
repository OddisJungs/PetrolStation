using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    [Serializable]
    public class FuelTank
    {
        // Private attributes
        private int maxLevel;
        private int fuelLevel;
        private decimal lowCriticalVolumePercent;
        private Fueltype fuelType;
        private bool IsCritical = false;
        private decimal fuelLevelPercent;

        public FuelTank(int pmaxLevel, decimal plowCriticalVolumePercent, Fueltype pfuelType)
        {
            maxLevel = pmaxLevel;
            fuelLevel = 0;
            lowCriticalVolumePercent = plowCriticalVolumePercent;
            fuelType = pfuelType;
        }

        public void DecreaseFuelLevel(int pamount)
        {
            fuelLevel = fuelLevel - pamount;
            fuelLevelPercent = 100 / maxLevel * fuelLevel;
            CheckIfCritical(fuelLevel);
        }

        public int GetPricePerLiter()
        {
            return fuelType.GetPricePerLiter();
        }

        public string GetFuelTypeName()
        {
            return fuelType.GetName();
        }

        public bool GetIsCritical()
        {
            return IsCritical;
        }

        private void CheckIfCritical(int pfuelLevel)
        {
            if (fuelLevelPercent <= lowCriticalVolumePercent)
            {
                IsCritical = true;
            }
        }
    }
}
