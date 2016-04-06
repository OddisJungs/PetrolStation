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

        /// <summary>
        /// Get value of 'worth'.
        /// </summary>
        /// <returns></returns>
        public int GetWorth()
        {
            return worth;
        }

        /// <summary>
        /// Increase the value of 'count' by one.
        /// </summary>
        public void IncreaseCount()
        {
            count++;
        }
        /// <summary>
        /// Decrease the value of 'count' by one.
        /// </summary>
        public void DecreaseCount()
        {
            count--;
        }

        /// <summary>
        /// Throw an exception, when the the fullage is critical.
        /// </summary>
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
