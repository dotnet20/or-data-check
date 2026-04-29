using System.Data;
using System.Data.SqlClient;

namespace or_data_check
{
    public class DatabaseService
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
                using (SqlCommand cmd = new SqlCommand(query, conn)) //command nie potrzebuje usinga, to connection wymaga zamknięcia  (stosując using, kompilator doda try-finally z kodem wywołującym close i dispose
                {
                    cmd.Parameters.AddWithValue("@Limit", limit);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            

            return dt;
        }
    }
}