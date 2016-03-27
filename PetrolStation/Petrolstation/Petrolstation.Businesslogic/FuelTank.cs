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
        private int lowCriticalVolumePercent;
        private int highCriticalVolumePercent;
        private FuelType fuelType;

        public FuelTank(int pmaxLevel, int plowCriticalVolumePercent, int phighCriticalVolumePercent, FuelType pfuelType)
        {
            maxLevel = pmaxLevel;
            fuelLevel = 0;
            lowCriticalVolumePercent = plowCriticalVolumePercent;
            highCriticalVolumePercent = phighCriticalVolumePercent;
            fuelType = pfuelType;
        }


        public int CalcFuelLevel(int pamount)
        {
            return fuelLevel + pamount;
        }

        public int GetMaxLevel()
        {
            return maxLevel;
        }

        public void SetMaxLevel(int pmaxLevel)
        {
            maxLevel = pmaxLevel;
        }

        public int GetFuelLevel()
        {
            return fuelLevel;
        }

        public void SetFuelLevel(int pamount)
        {
            fuelLevel = CalcFuelLevel(pamount);
        }

        public int GetLowCriticalVolumePercent()
        {
            return lowCriticalVolumePercent;
        }

        public void SetLowCriticalVolumePercent(int plowCriticalVolumePercent)
        {
            lowCriticalVolumePercent = plowCriticalVolumePercent;
        }

        public int GetHighCriticalVolumePercent()
        {
            return highCriticalVolumePercent;
        }

        public void SetHighCriticalVolumePercent(int phighCriticalVolumePercent)
        {
            highCriticalVolumePercent = phighCriticalVolumePercent;
        }

        public FuelType GetFuelType()
        {
            return fuelType;
        }
    }
}
