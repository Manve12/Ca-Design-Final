using StoreGraphRenderer.Data;
using StoreGraphRenderer.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreGraphRenderer.Data
{
    public class StoredProcedureHandler
    {
        public static DataTable Get(StoredProcedures.Procedure procedure, Dictionary<string,string> parametersWithValue)
        {
            string procedureName = "";

            foreach(var name in StoredProcedures.StoredProcedure)
            {
                if (name.Key == procedure)
                {
                    procedureName = name.Value;
                    break;
                }
            }
            
            SqlCommand cmd = DbConnect.ConnectionDatabase.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;

            foreach (var param in parametersWithValue)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value);
            }

            cmd.CommandTimeout = DbConnect.ConnectionTimeout;
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();

            DbConnect.OpenConnection();

            da.Fill(data);

            DbConnect.CloseConnection();

            return data;
        }
    }
}