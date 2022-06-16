using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using  simpleApp.Models;
using  simpleApp.Services;

namespace simpleApp.Daos
{
    public class StudentDao: StudentService
    {

        private readonly ILogger<StudentDao> _logger;
        private readonly List<Student> students = new List<Student>();
        private static string connStr = "server=localhost;user=root;password=test1234;database=StudentDB";
        private  static MySqlConnection conn = new MySqlConnection(connStr);

        public StudentDao(){
        }
        public StudentDao(ILogger<StudentDao> logger){
            _logger = logger;
        }

        public List<Student> getStudents() {

            try
            {
                conn.Open();

                string sql = "SELECT id, name, gpa From students";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    students.Add(new Student((int) rdr[0], (string) rdr[1], (double) rdr[2]));
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
            conn.Close();
            return students;
        }

        public Student getStudentById( int id) {
            var student = new Student();
            try
            {
                conn.Open();
                string sql = $"SELECT id, name, gpa From students  where id = {id}";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                   student.id = (int) rdr[0];
                   student.name = (string) rdr[1];
                   student.gpa = (double) rdr[2];
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
            conn.Close();
            return student;
        }

        public string addStudent( Student student) {
            try
            {
                conn.Open();
                string sql = $"INSERT INTO students (id, name, gpa) VALUES ({student.id}, '{student.name}', {student.gpa})";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                _logger.LogInformation("Student aready exists.");
            }
            conn.Close();
            return $"Student with id {student.id} added";
        }

        public string updateStudent( Student student) {
            try
            {
                conn.Open();
                string sql = $"UPDATE students  set name = '{student.name}', gpa = {student.gpa} where id = {student.id}";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                _logger.LogInformation("Student not found.");
            }
            conn.Close();
            return $"Student with id {student.id} updated";
        }

         public string removeStudent(int id) {
             try
             {
                 conn.Open();
                 string sql = $"DELETE FROM students WHERE id  = {id}";
                 MySqlCommand cmd = new MySqlCommand(sql, conn);
                 cmd.ExecuteNonQuery();
                 conn.Close();
             }
             catch (MySqlException ex)
             {
                 _logger.LogInformation("Student not found.");
             }
             conn.Close();
             return $"Student with id {id} deleted";
         }
    }
}
