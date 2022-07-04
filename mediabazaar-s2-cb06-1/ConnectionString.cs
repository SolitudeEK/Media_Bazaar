using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediabazaar_s2_cb06_1
{
    class ConnectionString
    {
        private static string conn = @"Server=studmysql01.fhict.local;Uid=dbi451854;Database=dbi451854;password=secret;";
        //private static string conn= @"Server=localhost;Database=dbi451854;User Id=mysql;Password=mysql;"; // OpenServer local variant       
        
        public static string GetConStr()
        {
            return conn;
        }
    }
}
