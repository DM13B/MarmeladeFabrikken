using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IProductionQualityCheck
    {
         string ControlName { get; set; }
         string ControlDescription { get; set; }

         string ExpectedResult1 { get; set; }
         string ExpectedResult2 { get; set; }

         bool ExpectedBoolResult { get; set; }
         bool BoolResult { get; set; }

         int ControlType { get; set; }

         //Kontrollør
         string Controller { get; set; }
         
         DateTime ControlStart { get; set; }
         DateTime ControlEnd { get; set; }
         bool ControlSuccess { get; set; }                 


    }
}
