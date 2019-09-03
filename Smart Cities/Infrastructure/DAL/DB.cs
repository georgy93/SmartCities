namespace SmartCities.Infrastructure.DAL
{
    using System.Configuration;
    using System.Data.SqlClient;

    internal class DB
    {
        private static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
            }
        }

        internal static SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            return connection;
        }
    }
}