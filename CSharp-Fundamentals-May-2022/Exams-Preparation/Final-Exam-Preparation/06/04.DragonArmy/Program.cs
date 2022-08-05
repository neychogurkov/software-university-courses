using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.DragonArmy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dragon>> dragonsByType = new Dictionary<string, List<Dragon>>();

            int countOfDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfDragons; i++)
            {
                string[] dragonInfo = Console.ReadLine().Split();

                string type = dragonInfo[0];
                string name = dragonInfo[1];
                string damage = dragonInfo[2];
                string health = dragonInfo[3];
                string armor = dragonInfo[4];

                if (damage == "null")
                {
                    damage = "45";
                }
                if (health == "null")
                {
                    health = "250";
                }
                if (armor == "null")
                {
                    armor = "10";
                }

                Dragon dragon = new Dragon(name, int.Parse(damage), int.Parse(health), int.Parse(armor));

                if (!dragonsByType.ContainsKey(type))
                {
                    dragonsByType[type] = new List<Dragon>();
                }

                if (dragonsByType[type].Any(d => d.Name == name))
                {
                    Dragon currentDragon = dragonsByType[type].Find(d => d.Name == name);

                    currentDragon.Damage = int.Parse(damage);
                    currentDragon.Health = int.Parse(health);
                    currentDragon.Armor = int.Parse(armor);
                }
                else
                {
                    dragonsByType[type].Add(dragon);
                }
            }

            foreach (var kvp in dragonsByType)
            {
                double averageDamage = kvp.Value.Average(d => d.Damage);
                double averageHealth = kvp.Value.Average(d => d.Health);
                double averageArmor = kvp.Value.Average(d => d.Armor);

                Console.WriteLine($"{kvp.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                foreach (var dragon in kvp.Value.OrderBy(d => d.Name))
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
