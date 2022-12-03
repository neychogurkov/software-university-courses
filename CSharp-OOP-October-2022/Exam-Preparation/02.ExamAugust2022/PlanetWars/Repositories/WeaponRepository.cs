namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Weapons.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)this.weapons;

        public void AddItem(IWeapon model)
        {
            this.weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.weapons.FirstOrDefault(w => w.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.weapons.Remove(this.weapons.FirstOrDefault(w => w.GetType().Name == name));
        }
    }
}
