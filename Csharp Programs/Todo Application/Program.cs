using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
namespace Todo_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            int Menu = StaticFunctions.MainMenu();
            switch (Menu)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
            }
            TodoController control = new TodoController();
            using (control)
            {
                var SortByTitle = control.Todos.
            }
        }
    }
}
