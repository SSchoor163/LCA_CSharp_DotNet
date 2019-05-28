using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towers_of_Hanoi
{

    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<char, Stack<int>> towers = new Dictionary<char, Stack<int>>();
            Dictionary<char, Stack<int>> towers2 = new Dictionary<char, Stack<int>>();
            towers.Add('A', new Stack<int> { });
            char move, moveTo;
            for (int x = 4; x > 0; x--)
            {
                towers['A'].Push(x);
            } towers2.Add('A', towers['A']);
            towers.Add('B', new Stack<int> { }); towers2.Add('B', towers['B']);
            towers.Add('C', new Stack<int> { }); towers2.Add('C', towers['C']);

            Console.WriteLine("Towers of Hanoi");
            Console.Write("Rules: You must get each number in tower A into tower C\n" +
                          "You may move only one number at a time, and a higher number can not sit atop a lower number.\n");
            printboard(towers2);
            Console.Write("Select A, B, or C to choose a piece...");
            move = char.ToUpper(char.Parse(Console.ReadLine()));// add exception validation
            while (move != 'A' && move != 'B' && move != 'C')
            {
                Console.WriteLine("invalid Choice. please choose again(A, B, or C)...");
                move = char.ToUpper(char.Parse(Console.ReadLine()));
            }
            Console.Write("Select A, B, or C to move the piece...");
            moveTo = char.ToUpper(char.Parse(Console.ReadLine()));
            while (moveTo != 'A' && moveTo != 'B' && moveTo != 'C')
            {
                Console.WriteLine("invalid Choice. please choose again(A, B, or C)...");
                moveTo = char.ToUpper(char.Parse(Console.ReadLine()));
            }
            towers[moveTo].Push(towers[move].Pop());
            printboard(towers2);
            Console.Read();
        }

        static void printboard(Dictionary<char, Stack<int>> t)
        {
            Stack<int> A = t['A'];
            Stack<int> B = t['B'];
            Stack<int> C = t['C'];


            for (int y = 0; y < 5; y++)
            {
                if (y == 4)
                {
                    Console.Write("----------\n" +
                                  "A   B   C\n");
                }
                else
                {
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
            }
        }
            /*     static void printboard(Dictionary<char, Stack<int>> t)
                 {
                     Stack<int> A = t['A'];
                     Stack<int> B = t['B'];
                     Stack<int> C = t['C'];


                     for (int y = 0; y < 5; y++)
                     {
                         if (y == 4)
                         {
                             Console.Write("----------\n" +
                                           "A   B   C\n");
                         }
                         else
                         {
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
                     }


                 }*/

            static bool victoryConditions()
            {
                return false;
            }
        }

    }
