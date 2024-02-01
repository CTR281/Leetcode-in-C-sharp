namespace Leetcode.problems
{
    public class MissingNumber // https://leetcode.com/problems/missing-number/
    {
        public class Solution
        {
            public int MissingNumber(int[] nums)
            {
                int n = nums.Length;
                bool hasN = false;
                for (int k = 0; k < n; k++)
                {
                    if (nums[k] == n)
                    {
                        nums[k] -= n;
                        hasN = true;
                        break;
                    }
                }
                if (!hasN) return n;
                for (int k = 0; k < n; k++)
                {
                    nums[nums[k] % n] += n;
                }
                if (nums[0] / n != 2) return 0;
                for (int k = 1; k < n; k++)
                {
                    if (nums[k] / n == 0) return k;
                }
                return n;
            }
        }

        public class Solution2
        {
            public int MissingNumber(int[] nums)
            {
                int n = nums.Length;
                int sumN = n * (n + 1) / 2;
                int sumNums = 0;
                for (int k = 0; k < n; k++)
                {
                    sumNums += nums[k];
                }
                if (sumNums == sumN) return 0;
                for (int k = 1; k <= n; k++)
                {
                    if (sumN - k == sumNums) return k;
                }
                return 42;
            }
        }
    }
}
