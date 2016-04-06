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
        /// Returns the earnings and the tanked milliliters of the timespan
        /// </summary>
        /// <param name="pfueltype"></param>
        /// <param name="pminDate"></param>
        /// <returns>Tuple(Eraned Money, Milliliterstanked)</returns>
        public Tuple<double, int> GetEarningsOfSinceDate(Fueltype pfueltype, DateTime pminDate)
        {
            return GetEarningsOfTimespan(pfueltype, pminDate, DateTime.Now);
        }

        /// <summary>
        /// Returns the earnings and the tanked milliliters of the timespan
        /// </summary>
        /// <param name="pfueltype"></param>
        /// <param name="pminDate"></param>
        /// <param name="pmaxDate"></param>
        /// <returns>Tuple(Eraned Money, Milliliterstanked)</returns>
        public Tuple<double, int> GetEarningsOfTimespan(Fueltype pfueltype, DateTime pminDate, DateTime pmaxDate)
        {
            string filespath = Path.Combine(path, typeof(Quittance).Name);
            int milliliterstanked = 0;
            double earanedMoney = 0;
            try
            {
                foreach (string file in Directory.GetFiles(filespath))
                {
                    using (FileStream fileStream = File.Open(Path.Combine(filespath, file), FileMode.Open))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        Quittance quittance = (Quittance) binaryFormatter.Deserialize(fileStream);
                        if (quittance.GetCreatedAt() > pminDate &&
                            quittance.GetFuelType().GetName() == pfueltype.GetName())
                        {
                            milliliterstanked += quittance.GetMililitersTanked();
                            earanedMoney += quittance.GetAmountToPay();
                        }
                    }
                }
            }
            catch
            {

            }
            return new Tuple<double, int>(earanedMoney, milliliterstanked) ;
        }
    }
}
