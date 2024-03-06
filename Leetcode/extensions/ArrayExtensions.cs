using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.extensions
{
    internal static class ArrayExtensions
    {
        public static void Deconstruct<T>(this T[] array, out T t0, out T t1)
        {
            if (array.Length != 2) throw new ArgumentException("Cannot deconstruct array.");
            t0 = array[0];
            t1 = array[1];
        }
    }
}
