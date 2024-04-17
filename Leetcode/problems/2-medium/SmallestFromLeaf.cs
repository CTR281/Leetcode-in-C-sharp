using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class SmallestFromLeaf // https://leetcode.com/problems/smallest-string-starting-from-leaf/
    {
        public class Solution
        {
            private string smallestString = "";
            private void dfs(TreeNode node, string currentString)
            {
                if (node == null) return;

                currentString = (char)('a' + node.val) + currentString;

                if (node.left == null & node.right == null)
                {
                    if (smallestString == "" || smallestString.CompareTo(currentString) > 0) smallestString = currentString;
                }

                dfs(node.left, currentString);
                dfs(node.right, currentString);
            }
            public string SmallestFromLeaf(TreeNode root)
            {
                dfs(root, "");
                return smallestString;
            }
        }
    }
}
