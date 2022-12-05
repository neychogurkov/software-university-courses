namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double DEFAULT_WEIGHT = 10000;
        private const decimal DEFAULT_PRICE = 80;

        public Kettlebell() : base(DEFAULT_WEIGHT, DEFAULT_PRICE)
        {
        }
    }
}
