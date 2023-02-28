using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.RemoveVillain
{
    public static class SqlQueries
    {
        public const string GetVillainNameById =
            @"SELECT Name 
                FROM Villains 
               WHERE Id = @villainId";

        public const string DeleteMinionsOfVillainsById =
            @"DELETE FROM MinionsVillains 
                    WHERE VillainId = @villainId";

        public const string DeleteVillainById =
            @"DELETE FROM Villains
                    WHERE Id = @villainId";
    }
}
