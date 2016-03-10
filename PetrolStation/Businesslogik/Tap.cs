using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation.Businesslogic
{
    public class Tap
    {
        // Konstruktor
        public Tap()
        {
            isLocked = false;
        }

        // private members
        private bool isLocked;
        private PetrolTank tank;
        
        // public methods
        public void Lock()
        {
            isLocked = true;
        }

        public void Unlock()
        {
            isLocked = false;
        }

    }
}
