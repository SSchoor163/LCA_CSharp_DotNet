using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerChoice, compChoice, playerWin = 0, compWin = 0;
            string replay = "y";
            Console.WriteLine("Rock Paper Scissors!");
            while (replay == "y")
            {
                outPut();
                playerChoice = int.Parse(Console.ReadLine());
                while (playerChoice != 1 && playerChoice != 2 && playerChoice != 3)
                {
                    Console.WriteLine("Invalid choice. Please choose 1-3");
                    playerChoice = int.Parse(Console.ReadLine());
                }
                Random generator = new Random();
                // creates a number 1,2 or 3
                int randomNumber = generator.Next(1, 4);
                compChoice = randomNumber;
                if(Compare(playerChoice, compChoice))
                {
                    playerWin++;
                }
                else
                {
                    compWin++;
                }
                Console.WriteLine("player Score: " + playerWin);
                Console.WriteLine("Computer Score: " + compWin);
                Console.WriteLine("Would you like to play again? (y/n)");
                replay = Console.ReadLine();
                replay = replay.ToLower();
                while(replay != "y" && replay != "n")
                {
                    Console.WriteLine("Invalid input. Please enter y to replay or n to quite.");
                    replay = Console.ReadLine();
                    }
            }
        }

        static void outPut()
        {
            Console.WriteLine("Player choose your weapon!");
            Console.WriteLine("Enter choice 1-3");
            Console.WriteLine("1-Rock");
            Console.WriteLine("2 - Paper");
            Console.WriteLine("3 - Scissors");
        }

        static bool Compare(int x, int y)
        {
            switch (x)
            {
                case 1:
                    {
                        if (y == 1)
                        {
                            Console.WriteLine("Computer chooses Rock!");
                            return (tie(x, y));
                             }
                        else if (y == 2)
                        {
                            Console.WriteLine("Computer chooses Paper!");
                            lose();
                            return false;
                        }
                        else
                        {
                            Console.WriteLine("Computer chooses Scissors!");
                            win();
                            return true;
                        }
                        break;
                    }
                case 2:
                    {
                        if (y == 1)
                        {
                            Console.WriteLine("Computer chooses Rock!");
                            win();
                            return true;
                        }
                        else if (y == 2)
                        {
                            Console.WriteLine("Computer chooses Paper!");
                            return (tie(x, y));
                        }
                        else
                        {

                            Console.WriteLine("Computer chooses Scissors!");
                            lose();
                            return false;
                        }
                        break;
                    }

                case 3:
                    {
                        if (y == 1)
                        {
                            Console.WriteLine("Computer chooses Rock!");
                            lose();
                            return false;
                        }
                        else if (y == 2)
                        {
                            Console.WriteLine("Computer chooses Paper!");
                            win();
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Computer chooses Scissors!");
                            return (tie(x, y));

                        }
                            break;
                    }
                    

            }
            return false;
        }
        static bool tie(int x, int y) {
            Console.WriteLine("Tied! Choose again!");
            outPut();
            x = int.Parse(Console.ReadLine());
            while (x != 1 && x != 2 && x != 3)
            {
                Console.WriteLine("Invalid choice. Please choose 1-3");
                x = int.Parse(Console.ReadLine());
            }
            Random generator = new Random();
            // creates a number 1,2 or 3
            int randomNumber = generator.Next(1, 4);
            y = randomNumber;
            if (Compare(x, y))
            {
                return true;
            }
            else return false;
        }
        static void win( ) {
            Console.WriteLine("Win! Congratulations.");
            
        }
        static void lose() {
            Console.WriteLine("Loose! Sorry.");
           
        }
    }




}
