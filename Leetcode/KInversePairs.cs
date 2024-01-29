using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class KInversePairs // https://leetcode.com/problems/k-inverse-pairs-array/
    {
        public class Solution
        {

            public int KInversePairs(int n, int k)
            {
                // f(n, k) = f(n - 1, k) + f(n - 1, k - 1) + ... + f(n - 1, k - n + 1)
                int[][] dp = new int[n + 1][];
                for (int i = 0; i < n + 1; i++)
                {
                    dp[i] = new int[k + 1];                  
                }
                return TP(n, k, dp);
            }

            private int TP(int n, int k, int[][] dp)
            {
                if (k == 0) return 1;
                if (k < 0) return 0;
                if (dp[n][k] != 0) return dp[n][k];
                for (int i = 0; i < n; i++)
                {
                    dp[n][k] = (dp[n][k] + f(n - 1, k - i, dp)) % (1_000_000_000 + 7); 
                }
                return dp[n][k];
            }

            public int KInversePairsBU(int n, int k)
            {
                // f(n, k) = f(n - 1, k) + f(n - 1, k - 1) + ... + f(n - 1, k - n + 1)
                int[][] dp = new int[n + 1][];
                for (int i = 0; i < n + 1; i++)
                {
                    dp[i] = new int[k + 1];
                    Array.Fill(dp[i], 0);
                }
                dp[1][0] = 1;
                return BU(n, k, dp);
            }

            private int BU(int n, int k, int[][] dp)
            {
                for (int N = 1; N <= n; N++)
                {
                    for (int K = 0; K <= k; K++)
                    {
                        for (int i = 0; i <= Math.Min(K, N - 1); i++)
                        {
                            dp[N][K] = (dp[N][K] + dp[N - 1][K - i]) % (1_000_000_000 + 7);
                        }
                    }
                }
                return dp[n][k];
            }
            public int KInversePairsOpti(int n, int k)
            {
                // f(n, k) = f(n - 1, k) + f(n - 1, k - 1) + ... + f(n - 1, k - n + 1)
                // f(n, k + 1) - f(n, k) allows us to find the simpliefied formula (telescoping sum)   
                int[][] dp = new int[n + 1][];
                for (int i = 0; i < n + 1; i++)
                {
                    dp[i] = new int[k + 1];
                }
                dp[0][0] = 1;
                for (int N = 1; N <= n; N++)
                {
                    for (int K = 0; K <= k; K++)
                    {
                        dp[N][K] = (dp[N - 1][K] + (K > 0 ? dp[N][K - 1] : 0)) % (1_000_000_000 + 7);
                        if (K >= N) dp[N][K] = (dp[N][K] - dp[N - 1][K - N]) % (1_000_000_000 + 7);
                    }
                }
                return dp[n][k];
            }
        }
    }
}
