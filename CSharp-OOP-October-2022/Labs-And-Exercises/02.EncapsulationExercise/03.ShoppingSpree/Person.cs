using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    internal class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }
        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }
        public List<Product> Products { get; set; }

        public string BuyProduct(Product product)
        {
            if (product.Price > this.Money)
            {
                return $"{this.Name} can't afford {product.Name}";
            }
            else
            {
                this.Products.Add(product);
                this.Money -= product.Price;
                return $"{this.Name} bought {product.Name}";
            }
        }
    }
}
