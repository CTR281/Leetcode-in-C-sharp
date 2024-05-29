using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class NumSteps // https://leetcode.com/problems/number-of-steps-to-reduce-a-number-in-binary-representation-to-one/
    {
        public class Solution
        {
            public int NumSteps(string s)
            {
                int result = 0;
                int right = s.Length - 1;
                char[] array = s.ToCharArray();
                while (right > 0)
                {
                    if (array[right] == '1')
                    {
                        result++;
                        int count = 0;
                        while (right >= 0 && array[right] != '0')
                        {
                            right--;
                            count++;
                        }
                        if (right >= 0) array[right] = '1';
                        result += count;
                    }
                    else
                    {
                        right--;
                        result++;
                    }
                }
                return result;
            }
        }
    }
}
