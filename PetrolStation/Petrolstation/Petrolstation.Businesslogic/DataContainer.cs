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
            foreach (string file in Directory.GetFiles(filespath))
            {
                using (FileStream fileStream = File.Open(Path.Combine(filespath, file), FileMode.Open))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    list.Add((T)binaryFormatter.Deserialize(fileStream));
                }
            }

            return list;
        }


    }
}
