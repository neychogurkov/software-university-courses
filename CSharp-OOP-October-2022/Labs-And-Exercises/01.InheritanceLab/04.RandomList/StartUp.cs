using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList { "1", "2", "3", "4", "5" };
            Console.WriteLine(string.Join(' ', list));
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(string.Join(' ', list));
        }
    }
}
