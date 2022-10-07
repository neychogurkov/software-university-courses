using System;
using System.Linq;

namespace GenericArrayCreator
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] array = new T[length];

            array = array.Select(x => item).ToArray();

            return array;
        }
    }
}
