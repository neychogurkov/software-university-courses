using System;
using System.Text;

namespace ImplementingList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                items[index] = value;
            }
        }

        private void Resize()
        {
            int[] internalArray = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                internalArray[i] = this.items[i];
            }

            this.items = internalArray;
        }

        public void Shrink()
        {
            int[] internalArray = new int[this.items.Length / 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                internalArray[i] = this.items[i];
            }

            this.items = internalArray;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
                this.items[i + 1] = 0;
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        public void Add(int element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public void AddRange(int[] range)
        {
            foreach (var item in range)
            {
                this.Add(item);
            }
        }

        public int RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int item = this.items[index];
            this.items[index] = default(int);
            this.ShiftLeft(index);

            this.Count--;
            if (this.Count * 4 <= this.items.Length)
            {
                this.Shrink();
            }

            return item;
        }

        public void Remove(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    this.items[i] = default(int);
                    this.ShiftLeft(i);
                    this.Count--;
                    return;
                }
            }
        }

        public void RemoveAll(Predicate<int> predicate)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (predicate(this.items[i]))
                {
                    this.items[i] = default(int);
                    this.ShiftLeft(i);
                    this.Count--;
                    i--;
                }
            }
        }

        public void Insert(int index, int element)
        {
            if (index < 0 || index >= this.Count && this.Count > 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftRight(index);
            this.items[index] = element;
            this.Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= this.Count || secondIndex < 0 || secondIndex >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            (this.items[firstIndex], this.items[secondIndex]) = (this.items[secondIndex], this.items[firstIndex]);
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.items[i];
            }

            return array;
        }

        public int Find(Predicate<int> predicate)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (predicate(this.items[i]))
                {
                    return this.items[i];
                }
            }

            return 0;
        }

        public CustomList FindAll(Predicate<int> predicate)
        {
            CustomList list = new CustomList();

            for (int i = 0; i < this.Count; i++)
            {
                if (predicate(this.items[i]))
                {
                    list.Add(this.items[i]);
                }
            }

            return list;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < this.Count / 2; i++)
            {
                (this.items[i], this.items[this.Count - 1 - i]) = (this.items[this.Count - 1 - i], this.items[i]);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(this.items[i] + " ");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
