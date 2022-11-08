namespace Raiding.Models
{
    using Contracts;

    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract int Power { get; }

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} ";
        }
    }
}
