using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class LengthOfLastWord // https://leetcode.com/problems/length-of-last-word/
    {
        public class Solution
        {
            public int LengthOfLastWord(string s)
            {
                string[] splitted = s.Trim().Split(' ');
                return splitted[splitted.Length - 1].Length;
            }
        }
    }
}
