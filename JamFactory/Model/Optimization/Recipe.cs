using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Optimization
{
    public class Recipe
    {
        public List<Ingredient> Ingredients { get; private set; }
        public string Name { get; set; }

        public Recipe(string name)
        {
            Ingredients = new List<Ingredient>();
            Name = name;
        }
    }
}
