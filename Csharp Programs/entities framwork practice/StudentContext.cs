using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace entities_framwork_practice
{
    class StudentContext : DbContext
    {
        public DbSet<Student> students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);
            //DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;
            //string DatabaseFile = Path.Combine(ProjectBase.FullName, "students.db");
            //Console.WriteLine("using database file :" + DatabaseFile);
            //optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\Steven Schoor\Documents\DevFolder\LCA_CSharp_DotNet\Csharp Programs\entities framwork practice\students.db");
        }
    }
}
