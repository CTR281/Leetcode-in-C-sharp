using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class MaxLength
    {
        public class Solution
        {
            private class Trie // TODO: prevent duplicate computations
            {
                public string root;
                public HashSet<char> charSet = new();
                public List<Trie> leaves = new();
                public static int longestRoot;

                public Trie(string root, Stack<string> strings)
                {
                    this.root = root;                 
                    if (containsDuplicate(root)) return;
                    foreach (char c in root)
                    {
                        charSet.Add(c);
                    }
                    longestRoot = Math.Max(longestRoot, root.Length);
                    buildLeaves(strings);
                }

                private void buildLeaves(Stack<string> strings)
                {
                    while (strings.Count > 0)
                    {
                        string s = strings.Pop();
                        if (containsDuplicate(s) || !canAddLeaf(s)) continue;
                        longestRoot = Math.Max(longestRoot, root.Length + s.Length);
                        leaves.Add(new Trie(String.Concat(root, s), cloneStack(strings)));
                    }
                }

                private bool canAddLeaf(string s)
                {
                    return !s.Any(c => charSet.Contains(c));
                }

                private bool containsDuplicate(string s)
                {
                    return new HashSet<char>(s.ToCharArray()).Count != s.Length;
                }

                private Stack<T> cloneStack<T>(Stack<T> stack)
                {
                    T[] stackToCopy = stack.ToArray();
                    Array.Reverse(stackToCopy);
                    return new Stack<T>(stackToCopy);
                }
            }

            public int MaxLength(IList<string> arr)
            {
                int res = 0;
                for (int k = 0; k < arr.Count; k++)
                {
                    new Trie(arr[k], new Stack<string>(arr.Where((string _, int l) => l != k)));
                    res = Math.Max(res, Trie.longestRoot);
                }
                Trie.longestRoot = 0;
                return res;
            }
        }
    }
}
