using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class Quittance : DataItem
    {
        // private members
        private DateTime createdAt;
        private int amountToPay;
        private int litersTanked;

        // public Constructor
        public Quittance(int pamountToPay, int plitersTanked)
        {
            createdAt = DateTime.Now;
            amountToPay = pamountToPay;
            litersTanked = plitersTanked;
            // Path
            Save();
        }

        public List<Quittance> Load(DateTime pdate)
        {
            List<Quittance> list = new List<Quittance>();
            string filespath = Path.Combine(path, typeof(Quittance).Name);
            try
            {
                foreach (string file in Directory.GetFiles(filespath))
                {
                    using (FileStream fileStream = File.Open(Path.Combine(filespath, file), FileMode.Open))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        list.Add((Quittance)binaryFormatter.Deserialize(fileStream));
                    }
                }
            }
            catch { }
            return list;
        }

        // public methods


    }
}
