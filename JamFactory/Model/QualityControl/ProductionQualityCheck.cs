using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Model.QualityControl
{
    [Serializable]
    public class ProductionQualityCheck : IProductionQualityCheck
    {
        private string _ControlName;
        public string ControlName{get { return _ControlName; }set { _ControlName = value; }}

        private string _ControlDescription;
        public string ControlDescription{get { return _ControlDescription; }set { _ControlDescription = value; }}

        //Control Type, Resultat 1 og 2 (2 pga. mulighed for interval check)
        private int _ControlType;
        public int ControlType { get { return _ControlType; } set { _ControlType = value; } }

        private bool _ExpectedBoolResult;
        public bool ExpectedBoolResult{get { return _ExpectedBoolResult; }set { _ExpectedBoolResult = value; }}
        
        private string _ExpectedResult1;
        public string ExpectedResult1{get { return _ExpectedResult1; }set { _ExpectedResult1 = value; }}

        private string _ExpectedResult2;
        public string ExpectedResult2{get { return _ExpectedResult2; }set { _ExpectedResult2 = value; }}

        private string _ControlResult;
        public string ControlResult { get { return _ControlResult; } set { _ControlResult = value; } }

        private string _ControlResult2;
        public string ControlResult2{get { return _ControlResult2; }set { _ControlResult2 = value; }}

        private bool _BoolResult;
        public bool BoolResult{get { return _BoolResult; }set { _BoolResult = value; }}
        
        
        // Commented ud, fjernes på senere tidspunkt 
        //private List<ITest> _Tests;
        //public List<ITest> Tests{get { return _Tests; }set { _Tests = value; }}

        private DateTime _ControlDone;
        public DateTime ControlDone{get { return _ControlDone; }set { _ControlDone = value; }}
        
        private bool _ControlSuccess;
        public bool ControlSuccess{get { return _ControlSuccess; }set { _ControlSuccess = value; }}        

        private DateTime _ControlStart;
        public DateTime ControlStart{get { return _ControlStart; }set { _ControlStart = value; }}

        private DateTime _ControlEnd;
        public DateTime ControlEnd{get { return _ControlEnd; }set { _ControlEnd = value; }}

        /// <summary>
        /// Navn på Kontrollør
        /// </summary>
        private string _Controller;
        public string Controller{get { return _Controller; }set { _Controller = value; }}
        
    }
}
