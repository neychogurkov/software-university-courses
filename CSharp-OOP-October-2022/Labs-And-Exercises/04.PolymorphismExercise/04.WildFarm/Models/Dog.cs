using System;
using System.Collections.Generic;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        private const double DogWeightIncrease = 0.4;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightIncrease => DogWeightIncrease;

        public override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>() { typeof(Meat) };

        public override string ProduceSound() => "Woof!";

        public override string ToString()
            => base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
