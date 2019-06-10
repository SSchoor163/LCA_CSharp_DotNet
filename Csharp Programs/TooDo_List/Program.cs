using System;
using System.Collections.Generic;

namespace TooDo_List
{
    class Program
    {

        static void Main(string[] args)
        {
            List<TooDo> list = new List<TooDo>(); //list of Toodo class
            int choice = 1, remove; //choice will be used to choose the menu item, remove will be used to remove a item from list
            while (choice != 3)
            {
                Console.Clear();
                Console.Write("Too Do Items\n");
                //prints the list of TooDo's
                if (list.Count > 0)
                {
                    Console.WriteLine("");
                    printList(list);
                    Console.WriteLine("");
                }
                choice = printMenu(); // displays menu system, gets user menu choice, validates menu choice, returns menu choice
                // 1 add item, 2 remove item, 3 close program
                if (choice == 1)
                {
                    SetList(ref list);//SetList gets the user to input data for the ToDoo then validates it.
                }
                else if (choice == 2)
                {// simply deletes an item from the list of ToDoo
                    Console.Write("Which Item would you like to delete: ");
                    try// catch when a user tries to enter a string into the int
                    {
                        remove = int.Parse(Console.ReadLine()) - 1;// list is displayed starting from 1, so remove is user entry -1
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("You tried to enter a Letter value for the Item. Please enter the task number in numerical format...");
                        remove = int.Parse(Console.ReadLine()) - 1
                    }
                    ValidateRemove(ref remove, list);// validates the users choice
                    list.RemoveAt(remove);//removes specific element in list
                }
                else continue;// if user enters 3, jumps to beging of loop and breaks it, closing the program
                Console.Write("Press any key to return to menu...");
                Console.ReadLine();

            }
        }
        //writes menu choices then gets the user choice, validates the choice then returns it to main
        static int printMenu()
        {
            int choice;
            Console.Write("1. Add a task\n" +
                          "2. Remove a Task\n" +
                          "3. Close Program\n" +
                          "Please enter 1,2, or 3...");
            choice = ValidateMenuItem(Console.ReadLine());
            return choice;
        }
        
        //collects and validates user data for the todo
        static void SetList(ref List<TooDo> x)
        {
            
                String title, priority; int day, month, year; DateTime due;
                Console.Clear();
                //gets title
                Console.Write("Please enter Task Name: ");
                title = Console.ReadLine();
                title = title.ToLower();
                //gets priority
                Console.Write("\nPlease enter priority of Low, medium, or high: ");
                priority = Console.ReadLine();
                priority = priority.ToLower();
            //gets due date, which is stored as a DataTime object
            try// if user enters in a string for the int value
            {
                GetDate();//collect date info
                ValidatEntry(ref day, ref month, ref year, ref priority); //validation
                due = new DateTime(year, month, day);
                // add entry to TooDo
                TooDo entry = new TooDo(title, due, priority);
                x.Add(entry);
            }
            catch (FormatException)
            {
                Console.WriteLine("Yout tried to enter a letter value for the due date. please you a numbered format...");
                GetDate();
            }
            //member function of this function to get Date Data, and is recalled in case of an exception
             void GetDate()
            {
                Console.Write("\nPlease Enter Due Date (DD:MM:YY)     \n" +
                    "Day(DD): ");
                day = int.Parse(Console.ReadLine());
                Console.Write("Month(MM): ");
                month = int.Parse(Console.ReadLine());
                Console.Write("Year(20YY): ");
                year = int.Parse(Console.ReadLine());
                year += 2000;
            }
        }
        //loops through the list of ToDoo starting at 1, using class member function datadump
        static void printList(List<TooDo> x)
        {
            for (int y = 1; y <= x.Count; y++)
            {
                Console.Write("Task #" + y + "     " + x[y - 1].DataDump());
            }
        }
        //validation. While menu item is not string 1,2 , or 3 ask again.
        static int ValidateMenuItem(string x)
        {
            while (x != "1" && x != "2" && x != "3")
            {
                Console.Write("Invalid Menu choice. Please enter 1 to add a too do item, 2 to remove a too do item, or 3 to exit the program...");
                x = Console.ReadLine();
            }
            return int.Parse(x);
        }
        /*TooDo entry validation. 
         * If month is not between 1 and 12, day is not between its respective number of days in that month, or the due data has already passed ask again.
          */
        static void ValidatEntry(ref int day, ref int month, ref int year, ref string priority)
        {
            // get correct month
            while (month < 1 || month > 12)
            {
                Console.Write("Invalid entry for month. Please choose a month 1-12...");
                month = int.Parse(Console.ReadLine());
            }
            //get correct day in month
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        while (day < 1 || day > 31)
                        {
                            Console.Write("Invalid entry for the month you entered. Please Enter a number 1-31...");
                            day = int.Parse(Console.ReadLine());
                        }
                        break;
                    }
                case 4:
                case 6:
                case 9:
                case 11:
                    {
                        while (day < 1 || day > 30)
                        {
                            Console.Write("Invalid entry for the month you entered. Please Enter a number 1-30...");
                            day = int.Parse(Console.ReadLine());
                        }
                        break;
                    }
                case 2:
                    {
                        while (day < 1 || day > 28)
                        {
                            Console.Write("Invalid entry for the month you entered. Please Enter a number 1-28...");
                            day = int.Parse(Console.ReadLine());
                        }
                        break;
                    }
            }
            DateTime temp = new DateTime(year, month, day);
            //check to make sure date is not past due
            if (DateTime.Compare(DateTime.Now, temp) > 0)
            {
                Console.Write("The date you entered is past due! Please enter a valid due date (DD:MM:YY)     \nDay(DD): ");
                day = int.Parse(Console.ReadLine());
                Console.Write("    Month(MM): ");
                month = int.Parse(Console.ReadLine());
                Console.Write("    Year(20YY): ");
                year = int.Parse(Console.ReadLine());
                year += 2000;
                ValidatEntry(ref day, ref month, ref year, ref priority);
            }
            //make sure priority is correct
            while (priority != "low" && priority != "medium" && priority != "high")
            {
                Console.Write("Invalid entry for priority you entered. Please enter low, medium, or high...");
                priority = Console.ReadLine();
            }
        }
        // verifies The task they want to remove is between 1 and the number of elements in the list
        static void ValidateRemove(ref int x, List<TooDo> y)
        {
            while (x + 1 < 1 || x + 1 > y.Count)
            {
                Console.Write("Invalid entry. Please enter a list item between 1 and " + y.Count + "...");
                x = int.Parse(Console.ReadLine()) - 1;
            }
        }

        class TooDo
        {
            String Title { get; }
            DateTime DueDate { get; }
            String Priority { get; }
            //constructor
            public TooDo(String title, DateTime time, String pri)
            {
                Title = title;
                Priority = pri;
                DueDate = time;
            }
            //returns the data in the toodo item in a single line
            public string DataDump()
            {
                return "Task: " + Title + "     Priority: " + Priority + "     Due Date: " + DueDate.ToShortDateString() + "\n";
            }
        }

    }
}
