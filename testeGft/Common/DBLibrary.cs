using System;
using System.Data;
using System.Data.SqlClient;

namespace Common
{
    public class DBLibrary
    {
        public static SqlConnection OpenConnection()
        {
            string connectionString = "Provider=sqloledb; Data Source=" + "" + "Initial Catalog=dbTrade;User Id=Trade;Password=Trade123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); 
                return connection;
            }
        }
    }
}
