using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.UserInterface
{
    internal class QuittanceManagement
    {
        public static void Show()
        {
            Console.WriteLine("Welcome to the QuittanceManagement");
            Console.WriteLine("Press 1 : To see the earnings");
            Console.WriteLine("Press 2 : To see the liters tanked per fueltype");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                int intInput;
                bool parsingsucceded = Int32.TryParse(input, out intInput);
                if (parsingsucceded)
                {
                    if (intInput == 1)
                    {
                        ListAllEarnings();
                    }
                    else if (intInput == 2)
                    {
                        LitersTankedPerFueltype();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input, back to the main menu");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Input, back to the main menu");
            }
        }

        static internal void ListAllEarnings()
        {
            ReasonWhyThisIsNotImplemented();
        }

        static internal void LitersTankedPerFueltype()
        {
            ReasonWhyThisIsNotImplemented();            
        }

        static internal void ReasonWhyThisIsNotImplemented()
        {
            Console.WriteLine("This part of our fantastic console application is still in progress and can be bought by a following DLC");
            Console.WriteLine("The logic is already implemented in our business logic.");
            Console.ReadLine();
        }
    }
}
