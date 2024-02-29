using Leetcode.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class IsEvenOdd // https://leetcode.com/problems/even-odd-tree/
    {
        public class Solution
        {
            public bool IsEvenOddTree(TreeNode root)
            {
                Queue<TreeNode> next = new Queue<TreeNode>();
                next.Enqueue(root);

                bool isEven = true;

                while (next.Count > 0)
                {
                    int levelNextCount = next.Count;
                    TreeNode last = next.Dequeue();
                    if (isEven && last.val % 2 == 0) return false;
                    if (!isEven && last.val % 2 == 1) return false;
                    if (last.right != null) next.Enqueue(last.right);
                    if (last.left != null) next.Enqueue(last.left);

                    while (--levelNextCount > 0)
                    {
                        TreeNode cur = next.Dequeue();

                        if (isEven && (cur.val >= last.val || cur.val % 2 == 0)) return false;
                        if (!isEven && (cur.val <= last.val || cur.val % 2 == 1)) return false;

                        if (cur.right != null) next.Enqueue(cur.right);
                        if (cur.left != null) next.Enqueue(cur.left);
                        last = cur;
                    }
                    isEven = !isEven;
                }

                return true;
            }
        }
    }
}
