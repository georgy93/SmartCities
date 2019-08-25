namespace DAL
{
    using System.Configuration;
    using System.Data.SqlClient;

    public class DB
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DbConnection"].ToString();                
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
