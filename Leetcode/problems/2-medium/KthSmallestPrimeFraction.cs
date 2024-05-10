using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class KthSmallestPrimeFraction // https://leetcode.com/problems/k-th-smallest-prime-fraction/
    {
        public class Solution
        {
            public int[] KthSmallestPrimeFraction(int[] arr, int k)
            {
                int n = arr.Length;
                PriorityQueue<int[], double> pq = new PriorityQueue<int[], double>();

                for (int i = 0; i < arr.Length; i++)
                {
                    pq.Enqueue([i, n - 1], 1.0 * arr[i] / arr[n - 1]);
                }

                while (--k > 0)
                {
                    pq.TryDequeue(out int[] nextFraction, out double value);
                    if (nextFraction[0] < nextFraction[1])
                    {
                        pq.Enqueue([nextFraction[0], nextFraction[1] - 1], 1.0 * arr[nextFraction[0]] / arr[nextFraction[1] - 1]);
                    }
                }

                int[] result = pq.Dequeue();
                return [arr[result[0]], arr[result[1]]];
            }
        }
    }
}
