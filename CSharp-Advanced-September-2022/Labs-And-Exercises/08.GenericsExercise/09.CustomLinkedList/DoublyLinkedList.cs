using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;
        public int Count { get; set; }

        public void AddFirst(T element)
        {
            this.Count++;
            ListNode<T> node = new ListNode<T>(element);

            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                ListNode<T> oldHead = this.head;
                this.head.PreviousNode = node;
                this.head = node;
                this.head.NextNode = oldHead;
            }
        }

        public void AddLast(T element)
        {
            this.Count++;
            ListNode<T> node = new ListNode<T>(element);

            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                ListNode<T> oldTail = this.tail;
                this.tail.NextNode = node;
                this.tail = node;
                this.tail.PreviousNode = oldTail;
            }
        }

        public T RemoveFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T first = this.head.Value;

            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = this.head.NextNode;
                this.head.PreviousNode = null;
            }

            this.Count--;
            return first;
        }

        public T RemoveLast()
        {
            if (this.tail == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T last = this.tail.Value;

            if (this.tail == this.head)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.tail = this.tail.PreviousNode;
                this.tail.NextNode = null;
            }

            this.Count--;
            return last;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> node = this.head;

            while (node != null)
            {
                action(node.Value);
                node = node.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            ListNode<T> node = this.head;
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
