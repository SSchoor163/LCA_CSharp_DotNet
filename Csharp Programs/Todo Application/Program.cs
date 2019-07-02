using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
namespace Todo_Application
{
    enum Priority { none, low, medium, high }
    enum Sort { ID, Pending, Complete, DateAscending, DateDecending, PritorityAscending, PriorityDescending}
    class Program
    {
        static void Main(string[] args)
        {
            ITemRepository.Control.Database.EnsureCreated();
            Sort Order = Sort.Pending;
            ITemRepository.Display(Order);
            int Menu = StaticFunctions.MainMenu();
            while (Menu != 6) {
                switch (Menu)
                    {
                        case 1:
                            ITemRepository.CreateTodo();
                            break;
                        case 2:
                            ITemRepository.DeleteTodo();
                            break;
                        case 3:
                            ITemRepository.EditTodo();
                            break;
                        case 4:
                            ITemRepository.CompleteTodo();
                            break;
                        case 5:
                            Order = StaticFunctions.SetSort(Order);
                            break;
                    }
                Console.Clear();
                ITemRepository.Display(Order);
                Menu = StaticFunctions.MainMenu();
            }
            
           
        }
    }
}//TODO make and validate against a list of valid ID's
