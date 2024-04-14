using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class SumOfLeftLeaves // https://leetcode.com/problems/sum-of-left-leaves/
    {
        public class Solution
        {
            private int dfs(TreeNode? node, bool isLeft)
            {
                if (node == null) return 0;
                if (node.left == null && node.right == null && isLeft) return node.val;
                return dfs(node.left, true) + dfs(node.right, false);
            }
            public int SumOfLeftLeaves(TreeNode root)
            {
                return dfs(root, false);
            }
        }
    }
}
