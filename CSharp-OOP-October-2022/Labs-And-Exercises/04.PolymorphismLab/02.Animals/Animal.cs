﻿namespace Animals
{
    using System;

    public abstract class Animal
    {
        private string name;
        private string favouriteFood;

        protected Animal(string name, string favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.name} and my fovourite food is {this.favouriteFood}" + Environment.NewLine;
        }
    }
}