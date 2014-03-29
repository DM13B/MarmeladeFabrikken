using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Model.Products
{
    public class Container : IContainer
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
