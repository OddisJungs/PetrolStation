using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    public class DataContainer
    {
        // private member
        private string path;

        // public Constructor
        public DataContainer()
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "\\PetrolStations\\Saves\\");
        }

        /// <summary>
        /// Loads all object of the type T
        /// </summary>
        /// <typeparam name="T">Type of all objects to load</typeparam>
        /// <returns>List of object with Type T</returns>
        public List<T> Load<T>()
        {
            List<T> list = new List<T>();
            string filespath = Path.Combine(path ,typeof(T).Name);
            try {
                foreach (string file in Directory.GetFiles(filespath))
                {
                    using (FileStream fileStream = File.Open(Path.Combine(filespath, file), FileMode.Open))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        list.Add((T)binaryFormatter.Deserialize(fileStream));
                    }
                }
            }
            catch { }
            return list;
        }

        /// <summary>
        /// Get all quittances of this day.
        /// </summary>
        /// <returns></returns>
        public List<Quittance> GetQuittanceOfThisDay()
        {
            List<Quittance> listQuittanceOfThisDay = new List<Quittance>();
            string filespath = Path.Combine(path, typeof(Quittance).Name);
            try
            {
                foreach (string file in Directory.GetFiles(filespath))
                {
                    using (FileStream fileStream = File.Open(Path.Combine(filespath, file), FileMode.Open))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        Quittance quittance = (Quittance)binaryFormatter.Deserialize(fileStream);
                        if (quittance.GetDay() == DateTime.Now.Day)
                        {
                            listQuittanceOfThisDay.Add((Quittance)binaryFormatter.Deserialize(fileStream));
                        }
                    }
                }
                return listQuittanceOfThisDay;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get all quittances of the last week.
        /// </summary>
        /// <returns></returns>
        public List<Quittance> GetQuittanceOfLastWeek()
        {
            List<Quittance> listQuittanceOfMonth = new List<Quittance>();
            string filespath = Path.Combine(path, typeof(Quittance).Name);
            try
            {
                foreach (string file in Directory.GetFiles(filespath))
                {
                    using (FileStream fileStream = File.Open(Path.Combine(filespath, file), FileMode.Open))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        Quittance quittance = (Quittance)binaryFormatter.Deserialize(fileStream);
                        if (quittance.GetDay() >= quittance.GetLastWeek())
                        {
                            listQuittanceOfMonth.Add((Quittance)binaryFormatter.Deserialize(fileStream));
                        }
                    }
                }
                return listQuittanceOfMonth;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get all the quittances of the last month.
        /// </summary>
        /// <returns></returns>
        public List<Quittance> GetQuittanceOfLastMonth()
        {
            List<Quittance> listQuittanceOfMonth = new List<Quittance>();
            string filespath = Path.Combine(path, typeof(Quittance).Name);
            try
            {
                foreach (string file in Directory.GetFiles(filespath))
                {
                    using (FileStream fileStream = File.Open(Path.Combine(filespath, file), FileMode.Open))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        Quittance quittance = (Quittance)binaryFormatter.Deserialize(fileStream);
                        if (quittance.GetMonth() == quittance.GetLastMonth())
                        {
                            listQuittanceOfMonth.Add((Quittance)binaryFormatter.Deserialize(fileStream));
                        }                        
                    }
                }
                return listQuittanceOfMonth;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get all the quittances of the last year.
        /// </summary>
        /// <returns></returns>
        public List<Quittance> GetQuittanceOfLastYear()
        {
            List<Quittance> listQuittanceOfLastYear = new List<Quittance>();
            string filespath = Path.Combine(path, typeof(Quittance).Name);
            try
            {
                foreach (string file in Directory.GetFiles(filespath))
                {
                    using (FileStream fileStream = File.Open(Path.Combine(filespath, file), FileMode.Open))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        Quittance quittance = (Quittance)binaryFormatter.Deserialize(fileStream);
                        if (quittance.GetYear() == quittance.GetLastYear())
                        {
                            listQuittanceOfLastYear.Add((Quittance)binaryFormatter.Deserialize(fileStream));
                        }
                    }
                }
                return listQuittanceOfLastYear;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get all earnings of this day.
        /// </summary>
        /// <returns></returns>
        public int EarningsThisDay()
        {
            List<Quittance> quittancesThisDay = GetQuittanceOfThisDay();
            return quittancesThisDay.Sum(x => x.GetAmountToPay());
        }

        /// <summary>
        /// Get all earnings of this/last week.
        /// </summary>
        /// <returns></returns>
        public int EarningsThisWeek()
        {
            List<Quittance> quittancesLastWeek = GetQuittanceOfLastWeek();
            return quittancesLastWeek.Sum(x => x.GetAmountToPay());
        }

        /// <summary>
        /// Get all earnings of last month.
        /// </summary>
        /// <returns></returns>
        public int EarningsLastMonth()
        {
            List<Quittance> quittancesLastMonth = GetQuittanceOfLastMonth();
            return quittancesLastMonth.Sum(x => x.GetAmountToPay());
        }

        /// <summary>
        /// Get all earnings of last year.
        /// </summary>
        /// <returns></returns>
        public int EarningLastYear()
        {
            List<Quittance> quittancesLastYear = GetQuittanceOfLastYear();
            return quittancesLastYear.Sum(x => x.GetAmountToPay());
        }
    }
}
