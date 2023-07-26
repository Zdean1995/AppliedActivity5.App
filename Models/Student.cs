using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AppliedActivity5.Models
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        [ManyToMany(typeof(StudentCourse))]
        public List<Course> Courses { get; set; }
    }
}
