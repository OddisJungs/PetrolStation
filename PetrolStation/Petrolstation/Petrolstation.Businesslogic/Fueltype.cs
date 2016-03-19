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

        public int GetPricePerLiter()
        {
            return pricePerLiter;
        }

        public string GetName()
        {
            return name;
        }
    }
}
