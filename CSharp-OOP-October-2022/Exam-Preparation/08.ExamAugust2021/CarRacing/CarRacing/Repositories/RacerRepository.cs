namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Racers.Contracts;
    using Utilities.Messages;

    public class RacerRepository : IRepository<IRacer>
    {
        private readonly ICollection<IRacer> racers;

        public RacerRepository()
        {
            this.racers = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => (IReadOnlyCollection<IRacer>)this.racers;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            this.racers.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return this.racers.FirstOrDefault(r => r.Username == property);
        }

        public bool Remove(IRacer model)
        {
            return this.racers.Remove(model);
        }
    }
}
