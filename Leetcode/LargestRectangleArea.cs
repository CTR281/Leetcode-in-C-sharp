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

            public int LargestRectangleArea2(int[] heights)
            {
                int n = heights.Length;
                int[] left = new int[n];
                int[] right = new int[n];
                Array.Fill(left, -1);
                Array.Fill(right, n);

                Stack<int> ms = new();

                for (int k = 0; k < n; k++)
                {
                    while (ms.Count > 0 && heights[ms.Peek()] >= heights[k])
                    {
                        ms.Pop();                       
                    }
                    if (ms.Count > 0) left[k] = ms.Peek();
                    ms.Push(k);
                }
                ms.Clear();

                for (int k = n - 1; k >= 0; k--)
                {
                    while (ms.Count > 0 && heights[ms.Peek()] >= heights[k])
                    {
                        ms.Pop();
                    }
                    if (ms.Count > 0) right[k] = ms.Peek();
                    ms.Push(k);
                }

                int res = 0;
                for (int k = 0; k < n; k++)
                {
                    res = Math.Max(res, (right[k] - left[k] - 1) * heights[k]);
                }
                return res;
            }
        }
    }
}
