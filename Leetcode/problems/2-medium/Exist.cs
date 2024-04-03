using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class Exist // https://leetcode.com/problems/word-search/
    {
        public class Solution
        {
       
            private bool backtrack(char[][] board, string word, int i, int j, int k, bool[][] visited)
            {
                if (k == word.Length) return true;
                if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || visited[i][j] || word[k] != board[i][j]) return false;
                
                visited[i][j] = true;

                if (backtrack(board, word, i + 1, j, k + 1, visited) ||
                    backtrack(board, word, i, j - 1, k + 1, visited) ||
                    backtrack(board, word, i, j + 1, k + 1, visited) ||
                    backtrack(board, word, i - 1, j, k + 1, visited)
                    ) return true;

                visited[i][j] = false;
                return false;
            }
            public bool Exist(char[][] board, string word)
            {
                int m = board.Length, n = board[0].Length;
                bool[][] visited = new bool[m][];
                for (int k = 0; k < m; k++) visited[k] = new bool[n];

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        bool res = backtrack(board, word, i, j, 0, visited);
                        if (res) return res;
                    }
                }
                return false;
            }
        }
    }
}
