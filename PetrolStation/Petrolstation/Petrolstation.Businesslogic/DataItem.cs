using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    [Serializable]
    public abstract class DataItem
    {
        // private members
        private string path;

        public DataItem(string typename)
        {

        }

        // public methods
        public void Save() { }
    }
}
