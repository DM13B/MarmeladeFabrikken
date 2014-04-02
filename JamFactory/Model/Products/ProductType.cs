using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Model.Products
{
    class ProductType : IProductType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
