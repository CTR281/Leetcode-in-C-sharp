using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class CountTriplets // https://leetcode.com/problems/count-triplets-that-can-form-two-arrays-of-equal-xor/
    {
        public class Solution
        {
            public int CountTriplets(int[] arr)
            {
                int n = arr.Length;
                int[] prefix = new int[n + 1];
                for (int k = 1; k <= n; k++)
                {
                    prefix[k] = arr[k - 1] ^ prefix[k - 1];
                }

                int result = 0;
                for (int i = 0; i <= n; i++)
                {
                    for (int j = i + 1; j <= n; j++)
                    {
                        if (prefix[i] == prefix[j]) result += j - i - 1;
                    }
                }

                return result;
            }
        }
    }
}
