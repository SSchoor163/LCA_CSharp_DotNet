using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Todo_Application
{
    class TodoController: DbContext
    {
        public DbSet<Todo> Todos { get; set; } //Local copy of database

        //Database link
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);
            DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;
            string DatabaseFile = Path.Combine(ProjectBase.FullName, "Todo.db");
            optionsBuilder.UseSqlite("Data Source =" + DatabaseFile);
        }
        //display Todo by title
        public void DisplayByTitle()
        {
            
            List<Todo> TempList = new List<Todo>(); // new list of Todo
            Todo Temp;

            foreach(Todo item in Todos)
            {
                TempList.Add(item);
            }
            List<Todo> SortedList = TempList.OrderBy(o => o.Title).ToList();
            int i,n;
            n = TempList.Count;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                foreach(Todo j in TempList)
                {foreach(Todo k in TempList)
                    if (k.Title > j.Title)
                    {
                        // swap arr[j] and arr[j+1] 
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                // IF no two elements were  
                // swapped by inner loop, then break 
                if (swapped == false)
                    break;
            }
        }
    }
}
