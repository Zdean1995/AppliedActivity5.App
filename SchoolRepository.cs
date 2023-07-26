using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppliedActivity5.Models;

namespace AppliedActivity5
{
    public class SchoolRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Student>();
            conn.CreateTable<Course>();
            conn.CreateTable<StudentCourse>();
        }

        public SchoolRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewStudent(Student student)
        {
            int result = 0;
            try
            {
                Init();
                result = conn.Insert(student);

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, student.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", student.Name, ex.Message);
            }

        }

        public List<Student> GetAllStudents()
        {
            try
            {
                Init();
                return conn.Table<Student>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Student>();
        }

        public void AddNewCourse(Course course)
        {
            int result = 0;
            try
            {
                Init();
                result = conn.Insert(course);

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, course.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", course.Name, ex.Message);
            }

        }

        public List<Course> GetAllCourses()
        {
            try
            {
                Init();
                return conn.Table<Course>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Course>();
        }
    }
}
