using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Products.Entities
{
    public class ReceivedGoodsEntity
    {
        public RawGoodsEntity RawGoods { get; set; }
        public double Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime Received { get; set; }
        public string Supplier { get; set; }
        public int Id { get; set; }
    }
}
