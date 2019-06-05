using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TooDo_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TooDo> list= new List<TooDo>();
            int choice = 1, remove;
            while(choice != 3)
            {
                Console.Write("Too Do Items\n");
                choice = printMenu();
                if(choice == 1)
                {
                    SetList(ref list);
                }
                else if(choice == 2)
                {
                    Console.Write("Which Item would you like to delete: ");
                    remove = int.Parse(Console.ReadLine());
                    ValidateRemove();
                    list.RemoveAt(remove);
                }
                printList(list);
                Console.Write("Press any key to return to menu...");
                Console.Read();

            }
        }
        static int printMenu()
        {
            int choice;
            Console.Write("1. Add a task\n" +
                          "2. Remove a Task\n" +
                          "3. Close Program\n" +
                          "Please enter 1,2, or 3...");
            choice = ValidateMenuItem(int.Parse(Console.ReadLine()));
            return choice;
        }
        static void SetList(ref List<TooDo> x)
        {
            String title, priority, duet; DateTime due;
            Console.Clear();
            Console.Write("Please enter Task Name: ");
            title = Console.ReadLine();
            Console.Write("\nPlease enter priority of Low, medium, or high: ");
            priority = Console.ReadLine();
            Console.Write("\nPlease Enter Due Date format (ddmmyyyy)...");
            duet = Console.ReadLine();
            due = DateTime.ParseExact(duet, "ddmmyyyy", System.Globalization.CultureInfo.InvariantCulture);
            ValidatEntry();
            TooDo entry = new TooDo(title, due, priority);
            x.Add(entry);
        }
        static void printList(List<TooDo> x)
        {

        }
        static int ValidateMenuItem(int x)
        {
            return 0;
        }
        static string ValidatEntry()
        {
            return null;
        }
        static string ValidateRemove()
        {
            return null;
        }

        class TooDo
        {
            String Title { get;}
            DateTime DueDate { get;}
            String Priority { get; }

            public TooDo(String title, DateTime time, String pri)
            {

            }
            public string DataDump()
            {
                return null;
            }
        }

    }
}
