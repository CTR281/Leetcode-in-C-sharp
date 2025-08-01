namespace Leetcode.problems._1_easy;

public class GetRow
{
    public class Solution { // https://leetcode.com/problems/pascals-triangle-ii/
        public IList<int> GetRow(int rowIndex) { // Time complexity: O(rowIndex^2); Space complexity O(rowIndex)
            var result = new int[rowIndex + 1];
            Array.Fill(result, 0);
            result[0] = 1;
            for (int i = 0; i <= rowIndex; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    result[j] += result[j - 1];
                }
            }
            return result;
        }
    }
}