namespace Leetcode
{
    public class NQueen
    {
        public class Solution
        {
            public IList<IList<string>> SolveNQueens(int n)
            {
                List<int[]> boards = new();
                buildBoards(boards, new int[n], n, 0, 0);

                return boards.ConvertAll<IList<string>>(board => board.Select(queenPos => new string('.', n - 1).Insert(queenPos, "Q")).ToList());
            }

            private void buildBoards(List<int[]> boards, int[] board, int n, int k, int l)
            {
                for (int i = k; i < n; i++)
                {
                    board[i] = -1;
                    for (int j = l; j < n; j++)
                    {
                        if (isValid(board, i, j))
                        {
                            board[i] = j;
                            if (i < n - 1 && j < n - 1)
                            {
                                int[] newBoard = new int[n];
                                board.CopyTo(newBoard, 0);
                                buildBoards(boards, newBoard, n, i, j + 1);
                                break;
                            }
                        }
                    }
                    l = 0;
                    if (board[i] == -1) return;
                }
                boards.Add(board);
            }

            private bool isValid(int[] board, int i, int j)
            {
                PriorityQueue<(int, int, int, int), int> pqueue = new();
                for (int k = 0; k < i; k++)
                {
                    if (board[k] == j || Math.Abs(i - k) == Math.Abs(j - board[k])) return false;
                }
                return true;
            }
        }
    }
}
