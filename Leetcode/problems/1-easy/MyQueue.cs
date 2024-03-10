using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MyQueue // https://leetcode.com/problems/implement-queue-using-stacks/
    {
        class Solution
        {
            public class MyQueue
            {
                Stack<int> leftStack = new Stack<int>();
                Stack<int> rightStack = new Stack<int>();

                public MyQueue()
                {

                }

                public void Push(int x)
                {
                    leftStack.Push(x);
                }

                public int Pop()
                {
                    if (rightStack.Count != 0) return rightStack.Pop();
                    while (leftStack.Count != 0) rightStack.Push(leftStack.Pop());
                    return rightStack.Pop();
                }

                public int Peek()
                {
                    if (rightStack.Count != 0) return rightStack.Peek();
                    while (leftStack.Count != 0) rightStack.Push(leftStack.Pop());
                    return rightStack.Peek();
                }

                public bool Empty()
                {
                    return leftStack.Count == 0 && rightStack.Count == 0;
                }
            }
        }
    }
}
