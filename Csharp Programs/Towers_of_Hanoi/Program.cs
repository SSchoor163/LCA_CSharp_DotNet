using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towers_of_Hanoi
{
    class Program
    {
        //Global dictionary. Holds a String and a stack of int. Uses String vs Char to avoid exception handling where the user may enter more than one character when moving.
       static Dictionary<String, Stack<int>> towers = new Dictionary<String, Stack<int>>();
        //initiating size to for increased difficulty, turns to track the number of moves, moveFrom to hold the piece the user is moving, and moveTo to hold where the user wants to move the piece too.
        static int size = 4, turns = 1;
        static string moveFrom, moveTo;
        static void Main(string[] args)
        {
            
            
            //Write Tile, Rules, and Choose Difficulty/
            Console.WriteLine("Towers of Hanoi");
            Console.Write("Rules: You must get each number in tower A into tower C\n" +
                          "You may move only one number at a time, and a higher number can not sit atop a lower number.\n" +
                          "How many peices would you like? 4 Easiest up to 10 hardest...");

            //User inputs difficulty by choosing number of pieces. TryParse handles exceptions Exceptions and define lowest and highest difficulty.
            bool suc = int.TryParse(Console.ReadLine(), out size);
            while (!suc || (size<4 || size>10))
            {
                Console.Write("Invaild entry, please enter a number between 4 and 10...");
                suc = int.TryParse(Console.ReadLine(), out size);
            }

            //Set tower Dictionary keys and values. A to hold the peices, B and C to empty.
            towers.Add("A", new Stack<int> { });
            for (int x = size; x > 0; x--)
            {
                towers["A"].Push(x);
            }
            towers.Add("B", new Stack<int> { });
            towers.Add("C", new Stack<int> { });
            Console.Clear();
            
            //While victoryConditions returns true print the rules, print the board, ask user to move a peice, then move the piece. 
            while (victoryConditions(new Dictionary<String, Stack<int>>(towers), size))
            {
                Console.WriteLine("Towers of Hanoi");
                Console.Write("Rules: You must get each number in tower A into tower C\n" +
                              "You may move only one number at a time, and a higher number can not sit atop a lower number.\n" +
                              "Turn: " +turns +"\n\n");

                printboard(new Dictionary<String, Stack<int>>(towers), size);
                //get user input for move, validate it, then swap piece
                move();
                turns++;
                Console.Clear();
            }
            //after all pieces have been moved to tower C print the board again and tell the user they have won and in how many turns 
            Console.Write("Towers of Hanoi\n\n");
                printboard(new Dictionary<String, Stack<int>>(towers), size);
                Console.Write("You achieved Victory in " + turns + "moves!\n" +
                    "Press any button to exit...");
            Console.Read();
        }

       
            //user choose a piece to move from one tower to another. validates the choice, then performs the move.
        static void move()
        {
            //User chooses which tower the want to move a piece off of.
            Console.Write("Select A, B, or C to choose a piece...");
            moveFrom = Console.ReadLine();
            moveFrom = moveFrom.ToUpper();
            //Validates the tower the user chooses for moveFrom
            while (moveFrom != "A" && moveFrom != "B" && moveFrom != "C")
            {
                Console.WriteLine("invalid Choice. please choose again(A, B, or C)...");
                moveFrom = Console.ReadLine();
                moveFrom = moveFrom.ToUpper();
            }
            //User choose where they want to move the piece too.
            Console.Write("Select A, B, or C to move the piece...");
            moveTo = Console.ReadLine();
            moveTo = moveTo.ToUpper();
            //Validates the tower the user chooses for moveToo
            while (moveTo != "A" && moveTo != "B" && moveTo != "C")
            {
                Console.WriteLine("invalid Choice. please choose again(A, B, or C)...");
                moveTo = Console.ReadLine();
                moveTo = moveTo.ToUpper();
            }

            if (towers[moveTo].Count != 0|| moveTo == moveFrom)//Validation. If the tower the user wants to move a piece into is not empty and they are not moving the same piece back into the sam tower
            {
                if (towers[moveTo].Peek() < towers[moveFrom].Peek())//Checks to see if the piece the user wants to move is larger than the piece they want to move it on top of. If it is forces the user to rechoose their move by jumping back to the begining of the move region
                {
                    Console.WriteLine("The peice you are trying to move is larger than the peice you are trying to move it to.");
                    move();
                }
            }
            //moves a piece from one tower into another after validation. Increases the turn count. clears the screen for the next iteration of moves.
            towers[moveTo].Push(towers[moveFrom].Pop());
        }

            
        //Places the stack values in towers into indivisual stacks to avoid reference to the original towers, then iterate and pop off values vertically
       static void printboard(Dictionary<String, Stack<int>> t, int size)
            {
            // A, B, C initialization.
            Stack<int> A = new Stack<int>();
            Stack<int> B = new Stack<int>();
            Stack<int> C = new Stack<int>();
            //seting the stack equal to the stack in towers places it in reverse order. This reverse this reversal so A, B, and C are put in proper order.
            Stack<int> rev = new Stack<int>(t["A"]);
            while (rev.Count != 0)
            {
                A.Push(rev.Pop());
            }
            rev = new Stack<int>(t["B"]);
            while (rev.Count != 0)
            {
                B.Push(rev.Pop());
            }
            rev = new Stack<int>(t["C"]);
            while (rev.Count != 0)
            {
                C.Push(rev.Pop());
            }

            //Iterated through each stack a line at a time. if stack is empty, write | else pop from stack
            for (int y = 0; y < size+1; y++)
                {
                    if (y == size)// after all stacks have been run through prints the bottom of the board.
                    {
                        Console.Write("   ----------\n" +
                                      "   A   B   C\n");
                    }
                    else
                    {
                    Console.Write("   ");
                        if (A.Count == 0)
                            Console.Write("|" + "   ");
                        else
                        {
                            Console.Write(A.Pop() + "   ");
                        }
                        if (B.Count == 0)
                            Console.Write("|" + "   ");
                        else
                        {
                            Console.Write(B.Pop() + "   ");
                        }
                        if (C.Count == 0)
                            Console.Write("|" + "   ");
                        else
                        {
                            Console.Write(C.Pop() + "   ");
                        }
                        Console.Write("\n");
                    }
                }}
            //VictoryConditions returns true while stack C does not have a count size equal to the difficulty size.
            static bool victoryConditions(Dictionary<String, Stack<int>> t, int size)
            {
                //initializes and un reverses a copy of towers C
                Stack<int> C = new Stack<int>();
                Stack<int> rev = new Stack<int>(t["C"]);
                while (rev.Count != 0)
                {
                    C.Push(rev.Pop());
                }
                //if the count of C is equal the size set when the user choose the difficulty then the user has achieved victory and it returns false which will break the games loop triggering victory.
                if(C.Count==size)
                    return false;
                return true;// returned while all values are not in the towers[C], continuing the games loop.
            }
        }

    }
