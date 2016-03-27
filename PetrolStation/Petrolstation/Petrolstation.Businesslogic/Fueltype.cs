using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class FuelType
    {
        // Private attributes
        private string name;
        private int pricePerLiter;

        // Constructor
        public FuelType(string pname, int ppricePerLiter)
        {
            name = pname;
            pricePerLiter = ppricePerLiter;
        }

        //Get- / Set-Methods
        public string GetName()
        {
            return name;
        }

        public void SetName(string pname)
        {
            name = pname;
        }

        public int GetPricePerLiter()
        {
            return pricePerLiter;
        }

        public void SetPricePerLiter(int ppricePerLiter)
        {
            pricePerLiter = ppricePerLiter;
        }
    }
}
