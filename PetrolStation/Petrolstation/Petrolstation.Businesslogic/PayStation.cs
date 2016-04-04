using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    [Serializable]
    public class PayStation : PetrolStationObject
    {
        // private Members
        private List<MoneyContainer> moneyContainers;
        private double amountToPay; // in Rp
        private int currentSelectedPumpId;
        private double returnMoney;
        private double fuelCost;

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
            currentSelectedPumpId = 0;
            Save();
        }

        /// <summary>
        /// Set 'amountToPay' to the return value of the methode 'GetAmountToPay'.
        /// </summary>
        /// <param name="ppumpId"></param>
        public void SetAmountToPay(int ppumpId)
        {
            amountToPay = PetrolStationObjectController.GetInstance().GetObjectInstance<PetrolPump>(ppumpId).GetAmountToPay();
            SetFuelCosts();
            Save();
        }

        /// <summary>
        /// Get the value of 'amountToPay'.
        /// </summary>
        /// <returns></returns>
        public double GetAmountToPay()
        {
            return amountToPay;
        }

        /// <summary>
        /// Set the value of 'fuelCost' to the value of 'amountToPay'.
        /// </summary>
        private void SetFuelCosts()
        {
            fuelCost = amountToPay;
        }

        /// <summary>
        /// Give One Money Unit
        /// </summary>
        /// <param name="pworth">Worth of the Money</param>
        public void PayMoney(int pworth)
        {
            MoneyContainer moneyContainer = moneyContainers.FirstOrDefault(x => x.GetWorth() == pworth);
            if (moneyContainer != null)
            {
                moneyContainer.IncreaseCount();
                amountToPay -= pworth;
            }

            // If lower than 0 the he payed enough
            if (amountToPay <= 0)
            {
                // Return Money logic
                returnMoney = amountToPay * -1;
                amountToPay = 0;

                PetrolStationObjectController.GetInstance().GetObjectInstance<PetrolPump>(currentSelectedPumpId).UnlockTaps();
            }
            Save();
        }

        /// <summary>
        /// Create a new Quittance of this Fuelling.
        /// </summary>
        private void CreateQuittance()
        {
            PetrolPump currentPetrolPump = PetrolStationObjectController.GetInstance().GetObjectInstance<PetrolPump>(currentSelectedPumpId);
            Quittance Quittance = new Quittance(fuelCost, currentPetrolPump.GetAlreadyFuelledVolume(), currentPetrolPump.GetSelectedTap().GetFueltype());
        }

        /// <summary>
        /// Give the return money.
        /// </summary>
        public double ReturnBackMoney()
        {

            foreach (MoneyContainer item in moneyContainers)
            {
                if (item.GetWorth() <= returnMoney)
                {
                    returnMoney -= item.GetWorth();
                    item.DecreaseCount();
                }
            }
            Save();
            return returnMoney;
           
        }

    }
}
