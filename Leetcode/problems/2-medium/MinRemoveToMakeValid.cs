using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class MinRemoveToMakeValid // https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/
    {
        public class Solution
        {
            public string MinRemoveToMakeValid(string s)
            {
                int count = 0;
                char[] chars = s.ToCharArray();
                for(int k = 0; k < chars.Length; k++)
                {
                    if (chars[k] == ')')
                    {
                        if (count > 0) count--;
                        else chars[k] = ' ';
                    }
                    else if (chars[k] == '(') count++;
                }
                count = 0;
                for (int k = chars.Length - 1; k >= 0; k--)
                {
                    if (chars[k] == '(')
                    {
                        if (count > 0) count--;
                        else chars[k] = ' ';
                    }
                    else if (chars[k] ==  ')') count++;
                }
                StringBuilder stringBuilder = new StringBuilder();
                foreach (char c in chars) if (!char.IsWhiteSpace(c)) stringBuilder.Append(c);
                return stringBuilder.ToString();
            }
        }
    }
}
