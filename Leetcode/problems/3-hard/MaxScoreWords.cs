using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._3_hard
{
    internal class MaxScoreWords // https://leetcode.com/problems/maximum-score-words-formed-by-letters/
    {
        public class Solution
        {
            private int backtrack(int start, int[] availableLetters, int result, string[] words, int[] score)
            {
                if (start == words.Length) return result;
                int wordScore = 0;
                for (int k = 0; k < words[start].Length; k++)
                {
                    char letter = words[start][k];
                    if (availableLetters[letter - 'a'] == 0) return result;
                    wordScore += score[letter - 'a'];
                    availableLetters[letter - 'a']--;
                }
                result += wordScore;
                int currentScore = result;
                for (int k = start; k < words.Length; k++)
                {
                    result = Math.Max(result, backtrack(k + 1, (int[])availableLetters.Clone(), currentScore, words, score));
                }
                return result;
            }

            public int MaxScoreWords(string[] words, char[] letters, int[] score)
            {
                int[] lettersFreq = new int[26];
                for (int k = 0; k < letters.Length; k++)
                {
                    lettersFreq[letters[k] - 'a']++;
                }
                int result = 0;
                for (int k = 0; k < words.Length; k++)
                {
                    result = Math.Max(result, backtrack(k, (int[])lettersFreq.Clone(), 0, words, score));
                }
                return result;
            }
        }

        public class Solution2 // 'unchoosing' manually
        {
            private int backtrack(int start, int[] availableLetters, int result, string[] words, int[] score)
            {
                if (start == words.Length) return result;
                int wordScore = 0;
                for (int k = 0; k < words[start].Length; k++)
                {
                    char letter = words[start][k];
                    if (availableLetters[letter - 'a'] == 0)
                    {
                        for (int j = 0; j < k; j++)
                        {
                            availableLetters[words[start][j] - 'a']++;
                        }
                        return result;
                    }
                    wordScore += score[letter - 'a'];
                    availableLetters[letter - 'a']--;
                }
                result += wordScore;
                int currentScore = result;
                for (int k = start; k < words.Length; k++)
                {
                    result = Math.Max(result, backtrack(k + 1, availableLetters, currentScore, words, score));
                }
                for (int k = 0; k < words[start].Length; k++)
                {
                    availableLetters[words[start][k] - 'a']++;
                }
                return result;
            }

            public int MaxScoreWords(string[] words, char[] letters, int[] score)
            {
                int[] lettersFreq = new int[26];
                for (int k = 0; k < letters.Length; k++)
                {
                    lettersFreq[letters[k] - 'a']++;
                }
                int result = 0;
                for (int k = 0; k < words.Length; k++)
                {
                    result = Math.Max(result, backtrack(k, lettersFreq, 0, words, score));
                }
                return result;
            }
        }

        public class Solution3
        {
            private int backtrack(int start, int[] availableLetters, string[] words, int[] score)
            {
                if (start == words.Length) return 0;
                int wordScore = 0;
                for (int k = 0; k < words[start].Length; k++)
                {
                    char letter = words[start][k];
                    if (availableLetters[letter - 'a'] == 0)
                    {
                        for (int j = 0; j < k; j++) availableLetters[words[start][j] - 'a']++;
                        return 0;
                    }
                    wordScore += score[letter - 'a'];
                    availableLetters[letter - 'a']--;
                }
                int result = 0;
                for (int k = start; k < words.Length; k++) result = Math.Max(result, backtrack(k + 1, availableLetters, words, score));
                for (int k = 0; k < words[start].Length; k++) availableLetters[words[start][k] - 'a']++;
                return wordScore + result;
            }

            public int MaxScoreWords(string[] words, char[] letters, int[] score)
            {
                int[] lettersFreq = new int[26];
                for (int k = 0; k < letters.Length; k++) lettersFreq[letters[k] - 'a']++;
                int result = 0;
                for (int k = 0; k < words.Length; k++) result = Math.Max(result, backtrack(k, lettersFreq, words, score));
                return result;
            }
        }
    }
}
