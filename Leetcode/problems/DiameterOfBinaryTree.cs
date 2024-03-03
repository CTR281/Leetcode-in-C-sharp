using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class DiameterOfBinaryTree // https://leetcode.com/problems/diameter-of-binary-tree/
    {
        public class Solution
        {
            private int diameter = 0;
            private int dfs(TreeNode node)
            {
                if (node == null) return -1;
                int left = 1 + dfs(node.left);
                int right = 1 + dfs(node.right);
                diameter = Math.Max(diameter, left + right);
                return Math.Max(left, right);
            }
            public int DiameterOfBinaryTree(TreeNode root)
            {
                dfs(root);
                return diameter;
            }
        }
    }
}
