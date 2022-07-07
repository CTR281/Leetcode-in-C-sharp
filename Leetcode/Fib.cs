namespace Leetcode
{
	public class Fib // https://leetcode.com/problems/fibonacci-number/
    {
        public class Solution // Memoization top-down
        {
            public int Fib(int n)
            {
                int[] memo = new int[n + 1];
                return dp(n, memo);
            }

            private int dp(int n, int[] memo)
            {
                if (n == 0) return 0;
                if (n == 1) return 1;
                if (memo[n] > 0) return memo[n]; else memo[n] = dp(n - 1, memo) + dp(n - 2, memo);
                return memo[n];
            }
        }
        public class Solution2 // Iterative
        {
            public int Fib(int n)
            {
                return f(n, 0, 1);
            }

            private int f(int n, int a, int b)
            {
                if (n == 0) return a;
                if (n == 1) return b;
                return f(n - 1, b, a + b); // c# has tail recursion optimization
            }
        }
    }
}
