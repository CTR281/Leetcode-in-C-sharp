using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Leetcode.problems
{
    internal class RemoveElement // https://leetcode.com/problems/remove-element/
    {
        public class Solution // Unnecessarily complicated - O(1)
        {
            public int RemoveElement(int[] nums, int val)
            {
                int next = -1;
                int start = -1;
                int result = 0;

                /*
                 * First, let's build (in place) the linked list that will hold all "val" elements that we will override in the array in the next loop.
                 * At every 'val', we want to store the index of the next 'val'. Thus, each 'val' will point to the next 'val', like a linked list.
                 * 'next' is the pointer of the last 'val' element added to the linked list. At the end of the iteration, 'next' will point to the last element of the linked list.
                 * The constraints of the problem makes it so it's better to start from the beginning of the linked list; thus 'start' will store the index of the first 'val' we encounter in the array. 
                 * 
                 * 'result' denotes the number of elements != val
                 * 
                 * Important point: at each element of the array, we want to be able to store two pieces of info: 
                 *      - the original value 'nums[k]'
                 *      - for 'val' elements, the index of the next 'val' (the linked list construction)
                 * To accomodate for both 'val' and non 'val' elements scenario, we override nums[k] by this value: `nums[k] * 101 + 101 (+ next)`      
                 * 101 is chosen based on the constraints of the problem. It works, because both index and array values cannot be greater than 100 (100 and 50 respectively).
                 * Indeed, from this new value, we can retrieve the original value by applying integer division `/` to the new value, minus 1.
                 * We have to add 101 because 0 is a possible value of nums[k].
                 * We can also, when this is relevant, retrieve the pointer to the next 'val' element by applying modulo `%` to the new value.
                 */
                for (int k = 0; k < nums.Length; k++)
                {
                    if (nums[k] == val)
                    {
                        if (next != -1) nums[next] += k;
                        else start = k;
                        next = k;
                    }
                    else result++;
                    nums[k] = nums[k] * 101 + 101;
                }

                next = start;

                /*
                 * For this input: ([3,2,2,3], 2)
                 * At this point, nums devolved to this: [3*101 + 101 + 3, 2 * 101 + 101, 2 * 101 + 101, 3 * 101 + 101]
                 * Now, we want to iterate again from the start. But there is a couple of things to consider...
                 */

                for (int k = 0; k < nums.Length; k++)
                {
                    /*
                     * Since our linked list may point to any element in the array, when we iterate over the k-th element, we may have already overriden this one. 
                     * In that case, we don't want to do anything more to it.
                     */
                    if (nums[k] < 101) continue;
                    int numsk = nums[k] / 101 - 1; // we retrieve the original value.
                    if (numsk == val) continue; // if the original value is a value to be overriden, then we don't want to override it with itself.
                    else
                    {
                        /*-We are going to override 'val' elements with non-val elements as we encounter them on the way.
                         * However, we will skip a few non-val elements: from the first loop we counted 'result' non-val elements. 
                         * All array elements that are encountered before k is greater than the number of non-val elements (= result) do not need to override 'val' elements.
                         * In fact, we don't want them to override 'val' elements that are encountered until then because they would be present twice in the final array.
                         * Thus these elements are already ready; they only need to be transformed back to their original value.
                         */
                        if (k < result) nums[k] = numsk;
                        else
                        {
                            int link = nums[next] % 101; // we retrieve the link to the next pointer before overriding the value that holds this pointer data with 'numsk'
                            nums[next] = numsk;
                            next = link;
                        }
                    }
                }
                return result;
            }
        }

        public class Solution2 // 3-liner - O(1)
        {
            public int RemoveElement(int[] nums, int val)
            {
                int index = 0;
                for (int k = 0; k < nums.Length; k++) if (nums[k] != val) nums[index++] = nums[k];
                return index;
            }
        }
    }
}
