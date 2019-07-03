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
            App app = new App();
            
           
        }
    }
}//TODO make and validate against a list of valid ID's
