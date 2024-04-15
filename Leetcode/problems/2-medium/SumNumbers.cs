using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class SumNumbers // https://leetcode.com/problems/sum-root-to-leaf-numbers/
    {
        public class Solution
        {
            private int dfs(TreeNode node, int result)
            {
                if (node == null) return 0;
                result = 10 * result + node.val;
                return Math.Max(result, dfs(node.left, result) + dfs(node.right, result));
            }

            public int SumNumbers(TreeNode root)
            {
                return dfs(root, 0);
            }
        }
    }
}
