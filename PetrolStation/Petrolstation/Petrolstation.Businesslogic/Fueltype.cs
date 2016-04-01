using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class Fueltype
    {
        // Private attributes
        private string name; //Name of the Fueltype object
        private int pricePerLiter;

        // Constructor
        public Fueltype(string pname, int ppricePerLiter)
        {
            name = pname;
            pricePerLiter = ppricePerLiter;
        }

        /// <summary>
        /// Get the value of 'pricePerLiter'.
        /// </summary>
        /// <returns></returns>
        public int GetPricePerLiter()
        {
            return pricePerLiter;
        }

        /// <summary>
        /// Get the value of 'name'.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return name;
        }
    }
}
