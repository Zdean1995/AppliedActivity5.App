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
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        [ForeignKey(typeof(Course))]
        public int CourseId { get; set; }
    }
}
