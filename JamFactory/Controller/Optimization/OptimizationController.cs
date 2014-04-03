using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.Optimization;
using Common.Interfaces;

namespace Controller.Optimization
{
    public class OptimizationController
    {
        List<ReceivedGoods> possibleReceivedGoods;
        List<RawGoods> rawGoodsList;

        public OptimizationController()
        {
            possibleReceivedGoods = new List<ReceivedGoods>();
            rawGoodsList = SeedRawGoodsList();
        }

        public string SuggestProduction()
        {
            string suggestion = "";
            DecisionBase decisionBase = new DecisionBase();

            decisionBase.SeedWithData();

            suggestion = decisionBase.SuggestProduction("basic");

            return suggestion;
        }

        public void AddPossibleReceivedGoods(string supplierName, string rawGoodsName, double amount, decimal price, DateTime received)
        {
            RawGoods rawGoods;
            switch (rawGoodsName)
            {
                case "Hyben":
                    rawGoods = rawGoodsList[0];
                    break;
                case "Æble":
                    rawGoods = rawGoodsList[1];
                    break;
                case "Boysenbær":
                    rawGoods = rawGoodsList[2];
                    break;
                case "Jordbær":
                    rawGoods = rawGoodsList[3];
                    break;
                case "Solbær":
                    rawGoods = rawGoodsList[4];
                    break;
                default:
                    rawGoods = new RawGoods(rawGoodsName);
                    break;
            }
            ReceivedGoods receivedGoods = new ReceivedGoods(rawGoods, amount, price, received, supplierName);
            possibleReceivedGoods.Add(receivedGoods);
        }

        public List<IReceivedGoods> LoadPossibleReceviedGoods()
        {
            return possibleReceivedGoods.Cast<IReceivedGoods>().ToList();
        }

        public void DeletePossibleReceivedGoods(IReceivedGoods receivedGoods)
        {
            possibleReceivedGoods.Remove((ReceivedGoods)receivedGoods);
        }

        public void DeleteAllPossibleReceivedGoods()
        {
            possibleReceivedGoods.Clear();
        }

        public List<RawGoods> SeedRawGoodsList() // temporary
        {
            rawGoodsList = new List<RawGoods>();
            rawGoodsList.Add(new RawGoods("Hyben"));
            rawGoodsList.Add(new RawGoods("Æble"));
            rawGoodsList.Add(new RawGoods("Boysenbær"));
            rawGoodsList.Add(new RawGoods("Jordbær"));
            rawGoodsList.Add(new RawGoods("Solbær"));
            return rawGoodsList;
        }
    }
}
