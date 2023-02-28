using Microsoft.Data.SqlClient;
using System.Text;

namespace _08.IncreaseMinionAge
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;Trust Server Certificate = true";
            await using SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            int[] minionsIds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string result = await GetMinionsNameAndAgeAsync(connection, minionsIds);
            Console.WriteLine(result);
        }

        private static async Task<string> GetMinionsNameAndAgeAsync(SqlConnection connection, int[] minionsIds)
        {
            foreach (var minionId in minionsIds)
            {
                SqlCommand updateMinionCommand = new SqlCommand(SqlQueries.UpdateMinionById, connection);
                updateMinionCommand.Parameters.AddWithValue("@Id", minionId);
                await updateMinionCommand.ExecuteNonQueryAsync();
            }

            SqlCommand getMinionsNameAndAgeCommand = new SqlCommand(SqlQueries.GetMinionsNameAndAge, connection);
            SqlDataReader reader = await getMinionsNameAndAgeCommand.ExecuteReaderAsync();

            StringBuilder sb = new StringBuilder();

            while (reader.Read())
            {
                string minionName = (string)reader["Name"];
                int minionAge = (int)reader["Age"];
                sb.AppendLine($"{minionName} {minionAge}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}