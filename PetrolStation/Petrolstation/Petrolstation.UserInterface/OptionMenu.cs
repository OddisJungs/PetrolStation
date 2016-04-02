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
            Console.WriteLine("Press 2: List PayStation");
            Console.WriteLine("Press 3: List or create an Fueltank");
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
                        ListPayStation();
                        break;
                    case 3:
                        ListOrCreateFueltank();
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
            foreach (int id in PetrolStationObjectController.GetInstance().GetInstanceIds<PetrolPump>())
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
                ListOrCreateTap(pumpId);
            }
        }

        static internal void ListOrCreateTap(int ppumpId)
        {
            Console.WriteLine("Current Selected PumpId: " + ppumpId);
            Console.Write("Select a Tap or create one with 'create'\nThe Taps: {");
            PetrolPump petrolpump = PetrolStationObjectController.GetInstance().GetObjectInstance<PetrolPump>(ppumpId);
            foreach (KeyValuePair<int, string> tap in petrolpump.GetListOfTapsId())
            {

                Console.WriteLine(String.Format("{0} : {1}, ", tap.Key, tap.Value));
            }

            Console.WriteLine(" }");
            string input = Console.ReadLine();
            if (input.ToLower().Contains("create"))
            {

                Console.WriteLine("With fueltank is connected to new tap?");
                Console.Write("{");
                foreach (int id in PetrolStationObjectController.GetInstance().GetInstanceIds<FuelTank>())
                {
                    Console.Write(String.Format("{0} : {1}, ", id, PetrolStationObjectController.GetInstance().GetObjectInstance<FuelTank>(id).GetFuelTypeName()));
                }
                Console.Write("}");
                input = Console.ReadLine();
                int inputId = Int32.Parse(input);
                FuelTank fuelTank = PetrolStationObjectController.GetInstance().GetObjectInstance<FuelTank>(inputId);
                petrolpump.AddTap(fuelTank);

                Show();
            }
        }

        static internal void ListPayStation()
        {
            Console.Write("Create a new Paystation with 'create'");
            Console.Write("Current Paystations: {");
            foreach (int id in PetrolStationObjectController.GetInstance().GetInstanceIds<PayStation>())
            {
                Console.Write(String.Format("{0} ", id));
            }
            Console.Write("}\n");
            string input = Console.ReadLine();
            if (input.ToLower().Contains("create"))
            {
                new PayStation();
            }
            else
            {
                Show();
            }
        }



        private static void ListOrCreateFueltank()
        {
            Console.WriteLine("Create new Fueltank with 'create'");
            Console.Write("Current Fueltanks: { ");
            foreach (int id in PetrolStationObjectController.GetInstance().GetInstanceIds<FuelTank>())
            {
                
                Console.Write(String.Format("{0} : {1}, ", id, PetrolStationObjectController.GetInstance().GetObjectInstance<FuelTank>(id).GetFuelTypeName()));
            }
            Console.Write("}\n");
            string input = Console.ReadLine();

            if (input.ToLower().Contains("create"))
            {
                Console.Write("The tank Volume in ml:  ");
                int tankVolume = Int32.Parse(Console.ReadLine());
                Console.Write("Critical tank fuelstate in percent:  ");
                decimal criticalLevel = Decimal.Parse(Console.ReadLine());
                Console.Write("The Fueltypename:  ");
                string fueltypename = Console.ReadLine();
                Console.Write("The PricePerLiter (In Rp.):  ");
                int priceperliter = Int32.Parse(Console.ReadLine());
                Fueltype fueltype = new Fueltype(fueltypename, priceperliter);
                new FuelTank(tankVolume, criticalLevel, fueltype);
                Console.WriteLine("Fueltank created!");
            }            
        }
    }
}
