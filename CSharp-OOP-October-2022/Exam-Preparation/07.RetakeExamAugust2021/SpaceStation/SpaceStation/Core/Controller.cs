namespace SpaceStation.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Astronauts;
    using Models.Astronauts.Contracts;
    using Models.Mission;
    using Models.Mission.Contracts;
    using Models.Planets;
    using Models.Planets.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly IRepository<IPlanet> planets;
        private readonly IRepository<IAstronaut> astronauts;
        private int exploredPlanetsCount;

        public Controller()
        {
            this.planets = new PlanetRepository();
            this.astronauts = new AstronautRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var astronauts = this.astronauts.Models.Where(a => a.Oxygen > 60).ToList();

            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IMission mission = new Mission();
            IPlanet planet = this.planets.FindByName(planetName);
            mission.Explore(planet, astronauts);
            this.exploredPlanetsCount++;

            return string.Format(OutputMessages.PlanetExplored, planetName, astronauts.Where(a => !a.CanBreath).Count());
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}")
                    .AppendLine($"Oxygen: {astronaut.Oxygen}")
                    .AppendLine($"Bag items: {(astronaut.Bag.Items.Any() ? string.Join(", ", astronaut.Bag.Items) : "none")}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}