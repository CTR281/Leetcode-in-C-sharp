using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._3_hard
{
    internal class MincostToHireWorkers // https://leetcode.com/problems/minimum-cost-to-hire-k-workers/
    {
        public class Solution
        {
            public double MincostToHireWorkers(int[] quality, int[] wage, int k)
            {
                int n = quality.Length;
                double totalCost = double.MaxValue;
                double currentTotalQuality = 0;
                List<(double, int)> wageToQualityRatio = new List<(double, int)>();
               
                for (int i = 0; i < n; i++)
                {
                    wageToQualityRatio.Add(((double) wage[i] / quality[i], quality[i]));
                }

                wageToQualityRatio.Sort((a, b) => a.Item1.CompareTo(b.Item1));

                PriorityQueue<int, int> highestQualityWorker = new PriorityQueue<int, int>();

                for (int i = 0; i < n; i++)
                {
                    highestQualityWorker.Enqueue(wageToQualityRatio[i].Item2, -wageToQualityRatio[i].Item2);
                    currentTotalQuality += wageToQualityRatio[i].Item2;

                    if (highestQualityWorker.Count > k) currentTotalQuality -= highestQualityWorker.Dequeue();

                    if (highestQualityWorker.Count == k) totalCost = Math.Min(totalCost, currentTotalQuality * wageToQualityRatio[i].Item1);
                }

                return totalCost;
            }
        }
    }
}
