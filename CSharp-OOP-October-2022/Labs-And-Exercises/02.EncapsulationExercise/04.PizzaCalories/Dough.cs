using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    internal class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;
        private double caloriesPerGram;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
            this.caloriesPerGram = 2;
        }

        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }
        public int Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }
        public double CaloriesPerGram => this.CalculateCaloriesPerGram(); 

        private double CalculateCaloriesPerGram()
        {
            double modifier = 1;

            if (this.flourType.ToLower() == "white")
            {
                modifier *= 1.5;
            }

            if (this.bakingTechnique.ToLower() == "crispy")
            {
                modifier *= 0.9;
            }
            else if (this.bakingTechnique.ToLower() == "chewy")
            {
                modifier *= 1.1;
            }

            return this.caloriesPerGram * modifier;
        }
    }
}
