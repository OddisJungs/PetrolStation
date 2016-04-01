using Petrolstation.Businesslogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.UserInterface
{
    internal class OptionMenu
    {
        static internal void Show()
        {
            Console.WriteLine("Welcome To the Option Menu");
            Console.WriteLine("Press 1: Modify or Create PetrolPump");
            Console.WriteLine("Press 2: Create PayStation");
            string input = Console.ReadLine();
            int selection;
            bool parsingSuccessful = Int32.TryParse(input, out selection);
            if (parsingSuccessful)
            {
                switch (selection)
                {
                    case 1:
                        ModifyOrCreatePump();
                        break;
                    case 2:
                        Console.WriteLine("Do Something other");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!! INVALID INPUT !!!!!!!!!!!!!!!!!");
                Show();
            }
        }

        static internal void ModifyOrCreatePump()
        {
            Console.Write("Select a PetrolPump or create one with 'create'\nThe Pumps: {");
            foreach (int id in PetrolStationObjectController.GetInstance().GetListOfPumpIds())
            {
                Console.Write(String.Format("{0} ", id));
            }

            Console.WriteLine(" }");
            string input = Console.ReadLine();
            if (input.ToLower().Contains("create"))
            {
                // the pump add calls
                new PetrolPump();
                Console.Write("Created one PetrolPump\n");
                Show();
            }
            else
            {
                int pumpId;
                Int32.TryParse(input, out pumpId);
                PetrolPump pump = PetrolStationObjectController.GetInstance().GetObjectInstance<PetrolPump>(pumpId);
                ModifyOrCreateTap(pumpId);
            }
        }

        static internal void ModifyOrCreateTap(int ppumpId)
        {
            Console.WriteLine("Current Selected PumpId: " + ppumpId);
            Console.Write("Select a Tap or create one with 'create'\nThe Taps: {");
            PetrolPump petrolpump = PetrolStationObjectController.GetInstance().GetObjectInstance<PetrolPump>(ppumpId);
            foreach (int id in petrolpump.GetListOfTapsId())
            {
                Console.WriteLine(String.Format("{0} ", id));
            }

            Console.WriteLine(" }");
            string input = Console.ReadLine();
            if (input.ToLower().Contains("create"))
            {
                // the pump add calls
                //new Tap(petrolpump.Fuelling, );
                // MUST ADD AN FuelTankList FIRST!!!!!!!!!!!!!!!!!!!!!!!!!!
                Console.Write("Created one Tap\n");
                Show();
            }


        }
    }
}
