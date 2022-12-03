namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly ICollection<IMilitaryUnit> militaryUnits;

        public UnitRepository()
        {
            this.militaryUnits = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => (IReadOnlyCollection<IMilitaryUnit>)this.militaryUnits;

        public void AddItem(IMilitaryUnit model)
        {
            this.militaryUnits.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return this.militaryUnits.FirstOrDefault(u => u.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.militaryUnits.Remove(this.militaryUnits.FirstOrDefault(u => u.GetType().Name == name));
        }
    }
}
