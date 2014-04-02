using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using DataAccess.QualityControl.Entity;


namespace DataAccess.QualityControl
{
    class DataAccessBinary
    {
        private List<ProductEntity> ProductList;

        public List<ProductEntity> LoadShopItems()
        {
           
            try
            {
                using (FileStream fs = File.OpenRead("ProductList.jam"))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    ProductList = formatter.Deserialize(fs) as List<ProductEntity>;
                }
            }
            catch { }
            return ProductList;
        }

        public void SaveShopItems(List<ProductEntity> items)
        {
            using (FileStream fs = File.Create("ProductList.jam", 2048, FileOptions.None))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, items);
            }
        }
    }
}
