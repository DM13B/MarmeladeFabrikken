using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Optimization;
using System.Collections.Generic;

namespace UnitTests.Optimization
{
    [TestClass]
    public class SuggestionAlgorithm
    {
        [TestMethod]
        public void TestOfStringResult() // skidt test.. skal revurderes
        {
            DecisionBase db = new DecisionBase();

            db.rawGoods.Add(new RawGoods("Hyben"));
            db.rawGoods.Add(new RawGoods("Æble"));

            db.receivedGoods.Add(new ReceivedGoods { RawGoods = db.rawGoods[0], Amount = 300, Price = 10 });
            db.receivedGoods.Add(new ReceivedGoods { RawGoods = db.rawGoods[1], Amount = 600, Price = 2 });

            Recipe recipe2 = new Recipe("Hyben/Æble Luksus");
            recipe2.Ingredients.Add(new Ingredient { RawGoods = db.rawGoods[0], Amount = 0.225 });
            recipe2.Ingredients.Add(new Ingredient { RawGoods = db.rawGoods[1], Amount = 0.225 });
            db.recipes.Add(recipe2);

            string expected = "Hyben/Æble Luksus: 1.101 kg @ 2,70 kr/kg \n";

            Assert.AreEqual(expected, db.SuggestProduction("basic")); 
        }
    }
}
