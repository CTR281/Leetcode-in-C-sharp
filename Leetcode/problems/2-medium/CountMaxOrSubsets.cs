using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class CountMaxOrSubsets // https://leetcode.com/problems/count-number-of-maximum-bitwise-or-subsets/
    {
        public class Solution // Time complexity: O(N*2^N)
        {
            public int CountMaxOrSubsets(int[] nums)
            {
                int max = nums.Aggregate((acc, num) => acc | num);
                int N = nums.Length;
                int result = 0;

                for (int i = 0; i < Math.Pow(2, N); i++)
                {
                    int sum = 0;
                    for (int j = 0; j < N; j++)
                    {
                        if (((i >> j) & 1) == 1)
                        {
                            sum |= nums[j];
                        }
                    }
                    if (sum == max) result++;
                }

                return result;
            }
        }

        public class Solution2 // Time complexity: O(2^N)
        {
            int[] nums = [];
            int maxOr = 0;
            public int CountMaxOrSubsets(int[] nums)
            {
                int N = nums.Length;
                this.nums = nums;
                this.maxOr = nums.Aggregate((acc, num) => acc | num);

                return this.dfs(0, 0);
            }

            private int dfs(int index, int currentOr)
            {
                if (index == this.nums.Length) return currentOr == this.maxOr ? 1 : 0;
                return dfs(index + 1, currentOr | nums[index]) + dfs(index + 1, currentOr);
            }
        }
    }
}
