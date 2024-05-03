using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class CompareVersion // https://leetcode.com/problems/compare-version-numbers/
    {
        public class Solution
        {
            public int CompareVersion(string version1, string version2)
            {
                List<int> numbers1 = version1.Split('.').Select(int.Parse).ToList();
                List<int> numbers2 = version2.Split('.').Select(int.Parse).ToList();

                int i = 0, j = 0;
                int number1, number2;
                while (i < numbers1.Count || j < numbers2.Count)
                {
                    if (i < numbers1.Count) number1 = numbers1[i++];
                    else number1 = 0;
                    if (j < numbers2.Count) number2 = numbers2[j++];
                    else number2 = 0;

                    if (number1 > number2) return 1;
                    else if (number2 > number1) return -1;
                }

                return 0;
            }
        }
    }
}
