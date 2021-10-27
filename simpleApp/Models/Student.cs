using System;

namespace simpleApp.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public double gpa { get; set; }

        public Student(){}

        public Student(int id,  string name,double gpa)
        {
            this.id = id;
            this.name = name;
            this.gpa = gpa;
        }
    }
}


