using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class Quittance : DataItem
    {
        // private members
        private DateTime createdAt;
        private int amountToPay;
        private int litersTanked;

        // public Constructor
        public Quittance(int pamountToPay, int plitersTanked)
        {
            createdAt = DateTime.Now;
            amountToPay = pamountToPay;
            litersTanked = plitersTanked;

            Save();
        }

        // public methods


    }
}
