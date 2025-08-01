using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Models
{
    public class SemesterCourseSettings
    {
        public string CourseCode { get; set; }
        public string SemesterName { get; set; }
        public double CourseWorkValue { get; set; }
        public double FinalValue { get; set; }

        public Course Course { get; set; }
        public Semester Semester { get; set; }
    }
}
