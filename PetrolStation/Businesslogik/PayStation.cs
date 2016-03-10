using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Businesslogic
{
    /// <summary>
    /// Hauptklasse Paystation
    /// </summary>
    public class PayStation
    {
        //Konstruktor
        public PayStation(int pstationNumber )
        {
            coins = new List<Coin>();
            Coin coin = new Coin(0, 10, 100, 90, 10); // 10 Rp.
            coins.Add(coin);
            coin = new Coin(0,10, 100, 90, 20);  // 20 Rp.
            coins.Add(coin);
            coin = new Coin(0,10, 100, 80, 50); // 50Rp.
            coins.Add(coin);
            coin = new Coin(0,10, 100, 80, 100); // 1Fr.
            coins.Add(coin);
            coin = new Coin(0,10, 100, 70, 200); // 2Fr.
            coins.Add(coin);
            coin = new Coin(0, 10, 100, 40, 500); // 5 Fr,
            coins.Add(coin);
            coin = new Coin(0, 10, 50, 80, 1000); // 10 Fr.
            coins.Add(coin);
            coin = new Coin(0, 10, 50, 80, 2000); // 20 Fr.
            coins.Add(coin);
            coin = new Coin(0, 10, 50, 80, 5000); // 50 Fr
            coins.Add(coin);
            coin = new Coin(0, 10, 50, 80, 10000); // 100 Fr.
            coins.Add(coin);
            coins = coins.OrderBy(x => x.GetWorth()).ToList();
            stationNumber = pstationNumber;
        }

        //Private
        private List<Coin> coins;
        private const int maxTotalCoins = 500;
        private int stationNumber;


        //Puplic
        public void InsertCoin(int pcoin)
        {
            Coin coin = coins.FirstOrDefault(x => x.GetWorth() == pcoin);
            if(coin != null)
            {
                coin.InputCoin();
            }
            else
            {
                Console.WriteLine("Invalid Coin");
            }
        }

        public int GetValueInput()
        {
            int valueInput = 0;
            foreach (Coin coin in coins)
	        {
		        valueInput += coin.GetQuanityOfUserInput() * coin.GetWorth();
	        }
            return valueInput;
        }

        public void AcceptValueInput()
        {
            foreach(Coin coin in coins)
            {
                coin.AddQuantityOfUserInputToQuantity();
            }
        }

        public void NotAcceptValueInput()
        {
            foreach(Coin coin in coins)
            {
                coin.RemoveQuantityOfUserInputToQuantity();
            }
        }

        public int GetValueTotal()
        {
            int valueTotal = 0;
            foreach (Coin coin in coins)
	        {
		        valueTotal += coin.GetQuantity() * coin.GetWorth();
	        }
            return valueTotal;
        }

        public int GetPercentCoin(int pcoin)
        {
            Coin coin = coins.FirstOrDefault(x => x.GetWorth() == pcoin);
            if(coin != null)
            {
                return (int)coin.GetStock();
            }
            else
	        {
                return 0;
	        }
        }

        public List<Tuple<int,int>> GetQuantityCoins()
        {
            List<Tuple<int,int>> quantityOfAllCoins = new List<Tuple<int,int>>();
            Tuple<int,int> quantityOfCoin;
            foreach (Coin coin in coins)
	        {
		        quantityOfCoin = new Tuple<int,int>(coin.GetWorth() ,coin.GetQuantity());
                quantityOfAllCoins.Add(quantityOfCoin);
	        }
            return quantityOfAllCoins;
        }

        public List<ChangeCoin> GetChange(int pchange)
        {
            List<ChangeCoin> changeCoins = new List<ChangeCoin>();
            ChangeCoin changeCoin = new ChangeCoin();
            foreach (Coin coin in coins)
	        {
                changeCoin.Worth = coin.GetWorth();
		        while (pchange >= changeCoin.Worth && coin.GetStock() > coin.GetMinPercent())
	            {
	                coin.IncrementQuantityChange();
	            }
                changeCoin.Amount = coin.GiveQuantityChange();

                changeCoins.Add(changeCoin);
	        }
            return changeCoins;
        }

        public void AlertCoinMinimum(int pcoin)
        {
            Coin coin = coins.FirstOrDefault(x => x.GetWorth() == pcoin);
            if (coin.GetStock() < coin.GetMinPercent())
	        {
		        Console.Write(String.Format("Not enough coins of worth: {0}", coin.GetWorth()));
	        }
        }

        public void AlertCoinMaximum(int pcoin)
        {
            Coin coin = coins.FirstOrDefault(x => x.GetWorth() == pcoin);
            if (coin.GetStock() > coin.GetMaxPercent())
            {
                Console.Write(String.Format("To many coins of worth: {0}", coin.GetWorth()));
            }
        }

        public void AlertValueTotalMaximum(int pvaluetotal)
        {
            int totalCoins = 0;
            foreach(Coin coin in coins)
            {
                totalCoins += coin.GetQuantity();
            }
            if (totalCoins > maxTotalCoins)
            {
                Console.Write(String.Format("To many coins: {0}", totalCoins));
            }
        }

        public int GetStationNumber()
        {
            return stationNumber;
        }
    }

    public struct ChangeCoin
	{
		public int Worth;
        public int Amount;
	}
}