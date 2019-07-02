using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;

namespace Todo_Application
{//TODO rename
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
            

            foreach(Todo item in Todos)
            {
                TempList.Add(item);
            }
            List<Todo> SortedList = TempList.OrderBy(o => o.Title).ToList();
            
            
        }
    }
}
