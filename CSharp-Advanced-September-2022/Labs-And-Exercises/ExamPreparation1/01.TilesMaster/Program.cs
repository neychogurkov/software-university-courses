using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTilesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] greyTilesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> whiteTilesAreas = new Stack<int>(whiteTilesInput);
            Queue<int> greyTilesAreas = new Queue<int>(greyTilesInput);

            Dictionary<int, string> locationsByArea = new Dictionary<int, string>()
            {
                { 40, "Sink" },
                { 50, "Oven" },
                { 60, "Countertop" },
                { 70, "Wall" }
            };

            Dictionary<string, int> tilesByLocation = new Dictionary<string, int>();

            while (whiteTilesAreas.Any() && greyTilesAreas.Any())
            {
                int currentWhiteTilesArea = whiteTilesAreas.Pop();
                int currentgrayTilesArea = greyTilesAreas.Dequeue();

                if (currentWhiteTilesArea == currentgrayTilesArea)
                {
                    int tilesArea = currentWhiteTilesArea + currentgrayTilesArea;

                    if (locationsByArea.ContainsKey(tilesArea))
                    {
                        string location = locationsByArea[tilesArea];
                        AddTiles(tilesByLocation, location);
                    }
                    else
                    {
                        AddTiles(tilesByLocation, "Floor");
                    }
                }
                else
                {
                    whiteTilesAreas.Push(currentWhiteTilesArea / 2);
                    greyTilesAreas.Enqueue(currentgrayTilesArea);
                }
            }

            Console.WriteLine($"White tiles left: {(whiteTilesAreas.Any() ? string.Join(", ", whiteTilesAreas) : "none")}");
            Console.WriteLine($"Grey tiles left: {(greyTilesAreas.Any() ? string.Join(", ", greyTilesAreas) : "none")}");

            foreach (var (location, tiles) in tilesByLocation.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine($"{location}: {tiles}");
            }
        }

        static void AddTiles(Dictionary<string, int> tilesByLocation, string location)
        {
            if (!tilesByLocation.ContainsKey(location))
            {
                tilesByLocation[location] = 0;
            }

            tilesByLocation[location]++;
        }
    }
}
