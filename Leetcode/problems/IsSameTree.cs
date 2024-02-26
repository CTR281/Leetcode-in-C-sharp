using Leetcode.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class IsSameTree // https://leetcode.com/problems/same-tree/
    {
        public class Solution
        {
            public bool IsSameTree(TreeNode p, TreeNode q)
            {
                if (p == null || q == null) return p == q;
                return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }
        }
    }
}
