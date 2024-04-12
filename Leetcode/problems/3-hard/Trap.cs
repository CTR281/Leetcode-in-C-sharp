using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._3_hard
{
    internal class Trap // https://leetcode.com/problems/trapping-rain-water/
    {
        public class Solution
        {
            public int Trap(int[] height)
            {
                int n = height.Length;
                int[] right = new int[n];
                int[] left = new int[n];
                int max;

                max = 0;
                for (int k = 0; k < n - 1; k++)
                {
                    if (height[max] < height[k]) max = k;
                    left[k + 1] = max;
                }

                max = n - 1;
                left[n - 1] = max;
                for (int k = n - 1; k > 0; k--)
                {
                    if (height[max] < height[k]) max = k;
                    right[k - 1] = max;
                }

                int result = 0;
                for (int k = 0; k < n; k++)
                {
                    result += Math.Max(0, Math.Min(height[left[k]], height[right[k]]) - height[k]);
                }

                return result;
            }
        }
    }
}
