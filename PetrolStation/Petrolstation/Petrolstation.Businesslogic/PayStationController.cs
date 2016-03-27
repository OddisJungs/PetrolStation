using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class PayStationController
    {
        // private members
        private static PayStationController instance;

        private List<PayStation> payStations;

        // Private Konstruktor
        private PayStationController()
        {
            payStations = new List<PayStation>();
            DataContainer dataContext = new DataContainer();
            payStations.AddRange(dataContext.Load<PayStation>());
        }

        // public methods
        public static PayStationController GetInstance()
        {
            if (instance == null)
            {
                instance = new PayStationController();
            }
            return instance;
        }

    }
}
