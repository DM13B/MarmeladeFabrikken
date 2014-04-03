using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Products.Entities
{
    public class RawGoodsEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RawGoodsEntity(string name)
        {
            Name = name;
        }
    }
}
