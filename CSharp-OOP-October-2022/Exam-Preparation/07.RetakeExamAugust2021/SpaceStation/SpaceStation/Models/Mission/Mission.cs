namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;

    using Astronauts.Contracts;
    using Contracts;
    using Planets.Contracts;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            var explorers = astronauts.Where(a => a.CanBreath).ToList();

            for (int i = 0; i < explorers.Count; i++)
            {
                var items = planet.Items.ToList();
                for (int j = 0; j < items.Count; j++)
                {
                    if (!explorers[i].CanBreath)
                    {
                        break;
                    }

                    explorers[i].Bag.Items.Add(items[j]);
                    planet.Items.Remove(items[j]);
                    explorers[i].Breath();
                }
            }
        }
    }
}
