namespace Leetcode
{
	public class MinOperations // https://leetcode.com/problems/minimum-operations-to-reduce-x-to-zero/
    {
		public class Solution
		{
            public int MinOperations(int[] nums, int x)
            {
                int n = nums.Length;
                int midArraySum = 0;
                for (int i = 0; i < n; i++)
                {
                    midArraySum += nums[i];
                }
                midArraySum -= x;
                if (midArraySum == 0) return n;
                if (midArraySum < 0) return -1;
                int sum = 0;
                int midArrayLength = 0;
                Dictionary<int, int> sums = new();
                sums[0] = -1;
                for (int i = 0; i < n; i++)
                {
                    sum += nums[i];
                    if (sums.ContainsKey(sum - midArraySum))
                    {
                        midArrayLength = Math.Max(midArrayLength, i - sums[sum - midArraySum]);
                    }
                    sums[sum] = i;
                }
                return midArrayLength == 0 ? -1 : n - midArrayLength;
            }
        }
	}
}
