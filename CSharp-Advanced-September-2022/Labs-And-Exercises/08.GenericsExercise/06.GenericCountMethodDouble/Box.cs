﻿using System;

namespace GenericCountMethodDouble
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
