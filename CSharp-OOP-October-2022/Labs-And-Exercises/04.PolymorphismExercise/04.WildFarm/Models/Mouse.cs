using System;
using System.Collections.Generic;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        private const double MouseWeightIncrease = 0.1;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightIncrease => MouseWeightIncrease;

        public override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) };

        public override string ProduceSound() => "Squeak";

        public override string ToString()
            => base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
