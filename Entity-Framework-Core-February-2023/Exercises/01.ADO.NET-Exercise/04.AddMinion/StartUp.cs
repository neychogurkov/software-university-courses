using Microsoft.Data.SqlClient;
using System.Text;

namespace _04.AddMinion
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;Trust Server Certificate = true";
            await using SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            string[] minionInfo = Console.ReadLine().Split().Skip(1).ToArray();
            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string townName = minionInfo[2];
            string villainName = Console.ReadLine().Split()[1];

            string result = await AddMinionToVillainAsync(connection, minionName, minionAge, townName, villainName);
            Console.WriteLine(result);
        }

        private static async Task<string> AddMinionToVillainAsync(SqlConnection connection, string minionName, int minionAge, string townName, string villainName)
        {
            StringBuilder sb = new StringBuilder();

            SqlTransaction sqlTransaction = connection.BeginTransaction();

            try
            {
                int townId = await GetTownIdOrAddNewTownAsync(connection, sqlTransaction, sb, townName);
                int villainId = await GetVillainIdOrAddNewVillainAsync(connection, sqlTransaction, sb, villainName);
                int minionId = await AddNewMinionAndGetIdAsync(connection, sqlTransaction, minionName, minionAge, townId);

                await AddMinionToVillainAsync(connection, sqlTransaction, villainId, minionId);
                sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                await sqlTransaction.CommitAsync();
            }
            catch
            {
                await sqlTransaction.RollbackAsync();
            }

            return sb.ToString().TrimEnd();
        }

        private static async Task<int> GetTownIdOrAddNewTownAsync(SqlConnection connection, SqlTransaction sqlTransaction, StringBuilder sb, string townName)
        {
            SqlCommand getTownIdCommand = new SqlCommand(SqlQueries.GetTownIdByName, connection, sqlTransaction);
            getTownIdCommand.Parameters.AddWithValue("@townName", townName);

            int? townId = (int?)await getTownIdCommand.ExecuteScalarAsync();

            if (townId == null)
            {
                SqlCommand addTownCommand = new SqlCommand(SqlQueries.AddTown, connection, sqlTransaction);
                addTownCommand.Parameters.AddWithValue("@townName", townName);
                await addTownCommand.ExecuteNonQueryAsync();

                sb.AppendLine($"Town {townName} was added to the database.");
                townId = (int)await getTownIdCommand.ExecuteScalarAsync();
            }

            return townId.Value;
        }

        private static async Task<int> GetVillainIdOrAddNewVillainAsync(SqlConnection connection, SqlTransaction sqlTransaction, StringBuilder sb, string villainName)
        {
            SqlCommand getVillainIdCommand = new SqlCommand(SqlQueries.GetVillainIdByName, connection, sqlTransaction);
            getVillainIdCommand.Parameters.AddWithValue("@Name", villainName);

            int? villainId = (int?)await getVillainIdCommand.ExecuteScalarAsync();

            if (villainId == null)
            {
                SqlCommand addVillainCommand = new SqlCommand(SqlQueries.AddVilain, connection, sqlTransaction);
                addVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                await addVillainCommand.ExecuteNonQueryAsync();

                sb.AppendLine($"Villain {villainName} was added to the database.");
                villainId = (int)await getVillainIdCommand.ExecuteScalarAsync();
            }

            return villainId.Value;
        }

        private static async Task<int> AddNewMinionAndGetIdAsync(SqlConnection connection, SqlTransaction sqlTransaction, string minionName, int minionAge, int townId)
        {
            SqlCommand addMinionCommand = new SqlCommand(SqlQueries.AddMinion, connection, sqlTransaction);
            addMinionCommand.Parameters.AddWithValue("@name", minionName);
            addMinionCommand.Parameters.AddWithValue("@age", minionAge);
            addMinionCommand.Parameters.AddWithValue("@townId", townId);
            await addMinionCommand.ExecuteNonQueryAsync();

            SqlCommand getMinionIdCommand = new SqlCommand(SqlQueries.GetMinionIdByName, connection, sqlTransaction);
            getMinionIdCommand.Parameters.AddWithValue("@Name", minionName);
            int minionId = (int)await getMinionIdCommand.ExecuteScalarAsync();

            return minionId;
        }

        private static async Task AddMinionToVillainAsync(SqlConnection connection, SqlTransaction sqlTransaction, int villainId, int minionId)
        {
            SqlCommand addMinionToVillainCommand = new SqlCommand(SqlQueries.AddMinionToVillain, connection, sqlTransaction);
            addMinionToVillainCommand.Parameters.AddWithValue("@minionId", minionId);
            addMinionToVillainCommand.Parameters.AddWithValue("@villainId", villainId);
            await addMinionToVillainCommand.ExecuteNonQueryAsync();
        }
    }
}