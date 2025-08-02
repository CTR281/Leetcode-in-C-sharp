namespace Leetcode.problems._3_hard;

public class MinCost
{
    public class Solution {
        public long MinCost(int[] basket1, int[] basket2) {
            var n = basket1.Length;
            var count = new Dictionary<int, int>();
            int pivot = int.MaxValue;
            var result = 0L;

            for (int k = 0; k < n; k++)
            {
                count.TryAdd(basket1[k], 0);
                count[basket1[k]]++;
                pivot = Math.Min(pivot, basket1[k]);

                count.TryAdd(basket2[k], 0);
                count[basket2[k]]--;
                pivot = Math.Min(pivot, basket2[k]);
            }

            var surplus = new List<int>();
            
            foreach (var kvp in count)
            {
                int fruit = kvp.Key;
                int diff =  Math.Abs(kvp.Value);
                if ((diff & 1) == 1) return -1;
                for (int k = 0; k < diff / 2; k++)
                {
                    surplus.Add(fruit);
                }
            }
            
            surplus.Sort();

            for (int k = 0; k < surplus.Count / 2; k++) // swap the first half with the second half
            {
                result += Math.Min(surplus[k], 2 * pivot); // ex: swap (50,80); global minimum (=pivot) of 2. swap 80 with 2, then 2 with 50, and the global cost of this double swap is 4 instead of 50.
            }

            return result;
        }
    }
}