using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] initialBullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] initialLocks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int moneyEarned = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(initialBullets);
            Queue<int> locks = new Queue<int>(initialLocks);

            int bulletsShot = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                ShootBulletsAtLocks(gunBarrelSize, bullets, locks, ref bulletsShot);
            }

            if (locks.Count == 0)
            {
                moneyEarned -= (initialBullets.Length - bullets.Count) * bulletPrice;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }

        static void ShootBulletsAtLocks(int gunBarrelSize, Stack<int> bullets, Queue<int> locks,ref int bulletsShot)
        {
            bulletsShot++;

            if (bullets.Pop() <= locks.Peek())
            {
                Console.WriteLine("Bang!");
                locks.Dequeue();
            }
            else
            {
                Console.WriteLine("Ping!");
            }

            if (bulletsShot == gunBarrelSize && bullets.Count > 0)
            {
                bulletsShot = 0;
                Console.WriteLine("Reloading!");
            }
        }
    }
}
