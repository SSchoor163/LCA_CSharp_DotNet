using System;
using System.Collections.Generic;
using System.Text;

namespace Todo_Application
{
    class App
    {
        int Menu { get; set; }
        Sort Order { get; set; }
        public App()
        {
            Order = Sort.Pending;
            ConsoleUtilities.LinkDatabase();
            Menu = ConsoleUtilities.MainMenu();
            while (Menu != 6)
            {
                switch (Menu)
                {
                    case 1:
                        ConsoleUtilities.MenuCreateTodo();
                        break;
                    case 2:
                        ConsoleUtilities.MenuDeleteTodo();
                        break;
                    case 3:
                        ConsoleUtilities.EditMenu();
                        break;
                    case 4:
                        ConsoleUtilities.MenuCompleteTodo();
                        break;
                    case 5:
                        Order = ConsoleUtilities.SetSort(Order);
                        break;
                }
                Console.Clear();
                ConsoleUtilities.SetDisplay(Order);
                Menu = ConsoleUtilities.MainMenu();
            }
        }
        
    }
}
