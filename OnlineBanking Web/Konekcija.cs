using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineBanking_Web
{
    internal class Konekcija
    {
        static public SqlConnection Connect()
        {
            string cs;
            cs = ConfigurationManager.ConnectionStrings["csconfig"].ConnectionString;
            SqlConnection connection = new SqlConnection(cs);
            return connection;
        }
    }
}