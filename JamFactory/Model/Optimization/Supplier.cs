using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Optimization
{
    public class Supplier
    {
        public string Name { get; set; }
        public ReceivedGoods ReceivedGoods { get; set; }

        public Supplier(string name, ReceivedGoods receivedGoods)
        {
            Name = name;
            ReceivedGoods = receivedGoods;
        }
    }
}
