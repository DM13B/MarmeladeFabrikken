using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Interface;


namespace Model.QualityControl 
{
    [Serializable]
    public class Test : ITest
    {
        public string TestName { get; set; }
        public string Result { get; set; }
        public DateTime TestTime { get; set; }

        public Test(string testName)
        {
            TestName = testName;
        }

        public void CompleteTest(string result)
        {
            Result = result;
            TestTime = DateTime.Now;
        }

        public override string ToString()
        {
            return TestName;
        }
    }
}
