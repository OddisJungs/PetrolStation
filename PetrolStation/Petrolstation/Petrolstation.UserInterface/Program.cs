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
            while (true)
            {
                SelectOrCreatePump();
            }
        }

        static private void SelectOrCreatePump()
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
                PetrolPumpController.GetInstance().GetPump(pumpId);
            }
        }
        static private void SelectTap()
        {

        }
    }
}
