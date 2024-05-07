using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class DoubleIt // https://leetcode.com/problems/double-a-number-represented-as-a-linked-list/
    {
        public class Solution
        {
            private bool dfs(ListNode node)
            {
                if (node == null) return false;
                bool addOne = dfs(node.next);
                node.val = node.val * 2 + (addOne ? 1 : 0);
                bool result = node.val >= 10;
                node.val %= 10;
                return result;
            }

            public ListNode DoubleIt(ListNode head)
            {
                if (dfs(head)) return new ListNode(1, head); else return head;
            }
        }
    }
}
