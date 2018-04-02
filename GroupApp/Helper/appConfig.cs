using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupApp.Helper
{
    public class appConfig
    {
        private static String _ConnectionString = "Data Source=NATRIXDATASERVE;Initial Catalog=SCIM;User ID=sa;Password=native2013";
        public static String ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
        }
    }
}
