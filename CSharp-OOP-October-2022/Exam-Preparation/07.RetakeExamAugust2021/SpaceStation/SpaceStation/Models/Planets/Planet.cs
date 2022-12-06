namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;

        public Planet(string name)
        {
            this.Name = name;
            this.Items = new List<string>();
        }

        public ICollection<string> Items { get; set; }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }
    }
}
