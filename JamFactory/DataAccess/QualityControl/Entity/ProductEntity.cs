using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.QualityControl.Entity
{
    public class ProductionProductEntity 
    {
         string ProductName { get; set; }

         List<BatchEntity> Batches { get; set; }

         List<QualityControlEntity> QualityControls { get; set; }

    }
}
