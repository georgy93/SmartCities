using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class DB
    {
        public static string ConnectionString
        {
            get
            {
                string connStr = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                
                return connStr;
            }
        }

        public static SqlConnection GetSqlConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString); 
            conn.Open(); 

            return conn;
        }       
    }
}
