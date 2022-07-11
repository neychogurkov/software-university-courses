using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Box> boxes = new List<Box>();

            while (command != "end")
            {
                string[] itemInfo = command.Split();
                string serialNumber = itemInfo[0];
                string itemName = itemInfo[1];
                int itemQuantity = int.Parse(itemInfo[2]);
                double itemPrice = double.Parse(itemInfo[3]);

                Item item = new Item(itemName, itemPrice);
                Box box = new Box(serialNumber, item, itemQuantity);
                boxes.Add(box);

                command = Console.ReadLine();
            }

            foreach (var box in boxes.OrderByDescending(b => b.PriceForABox))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForABox:f2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForABox { get; set; }

        public Box(string serialNumber, Item item, int itemQuantity)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
            PriceForABox = Item.Price * ItemQuantity;
        }
    }
}
