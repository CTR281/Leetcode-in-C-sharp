using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class PseudoPalindromicPaths // https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/
    {
        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         *         this.val = val;
         *         this.left = left;
         *         this.right = right;
         *     }
         * }
         */
        public class Solution
        {
            public int PseudoPalindromicPaths(TreeNode root)
            {
                return dfs(root, 0, 0);
            }

            private int dfs(TreeNode node, int mask, int res)
            {
                mask ^= 1 << node.val;
                if (node.left == null && node.right == null)
                {
                    int oddCount = 0;
                    for (int k = 0; k < 9; k++)
                    {
                        if ((mask >> k & 1) == 1) oddCount++;
                        if (oddCount > 1) return res;
                    }
                    return ++res;
                }
                if (node.left != null) res = Math.Max(res, dfs(node.left, mask, res));
                if (node.right != null) res = Math.Max(res, dfs(node.right, mask, res));
                return res;
            }
        }
    }
}
