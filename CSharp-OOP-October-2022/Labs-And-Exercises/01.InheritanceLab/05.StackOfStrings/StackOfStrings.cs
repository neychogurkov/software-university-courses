using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => this.Count == 0;

        public Stack<string> AddRange(IEnumerable<string> strings)
        {
            foreach (var item in strings)
            {
                Push(item);
            }

            return this;
        }
    }
}
