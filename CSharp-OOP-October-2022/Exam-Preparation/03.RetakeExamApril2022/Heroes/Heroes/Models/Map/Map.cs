namespace Heroes.Models.Map
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var barbarians = players.Where(p => p.GetType().Name == "Barbarian").ToList();
            var knights = players.Where(p => p.GetType().Name == "Knight").ToList();

            while (barbarians.Any(b => b.IsAlive) && knights.Any(k => k.IsAlive))
            {
                foreach (var knight in knights.Where(k => k.IsAlive))
                {
                    foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                {
                    foreach (var knight in knights.Where(k => k.IsAlive))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }
            }

            return knights.Any(k => k.IsAlive)
                ? $"The knights took {knights.Count(k => !k.IsAlive)} casualties but won the battle."
                : $"The barbarians took {barbarians.Count(b => !b.IsAlive)} casualties but won the battle.";
        }
    }
}
