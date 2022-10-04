using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            doublyLinkedList.AddFirst(3);
            doublyLinkedList.AddFirst(2);
            doublyLinkedList.AddLast(5);
            doublyLinkedList.AddFirst(4);
            doublyLinkedList.AddLast(6);
            doublyLinkedList.AddFirst(7);

            // 7 4 2 3 5 6
            Console.WriteLine(doublyLinkedList.RemoveLast()); // 6
            Console.WriteLine(doublyLinkedList.RemoveLast()); // 5
            Console.WriteLine(doublyLinkedList.RemoveFirst()); // 7
            Console.WriteLine(doublyLinkedList.RemoveLast()); // 3
            Console.WriteLine(doublyLinkedList.RemoveFirst()); // 4
            Console.WriteLine(doublyLinkedList.RemoveLast()); // 2

            doublyLinkedList.AddFirst(12);
            doublyLinkedList.AddLast(2);
            doublyLinkedList.AddLast(5);
            doublyLinkedList.AddFirst(8);
            doublyLinkedList.AddLast(1);
            doublyLinkedList.AddFirst(3);

            // 3 8 12 2 5 1 

            doublyLinkedList.ForEach(x => Console.WriteLine(x));

            doublyLinkedList.RemoveLast();
            doublyLinkedList.RemoveFirst();

            Console.WriteLine(string.Join(' ', doublyLinkedList.ToArray()));
        }
    }
}
