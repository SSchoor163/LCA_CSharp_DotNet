using System;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace entities_framwork_practice
{
    
    
    class Program
    {
        static void Main(string[] args)
        {
            StudentContext context = new StudentContext();
            context.Database.EnsureCreated();
            Console.WriteLine("Write Student Full Name");
            string FullName = Console.ReadLine();
            String[] parts = FullName.Split();
            if(parts.Length == 2)
            {
                Student newStudent = new Student(parts[0], parts[1]);
                context.students.Add(newStudent);
                context.SaveChanges();
                Console.WriteLine("Added the Student");
            }
            else
            {
                Console.WriteLine("Invalid full name, did not add student");
            }
            Console.WriteLine("Current list of students are: ");
            foreach(Student s in context.students)
            {
                Console.WriteLine($"{s.Id} - {s.FirstName} {s.LastName}");
            }
        }
    }
}
