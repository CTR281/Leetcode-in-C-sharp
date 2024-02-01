using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class RandomizedCollection
    {
        public class Solution
        {
            private Dictionary<int, HashSet<int>> values;
            private List<int> indexedValues;
            static private Random rnd = new();

            public Solution()
            {
                values = new();
                indexedValues = new();
            }

            public bool Insert(int val)
            {
                if (!values.ContainsKey(val))
                {
                    values.Add(val, new HashSet<int>());
                }
                values[val].Add(indexedValues.Count);
                indexedValues.Add(val);
                return values[val].Count == 1;
            }

            public bool Remove(int val)
            {
                if (!values.ContainsKey(val) || values[val].Count == 0) return false;
                int idxToRemove = values[val].First();
                values[val].Remove(idxToRemove);
                if (idxToRemove != indexedValues.Count - 1)
                {
                    indexedValues[idxToRemove] = indexedValues.Last();
                    values[indexedValues.Last()].Remove(indexedValues.Count - 1);
                    values[indexedValues.Last()].Add(idxToRemove);
                }
                indexedValues.RemoveAt(indexedValues.Count - 1);
                if (values[val].Count == 0) values.Remove(val);
                return true;
            }

            public int GetRandom()
            {
                return indexedValues[rnd.Next(0, indexedValues.Count)];
            }
        }
        /**
         * Your RandomizedCollection object will be instantiated and called as such:
         * RandomizedCollection obj = new RandomizedCollection();
         * bool param_1 = obj.Insert(val);
         * bool param_2 = obj.Remove(val);
         * int param_3 = obj.GetRandom();
        */
    }
}
