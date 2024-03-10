using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class RearrangeArray // https://leetcode.com/problems/rearrange-array-elements-by-sign/
    {
        public class Solution1
        {
            public int[] RearrangeArray(int[] nums)
            {
                Queue<int> posQueue = new Queue<int>();
                Queue<int> negQueue = new Queue<int>();

                foreach (int num in nums)
                {
                    if (Math.Sign(num) < 0) negQueue.Enqueue(num);
                    else posQueue.Enqueue(num);
                }

                List<int> result = new List<int>();
                while (posQueue.Count > 0)
                {
                    result.Add(posQueue.Dequeue());
                    if (negQueue.Count > 0)
                    {
                        result.Add(negQueue.Dequeue());
                    }
                }

                return result.ToArray();
            }
        }

        public class Solution2
        {
            public int[] RearrangeArray(int[] nums)
            {
                int posCursor = 0, negCursor = 0;
                int[] res = new int[nums.Length];

                for (int k = 0; k < nums.Length; k += 2)
                {
                    while (nums[posCursor] < 0) posCursor++;
                    res[k] = nums[posCursor++];
                    while (nums[negCursor] >= 0) negCursor++;
                    res[k + 1] = nums[negCursor++];
                }

                return res;
            }
        }
    }
}
