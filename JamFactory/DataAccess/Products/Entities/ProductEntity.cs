using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Products.Entities
{
    class ProductEntity
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
