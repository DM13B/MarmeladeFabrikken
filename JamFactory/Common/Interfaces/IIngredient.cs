using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IIngredient
    {
        int Id { get; set; }
        string Amount { get; set; }
    }
}
