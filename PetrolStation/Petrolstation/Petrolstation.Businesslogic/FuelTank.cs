using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Fueltype fuelType;
        public event EventHandler<CriticalEventArgs> CriticalEvent;

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
            OnCriticalEventArgs(fuelLevel);
        }

        public int GetPricePerLiter()
        {
            return fuelType.GetPricePerLiter();
        }

        public string GetFuelTypeName()
        {
            return fuelType.GetName();
        }

        protected void OnCriticalEventArgs(int pfuelLevel)
        {
            EventHandler<CriticalEventArgs> handler = CriticalEvent;
            if (handler != null)
            {
                if ((100 / maxLevel *pfuelLevel) <= lowCriticalVolumePercent)
                {
                    decimal fuelLevelPercent = 100 / maxLevel * pfuelLevel;
                    
                }
            }
        }
    }
}
