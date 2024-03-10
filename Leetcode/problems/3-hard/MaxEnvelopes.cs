namespace Leetcode.problems
{
    public class MaxEnvelopes // https://leetcode.com/problems/russian-doll-envelopes/
    {
        public class Solution // wrong answer, I keep it for history
        {
            public int MaxEnvelopes(int[][] envelopes)
            {
                Array.Sort(envelopes, WidthSort);
                int pw = int.MaxValue;
                int ph = int.MaxValue;
                int count = 0;
                int max = 0;
                for (int k = 0; k < envelopes.Length; k++)
                {
                    if (envelopes[k][0] < pw && envelopes[k][1] < ph)
                    {
                        count++;
                        pw = envelopes[k][0];
                        ph = envelopes[k][1];
                    }
                }
                max = count;
                Array.Sort(envelopes, HeightSort);
                pw = int.MaxValue;
                ph = int.MaxValue;
                count = 0;
                for (int k = 0; k < envelopes.Length; k++)
                {
                    if (envelopes[k][0] < pw && envelopes[k][1] < ph)
                    {
                        count++;
                        pw = envelopes[k][0];
                        ph = envelopes[k][1];
                    }
                }
                max = Math.Max(max, count);
                Array.Sort(envelopes, TotalSort);
                pw = int.MaxValue;
                ph = int.MaxValue;
                count = 0;
                for (int k = 0; k < envelopes.Length; k++)
                {
                    if (envelopes[k][0] < pw && envelopes[k][1] < ph)
                    {
                        count++;
                        pw = envelopes[k][0];
                        ph = envelopes[k][1];
                    }
                }
                max = Math.Max(max, count);
                Array.Sort(envelopes, MinSort);
                pw = int.MaxValue;
                ph = int.MaxValue;
                count = 0;
                for (int k = 0; k < envelopes.Length; k++)
                {
                    if (envelopes[k][0] < pw && envelopes[k][1] < ph)
                    {
                        count++;
                        pw = envelopes[k][0];
                        ph = envelopes[k][1];
                    }
                }
                max = Math.Max(max, count);
                return max;
            }

            private static int WidthSort(int[] envelope1, int[] envelope2)
            {
                if (envelope2[0] - envelope1[0] == 0)
                {
                    return envelope2[1] - envelope1[1];
                }
                return envelope2[0] - envelope1[0];
            }
            private static int HeightSort(int[] envelope1, int[] envelope2)
            {
                if (envelope2[1] - envelope1[1] == 0)
                {
                    return envelope2[0] - envelope1[0];
                }
                return envelope2[1] - envelope1[1];
            }
            private static int TotalSort(int[] envelope1, int[] envelope2)
            {
                if (envelope2[1] + envelope2[0] - (envelope1[1] + envelope1[0]) == 0)
                {
                    return Math.Min(envelope2[0], envelope2[1]) - Math.Min(envelope1[0], envelope1[1]);
                }
                return envelope2[1] + envelope2[0] - (envelope1[1] + envelope1[0]);
            }
            private static int MinSort(int[] envelope1, int[] envelope2)
            {
                int min1 = Math.Min(envelope1[0], envelope1[1]);
                int min2 = Math.Min(envelope2[0], envelope2[1]);
                if (min2 - min1 == 0)
                {
                    int max1 = Math.Max(envelope1[0], envelope1[1]);
                    int max2 = Math.Max(envelope2[0], envelope2[1]);
                    return max2 - max1;
                }
                return min2 - min1;
            }
        }
        public class Solution2
        {
            public int MaxEnvelopes(int[][] envelopes)
            {
                Array.Sort(envelopes, MinSort);
                Dictionary<(int, int), int> memo = new();
                Dictionary<int, Obj> dict = new();
                int lastBound = int.MaxValue;
                List<int[]> items = new();
                for (int k = 0; k < envelopes.Length; k++)
                {
                    int bound = Math.Min(envelopes[k][0], envelopes[k][1]);
                    if (bound == lastBound)
                    {
                        items.Add(envelopes[k]);
                    }
                    else
                    {
                        dict.Add(lastBound, new Obj(lastBound, items));
                        lastBound = bound;
                        items.Clear();
                        items.Add(envelopes[k]);
                    }
                }
                for (int k = 0; k < envelopes.Length; k++)
                {
                    int bound = Math.Min(envelopes[k][0], envelopes[k][1]);
                    if (dict.ContainsKey(bound + 1))
                    {
                        int max2 = 0;
                        if (bound == envelopes[k][0])
                        {
                            //if (Array.BinarySearch(envelopes[k][1], dict[bound + 1].heightSorted)) ;
                        }
                    }
                    else
                    {
                        memo.Add((envelopes[k][0], envelopes[k][1]), 1);
                    }
                }
                int max = 0;
                return max;
            }

            class CompareCustomDataType : IComparer<Obj>
            {

                public int Compare(Obj x, Obj y)
                {
                    return x.value - y.value;
                }
            }


            private class Obj
            {
                public int value;
                public int[][] widthSorted;
                public int[][] heightSorted;

                public Obj(int value)
                {
                    this.value = value;
                    widthSorted = Array.Empty<int[]>();
                    heightSorted = Array.Empty<int[]>();
                }

                public Obj(int value, List<int[]> list)
                {
                    this.value = value;
                    widthSorted = list.Select(s => s.ToArray()).ToArray();
                    Array.Sort(widthSorted, WidthSort);
                    heightSorted = list.Select(s => s.ToArray()).ToArray();
                    Array.Sort(heightSorted, HeightSort);
                }

                private static int WidthSort(int[] envelope1, int[] envelope2)
                {
                    if (envelope2[0] - envelope1[0] == 0)
                    {
                        return envelope2[1] - envelope1[1];
                    }
                    return envelope2[0] - envelope1[0];
                }
                private static int HeightSort(int[] envelope1, int[] envelope2)
                {
                    if (envelope2[1] - envelope1[1] == 0)
                    {
                        return envelope2[0] - envelope1[0];
                    }
                    return envelope2[1] - envelope1[1];
                }
            }

            private static int MinSort(int[] envelope1, int[] envelope2)
            {
                int min1 = Math.Min(envelope1[0], envelope1[1]);
                int min2 = Math.Min(envelope2[0], envelope2[1]);
                if (min2 - min1 == 0)
                {
                    int max1 = Math.Max(envelope1[0], envelope1[1]);
                    int max2 = Math.Max(envelope2[0], envelope2[1]);
                    return max2 - max1;
                }
                return min2 - min1;
            }
        } // also wrong
        public class Solution3 // valid, but very close to TLE
        {
            public int MaxEnvelopes(int[][] envelopes)
            {
                Array.Sort(envelopes, MinSort);
                int[] memo = new int[envelopes.Length];
                int result = 0;
                for (int i = 0; i < envelopes.Length; i++)
                {
                    int max = 0;
                    for (int j = i; j >= 0; j--)
                    {
                        if (envelopes[i][0] < envelopes[j][0] && envelopes[i][1] < envelopes[j][1]) max = Math.Max(max, memo[j]);
                        if (max == result) break;
                    }
                    memo[i] = max + 1;
                    result = Math.Max(result, memo[i]);
                }
                return result;
            }
            private static int MinSort(int[] envelope1, int[] envelope2)
            {
                int min1 = Math.Min(envelope1[0], envelope1[1]);
                int min2 = Math.Min(envelope2[0], envelope2[1]);
                if (min2 - min1 == 0)
                {
                    int max1 = Math.Max(envelope1[0], envelope1[1]);
                    int max2 = Math.Max(envelope2[0], envelope2[1]);
                    return max2 - max1;
                }
                return min2 - min1;
            }
        }
    }
}

