using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Optimization
{
    public class RawGoods : IRawGoods
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public RawGoods(string name)
        {
            Name = name;
        }
    }
}
