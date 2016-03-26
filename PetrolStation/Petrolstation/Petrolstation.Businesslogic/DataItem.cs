using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Petrolstation.Businesslogic
{
    [Serializable]
    public abstract class DataItem
    {
        // private members
        private string savepath;
        private string guid; // id to find the right file in the db
        public DataItem()
        {
            savepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "\\PetrolStations\\Saves\\", GetType().Name);
            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }
        }

        // public methods
        public void Save()
        {
            string savefile = null;
            if(!String.IsNullOrEmpty(guid))
            {
                savefile = Directory.GetFiles(savepath).Where(file => Path.GetFileName(file).StartsWith(guid)).FirstOrDefault();
            }

            if(savefile == null)
            {
                guid = Guid.NewGuid().ToString();
                savefile = Path.Combine(savepath, String.Format("{0}.bin", guid));
            }

            using (FileStream fileStream = File.Open(savefile, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, this);
            }
        }
    }
}
