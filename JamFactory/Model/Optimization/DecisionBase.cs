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
            recipe1.Ingredients.Add(new Ingredient {RawGoods = rawGoods[2], Amount = 0.45});
            recipe1.Ingredients.Add(new Ingredient {RawGoods = rawGoods[3], Amount = 0.45});
            recipes.Add(recipe1);

            Recipe recipe2 = new Recipe("Hyben/Æble Luksus");
            recipe2.Ingredients.Add(new Ingredient {RawGoods = rawGoods[0], Amount = 0.225});
            recipe2.Ingredients.Add(new Ingredient {RawGoods = rawGoods[1], Amount = 0.225});
            recipe2.Ingredients.Add(new Ingredient {RawGoods = rawGoods[3], Amount = 0.45});
            recipes.Add(recipe2);
        }

        public string SuggestProduction()
        {
            // UI calls Controller with algorithm, controller calls DecisionBase with algorithm, 
            // DecisionBase instantiates SuggestionAlgorithm with recipes and receivedGoods, call
            // suggest method with algorithm and asks for recipes, ordered by price, and amount.
            // SuggestionAlgorithm returns list with Tuple<Recipe, decimal, double>, being recipe, price and amount
            string suggestion = "";
            List<Tuple<Recipe, decimal>> cheapestRecipes = orderRecipesByPrice();

            suggestion += "Opskrifter sorteret efter pris:\n";

            foreach (Tuple<Recipe, decimal> recipePrice in cheapestRecipes)
            {
                suggestion += recipePrice.Item1.Name + ": " + recipePrice.Item2.ToString("N2") + "\n";
            }

            // to handle multiple deliveries for one raw material: need productions, 
            // of which there can be many candidate productions per recipe

            // calculate the amount to produce of each recipe 

            // or instead, calculate amount of each raw material in every production
            // then use that to calculate how many productions can be made

            suggestion += "-----------------\n";
            suggestion += "Mængde der kan produceres:\n";
            foreach (Recipe recipe in recipes)
            {
                double possibleAmount = calculateAmountThatCanBeProduced(recipe, receivedGoods);
                Console.WriteLine(recipe.Name + ": " + possibleAmount);
                suggestion += recipe.Name + ": " + possibleAmount.ToString("N2") + "\n";
            }

            return suggestion;
        }

        private double calculateAmountThatCanBeProduced(Recipe recipe, List<ReceivedGoods> deliveries)
        {
            double amountOfJamThatCanBeMade = 0;

            List<ReceivedGoods> matchingDeliveries = new List<ReceivedGoods>();
            List<Tuple<Ingredient, double>> ingredientAmounts = new List<Tuple<Ingredient, double>>();

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                matchingDeliveries.Add(getDeliveriesForRawMaterial(ingredient.RawGoods)[0]);
                double amountOfRawMaterialThatCanBeUsedToMakeJam = ingredient.Amount * getDeliveriesForRawMaterial(ingredient.RawGoods)[0].Amount;
                ingredientAmounts.Add(new Tuple<Ingredient, double>(ingredient, amountOfRawMaterialThatCanBeUsedToMakeJam));
            }
            
            double amountOfLimitingIngredientToUse = ingredientAmounts[0].Item2;
            Ingredient limitingIngredient = ingredientAmounts[0].Item1;

            foreach (var ingredientAmount in ingredientAmounts)
            {
                if (ingredientAmount.Item2 < amountOfLimitingIngredientToUse)
                {
                    amountOfLimitingIngredientToUse = ingredientAmount.Item2;
                    limitingIngredient = ingredientAmount.Item1;
                }
            }
            
            // I got the limitingIngredient, use that to calc it first

            // calculate amount of jam that can be made

            amountOfJamThatCanBeMade = ((1 - limitingIngredient.Amount) / limitingIngredient.Amount) * 
                getDeliveriesForRawMaterial(limitingIngredient.RawGoods)[0].Amount + amountOfLimitingIngredientToUse;


            return amountOfJamThatCanBeMade;
        }

        private List<Tuple<Recipe, decimal>> orderRecipesByPrice()
        {
            List<Tuple<Recipe, decimal>> recipePrices = new List<Tuple<Recipe, decimal>>();

            foreach (Recipe recipe in recipes)
            {
                decimal price = calculateRecipePrice(recipe);
                Tuple<Recipe, decimal> recipePrice = new Tuple<Recipe, decimal>(recipe, price);
                recipePrices.Add(recipePrice);
            }

            List<Tuple<Recipe, decimal>> sortedRecipePrices = recipePrices.OrderBy(p => p.Item2).ToList();

            return sortedRecipePrices;
        }

        private decimal calculateRecipePrice(Recipe recipe)
        {
            decimal price = 0;

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                List<ReceivedGoods> matchingDeliveries = getDeliveriesForRawMaterial(ingredient.RawGoods);

                // broken - what about multiple deliveries for same raw material?
                price += (decimal)ingredient.Amount * matchingDeliveries[0].Price;
            }

            Console.WriteLine("Recipe: " + recipe.Name + " Price: " + price);
            return price;
        }

        private List<ReceivedGoods> getDeliveriesForRawMaterial(RawGoods targetRawMaterial)
        {
            List<ReceivedGoods> matchingDeliveries = new List<ReceivedGoods>();

            foreach (ReceivedGoods delivery in receivedGoods)
            {
                if (delivery.RawGoods == targetRawMaterial)
                {
                    matchingDeliveries.Add(delivery);
                }
            }

            return matchingDeliveries;
        }

    }
}
