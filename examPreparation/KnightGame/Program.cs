using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());
             char[][] board = new char[boardSize][];

            for (int counter = 0; counter < boardSize; counter++)
            {
                board[counter] = Console.ReadLine().ToCharArray();
            }

            int maxRow = 0;
            int MaxCol = 0;
            int maxAttackedPositions = 0;
           int countOfRemoved = 0;

            do
            {
                if (maxAttackedPositions > 0)
                {
                    board[maxRow][MaxCol] = 'O';
                    maxAttackedPositions = 0;
                    countOfRemoved++;

                }

                int currentAtackedPositions = 0;

                for (int row = 0; row < boardSize; row++)
                {
                    for (int column = 0; column < boardSize; column++)
                    {
                        if (board[row][column] == 'K')
                        {
                            currentAtackedPositions = CalculateAttackedPosition(row, column, board);
                            if (currentAtackedPositions > maxAttackedPositions)
                            {
                                maxAttackedPositions = currentAtackedPositions;
                                maxRow = row;
                                MaxCol = column;
                            }
                        }
                    }
                }
            }
            while (maxAttackedPositions > 0);
            {

            }
            Console.WriteLine(countOfRemoved);
        }

         static int   CalculateAttackedPosition(int row, int column, char[][] board)
        {
            var currentAtackPosition = 0;
            if (isPositionAttacked(row - 2, column - 1, board)) currentAtackPosition++;
            if (isPositionAttacked(row - 2, column + 1, board)) currentAtackPosition++;
            if (isPositionAttacked(row - 1, column - 2, board)) currentAtackPosition++;
            if (isPositionAttacked(row - 1, column + 2, board)) currentAtackPosition++;
            if (isPositionAttacked(row + 1, column - 2, board)) currentAtackPosition++;
            if (isPositionAttacked(row + 1, column + 2, board)) currentAtackPosition++;
            if (isPositionAttacked(row + 2, column - 1, board)) currentAtackPosition++;
            if (isPositionAttacked(row + 2, column + 1, board)) currentAtackPosition++;

            return currentAtackPosition;

        }
        static bool isPositionAttacked(int row,int column,char[][] board)
        {
            return IsPositionWithinBoard(row, column, board[0].Length) && board[row][column] == 'K';

        }

        static bool IsPositionWithinBoard(int row,int column, int boardSize)
        {
            return row >= 0 && row < boardSize && column >= 0 && column < boardSize;
        }
    }
}
