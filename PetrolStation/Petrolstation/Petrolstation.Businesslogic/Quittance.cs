using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class Quittance : DataItem
    {
        // private members
        private DateTime createdAt;
        private int amountToPay;
        private int millilitersTanked;
        private Fueltype fuelType;

        // public Constructor
        public Quittance(int pamountToPay, int pmillilitersTanked, Fueltype pfuelType)
        {
            createdAt = DateTime.Now;
            amountToPay = pamountToPay;
            millilitersTanked = pmillilitersTanked;
            fuelType = pfuelType;

            // Path
            Save();
        }

        // public methods

        public DateTime GetCreatedAt()
        {
            return createdAt;
        }
       
        /// <summary>
        /// Get the value of 'amountType'.
        /// </summary>
        /// <returns></returns>
        public int GetAmountToPay()
        {
            return amountToPay;
        }

        /// <summary>
        /// Get the value of 'litersTanked'.
        /// </summary>
        /// <returns></returns>
        public int GetMililitersTanked()
        {
            return millilitersTanked;
        }

        /// <summary>
        /// Get the value of 'fuelType'.
        /// </summary>
        /// <returns></returns>
        public Fueltype GetFuelType()
        {
            return fuelType;
        }
    }
}
