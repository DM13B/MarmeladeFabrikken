using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.Optimization;

namespace Controller.Optimization
{
    public class OptimizationController
    {
        private List<Supplier> supplierList = new List<Supplier>();
        public string SuggestProduction()
        {
            string suggestion = "";
            DecisionBase decisionBase = new DecisionBase();

            decisionBase.SeedWithData();

            suggestion = decisionBase.SuggestProduction("basic");

            return suggestion;
        }

        public void AddSupplier(List<Tuple<string, string, double, decimal>> suppliers)
        {
            for (int i = 0; i < suppliers.Count; i++)
			{
                RawGoods rawGoods = new RawGoods(suppliers[i].Item2);
                ReceivedGoods receivedGoods = new ReceivedGoods(rawGoods, suppliers[i].Item3, suppliers[i].Item4);
                Supplier supplier = new Supplier(suppliers[i].Item1, receivedGoods);
                supplierList.Add(supplier);
			}
        }
    }
}
