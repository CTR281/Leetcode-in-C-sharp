using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class BagOfTokensScore // https://leetcode.com/problems/bag-of-tokens/
    {
        public class Solution
        {
            public int BagOfTokensScore(int[] tokens, int power)
            {
                int result = 0;
                int score = 0;
                int n = tokens.Length;
                Array.Sort(tokens);

                int right = n - 1;
                int left = 0;
                while (left <= right)
                {
                    if (power < tokens[left])
                    {
                        if (score > 0)
                        {
                            power += tokens[right--];
                            score--;
                        }
                        else return result;
                    }
                    else
                    {
                        power -= tokens[left++];
                        score++;
                    }
                    result = Math.Max(result, score);
                }

                return result;
            }
        }
    }
}
