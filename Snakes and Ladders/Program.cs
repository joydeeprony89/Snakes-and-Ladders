using System;
using System.Collections.Generic;

namespace Snakes_and_Ladders
{
  class Program
  {
    static void Main(string[] args)
    {
      var boards = new int[6][] { new int[]{ -1, -1, -1, -1, -1, -1 }, new int[] { -1, -1, -1, -1, -1, -1 }, new int[] { -1, -1, -1, -1, -1, -1 },
      new int[]{ -1,35,-1,-1,13,-1 },new int[]{ -1, -1, -1, -1, -1, -1 },new int[]{ -1,15,-1,-1,-1,-1 }};

      Solution s = new Solution();
      var answer = s.SnakesAndLadders(boards);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    // https://www.youtube.com/watch?v=6lH4nO3JfLk
    public int SnakesAndLadders(int[][] board)
    {
      // Will be solving this using BFS
      int length = board.Length;
      Reverse(board);

      (int, int) GetIndexes(int square)
      {
        int r = (square - 1) / length;
        int c = (square - 1) % length;
        if (r % 2 != 0)
        {
          c = length - 1 - c;
        }
        return (r, c);
      }

      void Reverse(int[][] board)
      {
        int i = 0; int j = board.Length - 1;
        while (i < j)
        {
          var temp = board[i];
          board[i] = board[j];
          board[j] = temp;
          i++; j--;
        }
      }

      Queue<(int, int)> q = new Queue<(int, int)>();
      // will be adding (square, moves) in the queue instead the index postions
      q.Enqueue((1, 0));
      var visited = new HashSet<int>();
      while (q.Count > 0)
      {
        var (square, moves) = q.Dequeue();
        // we can go 6 position as the dice has 6 values
        for (int i = 1; i <= 6; i++)
        {
          int newSquare = square + i;
          var (r, c) = GetIndexes(newSquare);

          if (board[r][c] != -1)
          {
            newSquare = board[r][c];
          }

          if (newSquare == length * length)
          {
            return moves + 1;
          }

          if (!visited.Contains(newSquare))
          {
            visited.Add(newSquare);
            q.Enqueue((newSquare, moves + 1));
          }
        }
      }

      return -1;
    }
  }
}
