using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static int[] score = { 0, 0, 0, 0, 0, 0, 0, 0 };
        static int[][] board = new int[3][];
        static int[][] newBoard = new int[3][];


        static void Main(string[] args)
        {
            board[0] = new int[] { 0, 0, 0 };
            board[1] = new int[] { 0, 0, 0 };
            board[2] = new int[] { 0, 0, 0 };
            newBoard[0] = new int[] { 0, 0, 0 };
            newBoard[1] = new int[] { 0, 0, 0 };
            newBoard[2] = new int[] { 0, 0, 0 };
            int currentPlayer = 1, playerScore = 1;
            
            char currentMarker = 'X';
            int row, col, turn = 0;
            string win = "start";
            while (win != "win" || win != "tie")
            {
                if (currentPlayer == 1) { 
                Console.WriteLine("Tic Tac Toe!\n Turn Player "+ currentPlayer+" you are " + currentMarker + ".");
            }
                else
                {
                    Console.WriteLine("Tic Tac Toe!\n Turn Player "+currentPlayer+" you are " + currentMarker + ".");
                }
                printBoard();
                
                    Console.WriteLine("Please Enter your row number 1-3");
                    row = int.Parse(Console.ReadLine()) - 1;
                    while (row != 0 && row != 1 && row != 2)
                    {
                        Console.WriteLine("Please enter a valid Row number 1-3");
                        row = int.Parse(Console.ReadLine()) - 1;
                    }
                    Console.WriteLine("Please Enter your column number 1-3");
                    col = int.Parse(Console.ReadLine()) - 1;
                    while (col != 0 && col != 1 && col != 2)
                    {
                        Console.WriteLine("Please enter a valid column number 1-3");
                        col = int.Parse(Console.ReadLine()) - 1;
                    }
                    while(board[row][col] != 0)
                {
                    Console.WriteLine("Area has already been choosen. choose again.");
                    Console.WriteLine("Please Enter your row number 1-3");
                    row = int.Parse(Console.ReadLine()) - 1;
                    while (row != 0 && row != 1 && row != 2)
                    {
                        Console.WriteLine("Please enter a valid Row number 1-3");
                        row = int.Parse(Console.ReadLine()) - 1;
                    }
                    Console.WriteLine("Please Enter your column number 1-3");
                    col = int.Parse(Console.ReadLine()) - 1;
                    while (col != 0 && col != 1 && col != 2)
                    {
                        Console.WriteLine("Please enter a valid column number 1-3");
                        col = int.Parse(Console.ReadLine()) - 1;
                    }
                }
                    board[row][col] = playerScore;
                calcScore(playerScore);
                    
                win = victoryConditions(turn);
                if (win == "win")
                {
                    Console.Clear();
                    Console.WriteLine("Tic Tac Toe!\n Turn Player " + currentPlayer + " you are " + currentMarker + ".");
                    printBoard();
                    Console.WriteLine("Player " + currentPlayer + " you win!");
                    Console.WriteLine("press any key to Exit");
                    Console.ReadLine();
                    Environment.Exit(0);


                }
                else if (win == "tie")
                {
                    Console.WriteLine("Nobody wins. Tie.");
                }
                else
                {
                    turn++;
                    if (currentPlayer == 1)
                    {
                        currentPlayer = 2;
                        playerScore = -1;
                        currentMarker = 'O';
                    }
                    else
                    {
                        currentPlayer = 1;
                        playerScore = 1;
                        currentMarker = 'X';
                    }
                    Console.Clear();
                }

            }
            Console.ReadLine();
        }
        static void calcScore( int currentPlayer)
        {
            int pos = 0;
            for(int x = 0; x <3; x++)
            {
                for(int y = 0; y<3; y++)
                {
                    
                    if (board[x][y] != newBoard[x][y])
                    {
                        switch (pos) {
                            case 0:
                            {
                                score[0] += currentPlayer;
                                score[3] += currentPlayer;
                                score[6] += currentPlayer;
                                        break;
                            }
                            case 1:
                            {
                                score[1] += currentPlayer;
                                score[3] += currentPlayer;
                                        break;
                            }
                            case 2:
                            {
                                score[2] += currentPlayer;
                                score[3] += currentPlayer;
                                score[7] += currentPlayer;
                                    break;
                            }
                            case 3:
                            {
                                score[0] += currentPlayer;
                                score[4] += currentPlayer;
                                        break;
                            }
                            case 4:
                            {
                                score[1] += currentPlayer;
                                score[4] += currentPlayer;
                                score[6] += currentPlayer;
                                score[7] += currentPlayer;
                                        break;
                            }
                            case 5:
                            {
                              score[2] += currentPlayer;
                                score[4] += currentPlayer;
                                    break;
                                }
                            case 6:
                                {
                                    score[0] += currentPlayer;
                                    score[5] += currentPlayer;
                                    score[7] += currentPlayer;
                                    break;
                                }
                            case 7:
                                {
                                    score[1] += currentPlayer;
                                    score[5] += currentPlayer;
                                    break;
                                }
                            case 8:
                                {
                                    score[2] += currentPlayer;
                                    score[5] += currentPlayer;
                                    score[6] += currentPlayer;
                                    break;
                                }
                        }
                        newBoard[x][y] = board[x][y];
                        return;
                    }
                    pos++;
                }
            }
        }
        static void printBoard()
        {
            Console.Write("   |---|---|---|\n");
            for(int x = 0; x < 3; x++) {
                Console.Write("   | ");
                for (int y = 0; y < 3; y++) {
                   
                        Console.Write( mark(x, y) + " | ");
              
                     }
                Console.Write("\n   |---|---|---|\n");
            }
        }
        static char mark(int x, int y)
        {
            char mark;
            if (board[x][y] == 1) mark = 'X';
            else if (board[x][y] == -1) mark = 'O';
            else mark = ' ';
            return mark;
        }

        static string victoryConditions(int turn)
        {
            if (turn == 9)
            {
                return "tie.";
            }
            for(int x = 0; x<8; x++)
            {
                if(score[x] == 3 || score[x] == -3)
                {
                    return "win";
                }
            }
            return "fail";
        }
    }
}
