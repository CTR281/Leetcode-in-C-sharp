using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MaxFrequencyElements // https://leetcode.com/problems/count-elements-with-maximum-frequency/
    {
        public class Solution
        {
            public int MaxFrequencyElements(int[] nums)
            {
                int[] freqs = new int[100];
                int maxFreq = int.MinValue;

                foreach (int num in nums)
                {
                    freqs[num - 1]++;
                    maxFreq = Math.Max(maxFreq, freqs[num - 1]);
                }

                int result = 0;
                foreach (int freq in freqs)
                {
                    if (freq == maxFreq) result += freq;
                }

                return result;
            }
        }  
    }
}
