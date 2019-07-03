using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Todo_Application
{
    class ItemRepository
    {
        public static TodoController Control = new TodoController();
        public static DateTime GetDate()
        {
            int Year, Month, Day;
            DateTime Due;
            do
            {
                Console.WriteLine("Please Enter year...");
                Year = Validation.ValidationStringtoInt(Console.ReadLine());
                Console.WriteLine("Please Enter Month...");
                Month = Validation.ValidationStringtoInt(Console.ReadLine());
                Month = Validation.ValidationMonthInYear(Month);
                Console.WriteLine("Please Enter Day...");
                Day = Validation.ValidationStringtoInt(Console.ReadLine());
                Day = Validation.ValidationDayInMonth(Month, Day);
                Due = new DateTime(Year, Month, Day);
                if (Due < DateTime.Now)
                {
                    Console.WriteLine("Invalid entry. The Date you entered has already passed. Please enter a future date.");
                }
            } while (Due < DateTime.Now);
            return Due;
        }
        public static void CreateTodo()//TODO transfer user inputs to console utility
        {
         
            string Title, Description, PriorityBool, DueBool;
            Priority Priority = Priority.none;
            DateTime Due = DateTime.Now;
            Todo Temp;
            Console.WriteLine("Enter a title for the Todo item");
            Title = Console.ReadLine();
            Console.WriteLine("Enter a description for the Todo item");
            Description = Console.ReadLine();
            Console.WriteLine("Would you like to set a priority for the Todo item? (y/n)...");
            PriorityBool = Console.ReadLine();
            PriorityBool = Validation.ValidationStringYN(PriorityBool.ToLower());
            if(PriorityBool == "y")
            {
                Priority = ConsoleUtilities.PriorityMenu();
            }
            Console.WriteLine("Would you like to set a due date for your Todo item? (y/n)...");
            DueBool = Console.ReadLine();
            DueBool = Validation.ValidationStringYN(DueBool.ToLower());
            if(DueBool == "y")
            {
                Due = GetDate();
            }
            if (PriorityBool == "n" && DueBool == "n")
            {
                Temp = new Todo(Title, Description);
            }
            else if(PriorityBool == "y" && DueBool == "n")
            {
                Temp = new Todo(Title, Description, Priority);
            }
            else if(PriorityBool == "n" && DueBool == "y")
            {
                Temp = new Todo(Title, Description, Due);
            }
            else
            {
                Temp = new Todo(Title, Description, Due, Priority);
            }
           Control.Todos.Add(Temp);
           Control.SaveChanges();
        }

        public static void DeleteTodo()
        {
            //TODO move user input to static functions
            Console.WriteLine("Please enter the Id of the Todo you wish to delete.");
            int choice = Validation.ValidationStringtoInt(Console.ReadLine());
            Control.Todos.Remove(Control.Todos.Find(choice));
            Control.SaveChanges();
        }
        public static void Display(Sort Sort)
        {
            if (Sort == Sort.ID)
            {
                foreach (Todo T in Control.Todos)
                {
                    T.DisplayTodo();
                }
            }
            else if (Sort == Sort.Pending)
            {
                foreach (Todo T in Control.Todos.Where(T => T.Complete == false))
                {
                    T.DisplayTodo();
                }
            }
            else if (Sort == Sort.Complete)
            {
                foreach (Todo T in Control.Todos.Where(T => T.Complete == true))
                {
                    T.DisplayTodo();
                }
            }
            else if (Sort == Sort.DateAscending)
            {
                foreach (Todo T in Control.Todos.OrderBy(T => T.Due))
                {
                    T.DisplayTodo();
                }
            }
            else if (Sort == Sort.DateDecending)
            {
                foreach (Todo T in Control.Todos.OrderByDescending(T => T.Due))
                {
                    T.DisplayTodo();
                }
            }
            else if (Sort == Sort.PritorityAscending)
            {
                foreach (Todo T in Control.Todos.OrderBy(T => T.Priority))
                {
                    T.DisplayTodo();
                }
            }
            else if (Sort == Sort.PriorityDescending)
            {
                foreach (Todo T in Control.Todos.OrderByDescending(T => T.Priority))
                {
                    T.DisplayTodo();
                }
            }
        }
        public static void EditTodo()
        {
            Console.WriteLine("Please enter the Id of the item you want to edit...\n");
            int IdChoice = Validation.ValidationStringtoInt(Console.ReadLine());
            Console.Clear();
            Control.Todos.Find(IdChoice).DisplayTodo();
            Console.WriteLine("What Field do you wish to edit?");
            int EditChoice = ConsoleUtilities.EditMenu();
            switch(EditChoice)
            {
                case 1:
                    Console.WriteLine("Please enter a new title");
                    Control.Todos.Find(IdChoice).Title = Console.ReadLine();
                    Control.SaveChanges();
                    break;
                case 2:
                    Console.WriteLine("Please enter a new Description");
                    Control.Todos.Find(IdChoice).Description = Console.ReadLine();
                    Control.SaveChanges();
                    break;
                case 3:
                    if (Control.Todos.Find(IdChoice).Complete == true)
                        Control.Todos.Find(IdChoice).Complete = false;
                    else Control.Todos.Find(IdChoice).Complete = true;
                    Control.SaveChanges();
                    break;
                case 4:
                    Control.Todos.Find(IdChoice).Due = GetDate();
                    Control.Todos.Find(IdChoice).HasDue = true;
                    Control.Todos.Find(IdChoice).GetDueStatus();
                    Control.SaveChanges();
                    break;
                case 5:
                    Control.Todos.Find(IdChoice).Priority = ConsoleUtilities.PriorityMenu();
                    Control.SaveChanges();
                    break;
                case 6:
                    break;
            }   
        }
        public static void CompleteTodo()
        {
            Console.WriteLine("Please enter the items Id...");
            int Choice = Validation.ValidationStringtoInt(Console.ReadLine());
            Control.Todos.Find(Choice).Complete = true;
        }
    }
}
