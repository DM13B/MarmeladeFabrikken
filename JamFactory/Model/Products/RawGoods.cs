﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Model.Products
{
    class RawGoods : IRawGoods
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
