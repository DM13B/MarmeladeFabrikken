using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IContainer
    {
        int Id { get; set; }
        int Quantity { get; set; }
    }
}
