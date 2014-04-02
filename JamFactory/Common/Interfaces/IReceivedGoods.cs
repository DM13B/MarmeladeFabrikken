using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IReceivedGoods
    {
        IRawGoods RawGoods { get; set; }
        double Amount { get; set; }
        decimal Price { get; set; }
        DateTime Received { get; set; }
        string Supplier { get; set; }
    }
}
