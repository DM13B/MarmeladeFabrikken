using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;

namespace Model
{
    [Serializable]
    public class Batch : IBatch
    {
        public int BatchID { get; set; }
        public List<IQualityControl> QualityControls { get; set; }
        public bool BatchDone { get; set; }

        public DateTime FinishedTime { get; set; }
        public Batch(int BatchId, List<IQualityControl> qualityControls)
        {
            BatchID = BatchId;
            QualityControls = new List<IQualityControl>();
            QualityControls = qualityControls;
            BatchDone = false;
        }

        public override string ToString()
        {
            return "" + BatchID;
        }
    }
}
