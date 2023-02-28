using Microsoft.Data.SqlClient;
using System.Text;

namespace _05.ChangeTownNamesCasing
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;Trust Server Certificate = true";
            await using SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            string countryName = Console.ReadLine();

            string result = await GetUpdatedTownsNamesAsync(connection, countryName);
            Console.WriteLine(result);
        }

        private static async Task<string> GetUpdatedTownsNamesAsync(SqlConnection connection, string countryName)
        {
            int updatedTownsCount = await GetCountOfUpdatedTownsAsync(connection, countryName);

            if (updatedTownsCount == 0)
            {
                return "No town names were affected.";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{updatedTownsCount} town names were affected.");

            List<string> townsNames = await GetTownsNamesByCountryAsync(connection, countryName);
            sb.AppendLine($"[{string.Join(", ", townsNames)}]");

            return sb.ToString().TrimEnd();
        }

        private static async Task<int> GetCountOfUpdatedTownsAsync(SqlConnection connection, string countryName)
        {
            SqlCommand updateTownsCommand = new SqlCommand(SqlQueries.UpdateTownsNamesByCountry, connection);
            updateTownsCommand.Parameters.AddWithValue("@countryName", countryName);

            int updatedTownsCount = await updateTownsCommand.ExecuteNonQueryAsync();

            return updatedTownsCount;
        }

        private static async Task<List<string>> GetTownsNamesByCountryAsync(SqlConnection connection, string countryName)
        {
            SqlCommand getTownsNamesCommand = new SqlCommand(SqlQueries.GetTownsNamesByCountry, connection);
            getTownsNamesCommand.Parameters.AddWithValue("@countryName", countryName);

            SqlDataReader reader = await getTownsNamesCommand.ExecuteReaderAsync();

            List<string> townsNames = new List<string>();

            while (reader.Read())
            {
                townsNames.Add((string)reader["Name"]);
            }

            return townsNames;
        }
    }
}