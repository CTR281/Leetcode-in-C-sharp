using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class RandomizedSet // https://leetcode.com/problems/insert-delete-getrandom-o1
    {
        public class Solution
        {
            private Dictionary<int, int> values;
            private List<int> indexedValues;
            static private Random rnd = new();

            public Solution()
            {
                values = new();
                indexedValues = new();
            }

            public bool Insert(int val)
            {
                if (values.ContainsKey(val)) return false;
                values.Add(val, indexedValues.Count);
                indexedValues.Add(val);
                return true;
            }

            public bool Remove(int val)
            {
                if (!values.ContainsKey(val)) return false;
                indexedValues[values[val]] = indexedValues[indexedValues.Count - 1];
                values[indexedValues[values[val]]] = values[val];
                indexedValues.RemoveAt(indexedValues.Count - 1);
                values.Remove(val);
                return true;
            }

            public int GetRandom()
            {
                return indexedValues[rnd.Next(0, indexedValues.Count)];
            }
        }

        /**
         * Your RandomizedSet object will be instantiated and called as such:
         * RandomizedSet obj = new RandomizedSet();
         * bool param_1 = obj.Insert(val);
         * bool param_2 = obj.Remove(val);
         * int param_3 = obj.GetRandom();
         */
    }
}
