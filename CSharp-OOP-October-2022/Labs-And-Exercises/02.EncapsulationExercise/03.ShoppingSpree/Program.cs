using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();

                string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in peopleInput)
                {
                    string[] personInfo = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);

                    Person person = new Person(name, money);
                    people.Add(person);
                }

                foreach (var item in productsInput)
                {
                    string[] productInfo = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = productInfo[0];
                    decimal price = decimal.Parse(productInfo[1]);

                    Product product = new Product(name, price);
                    products.Add(product);
                }

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    string personName = command.Split()[0];
                    string productName = command.Split()[1];

                    Person person = people.Find(p => p.Name == personName);
                    Product product = products.Find(p => p.Name == productName);
                    Console.WriteLine(person.BuyProduct(product));
                }

                foreach (var person in people)
                {
                    Console.WriteLine($"{person.Name} - " + (person.Products.Count == 0
                            ? "Nothing bought"
                            : string.Join(", ", person.Products.Select(p => p.Name))));
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
