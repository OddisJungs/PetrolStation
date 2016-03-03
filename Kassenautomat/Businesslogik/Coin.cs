using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Businesslogic
{
    public class Coin
    {
        //Konsrtruktor
        public Coin(int pquantity, int pminPercent, int pmaxQuantity, int pmaxPercent, int pworth)
        {
            quantity = pquantity;
            minPercent = pminPercent;
            maxQuantity = pmaxQuantity;
            maxPercent = pmaxPercent; 
            worth = pworth;
            quantityOfUserInput = 0;
            quantityChange = 0;
        }

        //Private Attributes
        private int quantity;
        private int minPercent;
        private int maxQuantity;
        private int maxPercent;
        private int worth;
        private int quantityOfUserInput;
        private int quantityChange;

        //Public
        public float GetStock()
        {
            return ((float)quantity / maxQuantity) * 100;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void AddQuantityOfUserInputToQuantity()
        {
            quantity += quantityOfUserInput;
            quantityOfUserInput = 0;
        }

        public void RemoveQuantityOfUserInputToQuantity()
        {
            quantity += quantityOfUserInput;
            quantityOfUserInput = 0;
        }

        public int GetQuanityOfUserInput()
        {
            return quantityOfUserInput;
        }

        public void InputCoin()
        {
            quantityOfUserInput++;
        }

        public int GetWorth()
        {
            return worth;
        }

        public int GetMinPercent()
        {
            return minPercent;
        }

        public int GetMaxPercent()
        {
            return maxPercent;
        }

        public void IncrementQuantityChange()
        {
            quantityChange++;
        }

        public int GiveQuantityChange()
        {

            int value = quantityChange;
            quantityChange = 0;
            return value;
        }


    }
}
