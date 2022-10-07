using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public ListNode<T> Head { get; set; }
        public ListNode<T> Tail { get; set; }
        public int Count { get; set; }

        public void AddFirst(T element)
        {
            this.Count++;
            ListNode<T> node = new ListNode<T>(element);

            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
            }
            else
            {
                ListNode<T> oldHead = this.Head;
                this.Head.PreviousNode = node;
                this.Head = node;
                this.Head.NextNode = oldHead;
            }
        }

        public void AddLast(T element)
        {
            this.Count++;
            ListNode<T> node = new ListNode<T>(element);

            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
            }
            else
            {
                ListNode<T> oldTail = this.Tail;
                this.Tail.NextNode = node;
                this.Tail = node;
                this.Tail.PreviousNode = oldTail;
            }
        }

        public T RemoveFirst()
        {
            if (this.Head == null)
            {
                throw new NullReferenceException();
            }

            T first = this.Head.Value;

            if (this.Head == this.Tail)
            {
                this.Head = null;
                this.Tail = null;
            }
            else
            {
                this.Head = this.Head.NextNode;
                this.Head.PreviousNode = null;
            }

            this.Count--;
            return first;
        }

        public T RemoveLast()
        {
            if (this.Tail == null)
            {
                throw new NullReferenceException();
            }

            T last = this.Tail.Value;

            if (this.Tail == this.Head)
            {
                this.Head = null;
                this.Tail = null;
            }
            else
            {
                this.Tail = this.Tail.PreviousNode;
                this.Tail.NextNode = null;
            }

            this.Count--;
            return last;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> node = this.Head;

            while (node != null)
            {
                action(node.Value);
                node = node.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            ListNode<T> node = this.Head;
            int index = 0;

            while (node != null)
            {
                array[index++] = node.Value;
                node = node.NextNode;
            }

            return array;
        }
    }
}
