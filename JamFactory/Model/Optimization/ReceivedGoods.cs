using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Optimization
{
    public class ReceivedGoods
    {
        public RawGoods RawGoods { get; set; }
        public double Amount { get; set; }
        public decimal Price { get; set; }

        public ReceivedGoods()
        {
        }

        public ReceivedGoods(RawGoods rawGoods, double amount, decimal price)
        {
            RawGoods = rawGoods;
            Amount = amount;
            Price = price;
        }
    }
}
