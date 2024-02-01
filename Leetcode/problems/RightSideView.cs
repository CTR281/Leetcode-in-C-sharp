using Leetcode.models;

namespace Leetcode.problems
{
    internal class RightSideView // https://leetcode.com/problems/binary-tree-right-side-view/
    {

        public class Solution
        {
            public IList<int> RightSideView(TreeNode root)
            {
                List<int> res = new();
                dfs(root, -1, 0, res);
                return res;
            }

            private int dfs(TreeNode node, int maxDepth, int depth, IList<int> res)
            {
                if (node == null)
                {
                    return maxDepth;
                }
                if (depth > maxDepth)
                {
                    res.Add(node.val);
                    maxDepth = depth;
                }
                maxDepth = dfs(node.right, maxDepth, depth + 1, res);
                return dfs(node.left, maxDepth, depth + 1, res);
            }
        }
    }
}
