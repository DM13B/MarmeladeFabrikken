using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Optimization
{
    public class ReceivedGoods : IReceivedGoods
    {
        public IRawGoods RawGoods { get; set; }
        public double Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime Received { get; set; }
        public string Supplier { get; set; }
        public int Id { get; set; }

        public ReceivedGoods()
        {
        }

        public ReceivedGoods(RawGoods rawGoods, double amount, decimal price, DateTime received, string supplier)
        {
            RawGoods = rawGoods;
            Amount = amount;
            Price = price;
            Received = received;
            Supplier = supplier;
        }

    }
}
