using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] inputPeople = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] inputProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in inputPeople)
            {
                string[] personInfo = item.Split('=');
                Person person = new Person(personInfo[0], double.Parse(personInfo[1]));
                people.Add(person);
            }

            foreach (var item in inputProducts)
            {
                string[] productInfo = item.Split('=');
                Product product = new Product(productInfo[0], double.Parse(productInfo[1]));
                products.Add(product);
            }


            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "END")
                {
                    break;
                }

                string personName = command[0];
                string productName = command[1];

                Person person = people.Find(p => p.Name == personName);
                Product product = products.Find(p => p.Name == productName);

                if (person.Money - product.Price >= 0)
                {
                    person.BuyProduct(product);
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }

            foreach (var person in people)
            {
                Console.Write($"{person.Name} - ");
                if (person.Bag.Count > 0)
                {
                    List<string> productsNames = new List<string>();
                    foreach (var product in person.Bag)
                    {
                        productsNames.Add(product.Name);
                    }

                    Console.WriteLine(string.Join(", ", productsNames));
                }
                else
                {
                    Console.WriteLine("Nothing bought");
                }
            }

        }
    }

    class Person
    {
        public string Name { get; set; }
        public double Money { get; set; }
        public List<Product> Bag { get; set; }

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            Bag = new List<Product>();
        }

        public void BuyProduct(Product product)
        {
            Bag.Add(product);
            Money -= product.Price;
            Console.WriteLine($"{Name} bought {product.Name}");
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
