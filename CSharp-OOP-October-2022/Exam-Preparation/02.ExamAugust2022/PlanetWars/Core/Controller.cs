namespace PlanetWars.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.MilitaryUnits;
    using Models.MilitaryUnits.Contracts;
    using Models.Planets;
    using Models.Planets.Contracts;
    using Models.Weapons;
    using Models.Weapons.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly IRepository<IPlanet> planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (unitTypeName != "AnonymousImpactUnit" && unitTypeName != "StormTroopers" && unitTypeName != "SpaceForces")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit militaryUnit = null;
            if (unitTypeName == "AnonymousImpactUnit")
            {
                militaryUnit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "StormTroopers")
            {
                militaryUnit = new StormTroopers();
            }
            else if (unitTypeName == "SpaceForces")
            {
                militaryUnit = new SpaceForces();
            }

            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (weaponTypeName != "BioChemicalWeapon" && weaponTypeName != "NuclearWeapon" && weaponTypeName != "SpaceMissiles")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            IWeapon weapon = null;
            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (this.planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            this.planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            var orderedPlanets = this.planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);

            IPlanet winner = null;

            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                winner = firstPlanet;
            }
            else if (firstPlanet.MilitaryPower < secondPlanet.MilitaryPower)
            {
                winner = secondPlanet;
            }
            else
            {
                bool firstPlanetHasNuclearWeapon = firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
                bool secondPlanetHasNuclearWeapon = secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
                if ((firstPlanetHasNuclearWeapon && secondPlanetHasNuclearWeapon) || (!firstPlanetHasNuclearWeapon && !secondPlanetHasNuclearWeapon))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    return OutputMessages.NoWinner;
                }
                else
                {
                    winner = firstPlanetHasNuclearWeapon ? firstPlanet : secondPlanet;
                }
            }

            IPlanet loser = winner == firstPlanet ? secondPlanet : firstPlanet;

            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);
            winner.Profit(loser.Army.Sum(u => u.Cost) + loser.Weapons.Sum(w => w.Price));
            this.planets.RemoveItem(planetOne == loser.Name ? planetOne : planetTwo);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
