using System;
using System.Collections.Generic;
using System.Text;

namespace Todo_Application
{
    
    class Todo
    {
        public int Id { get; private set; }
        public bool Complete { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool HasDue { get; set; }
        public DateTime Due { get; set; }
        public bool NearDue { get; set; }
        public bool PastDue { get; set; }
        public Priority Priority{get; set;}
        //Basic Constructor
        public Todo(string Title, string Description)
        {
            Complete = false;
            this.Title = Title;
            this.Description = Description;
            this.HasDue = false;
            Priority = Priority.none;
        }
        //Basic constructor plus Due, and detirmine if near due or past due
        public Todo(string Title, string Description, DateTime Due)
        {
            Complete = false;
            this.Title = Title;
            this.Description = Description;
            this.Due = Due;
            HasDue = true;
            GetDueStatus();
            Priority = Priority.none;
        }
        //Basic constructor plus Priority
        public Todo(string Title, string Description, Priority Priority)
        {
            Complete = false;
            this.Title = Title;
            this.Description = Description;
            this.Priority = Priority;
            this.HasDue = false;
        }
        //Basic Constructor plus Due, dietirmin if near due or past due, and priority
        public Todo(string Title, string Description, DateTime Due, Priority Priority)
        {
            Complete = false;
            this.Title = Title;
            this.Description = Description;
            this.Due = Due;
            HasDue = true;
            GetDueStatus();
            this.Priority = Priority;
        }
        //detirmine if due is past due, or near due. If Due is not set do nothing
        public void GetDueStatus()
        {
            
                if (Due.Day >= (DateTime.Now.Day - 1) && Due.Day > DateTime.Now.Day)
                {
                    NearDue = true;
                    PastDue = false;
                }
                else if (Due.Day > DateTime.Now.Day)
                {
                    NearDue = false;
                    PastDue = true;
                } 
        }
        //Display Todo information
        public void DisplayTodo()
        {
            String Marker, Time;
            if (Complete) { Marker = "Complete"; } else { Marker = "Pending"; }// if complete display complete, else display pending
            if (HasDue) Time = Due.ToShortDateString(); else Time = ""; // if there is a due date display it, otherwise display nothing
            if (Priority == Priority.medium) Console.ForegroundColor = ConsoleColor.DarkYellow; // if priority is set to medium, set text color to dark yellow
            else if (Priority == Priority.high) Console.ForegroundColor = ConsoleColor.Red;//if priority is set to high set text color to red
            Console.Write($"------------------------------------------------------------------------------\n" +
                          $"{Id}. [ {Marker} ]     {Title}          \n" +
                          $"{Description}\n" +
                          $"Due: {Time}        ");
            if (PastDue)// if past due is true say so
            {
                Console.Write("Todo is past due!");
            }else if (NearDue)//if near due is true say so
            {
                Console.Write("Todo is nearly due!");
            }
            Console.Write("\n" +
                          "Priority: ");
            if(Priority != Priority.none)// if priority is not none display it
            {
                Console.Write($"{Priority}\n");
            }
            else Console.Write("\n");
            Console.Write("------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }
    }
}
