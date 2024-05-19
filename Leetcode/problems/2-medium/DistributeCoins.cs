using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class DistributeCoins // https://leetcode.com/problems/distribute-coins-in-binary-tree/
    {
        public class Solution
        {
            private int result;

            private int dfs(TreeNode node)
            {
                if (node is null) return 0;
                int leftCoins = dfs(node.left);
                int rightCoins = dfs(node.right);
                result += Math.Abs(leftCoins) + Math.Abs(rightCoins);
                return node.val - 1 + leftCoins + rightCoins;
            }
            public int DistributeCoins(TreeNode root)
            {
                dfs(root);
                return result;
            }
        }
    }
}
