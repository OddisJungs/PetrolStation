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
        private Fueltype fuelType;

        // public Constructor
        public Quittance(int pamountToPay, int plitersTanked, Fueltype pfuelType)
        {
            createdAt = DateTime.Now;
            amountToPay = pamountToPay;
            litersTanked = plitersTanked;
            fuelType = pfuelType;
            // Path
            Save();
        }

        /// <summary>
        /// Load the quittances of the setted time duration.
        /// </summary>
        /// <returns></returns>
        public List<Quittance> Load()
        {
            List<Quittance> list = new List<Quittance>();
            string filespath = Path.Combine(GetSavePath(), typeof(Quittance).Name);
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

        /// <summary>
        /// Get last week.
        /// </summary>
        /// <returns></returns>
        public int GetLastWeek()
        {
            int lastWeek = DateTime.Now.Day - 7;
            return lastWeek;
        }

        /// <summary>
        /// Get last month.
        /// </summary>
        /// <returns></returns>
        public int GetLastMonth()
        {
            int lastMonth = DateTime.Now.Month - 1;
            return lastMonth;
        }

        /// <summary>
        /// Get last year.
        /// </summary>
        /// <returns></returns>
        public int GetLastYear()
        {
            int lastYear = DateTime.Now.Year - 1;
            return lastYear;
        }

        /// <summary>
        /// Get the value of 'createdAt.Day'.
        /// </summary>
        /// <returns></returns>
        public int GetDay()
        {
            return createdAt.Day;
        }

        /// <summary>
        /// Get the value of 'createdAt.Day'.
        /// </summary>
        /// <returns></returns>
        public int GetMonth()
        {
            return createdAt.Month;
        }

        /// <summary>
        /// Get the value of 'createdAt.Day'.
        /// </summary>
        /// <returns></returns>
        public int GetYear()
        {
            return createdAt.Year;
        }

        /// <summary>
        /// Get the value of 'amountType'.
        /// </summary>
        /// <returns></returns>
        public int GetAmountToPay()
        {
            return amountToPay;
        }

        /// <summary>
        /// Get the value of 'litersTanked'.
        /// </summary>
        /// <returns></returns>
        public int GetLitersTanked()
        {
            return litersTanked;
        }

        /// <summary>
        /// Get the value of 'fuelType'.
        /// </summary>
        /// <returns></returns>
        public Fueltype GetFuelType()
        {
            return fuelType;
        }
    }
}
