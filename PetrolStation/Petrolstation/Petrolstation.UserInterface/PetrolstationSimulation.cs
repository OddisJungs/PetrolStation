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
            Console.Clear();
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
                ChooseTapForFuelling(pumpId);
            }
        }

        static internal void ChooseTapForFuelling(int ppumpId)
        {
            Console.WriteLine("Current Selected PumpId: " + ppumpId);
            Console.Write("Select the tap with his number for the fuelling\nThe Taps: {");
            PetrolPump selectedPetrolpump = PetrolStationObjectController.GetInstance().GetObjectInstance<PetrolPump>(ppumpId);
            foreach (KeyValuePair<int, string> tap in selectedPetrolpump.GetListOfTapsId())
            {

                Console.Write(String.Format("{0} : {1}, ", tap.Key, tap.Value));
            }

            Console.Write(" }\n");
            string input = Console.ReadLine();
            int tapId;
            bool parsingsucceded = Int32.TryParse(input, out tapId);
            if (parsingsucceded)
            {
                DoTheFuelling(selectedPetrolpump, tapId);
            }
            
        }

        static internal void DoTheFuelling(PetrolPump ppetrolPump, int ptapId)
        {
            ppetrolPump.PrepareFuelling(ptapId);
            char inputKey;
            Console.WriteLine("Do the fuelling with the key 'f' and exit the fuelling process with 'q'.");
            do
            {
                ConsoleKeyInfo input = Console.ReadKey();
                inputKey = input.KeyChar;
                if (inputKey == 'f')
                {
                    int alreadyFuelled = ppetrolPump.Fuelling();
                    Console.WriteLine("Already Fuelled in ml : {0}", alreadyFuelled);
                }
            } while (inputKey != 'q');
            Console.WriteLine("Fuelling finished");
            PayTheFuelling(ppetrolPump.GetId());
        }

        static internal void PayTheFuelling(int ppumpId)
        {
            Console.WriteLine("Time to Pay, please select a Paystation");
            Console.Write("{");
            foreach (int id in PetrolStationObjectController.GetInstance().GetInstanceIds<PayStation>())
            {
                Console.Write(String.Format("{0}, ", id));
            }
            Console.Write("}\n");

            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                int intInput = Int32.Parse(input);
                PayStation payStation = PetrolStationObjectController.GetInstance().GetObjectInstance<PayStation>(intInput);
                if (payStation != null)
                {
                    payStation.SetAmountToPay(ppumpId);
                    while (payStation.GetAmountToPay() >= 0)
                    {
                        Console.WriteLine(String.Format("Please Pay a bit money, Amount to pay {0} Rp.", payStation.GetAmountToPay()));
                        Console.WriteLine("Possible paysizes, 5, 10, 20, 50, 100, 200, 500, 10000, 20000, 50000, 100000");
                        string coinInput = Console.ReadLine();
                        if (!string.IsNullOrEmpty(coinInput))
                        {
                            int intCoinInput = Int32.Parse(coinInput);
                            payStation.PayMoney(intCoinInput);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    }

                    if (payStation.GetAmountToPay() < 0)
                    {
                        while (payStation.GetAmountToPay() < 0)
                        {
                            Console.WriteLine("You get back: {0}", payStation.ReturnBackMoney());
                            Console.WriteLine("Still to get back: {0}", payStation.GetAmountToPay());
                        }
                    }
                    Console.WriteLine("Thanks for your visit. Goodbye");
                    PetrolPump selectedPump = PetrolStationObjectController.GetInstance().GetObjectInstance<PetrolPump>(ppumpId);
                    selectedPump.SetVolumeToNull();
                }
                else
                {
                    Console.WriteLine("Invalid input, Jump back to main menu");
                }
            }
            else
            {
                Console.WriteLine("Invalid input, Jump back to main menu");
            }

        }

    }
}
