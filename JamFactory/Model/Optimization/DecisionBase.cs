using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Optimization
{
    public class DecisionBase
    {
        List<RawGoods> rawGoods;
        List<ReceivedGoods> receivedGoods;
        List<Recipe> recipes;

        public DecisionBase()
        {
            rawGoods = new List<RawGoods>();
            receivedGoods = new List<ReceivedGoods>();
            recipes = new List<Recipe>();
        }

        public void SeedWithData()
        {
            rawGoods.Add(new RawGoods("Hyben"));
            rawGoods.Add(new RawGoods("Æble"));
            rawGoods.Add(new RawGoods("Solbær"));
            rawGoods.Add(new RawGoods("Sukker"));

            receivedGoods.Add(new ReceivedGoods { RawGoods = rawGoods[0], Amount = 300, Price = 10 });
            receivedGoods.Add(new ReceivedGoods { RawGoods = rawGoods[1], Amount = 600, Price = 2 });
            receivedGoods.Add(new ReceivedGoods { RawGoods = rawGoods[2], Amount = 100, Price = 8 });
            receivedGoods.Add(new ReceivedGoods { RawGoods = rawGoods[3], Amount = 100000, Price = 7 });

            Recipe recipe1 = new Recipe("Solbær Luksus");
            recipe1.Ingredients.Add(new Ingredient { RawGoods = rawGoods[2], Amount = 0.45 });
            recipe1.Ingredients.Add(new Ingredient { RawGoods = rawGoods[3], Amount = 0.45 });
            recipes.Add(recipe1);

            Recipe recipe2 = new Recipe("Hyben/Æble Luksus");
            recipe2.Ingredients.Add(new Ingredient { RawGoods = rawGoods[0], Amount = 0.225 });
            recipe2.Ingredients.Add(new Ingredient { RawGoods = rawGoods[1], Amount = 0.225 });
            recipe2.Ingredients.Add(new Ingredient { RawGoods = rawGoods[3], Amount = 0.45 });
            recipes.Add(recipe2);
        }

        public string SuggestProduction(string algorithm)
        {
            string suggestion = "";

            SuggestionAlgorithm suggestionAlgorithm = new SuggestionAlgorithm(receivedGoods, recipes);

            List<Tuple<Recipe, decimal, double>> possibleProductions = suggestionAlgorithm.CalculateProduction(algorithm);

            foreach (Tuple<Recipe, decimal, double> possibleProduction in possibleProductions)
            {
                suggestion += String.Format("{0}: {1} kg @ {2} kr/kg \n", possibleProduction.Item1.Name,
                    possibleProduction.Item3.ToString("N0"), possibleProduction.Item2.ToString("N2"));

            }

            return suggestion;
        }
    }
}
