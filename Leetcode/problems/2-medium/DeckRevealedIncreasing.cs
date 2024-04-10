using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class DeckRevealedIncreasing // https://leetcode.com/problems/reveal-cards-in-increasing-order/
    {
        public class Solution
        {
            public int[] DeckRevealedIncreasing(int[] deck)
            {
                int n = deck.Length;
                Array.Sort(deck);
                int[] result = new int[n];

                int deckIndex = 0;
                int resultIndex = 0;
                bool skip = false;

                while (deckIndex < n)
                {
                    if (result[resultIndex] == 0)
                    {
                        if (!skip)
                        {
                            result[resultIndex] = deck[deckIndex];
                            deckIndex++;
                        }
                        skip = !skip;
                    }
                    resultIndex = (resultIndex + 1) % n;
                }

                return result;
            }
        }

        public class Solution2
        {
            public int[] DeckRevealedIncreasing(int[] deck)
            {            
                int n = deck.Length;
                int[] result = new int[n];
                Array.Sort(deck);
                Queue<int> queue = new Queue<int>();
                for (int k = 0; k < n; k++)
                {
                    queue.Enqueue(k);
                }

                for (int k = 0; k < n; k++)
                {
                    result[queue.Dequeue()] = deck[k];
                    if (queue.Count > 0) queue.Enqueue(queue.Dequeue());
                }

                return result;
            }
        }
    }
}
