using Leetcode.models.leetcode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Leetcode.problems
{
    internal class AmountOfTime
    {
        public class Solution
        {
            public int AmountOfTime(TreeNode root, int start)
            {
                if (root.left == null && root.right == null) return 0;
                Dictionary<TreeNode, List<TreeNode>> adj = new Dictionary<TreeNode, List<TreeNode>>();
                adj.Add(root, new List<TreeNode>());
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);

                TreeNode startNode = root;
                while (stack.Count > 0)
                {
                    TreeNode node = stack.Pop();
                    if (node.val == start) { startNode = node; }
                    if (node.right != null)
                    {
                        stack.Push(node.right);
                        adj[node].Add(node.right);
                        adj.Add(node.right, new List<TreeNode> { node });
                    }
                    if (node.left != null)
                    {
                        stack.Push(node.left);
                        adj[node].Add(node.left);
                        adj.Add(node.left, new List<TreeNode> { node });
                    }
                }
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(startNode);
                int res = 0;
                while (queue.Count > 0)
                {
                    int breadth = queue.Count;
                    while (breadth > 0)
                    {
                        TreeNode node = queue.Dequeue();
                        breadth--;
                        adj[node].ForEach(adjNode =>
                        {
                            if (adj.ContainsKey(adjNode))
                            {
                                queue.Enqueue(adjNode);
                            }
                        });
                        adj.Remove(node);
                    }
                    res++;
                }
                return res - 1;
            }
        }
    }
}
