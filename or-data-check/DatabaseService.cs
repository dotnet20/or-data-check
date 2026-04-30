using System.Data;
using Microsoft.Data.SqlClient;

namespace or_data_check
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetTransactions(int limit = 10)
        {
            DataTable dt = new DataTable();
            string query = "SELECT TOP (@Limit) * FROM [dbo].[ExpenditureTransactions]";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Limit", limit);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }
    }
}