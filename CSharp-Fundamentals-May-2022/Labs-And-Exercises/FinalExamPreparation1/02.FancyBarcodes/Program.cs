using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfBarcodes = int.Parse(Console.ReadLine());

            string pattern = @"@#+(?<product>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";

            for (int i = 0; i < countOfBarcodes; i++)
            {
                string barcode = Console.ReadLine();

                Match match = Regex.Match(barcode, pattern);

                if (match.Success)
                {
                    string product = match.Groups["product"].Value;
                    string productGroup = new string(product.Where(char.IsDigit).ToArray());
                    
                    if (string.IsNullOrEmpty(productGroup))
                    {
                        productGroup = "00";
                    }

                    Console.WriteLine($"Product group: {productGroup}");

                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
