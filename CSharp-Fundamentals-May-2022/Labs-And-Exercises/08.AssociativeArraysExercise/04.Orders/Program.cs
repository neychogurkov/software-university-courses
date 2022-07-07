using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace _04.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> productsPrices = new Dictionary<string, double>();
            Dictionary<string, int> productsQuantities = new Dictionary<string, int>();

            while (true)
            {
                string[] productInfo = Console.ReadLine().Split();

                if (productInfo[0] == "buy")
                {
                    break;
                }

                string productName = productInfo[0];
                double productPrice = double.Parse(productInfo[1]);
                int productQuantity = int.Parse(productInfo[2]);

                if (!productsPrices.ContainsKey(productName))
                {
                    productsPrices[productName] = 0;
                    productsQuantities[productName] = 0;
                }

                productsPrices[productName] = productPrice;
                productsQuantities[productName] += productQuantity;
            }

            foreach (var product in productsPrices)
            {
                Console.WriteLine($"{product.Key} -> {product.Value * productsQuantities[product.Key]:f2}");
            }
        }
    }
}
