using System;

namespace ImplementingStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            stack.Push(3);
            stack.Push(2);
            stack.Push(7);
            stack.Push(9);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());

            stack.Push(1); 
            stack.Push(6);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Count);

            stack.ForEach(x => Console.WriteLine(x));
        }
    }
}
