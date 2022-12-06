namespace SpaceStation.Models.Astronauts
{
    using System;

    using Bags;
    using Bags.Contracts;
    using Contracts;
    using Utilities.Messages;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get { return this.oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            this.Oxygen -= 10;

            if (this.Oxygen < 0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
