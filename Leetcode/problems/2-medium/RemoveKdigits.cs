using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class RemoveKdigits // https://leetcode.com/problems/remove-k-digits/
    {
        public class Solution
        {
            public string RemoveKdigits(string num, int k)
            {
                int n = num.Length;
                Stack<char> stack = new Stack<char>();

                for (int i = 0; i < n; i++)
                {
                    while (stack.Count > 0 && stack.Peek() > num[i] && k > 0)
                    {
                        stack.Pop();
                        k--;
                    }
                    if (stack.Count != 0 || num[i] != '0') stack.Push(num[i]);
                }
                while (k-- > 0 && stack.Count > 0) stack.Pop();

                return stack.Count == 0 ? "0" : new string(stack.Reverse().ToArray());
            }
        }
    }
}
