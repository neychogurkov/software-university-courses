using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();

            while (true)
            {
                string[] vloggerInfo = Console.ReadLine().Split();

                if (vloggerInfo[0] == "Statistics")
                {
                    break;
                }

                if (vloggerInfo[1] == "joined")
                {
                    AddVlogger(vloggers, vloggerInfo);
                }
                else if (vloggerInfo[1] == "followed")
                {
                    AddFollower(vloggers, vloggerInfo);
                }
            }

            PrintVloggers(vloggers);
        }

        static void AddVlogger(Dictionary<string, Vlogger> vloggers, string[] vloggerInfo)
        {
            string vloggerName = vloggerInfo[0];

            if (!vloggers.ContainsKey(vloggerName))
            {
                vloggers[vloggerName] = new Vlogger();
            }
        }

        static void AddFollower(Dictionary<string, Vlogger> vloggers, string[] vloggerInfo)
        {
            string follower = vloggerInfo[0];
            string vloggerName = vloggerInfo[2];

            if (vloggers.ContainsKey(follower) && vloggers.ContainsKey(vloggerName) && !vloggers[vloggerName].Followers.Contains(follower) && vloggerName != follower)
            {
                vloggers[vloggerName].Followers.Add(follower);
                vloggers[follower].Followings++;
            }
        }

        static void PrintVloggers(Dictionary<string, Vlogger> vloggers)
        {
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int index = 1;

            foreach (var (name, vlogger) in vloggers.OrderByDescending(v => v.Value.Followers.Count).ThenBy(v => v.Value.Followings))
            {
                if (index == 1)
                {
                    Console.WriteLine($"1. {name} : {vlogger.Followers.Count} followers, {vlogger.Followings} following");

                    foreach (var follower in vlogger.Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                else
                {
                    Console.WriteLine($"{index}. {name} : {vlogger.Followers.Count} followers, {vlogger.Followings} following");
                }

                index++;
            }
        }
    }

    class Vlogger
    {
        public SortedSet<string> Followers { get; set; }
        public int Followings { get; set; }

        public Vlogger()
        {
            Followers = new SortedSet<string>();
        }
    }
}
