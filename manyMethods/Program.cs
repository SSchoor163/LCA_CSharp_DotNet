using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W1D1_CSharp_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Hello();
            addition();
            catDog();
            oddEvent();
            inches();
            echo();
            killGrams();
            date();
            age();
            guess();
            Console.Read();
        }


        static void Hello()
        {
            string firstName;
            Console.WriteLine("Hello, what is you name?");
            firstName = Console.ReadLine();
            Console.WriteLine("Good bye " + firstName);
            Console.WriteLine();
        }

        static void addition()
        {
            int numb1, numb2;
            Console.WriteLine("Time for addition.");
            Console.WriteLine("Please enter an integer...");
            numb1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter second integer...");
            numb2 = int.Parse(Console.ReadLine());
            Console.WriteLine(numb1 + numb2);
            Console.WriteLine();
        }

        static void catDog()
        {
            string catDog;
            Console.WriteLine("Do you prefer cats? or dogs?");
            catDog = Console.ReadLine();
            if (catDog == "cats")
            {
                Console.WriteLine("Meow!");
            }
            else { Console.WriteLine("Bark!"); }
            Console.WriteLine();

        }

        static void oddEvent()
        {
            int oddOrEven;
            Console.WriteLine("Please enter an odd or even number.");
            oddOrEven = int.Parse(Console.ReadLine());
            if (oddOrEven % 2 == 1)
            {
                Console.WriteLine("Number is odd.");
            }
            else
            {
                Console.WriteLine("Number is Even.");
            }
            Console.WriteLine();
        }

        static void inches()
        {
            const int convert = 12;
            double feet;
            Console.WriteLine("Please enter a height in feet");
            feet = double.Parse(Console.ReadLine());
            Console.WriteLine("The height you entered is " + feet * convert + " inches");
            Console.WriteLine();
        }

        static void echo()
        {
            Console.WriteLine("Please Enter a word...");
            string echo = Console.ReadLine();
            Console.WriteLine(echo.ToUpper());
            Console.WriteLine(echo.ToLower());
            Console.WriteLine(echo.ToLower());
            Console.WriteLine();
        }

        static void killGrams()
        {
            Console.WriteLine("Please enter a weight in pounds...");
            double weight = double.Parse(Console.ReadLine());
            const double convert = 2.205;
            weight = weight / convert;
            weight = Math.Round(weight, 3);
            Console.WriteLine("Weight in Kilograms is " + weight + "kg");
            Console.WriteLine();
        }
        static void date()
        {
            DateTime datew = DateTime.UtcNow.Date;
            Console.WriteLine("today's Date is " + datew.ToString("d"));
            Console.WriteLine();
        }

        static void age()
        {
            Console.WriteLine("Please Enter the year you were born...");
            int birth = int.Parse(Console.ReadLine());
            DateTime current = DateTime.UtcNow.Date;
            int year = current.Year;
            int result = year - birth;
            Console.WriteLine("You are " + result + " years old");
            Console.WriteLine();
        }

        static void guess()
        {
            Console.WriteLine("Guess a word...");
            const string correct = "csharp";
            string guess = Console.ReadLine();
            while (guess != correct)
            {
                Console.WriteLine("Wrong! Guess again...");
                guess = Console.ReadLine();
            }
            Console.WriteLine("Correct!");
        }
    }


}
