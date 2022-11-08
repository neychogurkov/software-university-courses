using System;
using System.Collections.Generic;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        private const double CatWeightIncrease = 0.3;
        
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightIncrease => CatWeightIncrease;

        public override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>() {typeof(Vegetable), typeof(Meat) };

        public override string ProduceSound() => "Meow";
    }
}
