using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using Common.Interfaces;



namespace DataAccess.QualityControl
{
    public class DataAccessBinary
    {
        private List<IProductionProduct> ProductList;

        public List<IProductionProduct> LoadProducts()
        {
           
            try
            {
                using (FileStream fs = File.OpenRead("ProductList.jam"))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    ProductList = formatter.Deserialize(fs) as List<IProductionProduct>;
                }
            }
            catch { }
            return ProductList;
        }

        public void SaveProducts(List<IProductionProduct> items)
        {
            using (FileStream fs = File.Create("ProductList.jam", 2048, FileOptions.None))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, items);
            }
        }

        public void SaveNewProduct(IProductionProduct newProduct)
        {
            throw new NotImplementedException();
        }


    }
}
