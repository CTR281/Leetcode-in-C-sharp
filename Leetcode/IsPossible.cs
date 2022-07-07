namespace Leetcode
{
	public class IsPossible // https://leetcode.com/problems/construct-target-array-with-multiple-sums/
    {

        public class Solution
        {
            public bool IsPossible(int[] target)
            {
                if (target.Length == 1) return target[0] == 1 ? true : false;
                PriorityQueue<int, int> heap = new();
                for (int k = 0; k < target.Length; k++)
                {
                    heap.Enqueue(k, -target[k]);
                    
                }
                while (heap.Count > 0)
                {
                    int j = heap.Dequeue();
                    for (int i = 0; i < target.Length; i++)
                    {
                        if (i != j) target[j] -= target[i];
                    }
                    if (target[j] > 1) heap.Enqueue(j, -target[j]);
                    if (target[j] < 1) return false;
                }
                return true;
            }
        }
    }
}

