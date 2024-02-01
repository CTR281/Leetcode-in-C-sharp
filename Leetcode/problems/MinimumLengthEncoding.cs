namespace Leetcode.problems
{
    public class MinimumLengthEncoding // https://leetcode.com/problems/short-encoding-of-words/
    {
        public class Solution
        {
            private class TrieNode
            {
                public TrieNode[] children;
                public bool isSuffix;

                public TrieNode()
                {
                    children = new TrieNode[27];
                    isSuffix = false;
                }
            }

            private TrieNode suffixTrie(string word)
            {
                TrieNode trie = new();
                TrieNode cur = trie;
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    for (int j = i; j < word.Length; j++)
                    {
                        if (cur.children[word[j] - 'a'] == null) cur.children[word[j] - 'a'] = new();
                        cur = cur.children[word[j] - 'a'];
                    }
                    cur.isSuffix = true;
                    cur = trie;
                }
                return trie;
            }

            public int MinimumLengthEncoding(string[] words)
            {
                List<string>[] list = new List<string>[7];
                for (int k = 0; k < 7; k++)
                {
                    list[k] = new List<string>();
                }
                for (int k = 0; k < words.Length; k++)
                {
                    list[words[k].Length - 1].Add(words[k]);
                }
                for (int i = 6; i > 0; i--)
                {
                    for (int j = 0; j < list[i].Count; j++)
                    {
                        if (list[i][j] == string.Empty) continue;
                        TrieNode trie = suffixTrie(list[i][j]);
                        TrieNode cur = trie;
                        int c = j + 1;
                        for (int i2 = i; i2 >= 0; i2--)
                        {
                            for (int j2 = c; j2 < list[i2].Count; j2++)
                            {
                                for (int l = 0; l < list[i2][j2].Length; l++)
                                {
                                    if (cur.children[list[i2][j2][l] - 'a'] == null)
                                    {
                                        cur = trie;
                                        break;
                                    }
                                    cur = cur.children[list[i2][j2][l] - 'a'];
                                }
                                if (cur.isSuffix) list[i2][j2] = string.Empty;
                                cur = trie;
                            }
                            c = 0;
                        }
                    }
                }
                int result = 0;
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < list[i].Count; j++)
                    {
                        result += list[i][j] == string.Empty ? 0 : list[i][j].Length + 1;
                    }
                }
                return result;
            }
        }

        public class Solution2
        {
            private class TrieNode
            {
                public TrieNode[] children;
                public bool isLeaf;

                public TrieNode()
                {
                    children = new TrieNode[26];
                    isLeaf = true;
                }

                public TrieNode get(char c)
                {
                    if (children[c - 'a'] == null)
                    {
                        children[c - 'a'] = new TrieNode();
                        isLeaf = false;
                    }
                    return children[c - 'a'];
                }
            }

            public int MinimumLengthEncoding(string[] words)
            {
                TrieNode trie = new();
                Dictionary<TrieNode, int> trieDict = new();

                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i];
                    TrieNode cur = trie;
                    for (int j = word.Length - 1; j >= 0; j--)
                    {
                        cur = cur.get(word[j]);
                    }
                    trieDict[cur] = i;
                }

                int result = 0;
                foreach (var item in trieDict)
                {
                    if (item.Key.isLeaf) result += words[item.Value].Length + 1;
                }
                return result;
            }
        }
    }
}
