using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.IncreaseAgeStoredProcedure
{
    public static class SqlQueries
    {
        public const string ExecuteProcedureToGetOlder =
            @"EXEC usp_GetOlder @id";

        public const string GetMinionNameAndAgeById =
            @"SELECT Name, Age 
                FROM Minions 
               WHERE Id = @Id";
    }
}
