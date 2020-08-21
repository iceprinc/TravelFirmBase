using System.Data.SqlClient;
using System;

namespace TourAgency
{
    class DBSQLServerUtils
    {        
        public static SqlConnection GetDBConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=travel_firm_db;Integrated Security=True");
            return conn;
        }
    }
}
