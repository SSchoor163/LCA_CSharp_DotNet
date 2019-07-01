using System;
using System.Collections.Generic;
using System.Text;

namespace Todo_Application
{
    class StaticFunctions
    {
        //writes Main Menu, retrieves user menu choice, and returns corresponding menu choice
        static public int MainMenu()
        {
            Console.Write($"Todo Organizer\n" +
                          $"-----------------------------\n" +
                          $"1. Create new Todo item\n" +
                          $"2. Delete existing Todo item\n" +
                          $"3. Edit existing Todo item\n" +
                          $"4. Sort Todo items\n" +
                          $"5. Display pending Todo items\n" +
                          $"6. Display Complete Todo items\n" +
                          $"7. Display all Todo items\n" +
                          $"8. Exit program\n");
            int choice = ValidationStringtoInt(Console.ReadLine()); // set choice to user menu choice of type int
            choice = ValidationMainMenu(choice); //ensures choice is between 1 and 8
            return choice;
        }
        //ensures user input is in the form of a number
        static int ValidationStringtoInt(string UserInput)
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
        static int ValidationMainMenu(int choice)
        {
            while (choice < 1 || choice > 8) {
                Console.WriteLine("Invalid menu choice. Please enter a number between 1 and 8 with respect to the menu...");
                choice = ValidationStringtoInt(Console.ReadLine());
            }
            return choice;
        }
    }
}

