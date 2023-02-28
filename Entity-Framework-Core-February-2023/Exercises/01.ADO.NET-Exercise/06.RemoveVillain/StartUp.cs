using Microsoft.Data.SqlClient;
using System.Text;

namespace _06.RemoveVillain
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;Trust Server Certificate = true";
            await using SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            int villainId = int.Parse(Console.ReadLine());

            string result = await RemoveVillainAsync(connection, villainId);
            Console.WriteLine(result);
        }

        private static async Task<string> RemoveVillainAsync(SqlConnection connection, int villainId)
        {
            SqlCommand getVillainNameCommand = new SqlCommand(SqlQueries.GetVillainNameById, connection);
            getVillainNameCommand.Parameters.AddWithValue("@villainId", villainId);

            string? villainName = (string?)await getVillainNameCommand.ExecuteScalarAsync();

            if (villainName == null)
            {
                return "No such villain was found.";
            }

            string output = await DeleteVillainAndHisMinionsAsync(connection, villainId, villainName);

            return output;
        }

        private static async Task<string> DeleteVillainAndHisMinionsAsync(SqlConnection connection, int villainId, string? villainName)
        {
            SqlCommand deleteMinionsOfVillainCommand = new SqlCommand(SqlQueries.DeleteMinionsOfVillainsById, connection);
            deleteMinionsOfVillainCommand.Parameters.AddWithValue("@villainId", villainId);
            int releasedMinionsCount = await deleteMinionsOfVillainCommand.ExecuteNonQueryAsync();

            SqlCommand deleteVillainCommand = new SqlCommand(SqlQueries.DeleteVillainById, connection);
            deleteVillainCommand.Parameters.AddWithValue("@villainId", villainId);
            await deleteVillainCommand.ExecuteNonQueryAsync();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{villainName} was deleted.");
            sb.AppendLine($"{releasedMinionsCount} minions were released.");
            return sb.ToString().TrimEnd();
        }
    }
}