using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class HeightChecker // https://leetcode.com/problems/height-checker/
    {
        public class Solution
        {
            public int HeightChecker(int[] heights)
            {
                int[] sortedHeights = (int[]) heights.Clone();
                Array.Sort(sortedHeights);

                // Using Linq
                // heights.Zip(sortedHeights).Where(x => x.Item1 != x.Item2).Count();

                // Using for loop
                int result = 0;
                for (int k = 0; k < sortedHeights.Length; k++)
                {
                    if (heights[k] != sortedHeights[k]) result++;
                }
                return result;
            }
        }
    }
}
