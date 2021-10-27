using System;
using  simpleApp.Models;

namespace simpleApp.Services
{
    public interface StudentService
    {
        public List<Student> getStudents();

        public Student getStudentById( int id);

        public string addStudent( Student student) ;

        public string updateStudent( Student student);

        public string removeStudent(int id);
    }
}
