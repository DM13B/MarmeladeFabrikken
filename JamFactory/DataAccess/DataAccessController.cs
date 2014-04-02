using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class DataAccessController
    {

        private const string CONNECTION_STRING = "Data Source=ealdb1.eal.local;Initial Catalog=EJL15_DB;Persist Security Info=True;User ID=ejl15_usr;Password=Baz1nga15";

        public static string ConnectionString
        {
            get { return CONNECTION_STRING; }
        }
    }
}
