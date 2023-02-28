using Microsoft.Data.SqlClient;
using System.Text;

namespace _07.PrintAllMinionNames
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;Trust Server Certificate = true";
            await using SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            string result = await GetAllMinionsNamesAsync(connection);
            Console.WriteLine(result);
        }

        private static async Task<string> GetAllMinionsNamesAsync(SqlConnection connection)
        {
            SqlCommand getMinionsNamesCommand = new SqlCommand(SqlQueries.GetMinionsNames, connection);
            SqlDataReader reader = await getMinionsNamesCommand.ExecuteReaderAsync();

            List<string> minionsNames = new List<string>();

            while (reader.Read())
            {
                string minionName = (string)reader["Name"];
                minionsNames.Add(minionName);
            }

            string output = PrintMinionsNames(minionsNames);

            return output;
        }

        private static string PrintMinionsNames(List<string> minionsNames)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < minionsNames.Count / 2; i++)
            {
                sb.AppendLine(minionsNames[i]);
                sb.AppendLine(minionsNames[minionsNames.Count - 1 - i]);
            }

            if (minionsNames.Count % 2 != 0)
            {
                sb.AppendLine(minionsNames[minionsNames.Count / 2]);
            }

            return sb.ToString().TrimEnd();
        }
    }
}