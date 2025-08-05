namespace Leetcode.problems._1_easy;

public class NumOfUnplacedFruits
{
    public class Solution { // Time complexity: O(N^2) (N(N+1)/2 worst case)
        public int NumOfUnplacedFruits(int[] fruits, int[] baskets) {
            var result = 0;
            foreach (var fruit in fruits)
            {
                var j = 0;
                while (j < baskets.Length && fruit > baskets[j])
                {
                    j++;
                }

                if (j == baskets.Length) result++;
                else baskets[j] = 0;
            }
            return result;
        }
    }
}