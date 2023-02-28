using Microsoft.Data.SqlClient;
using System.Text;

namespace _02.VillainNames
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;Trust Server Certificate = true";

            await using SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            string result = await GetVillainsNamesAndNumberOfMinionsAsync(connection);

            Console.WriteLine(result);
        }

        private static async Task<string> GetVillainsNamesAndNumberOfMinionsAsync(SqlConnection connection)
        {
            SqlCommand getVillainInfoCommand = new SqlCommand(SqlQueries.GetVillainNameAndCountOfTheirMinions, connection);
            SqlDataReader dataReader = await getVillainInfoCommand.ExecuteReaderAsync();
            StringBuilder sb = new StringBuilder();

            while (dataReader.Read())
            {
                string villainName = (string)dataReader["Name"];
                int minionsCount = (int)dataReader["MinionsCount"];
                sb.AppendLine($"{villainName} {minionsCount}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}