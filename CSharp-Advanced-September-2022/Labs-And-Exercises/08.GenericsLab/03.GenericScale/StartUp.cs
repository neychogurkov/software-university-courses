using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<string> equalityScale = new EqualityScale<string>(Console.ReadLine(), Console.ReadLine());
            Console.WriteLine(equalityScale.AreEqual());
        }
    }
}
