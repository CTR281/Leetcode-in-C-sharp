using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FindAllPeople // https://leetcode.com/problems/find-all-people-with-secret/
    {
        public class Solution // Passes tests, but adjacency model not that great
        {
            public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
            {
                Dictionary<int, Dictionary<int, List<int>>> adj = [];
                foreach (int[] meeting in meetings)
                {
                    int person1 = Math.Min(meeting[0], meeting[1]);
                    int person2 = Math.Max(meeting[0], meeting[1]);
                    if (!adj.ContainsKey(person1)) adj.Add(person1, []);
                    if (!adj.ContainsKey(person2)) adj.Add(person2, []);
                    if (!adj[person1].ContainsKey(person2)) adj[person1].Add(person2, []);
                    adj[person1][person2].Add(meeting[2]);
                    if (!adj[person2].ContainsKey(person1)) adj[person2].Add(person1, []);
                    adj[person2][person1].Add(meeting[2]);
                }               
                if (!adj.ContainsKey(0)) adj.Add(0, []);
                if (!adj[0].ContainsKey(firstPerson)) adj[0].Add(firstPerson, []);
                adj[0][firstPerson].Add(0);

                PriorityQueue<int, int> next = new();
                next.Enqueue(0, 0);

                HashSet<int> visited = [];

                while (next.Count > 0)
                {
                    next.TryDequeue(out int nextPerson, out int time);
                    if (!visited.Add(nextPerson)) continue;
                    if (!adj.ContainsKey(nextPerson) || adj[nextPerson].Count == 0) continue;
                    foreach ((int person, List<int> meets) in adj[nextPerson])
                    {
                        if (meets.Count > 0 && !visited.Contains(person))
                        {
                            List<int> bestMeets = meets.Where(meetingTime => meetingTime >= time).ToList();
                            if (bestMeets.Count > 0) next.Enqueue(person, bestMeets.Min());
                        }
                    }
                }
                return visited.ToArray();
            }
        }

        public class Solution2 // Better adjacency model
        {
            public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
            {
                Dictionary<int, List<(int, int)>> adj = [];
                foreach (int[] meeting in meetings)
                {
                    if (!adj.ContainsKey(meeting[0])) adj.Add(meeting[0], []);
                    adj[meeting[0]].Add((meeting[1], meeting[2]));

                    if (!adj.ContainsKey(meeting[1])) adj.Add(meeting[1], []);
                    adj[meeting[1]].Add((meeting[0], meeting[2]));
                }
                if (!adj.ContainsKey(0)) adj.Add(0, []);
                adj[0].Add((firstPerson, 0));

                PriorityQueue<int, int> next = new();
                next.Enqueue(0, 0);

                HashSet<int> visited = [];

                while (next.Count > 0)
                {
                    next.TryDequeue(out int nextPerson, out int time);
                    if (!visited.Add(nextPerson)) continue;
                    if (!adj.ContainsKey(nextPerson)) continue;
                    foreach ((int personMet, int meetTime) in adj[nextPerson])
                    {
                        if (meetTime >= time && !visited.Contains(personMet))
                        {
                            next.Enqueue(personMet, meetTime);
                        }
                    }
                }
                return visited.ToArray();
            }
        }
    }
}
