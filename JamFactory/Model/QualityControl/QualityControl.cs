using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Interface;

namespace Model
{
    [Serializable]
    public class QualityControl : IQualityControl
    {
        private string _ControlName;
        public string ControlName
        {
            get { return _ControlName; }
            set { _ControlName = value; }
        }

        private string _ControlDescription;
        public string ControlDescription
        {
            get { return _ControlDescription; }
            set { _ControlDescription = value; }
        }

        private string _ExpectedResult;
        public string ExpectedResult
        {
            get { return _ExpectedResult; }
            set { _ExpectedResult = value; }
        }

        private List<ITest> _Tests;
        public List<ITest> Tests
        {
            get { return _Tests; }
            set { _Tests = value; }
        }

        private DateTime _ControlDone;
        public DateTime ControlDone
        {
            get { return _ControlDone; }
            set { _ControlDone = value; }
        }

        private bool _ControlResult;
        public bool ControlResult
        {
            get { return _ControlResult; }
            set { _ControlResult = value; }
        }

        private bool _ControlSuccess;
        public bool ControlSuccess
        {
            get { return _ControlSuccess; }
            set { _ControlSuccess = value; }
        }        

        private DateTime _ControlStart;
        public DateTime ControlStart
        {
            get { return _ControlStart; }
            set { _ControlStart = value; }
        }

        private DateTime _ControlEnd;
        public DateTime ControlEnd
        {
            get { return _ControlEnd; }
            set { _ControlEnd = value; }
        }

        private string _Controller;
        public string Controller
        {
            get { return _Controller; }
            set { _Controller = value; }
        }
        

        public QualityControl(string controlName, string controlDescription, string expectedResult)
        {
            ControlName = controlName;
            ControlDescription = controlDescription;
            ExpectedResult = expectedResult;
            Tests = new List<ITest>();
        }

    }
}
