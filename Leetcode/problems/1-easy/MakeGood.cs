using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class MakeGood // https://leetcode.com/problems/make-the-string-great/
    {
        public class Solution
        {
            public string MakeGood(string s)
            {
                Stack<char> stack = new Stack<char>();
    
                for (int k = 0; k < s.Length; k++)
                {
                    if (stack.Count > 0 && char.ToLower(stack.Peek()) == char.ToLower(s[k]) && stack.Peek() != s[k]) stack.Pop();
                    else stack.Push(s[k]);
                }

                return new string(stack.Reverse().ToArray());
            }
        }
    }
}
