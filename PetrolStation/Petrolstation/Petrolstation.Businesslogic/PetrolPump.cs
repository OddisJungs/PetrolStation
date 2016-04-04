using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    [Serializable]
    public class PetrolPump : PetrolStationObject
    {
        // private members
        private const int tankSpeed = 500; // How Many ml per second are tanked
        private int amountToPay = 0;
        private int alreadyFuelledVolume = 0;
        private Tap selectedTap;
        private List<Tap> taps = new List<Tap>();

        // Constructor
        public PetrolPump() : base()
        {

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
            taps.Add(new Tap(pfuelTank, id));
            Save();
        }

        /// <summary>
        /// Return the Id's of all objects in the list 'taps'.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetListOfTapsId()
        {
            Dictionary<int, string> tapIds = new Dictionary<int, string>();
            foreach (Tap tap in taps)
            {
                tapIds.Add(tap.GetId(), tap.GetFuelTypeName());
            }
            return tapIds;
        }

        /// <summary>
        /// Start the fuelling process.
        /// </summary>
        /// <param name="ptap"></param>
        /// <returns></returns>
        public void PrepareFuelling(int ptapId)
        {
            foreach(Tap oneTap in taps)
            {
                if (oneTap.GetId() != ptapId)
                {
                    oneTap.Lock();
                }
            }

            selectedTap = taps.FirstOrDefault(x => x.GetId() == ptapId);
            amountToPay = 0;

            Save();
        }

        public int Fuelling()
        {
            amountToPay += (selectedTap.GetPricePerLiter()*(tankSpeed/1000));
            selectedTap.DecreaseFuelLevelOfTank(tankSpeed);
            alreadyFuelledVolume += tankSpeed;
            Save();
            return alreadyFuelledVolume;
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
            Save();
        }

        /// <summary>
        /// Reset the Amount to Pay after paying.
        /// </summary>
        public void ResetAmountToPay()
        {
            amountToPay = 0;
            Save();
        }

        public void SetVolumeToNull()
        {
            alreadyFuelledVolume = 0;
            Save();
        }
    }
}
