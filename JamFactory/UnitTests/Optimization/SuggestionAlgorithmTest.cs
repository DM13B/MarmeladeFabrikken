﻿using System;
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
            List<Tuple<Recipe, decimal, double>> resultList = sA.CalculateProduction(null);

            List<Tuple<Recipe, decimal, double>> tupleList = new List<Tuple<Recipe, decimal, double>>();

            CollectionAssert.AreEqual(tupleList, resultList);
        }

        [TestMethod]
        public void TestCalculateProductionWithBasic()
        {
            List<Tuple<Recipe, decimal, double>> resultList = sA.CalculateProduction("basic");

            string firstRecipeName = "Hyben/Æble Luksus";
            decimal firstPrice = 5.85m;
            string firstAmount = "1.100,83";

            Assert.AreEqual(firstRecipeName, resultList[0].Item1.Name);
            Assert.AreEqual(firstPrice, resultList[0].Item2);
            Assert.AreEqual(firstAmount,resultList[0].Item3.ToString("n2"));
        }




    }
}
