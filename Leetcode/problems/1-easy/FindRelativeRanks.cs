using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class FindRelativeRanks // https://leetcode.com/problems/relative-ranks/
    {
        public class Solution
        {
            public string[] FindRelativeRanks(int[] score)
            {
                int[] scoreSorted = new int[score.Length];
                score.CopyTo(scoreSorted, 0);
                Array.Sort(scoreSorted, (a , b) => b - a);
                Dictionary<int, int> ranks = new Dictionary<int, int>();

                for (int k = 0; k < score.Length; k++)
                {
                    ranks[scoreSorted[k]] = k + 1;
                }

                string[] result = new string[score.Length];
                for (int k = 0; k < score.Length; k++)
                {
                    int rank = ranks[score[k]];
                    result[k] = rank switch
                    {
                        3 => "Bronze Medal",
                        2 => "Silver Medal",
                        1 => "Gold Medal",
                        int x => x.ToString(),
                    };
                }
                return result;
            }
        }
    }
}
