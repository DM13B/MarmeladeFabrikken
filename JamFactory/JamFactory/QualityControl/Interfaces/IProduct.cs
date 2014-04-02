using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IProduct
    {
         string ProductName { get; set; }

         List<IBatch> Batches { get; set; }

         List<IQualityControl> QualityControls { get; set; }

    }
}
