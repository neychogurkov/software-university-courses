using System;

namespace ImplementingQueue
{
    public class CustomQueue
    {
        private const int InitialCapacity = 4;
        private const int FirstElementIndex = 0;
        private int[] items;

        public CustomQueue()
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

        private void ShiftLeft()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
                this.items[i + 1] = default(int);
            }
        }

        public void Enqueue(int element)
        {
            if (this.items.Length == this.Count)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public int Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            int item = this.items[FirstElementIndex];
            this.ShiftLeft();
            this.Count--;

            return item;
        }

        public int Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            return this.items[FirstElementIndex];
        }

        public void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.items[i] = default(int);
            }

            this.Count = 0;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
    }
}
