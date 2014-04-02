using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Optimization
{
    public class SuggestionAlgorithm
    {
        List<ReceivedGoods> receivedGoods;
        List<Recipe> recipes;

        public SuggestionAlgorithm(List<ReceivedGoods> receivedGoods, List<Recipe> recipes)
        {
            this.receivedGoods = receivedGoods;
            this.recipes = recipes;
        }

        /// <summary>
        /// Returns a list of prices and possible production amounts for each recipe, calculated 
        /// using specified algorithm
        /// </summary>
        /// <param name="algorithm">the name of an algorithm, currently only basic is available</param>
        /// <returns>list of recipes, prices and amounts sorted by price</returns>
        public List<Tuple<Recipe, decimal, double>> CalculateProduction(string algorithm)
        {
            List<Tuple<Recipe, decimal, double>> calculatedProduction;

            switch (algorithm)
            {
                case "basic":
                    calculatedProduction = basicProduction();
                    break;
                default:
                    calculatedProduction = new List<Tuple<Recipe, decimal, double>>();
                    break;
            }

            return calculatedProduction;
        }

        private List<Tuple<Recipe, decimal, double>> basicProduction()
        {
            List<Tuple<Recipe, decimal, double>> calculatedProduction = new List<Tuple<Recipe, decimal, double>>();

            List<Tuple<Recipe, decimal>> recipesByPrice = orderRecipesByPrice();

            foreach (Tuple<Recipe, decimal> recipePrice in recipesByPrice)
            {
                Recipe recipe = recipePrice.Item1;
                decimal price = recipePrice.Item2;

                double possibleAmount = calculateAmountThatCanBeProduced(recipe, receivedGoods);

                Tuple<Recipe, decimal, double> recipeProduction = 
                    new Tuple<Recipe, decimal, double>(recipe, price, possibleAmount);

                calculatedProduction.Add(recipeProduction);
            }

            return calculatedProduction;
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
