namespace Heroes.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Contracts;
    using Models.Heroes;
    using Models.Map;
    using Models.Weapons;
    using Repositories;
    using Repositories.Contracts;

    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            if (type != "Barbarian" && type != "Knight")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            IHero hero;
            if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);
            }
            else
            {
                hero = new Knight(name, health, armour);
            }
            this.heroes.Add(hero);

            return $"Successfully added {(type == "Barbarian" ? "Barbarian" : "Sir")} {name} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            if (type != "Mace" && type != "Claymore")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            IWeapon weapon;
            if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }
            else
            {
                weapon = new Claymore(name, durability);
            }
            this.weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = this.heroes.FindByName(heroName);
            IWeapon weapon = this.weapons.FindByName(weaponName);

            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);

            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string StartBattle()
        {
            IMap map = new Map();
            var heroesCollection = this.heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();
            return map.Fight(heroesCollection);
        }

        public string HeroReport()
        {
            var orderedHeroes = this.heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var hero in orderedHeroes)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}")
                    .AppendLine($"--Health: {hero.Health}")
                    .AppendLine($"--Armour: {hero.Armour}")
                    .AppendLine($"--Weapon: {(hero.Weapon != null ? $"{hero.Weapon.Name}" : "Unarmed")}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
