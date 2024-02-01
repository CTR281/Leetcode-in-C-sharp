using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FindPaths // https://leetcode.com/problems/out-of-boundary-paths/
    {
        public class Solution
        {
            public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
            {
                if (maxMove == 0) return 0;
                int[][][] memo = new int[m][][];
                for (int i = 0; i < m; i++)
                {
                    memo[i] = new int[n][];
                    for (int j = 0; j < n; j++)
                    {
                        memo[i][j] = new int[maxMove];
                        Array.Fill(memo[i][j], -1);
                    }
                }
                return dfs(startRow, startColumn, maxMove, memo);
            }

            private bool cannotReach(int i, int j, int m, int n, int remainingMove)
            {
                return i - remainingMove >= 0 && j - remainingMove >= 0 && i + remainingMove < m && j + remainingMove < n;
            }

            private bool isOutOfBounds(int i, int j, int m, int n)
            {
                return i < 0 || i >= m || j < 0 || j >= n;
            }

            private int dfs(int i, int j, int remainingMove, int[][][] memo)
            {
                if (isOutOfBounds(i, j, memo.Length, memo[0].Length)) return 1;
                if (remainingMove == 0) return 0;
                if (memo[i][j][remainingMove - 1] != -1) return memo[i][j][remainingMove - 1];
                if (cannotReach(i, j, memo.Length, memo[0].Length, remainingMove)) return memo[i][j][remainingMove - 1] = 0;
                return
                memo[i][j][remainingMove - 1] = mod(
                    mod(
                        mod(dfs(i - 1, j, remainingMove - 1, memo) + dfs(i + 1, j, remainingMove - 1, memo))
                        + dfs(i, j - 1, remainingMove - 1, memo)
                    )
                    + dfs(i, j + 1, remainingMove - 1, memo)
                );
            }

            private int mod(int num)
            {
                return num % (1_000_000_000 + 7);
            }
        }
    }
}
