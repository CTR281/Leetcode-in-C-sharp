namespace Leetcode.problems
{
    public class SearchSuggestions // https://leetcode.com/problems/search-suggestions-system/
    {
        public class Solution
        {
            private class TrieNode
            {
                public TrieNode[] children;
                public int weight;

                public TrieNode()
                {
                    children = new TrieNode[27];
                    weight = -1;
                }
            }
            public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
            {
                TrieNode trie = new();
                for (int weight = 0; weight < products.Length; weight++)
                {
                    TrieNode cur = trie;
                    for (int j = 0; j < products[weight].Length; j++)
                    {
                        if (cur.children[products[weight][j] - 'a'] == null) cur.children[products[weight][j] - 'a'] = new TrieNode();
                        cur = cur.children[products[weight][j] - 'a'];
                        if (j == products[weight].Length - 1) cur.weight = weight;
                    }
                }
                List<string>[] result = new List<string>[searchWord.Length];
                List<string> mem = new();
                TrieNode current = trie;
                for (int k = 0; k < searchWord.Length; k++)
                {
                    List<string> kList = new(mem);
                    int c = searchWord[k] - 'a';
                    if (current.children[c] == null)
                    {
                        result[k] = kList;
                        for (int k2 = k; k2 < searchWord.Length; k2++)
                        {
                            result[k2] = new List<string>();
                        }
                        break;
                    }
                    else
                    {
                        current = current.children[c];
                    }
                    if (current.weight != -1)
                    {
                        kList.Add(products[current.weight]);
                        mem.Add(products[current.weight]);
                    }
                    result[k] = dfs(current, kList, products);
                }
                return result;
            }
            private List<string> dfs(TrieNode node, List<string> kList, string[] products)
            {
                int c = 0;
                while (kList.Count < 3 && c < 27)
                {
                    if (node.children[c] != null)
                    {
                        if (node.children[c].weight != -1)
                        {
                            kList.Add(products[node.children[c].weight]);
                        }
                        dfs(node.children[c], kList, products);
                    }
                    c++;
                }
                return kList;
            }
        }
    }
}
