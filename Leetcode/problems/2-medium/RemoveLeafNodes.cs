using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class RemoveLeafNodes // https://leetcode.com/problems/delete-leaves-with-a-given-value/
    {
        public class Solution
        {
            private void dfs(TreeNode node, int target, TreeNode parent, bool isLeft)
            {
                if (node == null) return;
                dfs(node.left, target, node, true);
                dfs(node.right, target, node, false);
                if (node.val == target && node.right == null & node.left == null)
                {
                    if (isLeft) parent.left = null; else parent.right = null;
                }
            }

            public TreeNode RemoveLeafNodes(TreeNode root, int target)
            {
                TreeNode head = new TreeNode(0, root);
                dfs(root, target, head, true);
                return head.left;
            }
        }

        public class Solution2 // better
        {
            public TreeNode RemoveLeafNodes(TreeNode root, int target)
            {
                if (root is null) return null;
                root.left = RemoveLeafNodes(root.left, target);
                root.right = RemoveLeafNodes(root.right, target);
                if (root.left is null && root.right is null && root.val == target) return null;
                return root;
            }
        }
    }
}
