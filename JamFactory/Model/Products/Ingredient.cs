﻿using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Products
{
    public class Ingredient : IIngredient
    {
        public string Amount { get; set; }
    }
}