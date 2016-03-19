using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class PayStation
    {
        // private Members
        private List<MoneyContainer> moneyContainers;
        private int amountToPay;
        private int currentSelectedPumpId;

        // Konstruktor
        public PayStation()
        {
            moneyContainers = new List<MoneyContainer>();
            moneyContainers.Add(new MoneyContainer(5, 500, 15.5, 88.5));
            moneyContainers.Add(new MoneyContainer(10, 500, 15.5, 88.5));
            moneyContainers.Add(new MoneyContainer(20, 500, 15.5, 88.5));
            moneyContainers.Add(new MoneyContainer(50, 500, 15.5, 88.5));
            moneyContainers.Add(new MoneyContainer(100, 500, 15.5, 88.5));
            moneyContainers.Add(new MoneyContainer(200, 500, 15.5, 88.5));
            moneyContainers.Add(new MoneyContainer(500, 500, 15.5, 88.5));
            moneyContainers.Add(new MoneyContainer(1000, 500, 15.5, 88.5));
            moneyContainers.Add(new MoneyContainer(2000, 500, 15.5, 88.5));
            moneyContainers.Add(new MoneyContainer(5000, 500, 15.5, 88.5));
            moneyContainers.Add(new MoneyContainer(10000, 500, 15.5, 88.5));
            moneyContainers.Add(new MoneyContainer(20000, 500, 15.5, 88.5));
            moneyContainers.Add(new MoneyContainer(100000, 500, 15.5, 88.5));
        }

        public void SetAmountToPay(int ppumpId)
        {
            amountToPay = PetrolPumpController.GetInstance().GetAmountToPay(ppumpId);
        }

        /// <summary>
        /// Give One Money Unit
        /// </summary>
        /// <param name="pworth">Worth of the Money</param>
        public void PayMoney(int pworth)
        {
            MoneyContainer moneyContainer = moneyContainers.Where(x => x.GetWorth() == pworth).FirstOrDefault();
            if(moneyContainer != null)
            {
                moneyContainer.IncreaseCount();
                amountToPay -= pworth;
            }

            // If lower than 0 the he payed enough
            if(amountToPay < 0)
            {
                // Return Money logic
                CreateQuittance();
            }
        }

        private void CreateQuittance()
        {
            // Do something
        }
    }
}
