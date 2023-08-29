using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrajeet_MVC.Utility
{
    public class ConnectionString
    {
        private static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Mitrajeet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string conn
        {
            get => conStr;
        }
    }
}
