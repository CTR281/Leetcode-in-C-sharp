using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class ReorderList // https://leetcode.com/problems/reorder-list/
    {
        public class Solution
        {
            public void ReorderList(ListNode head)
            {
                // Count number of nodes
                int n = 0;
                ListNode node = head;
                while (node != null)
                {
                    n++;
                    node = node.next;
                }

                //Reverse half of the linked list
                node = head;
                ListNode parent = null;
                int k = 0;
                while (node != null)
                {
                    ListNode next = node.next;
                    if (k >= (n + 1) / 2) node.next = parent;
                    parent = node;
                    node = next;
                    k++;
                }

                k = 0;
                ListNode tail = parent;
                while (k < n)
                {

                    if (k % 2 == 0)
                    {
                        ListNode next = head.next;
                        head.next = tail;
                        head = next;
                    }
                    else
                    {
                        ListNode next = tail.next;
                        tail.next = head;
                        tail = next;
                    }
                    k++;
                }
                if (n % 2 == 1) tail.next = null; else head.next = null;

            }
        }
    }
}
