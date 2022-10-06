using System;

namespace ImplementingStack
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items;

        public CustomStack()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Resize()
        {
            int[] internalArray = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                internalArray[i] = this.items[i];
            }

            this.items = internalArray;
        }

        public void Push(int element)
        {
            if (this.items.Length == this.Count)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public int Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            int item = this.items[this.Count - 1];
            this.items[this.Count - 1] = default(int);
            this.Count--;

            return item;
        }

        public int Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            return this.items[this.Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }
    }
}
