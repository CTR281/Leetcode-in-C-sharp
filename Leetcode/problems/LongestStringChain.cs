namespace Leetcode.problems
{
    public class LongestStringChain // https://leetcode.com/problems/longest-string-chain/
    {
        public class Solution
        {
            public int LongestStrChain(string[] words)
            {
                int n = words.Length;
                int[] memo = new int[n];
                Dictionary<int, List<int>> dict = new();
                for (int i = 0; i < n; i++)
                {
                    memo[i] = -1;
                    if (dict.ContainsKey(words[i].Length)) dict[words[i].Length].Add(i); else dict[words[i].Length] = new List<int> { i };
                }
                int result = 0;
                for (int i = 0; i < n; i++)
                {
                    result = Math.Max(result, dfs(dict, memo, i, words));
                }
                return result;
            }

            private int dfs(Dictionary<int, List<int>> dict, int[] memo, int predecessorI, string[] words)
            {
                if (memo[predecessorI] != -1) return memo[predecessorI];
                int depth = words[predecessorI].Length + 1;
                if (!dict.ContainsKey(depth)) return 1;
                int result = 1;
                foreach (int wordI in dict[depth])
                {
                    if (isPredecessor(words[predecessorI], words[wordI]))
                    {
                        result = memo[wordI] != -1 ? Math.Max(result, memo[wordI] + 1) : Math.Max(result, dfs(dict, memo, wordI, words) + 1);
                    }
                }
                return memo[predecessorI] = result;
            }

            private bool isPredecessor(string predecessor, string word)
            {
                int n = predecessor.Length;
                int m = word.Length;
                int i = 0;
                for (int k = 0; k < m; k++)
                {
                    if (i == n) return true;
                    if (predecessor[i] == word[k]) i++;
                }
                return i == n;
            }
        }
    }
}

