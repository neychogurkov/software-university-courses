using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        public ListNode Head { get; set; }
        public ListNode Tail { get; set; }
        public int Count { get; set; }

        public void AddFirst(int element)
        {
            this.Count++;
            ListNode node = new ListNode(element);

            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
            }
            else
            {
                ListNode oldHead = this.Head;
                this.Head.PreviousNode = node;
                this.Head = node;
                this.Head.NextNode = oldHead;
            }
        }

        public void AddLast(int element)
        {
            this.Count++;
            ListNode node = new ListNode(element);

            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
            }
            else
            {
                ListNode oldTail = this.Tail;
                this.Tail.NextNode = node;
                this.Tail = node;
                this.Tail.PreviousNode = oldTail;
            }
        }

        public int RemoveFirst()
        {
            if (this.Head == null)
            {
                throw new NullReferenceException();
            }

            int first = this.Head.Value;

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

        public int RemoveLast()
        {
            if (this.Tail == null)
            {
                throw new NullReferenceException();
            }

            int last = this.Tail.Value;

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

        public void ForEach(Action<int> action)
        {
            ListNode node = this.Head;

            while (node != null)
            {
                action(node.Value);
                node = node.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];

            ListNode node = this.Head;
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
