using System;
using System.Collections.Generic;
using System.Text;
//TODO Rename to COnsole Utility
namespace Todo_Application
{
    class ConsoleUtilities
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
            int choice = Validation.ValidationStringtoInt(Console.ReadLine()); // set choice to user menu choice of type int
            choice = Validation.ValidationMenu(choice, 6); //ensures choice is between 1 and 8
            return choice;
        }
        public static Priority PriorityMenu()
        {
            Console.Write($"Please select your pritoirty level.\n" +
                          $"-----------------------------\n" +
                          $"1. Low\n" +
                          $"2. Medium\n" +
                          $"3. High\n");
            int choice = Validation.ValidationStringtoInt(Console.ReadLine()); // set choice to user menu choice of type int
            choice = Validation.ValidationMenu(choice, 3); //ensures choice is between 1 and 3
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
            int choice = Validation.ValidationStringtoInt(Console.ReadLine()); // set choice to user menu choice of type int
            choice = Validation.ValidationMenu(choice, 7); //ensures choice is between 1 and 8
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
            int choice = Validation.ValidationStringtoInt(Console.ReadLine()); // set choice to user menu choice of type int
            choice = Validation.ValidationMenu(choice, 6); //ensures choice is between 1 and 8
            return choice;
        }
       
        public static void LinkDatabase()
        {
            ItemRepository.Control.Database.EnsureCreated();
        }
       public static void SetDisplay(Sort Order)
        {
            
            ItemRepository.Display(Order);
        }
        public static void MenuCreateTodo()
        {
            ItemRepository.CreateTodo();
        }
        public static void MenuDeleteTodo()
        {
            ItemRepository.DeleteTodo();
        }
        public static void MenuEditTodo()
        {
            ItemRepository.EditTodo();
        }
        public static void MenuCompleteTodo()
        {
            ItemRepository.CompleteTodo();
        }
    }
}

