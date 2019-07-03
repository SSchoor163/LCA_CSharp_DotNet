using System;
using System.Collections.Generic;
using System.Text;

namespace Todo_Application
{
    class Validation
    {
        //ensures user input is in the form of a number
        public static int ValidationStringtoInt(string UserInput)
        {
            try
            {
                return int.Parse(UserInput); // return int if number
            }
            catch (FormatException)// if not number recusive call until a number is entered
            {
                Console.WriteLine("Invalid menu choice. Please enter a numerical value...");
                return ValidationStringtoInt(Console.ReadLine());
            }

        }
        public static int ValidationMenu(int choice, int MaxChoices)
        {
            while (choice < 1 || choice > MaxChoices)
            {
                Console.WriteLine($"Invalid menu choice. Please enter a number between 1 and {MaxChoices} with respect to the menu...");
                choice = ValidationStringtoInt(Console.ReadLine());
            }
            return choice;
        }
        public static string ValidationStringYN(string Choice)
        {
            while (Choice != "y" && Choice != "n")
            {
                Console.WriteLine("Invalid input. Please enter y for yes and n for no to continue.");
                Choice = Console.ReadLine();
                Choice = Choice.ToLower();
            }
            return Choice;
        }
        public static int ValidationMonthInYear(int Month)
        {
            while (Month < 1 || Month > 12)
            {
                Console.WriteLine("Invalid entry for the month of the year. Please enter a number 1-12...");
                Month = ValidationStringtoInt(Console.ReadLine());
            }
            return Month;
        }
        public static int ValidationDayInMonth(int Month, int Day)
        {
            switch (Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        while (Day < 1 || Day > 31)
                        {
                            Console.Write("Invalid entry for the month you entered. Please Enter a number 1-31...");
                            Day = ValidationStringtoInt(Console.ReadLine());
                        }
                        break;
                    }
                case 4:
                case 6:
                case 9:
                case 11:
                    {
                        while (Day < 1 || Day > 30)
                        {
                            Console.Write("Invalid entry for the month you entered. Please Enter a number 1-30...");
                            Day = ValidationStringtoInt(Console.ReadLine());
                        }
                        break;
                    }
                case 2:
                    {
                        while (Day < 1 || Day > 28)
                        {
                            Console.Write("Invalid entry for the month you entered. Please Enter a number 1-28...");
                            Day = ValidationStringtoInt(Console.ReadLine());
                        }
                        break;
                    }
            }
            return Day;
        }
    }
}
