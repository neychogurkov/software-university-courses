using System;
using System.Collections.Generic;

namespace _03.HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            PickHeroes(heroes);

            while (true)
            {
                string[] command = Console.ReadLine().Split(" - ");

                if (command[0] == "End")
                {
                    break;
                }

                switch (command[0])
                {
                    case "CastSpell":
                        CastSpell(command, heroes);
                        break;
                    case "TakeDamage":
                        TakeDamage(command, heroes);
                        break;
                    case "Recharge":
                        Recharge(command, heroes);
                        break;
                    case "Heal":
                        Heal(command, heroes);
                        break;
                }
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HitPoints}");
                Console.WriteLine($"  MP: {hero.Value.ManaPoints}");
            }
        }

        static void PickHeroes(Dictionary<string, Hero> heroes)
        {
            int countOfHeroes = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfHeroes; i++)
            {
                string[] heroInfo = Console.ReadLine().Split();

                string heroName = heroInfo[0];
                int hitPoints = int.Parse(heroInfo[1]);
                int manaPoints = int.Parse(heroInfo[2]);

                heroes[heroName] = new Hero(hitPoints, manaPoints);
            }
        }

        static void CastSpell(string[] command, Dictionary<string, Hero> heroes)
        {
            string heroName = command[1];
            int manaPointsNeeded = int.Parse(command[2]);
            string spellName = command[3];

            if (heroes[heroName].ManaPoints >= manaPointsNeeded)
            {
                heroes[heroName].ManaPoints -= manaPointsNeeded;
                Console.WriteLine(
                    $"{heroName} has successfully cast {spellName} and now has {heroes[heroName].ManaPoints} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
        }

        static void TakeDamage(string[] command, Dictionary<string, Hero> heroes)
        {
            string heroName = command[1];
            int damage = int.Parse(command[2]);
            string attacker = command[3];

            heroes[heroName].HitPoints -= damage;

            if (heroes[heroName].HitPoints > 0)
            {
                Console.WriteLine(
                    $"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HitPoints} HP left!");
            }
            else
            {
                heroes.Remove(heroName);
                Console.WriteLine($"{heroName} has been killed by {attacker}!");
            }
        }

        static void Recharge(string[] command, Dictionary<string, Hero> heroes)
        {
            string heroName = command[1];
            int amount = int.Parse(command[2]);

            int initialManaPoints = heroes[heroName].ManaPoints;

            heroes[heroName].ManaPoints = Math.Min(heroes[heroName].ManaPoints + amount, 200);

            Console.WriteLine($"{heroName} recharged for {heroes[heroName].ManaPoints - initialManaPoints} MP!");
        }

        static void Heal(string[] command, Dictionary<string, Hero> heroes)
        {
            string heroName = command[1];
            int amount = int.Parse(command[2]);

            int initialHitPoints = heroes[heroName].HitPoints;

            heroes[heroName].HitPoints = Math.Min(heroes[heroName].HitPoints + amount, 100);

            Console.WriteLine($"{heroName} healed for {heroes[heroName].HitPoints - initialHitPoints} HP!");
        }
    }

    class Hero
    {
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }

        public Hero(int hitPoints, int manaPoints)
        {
            HitPoints = hitPoints;
            ManaPoints = manaPoints;
        }
    }
}
