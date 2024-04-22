using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class OpenLock // https://leetcode.com/problems/open-the-lock/
    {
        public class Solution
        {
            private string[] computeNextStates(string state, int digit)
            {
                string[] result = new string[2];
                char[] stateArray = state.ToCharArray();
                if (state[digit] == '9')
                {
                    stateArray[digit] = '0';
                }
                else
                {
                    stateArray[digit] = (char)(state[digit] + 1);
                }
                result[0] = new string(stateArray);
                stateArray = state.ToCharArray();
                if (state[digit] == '0')
                {
                    stateArray[digit] = '9';
                }
                else
                {
                    stateArray[digit] = (char)(state[digit] - 1);
                }
                result[1] = new string(stateArray);
                return result;

            }

            public int OpenLock(string[] deadends, string target)
            {
                HashSet<string> invalidStates = new HashSet<string>(deadends);
                HashSet<string> visited = new HashSet<string>();
                Queue<string> next = new Queue<string>();

                string start = "0000";
                int result = -1;
                if (!invalidStates.Contains(start)) next.Enqueue(start);
                while (next.Count > 0)
                {
                    int size = next.Count;
                    result++;
                    while (size-- > 0)
                    {
                        string nextState = next.Dequeue();
                        if (nextState == target) return result;
                        for (int k = 0; k < 4; k++)
                        {
                            string[] nextStates = computeNextStates(nextState, k);
                            if (!invalidStates.Contains(nextStates[0]) && !visited.Contains(nextStates[0]))
                            {
                                next.Enqueue(nextStates[0]);
                                visited.Add(nextStates[0]);
                            }
                            if (!invalidStates.Contains(nextStates[1]) && !visited.Contains(nextStates[1]))
                            {
                                next.Enqueue(nextStates[1]);
                                visited.Add(nextStates[1]);
                            }
                        }
                    }
                }

                return -1;
            }
        } // BFS, works

        public class Solution2 // A*, unsuccessful on last 3 test cases
        {
            struct State
            {
                public string state;
                public int moves;
                public State(string state, int moves = 0)
                {
                    this.state = state;
                    this.moves = moves;
                }
            }
            private string[] computeNextStates(string state, int digit)
            {
                string[] result = new string[2];
                char[] stateArray = state.ToCharArray();
                if (state[digit] == '9')
                {
                    stateArray[digit] = '0';
                }
                else
                {
                    stateArray[digit] = (char)(state[digit] + 1);
                }
                result[0] = new string(stateArray);
                stateArray = state.ToCharArray();
                if (state[digit] == '0')
                {
                    stateArray[digit] = '9';
                }
                else
                {
                    stateArray[digit] = (char)(state[digit] - 1);
                }
                result[1] = new string(stateArray);
                return result;

            }

            private int computeDistance(string state, string destination)
            {
                int result = 0;
                for (int k = 0; k < 4; k++)
                {
                    int stateDigit = state[k] - '0';
                    int destinationDigit = destination[k] - '0';

                    int min = Math.Min(stateDigit, destinationDigit);
                    int max = Math.Max(stateDigit, destinationDigit);
                    result += Math.Min(max - min, min + 10 - max);
                }
                return result;
            }

            public int OpenLock(string[] deadends, string target)
            {
                HashSet<string> invalidStates = new HashSet<string>(deadends);
                if (invalidStates.Contains("0000")) return -1;
                HashSet<string> visited = new HashSet<string>();
                PriorityQueue<State, int> next = new PriorityQueue<State, int>();

                State start = new State("0000");
                next.Enqueue(start, computeDistance(start.state, target));
                while (next.Count > 0)
                {
                    State nextState = next.Dequeue();
                    if (nextState.state == target) return nextState.moves;
                    for (int k = 0; k < 4; k++)
                    {
                        State[] nextStates = computeNextStates(nextState.state, k).Select(state => new State(state, nextState.moves + 1)).ToArray();
                        if (!invalidStates.Contains(nextStates[0].state) && !visited.Contains(nextStates[0].state))
                        {
                            next.Enqueue(new State(nextStates[0].state, nextStates[0].moves), computeDistance(nextStates[0].state, target));
                            visited.Add(nextStates[0].state);
                        }
                        if (!invalidStates.Contains(nextStates[1].state) && !visited.Contains(nextStates[1].state))
                        {
                            next.Enqueue(new State(nextStates[1].state, nextStates[1].moves), computeDistance(nextStates[1].state, target));
                            visited.Add(nextStates[1].state);
                        }
                    }
                }

                return -1;
            }
        }
    }
}
