namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        private const double WEAPON_PRICE = 3.2;

        public BioChemicalWeapon(int destructionLevel) 
            : base(destructionLevel, WEAPON_PRICE)
        {
        }
    }
}
