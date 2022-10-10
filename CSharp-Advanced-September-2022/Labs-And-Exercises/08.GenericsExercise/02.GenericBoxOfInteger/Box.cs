using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        public T Value { get; set; }

        public override string ToString()
        {
            return $"{typeof(T)}: {this.Value}";
        }
    }
}
