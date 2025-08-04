namespace Leetcode.problems._2_medium;

public class TotalFruit
{
    public class Solution
    {
        // Time complexity: O(N) but with HashMap overhead + possibly ~2*N iterations with sth like [1,...,1,2,3]
        public int TotalFruit(int[] fruits)
        {
            int left = fruits.Length - 1, right = fruits.Length - 1;
            var picked = new Dictionary<int, int>();
            var result = 0;
            while (left >= 0)
            {
                picked.TryAdd(fruits[left], 0);
                picked[fruits[left]]++;
                while (picked.Count > 2)
                {
                    picked[fruits[right]]--;
                    if (picked[fruits[right]] == 0) picked.Remove(fruits[right]);
                    right--;
                }

                result = Math.Max(result, right - left + 1);
                left--;
            }

            return result;
        }
    }

    public class Solution2
    {
        /*
         * The basket may only hold 2 types of fruit: pick1 & pick2. They are not static: 'pick1' always matches the latest type of fruit added to the basket; 'pick2' the oldest.
         * 'countBasket' keeps track of the number of fruits in the basket.
         * 'countPick1' keeps track of the amount of fruit of type 'pick1' in the basket.
         * When we are about to add a third one, we throw the oldest type of fruit 'pick2' out of the basket.
         * The new number of fruits in the basket is the number of fruit 'pick1' (which becomes pick2) + the new fruit we just added (which becomes pick1)
         */
        public int TotalFruit(int[] fruits) // Time complexity: O(N), better than Solution
        {
            int pick1 = fruits[0];
            int pick2 = -1;
            int countPick1 = 1;
            int countBasket = 1;
            int result = 0;
            for (int i = 1; i < fruits.Length; i++)
            {
                if (fruits[i] == pick1) // we are adding pick1
                {
                    countBasket++;
                    countPick1++;
                }
                else if (fruits[i] == pick2 || pick2 == -1) // we are adding pick2, or it becomes pick2 if we don't have one yet (only at the start)
                {
                    pick2 = pick1;
                    pick1 = fruits[i];
                    countPick1 = 1; // 'pick1' is now 'pick2' so the count must be reset
                    countBasket++;
                }
                else // this is a new fruit. we 'throw out' the oldest type of fruit by overriding pick2.
                {
                    result = Math.Max(result, countBasket);
                    pick2 = pick1;
                    pick1 = fruits[i];
                    countBasket = countPick1 + 1;
                    countPick1 = 1;
                }
            }
            result = Math.Max(result, countBasket);

            return result;
        }
    }
}