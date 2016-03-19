using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class MoneyContainer
    {
        // private Members
        private decimal lowCriticalPercent;
        private decimal maxCriticalPercent;
        private int maxCount;
        private int count;
        private int worth;

        // Konstructor
        public MoneyContainer(int pworth, int pmaxCount, decimal plowCriticalPercent, decimal pmaxCriticalPercent, int pcount = 0)
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

        public void IncreaseCount(int pcount = 1)
        {
            count += pcount;
        }

        public void DecreaseCount(int pcount = 1)
        {
            count -= pcount;
        }

        public void CheckCriticalPercent()
        {
            if(maxCount/(decimal)count > maxCount)
            {
                throw new Exception("Max Critical Fullage reached");
            }

            else if(maxCount/(decimal)count < lowCriticalPercent)
            {
                throw new Exception("Min Critical Fullage reached");
            }
        }
    }
}
