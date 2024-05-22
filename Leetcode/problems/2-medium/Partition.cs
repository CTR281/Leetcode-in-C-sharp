using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class Partition // https://leetcode.com/problems/palindrome-partitioning/
    {
        public class Solution
        {
            private bool isPalindrome(string word)
            {
                for (int k = 0; k < word.Length / 2; k++) if (word[k] != word[word.Length - 1 - k]) return false;
                return true;
            }

            private void backtrack(string word, List<string> partition, List<IList<string>> result)
            {
                if (word.Length == 0)
                {
                    result.Add(new List<string>(partition));
                    return;
                }
                for (int k = 1; k <= word.Length; k++)
                {
                    string curWord = word.Substring(0, k);
                    if (!isPalindrome(curWord)) continue;
                    partition.Add(curWord);
                    backtrack(word.Substring(k), partition, result);
                    partition.RemoveAt(partition.Count - 1);
                }
            }

            public IList<IList<string>> Partition(string s)
            {
                List<IList<string>> result = new List<IList<string>>();
                backtrack(s, new List<string>(), result);
                return result;
            }
        }
    }
}
