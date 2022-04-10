using System;

namespace _04.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double income = 0;

            while (command != "Movie time!")
            {
                int people = int.Parse(command);
                if (people > capacity)
                {
                    Console.WriteLine("The cinema is full.");
                    Console.WriteLine($"Cinema income - {income} lv.");
                    return;
                }

                capacity -= people;
                double price = people * 5;
                if (people % 3 == 0)
                {
                    price -= 5;
                }
                income += price;

                command = Console.ReadLine();
            }
            Console.WriteLine($"There are {capacity} seats left in the cinema.");
            Console.WriteLine($"Cinema income - {income} lv.");
        }
    }
}
