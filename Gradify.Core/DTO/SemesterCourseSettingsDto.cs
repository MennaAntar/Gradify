using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.DTO
{
    public class SemesterCourseSettingsDto
    {
        [Required]
        public string CourseCode { get; set; }
        [Required]
        public string SemesterName { get; set; }
        [Required]
        public double CourseWorkValue { get; set; }
        [Required]
        public double FinalValue { get; set; }
    }
}
