using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class AddOneRow // https://leetcode.com/problems/add-one-row-to-tree/
    {
        public class Solution
        {
            private void dfs(TreeNode node, int val, int depth, TreeNode parent, int curDepth, bool left)
            {
                if (curDepth == depth)
                {
                    TreeNode newNode = left ? new TreeNode(val, node) : new TreeNode(val, null, node);
                    if (left) parent.left = newNode; else parent.right = newNode;
                }
                else if (curDepth < depth && node != null)
                {
                    dfs(node.left, val, depth, node, curDepth + 1, true);
                    dfs(node.right, val, depth, node, curDepth + 1, false);
                }
                else return;
            }

            public TreeNode AddOneRow(TreeNode root, int val, int depth)
            {
                if (depth == 1) return new TreeNode(val, root);
                dfs(root, val, depth, root, 1, true);
                return root;
            }
        }
    }
}
