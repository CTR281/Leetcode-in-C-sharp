
using Leetcode.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Leetcode
{
    internal class LeafSimilar
    {
        public class Solution // https://leetcode.com/problems/leaf-similar-trees/
        {
            public bool LeafSimilar(TreeNode root1, TreeNode root2)
            {
                Stack<TreeNode> stack1 = new Stack<TreeNode>();
                stack1.Push(root1);

                Stack<TreeNode> stack2 = new Stack<TreeNode>();
                stack2.Push(root2);

                return dfs(stack1, stack2);
            }

            private bool hasChildren(TreeNode node)
            {
                return hasLeftChild(node) || hasRightChild(node);
            }

            private bool hasLeftChild(TreeNode node)
            {
                return node.left != null;
            }

            private bool hasRightChild(TreeNode node)
            {
                return node.right != null;
            }

            private void addChildrenToStack(Stack<TreeNode> stack, TreeNode node)
            {
                stack.Pop();
                if (hasRightChild(node)) stack.Push(node.right);
                if (hasLeftChild(node)) stack.Push(node.left);
            }

            private bool dfs(Stack<TreeNode> stack1, Stack<TreeNode> stack2)
            {
                if (!stack1.TryPeek(out TreeNode node1)) // if there is no more node to explore in tree 1, there better not be too for tree 2
                {
                    return !stack2.TryPeek(out _);
                }
                if (!hasChildren(node1)) // if current node of tree 1 is leaf
                {
                    if (!stack2.TryPeek(out TreeNode node2)) return false;
                    if (!hasChildren(node2))
                    { // if current node of tree 2 is leaf
                        if (node1.val != node2.val) return false;
                        else
                        { // leafs are identical; move on to the next nodes
                            stack1.Pop();
                            stack2.Pop();
                        }
                    }
                    else
                    {
                        addChildrenToStack(stack2, node2); // current node of tree 2 was not leaf; we will keep exploring tree 2 until we get a leaf to compare with leaf of tree 1
                    }
                }
                else
                {
                    addChildrenToStack(stack1, node1); // current node of tree 1 was not leaf; keep exploring tree 1
                }
                return dfs(stack1, stack2);
            }
        }
    }
}
