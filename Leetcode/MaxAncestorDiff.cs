﻿using Leetcode.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class MaxAncestorDiff
    {
        public class Solution
        {
            public int MaxAncestorDiff(TreeNode root)
            {               
                return dfs(root, root.val, root.val);
            }

            public int dfs(TreeNode node, int maxVal, int minVal)
            {
                if (node == null) return maxVal - minVal;
                maxVal = Math.Max(maxVal, node.val);
                minVal = Math.Min(minVal, node.val);
                return Math.Max(
                    dfs(node.left, maxVal, minVal), 
                    dfs(node.right, maxVal, minVal)
                );               
            }
        }
    }
}
