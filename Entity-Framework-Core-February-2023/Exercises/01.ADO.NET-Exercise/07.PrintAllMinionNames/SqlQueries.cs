using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PrintAllMinionNames
{
    public static class SqlQueries
    {
        public const string GetMinionsNames =
            @"SELECT Name 
                FROM Minions";
    }
}
