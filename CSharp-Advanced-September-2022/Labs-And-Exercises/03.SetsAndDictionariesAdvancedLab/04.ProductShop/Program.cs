using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> productsPricesByShops = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] productInfo = Console.ReadLine().Split(", ");

                if (productInfo[0] == "Revision")
                {
                    break;
                }

                AddProduct(productsPricesByShops, productInfo);
            }

            PrintProducts(productsPricesByShops);
        }

        static void AddProduct(Dictionary<string, Dictionary<string, double>> productsPricesByShops, string[] productInfo)
        {
            string shop = productInfo[0];
            string product = productInfo[1];
            double price = double.Parse(productInfo[2]);

            if (!productsPricesByShops.ContainsKey(shop))
            {
                productsPricesByShops[shop] = new Dictionary<string, double>();
            }

            productsPricesByShops[shop][product] = price;
        }

        static void PrintProducts(Dictionary<string, Dictionary<string, double>> productsPricesByShops)
        {
            foreach (var (shop, productsPrices) in productsPricesByShops.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{shop}->");

                foreach (var (product, price) in productsPrices)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
