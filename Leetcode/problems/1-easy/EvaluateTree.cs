using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class EvaluateTree // https://leetcode.com/problems/evaluate-boolean-binary-tree/
    {
        public class Solution
        {
            private bool dfs(TreeNode node)
            {
                switch (node.val)
                {
                    case 0: return false;
                    case 1: return true;
                    case 2:
                        {
                            return dfs(node.left) || dfs(node.right);
                        }
                    case 3:
                        {
                            return dfs(node.left) && dfs(node.right);
                        }
                }
                return false;
            }
            public bool EvaluateTree(TreeNode root)
            {
                return dfs(root);
            }
        }
    }
}
