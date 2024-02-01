using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class EvalRPN // https://leetcode.com/problems/evaluate-reverse-polish-notation/
    {
        public class Solution
        {
            public int EvalRPN(string[] tokens)
            {
                Stack<int> stack = new Stack<int>();

                for (int k = 0; k < tokens.Length; k++)
                {
                    if (int.TryParse(tokens[k], out int x)) stack.Push(x);
                    else
                    {
                        int x1 = stack.Pop();
                        int x2 = stack.Pop();

                        switch (tokens[k])
                        {
                            case "+": stack.Push(x2 + x1); break;
                            case "-": stack.Push(x2 - x1); break;
                            case "*": stack.Push(x2 * x1); break;
                            case "/": stack.Push(x2 / x1); break;
                        }
                    }
                }
                return stack.Pop();
            }
        }
    }
}
