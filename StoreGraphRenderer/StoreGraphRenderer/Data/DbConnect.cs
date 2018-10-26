using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StoreGraphRenderer.Data
{
    public static class DbConnect
    {
        public static string Connection { get; } = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static SqlConnection ConnectionDatabase { get; set; } = new SqlConnection(Connection);

        public static int ConnectionTimeout = 60;

        public static void OpenConnection()
        {
            ConnectionDatabase.Open();
        }

        public static void CloseConnection()
        {
            ConnectionDatabase.Close();
        }
    }
}