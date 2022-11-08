namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name)
            : base(name)
        {
        }

        public override int Power => 100;

        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {this.Power} damage";
        }
    }
}
