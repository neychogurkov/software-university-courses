using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class CustomTuple<T1, T2>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }
    }
}
