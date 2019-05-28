using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// add input validation for multiple instances of the same key
namespace Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = null;
            Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();
            Console.WriteLine("Student Gradebook");
            Console.WriteLine("Please enter student name, or enter Quit to finalize data.");
            name = Console.ReadLine();
            
            while (name.ToLower() != "quit")
            {

                string grade1;
                string[] gradeTemp;
                List<int> grade2 = new List<int>();
                
            grades: { 
                Console.WriteLine("Please enter each grade separated by a space.");
                grade1 = Console.ReadLine();
                grade1 = grade1.Trim();
                gradeTemp = grade1.Split(' ');
                foreach (string grade in gradeTemp)
                {
                    int num;
                    bool success = int.TryParse(grade, out num);
                        if(num < 0 || num > 100)
                        {
                            Console.WriteLine("Student grade invalid entry, please re-enter student data.");
                            goto grades;
                        }
                    if (success)
                    {
                        grade2.Add(num);
                    }
                    else
                    {
                        Console.WriteLine("Invalid grade entered. Please re-enter student grade data");
                            goto grades;
                    }
                } }
                students.Add(name, grade2);
                Console.Clear();
                Console.WriteLine("Please enter student name, or enter Quit to finalize data.");
                name = Console.ReadLine();
            }
            foreach(string studentName in students.Keys)
            {
                int low = 100, high = 0, avg = 0;
                Console.WriteLine("Name: " + studentName);
                foreach(int grade in students[studentName])
                {
                    if(grade < low)
                    {
                        low = grade;
                    }
                    if(grade > high)
                    {
                        high = grade;
                    }
                    avg += grade;
                }
                avg = avg / students[studentName].Count();
                Console.Write("Lowest Grade: " +low +"    Highest Grade: " + high+"    Average Grade: " + avg +"\n");
            }
            Console.Read();

        }
    }
}
