using System;

namespace _01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            while (true)
            {
                string[] command = Console.ReadLine().Split(">>>");

                if (command[0] == "Generate")
                {
                    break;
                }

                switch (command[0])
                {
                    case "Contains":
                        string substring = command[1];

                        Console.WriteLine(activationKey.Contains(substring)
                            ? $"{activationKey} contains {substring}"
                            : "Substring not found!");
                        break;
                    case "Flip":
                        activationKey = FlipActivationKey(command, activationKey);
                        Console.WriteLine(activationKey);
                        break;
                    case "Slice":
                        activationKey = SliceActivationKey(command, activationKey);
                        Console.WriteLine(activationKey);
                        break;

                }
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }

        static string FlipActivationKey(string[] command, string activationKey)
        {
            string casing = command[1];
            int startIndex = int.Parse(command[2]);
            int endIndex = int.Parse(command[3]);

            if (casing == "Upper")
            {
                activationKey = activationKey.Substring(0, startIndex) +
                                activationKey.Substring(startIndex, endIndex - startIndex).ToUpper() +
                                activationKey.Substring(endIndex);
            }
            else if (casing == "Lower")
            {
                activationKey = activationKey.Substring(0, startIndex) +
                                activationKey.Substring(startIndex, endIndex - startIndex).ToLower() +
                                activationKey.Substring(endIndex);
            }

            return activationKey;
        }

        static string SliceActivationKey(string[] command, string activationKey)
        {
            int startIndex = int.Parse(command[1]);
            int endIndex = int.Parse(command[2]);

            activationKey = activationKey.Substring(0, startIndex) + activationKey.Substring(endIndex);

            return activationKey;
        }
    }
}
