using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Ingredients = new List<Ingredient>();
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
        }

        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => this.Ingredients.Sum(i => i.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (!this.Ingredients.Any(i => i.Name == ingredient.Name)
                && this.CurrentAlcoholLevel + ingredient.Alcohol <= this.MaxAlcoholLevel
                && this.Ingredients.Count < this.Capacity)
            {
                this.Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name) => this.Ingredients.Remove(FindIngredient(name));

        public Ingredient FindIngredient(string name) => this.Ingredients.Find(i => i.Name == name);

        public Ingredient GetMostAlcoholicIngredient() => this.Ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (var ingredient in this.Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
