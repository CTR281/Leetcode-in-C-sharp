using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MaximumOddBinaryNumber // https://leetcode.com/problems/maximum-odd-binary-number/
    {
        public class Solution
        {
            public string MaximumOddBinaryNumber(string s)
            {
                int[] bitCount = new int[2];

                foreach (char bit in s) bitCount[bit - '0']++;

                if (bitCount[1] == 0) return s;
                StringBuilder stringBuilder = new StringBuilder(s.Length);

                for (int k = 1; k < bitCount[1]; k++) stringBuilder.Append('1');
                for (int k = 0; k < bitCount[0]; k++) stringBuilder.Append('0');
                stringBuilder.Append('1');
                return stringBuilder.ToString();
            }
        }
    }
}
