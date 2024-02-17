namespace Leetcode.problems
{
    public class FurthestBuilding // https://leetcode.com/problems/furthest-building-you-can-reach/
    {

        public class Solution
        {
            public int FurthestBuilding(int[] heights, int bricks, int ladders)
            {
                return Greedy(heights, bricks, ladders);
            }

            private int Greedy(int[] heights, int bricks, int ladders)
            {
                int bricked = 0;
                PriorityQueue<int, int> heap = new();
                int i = 0;
                while (ladders >= 0)
                {
                    while (i < heights.Length - 1 && heights[i] >= heights[i + 1])
                    {
                        i++;
                    }
                    if (i == heights.Length - 1) return i;
                    int height = heights[i + 1] - heights[i];
                    heap.Enqueue(height, -height);
                    bricked += height;
                    if (bricked > bricks)
                    {
                        if (ladders > 0)
                        {
                            int maxJump = heap.Dequeue();
                            bricked -= maxJump;
                            ladders--;
                            i++;
                        }
                        else
                        {
                            return i;
                        }
                    }
                    else
                    {
                        i++;
                    }
                }
                return i;
            }
        }

        public class Solution2
        {
            public int FurthestBuilding(int[] heights, int bricks, int ladders)
            {
                if (heights.Length == 1) return 0;
                PriorityQueue<int, int> heap = new();

                for (int k = 1; k < heights.Length; k++)
                {
                    int height = heights[k] - heights[k - 1];
                    if (height > 0)
                    {
                        heap.Enqueue(height, -height);
                        bricks -= height;
                        if (bricks < 0)
                        {
                            if (ladders > 0)
                            {
                                bricks += heap.Dequeue();
                                ladders--;
                            }
                            else return k - 1;
                        }
                    }
                }
                return heights.Length - 1;
            }
        }
    }
}
