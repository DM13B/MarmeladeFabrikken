using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Model.Products
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ContainerId { get; set; }
        public int ProductTypeId { get; set; }
        public int QualityId { get; set; }
        public int RecipeId { get; set; }
    }
}
