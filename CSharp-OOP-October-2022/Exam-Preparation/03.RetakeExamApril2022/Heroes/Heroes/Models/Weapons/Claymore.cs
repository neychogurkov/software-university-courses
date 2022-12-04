namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        public const int DEFAULT_DAMAGE = 20;

        public Claymore(string name, int durability) 
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (this.Durability == 0)
            {
                return 0;
            }

            this.Durability--;

            return DEFAULT_DAMAGE;
        }
    }
}
