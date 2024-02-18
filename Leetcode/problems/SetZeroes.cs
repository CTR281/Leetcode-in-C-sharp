using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class SetZeroes // https://leetcode.com/problems/set-matrix-zeroes/
    {
        public class Solution // O(m + n) space
        {
            public void SetZeroes(int[][] matrix)
            {
                int[] rows = new int[matrix.Length];
                int[] columns = new int[matrix[0].Length];

                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        if (matrix[i][j] == 0)
                        {
                            rows[i] = 1;
                            columns[j] = 1;
                        }
                    }
                }

                for (int i = 0; i < matrix.Length; i++)
                {
                    if (rows[i] == 1)
                    {
                        for (int j = 0; j < matrix[0].Length; j++)
                        {
                            matrix[i][j] = 0;
                        }
                    }
                }
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (columns[j] == 1)
                    {
                        for (int i = 0; i < matrix.Length; i++)
                        {
                            matrix[i][j] = 0;
                        }
                    }
                }
            }
        }

        public class Solution2 // O(1) space
        {
            public void SetZeroes(int[][] matrix)
            {
                int n = matrix.Length;
                int m = matrix[0].Length;
                bool firstRowHasZero = matrix[0].Any(column => column == 0);
                bool firstColumnHasZero = matrix.Any(row => row[0] == 0);
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < m; j++)
                    {
                        if (matrix[i][j] == 0)
                        {
                            matrix[i][0] = 0;
                            matrix[0][j] = 0;
                        }
                    }
                }

                for (int i = 1; i < n; i++)
                {
                    if (matrix[i][0] == 0)
                    {
                        for (int j = 1; j < m; j++)
                        {
                            matrix[i][j] = 0;
                        }
                    }
                }
                for (int j = 0; j < m; j++)
                {
                    if (matrix[0][j] == 0)
                    {
                        for (int i = 1; i < n; i++)
                        {
                            matrix[i][j] = 0;
                        }
                    }
                }

                if (firstRowHasZero) Array.Fill(matrix[0], 0);
                if (firstColumnHasZero) for (int i = 0; i < n; i++) matrix[i][0] = 0;
            }
        }
    }
}
