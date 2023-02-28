using Microsoft.Data.SqlClient;
using System.Text;

namespace _03.MinionNames
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;Trust Server Certificate = true";

            await using SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            int villainId = int.Parse(Console.ReadLine());

            string result = await GetMinionNamesForAVillainAsync(connection, villainId);
            Console.WriteLine(result);
        }

        private static async Task<string> GetMinionNamesForAVillainAsync(SqlConnection connection, int villainId)
        {
            SqlCommand getVillainNameCommand = new SqlCommand(SqlQueries.GetVillainNameById, connection);
            getVillainNameCommand.Parameters.AddWithValue("@Id", villainId);
            string? villainName = (string?)await getVillainNameCommand.ExecuteScalarAsync();


            if (villainName == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            SqlCommand getMinionsNameAndAgeCommand = new SqlCommand(SqlQueries.GetMinionsNameAndAge, connection);
            getMinionsNameAndAgeCommand.Parameters.AddWithValue("@Id", villainId);
            SqlDataReader reader = await getMinionsNameAndAgeCommand.ExecuteReaderAsync();

            string output = GetVillainAndInfoForHisMinions(villainName, reader);

            return output;
        }

        private static string GetVillainAndInfoForHisMinions(string villainName, SqlDataReader reader)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Villain: {villainName}");

            if (!reader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (reader.Read())
                {
                    long rowNumber = (long)reader["RowNum"];
                    string name = (string)reader["Name"];
                    int age = (int)reader["Age"];

                    sb.AppendLine($"{rowNumber}. {name} {age}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}