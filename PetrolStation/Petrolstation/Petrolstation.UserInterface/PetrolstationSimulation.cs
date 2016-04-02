using Petrolstation.Businesslogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.UserInterface
{
    internal class PetrolstationSimulation
    {
        public static void Show()
        {
            Console.WriteLine("Welcome to the PetrolstationSimulation.");
            Console.WriteLine("In this magical place you can fuel your vehicel and pay after that.");
            Console.WriteLine("You can choose on your own which fueltype you want to fuel and also how much.");
            Console.Write("Select a PetrolPump for the fuelling with the number\nThe Pumps: {");
            foreach (int id in PetrolStationObjectController.GetInstance().GetInstanceIds<PetrolPump>())
            {
                Console.Write(String.Format("{0} ", id));
            }

            Console.WriteLine(" }");
            string input = Console.ReadLine();
            int pumpId;
            bool parsingsucceded = Int32.TryParse(input, out pumpId);
            if (parsingsucceded)
            {
                FuelOnPump(pumpId);
            }
        }

        static internal void FuelOnPump(int ppumpId)
        {
            Console.WriteLine("Current Selected PumpId: " + ppumpId);
            Console.Write("Select the tap with his number\nThe Taps: {");
            PetrolPump petrolpump = PetrolStationObjectController.GetInstance().GetObjectInstance<PetrolPump>(ppumpId);
            foreach (KeyValuePair<int, string> tap in petrolpump.GetListOfTapsId())
            {

                Console.Write(String.Format("{0} : {1}, ", tap.Key, tap.Value));
            }

            Console.Write(" }\n");
            string input = Console.ReadLine();
            int tapId;
            bool parsingsucceded = Int32.TryParse(input, out tapId);
            PetrolPump selectedPump = PetrolStationObjectController.GetInstance().GetObjectInstance<PetrolPump>(ppumpId);
        }
    }
}
