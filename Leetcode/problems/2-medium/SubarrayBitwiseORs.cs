namespace Leetcode.problems._2_medium;

internal class SubarrayBitwiseORs
{
    public class Solution
    {
        public int SubarrayBitwiseORs(int[] arr)
        {
            HashSet<int> result = new HashSet<int>();
            HashSet<int> cur = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                HashSet<int> cur2 = new HashSet<int>();
                foreach (int item in cur) cur2.Add(item | arr[i]);
                cur2.Add(arr[i]);
                cur = cur2;
                result.UnionWith(cur2);
            }

            return result.Count;
        }
    }
}