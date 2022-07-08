using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DragonArmy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dragon>> dragonsTypes = new Dictionary<string, List<Dragon>>();

            int dragonsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < dragonsCount; i++)
            {
                string[] dragonInfo = Console.ReadLine().Split();

                if (dragonInfo[2] == "null")
                {
                    dragonInfo[2] = "45";
                }
                if (dragonInfo[3] == "null")
                {
                    dragonInfo[3] = "250";
                }
                if (dragonInfo[4] == "null")
                {
                    dragonInfo[4] = "10";
                }

                string dragonType = dragonInfo[0];
                string dragonName = dragonInfo[1];
                int dragonDamage = int.Parse(dragonInfo[2]);
                int dragonHealth = int.Parse(dragonInfo[3]);
                int dragonArmor = int.Parse(dragonInfo[4]);

                Dragon dragon = new Dragon(dragonName, dragonDamage, dragonHealth, dragonArmor);

                if (dragonsTypes.ContainsKey(dragonType))
                {
                    if (dragonsTypes[dragonType].Any(d => d.Name == dragonName))
                    {
                        Dragon currentDragon = dragonsTypes[dragonType].Find(d => d.Name == dragonName);

                        currentDragon.Damage = dragonDamage;
                        currentDragon.Health = dragonHealth;
                        currentDragon.Armor = dragonArmor;
                    }
                    else
                    {
                        dragonsTypes[dragonType].Add(dragon);
                    }
                }
                else
                {
                    dragonsTypes[dragonType] = new List<Dragon> { dragon };
                }
            }

            foreach (var dragonType in dragonsTypes)
            {
                double averageDamage = (double)dragonType.Value.Sum(d => d.Damage) / dragonType.Value.Count;
                double averageHealth = (double)dragonType.Value.Sum(d => d.Health) / dragonType.Value.Count;
                double averageArmor = (double)dragonType.Value.Sum(d => d.Armor) / dragonType.Value.Count;

                Console.WriteLine($"{dragonType.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                foreach (var dragon in dragonType.Value.OrderBy(d => d.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
    }

    class Dragon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public Dragon(string name, int damage, int health, int armor)
        {
            Name = name;
            Damage = damage;
            Health = health;
            Armor = armor;
        }
    }
}
