using System;

namespace _02.MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split('|');
            int health = 100;
            int bitcoins = 0;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] currentRoom = rooms[i].Split();
                string command = currentRoom[0];
                int number = int.Parse(currentRoom[1]);

                switch (command)
                {
                    case "potion":
                        if (health + number > 100)
                        {
                            Console.WriteLine($"You healed for {100 - health} hp.");
                            health = 100;
                        }
                        else
                        {
                            health += number;
                            Console.WriteLine($"You healed for {number} hp.");
                        }

                        Console.WriteLine($"Current health: {health} hp.");
                        break;
                    case "chest":
                        Console.WriteLine($"You found {number} bitcoins.");
                        bitcoins += number;
                        break;
                    default:
                        string monster = command;
                        int monsterAttack = number;
                        health -= monsterAttack;
                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {monster}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {monster}.");
                            Console.WriteLine($"Best room: {i + 1}");
                            return;
                        }
                        break;
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
