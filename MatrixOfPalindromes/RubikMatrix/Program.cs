using System;
using System.Collections.Generic;
using System.Linq;

namespace RubikMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine()
                                           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];
            int cellNumber = 1;

            int[,] rubikCubeMatrix = new int[rows, cols];

            for (int row = 0; row < rubikCubeMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < rubikCubeMatrix.GetLength(1); col++)
                {
                    rubikCubeMatrix[row, col] = cellNumber;
                    cellNumber++;
                }
            }

            int numberOfCommands = int.Parse(Console.ReadLine());

            while (numberOfCommands != 0)
            {
                string[] inputCommands = Console.ReadLine()
                                           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           .ToArray();

                int numberOfMatrix = int.Parse(inputCommands[0]);
                string command = inputCommands[1];
                int moves = int.Parse(inputCommands[2]);


                rubikCubeMatrix = FourDirections(rubikCubeMatrix, numberOfMatrix, moves, command);

                numberOfCommands--;
            }

            cellNumber = 1;

            for (int row = 0; row < rubikCubeMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < rubikCubeMatrix.GetLength(1); col++)
                {
                    if (rubikCubeMatrix[row, col] == cellNumber)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int currentNumber = rubikCubeMatrix[row, col];
                        int switchNumberRow = 0;
                        int switchNumberCol = 0;

                        for (int checkerRow = 0; checkerRow < rubikCubeMatrix.GetLength(0); checkerRow++)
                        {
                            for (int checkerCol = 0; checkerCol < rubikCubeMatrix.GetLength(1); checkerCol++)
                            {
                                if (rubikCubeMatrix[checkerRow, checkerCol] == cellNumber)
                                {
                                    rubikCubeMatrix[checkerRow, checkerCol] = currentNumber;
                                    switchNumberRow = checkerRow;
                                    switchNumberCol = checkerCol;
                                    break;
                                }
                            }
                        }

                        rubikCubeMatrix[row, col] = cellNumber;

                        Console.WriteLine($"Swap ({row}, {col}) with ({switchNumberRow}, {switchNumberCol})");
                    }
                    cellNumber++;
                }
            }
        }

        public static int[,] FourDirections(int[,] currentMatrix, int index, int move, string command)
        {
            if (command == "right" || command == "down")
            {
                Queue<int> matrixRow = new Queue<int>();
                for (int row = currentMatrix.GetLength(0) - 1; row >= 0; row--)
                {
                    for (int col = currentMatrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (row == index && command == "right")
                        {
                            matrixRow.Enqueue(currentMatrix[row, col]);
                        }
                        else if (col == index && command == "down")
                        {
                            matrixRow.Enqueue(currentMatrix[row, col]);
                        }
                    }
                }

                if (command == "right")
                {
                    int moves = move % currentMatrix.GetLength(0);
                    while (moves != 0)
                    {
                        matrixRow.Enqueue(matrixRow.Dequeue());
                        moves--;
                    }
                }
                else if (command == "down")
                {
                    int moves = move % currentMatrix.GetLength(1);
                    while (moves != 0)
                    {
                        matrixRow.Enqueue(matrixRow.Dequeue());
                        moves--;
                    }
                }

                for (int row = currentMatrix.GetLength(0) - 1; row >= 0; row--)
                {
                    for (int col = currentMatrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (row == index && command == "right")
                        {
                            currentMatrix[row, col] = matrixRow.Dequeue();
                        }
                        else if (col == index && command == "down")
                        {
                            currentMatrix[row, col] = matrixRow.Dequeue();
                        }
                    }
                }
            }
            else if (command == "left" || command == "up")
            {
                Queue<int> matrixRow = new Queue<int>();
                for (int row = 0; row < currentMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < currentMatrix.GetLength(1); col++)
                    {
                        if (row == index && command == "left")
                        {
                            matrixRow.Enqueue(currentMatrix[row, col]);
                        }
                        else if (col == index && command == "up")
                        {
                            matrixRow.Enqueue(currentMatrix[row, col]);
                        }
                    }
                }

                if (command == "left")
                {
                    int moves = move % currentMatrix.GetLength(0);
                    while (moves != 0)
                    {
                        matrixRow.Enqueue(matrixRow.Dequeue());
                        moves--;
                    }
                }
                else if (command == "up")
                {
                    int moves = move % currentMatrix.GetLength(1);
                    while (moves != 0)
                    {
                        matrixRow.Enqueue(matrixRow.Dequeue());
                        moves--;
                    }
                }

                for (int row = 0; row < currentMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < currentMatrix.GetLength(1); col++)
                    {
                        if (row == index && command == "left")
                        {
                            currentMatrix[row, col] = matrixRow.Dequeue();
                        }
                        else if (col == index && command == "up")
                        {
                            currentMatrix[row, col] = matrixRow.Dequeue();
                        }
                    }
                }
            }

            return currentMatrix;
        }
    }
    }

