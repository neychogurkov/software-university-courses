namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double DEFAULT_WEIGHT = 227;
        private const decimal DEFAULT_PRICE = 120;

        public BoxingGloves() : base(DEFAULT_WEIGHT, DEFAULT_PRICE)
        {
        }
    }
}
