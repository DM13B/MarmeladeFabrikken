using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Model.QualityControl
{
    [Serializable]
    public class ProductionBatch : IProductionBatch
    {
        public int BatchID { get; set; }
        public List<IProductionQualityCheck> QualityControls { get; set; }
        public bool BatchDone { get; set; }

        public DateTime FinishedTime { get; set; }

        public ProductionBatch(int BatchId, List<IProductionQualityCheck> qualityControls)
        {
            BatchID = BatchId;
            QualityControls = new List<IProductionQualityCheck>();
            QualityControls = qualityControls;
            BatchDone = false;
        }

        public override string ToString()
        {
            return "" + BatchID;
        }
    }
}
