using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class IsNStraightHand // https://leetcode.com/problems/hand-of-straights/
    {
        public class Solution // 1, 2, 2, 3, 3, 4, 6, 7, 8
        {
            public bool IsNStraightHand(int[] hand, int groupSize)
            {
                Dictionary<int, int> map = new Dictionary<int, int>();
                foreach (int card in hand)
                {
                    if (!map.ContainsKey(card)) map.Add(card, 0);
                    map[card]++;
                }
                Array.Sort(hand);
                hand = hand.Distinct().ToArray();
                int i = 0;
                while (i < hand.Length)
                {
                    int nextGroupStart = i + groupSize;
                    int k = 0;
                    while (k < groupSize)
                    {
                        if (!map.ContainsKey(hand[i] + k) || map[hand[i] + k] == 0) return false;
                        map[hand[i] + k]--;
                        if (map[hand[i] + k] > 0) nextGroupStart = Math.Min(nextGroupStart, i + k);
                        k++;
                    }
                    i = nextGroupStart;
                }
                return true;
            }
        }
    }
}
