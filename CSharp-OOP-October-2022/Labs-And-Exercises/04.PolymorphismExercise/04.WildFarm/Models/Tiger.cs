using System;
using System.Collections.Generic;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        private const double TigerWeightIncrease = 1;
        
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightIncrease => TigerWeightIncrease;

        public override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>() { typeof(Meat) };

        public override string ProduceSound() => "ROAR!!!";
    }
}
