using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class LargestRectangleArea // https://leetcode.com/problems/largest-rectangle-in-histogram/
    {
        public class Solution
        {
            public int LargestRectangleArea(int[] heights)
            {
                List<int> A = heights.ToList();
                A.Add(0);
                Stack<int> stack = new();
                int res = 0;
                for (int k = 0; k < A.Count; k++)
                {
                    while (stack.Count > 0 && A[stack.Peek()] > A[k])
                    {
                        int height = A[stack.Pop()];
                        int left = stack.Count > 0 ? stack.Peek() : -1;
                        res = Math.Max(res, (k - left - 1) * height);
                    }
                    stack.Push(k);
                }
                return res;
            }
        }
    }
}
