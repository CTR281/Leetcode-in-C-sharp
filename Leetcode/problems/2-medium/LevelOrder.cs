using Leetcode.models.leetcode;

namespace Leetcode.problems
{
    internal class LevelOrder // https://leetcode.com/problems/binary-tree-level-order-traversal/
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

        public class Solution2
        {
            public IList<IList<int>> LevelOrder(TreeNode root)
            {
                Queue<TreeNode> queue = new();
                if (root != null) queue.Enqueue(root);

                List<IList<int>> result = new();

                while (queue.Count() > 0)
                {
                    int next = queue.Count;
                    List<int> level = new List<int>();
                    while (next-- > 0)
                    {
                        TreeNode node = queue.Dequeue();
                        if (node.left != null) queue.Enqueue(node.left);
                        if (node.right != null) queue.Enqueue(node.right);
                        level.Add(node.val);
                    }
                    result.Add(level);
                }

                return result;
            }
        }
    }
}
