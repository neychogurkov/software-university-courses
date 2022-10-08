using System;

namespace ImplementingStack
{
    public class CustomStack<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;

        public CustomStack()
        {
            this.items = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Resize()
        {
            T[] internalArray = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                internalArray[i] = this.items[i];
            }

            this.items = internalArray;
        }

        public void Push(T element)
        {
            if (this.items.Length == this.Count)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            T item = this.items[this.Count - 1];
            this.items[this.Count - 1] = default(T);
            this.Count--;

            return item;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            return this.items[this.Count - 1];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }
    }
}
