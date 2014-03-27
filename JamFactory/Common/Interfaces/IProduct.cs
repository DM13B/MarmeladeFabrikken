using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int ContainerId { get; set; }
        int ProductTypeId { get; set; }
        int QualityId { get; set; }
        int RecipeId { get; set; }
    }
}
