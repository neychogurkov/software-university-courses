using System;

namespace _01.DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    {
                        int number = int.Parse(Console.ReadLine());
                        Console.WriteLine(ModifyInput(number));
                        break;
                    }
                case "real":
                    {
                        double number = double.Parse(Console.ReadLine());
                        Console.WriteLine($"{ModifyInput(number):f2}");
                        break;
                    }
                case "string":
                    {
                        string text = Console.ReadLine();
                        Console.WriteLine(ModifyInput(text));
                        break;
                    }
            }
        }

        static int ModifyInput(int number)
        {
            return number * 2;
        }

        static double ModifyInput(double number)
        {
            return number * 1.5;
        }

        static string ModifyInput(string text)
        {
            return $"${text}$";
        }
    }
}
