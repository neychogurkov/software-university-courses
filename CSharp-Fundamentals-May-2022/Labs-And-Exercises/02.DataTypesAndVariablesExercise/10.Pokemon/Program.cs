using System;

namespace _10.Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialPokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int pokedTargets = 0;
            int pokePower = initialPokePower;

            while (pokePower >= distance)
            {
                pokePower -= distance;
                pokedTargets++;

                if (pokePower == initialPokePower / 2 && exhaustionFactor != 0)
                {
                    pokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokedTargets);
        }
    }
}
