using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliedActivity5.Models
{
    internal class StudentCourse
    {
        [ForeignKey(typeof(Student))]
        public int StudentId { get; set; }
        [ForeignKey(typeof(Course))]
        public int CourseId { get; set; }
        public decimal Mark { get; set; }
    }
}
