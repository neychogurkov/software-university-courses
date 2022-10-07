using System;
using System.Text;

namespace ImplementingList
{
    public class CustomList<T>
    {
        private const int InitialCapacity = 2;
        private T[] items;

        public CustomList()
        {
            this.items = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public T this[int index]
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
            T[] internalArray = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                internalArray[i] = this.items[i];
            }

            this.items = internalArray;
        }

        public void Shrink()
        {
            T[] internalArray = new T[this.items.Length / 2];

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
                this.items[i + 1] = default(T);
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        public void Add(T element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public void AddRange(T[] range)
        {
            foreach (var item in range)
            {
                this.Add(item);
            }
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            T item = this.items[index];
            this.items[index] = default(T);
            this.ShiftLeft(index);

            this.Count--;
            if (this.Count * 4 <= this.items.Length)
            {
                this.Shrink();
            }

            return item;
        }

        public void Remove(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(element))
                {
                    this.items[i] = default(T);
                    this.ShiftLeft(i);
                    this.Count--;
                    return;
                }
            }
        }

        public void RemoveAll(Predicate<T> predicate)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (predicate(this.items[i]))
                {
                    this.items[i] = default(T);
                    this.ShiftLeft(i);
                    this.Count--;
                    i--;
                }
            }
        }

        public void Insert(int index, T element)
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

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(element))
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

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.items[i];
            }

            return array;
        }

        public T Find(Predicate<T> predicate)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (predicate(this.items[i]))
                {
                    return this.items[i];
                }
            }

            return default(T);
        }

        public CustomList<T> FindAll(Predicate<T> predicate)
        {
            CustomList<T> list = new CustomList<T>();

            for (int i = 0; i < this.Count; i++)
            {
                if (predicate(this.items[i]))
                {
                    list.Add(this.items[i]);
                }
            }

            return list;
        }

        public void ForEach(Action<T> action)
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
