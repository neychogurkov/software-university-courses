using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    internal class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.toppings = new List<Topping>();
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }
        public Dough Dough { get; set; }
        public int ToppingsCount => this.toppings.Count;
        public double TotalCalories => this.Dough.CaloriesPerGram * this.Dough.Weight + this.toppings.Sum(t => t.CaloriesPerGram * t.Weight);

        public void AddTopping(Topping topping)
        {
            if (this.ToppingsCount == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }
    }
}
