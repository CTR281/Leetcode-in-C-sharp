namespace Leetcode
{
    public class ReconstructQueue // https://leetcode.com/problems/queue-reconstruction-by-height/
    {
        public class Solution
        {
            public int[][] ReconstructQueue(int[][] people)
            {
                Array.Sort(people, (x, y) => y[0] - x[0] != 0 ? y[0] - x[0] : x[1] - y[1]);
                List<int[]> result = people.ToList();
                for (int k = 0; k < result.Count; k++)
                {
                    result.RemoveAt(k);
                    result.Insert(people[k][1], people[k]);
                }
                return result.ToArray();
            }
        }
    }
}

