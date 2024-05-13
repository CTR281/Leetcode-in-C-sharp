using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class MatrixScore // https://leetcode.com/problems/score-after-flipping-matrix/
    {
        public class Solution
        {
            public int MatrixScore(int[][] grid)
            {
                for (int i = 0; i < grid.Length; i++)
                {
                    if (grid[i][0] == 0)
                    {
                        for (int j = 0; j < grid[i].Length; j++)
                        {
                            grid[i][j] = (grid[i][j] + 1) % 2;
                        }
                    }
                }

                for (int j = 1; j < grid[0].Length; j++)
                {
                    int onesCount = 0;
                    for (int i = 0; i < grid.Length; i++)
                    {
                        if (grid[i][j] == 1) onesCount++;
                    }
                    if (onesCount <= grid.Length / 2)
                    {
                        for (int i = 0; i < grid.Length; i++) grid[i][j] = (grid[i][j] + 1) % 2;
                    }
                }

                int result = 0;
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++) result += grid[i][j] << grid[i].Length - 1 - j;
                }

                return result;
            }
        }
    }
}
