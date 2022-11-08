using System;
using System.Collections.Generic;

namespace WildFarm.Models
{
    public class Hen : Bird
    {
        private const double HenWeightIncrease = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightIncrease => HenWeightIncrease;

        public override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) ,typeof(Meat), typeof(Seeds) };

        public override string ProduceSound() => "Cluck";
    }
}
