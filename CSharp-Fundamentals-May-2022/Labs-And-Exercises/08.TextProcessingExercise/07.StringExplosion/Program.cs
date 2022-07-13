using System;

namespace _07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int explosionStrength = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '>')
                {
                    explosionStrength += int.Parse(text[i + 1].ToString());
                    continue;
                }

                if (explosionStrength > 0)
                {
                    text = text.Remove(i, 1);
                    explosionStrength--;
                    i--;
                }
            }

            Console.WriteLine(text);
        }
    }
}
