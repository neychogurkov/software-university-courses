namespace Gym.Models.Equipment
{
    using Contracts;

    public abstract class Equipment : IEquipment
    {
        public Equipment(double weight, decimal price)
        {
            this.Weight = weight;
            this.Price = price;
        }

        public double Weight { get; private set; }

        public decimal Price { get; private set; }
    }
}
