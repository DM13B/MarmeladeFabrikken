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
        public string SuggestProduction()
        {
            string suggestion = "";
            DecisionBase decisionBase = new DecisionBase();

            decisionBase.SeedWithData();

            suggestion = decisionBase.SuggestProduction();

            return suggestion;
        }
    }
}
