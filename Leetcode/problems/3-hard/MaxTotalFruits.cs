namespace Leetcode.problems._3_hard;

public class MaxTotalFruits
{
    public class Solution
    {
        public int MaxTotalFruits(int[][] fruits, int startPos, int k)
        {
            var maxPos = Math.Max(fruits[^1][0], startPos + k) + 1;
            var prefixSum = new int[maxPos + 1];
            foreach (var fruit in fruits) prefixSum[fruit[0] + 1] = fruit[1];
            for (int i = 0; i < maxPos; i++)
            {
                prefixSum[i + 1] += prefixSum[i];
            }

            var result = 0;
            for (int i = 0; i <= k / 2; i++)
            {
                var left = Math.Max(startPos - i, 0);
                var right = Math.Max(startPos + k - 2 * i, 0);
                result = Math.Max(result, prefixSum[right + 1] - prefixSum[left]);
            }

            for (int i = 0; i <= k / 2; i++)
            {
                var left = Math.Max(startPos - k + 2 * i, 0);
                var right = startPos + i;
                result = Math.Max(result, prefixSum[right + 1] - prefixSum[left]);
            }

            return result;
        }
    }

    public class Solution2
    {
        public int MaxTotalFruits(int[][] fruits, int startPos, int k)
        {
            var result = 0;
            var sum = 0;
            var right = 0;
            var n = fruits.Length;
            var left = 0;
            while (right < n)
            {
                sum += fruits[right][1];
                while (left <= right && Step(fruits, startPos, right, left) > k)
                {
                    sum -= fruits[left++][1];
                }

                result = Math.Max(result, sum);
                right++;
            }

            return result;
        }

        private int Step(int[][] fruits, int startPos, int right, int left)
        {
            if (startPos <= fruits[left][0]) return fruits[right][0] - startPos;
            else if (startPos >= fruits[right][0]) return startPos - fruits[left][0];
            else
            {
                return Math.Min(fruits[right][0] - startPos, startPos - fruits[left][0]) + fruits[right][0] -
                       fruits[left][0];
            }
        }
    }
}