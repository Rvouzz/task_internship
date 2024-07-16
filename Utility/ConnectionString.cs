using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesRecordManagementSystem.Utility
{
    public class ConnectionString
    {
        private static string cname = "Data Source=localhost\\MSSQLSERVER01;" +
            "Initial Catalog=db_orders;" +
            "Integrated Security=True";
        public static string CName
        {
            get { return cname; }
        }
    }
}
