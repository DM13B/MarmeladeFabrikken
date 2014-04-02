using Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;



namespace DataAccess
{
    class DataAccessBinary
    {
        private List<IProduct> ProductList;

        public List<IProduct> LoadShopItems()
        {
           
            try
            {
                using (FileStream fs = File.OpenRead("ProductList.jam"))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    ProductList = formatter.Deserialize(fs) as List<IProduct>;
                }
            }
            catch { }
            return ProductList;
        }

        public void SaveShopItems(List<IProduct> items)
        {
            using (FileStream fs = File.Create("ProductList.jam", 2048, FileOptions.None))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, items);
            }
        }
    }
}
