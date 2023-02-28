using Microsoft.Data.SqlClient;
using System.Text;

namespace _09.IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;Trust Server Certificate = true";
            await using SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            int minionId = int.Parse(Console.ReadLine());

            string result = await GetMinionNameAndAgeAsync(connection, minionId);
            Console.WriteLine(result);
        }

        private static async Task<string> GetMinionNameAndAgeAsync(SqlConnection connection, int minionId)
        {
            SqlCommand executeCommand = new SqlCommand(SqlQueries.ExecuteProcedureToGetOlder, connection);
            executeCommand.Parameters.AddWithValue("@id", minionId);
            await executeCommand.ExecuteNonQueryAsync();

            SqlCommand getMinionNameAndAgeCommand = new SqlCommand(SqlQueries.GetMinionNameAndAgeById, connection);
            getMinionNameAndAgeCommand.Parameters.AddWithValue("@id", minionId);
            SqlDataReader reader = await getMinionNameAndAgeCommand.ExecuteReaderAsync();

            StringBuilder sb = new StringBuilder();

            while (reader.Read())
            {
                string minionName = (string)reader["Name"];
                int minionAge = (int)reader["Age"];
                sb.AppendLine($"{minionName} - {minionAge} years old");
            }

            return sb.ToString().TrimEnd();
        }
    }
}