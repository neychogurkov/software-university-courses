using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;

        public Stack()
        {
            this.items = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Resize()
        {
            T[] newItems = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                newItems[i] = this.items[i];
            }

            items = newItems;
        }

        public void Push(T value)
        {
            this.items[this.Count++] = value;

            if (this.items.Length == this.Count)
            {
                this.Resize();
            }
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T item = this.items[this.Count];
            this.items[this.Count--] = default(T);
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
