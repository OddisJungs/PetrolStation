using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    [Serializable]
    public class PetrolPump : DataItem
    {
        // private members
        private const int tankSpeed = 50; // How Many ml per second are tanked
        private int petrolPumpId;
        private int amountToPay;
        private List<Tap> taps;

        // Constructor
        public PetrolPump() : base()
        {
            // Add himself to the PetrolPumpController
            petrolPumpId = 0;
            PetrolPumpController.GetInstance().AddPump(this);
            taps = new List<Tap>();
            Save();
        }

        // public methods
        public void AddTap(Tap ptap)
        {
            taps.Add(ptap);
        }

        // Set a the id for the actual object.
        // Add a new tap to the petrolpump.
        public void AddTap(FuelTank pfuelTank)
        {
            int id = taps.Count() + 1;
            taps.Add(new Tap(this.Fuelling, pfuelTank, id));
        }
       
        /// <summary>
        /// Set the value of 'petrolPumpId' to the parameter value.
        /// </summary>
        /// <param name="ppumpId"></param>
        public void SetId(int ppumpId)
        {
            petrolPumpId = ppumpId;
        }

        /// <summary>
        /// Get the value of 'petrolPumpId'.
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            return petrolPumpId;
        }

        /// <summary>
        /// Return the Id's of all objects in the list 'taps'.
        /// </summary>
        /// <returns></returns>
        public List<int> GetListOfTapsId()
        {
            List<int> tapIds = new List<int>();
            foreach (Tap tap in taps)
            {
                tapIds.Add(tap.GetId());
            }
            return tapIds;
        }

        /// <summary>
        /// Start the fuelling process.
        /// </summary>
        /// <param name="ptap"></param>
        /// <returns></returns>
        public String Fuelling(Tap ptap)
        {
            foreach(Tap oneTap in taps)
            {
                if (oneTap != ptap)
                {
                    oneTap.Lock();
                }
            }

            amountToPay = ptap.GetPricePerLiter();
            // Do fuelling 
            for (int i = 0; i < 15; i++)
            {
                amountToPay += (ptap.GetPricePerLiter() * (tankSpeed/1000));
                ptap.DecreaseFuelLevelOfTank(tankSpeed);
                System.Threading.Thread.Sleep(1000);
            }

            return "";
        }

        /// <summary>
        /// Get the value of 'amountToPay'.
        /// </summary>
        /// <returns></returns>
        public int GetAmountToPay()
        {
            return amountToPay;
        }

        /// <summary>
        /// Unlock all tap objects in the list 'taps'.
        /// </summary>
        public void UnlockTaps()
        {
            foreach (Tap tap in taps)
            {
                tap.Unlock();
            }
        }

        /// <summary>
        /// Reset the Amount to Pay after paying.
        /// </summary>
        public void ResetAmountToPay()
        {
            amountToPay = 0;
        }
    }
}
