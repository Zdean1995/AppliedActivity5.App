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

        private SQLiteAsyncConnection conn;

        private async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Student>();
            await conn.CreateTableAsync<Course>();
            await conn.CreateTableAsync<StudentCourse>();

            await conn.DeleteAllAsync<Student>();
            await conn.DeleteAllAsync<Course>();
            await conn.DeleteAllAsync<StudentCourse>();

            await conn.InsertAsync(new Student { Name = "Anish Acharya", Email= "aachary3@mycambrian.ca", PhoneNumber=1234567890});
            await conn.InsertAsync(new Student { Name = "Bikash Chhantyal", Email = "bchhanty@mycambrian.ca", PhoneNumber = 1234567890 });
            await conn.InsertAsync(new Student { Name = "Zachary Dean", Email = "zdean@mycambrian.ca", PhoneNumber = 1234567890 });
            await conn.InsertAsync(new Student { Name = "Vijaybhai Virambhai Desai", Email = "vdesai5@mycambrian.ca", PhoneNumber = 1234567890 });
            await conn.InsertAsync(new Student { Name = "Deepshika Ghale", Email = "dghale@mycambrian.ca", PhoneNumber = 1234567890 });

            await conn.InsertAsync(new Course { Name = "Software Project Management", CourseCode = "PRM-1111", Professor = "Saifur Rahman" });
            await conn.InsertAsync(new Course { Name = "Advanced Android Development", CourseCode = "ISP-1004 ", Professor = "Manisha Goud Ranga" });
            await conn.InsertAsync(new Course { Name = "Cloud Computing Fundamentals", CourseCode = "ISP-1003", Professor = "Jeffrey Maitland" });
            await conn.InsertAsync(new Course { Name = "Advanced Web Development", CourseCode = "CMP-1005", Professor = "Brent Ritchie" });
            await conn.InsertAsync(new Course { Name = "Advanced iOS Development", CourseCode = "CMP-1000", Professor = "Joshua Van Der Most" });
            
            List<Student> students = await GetAllStudents();
            List<Course> courses = await GetAllCourses();

            foreach (Student student in students)
            {
                foreach (Course course in courses)
                {
                    student.Courses.Add(course);
                }
                await conn.UpdateAsync(student);
            }
            
        }

        public SchoolRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task AddNewStudent(Student student)
        {
            int result = 0;
            try
            {
                await Init();
                result = await conn.InsertAsync(student);

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, student.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", student.Name, ex.Message);
            }

        }

        public async Task<List<Student>> GetAllStudents()
        {
            try
            {
                await Init();
                return await conn.Table<Student>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Student>();
        }

        public async Task AddNewCourse(Course course)
        {
            int result = 0;
            try
            {
                await Init();
                result = await conn.InsertAsync(course);

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, course.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", course.Name, ex.Message);
            }

        }

        public async Task<List<Course>> GetAllCourses()
        {
            try
            {
                await Init();
                return await conn.Table<Course>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Course>();
        }

        public async Task AssignStudentToCourse(Student student, Course course)
        {
            try
            {
                await Init();
                student.Courses.Add(course);
                await conn.UpdateAsync(student);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0} to {1}. Error: {2}", student.Name, course.Name, ex.Message);
            }
        }
    }
}
