namespace Leetcode.problems._1_easy;

public class Generate
{
    public class Solution // https://leetcode.com/problems/pascals-triangle/
    {
        public IList<IList<int>> Generate(int numRows) // Time complexity: O(N^2) (N(N + 1)/2)
        {
            var result = new IList<int>[numRows];
            for (var i = 0; i < numRows; i++)
            {
                result[i] = new int[i + 1];
                result[i][0] = 1;
                result[i][^1] = 1;
                for (var j = 1; j < i; j++)
                {
                    result[i][j] = result[i - 1][j - 1] + result[i - 1][j];
                }
            }

            return result;
        }
    }
}