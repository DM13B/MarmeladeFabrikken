using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IProductionBatch
    {
        int BatchID { get; set; }
        List<IProductionQualityCheck> QualityControls { get; set; }
        DateTime FinishedTime { get; set; }
    }
}
