using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class ReversePrefix // https://leetcode.com/problems/reverse-prefix-of-word/
    {
        public class Solution
        {
            public string ReversePrefix(string word, char ch)
            {
                List<char> chars = new List<char>();
                int k;

                for (k = 0; k < word.Length; k++)
                {
                    chars.Add(word[k]);
                    if (ch == word[k])
                    {
                        chars.Reverse();
                        k++;
                        break;
                    }
                }
                while (k < word.Length)
                {
                    chars.Add(word[k++]);
                }

                return new string(chars.ToArray());
            }
        }
    }
}
