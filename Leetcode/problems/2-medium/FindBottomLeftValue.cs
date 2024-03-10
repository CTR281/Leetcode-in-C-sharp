using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FindBottomLeftValue // https://leetcode.com/problems/find-bottom-left-tree-value/
    {
        public class Solution
        {
            private int maxDepth = -1;
            private int result = 0;
            private void dfs(TreeNode node, int depth)
            {
                if (node == null) return;
                if (depth > maxDepth)
                {
                    result = node.val;
                    maxDepth = depth;
                }
                dfs(node.left, depth + 1);
                dfs(node.right, depth + 1);
            }

            public int FindBottomLeftValue(TreeNode root)
            {
                dfs(root, 0);
                return result;
            }
        }

        public class Solution2 // using Action<>
        {
            public int FindBottomLeftValue(TreeNode root)
            {
                int maxDepth = -1;
                int result = 0;
                Action<TreeNode, int> dfs = null;
                dfs = (node, depth) =>
                    {
                        if (node == null) return;
                        if (depth > maxDepth)
                        {
                            result = node.val;
                            maxDepth = depth;
                        }
                        dfs(node.left, depth + 1);
                        dfs(node.right, depth + 1);
                    };
                dfs(root, 0);
                return result;
            }
        }

        public class Solution3 // Level-order traversal
        {
            public int FindBottomLeftValue(TreeNode root)
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                int result = 0;

                while (queue.Count > 0)
                {
                    TreeNode node = queue.Dequeue();
                    if (node == null) continue;

                    result = node.val;

                    queue.Enqueue(node.right);
                    queue.Enqueue(node.left);
                }

                return result;
            }
        }
    }
}
