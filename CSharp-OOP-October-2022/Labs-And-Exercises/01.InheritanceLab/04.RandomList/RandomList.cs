using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random r = new Random();
            int index = r.Next(this.Count);
            string removedElement = this[index];
            this.RemoveAt(index);
                
            return removedElement;
        }
    }
}
