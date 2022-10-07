using System;

namespace ImplementingList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomList<string> list = new CustomList<string>();
            list.Add("abc");
            list.Add("def");
            list.Add("ghi");
            list.RemoveAt(1);
            list.Add("dafd");
            list.Add("feaftew");
            list.Add("4eqw");
            list.AddRange(new string[] { "daf", "dsa", "fe", "123", "2314", "dghj", "4yt" });
            list.Insert(0, "xyz");
            Console.WriteLine(string.Join(' ', list));


            //CustomList<int> list = new CustomList<int>();

            //list.Add(3);
            //list.Add(5);
            //list.Add(6);

            //Console.WriteLine(list[0]);

            //(list[0], list[2]) = (list[2], list[0]);
            //Console.WriteLine(list[0]);

            //list.Add(7);
            //list.Add(2);
            //list.RemoveAt(2);
            //list.Insert(0, 3);
            //Console.WriteLine(list.Contains(7));
            //Console.WriteLine(list.Contains(15));
            //list.Swap(1, 4);
            //Console.WriteLine(list);

            //int[] array = list.ToArray();
            //Console.WriteLine(String.Join(Environment.NewLine, array));

            //list.Add(1);
            //Console.WriteLine(list.Find(x => x % 2 == 0));
            //list.Add(5);
            //list.Add(2);
            //Console.WriteLine(list.Find(x => x % 2 == 0));
            //list.Insert(0, 4);
            //Console.WriteLine(list.Find(x => x % 2 == 0));
            //Console.WriteLine(list);

            //list.Reverse();
            //Console.WriteLine(list);

            //list.AddRange(new int[] { 3, 54, 23, 21, 3, 213, 21, 34 });
            //Console.WriteLine(list);

            //list.Remove(54);
            //Console.WriteLine(list);

            //list.Remove(21);
            //Console.WriteLine(list);

            //list.FindAll(x => x % 2 != 0).ForEach(x => Console.Write(x + " "));
            //Console.WriteLine();

            //list.RemoveAll(x => x % 2 != 0);
            //Console.WriteLine(list);
        }
    }
}
