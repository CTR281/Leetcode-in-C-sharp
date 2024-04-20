using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class FindFarmLand // https://leetcode.com/problems/find-all-groups-of-farmland/
    {
        public class Solution
        {
            public int[][] FindFarmland(int[][] land)
            {
                List<int[]> farmlands = new List<int[]>();
                int m = land.Length, n = land[0].Length;
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (land[i][j] == 0) continue;
                        land[i][j] = 0; // not necessary
                        int r1 = i, c1 = j;
                        int i2 = r1 + 1, j2 = c1 + 1;
                        while (i2 < m && land[i2][c1] == 1) land[i2++][c1] = 0;
                        while (j2 < n && land[r1][j2] == 1) land[r1][j2++] = 0;
                        int r2 = i2 - 1, c2 = j2 - 1;
                        for (i2 = r1 + 1; i2 <= r2; i2++)
                        {
                            for (j2 = c1 + 1; j2 <= c2; j2++)
                            {
                                land[i2][j2] = 0;
                            }
                        }
                        farmlands.Add([r1, c1, r2, c2]);
                    }
                }
                return farmlands.ToArray();
            }
        }
    } 
}
