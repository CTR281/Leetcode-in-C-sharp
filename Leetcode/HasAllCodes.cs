namespace Leetcode
{
	public class HasAllCodes // https://leetcode.com/problems/check-if-a-string-contains-all-binary-codes-of-size-k/
    {
		class Solution
        {
            private Dictionary<int, bool> hashes = new();
            public bool HasAllCodes(string s, int k)
            {
                int n = s.Length;
                int toAdd = 0;
                for (int i = 0; i < k; i++)
                {
                    toAdd += (s[n - 1 - i] - '0') * (1 << i);
                }
                hashes.Add(toAdd, true);
                for (int i = n - k - 1; i >= 0; i--)
                {
                    toAdd = toAdd / 2 + (s[i] - '0') * (1 << (k - 1));
                    hashes.TryAdd(toAdd, true);
                }
                for (int i = 0; i < 1 << k; i++)
                {
                    if (!hashes.ContainsKey(i)) return false;
                }
                return true;
            }
        }

        public class Solution2
        {
            public bool HasAllCodes(string s, int k)
            {
                int n = s.Length;
                if (n <= k) return false;
                bool[] gotHash = new bool[1 << k];
                int gotten = 0;
                int nextHash = 0;
                for (int i = 0; i < k; i++)
                {
                    nextHash += (s[n - 1 - i] - '0') * (1 << i);
                }
                gotHash[nextHash] = true;
                gotten++;
                for (int i = n - k - 1; i >= 0; i--)
                {
                    nextHash = nextHash / 2 + (s[i] - '0') * (1 << (k - 1));
                    if (!gotHash[nextHash])
                    {
                        gotHash[nextHash] = true;
                        gotten++;
                        if (gotten == 1 << k) return true;
                    }
                }
                return false;
            }
        }

        public class Solution3
        {
            public bool HasAllCodes(string s, int k)
            {
                int n = s.Length;
                if (n <= k) return false;
                bool[] gotHash = new bool[1 << k];
                int gotten = 0;
                int nextHash = 0;
                for (int i = 0; i < k; i++)
                {
                    nextHash <<= 1;
                    nextHash |= (s[i] - '0');
                }
                gotHash[nextHash] = true;
                gotten++;
                for (int i = k; i < n; i++)
                {
                    nextHash = ((nextHash << 1) & ((1 << k) - 1)) | (s[i] - '0');
                    if (!gotHash[nextHash])
                    {
                        gotHash[nextHash] = true;
                        gotten++;
                        if (gotten == 1 << k) return true;
                    }
                }
                return false;
            }
        }
    }
}
