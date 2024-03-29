﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MinionNames
{
    public static class SqlQueries
    {
        public const string GetVillainNameById =
            @"SELECT Name 
                FROM Villains 
               WHERE Id = @Id";

        public const string GetMinionsNameAndAge =
            @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                     m.Name, 
                     m.Age
                FROM MinionsVillains AS mv
                JOIN Minions As m ON mv.MinionId = m.Id
               WHERE mv.VillainId = @Id
            ORDER BY m.Name";
    }
}
