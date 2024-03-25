using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class IsPalindrome // https://leetcode.com/problems/palindrome-linked-list/
    {
        public class Solution
        {
            public bool IsPalindrome(ListNode head)
            {
                // Count number of nodes
                int n = 0;
                ListNode node = head;
                while (node != null)
                {
                    n++;
                    node = node.next;
                }
                n = (n + 1) / 2;

                //Reverse half of the linked list
                node = head;
                ListNode parent = null;
                int k = 0;
                while (node != null)
                {
                    ListNode next = node.next;
                    if (k >= n) node.next = parent;
                    parent = node;
                    node = next;
                    k++;
                }

                // Compare first half with reversed half
                node = parent;
                k = 0;
                while (k < n)
                {
                    if (head.val != node.val) return false;
                    head = head.next;
                    node = node.next;
                    k++;
                }
                return true;
            }
        }
    }
}
