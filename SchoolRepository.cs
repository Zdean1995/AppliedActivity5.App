using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppliedActivity5.Models;
using System.Net.Http.Json;

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

        public async Task DeleteStudent(Student student)
        {
            int result = 0;
            try
            {
                await Init();
                result = await conn.DeleteAsync(student);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. Error: {1}", student.Name, ex.Message);
            }
        }
        public async Task DeleteCourse(Course course)
        {
            int result = 0;
            try
            {
                await Init();
                result = await conn.DeleteAsync(course);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. Error: {1}", course.Name, ex.Message);
            }
        }
    }
}
