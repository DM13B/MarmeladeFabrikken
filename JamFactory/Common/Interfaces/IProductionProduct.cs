using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IProductionProduct
    {
         string ProductName { get; set; }

         List<IProductionBatch> Batches { get; set; }

         List<IProductionQualityCheck> QualityControls { get; set; }

      
    }
}
