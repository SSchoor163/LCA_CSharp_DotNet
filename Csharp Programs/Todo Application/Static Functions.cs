using System;
using System.Collections.Generic;
using System.Text;
//TODO Rename to COnsole Utility
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
                          $"4. Mark todo as complete\n" +
                          $"5. Sort Todo items\n" +
                          $"6. Exit program\n");
            int choice = ValidationStringtoInt(Console.ReadLine()); // set choice to user menu choice of type int
            choice = ValidationMenu(choice, 6); //ensures choice is between 1 and 8
            return choice;
        }
        public static Priority PriorityMenu()
        {
            Console.Write($"Please select your pritoirty level.\n" +
                          $"-----------------------------\n" +
                          $"1. Low\n" +
                          $"2. Medium\n" +
                          $"3. High\n");
            int choice = ValidationStringtoInt(Console.ReadLine()); // set choice to user menu choice of type int
            choice = ValidationMenu(choice, 3); //ensures choice is between 1 and 3
            if (choice == 1)
                return Priority.low;
            else if (choice == 2)
                return Priority.medium;
            else return Priority.high;
        }

        public static Sort SetSort(Sort Order)
        {
            Console.Write($"Select how you would like your list displayed\n" +
                           $"-----------------------------\n" +
                           $"Display is currently set to {Order}\n" +
                           $"1. Id\n" +
                           $"2. Pending Items\n" +
                           $"3. Completeted items\n" +
                           $"4. Date (Ascending)\n" +
                           $"5. Date (Descending)\n" +
                           $"6. Priority (Ascending)\n" +
                           $"7. Priority (Descending)\n" );
            int choice = ValidationStringtoInt(Console.ReadLine()); // set choice to user menu choice of type int
            choice = ValidationMenu(choice, 7); //ensures choice is between 1 and 8
            switch (choice)
            {
                case 1:
                    Order = Sort.ID;
                    break;
                case 2:
                    Order = Sort.Pending;
                    break;
                case 3:
                    Order = Sort.Complete;
                    break;
                case 4:
                    Order = Sort.DateAscending;
                    break;
                case 5:
                    Order = Sort.DateDecending;
                    break;
                case 6:
                    Order = Sort.PritorityAscending;
                    break;
                case 7:
                    Order = Sort.PriorityDescending;
                    break;
            }
            return Order;
        }
        static public int EditMenu()
        {
            Console.Write($"Which field do you wish to edit?\n" +
                          $"-----------------------------\n" +
                          $"1. Title\n" +
                          $"2. Description\n" +
                          $"3. Toggle Pending/Complete\n" +
                          $"4. Due Date\n" +
                          $"5. Priority\n" +
                          $"6. Return to Main Menu\n");
            int choice = ValidationStringtoInt(Console.ReadLine()); // set choice to user menu choice of type int
            choice = ValidationMenu(choice, 6); //ensures choice is between 1 and 8
            return choice;
        }
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
        static int ValidationMenu(int choice, int MaxChoices)
        {
            while (choice < 1 || choice > MaxChoices) {
                Console.WriteLine($"Invalid menu choice. Please enter a number between 1 and {MaxChoices} with respect to the menu...");
                choice = ValidationStringtoInt(Console.ReadLine());
            }
            return choice;
        }
        public static string ValidationStringYN(string Choice)
        {
            while(Choice != "y" && Choice != "n")
            {
                Console.WriteLine("Invalid input. Please enter y for yes and n for no to continue.");
                Choice = Console.ReadLine();
                Choice = Choice.ToLower();
            }
            return Choice;
        }
       
    }
}

