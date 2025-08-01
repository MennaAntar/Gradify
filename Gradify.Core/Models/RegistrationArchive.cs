using Gradify.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Models
{
    public class RegistrationArchive
    {
        public int Id { get; set; }
        public string SemesterName { get; set; }
        public int StudentId { get; set; }
        public string CourseCode { get; set; }
        public DateTime RegistrationDate { get; set; }
        public double FinalMarks { get; set; }
        public bool IsAbsentFinal { get; set; }
        public Grades? Grade { get; set; }

        public Student Student { get; set; }
        public Semester Semester { get; set; }
        public Course Course { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }

}
