using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;

namespace Model
{
    [Serializable]
    public class Product : IProduct
    {
        private string _ProductName;        
        private List<IQualityControl> _QualityControls;
        private List<IBatch> _Batches;

        public string ProductName { get { return _ProductName; } set { _ProductName = value; } }
        public List<IQualityControl> QualityControls { get { return _QualityControls; } set { _QualityControls = value; } }
        public List<IBatch> Batches { get { return _Batches; } set { _Batches = value; } }        

        public Product(string productName)
        {
            ProductName = productName;
            Batches = new List<IBatch>();
            QualityControls = new List<IQualityControl>();
        }

        public void AddBatch(int batchID)
        {
            

        }

        public void AddQualityControl(string controlName, string controlDescription, string expectedResult)
        {
            
        }

        public List<Batch> ReturnCurrentBatches()
        {
            List<Batch> returnBatches = new List<Batch>();
            foreach (Batch batch in Batches)
            {
                if (batch.BatchDone == false)
                {
                    returnBatches.Add(batch);
                }
            }
            return returnBatches;
        }

        public Batch FindBatch(Batch batch)
        {
            foreach (Batch batch1 in Batches)
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
