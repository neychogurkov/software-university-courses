using System;
using System.Linq;
using System.Collections.Generic;

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

            Dictionary<string, int> tilesByLocation = new Dictionary<string, int>();

            while (whiteTilesAreas.Any() && greyTilesAreas.Any())
            {
                int currentWhiteTile = whiteTilesAreas.Pop();
                int currentGreyTile = greyTilesAreas.Dequeue();

                if (currentWhiteTile == currentGreyTile)
                {
                    switch (currentWhiteTile + currentGreyTile)
                    {
                        case 40:
                            AddTiles(tilesByLocation, "Sink");
                            break;
                        case 50:
                            AddTiles(tilesByLocation, "Oven");
                            break;
                        case 60:
                            AddTiles(tilesByLocation, "Countertop");
                            break;
                        case 70:
                            AddTiles(tilesByLocation, "Wall");
                            break;
                        default:
                            AddTiles(tilesByLocation, "Floor");
                            break;
                    }
                }
                else
                {
                    whiteTilesAreas.Push(currentWhiteTile / 2);
                    greyTilesAreas.Enqueue(currentGreyTile);
                }
            }

            Console.WriteLine($"White tiles left: {(whiteTilesAreas.Any() ? string.Join(", ", whiteTilesAreas) : "none")}");
            Console.WriteLine($"Grey tiles left: {(greyTilesAreas.Any() ? string.Join(", ", greyTilesAreas) : "none")}");

            foreach (var tiles in tilesByLocation.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine($"{tiles.Key}: {tiles.Value}");
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
