using Leetcode.models.leetcode;

namespace Leetcode.problems
{
    internal class MinCameraCover // https://leetcode.com/problems/binary-tree-cameras/
    {
        public class Solution
        {
            public int MinCameraCover(TreeNode root)
            {
                int result = dfs(root, 0);
                if (root.val == 0) result++;
                return result;
            }

            private int dfs(TreeNode node, int count)
            {
                if (node.left != null && node.right != null)
                {
                    count += dfs(node.left, count) + dfs(node.right, count);
                    node.val = (Math.Min(node.right.val, node.left.val) + 1) % 3;
                }
                else if (node.left != null || node.right != null)
                { // node has exactly one child
                    TreeNode next = node.right != null ? node.right : node.left;
                    count += dfs(next, count);
                    node.val = (next.val + 1) % 3;
                }
                if (node.val == 1) count++;
                return count;
            }
        }
    }
}
