using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class SumSubarrayMins // https://leetcode.com/problems/sum-of-subarray-minimums/
    {
        public class Solution
        {
            public int SumSubarrayMinsTLE1(int[] arr) // TLE ~O(N^3)
            {
                int n = arr.Length;
                int res = 0;
                for (int subArrayLength = 1; subArrayLength <= n; subArrayLength++)
                {
                    for (int subArrayStart = 0; subArrayStart < n; subArrayStart++)
                    {
                        int min = int.MaxValue;
                        if (subArrayStart + subArrayLength <= n)
                        {
                            for (int k = 0; k < subArrayLength; k++)
                            {
                                min = Math.Min(min, arr[subArrayStart + k]);
                            }
                            res = (res + min) % (1_000_000_000 + 7);
                        }
                    }
                }
                return res;
            }
            public int SumSubarrayMinsTLE2(int[] arr) // TLE O(N^2)
            {
                int n = arr.Length;
                int res = 0;
                int count = 0;

                for (int k = 0; k < n; k++)
                {
                    res = (res + arr[k]) % (1_000_000_000 + 7);
                }
                count++;
                while (count < n)
                {
                    for (int i = 0; i < n - count; i++)
                    {
                        arr[i] = Math.Min(arr[i], arr[i + 1]);
                        res = (res + arr[i]) % (1_000_000_000 + 7);
                    }
                    count++;
                }
                return res;
            }

            public int SumSubarrayMins(int[] arr)
            {
                const int MOD = 1000000007;
                int n = arr.Length;
                long result = 0;

                Stack<int> stack = new Stack<int>();

                for (int i = 0; i <= n; i++)
                {
                    while (stack.Count > 0 && (i == n || arr[i] < arr[stack.Peek()]))
                    {
                        int j = stack.Pop();
                        int left = stack.Count > 0 ? stack.Peek() : -1;
                        result = (result + (long)arr[j] * (i - j) * (j - left)) % MOD;
                    }
                    if (i < n)
                    {
                        stack.Push(i);
                    }
                }

                return (int)result;
            }
        }
    }
}
