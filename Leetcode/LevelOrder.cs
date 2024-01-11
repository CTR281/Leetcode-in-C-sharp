﻿using Leetcode.models;

namespace Leetcode
{
	internal class LevelOrder
	{
 
    public class Solution
    {
            private struct QueueItem
            {
                public TreeNode node;
                public int level;

                public QueueItem(TreeNode node, int level)
                {
                    this.node = node;
                    this.level = level;
                }
            }
            public IList<IList<int>> LevelOrder(TreeNode root)
            {
                List<IList<int>> result = new();
                if (root == null) return result;
                Queue<QueueItem> queue = new();
                int curLevel = -1;
                QueueItem next = new QueueItem(root, 0);
                queue.Enqueue(next);

                while (queue.TryDequeue(out next))
                {
                    if (curLevel == next.level)
                    {
                        result[curLevel].Add(next.node.val);
                    }
                    else
                    {
                        result.Add(new List<int> { next.node.val });
                        curLevel = next.level;
                    }
                    if (next.node.left != null) queue.Enqueue(new QueueItem(next.node.left, next.level + 1));
                    if (next.node.right != null) queue.Enqueue(new QueueItem(next.node.right, next.level + 1));
                }
                return result;
            }
        }
    }
}
