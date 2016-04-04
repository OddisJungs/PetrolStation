using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    [Serializable]
    public class MoneyContainer
    {
        // private Members
        private double lowCriticalPercent;
        private double maxCriticalPercent;
        private int maxCount;
        private int count;
        private int worth;

        // Konstructor
        public MoneyContainer(int pworth, int pmaxCount, double plowCriticalPercent, double pmaxCriticalPercent, int pcount = 0)
        {
            lowCriticalPercent = plowCriticalPercent;
            maxCriticalPercent = pmaxCriticalPercent;
            maxCount = pmaxCount;
            count = pcount;
            worth = pworth;
        }

        public int GetWorth()
        {
            return worth;
        }

        public void IncreaseCount()
        {
            count++;
        }

        public void DecreaseCount()
        {
            count--;
        }

        public void CheckCriticalPercent()
        {
            if(maxCount/(double)count > maxCount)
            {
                throw new Exception("Max Critical Fullage reached");
            }

            else if(maxCount/(double)count < lowCriticalPercent)
            {
                throw new Exception("Min Critical Fullage reached");
            }
        }
    }
}
