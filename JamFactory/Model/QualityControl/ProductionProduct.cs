using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Model.QualityControl
{
    [Serializable]
    public class ProductionProduct : IProductionProduct
    {
        private string _ProductName;        
        private List<IProductionQualityCheck> _QualityControls;
        private List<IProductionBatch> _Batches;

        public string ProductName { get { return _ProductName; } set { _ProductName = value; } }
        public List<IProductionQualityCheck> QualityControls { get { return _QualityControls; } set { _QualityControls = value; } }
        public List<IProductionBatch> Batches { get { return _Batches; } set { _Batches = value; } }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="productName"></param>
        public ProductionProduct(string productName)
        {
            ProductName = productName;
            Batches = new List<IProductionBatch>();
            QualityControls = new List<IProductionQualityCheck>();
        }

        /// <summary>
        /// Returns the batches in this Production
        /// </summary>
        /// <returns>List<ProductionBatch></returns>
        public List<ProductionBatch> ReturnCurrentBatches()
        {
            List<ProductionBatch> returnBatches = new List<ProductionBatch>();
            foreach (ProductionBatch batch in Batches)
            {
                if (batch.BatchDone == false)
                {
                    returnBatches.Add(batch);
                }
            }
            return returnBatches;
        }

        /// <summary>
        /// Returns a specific batch in this Production
        /// </summary>
        /// <param name="batch">ProductionBatch</param>
        /// <returns></returns>
        public ProductionBatch FindBatch(ProductionBatch batch)
        {
            foreach (ProductionBatch batch1 in Batches)
            {
                if (batch == batch1)
                {
                    return batch1;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return ProductName;
        }
        
    }
}
