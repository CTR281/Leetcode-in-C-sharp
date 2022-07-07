namespace Leetcode
{
	public class HammingWeight // https://leetcode.com/problems/number-of-1-bits/
    {
        public class Solution
        {
            public int HammingWeight(uint s)
            {
                int result = 0;
                for (int k = 0; k < 32; k++)
                {
                    if ((s & 1 << k) != 0) result++;
                }
                return result;
            }
        }
        public class Solution2
        {
            public int HammingWeight(uint n)
            {
                int result = 0;
                while (n > 0)
                {
                    n &= n - 1;
                    result++;
                }
                return result;
            }
        }
    }
}
