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
                Console.WriteLine("Welcome to the main menu of the petrol station");
                Console.WriteLine("Press 1: Enter the Petrol Station Simulation software");
                Console.WriteLine("Press 2: To add Petrol Station Parts to the Simulation software");
                Console.WriteLine("Press 3 : Enter QuittanceManagement for more information about the fuelling progress");
                string input = Console.ReadLine();
                int selection;
                bool conversionSuccessful = Int32.TryParse(input, out selection);
                if (conversionSuccessful)
                {
                    switch (selection)
                    {
                        case 1:
                            PetrolstationSimulation.Show();
                            break;
                        case 2:
                            OptionMenu.Show();
                            break;
                        case 3:
                            QuittanceManagement.Show();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
