using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class PayStation : PetrolStationObject
    {
        // private Members
        private List<MoneyContainer> moneyContainers;
        private int amountToPay;
        private int currentSelectedPumpId;
        private int returnMoney;

        // Konstruktor
        public PayStation() : base()
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
            moneyContainers = moneyContainers.OrderByDescending(x => x.GetWorth()).ToList();

            PetrolStationInstanceController.GetInstance().AddInstance(this);
        }

        /// <summary>
        /// Set 'amountToPay' to the return value of the methode 'GetAmountToPay'.
        /// </summary>
        /// <param name="ppumpId"></param>
        public void SetAmountToPay(int ppumpId)
        {
            amountToPay = PetrolStationInstanceController.GetInstance().GetObjectInstance<PetrolPump>(ppumpId).GetAmountToPay();
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
            if(amountToPay <= 0)
            {
                // Return Money logic
                returnMoney = amountToPay * -1;
                amountToPay = 0;

                PetrolStationInstanceController.GetInstance().GetObjectInstance<PetrolPump>(currentSelectedPumpId).UnlockTaps();
                CreateQuittance();
                ReturnBackMoney();
            }
        }

        /// <summary>
        /// Create a new Quittance of this Fuelling.
        /// </summary>
        private void CreateQuittance()
        {
            // Do something
            
        }

        /// <summary>
        /// Give the return money.
        /// </summary>
        private void ReturnBackMoney()
        {
            while (returnMoney != 0)
            {
                foreach (MoneyContainer item in moneyContainers)
                {
                    if (item.GetWorth() <= returnMoney)
                    {
                        returnMoney -= item.GetWorth();
                        item.DecreaseCount();
                    }
                }
            }

        }

    }
}
