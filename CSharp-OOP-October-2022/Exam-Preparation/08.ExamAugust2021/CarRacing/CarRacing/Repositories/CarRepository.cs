namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Cars.Contracts;
    using Utilities.Messages;

    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => (IReadOnlyCollection<ICar>)this.cars;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            this.cars.Add(model);
        }

        public ICar FindBy(string property)
        {
            return this.cars.FirstOrDefault(c => c.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return this.cars.Remove(model);
        }
    }
}
