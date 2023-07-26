using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AppliedActivity5.Models
{
    [Table("Courses")]
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string CourseCode { get; set; }
        [MaxLength(250)]
        public string Professor { get; set; }

        [ManyToMany(typeof(Student))]
        public List<Student> Students { get; set; }
    }
}
