﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IQualityControl
    {
         string ControlName { get; set; }
         string ControlDescription { get; set; }
         string ExpectedResult { get; set; }
         List<ITest> Tests { get; set; }
        
        //Kontrollør
        string Controller { get; set; }
         
         DateTime ControlStart { get; set; }
         DateTime ControlEnd { get; set; }
         bool ControlSuccess { get; set; }                 
    }
}
