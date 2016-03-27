using Petrolstation.Businesslogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            PetrolPumpController pumpController = PetrolPumpController.GetInstance();
            PayStationController payStationConroller = PayStationController.GetInstance();

        }
    }
}
