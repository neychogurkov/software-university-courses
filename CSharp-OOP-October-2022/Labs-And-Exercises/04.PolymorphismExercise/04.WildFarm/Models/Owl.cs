using System;
using System.Collections.Generic;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        private const double OwlWeightIncrease = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightIncrease => OwlWeightIncrease;

        public override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>() { typeof(Meat) };

        public override string ProduceSound() => "Hoot Hoot";
    }
}
