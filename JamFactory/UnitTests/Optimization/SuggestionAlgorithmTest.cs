using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Optimization;
using System.Collections.Generic;

namespace UnitTests.Optimization
{
    [TestClass]
    public class SuggestionAlgorithmTest
    {
        private SuggestionAlgorithm sA;

        [TestInitialize]
        public void Init()
        {
            List<ReceivedGoods> receivedGoods = new List<ReceivedGoods>();
            List<Recipe> recipes = new List<Recipe>();
            List<RawGoods> rawGoods = new List<RawGoods>();

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

            sA = new SuggestionAlgorithm(receivedGoods,recipes);
        }

        [TestMethod]
        public void TestCalculateProdutionWithNull()
        {
            List<Tuple<Recipe, decimal, double>> actualResult = sA.CalculateProduction(null);

            List<Tuple<Recipe, decimal, double>> expectedResult = new List<Tuple<Recipe, decimal, double>>();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestCalculateProdutionWithUnkownAlgorithm()
        {
            List<Tuple<Recipe, decimal, double>> actualResult = sA.CalculateProduction("fister");

            List<Tuple<Recipe, decimal, double>> expectedResult = new List<Tuple<Recipe, decimal, double>>();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestCalculateProductionPriceWithBasic()
        {
            List<Tuple<Recipe, decimal, double>> resultList = sA.CalculateProduction("basic");

            string expectedRecipeName = "Hyben/Æble Luksus";
            decimal expectedRecipePrice = 5.85m;

            string actualRecipeName = resultList[0].Item1.Name;
            decimal actualRecipePrice = resultList[0].Item2;

            Assert.AreEqual(expectedRecipeName, actualRecipeName);
            Assert.AreEqual(expectedRecipePrice, actualRecipePrice);
        }

        [TestMethod]
        public void TestCalculateProductionAmountWithBasic()
        {
            List<Tuple<Recipe, decimal, double>> resultList = sA.CalculateProduction("basic");

            Tuple<Recipe, decimal, double> result = resultList[0];

            foreach (Tuple<Recipe, decimal, double> recipeProduction in resultList)
            {
                if (recipeProduction.Item1.Name == "Hyben/Æble Luksus")
                {
                    result = recipeProduction;
                }
            }

            string expectedAmount = "1.100,83";
            string actualAmount = result.Item3.ToString("n2");

            Assert.AreEqual(expectedAmount, actualAmount);
        }




    }
}
