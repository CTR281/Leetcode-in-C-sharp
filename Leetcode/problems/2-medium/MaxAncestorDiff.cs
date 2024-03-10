using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MaxAncestorDiff // https://leetcode.com/problems/maximum-difference-between-node-and-ancestor/
    {
        public class Solution
        {
            public int MaxAncestorDiff(TreeNode root)
            {
                return dfs(root, root.val, root.val);
            }

            public int dfs(TreeNode node, int maxVal, int minVal)
            {
                if (node == null) return maxVal - minVal;
                maxVal = Math.Max(maxVal, node.val);
                minVal = Math.Min(minVal, node.val);
                return Math.Max(
                    dfs(node.left, maxVal, minVal),
                    dfs(node.right, maxVal, minVal)
                );
            }
        }
    }
}
