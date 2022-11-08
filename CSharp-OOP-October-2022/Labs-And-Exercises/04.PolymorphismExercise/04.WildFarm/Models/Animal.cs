namespace WildFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract double WeightIncrease { get; }

        public abstract IReadOnlyCollection<Type> PreferredFood { get; }

        public abstract string ProduceSound();

        public void Eat(IFood food)
        {
            if (!this.PreferredFood.Any(f => f.Name == food.GetType().Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += this.WeightIncrease * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
            => $"{this.GetType().Name} [{this.Name}, ";
    }
}
