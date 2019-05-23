using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MasterMind_Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] colors = { "red", "blue", "green"};
            
            int length = colors.GetLength(0);
            Random generator = new Random();
            // creates a number 0,1 or 2
            int x = generator.Next(0, 3);
            int y = generator.Next(0, 3);
            //int x = 0, y = 0;
            string userX, userY;
            bool game = true;
            int condition = 0;
            int turns = 0;
            Console.Write("Mastermind!\n" +
                          "The computer will choose two colors Red, blue, or green.\n" +
                          "You must guess the correct colors and the correct placement first, and second.\n" +
                          "If neither color nor placement are correct the computer will say 0-0\n" +
                          "If one color is correct but in the wrong place the computer will say 1-0\n" +
                          "if one color is correct and in the correct position the computer will say 1-1\n" +
                          "if both colors are correct but in the wrong positions the computer will say 2-0\n" +
                          "If you guess both correctly and in the correct positions the computer will say 2-2 and you win!\n");
            while(game) {
                turns++;
                
                Console.Write("Please enter your first color: ");
                userX = Console.ReadLine();
                userX = userX.ToLower();
                while(userX != "red" && userX != "blue" && userX != "green")
                {
                    Console.Write("Invalid input. Please enter red, blue, or green");
                    userX = Console.ReadLine();
                    userX = userX.ToLower();
                }
                Console.Write("Please enter your second color: ");
                userY = Console.ReadLine();
                userY = userY.ToLower();
                while (userY != "red" && userY != "blue" && userY != "green")
                {
                    Console.Write("Invalid input. Please enter red, blue, or green");
                    userY = Console.ReadLine();
                    userY = userY.ToLower();
                }
                condition = eval(colors[x], colors[y], userX, userY);
                switch (condition)
                {
                    case 0: {
                            Console.WriteLine("0-0");
                            break;
                        }
                    case 1: {
                            Console.WriteLine("1-0");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("1-1");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("0-2");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("2-2");
                            Console.WriteLine("You won in " +turns+ " turns!");
                            game = false;
                            break;
                        }

                }
                
            }
            Console.ReadLine();

        }
       

       static int eval(string x, string y, string userX, string userY)
        {
            if ((userX != x && userX!= y) && (userY != x && userY!= y))
            {
                 return 0;
            }
            else if(userX == y && userY == x)
            {
                if(userX == x && userY == y) { return 4; }
                    else return 3;
            }
            else if (userX == x && userY != y)
            {
                return 2;
            }
            else if (userX != x && userY == y)
            {
                return 2;
            }
            else if(userX == y)
            {
                return 1;
            }
            else if(userY == x)
            {
                return 1;
            }
            else if (userX == x && userY != y)
            {
                return 2;
            }
            else if(userX != x && userY == y)
            {
                return 2;
            }
            else if(userX == x && userY == y)
            {
                return 4;
            }
            return 0;
        }
    }
}
