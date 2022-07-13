using System;
using System.Linq;
using System.Text;

namespace _03.TreasureFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string text = Console.ReadLine();

            while (text != "find")
            {
                StringBuilder sb = new StringBuilder(text);
                int keyIndex = 0;

                for (int i = 0; i < sb.Length; i++)
                {
                    sb[i] -= (char)keys[keyIndex];


                    if (keyIndex == keys.Length - 1)
                    {
                        keyIndex = 0;
                    }
                    else
                    {
                        keyIndex++;
                    }
                }

                string decryptedMessage = sb.ToString();
                string treasureType = decryptedMessage.Substring(decryptedMessage.IndexOf('&') + 1, decryptedMessage.LastIndexOf('&') - decryptedMessage.IndexOf('&') - 1);
                string treasureCoordinates = decryptedMessage.Substring(decryptedMessage.IndexOf('<') + 1, decryptedMessage.IndexOf('>') - decryptedMessage.IndexOf('<') - 1);

                Console.WriteLine($"Found {treasureType} at {treasureCoordinates}");

                text = Console.ReadLine();
            }

        }
    }
}
