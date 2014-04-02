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
        List<ReceivedGoods> possibleReceivedGoods = new List<ReceivedGoods>();
        //List<RawGoods> rawGoodsList;

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
            RawGoods rawGoods = new RawGoods(rawGoodsName);
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
    }
}
