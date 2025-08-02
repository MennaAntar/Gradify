using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Responses
{
    public class SemesterCourseSettingsResponse
    {
        public string CourseCode { get; set; }
        public string SemesterName { get; set; }
        public double CourseWorkValue { get; set; }
        public double FinalValue { get; set; }
    }
}
