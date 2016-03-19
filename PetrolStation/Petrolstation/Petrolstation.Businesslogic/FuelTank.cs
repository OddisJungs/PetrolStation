using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class FuelTank
    {
        // Private attributes
        private int maxLevel;
        private int fuelLevel;
        private decimal lowCriticalVolumePercent;
        private decimal highCriticalVolumePercent;
        private Fueltype fuelType;

        public FuelTank(int pmaxLevel, decimal plowCriticalVolumePercent, decimal phighCriticalVolumePercent, Fueltype pfuelType)
        {
            maxLevel = pmaxLevel;
            fuelLevel = 0;
            lowCriticalVolumePercent = plowCriticalVolumePercent;
            highCriticalVolumePercent = phighCriticalVolumePercent;
            fuelType = pfuelType;
        }


        public void DecreaseFuelLevel(int pamount)
        {
            fuelLevel = fuelLevel - pamount;
        }

        public int GetPricePerLiter()
        {
            return fuelType.GetPricePerLiter();
        }

        public string GetFuelTypeName()
        {
            return fuelType.GetName();
        }
    }
}
