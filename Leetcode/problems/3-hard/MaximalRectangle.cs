using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._3_hard
{
    internal class MaximalRectangle // https://leetcode.com/problems/maximal-rectangle/
    {
        public class Solution
        {
            public int MaximalRectangle(char[][] matrix)
            {
                int m = matrix.Length, n = matrix[0].Length;
                int[][] right = new int[m][];
                for (int i = 0; i < m; i++) right[i] = new int[n];

                for (int i = 0; i < m; i++)
                {
                    int count = 0;
                    for (int j = n - 1; j >= 0; j--)
                    {
                        if (matrix[i][j] == '1') count++; else count = 0;
                        right[i][j] = count;
                    }
                }

                int[][] histograms = new int[n][];

                for (int k = 0; k < n; k++)
                {
                    histograms[k] = new int[m + 1];
                    for (int i = 0; i < m; i++)
                    {
                        histograms[k][i] = right[i][k];
                    }
                    histograms[k][m] = 0;
                }

                int result = 0;
                for (int k = 0; k < n; k++)
                {
                    Stack<int> stack = new Stack<int>();
                    for (int i = 0; i <= m; i++)
                    {
                        while(stack.Count > 0 && histograms[k][stack.Peek()] > histograms[k][i])
                        {
                            int height = histograms[k][stack.Pop()];
                            int left = stack.Count > 0 ? stack.Peek() : -1;
                            result = Math.Max(result, (i - left - 1) * height);
                        }
                        stack.Push(i);
                    }
                }

                return result;
            }
        }
    }
}
