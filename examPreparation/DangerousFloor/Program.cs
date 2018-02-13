using System;

namespace DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[8][];

            for (int counter = 0; counter < 8; counter++)
            {
                var input = Console.ReadLine().Split(new char[] { ',' });

                board[counter] = string.Join("", input).ToCharArray(); 
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var typeOfPeace = command[0];
                var currentRow = int.Parse(command[1].ToString());
                var currentCol = int.Parse(command[2].ToString());
                var finalRow = int.Parse(command[4].ToString());
                var finalCol = int.Parse(command[5].ToString());

                if (board[currentRow][currentCol] == 'x')
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
                if (finalRow < 0 || finalRow > board.Length - 1 || finalCol< 0 || finalCol > board.Length - 1)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                switch (typeOfPeace)
                {
                    case 'K':
                        bool IsValid = (finalRow == currentRow - 1 && finalCol == currentCol - 1) ||
                                        (finalRow == currentRow - 1 && finalCol == currentCol) ||
                                        (finalRow == currentRow - 1 && finalCol == currentCol + 1) ||
                                        (finalRow == currentRow && finalCol == currentCol - 1) ||
                                        (finalRow == currentRow && finalCol == currentCol + 1) ||
                                        (finalRow == currentRow + 1 && finalCol == currentCol - 1) ||
                                        (finalRow == currentRow + 1 && finalCol == currentCol) ||
                                        (finalRow == currentRow + 1 && finalCol == currentCol + 1);

                        if (!IsValid)
                        {
                            Console.WriteLine("Invalid move!");
                            continue;
                        }
                        board[currentRow][currentCol] = 'x';
                        board[finalRow][finalCol] = 'K';

                        break;

                    case 'R':

                        if (finalRow != currentRow && finalCol != currentCol)
                        {
                            Console.WriteLine("Invalid move!");
                            continue;
                        }

                        board[currentRow][currentCol] = 'x';
                        board[finalRow][finalCol] = 'R';

                        break;

                    case 'B':
                        if (Math.Abs(finalRow - currentRow) != Math.Abs(finalCol - currentCol))
                        {
                            Console.WriteLine("Invalid move!");
                            continue;
                        }
                        board[currentRow][currentCol] = 'x';
                        board[finalRow][finalCol] = 'B';
                        break;

                    case 'Q':

                        if (finalRow == currentRow || finalCol == currentCol|| Math.Abs(finalRow - currentRow) == Math.Abs(finalCol - currentCol))
                        {
                            board[currentRow][currentCol] = 'x';
                            board[finalRow][finalCol] = 'Q';
                            
                            continue;
                        }
                        Console.WriteLine("Invalid move!");

                        break;

                    case 'P':

                        if (finalRow >= currentRow || finalCol != currentCol)
                        {
                            Console.WriteLine("Invalid move!");
                            continue;
                        }


                        board[currentRow][currentCol] = 'x';
                        board[finalRow][finalCol] = 'P';
                        break;
                }
            }
            
        }
    }
}
