using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businesslogik
{
    public class Fuel
    {
        // Konstruktor
        public Fuel(string pfueltype, int ppricePerLiter)
        {
            fueltype = pfueltype;
            pricePerLiter = ppricePerLiter;
        }

        // private member
        private string fueltype;
        private int pricePerLiter;

        // public methods
        public string GetFuelType()
        {
            return fueltype;
        }

        public int GetPricePerLiter()
        {
            return 0;
        }

        public void SetPricePerLiter(int pprice)
        {

        }
    }
}
