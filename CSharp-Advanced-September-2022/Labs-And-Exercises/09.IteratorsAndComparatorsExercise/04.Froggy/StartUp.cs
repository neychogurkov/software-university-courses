﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int[] stones = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Lake lake = new Lake(stones);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
