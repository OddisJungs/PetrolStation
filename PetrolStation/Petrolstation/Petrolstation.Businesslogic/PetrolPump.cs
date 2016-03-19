﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class PetrolPump
    {
        // private members
        private const int tankSpeed = 50; // How Many ml per second are tanked
        private int petrolPumpId;
        private int amountToPay;
        private List<Tap> taps;

        // Constructor
        public PetrolPump()
        {
            // Add himself to the PetrolPumpController
            petrolPumpId = 0;
            PetrolPumpController.GetInstance().AddPump(this);
            taps = new List<Tap>();
        }

        // public methods

        public void AddTap(Tap ptap)
        {
            taps.Add(ptap);
        }
       
        public void SetId(int ppumpId)
        {
            petrolPumpId = ppumpId;
        }

        public int GetId()
        {
            return petrolPumpId;
        }

        public void Fuelling(Tap ptap)
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
        }
    }
}