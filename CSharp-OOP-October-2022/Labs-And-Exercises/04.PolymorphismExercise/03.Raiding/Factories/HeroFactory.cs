namespace Raiding.Factories
{
    using Contracts;
    using Models;
    using Models.Contracts;

    public class HeroFactory : IHeroFactory
    {
        public IBaseHero CreateHero(string type, string name)
        {
            IBaseHero hero = null;
            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }

            return hero;
        }
    }
}
