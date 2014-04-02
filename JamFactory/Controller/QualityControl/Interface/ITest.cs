using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface ITest 
    {
         string TestName { get; set; }
         string Result { get; set; }
         DateTime TestTime { get; set; }
    }
}
