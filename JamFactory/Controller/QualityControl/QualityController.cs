using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.QualityControl;
using Common.Interfaces;
using Model.QualityControl;

namespace Controller.QualityControl
{
    public class QualityController
    {
        DataAccessBinary DT = new DataAccessBinary();
        public IProductionProduct product;
        List<IProductionProduct> ProductionList = new List<IProductionProduct>();
        
        /// <summary>
        /// Creates a new product line
        /// </summary>
        /// <param name="name">Product Name</param>
        public void saveNewProductProduction(string name)
        {        
            product.ProductName = name;
        }

        public List<IProductionProduct> loadAllProductionItems()
        {
            return DT.LoadProducts();
        }
    }
}
