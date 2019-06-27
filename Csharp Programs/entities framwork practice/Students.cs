using System;
using System.Collections.Generic;
using System.Text;

namespace entities_framwork_practice
{
    class Student
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Student(string FirstName, string LastName)
        {
           
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}
