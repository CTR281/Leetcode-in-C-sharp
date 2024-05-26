using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._3_hard
{
    internal class WordBreak // https://leetcode.com/problems/word-break-ii/
    {
        public class Solution
        {
            private void backtrack(int wordStart, int wordLength, string s, IList<string> wordDict, string sentence, List<string> result)
            {
                if (wordStart == s.Length || wordStart + wordLength > s.Length)
                {
                    if (wordStart == s.Length) result.Add(sentence);
                    return;
                }

                for (int k = 0; k < wordDict.Count; k++)
                {
                    if (s.Substring(wordStart, wordLength) == wordDict[k])
                    {
                        string wordToAdd = "";
                        if (sentence.Length > 0) wordToAdd += ' ';
                        wordToAdd += wordDict[k];
                        sentence += wordToAdd;
                        backtrack(wordStart + wordLength, 1, s, wordDict, sentence, result);
                        sentence = sentence.Substring(0, sentence.Length - wordToAdd.Length);
                    }
                }
                backtrack(wordStart, wordLength + 1, s, wordDict, sentence, result);
            }

            public IList<string> WordBreak(string s, IList<string> wordDict)
            {
                List<string> result = new List<string>();
                backtrack(0, 1, s, wordDict, "", result);
                return result;
            }
        }
    }
}
