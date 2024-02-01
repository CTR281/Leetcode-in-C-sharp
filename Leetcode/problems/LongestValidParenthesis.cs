namespace Leetcode.problems
{
    class LongestValidParenthesis // https://leetcode.com/problems/longest-valid-parentheses/
    {
        public class Solution
        {
            public int LongestValidParentheses(string s)
            {
                Stack<int> stack = new();
                int parCount = 0;
                int max = 0;
                int count = 0;
                int k = s.Length - 1;
                while (k >= 0)
                {
                    if (k > 0 && s[k] == ')' && s[k - 1] == '(')
                    {
                        count += 2;
                        k -= 2;
                        continue;
                    }
                    if (s[k] == '(')
                    {
                        if (parCount > 0)
                        {
                            parCount--;
                            count += 2;
                            if (stack.TryPeek(out int lastCount))
                            {
                                count += lastCount;
                                stack.Pop();
                            }
                        }
                        else
                        {
                            if (count > 0)
                            {
                                max = Math.Max(max, count);
                                stack.Push(count);
                                count = 0;
                            }
                        }
                        k--;
                        continue;
                    }
                    if (s[k] == ')')
                    {
                        max = Math.Max(max, count);
                        stack.Push(count);
                        count = 0;
                        parCount++;
                        k--;
                    }
                }
                max = Math.Max(max, count);
                return max;
            }
        }
    }
}

