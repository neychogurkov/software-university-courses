namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Astronauts.Contracts;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly ICollection<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => (IReadOnlyCollection<IAstronaut>)this.astronauts;

        public void Add(IAstronaut model)
        {
            this.astronauts.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return this.astronauts.FirstOrDefault(a => a.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
            return this.astronauts.Remove(model);
        }
    }
}
