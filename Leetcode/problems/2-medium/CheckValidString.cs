using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class CheckValidString // https://leetcode.com/problems/valid-parenthesis-string/
    {
        public class Solution
        {
            public bool CheckValidString(string s)
            {
                int parenthesisCount = 0, asteriskCount = 0;

                for (int k = 0; k < s.Length; k++)
                {
                    char c = s[k];
                    if (s[k] == '(') parenthesisCount++;
                    else if (s[k] == ')')
                    {
                        parenthesisCount--;
                        if (parenthesisCount < 0)
                        {
                            if (asteriskCount == 0) return false;
                            else
                            {
                                asteriskCount--;
                                parenthesisCount++;
                            }
                        }
                    }
                    else if (s[k] == '*') asteriskCount++;
                }
                if (parenthesisCount > 0 && parenthesisCount > asteriskCount) return false;
                parenthesisCount = 0;
                asteriskCount = 0;
                for (int k = s.Length - 1; k >= 0; k--)
                {
                    if (s[k] == ')') parenthesisCount++;
                    else if (s[k] == '(')
                    {
                        parenthesisCount--;
                        if (parenthesisCount < 0)
                        {
                            if (asteriskCount == 0) return false;
                            else
                            {
                                asteriskCount--;
                                parenthesisCount++;
                            }
                        }
                    }
                    else if (s[k] == '*') asteriskCount++;
                }
                if (parenthesisCount > 0 && parenthesisCount > asteriskCount) return false;
                return true;
            }
        }
    }
}
