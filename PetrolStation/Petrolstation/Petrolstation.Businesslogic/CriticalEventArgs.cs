using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class CriticalEventArgs : EventArgs
    {
        private int fuelLevel;
        private decimal fuelLevelPercent;

        public CriticalEventArgs(int pfuelLevel, decimal pfuelLevelPercent)
        {
            fuelLevel = pfuelLevel;
            fuelLevelPercent = pfuelLevelPercent;
        }

        public int GetCriticalFuelLevel()
        {
            return fuelLevel;
        }

        public decimal GetCriticalFuelLevelPercent()
        {
            return fuelLevelPercent;
        }
    }
}
