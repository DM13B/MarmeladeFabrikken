using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Optimization
{
    public class DecisionBase
    {
        // Peter lavede til public for at kunne tilføje i listerne i UnitTest
        // Skal nok ændres, når vi sletter SeedWithData
        public List<RawGoods> rawGoods;
        public List<ReceivedGoods> receivedGoods;
        public List<Recipe> recipes;

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

            receivedGoods.Add(new ReceivedGoods { RawGoods = rawGoods[0], Amount = 300, Price = 10 });
            receivedGoods.Add(new ReceivedGoods { RawGoods = rawGoods[1], Amount = 600, Price = 2 });

            Recipe recipe2 = new Recipe("Hyben/Æble Luksus");
            recipe2.Ingredients.Add(new Ingredient { RawGoods = rawGoods[0], Amount = 0.225 });
            recipe2.Ingredients.Add(new Ingredient { RawGoods = rawGoods[1], Amount = 0.225 });
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
