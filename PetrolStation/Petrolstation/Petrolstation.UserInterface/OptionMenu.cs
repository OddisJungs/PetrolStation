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
            Console.WriteLine("Press 1: Create Fueltank");
            Console.WriteLine("Press 2: Modify or Create PetrolPump");
            Console.WriteLine("Press 3: Create PayStation");
            string input = Console.ReadLine();
            int selection;
            bool parsingSuccessful = Int32.TryParse(input, out selection);
            if (parsingSuccessful)
            {
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Do Something");
                        break;
                    case 2:
                        ModifyOrCreatePump();
                        break;
                    case 3:
                        Console.WriteLine("Do Something other");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!! INVALID INPUT !!!!!!!!!!!!!!!!!");
            }
        }

        static internal void ModifyOrCreatePump()
        {
            Console.Write("Select a PetrolPump or create one with 'create'\nThe Pumps: {");
            foreach (int id in PetrolPumpController.GetInstance().GetListOfPumpIds())
            {
                Console.Write(String.Format("{0} ", id));
            }

            Console.Write(" }\n");
            string input = Console.ReadLine();
            if (input.ToLower().Contains("create"))
            {
                // the pump add calls
                new PetrolPump();
                Console.Write("Created one PetrolPump\n");
            }
            else
            {
                int pumpId;
                Int32.TryParse(input, out pumpId);
                PetrolPump pump = PetrolPumpController.GetInstance().GetPump(pumpId);
                Console.Write(pump.GetAmountToPay());
            }
        }
    }
}
