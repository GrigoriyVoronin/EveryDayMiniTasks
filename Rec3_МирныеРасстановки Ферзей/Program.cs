using System;
using System.Diagnostics;
using  System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Rec3_МирныеРасстановки_Ферзей
{
    class Program
    {
        private static int count;
        private static int n; 
        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            var board = new bool[n, n];
            var time = new Stopwatch();
            time.Start();
            FindSolution(board,0);
            time.Stop();
            Console.WriteLine(count);
            Console.WriteLine(time.Elapsed.TotalMilliseconds);

        }

        private static void FindSolution(bool[,] board, int numberOfFerz)
        {
            if (numberOfFerz == n)
            {
                count++;
                return;
            }
            var boardClone = new bool[n, n];
            for (int j = 0; j < n; j++)
            {
                if (!board[numberOfFerz, j])
                {
                    Copy(board, boardClone);
                    Ferz(boardClone, numberOfFerz, j);
                    FindSolution(boardClone, numberOfFerz + 1);
                    //
                    //Без дополнительной памяти, но медленнее  в n/log(n) раз
                    //
                    //if (!Check(board, numberOfFerz, j))
                    //{
                    //    board[numberOfFerz, j] = true;
                    //    FindSolution(board, numberOfFerz + 1);
                    //}
                    //board[numberOfFerz, j] = false;
                }
            }
        }

        private static void Copy(bool[,] board, bool[,] boardClone)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    boardClone[i, j] = board[i, j];
                }
            }
        }

        static bool Check(bool[,] board, int x, int y)
        {
            var isCant = false;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                isCant = isCant || board[x, i];
                isCant = isCant || board[i, y];
                if (x + i < n && y + i < n)
                    isCant = isCant || board[x + i, y + i];
                if (x + i < n && y - i >= 0)
                    isCant = isCant || board[x + i, y - i];
                if (x - i >= 0 && y + i < n)
                    isCant = isCant || board[x - i, y + i];
                if (x - i >= 0 && y - i >= 0)
                    isCant = isCant || board[x - i, y - i];
            }

            return isCant;
        }
        static void Ferz(bool[,] board, int x, int y)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                board[x, i] = true;
                board[i, y] = true;
                if (x + i < n && y + i < n)
                    board[x + i, y + i] = true;
                if (x + i < n && y - i >= 0)
                    board[x + i, y - i] = true;
                if (x - i >= 0 && y + i < n)
                    board[x - i, y + i] = true;
                if (x - i >= 0 && y - i >= 0)
                    board[x - i, y - i] = true;
            }
        }
    }
}
