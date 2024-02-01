namespace Leetcode.problems
{
    public class MaxProduct // https://leetcode.com/problems/maximum-product-of-word-lengths/
    {
        public class Solution
        {
            private readonly Dictionary<char, int> LetterToByte = new();

            public Solution()
            {
                for (int k = 0; k < 26; k++)
                {
                    LetterToByte.Add((char)('a' + k), 1 << k);
                }
            }

            private int GetBitMask(string word)
            {
                int result = 0;
                for (int k = 0; k < word.Length; k++)
                {
                    result |= LetterToByte[word[k]];
                }
                return result;
            }

            public int MaxProduct(string[] words)
            {
                int[] wordsMask = new int[words.Length];
                for (int k = 0; k < words.Length; k++)
                {
                    wordsMask[k] = GetBitMask(words[k]);

                }
                int max = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = i + 1; j < words.Length; j++)
                    {
                        if ((wordsMask[i] & wordsMask[j]) == 0) max = Math.Max(max, words[i].Length * words[j].Length);
                    }
                }
                return max;
            }
        }
    }
}
