using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class ReplaceWords // https://leetcode.com/problems/replace-words/
    {
        public class Solution
        {
            public string ReplaceWords(IList<string> dictionary, string sentence)
            {
                HashSet<string> dict = new HashSet<string>(dictionary);

                int start = 0, count = 1;
                StringBuilder result = new StringBuilder();

                while (start + count - 1 < sentence.Length)
                {
                    if (dict.Contains(sentence.Substring(start, count)))
                    {
                        result.Append(sentence.Substring(start, count));
                        while (start + count - 1 < sentence.Length && sentence[start + count - 1] != ' ') count++;
                        if (start + count - 1 < sentence.Length && sentence[start + count - 1] == ' ') result.Append(" ");
                        start += count;
                        count = 1;
                    }
                    else if (sentence[start + count - 1] == ' ' || start + count - 1 == sentence.Length - 1)
                    {
                        result.Append(sentence.Substring(start, count));
                        start += count;
                        count = 1;
                    }
                    else
                    {
                        count++;
                    }
                }

                return result.ToString();
            }
        }
    }
}
